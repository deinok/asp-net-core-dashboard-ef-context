using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class FormulasRemoveTrigger : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP TRIGGER IF EXISTS [Trigger_Formulas];");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
