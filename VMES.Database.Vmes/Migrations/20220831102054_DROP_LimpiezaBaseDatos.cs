using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class DROP_LimpiezaBaseDatos : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql($@"DROP PROCEDURE IF EXISTS [LimpiezaBaseDatos];");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}
