using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class LotesPrioritario : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "Prioritario",
				table: "Lotes",
				nullable: false,
				defaultValue: false);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Prioritario",
				table: "Lotes");
		}
	}
}
