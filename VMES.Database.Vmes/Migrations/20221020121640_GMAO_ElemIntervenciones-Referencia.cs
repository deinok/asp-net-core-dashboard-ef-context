using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class GMAO_ElemIntervencionesReferencia : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "Referencia",
				table: "GMAO_ElemIntervenciones",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Referencia",
				table: "GMAO_ElemIntervenciones");
		}
	}
}
