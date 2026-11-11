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
        public IActionResult GetAllRecords()
        {
            var records = _recordRepository.GetAllRecords();
            return Ok(records);
        }

    }
}
