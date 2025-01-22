using HomeServicePlatform.APIs;
using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HomeServicePlatform.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ServiceProvidersControllerBase : ControllerBase
{
    protected readonly IServiceProvidersService _service;

    public ServiceProvidersControllerBase(IServiceProvidersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one ServiceProvider
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ServiceProvider>> CreateServiceProvider(
        ServiceProviderCreateInput input
    )
    {
        var serviceProvider = await _service.CreateServiceProvider(input);

        return CreatedAtAction(
            nameof(ServiceProvider),
            new { id = serviceProvider.Id },
            serviceProvider
        );
    }

    /// <summary>
    /// Delete one ServiceProvider
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteServiceProvider(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteServiceProvider(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ServiceProviders
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ServiceProvider>>> ServiceProviders(
        [FromQuery()] ServiceProviderFindManyArgs filter
    )
    {
        return Ok(await _service.ServiceProviders(filter));
    }

    /// <summary>
    /// Meta data about ServiceProvider records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ServiceProvidersMeta(
        [FromQuery()] ServiceProviderFindManyArgs filter
    )
    {
        return Ok(await _service.ServiceProvidersMeta(filter));
    }

    /// <summary>
    /// Get one ServiceProvider
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ServiceProvider>> ServiceProvider(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ServiceProvider(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one ServiceProvider
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateServiceProvider(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId,
        [FromQuery()] ServiceProviderUpdateInput serviceProviderUpdateDto
    )
    {
        try
        {
            await _service.UpdateServiceProvider(uniqueId, serviceProviderUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Booking record for ServiceProvider
    /// </summary>
    [HttpGet("{Id}/booking")]
    public async Task<ActionResult<List<Booking>>> GetBooking(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId
    )
    {
        var booking = await _service.GetBooking(uniqueId);
        return Ok(booking);
    }

    /// <summary>
    /// Connect multiple Bookings records to ServiceProvider
    /// </summary>
    [HttpPost("{Id}/bookings")]
    public async Task<ActionResult> ConnectBookings(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId,
        [FromQuery()] BookingWhereUniqueInput[] bookingsId
    )
    {
        try
        {
            await _service.ConnectBookings(uniqueId, bookingsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Bookings records from ServiceProvider
    /// </summary>
    [HttpDelete("{Id}/bookings")]
    public async Task<ActionResult> DisconnectBookings(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId,
        [FromBody()] BookingWhereUniqueInput[] bookingsId
    )
    {
        try
        {
            await _service.DisconnectBookings(uniqueId, bookingsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Bookings records for ServiceProvider
    /// </summary>
    [HttpGet("{Id}/bookings")]
    public async Task<ActionResult<List<Booking>>> FindBookings(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId,
        [FromQuery()] BookingFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindBookings(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Bookings records for ServiceProvider
    /// </summary>
    [HttpPatch("{Id}/bookings")]
    public async Task<ActionResult> UpdateBookings(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId,
        [FromBody()] BookingWhereUniqueInput[] bookingsId
    )
    {
        try
        {
            await _service.UpdateBookings(uniqueId, bookingsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Review record for ServiceProvider
    /// </summary>
    [HttpGet("{Id}/review")]
    public async Task<ActionResult<List<Review>>> GetReview(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId
    )
    {
        var review = await _service.GetReview(uniqueId);
        return Ok(review);
    }

    /// <summary>
    /// Connect multiple Reviews records to ServiceProvider
    /// </summary>
    [HttpPost("{Id}/reviews")]
    public async Task<ActionResult> ConnectReviews(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId,
        [FromQuery()] ReviewWhereUniqueInput[] reviewsId
    )
    {
        try
        {
            await _service.ConnectReviews(uniqueId, reviewsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Reviews records from ServiceProvider
    /// </summary>
    [HttpDelete("{Id}/reviews")]
    public async Task<ActionResult> DisconnectReviews(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId,
        [FromBody()] ReviewWhereUniqueInput[] reviewsId
    )
    {
        try
        {
            await _service.DisconnectReviews(uniqueId, reviewsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Reviews records for ServiceProvider
    /// </summary>
    [HttpGet("{Id}/reviews")]
    public async Task<ActionResult<List<Review>>> FindReviews(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId,
        [FromQuery()] ReviewFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindReviews(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Reviews records for ServiceProvider
    /// </summary>
    [HttpPatch("{Id}/reviews")]
    public async Task<ActionResult> UpdateReviews(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId,
        [FromBody()] ReviewWhereUniqueInput[] reviewsId
    )
    {
        try
        {
            await _service.UpdateReviews(uniqueId, reviewsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple ServiceCategories records to ServiceProvider
    /// </summary>
    [HttpPost("{Id}/serviceCategories")]
    public async Task<ActionResult> ConnectServiceCategories(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId,
        [FromQuery()] ServiceCategoryWhereUniqueInput[] serviceCategoriesId
    )
    {
        try
        {
            await _service.ConnectServiceCategories(uniqueId, serviceCategoriesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple ServiceCategories records from ServiceProvider
    /// </summary>
    [HttpDelete("{Id}/serviceCategories")]
    public async Task<ActionResult> DisconnectServiceCategories(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId,
        [FromBody()] ServiceCategoryWhereUniqueInput[] serviceCategoriesId
    )
    {
        try
        {
            await _service.DisconnectServiceCategories(uniqueId, serviceCategoriesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple ServiceCategories records for ServiceProvider
    /// </summary>
    [HttpGet("{Id}/serviceCategories")]
    public async Task<ActionResult<List<ServiceCategory>>> FindServiceCategories(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId,
        [FromQuery()] ServiceCategoryFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindServiceCategories(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple ServiceCategories records for ServiceProvider
    /// </summary>
    [HttpPatch("{Id}/serviceCategories")]
    public async Task<ActionResult> UpdateServiceCategories(
        [FromRoute()] ServiceProviderWhereUniqueInput uniqueId,
        [FromBody()] ServiceCategoryWhereUniqueInput[] serviceCategoriesId
    )
    {
        try
        {
            await _service.UpdateServiceCategories(uniqueId, serviceCategoriesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
