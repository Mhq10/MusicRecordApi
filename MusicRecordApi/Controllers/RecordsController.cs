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

        [HttpGet]
        [EnableCors("ReadOnly")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllRecords([FromQuery] string? title, [FromQuery] string? artist, [FromQuery] string? genre, [FromQuery] int? year)
        {
            var records = _recordRepository.GetAllRecords(title, artist, genre, year);
            return Ok(records);
        }

    }
}
