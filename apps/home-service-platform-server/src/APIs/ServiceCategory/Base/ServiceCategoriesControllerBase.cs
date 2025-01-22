using HomeServicePlatform.APIs;
using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HomeServicePlatform.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ServiceCategoriesControllerBase : ControllerBase
{
    protected readonly IServiceCategoriesService _service;

    public ServiceCategoriesControllerBase(IServiceCategoriesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one ServiceCategory
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ServiceCategory>> CreateServiceCategory(
        ServiceCategoryCreateInput input
    )
    {
        var serviceCategory = await _service.CreateServiceCategory(input);

        return CreatedAtAction(
            nameof(ServiceCategory),
            new { id = serviceCategory.Id },
            serviceCategory
        );
    }

    /// <summary>
    /// Delete one ServiceCategory
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteServiceCategory(
        [FromRoute()] ServiceCategoryWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteServiceCategory(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ServiceCategories
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ServiceCategory>>> ServiceCategories(
        [FromQuery()] ServiceCategoryFindManyArgs filter
    )
    {
        return Ok(await _service.ServiceCategories(filter));
    }

    /// <summary>
    /// Meta data about ServiceCategory records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ServiceCategoriesMeta(
        [FromQuery()] ServiceCategoryFindManyArgs filter
    )
    {
        return Ok(await _service.ServiceCategoriesMeta(filter));
    }

    /// <summary>
    /// Get one ServiceCategory
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ServiceCategory>> ServiceCategory(
        [FromRoute()] ServiceCategoryWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ServiceCategory(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one ServiceCategory
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateServiceCategory(
        [FromRoute()] ServiceCategoryWhereUniqueInput uniqueId,
        [FromQuery()] ServiceCategoryUpdateInput serviceCategoryUpdateDto
    )
    {
        try
        {
            await _service.UpdateServiceCategory(uniqueId, serviceCategoryUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Bookings records to ServiceCategory
    /// </summary>
    [HttpPost("{Id}/bookings")]
    public async Task<ActionResult> ConnectBookings(
        [FromRoute()] ServiceCategoryWhereUniqueInput uniqueId,
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
    /// Disconnect multiple Bookings records from ServiceCategory
    /// </summary>
    [HttpDelete("{Id}/bookings")]
    public async Task<ActionResult> DisconnectBookings(
        [FromRoute()] ServiceCategoryWhereUniqueInput uniqueId,
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
    /// Find multiple Bookings records for ServiceCategory
    /// </summary>
    [HttpGet("{Id}/bookings")]
    public async Task<ActionResult<List<Booking>>> FindBookings(
        [FromRoute()] ServiceCategoryWhereUniqueInput uniqueId,
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
    /// Update multiple Bookings records for ServiceCategory
    /// </summary>
    [HttpPatch("{Id}/bookings")]
    public async Task<ActionResult> UpdateBookings(
        [FromRoute()] ServiceCategoryWhereUniqueInput uniqueId,
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
    /// Get a ServiceProvider record for ServiceCategory
    /// </summary>
    [HttpGet("{Id}/serviceProvider")]
    public async Task<ActionResult<List<ServiceProvider>>> GetServiceProvider(
        [FromRoute()] ServiceCategoryWhereUniqueInput uniqueId
    )
    {
        var serviceProvider = await _service.GetServiceProvider(uniqueId);
        return Ok(serviceProvider);
    }
}
