using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CabMedicalBACK.API.DTOs;
using CabMedicalBACK.API.Mappers;
using CabMedicalBACK.BLL.Interfaces;
using Newtonsoft.Json;

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
                Console.WriteLine($"Début GetByUtilisateur - ID: {idUtilisateur}");
        
                var rdvList = _rendezVousService.GetByUtilisateur(idUtilisateur);
                Console.WriteLine($"Rendez-vous récupérés : {rdvList?.Count() ?? 0}");
        
                var resultDto = rdvList.Select(r => r.ToDTO());
                Console.WriteLine("Conversion en DTO réussie");
        
                return Ok(resultDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERREUR dans GetByUtilisateur: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RendezVousCreateDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] RendezVousCreateDTO dto)
        {
            try
            {
                // ✅ Log pour voir les données reçues
                Console.WriteLine("Requête reçue pour la création d'un rendez-vous.");
                Console.WriteLine($"Données reçues: {JsonConvert.SerializeObject(dto)}");

                // ❌ Vérification que l'objet DTO n'est pas null
                if (dto == null)
                {
                    Console.WriteLine("Erreur : l'objet reçu est null.");
                    return BadRequest("Les données envoyées sont null.");
                }

                // ⚠ Vérification des champs obligatoires
                if (dto.DateDebut == default || dto.DateFin == default)
                {
                    Console.WriteLine("Erreur : DateDebut ou DateFin est vide.");
                    return BadRequest("Les dates de début et de fin sont obligatoires.");
                }

                if (dto.IdUtilisateur <= 0)
                {
                    Console.WriteLine("Erreur : Aucun médecin sélectionné.");
                    return BadRequest("Un médecin doit être sélectionné pour ce rendez-vous.");
                }

                // ✅ Création du rendez-vous
                int newId = _rendezVousService.Create(dto.ToModel());
                if (newId > 0)
                {
                    Console.WriteLine($"Rendez-vous créé avec l'ID: {newId}");
                    return CreatedAtAction(nameof(GetById), new { id = newId }, dto);
                }

                // ❌ Si l'insertion en base de données échoue
                Console.WriteLine("Échec de la création du rendez-vous.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Impossible de créer le rendez-vous.");
            }
            catch (Exception ex)
            {
                // 🔴 Capture et affichage de l'erreur
                Console.WriteLine($"Exception levée: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
