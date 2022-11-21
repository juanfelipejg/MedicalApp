namespace MedicalApp.Api.Controllers
{
    using MedicalApp.Data.Repositories;
    using MedicalApp.Domain.MedicalApp.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorsController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _doctorRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            return Ok(await _doctorRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var created = await _doctorRepository.Insert(doctor);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoctor([FromBody] Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _doctorRepository.Update(doctor);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorRepository.Delete(id);

            return NoContent();
        }
    }
}
