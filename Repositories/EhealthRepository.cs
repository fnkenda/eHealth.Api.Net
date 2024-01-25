using eHealth.Api.Data;
using eHealth.Api.Models;

namespace eHealth.Api.Repositories
{
    public class EhealthRepository : IEhealthRepository
    {
        private EhealthDbContext _context;

        public EhealthRepository(EhealthDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

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

        public List<Medecin> GetAll()
        {
            return _context.medecins.ToList();
        }

        public Medecin GetMedecinById(int? id)
        {
            return _context.medecins.FirstOrDefault(m => m.IdMedecin == id);
        }


    }
}
