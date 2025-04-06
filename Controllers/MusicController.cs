using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/music")]
[Authorize]
public class MusicController : ControllerBase
{
    private readonly JamendoService _jamendoService;

    public MusicController(JamendoService jamendoService)
    {
        _jamendoService = jamendoService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchTracks([FromQuery] string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return BadRequest("Search query is required");
        }

        try
        {
            var result = await _jamendoService.SearchTracks(query);
            return Content(result, "application/json");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("popular")]
    public async Task<IActionResult> GetPopularTracks()
    {
        try
        {
            var result = await _jamendoService.GetPopularTracks();
            return Content(result, "application/json");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}