using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class SolicitudAjusteCaudal : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "GenerarComprovacionOrigenVacio",
				table: "Modulos",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AlterColumn<decimal>(
				name: "CaudalSalida",
				table: "Caudales",
				type: "decimal(18, 3)",
				nullable: false,
				oldClrType: typeof(decimal),
				oldType: "decimal(18, 5)");

			migrationBuilder.AlterColumn<decimal>(
				name: "CaudalEntrada",
				table: "Caudales",
				type: "decimal(18, 3)",
				nullable: false,
				oldClrType: typeof(decimal),
				oldType: "decimal(18, 5)");

			migrationBuilder.AddColumn<decimal>(
				name: "PorcentajeAjusteAutomaticoMaximo",
				table: "Caudales",
				type: "decimal(18, 2)",
				nullable: false,
				defaultValueSql: "5");

			migrationBuilder.AddColumn<decimal>(
				name: "PorcentajeAjusteMaximo",
				table: "Caudales",
				type: "decimal(18, 2)",
				nullable: false,
				defaultValueSql: "10");

			migrationBuilder.CreateTable(
				name: "SolicitudesAjusteCaudal",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ProductoId = table.Column<int>(nullable: false),
					UbicacionId = table.Column<int>(nullable: false),
					Type = table.Column<byte>(nullable: false),
					Status = table.Column<byte>(nullable: false),
					NuevoCaudalEntrada = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
					NuevoCaudalSalida = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
					Creacion = table.Column<DateTime>(nullable: false),
					Modificacion = table.Column<DateTime>(nullable: false),
					OrdenId = table.Column<int>(nullable: true),
					UsuarioId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SolicitudesAjusteCaudal", x => x.Id);
					table.ForeignKey(
						name: "FK_SolicitudesAjusteCaudal_Ordenes_OrdenId",
						column: x => x.OrdenId,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SolicitudesAjusteCaudal_Productos_ProductoId",
						column: x => x.ProductoId,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_SolicitudesAjusteCaudal_Ubicaciones_UbicacionId",
						column: x => x.UbicacionId,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_SolicitudesAjusteCaudal_Usuarios_UsuarioId",
						column: x => x.UsuarioId,
						principalTable: "Usuarios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SolicitudesAjusteCaudal_Caudales_ProductoId_UbicacionId",
						columns: x => new { x.ProductoId, x.UbicacionId },
						principalTable: "Caudales",
						principalColumns: new[] { "ProductoId", "UbicacionId" },
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "NetAlarmasTipos",
				columns: new[] { "Id", "AutoFinalizar", "IdAlarmaPLC", "MostrarUsuario", "Nivel", "RolShow", "TextoError", "UserShow" },
				values: new object[] { 2050, false, 2050, true, null, null, "Comprovacion Origen Vacio", null });

			migrationBuilder.CreateIndex(
				name: "IX_SolicitudesAjusteCaudal_OrdenId",
				table: "SolicitudesAjusteCaudal",
				column: "OrdenId");

			migrationBuilder.CreateIndex(
				name: "IX_SolicitudesAjusteCaudal_UbicacionId",
				table: "SolicitudesAjusteCaudal",
				column: "UbicacionId");

			migrationBuilder.CreateIndex(
				name: "IX_SolicitudesAjusteCaudal_UsuarioId",
				table: "SolicitudesAjusteCaudal",
				column: "UsuarioId");

			migrationBuilder.CreateIndex(
				name: "IX_SolicitudesAjusteCaudal_ProductoId_UbicacionId",
				table: "SolicitudesAjusteCaudal",
				columns: new[] { "ProductoId", "UbicacionId" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "SolicitudesAjusteCaudal");

			migrationBuilder.DeleteData(
				table: "NetAlarmasTipos",
				keyColumn: "Id",
				keyValue: 2050);

			migrationBuilder.DropColumn(
				name: "GenerarComprovacionOrigenVacio",
				table: "Modulos");

			migrationBuilder.DropColumn(
				name: "PorcentajeAjusteAutomaticoMaximo",
				table: "Caudales");

			migrationBuilder.DropColumn(
				name: "PorcentajeAjusteMaximo",
				table: "Caudales");

			migrationBuilder.AlterColumn<decimal>(
				name: "CaudalSalida",
				table: "Caudales",
				type: "decimal(18, 5)",
				nullable: false,
				oldClrType: typeof(decimal),
				oldType: "decimal(18, 3)");

			migrationBuilder.AlterColumn<decimal>(
				name: "CaudalEntrada",
				table: "Caudales",
				type: "decimal(18, 5)",
				nullable: false,
				oldClrType: typeof(decimal),
				oldType: "decimal(18, 3)");
		}
	}
}
