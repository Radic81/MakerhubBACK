using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CabMedicalBACK.API.DTOs;
using CabMedicalBACK.API.Mappers;
using CabMedicalBACK.BLL.Interfaces;

namespace CabMedicalBACK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendezVousController : ControllerBase
    {
        private readonly IRendezVousService _rendezVousService;

        public RendezVousController(IRendezVousService rendezVousService)
        {
            _rendezVousService = rendezVousService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RendezVousDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var liste = _rendezVousService.GetAll().Select(r => r.ToDTO());
                
                return Ok(liste);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RendezVousDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                var rv = _rendezVousService.GetById(id);
                if (rv == null)
                    return NotFound($"Le rendez-vous {id} n'a pas été trouvé");
                
                return Ok(rv.ToDTO());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpGet("utilisateur/{idUtilisateur}")]
        public IActionResult GetByUtilisateur(int idUtilisateur)
        {
            try
            {
                var rdvList = _rendezVousService.GetByUtilisateur(idUtilisateur);
                var resultDto = rdvList.Select(r => r.ToDTO());
                return Ok(resultDto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RendezVousCreateDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] RendezVousCreateDTO dto)
        {
            try
            {
                int newId = _rendezVousService.Create(dto.ToModel());
                if (newId > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id = newId }, dto);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur lors de la création du rendez-vous");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RendezVousUpdateDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(int id, [FromBody] RendezVousUpdateDTO dto)
        {
            try
            {
                bool updated = _rendezVousService.Update(dto.ToModel(id));
                if (updated)
                {
                    return Ok(dto);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur lors de la mise à jour du rendez-vous");
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
                bool deleted = _rendezVousService.Delete(id);
                if (deleted)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur lors de la suppression du rendez-vous");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
