using eHealth.Api.Models;

namespace eHealth.Api.Repositories
{
    public interface IEhealthRepository
    {
		#region Medecin

		Medecin GetMedecinById(int? id);

		List<Medecin> GetAllMedecin();

		void AddMedecin(Medecin medecin);

		bool DeleteMedecin(Medecin medecin);

		#endregion



		#region Clinique

		Clinique GetCliniqueById(int? id);

		List<Clinique> GetAllClinique();

		void AddClinique(Clinique clinique);

		bool DeleteClinique(Clinique clinique);

		#endregion
	}
}