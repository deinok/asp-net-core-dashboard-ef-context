using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class recetas_especies : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "EspecieId",
				table: "Recetas",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "Estado",
				table: "Recetas",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.CreateIndex(
				name: "IX_Recetas_EspecieId",
				table: "Recetas",
				column: "EspecieId");

			migrationBuilder.AddForeignKey(
				name: "FK_Recetas_Especies_EspecieId",
				table: "Recetas",
				column: "EspecieId",
				principalTable: "Especies",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Recetas_Especies_EspecieId",
				table: "Recetas");

			migrationBuilder.DropIndex(
				name: "IX_Recetas_EspecieId",
				table: "Recetas");

			migrationBuilder.DropColumn(
				name: "EspecieId",
				table: "Recetas");

			migrationBuilder.DropColumn(
				name: "Estado",
				table: "Recetas");
		}
	}
}
