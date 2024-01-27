using eHealth.Api.Models;
using eHealth.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eHealth.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CliniqueController : ControllerBase
	{










		private IEhealthRepository repository;
		private List<Clinique> _cliniques;
		public CliniqueController(IEhealthRepository ehealthRepository)
		{
			repository = ehealthRepository;
			_cliniques = repository.GetAllClinique();
		}

		[HttpGet("/api/cliniques")]
		public async Task<IActionResult> GetAllCliniques()
		{

			if (_cliniques == null)
			{
				return NotFound();
			}

			return Ok(_cliniques);
		}

		[HttpGet("/api/clinique/{id}")]
		// [ServiceFilter(typeof(LogActionFilterAttribute))]
		public async Task<IActionResult> GetClinique(int? id)
		{
			var clinique = repository.GetCliniqueById(id);

			if (clinique == null)
			{
				return NotFound(nameof(clinique));
			}

			return Ok(clinique);
		}

		[HttpDelete("/api/deleteclinique")]
		public async Task<IActionResult> DeleteClinique(int? id)
		{
			var cliniqueToBeDeleted = repository.GetCliniqueById(id);
			if (cliniqueToBeDeleted == null)
			{
				return NotFound();
			}
			return Ok(repository.DeleteClinique(cliniqueToBeDeleted));
		}

		[HttpPost("/api/addclinique")]
		public async Task<IActionResult> Create(Clinique clinique)
		{
			if (ModelState.IsValid)
			{
				int _cliniqueId = (_cliniques.Count == 0) ? 1 : _cliniques.Max(m => m.IdClinique) + 1;
				repository.AddClinique(new Clinique
				{
					IdClinique = _cliniqueId,
					Nom = clinique.Nom,
					Adresse = clinique.Adresse,
					Telephone = clinique.Telephone
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
