using HomeServicePlatform.APIs;
using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HomeServicePlatform.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ReviewsControllerBase : ControllerBase
{
    protected readonly IReviewsService _service;

    public ReviewsControllerBase(IReviewsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Review
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Review>> CreateReview(ReviewCreateInput input)
    {
        var review = await _service.CreateReview(input);

        return CreatedAtAction(nameof(Review), new { id = review.Id }, review);
    }

    /// <summary>
    /// Delete one Review
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteReview([FromRoute()] ReviewWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteReview(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Reviews
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Review>>> Reviews([FromQuery()] ReviewFindManyArgs filter)
    {
        return Ok(await _service.Reviews(filter));
    }

    /// <summary>
    /// Meta data about Review records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ReviewsMeta(
        [FromQuery()] ReviewFindManyArgs filter
    )
    {
        return Ok(await _service.ReviewsMeta(filter));
    }

    /// <summary>
    /// Get one Review
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Review>> Review([FromRoute()] ReviewWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Review(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Review
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateReview(
        [FromRoute()] ReviewWhereUniqueInput uniqueId,
        [FromQuery()] ReviewUpdateInput reviewUpdateDto
    )
    {
        try
        {
            await _service.UpdateReview(uniqueId, reviewUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a ServiceProvider record for Review
    /// </summary>
    [HttpGet("{Id}/serviceProvider")]
    public async Task<ActionResult<List<ServiceProvider>>> GetServiceProvider(
        [FromRoute()] ReviewWhereUniqueInput uniqueId
    )
    {
        var serviceProvider = await _service.GetServiceProvider(uniqueId);
        return Ok(serviceProvider);
    }

    /// <summary>
    /// Connect multiple ServiceProviders records to Review
    /// </summary>
    [HttpPost("{Id}/serviceProviders")]
    public async Task<ActionResult> ConnectServiceProviders(
        [FromRoute()] ReviewWhereUniqueInput uniqueId,
        [FromQuery()] ServiceProviderWhereUniqueInput[] serviceProvidersId
    )
    {
        try
        {
            await _service.ConnectServiceProviders(uniqueId, serviceProvidersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple ServiceProviders records from Review
    /// </summary>
    [HttpDelete("{Id}/serviceProviders")]
    public async Task<ActionResult> DisconnectServiceProviders(
        [FromRoute()] ReviewWhereUniqueInput uniqueId,
        [FromBody()] ServiceProviderWhereUniqueInput[] serviceProvidersId
    )
    {
        try
        {
            await _service.DisconnectServiceProviders(uniqueId, serviceProvidersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple ServiceProviders records for Review
    /// </summary>
    [HttpGet("{Id}/serviceProviders")]
    public async Task<ActionResult<List<ServiceProvider>>> FindServiceProviders(
        [FromRoute()] ReviewWhereUniqueInput uniqueId,
        [FromQuery()] ServiceProviderFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindServiceProviders(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple ServiceProviders records for Review
    /// </summary>
    [HttpPatch("{Id}/serviceProviders")]
    public async Task<ActionResult> UpdateServiceProviders(
        [FromRoute()] ReviewWhereUniqueInput uniqueId,
        [FromBody()] ServiceProviderWhereUniqueInput[] serviceProvidersId
    )
    {
        try
        {
            await _service.UpdateServiceProviders(uniqueId, serviceProvidersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a User record for Review
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] ReviewWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Connect multiple Users records to Review
    /// </summary>
    [HttpPost("{Id}/users")]
    public async Task<ActionResult> ConnectUsers(
        [FromRoute()] ReviewWhereUniqueInput uniqueId,
        [FromQuery()] UserWhereUniqueInput[] usersId
    )
    {
        try
        {
            await _service.ConnectUsers(uniqueId, usersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Users records from Review
    /// </summary>
    [HttpDelete("{Id}/users")]
    public async Task<ActionResult> DisconnectUsers(
        [FromRoute()] ReviewWhereUniqueInput uniqueId,
        [FromBody()] UserWhereUniqueInput[] usersId
    )
    {
        try
        {
            await _service.DisconnectUsers(uniqueId, usersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Users records for Review
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> FindUsers(
        [FromRoute()] ReviewWhereUniqueInput uniqueId,
        [FromQuery()] UserFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindUsers(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Users records for Review
    /// </summary>
    [HttpPatch("{Id}/users")]
    public async Task<ActionResult> UpdateUsers(
        [FromRoute()] ReviewWhereUniqueInput uniqueId,
        [FromBody()] UserWhereUniqueInput[] usersId
    )
    {
        try
        {
            await _service.UpdateUsers(uniqueId, usersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
