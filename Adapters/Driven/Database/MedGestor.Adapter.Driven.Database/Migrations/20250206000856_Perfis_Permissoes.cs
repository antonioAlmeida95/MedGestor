using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedGestor.Adapter.Driven.Database.Migrations
{
    /// <inheritdoc />
    public partial class Perfis_Permissoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(schema: "MedHealth",
                table: "Prp_PerfilPermissao",
                columns: new[] { "Prp_PerfilPermissaoId", "Prf_PerfilId", "Per_PermissaoId" },
                values: new object[,]
                {
                    {
                        Guid.Parse("7314010d-a303-4a84-abf3-130f3accc3cb"),
                        Guid.Parse("ed63493d-6338-4fa6-b1e8-aed7ebb49204"),
                        Guid.Parse("241f210b-b3c3-4fa2-9047-255eae87ba02")
                    },
                    {
                        Guid.Parse("16f5b77f-f1d5-4959-a490-b3baa499d5a9"),
                        Guid.Parse("2842d69d-6834-4a59-9de8-30e64fe354d7"),
                        Guid.Parse("7e553833-4b6d-41eb-b0a1-e19445287b28"),
                    },
                    {
                        Guid.Parse("b3262744-9545-4831-b637-69ddba922088"),
                        Guid.Parse("2842d69d-6834-4a59-9de8-30e64fe354d7"),
                        Guid.Parse("fd3e3251-249f-4d30-8cd2-0640e8143467"),
                    },
                    {
                        Guid.Parse("c4effda8-fd58-4fb5-bbf6-b7397f72dce7"),
                        Guid.Parse("2842d69d-6834-4a59-9de8-30e64fe354d7"),
                        Guid.Parse("21b60241-d211-4220-bc68-61df610a81db"),
                    },
                    {
                        Guid.Parse("09581f6e-0a29-4b84-a0bd-9c6b4a3cb579"),
                        Guid.Parse("45dc4d0b-20e4-4ec8-bb1a-07de66f18b67"),
                        Guid.Parse("d4314cbc-78a7-444b-ad9e-ef1b08fe2ed8"),
                    },
                    {
                        Guid.Parse("f1141136-7a63-487a-9acb-46bbcf79cf5f"),
                        Guid.Parse("45dc4d0b-20e4-4ec8-bb1a-07de66f18b67"),
                        Guid.Parse("84b97ca3-381c-4f3b-91c7-2281f8b4e795"),
                    },
                    {
                        Guid.Parse("96960cf6-b1a1-40d4-a5df-798ba9012368"),
                        Guid.Parse("45dc4d0b-20e4-4ec8-bb1a-07de66f18b67"),
                        Guid.Parse("80234278-8e5d-4e23-ad82-7c2859365535"),
                    }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(schema: "MedHealth",
                table: "Prp_PerfilPermissao",
                keyColumn: "Prp_PerfilPermissaoId",
                keyValues: new[]
                {
                    "7314010d-a303-4a84-abf3-130f3accc3cb",
                    "16f5b77f-f1d5-4959-a490-b3baa499d5a9",
                    "b3262744-9545-4831-b637-69ddba922088",
                    "c4effda8-fd58-4fb5-bbf6-b7397f72dce7",
                    "09581f6e-0a29-4b84-a0bd-9c6b4a3cb579",
                    "f1141136-7a63-487a-9acb-46bbcf79cf5f",
                    "80234278-8e5d-4e23-ad82-7c2859365535"
                });
        }
    }
}
