using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CabMedicalBACK.API.DTOs;
using CabMedicalBACK.API.Mappers;
using CabMedicalBACK.BLL.Interfaces;

namespace CabMedicalBACK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PatientDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var list = _patientService.GetAll()
                                          .Select(p => p.ToDTO());
                return Ok(list);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                var patient = _patientService.GetById(id);
                if (patient == null)
                    return NotFound($"Patient with ID {id} not found.");

                return Ok(patient.ToDTO());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PatientCreateDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] PatientCreateDTO dto)
        {
            try
            {
                int newId = _patientService.Create(dto.ToModel());
                if (newId > 0)
                {
                    // On renvoie l'emplacement de la ressource créée
                    return CreatedAtAction(nameof(GetById), new { id = newId }, dto);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating patient");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientUpdateDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(int id, [FromBody] PatientUpdateDTO dto)
        {
            try
            {
                bool updated = _patientService.Update(dto.ToModel(id));
                if (updated)
                {
                    return Ok(dto);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating patient");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _patientService.Delete(id);
                if (deleted)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting patient");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
