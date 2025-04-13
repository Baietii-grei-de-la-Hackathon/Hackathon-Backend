using Microsoft.AspNetCore.Mvc;
using QubHQ_Services.Dtos;
using QubHQ_Services.Services;
using QubHQ_Services.Services.VerifyService;


namespace Hackathon_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VeryfiController : ControllerBase
{
    private readonly IVeryfiService _veryfiService;

    public VeryfiController(IVeryfiService veryfiService)
    {
        _veryfiService = veryfiService;
    }

    [HttpPost("ocr")]
    public async Task<IActionResult> ExtractText([FromBody] ImageDto imageDto)
    {
        if (string.IsNullOrEmpty(imageDto.Base64Image))
            return BadRequest("No base64 string provided.");

        try
        {
            var ocrResult = await _veryfiService.ExtractText(imageDto);

            return Ok(ocrResult);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}