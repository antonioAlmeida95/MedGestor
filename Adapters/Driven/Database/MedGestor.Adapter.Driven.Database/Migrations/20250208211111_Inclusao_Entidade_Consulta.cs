using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedGestor.Adapter.Driven.Database.Migrations
{
    /// <inheritdoc />
    public partial class Inclusao_Entidade_Consulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cst_Consulta",
                schema: "MedHealth",
                columns: table => new
                {
                    Cst_ConsultaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cst_Aceito = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Cst_Cancelada = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Cst_Justificativa = table.Column<string>(type: "text", nullable: true),
                    Agd_AgendaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Pct_PacienteId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cst_Consulta", x => x.Cst_ConsultaId);
                    table.ForeignKey(
                        name: "FK_Cst_Consulta_Agd_Agenda_Agd_AgendaId",
                        column: x => x.Agd_AgendaId,
                        principalSchema: "MedHealth",
                        principalTable: "Agd_Agenda",
                        principalColumn: "Agd_AgendaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cst_Consulta_Pct_Paciente_Pct_PacienteId",
                        column: x => x.Pct_PacienteId,
                        principalSchema: "MedHealth",
                        principalTable: "Pct_Paciente",
                        principalColumn: "Pct_PacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cst_Consulta_Agd_AgendaId",
                schema: "MedHealth",
                table: "Cst_Consulta",
                column: "Agd_AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cst_Consulta_Pct_PacienteId",
                schema: "MedHealth",
                table: "Cst_Consulta",
                column: "Pct_PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cst_Consulta",
                schema: "MedHealth");
        }
    }
}
