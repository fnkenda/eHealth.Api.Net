using eHealth.Api.Data;
using eHealth.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace eHealth.Api.Repositories
{
    public class EhealthRepository : IEhealthRepository
    {
        private EhealthDbContext _context;

        public EhealthRepository(EhealthDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

		#region Medecin
		public void AddMedecin(Medecin medecin)
        {
            _context.medecins.Add(medecin);
            _context.SaveChanges();
        }

        public bool DeleteMedecin(Medecin medecin)
        {
            var deletedMedecin = _context.medecins.Remove(medecin);
            _context.SaveChanges();
            if (deletedMedecin.State == Microsoft.EntityFrameworkCore.EntityState.Deleted ) {
                return true;
            }
            return false;
        }

        public List<Medecin> GetAllMedecin()
        {
            return _context.medecins.ToList();
        }

        public Medecin GetMedecinById(int? id)
        {
            return _context.medecins.FirstOrDefault(m => m.IdMedecin == id);
        }


		#endregion

		#region Clinique

		public void AddClinique(Clinique clinique)
		{
			_context.cliniques.Add(clinique);
			_context.SaveChanges();
		}

		public bool DeleteClinique(Clinique clinique)
		{
			var deletedClinique = _context.cliniques.Remove(clinique);
			_context.SaveChanges();
			if (deletedClinique.State == Microsoft.EntityFrameworkCore.EntityState.Deleted)
			{
				return true;
			}
			return false;
		}

		public List<Clinique> GetAllClinique()
		{
			return _context.cliniques.Include(c => c.medecins).ToList();
		}

		public Clinique GetCliniqueById(int? id)
		{
			return _context.cliniques.Include(c => c.medecins).FirstOrDefault(m => m.IdClinique == id);
		}


		#endregion

	}
}
