using HomeServicePlatform.APIs;
using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HomeServicePlatform.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class BookingsControllerBase : ControllerBase
{
    protected readonly IBookingsService _service;

    public BookingsControllerBase(IBookingsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Booking
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Booking>> CreateBooking(BookingCreateInput input)
    {
        var booking = await _service.CreateBooking(input);

        return CreatedAtAction(nameof(Booking), new { id = booking.Id }, booking);
    }

    /// <summary>
    /// Delete one Booking
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteBooking([FromRoute()] BookingWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteBooking(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Bookings
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Booking>>> Bookings(
        [FromQuery()] BookingFindManyArgs filter
    )
    {
        return Ok(await _service.Bookings(filter));
    }

    /// <summary>
    /// Meta data about Booking records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> BookingsMeta(
        [FromQuery()] BookingFindManyArgs filter
    )
    {
        return Ok(await _service.BookingsMeta(filter));
    }

    /// <summary>
    /// Get one Booking
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Booking>> Booking([FromRoute()] BookingWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Booking(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Booking
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateBooking(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
        [FromQuery()] BookingUpdateInput bookingUpdateDto
    )
    {
        try
        {
            await _service.UpdateBooking(uniqueId, bookingUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a ServiceCategory record for Booking
    /// </summary>
    [HttpGet("{Id}/serviceCategory")]
    public async Task<ActionResult<List<ServiceCategory>>> GetServiceCategory(
        [FromRoute()] BookingWhereUniqueInput uniqueId
    )
    {
        var serviceCategory = await _service.GetServiceCategory(uniqueId);
        return Ok(serviceCategory);
    }

    /// <summary>
    /// Get a ServiceProvider record for Booking
    /// </summary>
    [HttpGet("{Id}/serviceProvider")]
    public async Task<ActionResult<List<ServiceProvider>>> GetServiceProvider(
        [FromRoute()] BookingWhereUniqueInput uniqueId
    )
    {
        var serviceProvider = await _service.GetServiceProvider(uniqueId);
        return Ok(serviceProvider);
    }

    /// <summary>
    /// Connect multiple ServiceProviders records to Booking
    /// </summary>
    [HttpPost("{Id}/serviceProviders")]
    public async Task<ActionResult> ConnectServiceProviders(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
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
    /// Disconnect multiple ServiceProviders records from Booking
    /// </summary>
    [HttpDelete("{Id}/serviceProviders")]
    public async Task<ActionResult> DisconnectServiceProviders(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
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
    /// Find multiple ServiceProviders records for Booking
    /// </summary>
    [HttpGet("{Id}/serviceProviders")]
    public async Task<ActionResult<List<ServiceProvider>>> FindServiceProviders(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
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
    /// Update multiple ServiceProviders records for Booking
    /// </summary>
    [HttpPatch("{Id}/serviceProviders")]
    public async Task<ActionResult> UpdateServiceProviders(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
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
    /// Get a User record for Booking
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] BookingWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Connect multiple Users records to Booking
    /// </summary>
    [HttpPost("{Id}/users")]
    public async Task<ActionResult> ConnectUsers(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
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
    /// Disconnect multiple Users records from Booking
    /// </summary>
    [HttpDelete("{Id}/users")]
    public async Task<ActionResult> DisconnectUsers(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
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
    /// Find multiple Users records for Booking
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> FindUsers(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
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
    /// Update multiple Users records for Booking
    /// </summary>
    [HttpPatch("{Id}/users")]
    public async Task<ActionResult> UpdateUsers(
        [FromRoute()] BookingWhereUniqueInput uniqueId,
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
