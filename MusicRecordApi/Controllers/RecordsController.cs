using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicRecordApi.Interfaces;
using MusicRecordApi.Models;

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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult AddRecord([FromBody] Record record)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized("You are not authorized to access this resource.");
            }
            if (record == null)
            {
                return BadRequest("Record cannot be null.");
            }
            var addedRecord = _recordRepository.AddRecord(record);

            return CreatedAtAction(nameof(GetAllRecords), new { id = addedRecord.Id }, addedRecord);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateRecord([FromBody] Record record)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized("You are not authorized to access this resource.");
            }
            if (record == null)
            {
                return BadRequest("Record cannot be null.");
            }

            var updatedRecord = _recordRepository.UpdateRecord(record);
            return Ok(updatedRecord);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteRecord(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized("You are not authorized to access this resource.");
            }
            var deletedRecord = _recordRepository.DeleteRecord(id);
            if (deletedRecord == null)
            {
                return NotFound($"Record with ID {id} not found.");
            }
            return Ok(deletedRecord);
        }
    }
}
