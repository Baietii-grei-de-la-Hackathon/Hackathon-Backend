using Microsoft.AspNetCore.Mvc;
using QubHQ_Services.Services;


namespace Hackathon_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VeryfiController : ControllerBase
{
    private readonly VeryfiService _veryfiService;

    public VeryfiController(VeryfiService veryfiService)
    {
        _veryfiService = veryfiService;
    }

    [HttpPost("ocr")]
    public async Task<IActionResult> ExtractText([FromBody] string base64Image)
    {
        if (string.IsNullOrEmpty(base64Image))
            return BadRequest("No base64 string provided.");

        try
        {
            var ocrResult = await _veryfiService.ExtractText(base64Image);

            return Ok(ocrResult);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}