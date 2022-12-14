namespace MedicalApp.Api.Controllers
{
    using MedicalApp.Data.Repositories;
    using MedicalApp.Domain.MedicalApp.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController: ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _patientRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            return Ok(await _patientRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] Patient patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var created = await _patientRepository.Insert(patient);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatient([FromBody] Patient patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _patientRepository.Update(patient);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientRepository.Delete(id);

            return NoContent();
        }
    }
}
