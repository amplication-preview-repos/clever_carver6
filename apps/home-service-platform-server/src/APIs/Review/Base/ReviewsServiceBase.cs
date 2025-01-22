using HomeServicePlatform.APIs;
using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.APIs.Errors;
using HomeServicePlatform.APIs.Extensions;
using HomeServicePlatform.Infrastructure;
using HomeServicePlatform.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeServicePlatform.APIs;

public abstract class ReviewsServiceBase : IReviewsService
{
    protected readonly HomeServicePlatformDbContext _context;

    public ReviewsServiceBase(HomeServicePlatformDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Review
    /// </summary>
    public async Task<Review> CreateReview(ReviewCreateInput createDto)
    {
        var review = new ReviewDbModel
        {
            Comment = createDto.Comment,
            CreatedAt = createDto.CreatedAt,
            Rating = createDto.Rating,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            review.Id = createDto.Id;
        }
        if (createDto.ServiceProvider != null)
        {
            review.ServiceProvider = await _context
                .ServiceProviders.Where(serviceProvider =>
                    createDto.ServiceProvider.Id == serviceProvider.Id
                )
                .FirstOrDefaultAsync();
        }

        if (createDto.ServiceProviders != null)
        {
            review.ServiceProviders = await _context
                .ServiceProviders.Where(serviceProvider =>
                    createDto.ServiceProviders.Select(t => t.Id).Contains(serviceProvider.Id)
                )
                .ToListAsync();
        }

        if (createDto.User != null)
        {
            review.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Users != null)
        {
            review.Users = await _context
                .Users.Where(user => createDto.Users.Select(t => t.Id).Contains(user.Id))
                .ToListAsync();
        }

        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ReviewDbModel>(review.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Review
    /// </summary>
    public async Task DeleteReview(ReviewWhereUniqueInput uniqueId)
    {
        var review = await _context.Reviews.FindAsync(uniqueId.Id);
        if (review == null)
        {
            throw new NotFoundException();
        }

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Reviews
    /// </summary>
    public async Task<List<Review>> Reviews(ReviewFindManyArgs findManyArgs)
    {
        var reviews = await _context
            .Reviews.Include(x => x.ServiceProvider)
            .Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return reviews.ConvertAll(review => review.ToDto());
    }

    /// <summary>
    /// Meta data about Review records
    /// </summary>
    public async Task<MetadataDto> ReviewsMeta(ReviewFindManyArgs findManyArgs)
    {
        var count = await _context.Reviews.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Review
    /// </summary>
    public async Task<Review> Review(ReviewWhereUniqueInput uniqueId)
    {
        var reviews = await this.Reviews(
            new ReviewFindManyArgs { Where = new ReviewWhereInput { Id = uniqueId.Id } }
        );
        var review = reviews.FirstOrDefault();
        if (review == null)
        {
            throw new NotFoundException();
        }

        return review;
    }

    /// <summary>
    /// Update one Review
    /// </summary>
    public async Task UpdateReview(ReviewWhereUniqueInput uniqueId, ReviewUpdateInput updateDto)
    {
        var review = updateDto.ToModel(uniqueId);

        if (updateDto.ServiceProvider != null)
        {
            review.ServiceProvider = await _context
                .ServiceProviders.Where(serviceProvider =>
                    updateDto.ServiceProvider == serviceProvider.Id
                )
                .FirstOrDefaultAsync();
        }

        if (updateDto.ServiceProviders != null)
        {
            review.ServiceProviders = await _context
                .ServiceProviders.Where(serviceProvider =>
                    updateDto.ServiceProviders.Select(t => t).Contains(serviceProvider.Id)
                )
                .ToListAsync();
        }

        if (updateDto.User != null)
        {
            review.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.Users != null)
        {
            review.Users = await _context
                .Users.Where(user => updateDto.Users.Select(t => t).Contains(user.Id))
                .ToListAsync();
        }

        _context.Entry(review).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Reviews.Any(e => e.Id == review.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Get a ServiceProvider record for Review
    /// </summary>
    public async Task<ServiceProvider> GetServiceProvider(ReviewWhereUniqueInput uniqueId)
    {
        var review = await _context
            .Reviews.Where(review => review.Id == uniqueId.Id)
            .Include(review => review.ServiceProvider)
            .FirstOrDefaultAsync();
        if (review == null)
        {
            throw new NotFoundException();
        }
        return review.ServiceProvider.ToDto();
    }

    /// <summary>
    /// Connect multiple ServiceProviders records to Review
    /// </summary>
    public async Task ConnectServiceProviders(
        ReviewWhereUniqueInput uniqueId,
        ServiceProviderWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Reviews.Include(x => x.ServiceProviders)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ServiceProviders.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.ServiceProviders);

        foreach (var child in childrenToConnect)
        {
            parent.ServiceProviders.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple ServiceProviders records from Review
    /// </summary>
    public async Task DisconnectServiceProviders(
        ReviewWhereUniqueInput uniqueId,
        ServiceProviderWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Reviews.Include(x => x.ServiceProviders)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ServiceProviders.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.ServiceProviders?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple ServiceProviders records for Review
    /// </summary>
    public async Task<List<ServiceProvider>> FindServiceProviders(
        ReviewWhereUniqueInput uniqueId,
        ServiceProviderFindManyArgs reviewFindManyArgs
    )
    {
        var serviceProviders = await _context
            .ServiceProviders.Where(m => m.ReviewId == uniqueId.Id)
            .ApplyWhere(reviewFindManyArgs.Where)
            .ApplySkip(reviewFindManyArgs.Skip)
            .ApplyTake(reviewFindManyArgs.Take)
            .ApplyOrderBy(reviewFindManyArgs.SortBy)
            .ToListAsync();

        return serviceProviders.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple ServiceProviders records for Review
    /// </summary>
    public async Task UpdateServiceProviders(
        ReviewWhereUniqueInput uniqueId,
        ServiceProviderWhereUniqueInput[] childrenIds
    )
    {
        var review = await _context
            .Reviews.Include(t => t.ServiceProviders)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (review == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ServiceProviders.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        review.ServiceProviders = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Get a User record for Review
    /// </summary>
    public async Task<User> GetUser(ReviewWhereUniqueInput uniqueId)
    {
        var review = await _context
            .Reviews.Where(review => review.Id == uniqueId.Id)
            .Include(review => review.User)
            .FirstOrDefaultAsync();
        if (review == null)
        {
            throw new NotFoundException();
        }
        return review.User.ToDto();
    }

    /// <summary>
    /// Connect multiple Users records to Review
    /// </summary>
    public async Task ConnectUsers(
        ReviewWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Reviews.Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Users.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Users);

        foreach (var child in childrenToConnect)
        {
            parent.Users.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Users records from Review
    /// </summary>
    public async Task DisconnectUsers(
        ReviewWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Reviews.Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Users.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Users?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Users records for Review
    /// </summary>
    public async Task<List<User>> FindUsers(
        ReviewWhereUniqueInput uniqueId,
        UserFindManyArgs reviewFindManyArgs
    )
    {
        var users = await _context
            .Users.Where(m => m.ReviewId == uniqueId.Id)
            .ApplyWhere(reviewFindManyArgs.Where)
            .ApplySkip(reviewFindManyArgs.Skip)
            .ApplyTake(reviewFindManyArgs.Take)
            .ApplyOrderBy(reviewFindManyArgs.SortBy)
            .ToListAsync();

        return users.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Users records for Review
    /// </summary>
    public async Task UpdateUsers(
        ReviewWhereUniqueInput uniqueId,
        UserWhereUniqueInput[] childrenIds
    )
    {
        var review = await _context
            .Reviews.Include(t => t.Users)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (review == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Users.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        review.Users = children;
        await _context.SaveChangesAsync();
    }
}
