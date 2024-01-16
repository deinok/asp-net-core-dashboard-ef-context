using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class RecetasLineasExtendedDrop : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP VIEW [RecetasLineasExtended];");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
