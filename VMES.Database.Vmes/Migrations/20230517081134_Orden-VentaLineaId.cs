using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class OrdenVentaLineaId : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP INDEX IF EXISTS [_dta_index_Ordenes_3] ON [Ordenes];");
			migrationBuilder.Sql("CREATE INDEX [_dta_index_Ordenes_3] ON [Ordenes]([Id]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [iOrdenes_estado_ffin] ON [Ordenes];");
			migrationBuilder.Sql("CREATE INDEX [iOrdenes_estado_ffin] ON [Ordenes]([Id]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [_dta_index_Ordenes_1] ON [Ordenes];");
			migrationBuilder.Sql("CREATE INDEX [_dta_index_Ordenes_1] ON [Ordenes]([Id]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [_dta_index_Ordenes_2] ON [Ordenes];");
			migrationBuilder.Sql("CREATE INDEX [_dta_index_Ordenes_2] ON [Ordenes]([Id]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IndexOrdenes_1] ON [Ordenes];");
			migrationBuilder.Sql("CREATE INDEX [IndexOrdenes_1] ON [Ordenes]([Id]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IndOrdenes_ModuloEstadoBloqueada] ON [Ordenes];");
			migrationBuilder.Sql("CREATE INDEX [IndOrdenes_ModuloEstadoBloqueada] ON [Ordenes]([Id]);");

			migrationBuilder.DropIndex(
				name: "_dta_index_Ordenes_3",
				table: "Ordenes");

			migrationBuilder.DropIndex(
				name: "iOrdenes_estado_ffin",
				table: "Ordenes");

			migrationBuilder.DropIndex(
				name: "_dta_index_Ordenes_1",
				table: "Ordenes");

			migrationBuilder.DropIndex(
				name: "_dta_index_Ordenes_2",
				table: "Ordenes");

			migrationBuilder.DropIndex(
				name: "IndexOrdenes_1",
				table: "Ordenes");

			migrationBuilder.DropIndex(
				name: "IndOrdenes_ModuloEstadoBloqueada",
				table: "Ordenes");

			migrationBuilder.AddColumn<int>(
				name: "VentaLineaId",
				table: "Ordenes",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_IdCab",
				table: "Ordenes",
				column: "IdCab");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_VentaLineaId",
				table: "Ordenes",
				column: "VentaLineaId");

			migrationBuilder.AddForeignKey(
				name: "FK_Ordenes_VentasLinias_VentaLineaId",
				table: "Ordenes",
				column: "VentaLineaId",
				principalTable: "VentasLinias",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Ordenes_VentasLinias_VentaLineaId",
				table: "Ordenes");

			migrationBuilder.DropIndex(
				name: "IX_Ordenes_IdCab",
				table: "Ordenes");

			migrationBuilder.DropIndex(
				name: "IX_Ordenes_VentaLineaId",
				table: "Ordenes");

			migrationBuilder.DropColumn(
				name: "VentaLineaId",
				table: "Ordenes");

			migrationBuilder.CreateIndex(
				name: "_dta_index_Ordenes_3",
				table: "Ordenes",
				column: "Medicada");

			migrationBuilder.CreateIndex(
				name: "iOrdenes_estado_ffin",
				table: "Ordenes",
				columns: new[] { "Estado", "Fin" });

			migrationBuilder.CreateIndex(
				name: "_dta_index_Ordenes_1",
				table: "Ordenes",
				columns: new[] { "IdCab", "Serie", "Id", "Nombre", "Departamento", "Modulo", "Cantidad", "Fecha", "Servida", "Inicio", "Fin", "Formula", "NumeroCiclos", "ContadorCiclos", "Exportado", "LoteNombre", "FormulaFecha", "ProductoDestino", "LoteDestino", "TipoFinalizacion", "Tiempo", "Velocidad", "Ganancia", "GananciaUnidad", "EnvaseOrigen", "BultosOrigen", "Modificada", "Receta", "Medicacion", "Version", "Confirmada", "SerieSalida", "Salida", "LineaSalida", "SerieEntrada", "Entrada", "LineaEntrada", "SeriePlanificacion", "Planificacion", "Importado", "LineaVenta", "OrdenAscendiente", "SerieOrdenAscendiente", "SerieOrdenRelacionada", "OrdenRelacionada", "Medicada", "idChofer", "idTarjeta", "Editada", "idOld", "SerieOld", "IniciarOrden", "Caminos", "FechaEnvioAPlc", "Bloqueada", "ViajeSalida", "SerieViajeSalida", "OrdenEnvioPLC", "Estado" });

			migrationBuilder.CreateIndex(
				name: "_dta_index_Ordenes_2",
				table: "Ordenes",
				columns: new[] { "Serie", "Id", "Nombre", "Departamento", "Modulo", "Cantidad", "Fecha", "Estado", "Servida", "Inicio", "Fin", "Formula", "NumeroCiclos", "ContadorCiclos", "Exportado", "LoteNombre", "FormulaFecha", "ProductoDestino", "LoteDestino", "TipoFinalizacion", "Tiempo", "Velocidad", "Ganancia", "GananciaUnidad", "EnvaseOrigen", "BultosOrigen", "Modificada", "Receta", "Medicacion", "Version", "Confirmada", "SerieSalida", "Salida", "LineaSalida", "SerieEntrada", "Entrada", "LineaEntrada", "SeriePlanificacion", "Planificacion", "Importado", "LineaVenta", "OrdenAscendiente", "SerieOrdenAscendiente", "SerieOrdenRelacionada", "OrdenRelacionada", "Medicada", "idChofer", "idTarjeta", "Editada", "idOld", "SerieOld", "IniciarOrden", "OrdenEnvioPLC", "Caminos", "FechaEnvioAPlc", "Bloqueada", "ViajeSalida", "SerieViajeSalida", "IdCab" });

			migrationBuilder.CreateIndex(
				name: "IndexOrdenes_1",
				table: "Ordenes",
				columns: new[] { "Serie", "Nombre", "Departamento", "Modulo", "Cantidad", "Fecha", "Estado", "Servida", "Inicio", "Fin", "Formula", "NumeroCiclos", "ContadorCiclos", "Exportado", "LoteNombre", "FormulaFecha", "ProductoDestino", "LoteDestino", "TipoFinalizacion", "Tiempo", "Velocidad", "Ganancia", "GananciaUnidad", "EnvaseOrigen", "BultosOrigen", "Modificada", "Receta", "Medicacion", "Version", "Confirmada", "SerieSalida", "Salida", "LineaSalida", "SerieEntrada", "Entrada", "LineaEntrada", "SeriePlanificacion", "Planificacion", "Importado", "LineaVenta", "OrdenAscendiente", "SerieOrdenAscendiente", "SerieOrdenRelacionada", "OrdenRelacionada", "Medicada", "idChofer", "idTarjeta", "Editada", "idOld", "SerieOld", "IniciarOrden", "OrdenEnvioPLC", "Caminos", "FechaEnvioAPlc", "Bloqueada", "ViajeSalida", "SerieViajeSalida", "NombreChofer", "Matricula", "Remolque", "IdVehiculo", "RefERP", "SegundosCicloTeorico", "DatosOptimizados", "IncompatComprobada", "IncompatFlexible", "IncompatEstricta", "IncompatInfo", "TiempoPrevistoCicloSegs", "IdCab", "Id" });

			migrationBuilder.CreateIndex(
				name: "IndOrdenes_ModuloEstadoBloqueada",
				table: "Ordenes",
				columns: new[] { "IdCab", "Serie", "Id", "Nombre", "Departamento", "Cantidad", "Fecha", "Servida", "Inicio", "Fin", "Formula", "NumeroCiclos", "ContadorCiclos", "Exportado", "LoteNombre", "FormulaFecha", "ProductoDestino", "LoteDestino", "TipoFinalizacion", "Tiempo", "Velocidad", "Ganancia", "GananciaUnidad", "EnvaseOrigen", "BultosOrigen", "Modificada", "Receta", "Medicacion", "Version", "Confirmada", "SerieSalida", "Salida", "LineaSalida", "SerieEntrada", "Entrada", "LineaEntrada", "SeriePlanificacion", "Planificacion", "Importado", "LineaVenta", "OrdenAscendiente", "SerieOrdenAscendiente", "SerieOrdenRelacionada", "OrdenRelacionada", "Medicada", "idChofer", "idTarjeta", "Editada", "idOld", "SerieOld", "IniciarOrden", "OrdenEnvioPLC", "Caminos", "FechaEnvioAPlc", "ViajeSalida", "SerieViajeSalida", "NombreChofer", "Matricula", "Remolque", "IdVehiculo", "RefERP", "SegundosCicloTeorico", "DatosOptimizados", "IncompatComprobada", "IncompatFlexible", "IncompatEstricta", "IncompatInfo", "TiempoPrevistoCicloSegs", "FechaInicioPrevista", "NecesitaOrigen", "Fexportado", "ExportError", "TotalCiclosReal", "RefERP1", "RefERP2", "RefERP3", "Modulo", "Estado", "Bloqueada" });
		}
	}
}
