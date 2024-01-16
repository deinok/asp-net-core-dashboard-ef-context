using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class veterinarios_missing_fields_2 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "DNI",
				table: "Veterinarios",
				maxLength: 9,
				nullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "Predeterminado",
				table: "Veterinarios",
				nullable: false,
				defaultValue: false);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "DNI",
				table: "Veterinarios");

			migrationBuilder.DropColumn(
				name: "Predeterminado",
				table: "Veterinarios");
		}
	}
}
