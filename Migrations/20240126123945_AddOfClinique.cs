using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eHealth.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddOfClinique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CliniqueIdClinique",
                table: "medecins",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "cliniques",
                columns: table => new
                {
                    IdClinique = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", nullable: false),
                    Telephone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliniques", x => x.IdClinique);
                });

            migrationBuilder.UpdateData(
                table: "medecins",
                keyColumn: "IdMedecin",
                keyValue: 1,
                column: "CliniqueIdClinique",
                value: null);

            migrationBuilder.UpdateData(
                table: "medecins",
                keyColumn: "IdMedecin",
                keyValue: 2,
                column: "CliniqueIdClinique",
                value: null);

            migrationBuilder.UpdateData(
                table: "medecins",
                keyColumn: "IdMedecin",
                keyValue: 3,
                column: "CliniqueIdClinique",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_medecins_CliniqueIdClinique",
                table: "medecins",
                column: "CliniqueIdClinique");

            migrationBuilder.AddForeignKey(
                name: "FK_medecins_cliniques_CliniqueIdClinique",
                table: "medecins",
                column: "CliniqueIdClinique",
                principalTable: "cliniques",
                principalColumn: "IdClinique");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medecins_cliniques_CliniqueIdClinique",
                table: "medecins");

            migrationBuilder.DropTable(
                name: "cliniques");

            migrationBuilder.DropIndex(
                name: "IX_medecins_CliniqueIdClinique",
                table: "medecins");

            migrationBuilder.DropColumn(
                name: "CliniqueIdClinique",
                table: "medecins");
        }
    }
}
