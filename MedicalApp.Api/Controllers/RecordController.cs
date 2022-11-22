namespace MedicalApp.Api.Controllers
{
    using MedicalApp.Data.Repositories;
    using MedicalApp.Domain.MedicalApp.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordRepository _recordRepositoy;
        public RecordController(IRecordRepository recordRepository)
        {
            _recordRepositoy = recordRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _recordRepositoy.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecordById(int id)
        {
            return Ok(await _recordRepositoy.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicine([FromBody] Record record)
        {
            if (record == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var created = await _recordRepositoy.Insert(record);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRecord([FromBody] Record record)
        {
            if (record == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _recordRepositoy.Update(record);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            await _recordRepositoy.Delete(id);

            return NoContent();
        }
    }
}
