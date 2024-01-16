using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class FormulariosCascade : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Formularios_Formulas",
				table: "Formularios");

			migrationBuilder.AddForeignKey(
				name: "FK_Formularios_Formulas",
				table: "Formularios",
				column: "Formula",
				principalTable: "Formulas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Formularios_Formulas",
				table: "Formularios");

			migrationBuilder.AddForeignKey(
				name: "FK_Formularios_Formulas",
				table: "Formularios",
				column: "Formula",
				principalTable: "Formulas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}
	}
}
