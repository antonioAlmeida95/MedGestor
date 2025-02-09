using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedGestor.Adapter.Driven.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MedHealth");

            migrationBuilder.CreateTable(
                name: "Per_Permissao",
                schema: "MedHealth",
                columns: table => new
                {
                    Per_PermissaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Per_Valor = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Per_Permissao", x => x.Per_PermissaoId);
                });

            migrationBuilder.CreateTable(
                name: "Prf_Perfil",
                schema: "MedHealth",
                columns: table => new
                {
                    Prf_PerfilId = table.Column<Guid>(type: "uuid", nullable: false),
                    Prf_Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Prf_Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prf_Perfil", x => x.Prf_PerfilId);
                });

            migrationBuilder.CreateTable(
                name: "Usu_Usuario",
                schema: "MedHealth",
                columns: table => new
                {
                    Usu_UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Usu_Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Usu_Senha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Usu_Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usu_Usuario", x => x.Usu_UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Prp_PerfilPermissao",
                schema: "MedHealth",
                columns: table => new
                {
                    Per_PermissaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Prf_PerfilId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissaoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prp_PerfilPermissao", x => x.Per_PermissaoId);
                    table.ForeignKey(
                        name: "FK_Prp_PerfilPermissao_Per_Permissao_PermissaoId",
                        column: x => x.PermissaoId,
                        principalSchema: "MedHealth",
                        principalTable: "Per_Permissao",
                        principalColumn: "Per_PermissaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prp_PerfilPermissao_Prf_Perfil_Prf_PerfilId",
                        column: x => x.Prf_PerfilId,
                        principalSchema: "MedHealth",
                        principalTable: "Prf_Perfil",
                        principalColumn: "Prf_PerfilId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pes_Pessoa",
                schema: "MedHealth",
                columns: table => new
                {
                    Pes_PessoaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Pes_Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Pes_Documento = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    Pes_DataNascimento = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Pes_Genero = table.Column<int>(type: "integer", nullable: false),
                    Prf_PerfilId = table.Column<Guid>(type: "uuid", nullable: false),
                    Usu_UsuarioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pes_Pessoa", x => x.Pes_PessoaId);
                    table.ForeignKey(
                        name: "FK_Pes_Pessoa_Prf_Perfil_Prf_PerfilId",
                        column: x => x.Prf_PerfilId,
                        principalSchema: "MedHealth",
                        principalTable: "Prf_Perfil",
                        principalColumn: "Prf_PerfilId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pes_Pessoa_Usu_Usuario_Usu_UsuarioId",
                        column: x => x.Usu_UsuarioId,
                        principalSchema: "MedHealth",
                        principalTable: "Usu_Usuario",
                        principalColumn: "Usu_UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mdc_Medico",
                schema: "MedHealth",
                columns: table => new
                {
                    Mdc_MedicoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Mdc_Crm = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Mdc_Telefone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Mdc_Especialidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Mdc_Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Pes_PessoaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mdc_Medico", x => x.Mdc_MedicoId);
                    table.ForeignKey(
                        name: "FK_Mdc_Medico_Pes_Pessoa_Pes_PessoaId",
                        column: x => x.Pes_PessoaId,
                        principalSchema: "MedHealth",
                        principalTable: "Pes_Pessoa",
                        principalColumn: "Pes_PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pct_Paciente",
                schema: "MedHealth",
                columns: table => new
                {
                    Pct_PacienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Pct_Peso = table.Column<decimal>(type: "numeric(2)", precision: 2, nullable: false),
                    Pct_Altura = table.Column<decimal>(type: "numeric(2)", precision: 2, nullable: false),
                    PessoaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pct_Paciente", x => x.Pct_PacienteId);
                    table.ForeignKey(
                        name: "FK_Pct_Paciente_Pes_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalSchema: "MedHealth",
                        principalTable: "Pes_Pessoa",
                        principalColumn: "Pes_PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agd_Agenda",
                schema: "MedHealth",
                columns: table => new
                {
                    Agd_AgendaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Agd_Data = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Agd_Limite = table.Column<int>(type: "integer", nullable: false),
                    Agd_Duracao = table.Column<int>(type: "integer", nullable: false),
                    Agd_Dia = table.Column<int>(type: "integer", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agd_Agenda", x => x.Agd_AgendaId);
                    table.ForeignKey(
                        name: "FK_Agd_Agenda_Mdc_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalSchema: "MedHealth",
                        principalTable: "Mdc_Medico",
                        principalColumn: "Mdc_MedicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agd_Agenda_MedicoId",
                schema: "MedHealth",
                table: "Agd_Agenda",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mdc_Medico_Pes_PessoaId",
                schema: "MedHealth",
                table: "Mdc_Medico",
                column: "Pes_PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pct_Paciente_PessoaId",
                schema: "MedHealth",
                table: "Pct_Paciente",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pes_Pessoa_Prf_PerfilId",
                schema: "MedHealth",
                table: "Pes_Pessoa",
                column: "Prf_PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Pes_Pessoa_Usu_UsuarioId",
                schema: "MedHealth",
                table: "Pes_Pessoa",
                column: "Usu_UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prp_PerfilPermissao_PermissaoId",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao",
                column: "PermissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prp_PerfilPermissao_Prf_PerfilId",
                schema: "MedHealth",
                table: "Prp_PerfilPermissao",
                column: "Prf_PerfilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agd_Agenda",
                schema: "MedHealth");

            migrationBuilder.DropTable(
                name: "Pct_Paciente",
                schema: "MedHealth");

            migrationBuilder.DropTable(
                name: "Prp_PerfilPermissao",
                schema: "MedHealth");

            migrationBuilder.DropTable(
                name: "Mdc_Medico",
                schema: "MedHealth");

            migrationBuilder.DropTable(
                name: "Per_Permissao",
                schema: "MedHealth");

            migrationBuilder.DropTable(
                name: "Pes_Pessoa",
                schema: "MedHealth");

            migrationBuilder.DropTable(
                name: "Prf_Perfil",
                schema: "MedHealth");

            migrationBuilder.DropTable(
                name: "Usu_Usuario",
                schema: "MedHealth");
        }
    }
}
