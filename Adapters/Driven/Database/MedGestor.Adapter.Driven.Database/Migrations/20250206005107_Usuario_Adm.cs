using MedGestor.Core.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedGestor.Adapter.Driven.Database.Migrations
{
    /// <inheritdoc />
    public partial class Usuario_Adm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(schema: "MedHealth",
                table: "Usu_Usuario",
                columns: new[]
                {
                    "Usu_UsuarioId",
                    "Usu_Email",
                    "Usu_Senha",
                    "Usu_Status"
                },
                values: new object[]
                {
                    Guid.Parse("10e2b402-c113-4f6d-a1b7-59c5fdb56528"),
                    "admmed@gmail.com.br",
                    "admtop",
                    true
                });
            
            migrationBuilder.InsertData(schema: "MedHealth",
                table: "Pes_Pessoa",
                columns: new[] 
                { 
                    "Pes_PessoaId",
                    "Pes_Nome",
                    "Pes_Documento",
                    "Pes_DataNascimento",
                    "Pes_Genero",
                    "Prf_PerfilId",
                    "Usu_UsuarioId"
                },
                values: new object[]
                {
                    Guid.Parse("9390aa7e-a70e-426c-8800-8015771a24f5"),
                    "Administrador",
                    "0",
                    DateTimeOffset.UtcNow,
                    (int) Genero.Masculino,
                    Guid.Parse("ed63493d-6338-4fa6-b1e8-aed7ebb49204"),
                    Guid.Parse("10e2b402-c113-4f6d-a1b7-59c5fdb56528")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(schema: "MedHealth",
                table: "Pes_Pessoa",
                keyColumn: "Usu_UsuarioId",
                keyValue: "10e2b402-c113-4f6d-a1b7-59c5fdb56528");
            
            migrationBuilder.DeleteData(schema: "MedHealth",
                table: "Usu_UsuarioId",
                keyColumn: "Usu_UsuarioId",
                keyValue: "10e2b402-c113-4f6d-a1b7-59c5fdb56528");
        }
    }
}
