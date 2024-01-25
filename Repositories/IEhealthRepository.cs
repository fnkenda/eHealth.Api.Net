using eHealth.Api.Models;

namespace eHealth.Api.Repositories
{
    public interface IEhealthRepository
    {
        Medecin GetMedecinById(int? id);
        List<Medecin> GetAll();
        void AddMedecin(Medecin medecin);

        bool DeleteMedecin(Medecin medecin);

    }
}
