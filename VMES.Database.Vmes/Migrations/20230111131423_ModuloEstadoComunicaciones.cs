using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class ModuloEstadoComunicaciones : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "ModulosEstadoComunicaciones",
				columns: table => new
				{
					ModuloId = table.Column<int>(nullable: false),
					Estado = table.Column<int>(nullable: false),
					CerrarModulo = table.Column<bool>(nullable: false),
					CerrarOpc = table.Column<bool>(nullable: false),
					Resituar = table.Column<bool>(nullable: false),
					UltimaActualizacionIntegraServer = table.Column<DateTime>(nullable: false),
					UltimaActualizacionIntegraModulo = table.Column<DateTime>(nullable: false),
					ProcessId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ModulosEstadoComunicaciones", x => x.ModuloId);
					table.ForeignKey(
						name: "FK_ModulosEstadoComunicaciones_Modulos_ModuloId",
						column: x => x.ModuloId,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "ModulosEstadoComunicaciones");
		}
	}
}
