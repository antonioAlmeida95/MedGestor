using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedGestor.Adapter.Driven.Database.Migrations
{
    /// <inheritdoc />
    public partial class Perfis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(schema: "MedHealth",
                table: "Prf_Perfil",
                columns: new[] { "Prf_PerfilId", "Prf_Nome", "Prf_Status" },
                values: new object[,]
                {
                    { Guid.Parse("ed63493d-6338-4fa6-b1e8-aed7ebb49204"), "Administrador", true },
                    { Guid.Parse("2842d69d-6834-4a59-9de8-30e64fe354d7"), "Paciente", true },
                    { Guid.Parse("45dc4d0b-20e4-4ec8-bb1a-07de66f18b67"), "Medico", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(schema: "MedHealth",
                table: "Prp_PerfilPermissao",
                keyColumn: "Prf_PerfilId",
                keyValues: new[]
                {
                    "ed63493d-6338-4fa6-b1e8-aed7ebb49204",
                    "2842d69d-6834-4a59-9de8-30e64fe354d7",
                    "45dc4d0b-20e4-4ec8-bb1a-07de66f18b67"
                });
            
            migrationBuilder.DeleteData(schema: "MedHealth",
                table: "Prf_Perfil",
                keyColumn: "Prf_PerfilId",
                keyValues: new[]
                {
                    "ed63493d-6338-4fa6-b1e8-aed7ebb49204",
                    "2842d69d-6834-4a59-9de8-30e64fe354d7",
                    "45dc4d0b-20e4-4ec8-bb1a-07de66f18b67"
                });
        }
    }
}
