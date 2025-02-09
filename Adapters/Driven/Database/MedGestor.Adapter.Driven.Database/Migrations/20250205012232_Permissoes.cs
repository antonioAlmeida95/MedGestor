using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedGestor.Adapter.Driven.Database.Migrations
{
    /// <inheritdoc />
    public partial class Permissoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(schema: "MedHealth",
                table: "Per_Permissao",
                columns: new []{ "Per_PermissaoId", "Per_Valor" },
                values: new object[,]
                {
                    { Guid.Parse("241f210b-b3c3-4fa2-9047-255eae87ba02"), "0" }, //Adm
                    { Guid.Parse("7e553833-4b6d-41eb-b0a1-e19445287b28"), "1"}, //Leitura Paciente
                    { Guid.Parse("fd3e3251-249f-4d30-8cd2-0640e8143467"), "2"}, //Escrita Paciente
                    { Guid.Parse("21b60241-d211-4220-bc68-61df610a81db"), "3"}, //Remocao Paciente
                    { Guid.Parse("d4314cbc-78a7-444b-ad9e-ef1b08fe2ed8"), "4"}, //Leitura Medico
                    { Guid.Parse("84b97ca3-381c-4f3b-91c7-2281f8b4e795"), "5"}, //Escrita Medico
                    { Guid.Parse("80234278-8e5d-4e23-ad82-7c2859365535"), "6"}, //Remocao Medico
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(schema: "MedHealth",
                table: "Prp_PerfilPermissao",
                keyColumn: "Per_PermissaoId",
                keyValues: new[]
                {
                    "241f210b-b3c3-4fa2-9047-255eae87ba02",
                    "7e553833-4b6d-41eb-b0a1-e19445287b28",
                    "fd3e3251-249f-4d30-8cd2-0640e8143467",
                    "21b60241-d211-4220-bc68-61df610a81db",
                    "d4314cbc-78a7-444b-ad9e-ef1b08fe2ed8",
                    "84b97ca3-381c-4f3b-91c7-2281f8b4e795",
                    "80234278-8e5d-4e23-ad82-7c2859365535"
                });
            
            migrationBuilder.DeleteData(schema: "MedHealth",
                table: "Per_Permissao",
                keyColumn: "Per_PermissaoId",
                keyValues: new[]
                {
                    "241f210b-b3c3-4fa2-9047-255eae87ba02",
                    "7e553833-4b6d-41eb-b0a1-e19445287b28",
                    "fd3e3251-249f-4d30-8cd2-0640e8143467",
                    "21b60241-d211-4220-bc68-61df610a81db",
                    "d4314cbc-78a7-444b-ad9e-ef1b08fe2ed8",
                    "84b97ca3-381c-4f3b-91c7-2281f8b4e795",
                    "80234278-8e5d-4e23-ad82-7c2859365535"
                });
        }
    }
}
