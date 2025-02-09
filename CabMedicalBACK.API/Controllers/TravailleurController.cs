using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CabMedicalBACK.API.DTOs;
using CabMedicalBACK.API.Mappers;
using CabMedicalBACK.BLL.Interfaces;

namespace CabMedicalBACK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravailleurController : ControllerBase
    {
        private readonly ITravailleurService _travailleurService;

        public TravailleurController(ITravailleurService travailleurService)
        {
            _travailleurService = travailleurService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TravailleurDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var list = _travailleurService
                    .GetAll()
                    .Select(t => t.ToDTO());

                return Ok(list);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TravailleurDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                var travailleur = _travailleurService.GetById(id);
                if (travailleur == null)
                    return NotFound($"Travailleur with ID {id} not found.");

                return Ok(travailleur.ToDTO());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TravailleurCreateDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] TravailleurCreateDTO dto)
        {
            try
            {
                int newId = _travailleurService.Create(dto.ToModel());
                if (newId > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id = newId }, dto);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating travailleur");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TravailleurUpdateDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(int id, [FromBody] TravailleurUpdateDTO dto)
        {
            try
            {
                bool updated = _travailleurService.Update(dto.ToModel(id));
                if (updated)
                {
                    return Ok(dto);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating travailleur");
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
                bool deleted = _travailleurService.Delete(id);
                if (deleted)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting travailleur");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
