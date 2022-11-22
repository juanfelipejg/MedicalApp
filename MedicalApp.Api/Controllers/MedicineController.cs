namespace MedicalApp.Api.Controllers
{
    using MedicalApp.Data.Repositories;
    using MedicalApp.Domain.MedicalApp.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineRepository _medicineRepositoy;

        public MedicineController(IMedicineRepository medicineRepository)
        {
            _medicineRepositoy = medicineRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _medicineRepositoy.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicineById(int id)
        {
            return Ok(await _medicineRepositoy.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicine([FromBody] Medicine medicine)
        {
            if (medicine == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var created = await _medicineRepositoy.Insert(medicine);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMedicine([FromBody] Medicine medicine)
        {
            if (medicine == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _medicineRepositoy.Update(medicine);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            await _medicineRepositoy.Delete(id);

            return NoContent();
        }
    }
}
