using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class BufferERPSolicitudTraspaso : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "BufferERPSolicitudTraspaso",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					LoteId = table.Column<int>(nullable: false),
					DestinoId = table.Column<int>(nullable: false),
					OrigenId = table.Column<int>(nullable: false),
					UsuarioId = table.Column<int>(nullable: false),
					Cantidad = table.Column<decimal>(nullable: false),
					FechaSolicitud = table.Column<DateTime>(nullable: false),
					Estado = table.Column<int>(nullable: false),
					Respuesta = table.Column<int>(nullable: true),
					FechaRespuesta = table.Column<DateTime>(nullable: true),
					TxtErrores = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPSolicitudTraspaso", x => x.Id);
					table.ForeignKey(
						name: "FK_BufferERPSolicitudTraspaso_Destinos_DestinoId",
						column: x => x.DestinoId,
						principalTable: "Destinos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_BufferERPSolicitudTraspaso_Lotes_LoteId",
						column: x => x.LoteId,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_BufferERPSolicitudTraspaso_Origenes_OrigenId",
						column: x => x.OrigenId,
						principalTable: "Origenes",
						principalColumn: "ID",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_BufferERPSolicitudTraspaso_Usuarios_UsuarioId",
						column: x => x.UsuarioId,
						principalTable: "Usuarios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPSolicitudTraspaso_DestinoId",
				table: "BufferERPSolicitudTraspaso",
				column: "DestinoId");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPSolicitudTraspaso_LoteId",
				table: "BufferERPSolicitudTraspaso",
				column: "LoteId");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPSolicitudTraspaso_OrigenId",
				table: "BufferERPSolicitudTraspaso",
				column: "OrigenId");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPSolicitudTraspaso_UsuarioId",
				table: "BufferERPSolicitudTraspaso",
				column: "UsuarioId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "BufferERPSolicitudTraspaso");
		}
	}
}
