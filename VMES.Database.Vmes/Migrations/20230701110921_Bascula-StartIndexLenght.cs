using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class BasculaStartIndexLenght : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "Lenght",
				table: "Basculas",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "StartIndex",
				table: "Basculas",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Lenght",
				table: "Basculas");

			migrationBuilder.DropColumn(
				name: "StartIndex",
				table: "Basculas");
		}
	}
}
