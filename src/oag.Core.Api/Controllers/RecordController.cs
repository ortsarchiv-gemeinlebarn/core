using Microsoft.AspNetCore.Mvc;
using oag.Core.Services;
using oag.Core.Dto;
using oag.Core.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace oag.Core.Controllers;

[ApiController]
[Route("api/v1/records")]
public class RecordsController : ControllerBase
{
    private readonly RecordService recordService;

    public RecordsController(RecordService recordService)
    {
        this.recordService = recordService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecordDto>> Get(Guid id)
    {
        var record = await this.recordService.GetAsync(id);

        if (record is null)
        {
            return NotFound();
        }

        return record;
    }

    [HttpGet("{id}/orientation")]
    public async Task<ActionResult<RecordOrentationDto>> GetOriantation(Guid id)
    {
        var record = await this.recordService.GetOrientationAsync(id);

        if (record is null)
        {
            return NotFound();
        }

        return record;
    }

    [HttpPost("")]
    public async Task<ActionResult<RecordDto>> UpdateOrCreate([FromBody] Record record)
    {
        if (!await this.recordService.IsValidUniqueReferenceCode(record))
        {
            return Problem(
                title: $"Reference Code '{record.IdentityManagement.ReferenceCode}' inside of Parent Record '{record.ParentId}' is not unique!",
                statusCode: 400
            );
        }

        if (record.Id != Guid.Empty)
        {
            return await this.recordService.UpdateAsync(record);
        }

        return await this.recordService.CreateAsync(record);
    }

    [HttpDelete("{id}")]
    public ActionResult<bool> Delete(Guid id)
    {
        // Check if any Record has Id as Parent
        throw new NotImplementedException();
    }
}