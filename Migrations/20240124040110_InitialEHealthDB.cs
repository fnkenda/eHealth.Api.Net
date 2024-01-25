using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eHealth.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialEHealthDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medecins",
                columns: table => new
                {
                    IdMedecin = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    Specialite = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medecins", x => x.IdMedecin);
                });

            migrationBuilder.InsertData(
                table: "medecins",
                columns: new[] { "IdMedecin", "Nom", "Prenom", "Specialite" },
                values: new object[,]
                {
                    { 1, "La Monica", "Giuliano", "Dentiste" },
                    { 2, "Barry", "Thierno", "Orthopediste" },
                    { 3, "Nkenda", "Florent", "Orl" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medecins");
        }
    }
}
