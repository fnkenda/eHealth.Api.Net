using eHealth.Api.Models;
using eHealth.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eHealth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedecinsController : ControllerBase
    {
        private IEhealthRepository repository;
        private List<Medecin> _medecins;
        public MedecinsController(IEhealthRepository ehealthRepository)
        {
            repository = ehealthRepository;
            _medecins = repository.GetAll();
        }

        [HttpGet("/api/medecins")]
        public async Task<IActionResult> GetAllMedecins()
        {

            if (_medecins == null)
            {
                return NotFound();
            }

            return Ok(_medecins);
        }

        [HttpGet("/api/medecin/{id}")]
        // [ServiceFilter(typeof(LogActionFilterAttribute))]
        public async Task<IActionResult> GetMedecin(int? id)
        {
            var medecin = repository.GetMedecinById(id);

            if (medecin == null)
            {
                return NotFound(nameof(medecin));
            }

            return Ok(medecin);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMedecin(int? id)
        {
            var medecinToBeDeleted = repository.GetMedecinById(id);
            if (medecinToBeDeleted == null)
            {
                return NotFound();
            }
            return Ok(repository.DeleteMedecin(medecinToBeDeleted));
        }

        [HttpPost("/api/create")]
        public async Task<IActionResult> Create(Medecin medecin)
        {
            if (ModelState.IsValid)
            {

                int _medecinsId = _medecins.Max(m => m.IdMedecin) + 1;
                repository.AddMedecin(new Medecin
                {
                    IdMedecin = _medecinsId,
                    Nom = medecin.Nom,
                    Prenom = medecin.Prenom,
                    Specialite = medecin.Specialite,
                });
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
