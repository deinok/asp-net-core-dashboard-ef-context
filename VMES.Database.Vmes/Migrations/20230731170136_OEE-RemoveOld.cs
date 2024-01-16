using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class OEERemoveOld : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_Modulos_EstadoForzado] ON [Modulos];");
			migrationBuilder.Sql("CREATE INDEX [IX_Modulos_EstadoForzado] ON [Modulos]([EstadoForzado]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_Medidores_EstadoForzado] ON [Medidores];");
			migrationBuilder.Sql("CREATE INDEX [IX_Medidores_EstadoForzado] ON [Medidores]([EstadoForzado]);");

			migrationBuilder.DropForeignKey(
				name: "FK_Medidores_OEEEstadosTipo",
				table: "Medidores");

			migrationBuilder.DropForeignKey(
				name: "FK_Modulos_OEEEstadosTipo",
				table: "Modulos");

			migrationBuilder.DropTable(
				name: "OEEEstados");

			migrationBuilder.DropTable(
				name: "OEEEstadosMedidores");

			migrationBuilder.DropTable(
				name: "OEEEstadosModulos");

			migrationBuilder.DropTable(
				name: "OEEEstadosTipoLista");

			migrationBuilder.DropTable(
				name: "OEEHorarios");

			migrationBuilder.DropTable(
				name: "Turnos");

			migrationBuilder.DropTable(
				name: "OEEEstadosTipo");

			migrationBuilder.DropIndex(
				name: "IX_Modulos_EstadoForzado",
				table: "Modulos");

			migrationBuilder.DropIndex(
				name: "IX_Medidores_EstadoForzado",
				table: "Medidores");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "OEEEstadosTipo",
				columns: table => new
				{
					id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
					EstadoAveria = table.Column<bool>(type: "bit", nullable: true),
					EstadoAveriaGrave = table.Column<bool>(type: "bit", nullable: true),
					EstadoEnHorario = table.Column<bool>(type: "bit", nullable: true),
					EstadoMantenimiento = table.Column<bool>(type: "bit", nullable: true),
					EstadoProduciendo = table.Column<bool>(type: "bit", nullable: true),
					Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
					Tipo = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OEEEstadosTipo", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "OEEHorarios",
				columns: table => new
				{
					id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Domingo = table.Column<bool>(type: "bit", nullable: false),
					HoraFin = table.Column<TimeSpan>(type: "time", nullable: false),
					HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
					Jueves = table.Column<bool>(type: "bit", nullable: false),
					Lunes = table.Column<bool>(type: "bit", nullable: false),
					Martes = table.Column<bool>(type: "bit", nullable: false),
					Miercoles = table.Column<bool>(type: "bit", nullable: false),
					Sabado = table.Column<bool>(type: "bit", nullable: false),
					Viernes = table.Column<bool>(type: "bit", nullable: false),
					idMedidor = table.Column<int>(type: "int", nullable: true),
					idModulo = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OEEHorarios", x => x.id);
					table.ForeignKey(
						name: "FK_OEEHorarios_Medidores",
						column: x => x.idMedidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OEEHorarios_Modulos",
						column: x => x.idModulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "Turnos",
				columns: table => new
				{
					id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					HoraFinal = table.Column<TimeSpan>(type: "time", nullable: true),
					HoraInicio = table.Column<TimeSpan>(type: "time", nullable: true),
					Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Turnos", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "OEEEstadosMedidores",
				columns: table => new
				{
					idEstadoTipo = table.Column<int>(type: "int", nullable: false),
					idMedidor = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OEEEstadosMedidores", x => new { x.idEstadoTipo, x.idMedidor });
					table.ForeignKey(
						name: "FK_OEEEstadosMedidores_OEEEstadosTipo",
						column: x => x.idEstadoTipo,
						principalTable: "OEEEstadosTipo",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OEEEstadosMedidores_Medidores",
						column: x => x.idMedidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "OEEEstadosModulos",
				columns: table => new
				{
					idEstadoTipo = table.Column<int>(type: "int", nullable: false),
					idModulo = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OEEEstadosModulos", x => new { x.idEstadoTipo, x.idModulo });
					table.ForeignKey(
						name: "FK_OEEEstadosModulos_OEEEstadosTipo",
						column: x => x.idEstadoTipo,
						principalTable: "OEEEstadosTipo",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OEEEstadosModulos_Modulos",
						column: x => x.idModulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "OEEEstadosTipoLista",
				columns: table => new
				{
					IdEstadoTipo = table.Column<int>(type: "int", nullable: false),
					IdEstadoEnum = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OEEEstadosTipoLista", x => new { x.IdEstadoTipo, x.IdEstadoEnum });
					table.ForeignKey(
						name: "FK_OEEEstadosTipoLista_OEEEstadosTipo",
						column: x => x.IdEstadoTipo,
						principalTable: "OEEEstadosTipo",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "OEEEstados",
				columns: table => new
				{
					id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Estado = table.Column<int>(type: "int", nullable: true),
					FFinal = table.Column<DateTime>(type: "datetime", nullable: true),
					FInicio = table.Column<DateTime>(type: "datetime", nullable: true),
					IdAlarmaActual = table.Column<int>(type: "int", nullable: true),
					IdMedidor = table.Column<int>(type: "int", nullable: true),
					IdModulo = table.Column<int>(type: "int", nullable: true),
					IdOrdenActual = table.Column<int>(type: "int", nullable: true),
					IdTurno = table.Column<int>(type: "int", nullable: true),
					OperarioId = table.Column<int>(type: "int", nullable: true),
					VentanaSegs = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OEEEstados", x => x.id);
					table.ForeignKey(
						name: "FK_OEEEstados_OEEEstadosTipo",
						column: x => x.Estado,
						principalTable: "OEEEstadosTipo",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OEEEstados_NetAlarmas",
						column: x => x.IdAlarmaActual,
						principalTable: "NetAlarmas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OEEEstados_Medidores",
						column: x => x.IdMedidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OEEEstados_Modulos",
						column: x => x.IdModulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OEEEstados_Ordenes",
						column: x => x.IdOrdenActual,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OEEEstados_Turnos",
						column: x => x.IdTurno,
						principalTable: "Turnos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OEEEstados_Usuarios",
						column: x => x.OperarioId,
						principalTable: "Usuarios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Modulos_EstadoForzado",
				table: "Modulos",
				column: "EstadoForzado");

			migrationBuilder.CreateIndex(
				name: "IX_Medidores_EstadoForzado",
				table: "Medidores",
				column: "EstadoForzado");

			migrationBuilder.CreateIndex(
				name: "IX_OEEEstados_Estado",
				table: "OEEEstados",
				column: "Estado");

			migrationBuilder.CreateIndex(
				name: "IX_OEEEstados_IdAlarmaActual",
				table: "OEEEstados",
				column: "IdAlarmaActual");

			migrationBuilder.CreateIndex(
				name: "IX_OEEEstados_IdMedidor",
				table: "OEEEstados",
				column: "IdMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_OEEEstados_IdModulo",
				table: "OEEEstados",
				column: "IdModulo");

			migrationBuilder.CreateIndex(
				name: "IX_OEEEstados_IdOrdenActual",
				table: "OEEEstados",
				column: "IdOrdenActual");

			migrationBuilder.CreateIndex(
				name: "IX_OEEEstados_IdTurno",
				table: "OEEEstados",
				column: "IdTurno");

			migrationBuilder.CreateIndex(
				name: "IX_OEEEstados_OperarioId",
				table: "OEEEstados",
				column: "OperarioId");

			migrationBuilder.CreateIndex(
				name: "_dta_index_OEEEstados_6_140579589__K2_1_3_4_5_6_7_8_9_10_11",
				table: "OEEEstados",
				columns: new[] { "id", "IdMedidor", "Estado", "FInicio", "FFinal", "VentanaSegs", "OperarioId", "IdTurno", "IdAlarmaActual", "IdOrdenActual", "IdModulo" });

			migrationBuilder.CreateIndex(
				name: "IX_OEEEstadosMedidores_idMedidor",
				table: "OEEEstadosMedidores",
				column: "idMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_OEEEstadosModulos_idModulo",
				table: "OEEEstadosModulos",
				column: "idModulo");

			migrationBuilder.CreateIndex(
				name: "IX_OEEHorarios_idMedidor",
				table: "OEEHorarios",
				column: "idMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_OEEHorarios_idModulo",
				table: "OEEHorarios",
				column: "idModulo");

			migrationBuilder.AddForeignKey(
				name: "FK_Medidores_OEEEstadosTipo",
				table: "Medidores",
				column: "EstadoForzado",
				principalTable: "OEEEstadosTipo",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Modulos_OEEEstadosTipo",
				table: "Modulos",
				column: "EstadoForzado",
				principalTable: "OEEEstadosTipo",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);
		}
	}
}
