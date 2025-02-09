using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedGestor.Adapter.Driven.Database.Migrations
{
    /// <inheritdoc />
    public partial class Correcao_PerfilPermissao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prp_PerfilPermissao_Per_Permissao_PermissaoId",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prp_PerfilPermissao",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao");

            migrationBuilder.DropIndex(
                name: "IX_Prp_PerfilPermissao_PermissaoId",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao");

            migrationBuilder.RenameColumn(
                name: "PermissaoId",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao",
                newName: "Prp_PerfilPermissaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prp_PerfilPermissao",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao",
                column: "Prp_PerfilPermissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prp_PerfilPermissao_Per_PermissaoId",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao",
                column: "Per_PermissaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prp_PerfilPermissao_Per_Permissao_Per_PermissaoId",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao",
                column: "Per_PermissaoId",
                principalSchema: "MedHealth",
                principalTable: "Per_Permissao",
                principalColumn: "Per_PermissaoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prp_PerfilPermissao_Per_Permissao_Per_PermissaoId",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prp_PerfilPermissao",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao");

            migrationBuilder.DropIndex(
                name: "IX_Prp_PerfilPermissao_Per_PermissaoId",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao");

            migrationBuilder.RenameColumn(
                name: "Prp_PerfilPermissaoId",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao",
                newName: "PermissaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prp_PerfilPermissao",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao",
                column: "Per_PermissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prp_PerfilPermissao_PermissaoId",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao",
                column: "PermissaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prp_PerfilPermissao_Per_Permissao_PermissaoId",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao",
                column: "PermissaoId",
                principalSchema: "MedHealth",
                principalTable: "Per_Permissao",
                principalColumn: "Per_PermissaoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
