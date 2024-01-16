using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class OrdenesTransicionEstadosHistory_CREATE : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "OrdenesTransicionEstadosHistory",
				columns: table => new
				{
					IdAuto = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					InicioValidez = table.Column<DateTime>(nullable: false),
					FinValidez = table.Column<DateTime>(nullable: true),
					ContadorActualizaciones = table.Column<int>(nullable: false),
					EstadoAnterior = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					ExportadoERP = table.Column<int>(nullable: true),
					IdOrden = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OrdenesTransicionEstadosHistory", x => x.IdAuto);
					table.ForeignKey(
						name: "FK_OrdenesTransicionEstadosHistory_Ordenes_IdOrden",
						column: x => x.IdOrden,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_OrdenesTransicionEstadosHistory_IdOrden",
				table: "OrdenesTransicionEstadosHistory",
				column: "IdOrden");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "OrdenesTransicionEstadosHistory");
		}
	}
}
