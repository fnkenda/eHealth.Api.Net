using eHealth.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace eHealth.Api.Data
{
    public class EhealthDbContext : DbContext
    {
        public EhealthDbContext(DbContextOptions<EhealthDbContext> options) : base(options)
        {
        }

        public DbSet<Medecin> medecins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Medecin>().HasData(
                new Medecin { IdMedecin = 1, Nom = "La Monica", Prenom = "Giuliano", Specialite = "Dentiste" },
                    new Medecin { IdMedecin = 2, Nom = "Barry", Prenom = "Thierno", Specialite = "Orthopediste" },
                    new Medecin { IdMedecin = 3, Nom = "Nkenda", Prenom = "Florent", Specialite = "Orl" }
                );
        }

    }
}
