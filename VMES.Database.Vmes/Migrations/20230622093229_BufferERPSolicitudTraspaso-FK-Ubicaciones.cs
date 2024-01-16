using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class BufferERPSolicitudTraspasoFKUbicaciones : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_BufferERPSolicitudTraspaso_Destinos_DestinoId",
				table: "BufferERPSolicitudTraspaso");

			migrationBuilder.DropForeignKey(
				name: "FK_BufferERPSolicitudTraspaso_Origenes_OrigenId",
				table: "BufferERPSolicitudTraspaso");

			migrationBuilder.AddForeignKey(
				name: "FK_BufferERPSolicitudTraspaso_Ubicaciones_DestinoId",
				table: "BufferERPSolicitudTraspaso",
				column: "DestinoId",
				principalTable: "Ubicaciones",
				principalColumn: "Id",
				onDelete: ReferentialAction.NoAction);

			migrationBuilder.AddForeignKey(
				name: "FK_BufferERPSolicitudTraspaso_Ubicaciones_OrigenId",
				table: "BufferERPSolicitudTraspaso",
				column: "OrigenId",
				principalTable: "Ubicaciones",
				principalColumn: "Id",
				onDelete: ReferentialAction.NoAction);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_BufferERPSolicitudTraspaso_Ubicaciones_DestinoId",
				table: "BufferERPSolicitudTraspaso");

			migrationBuilder.DropForeignKey(
				name: "FK_BufferERPSolicitudTraspaso_Ubicaciones_OrigenId",
				table: "BufferERPSolicitudTraspaso");

			migrationBuilder.AddForeignKey(
				name: "FK_BufferERPSolicitudTraspaso_Destinos_DestinoId",
				table: "BufferERPSolicitudTraspaso",
				column: "DestinoId",
				principalTable: "Destinos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_BufferERPSolicitudTraspaso_Origenes_OrigenId",
				table: "BufferERPSolicitudTraspaso",
				column: "OrigenId",
				principalTable: "Origenes",
				principalColumn: "ID",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
