using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class NetAlarmasTiposRespuestasOrigenes : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "NetAlarmasTiposRespuestasOrigenes",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					NetAlarmasTipoId = table.Column<int>(nullable: false),
					NetAlarmasRespuestaId = table.Column<int>(nullable: false),
					OrigenId = table.Column<int>(nullable: false),
					Accion = table.Column<byte>(nullable: false),
					Activo = table.Column<bool>(nullable: false, defaultValueSql: "1")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_NetAlarmasTiposRespuestasOrigenes", x => x.Id);
					table.ForeignKey(
						name: "FK_NetAlarmasTiposRespuestasOrigenes_NetAlarmasRespuestas_NetAlarmasRespuestaId",
						column: x => x.NetAlarmasRespuestaId,
						principalTable: "NetAlarmasRespuestas",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_NetAlarmasTiposRespuestasOrigenes_NetAlarmasTipos_NetAlarmasTipoId",
						column: x => x.NetAlarmasTipoId,
						principalTable: "NetAlarmasTipos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_NetAlarmasTiposRespuestasOrigenes_Origenes_OrigenId",
						column: x => x.OrigenId,
						principalTable: "Origenes",
						principalColumn: "ID",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasTiposRespuestasOrigenes_NetAlarmasRespuestaId",
				table: "NetAlarmasTiposRespuestasOrigenes",
				column: "NetAlarmasRespuestaId");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasTiposRespuestasOrigenes_NetAlarmasTipoId",
				table: "NetAlarmasTiposRespuestasOrigenes",
				column: "NetAlarmasTipoId");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasTiposRespuestasOrigenes_OrigenId",
				table: "NetAlarmasTiposRespuestasOrigenes",
				column: "OrigenId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "NetAlarmasTiposRespuestasOrigenes");
		}
	}
}
