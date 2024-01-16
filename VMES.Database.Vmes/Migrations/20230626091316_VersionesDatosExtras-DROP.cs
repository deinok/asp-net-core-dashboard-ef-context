using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class VersionesDatosExtrasDROP : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP TRIGGER [Trigger_Version];");
			migrationBuilder.DropTable(
				name: "VersionDatosExtra");
			migrationBuilder.Sql("DROP FUNCTION [VersionKWToneladaEfectivo];");
			migrationBuilder.Sql("DROP FUNCTION [VersionKWToneladaTotal];");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "VersionDatosExtra",
				columns: table => new
				{
					id = table.Column<int>(type: "int", nullable: false),
					KWToneladaEfectivo = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, computedColumnSql: "([dbo].[VersionKWToneladaEfectivo]([id]))"),
					KWToneladaTotal = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, computedColumnSql: "([dbo].[VersionKWToneladaTotal]([id]))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_VersionDatosExtra", x => x.id);
					table.ForeignKey(
						name: "FK_VersionDatosExtra_Version",
						column: x => x.id,
						principalTable: "Versiones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});
		}
	}
}
