using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class FormulasDatosExtrasDROP : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "FormulasDatosExtra");
			migrationBuilder.Sql("DROP FUNCTION [FormulaKWToneladaEfectivo];");
			migrationBuilder.Sql("DROP FUNCTION [FormulaKWToneladaTotal];");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "FormulasDatosExtra",
				columns: table => new
				{
					id = table.Column<int>(type: "int", nullable: false),
					KWToneladaEfectivo = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, computedColumnSql: "([dbo].[FormulaKWToneladaEfectivo]([id]))"),
					KWToneladaTotal = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, computedColumnSql: "([dbo].[FormulaKWToneladaTotal]([id]))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_FormulasDatosExtra", x => x.id);
					table.ForeignKey(
						name: "FK_FormulasDatosExtra_Formulas",
						column: x => x.id,
						principalTable: "Formulas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});
		}
	}
}
