using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class RecetasExtendedDrop : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP VIEW [RecetasExtended];");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
