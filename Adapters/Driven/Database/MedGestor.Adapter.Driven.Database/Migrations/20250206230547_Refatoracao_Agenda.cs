using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedGestor.Adapter.Driven.Database.Migrations
{
    /// <inheritdoc />
    public partial class Refatoracao_Agenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agd_Limite",
                schema: "MedHealth",
                table: "Agd_Agenda");

            migrationBuilder.RenameColumn(
                name: "Agd_Data",
                schema: "MedHealth",
                table: "Agd_Agenda",
                newName: "Agd_DataInicio");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Agd_DataFim",
                schema: "MedHealth",
                table: "Agd_Agenda",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agd_DataFim",
                schema: "MedHealth",
                table: "Agd_Agenda");

            migrationBuilder.RenameColumn(
                name: "Agd_DataInicio",
                schema: "MedHealth",
                table: "Agd_Agenda",
                newName: "Agd_Data");

            migrationBuilder.AddColumn<int>(
                name: "Agd_Limite",
                schema: "MedHealth",
                table: "Agd_Agenda",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
