using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class StocksUbicacionesIndexes : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateIndex(
				name: "IX_Ubicaciones_Ordenacion",
				table: "Ubicaciones",
				column: "Ordenacion");

			migrationBuilder.CreateIndex(
				name: "IX_Stocks_Ubicacion",
				table: "Stocks",
				column: "Ubicacion");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropIndex(
				name: "IX_Ubicaciones_Ordenacion",
				table: "Ubicaciones");

			migrationBuilder.DropIndex(
				name: "IX_Stocks_Ubicacion",
				table: "Stocks");
		}
	}
}
