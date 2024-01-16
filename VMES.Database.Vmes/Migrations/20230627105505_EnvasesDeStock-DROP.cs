using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class EnvasesDeStockDROP : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "UdsEnvase",
				table: "Stocks");

			migrationBuilder.DropColumn(
				name: "UdsEnvase",
				table: "Desgloses");
			migrationBuilder.Sql("DROP FUNCTION [EnvasesDeStock];");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<decimal>(
				name: "UdsEnvase",
				table: "Stocks",
				type: "decimal(18, 5)",
				nullable: true,
				computedColumnSql: "([dbo].[EnvasesDeStock]([envase],[Cantidad]))");

			migrationBuilder.AddColumn<decimal>(
				name: "UdsEnvase",
				table: "Desgloses",
				type: "decimal(18, 5)",
				nullable: true,
				computedColumnSql: "([dbo].[EnvasesDeStock]([Envase],[Cantidad]))");
		}
	}
}
