using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class veterinarios_missing_fields : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "CodigoPostal",
				table: "Veterinarios",
				maxLength: 10,
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "Domicilio",
				table: "Veterinarios",
				maxLength: 120,
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "Poblacion",
				table: "Veterinarios",
				maxLength: 120,
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "ProvinciaId",
				table: "Veterinarios",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_Veterinarios_ProvinciaId",
				table: "Veterinarios",
				column: "ProvinciaId");

			migrationBuilder.AddForeignKey(
				name: "FK_Veterinarios_Provincias_ProvinciaId",
				table: "Veterinarios",
				column: "ProvinciaId",
				principalTable: "Provincias",
				principalColumn: "Id",
				onDelete: ReferentialAction.SetNull);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Veterinarios_Provincias_ProvinciaId",
				table: "Veterinarios");

			migrationBuilder.DropIndex(
				name: "IX_Veterinarios_ProvinciaId",
				table: "Veterinarios");

			migrationBuilder.DropColumn(
				name: "CodigoPostal",
				table: "Veterinarios");

			migrationBuilder.DropColumn(
				name: "Domicilio",
				table: "Veterinarios");

			migrationBuilder.DropColumn(
				name: "Poblacion",
				table: "Veterinarios");

			migrationBuilder.DropColumn(
				name: "ProvinciaId",
				table: "Veterinarios");
		}
	}
}
