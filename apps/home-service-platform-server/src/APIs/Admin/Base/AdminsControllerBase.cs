using HomeServicePlatform.APIs;
using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.APIs.Dtos;
using HomeServicePlatform.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HomeServicePlatform.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AdminsControllerBase : ControllerBase
{
    protected readonly IAdminsService _service;

    public AdminsControllerBase(IAdminsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Admin
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Admin>> CreateAdmin(AdminCreateInput input)
    {
        var admin = await _service.CreateAdmin(input);

        return CreatedAtAction(nameof(Admin), new { id = admin.Id }, admin);
    }

    /// <summary>
    /// Delete one Admin
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAdmin([FromRoute()] AdminWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteAdmin(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Admins
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Admin>>> Admins([FromQuery()] AdminFindManyArgs filter)
    {
        return Ok(await _service.Admins(filter));
    }

    /// <summary>
    /// Meta data about Admin records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AdminsMeta([FromQuery()] AdminFindManyArgs filter)
    {
        return Ok(await _service.AdminsMeta(filter));
    }

    /// <summary>
    /// Get one Admin
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Admin>> Admin([FromRoute()] AdminWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Admin(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Admin
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAdmin(
        [FromRoute()] AdminWhereUniqueInput uniqueId,
        [FromQuery()] AdminUpdateInput adminUpdateDto
    )
    {
        try
        {
            await _service.UpdateAdmin(uniqueId, adminUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
