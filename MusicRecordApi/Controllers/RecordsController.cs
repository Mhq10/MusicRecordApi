using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicRecordApi.Interfaces;

namespace MusicRecordApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordInterface _recordRepository;
        public RecordsController(IRecordInterface recordRepository)
        {
            _recordRepository = recordRepository;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetAllRecords([FromQuery] string? title, [FromQuery] string? artist, [FromQuery] string? genre, [FromQuery] int? year)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized("You are not authorized to access this resource.");
            }

            var records = _recordRepository.GetAllRecords(title, artist, genre, year);
            return Ok(records);
        }

    }
}
