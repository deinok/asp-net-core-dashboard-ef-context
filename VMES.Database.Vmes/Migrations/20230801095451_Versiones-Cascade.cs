using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class VersionesCascade : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Componentes_Versiones",
				table: "Componentes");

			migrationBuilder.DropForeignKey(
				name: "FK_Versiones_Formulas",
				table: "Versiones");

			migrationBuilder.AddForeignKey(
				name: "FK_Componentes_Versiones_Version",
				table: "Componentes",
				column: "Version",
				principalTable: "Versiones",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Versiones_Formulas_Formula",
				table: "Versiones",
				column: "Formula",
				principalTable: "Formulas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Componentes_Versiones_Version",
				table: "Componentes");

			migrationBuilder.DropForeignKey(
				name: "FK_Versiones_Formulas_Formula",
				table: "Versiones");

			migrationBuilder.AddForeignKey(
				name: "FK_Componentes_Versiones",
				table: "Componentes",
				column: "Version",
				principalTable: "Versiones",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Versiones_Formulas",
				table: "Versiones",
				column: "Formula",
				principalTable: "Formulas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}
	}
}
