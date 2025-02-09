using CabMedicalBACK.API.DTOs;
using CabMedicalBACK.API.Mappers;
using CabMedicalBACK.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CabMedicalBACK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly IUtilisateurService _utilisateurService;

        public UtilisateurController(IUtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UtilisateurDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var utilisateurs = _utilisateurService.GetAll()
                    .Select(u => u.ToDTO());
                return Ok(utilisateurs);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UtilisateurDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                var utilisateur = _utilisateurService.GetById(id);
                if (utilisateur == null)
                    return NotFound($"Utilisateur with ID {id} not found.");

                return Ok(utilisateur.ToDTO());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UtilisateurCreateDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] UtilisateurCreateDTO dto)
        {
            try
            {
                int newId = _utilisateurService.Create(dto.ToModel());
                if (newId > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id = newId }, dto);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create utilisateur.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UtilisateurUpdateDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(int id, [FromBody] UtilisateurUpdateDTO dto)
        {
            try
            {
                var toUpdate = dto.ToModel(id);
                bool success = _utilisateurService.Update(toUpdate);
                if (!success)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Could not update utilisateur.");

                return Ok(toUpdate);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
