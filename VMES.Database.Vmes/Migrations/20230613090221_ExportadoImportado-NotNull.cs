using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class ExportadoImportadoNotNull : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP INDEX IF EXISTS [IEntradas1] ON [Entradas];");
			migrationBuilder.Sql("CREATE INDEX [IEntradas1] ON [Entradas]([id]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IEntradasLineas] ON [EntradasLineas];");
			migrationBuilder.Sql("CREATE INDEX [IEntradasLineas] ON [EntradasLineas]([id]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IProductos1] ON [Productos];");
			migrationBuilder.Sql("CREATE INDEX [IProductos1] ON [Productos]([Id]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [ISalidasLinias1] ON [SalidasLinias];");
			migrationBuilder.Sql("CREATE INDEX [ISalidasLinias1] ON [SalidasLinias]([id]);");

			migrationBuilder.Sql("UPDATE [Clientes] SET [Exportado] = 0 WHERE [Exportado] IS NULL;");
			migrationBuilder.Sql("UPDATE [Clientes] SET [Importado] = 0 WHERE [Importado] IS NULL;");

			migrationBuilder.Sql("UPDATE [Compras] SET [Exportado] = 0 WHERE [Exportado] IS NULL;");
			migrationBuilder.Sql("UPDATE [Compras] SET [Importado] = 0 WHERE [Importado] IS NULL;");

			migrationBuilder.Sql("UPDATE [Entradas] SET [exportado] = 0 WHERE [exportado] IS NULL;");
			migrationBuilder.Sql("UPDATE [EntradasLineas] SET [exportado] = 0 WHERE [exportado] IS NULL;");

			migrationBuilder.Sql("UPDATE [Lotes] SET [Exportado] = 0 WHERE [Exportado] IS NULL;");
			migrationBuilder.Sql("UPDATE [Lotes] SET [Importado] = 0 WHERE [Importado] IS NULL;");

			migrationBuilder.Sql("UPDATE [Productos] SET [Exportado] = 0 WHERE [Exportado] IS NULL;");
			migrationBuilder.Sql("UPDATE [Productos] SET [Importado] = 0 WHERE [Importado] IS NULL;");

			migrationBuilder.Sql("UPDATE [Proveedores] SET [Exportado] = 0 WHERE [Exportado] IS NULL;");
			migrationBuilder.Sql("UPDATE [Proveedores] SET [Importado] = 0 WHERE [Importado] IS NULL;");

			migrationBuilder.Sql("UPDATE [Salidas] SET [Exportado] = 0 WHERE [Exportado] IS NULL;");

			migrationBuilder.Sql("UPDATE [SalidasLinias] SET [Exportado] = 0 WHERE [Exportado] IS NULL;");

			migrationBuilder.Sql("UPDATE [SalidasViajes] SET [Exportado] = 0 WHERE [Exportado] IS NULL;");

			migrationBuilder.DropIndex(
				name: "ISalidasLinias1",
				table: "SalidasLinias");

			migrationBuilder.DropIndex(
				name: "IProductos1",
				table: "Productos");

			migrationBuilder.DropIndex(
				name: "IEntradasLineas",
				table: "EntradasLineas");

			migrationBuilder.DropIndex(
				name: "IEntradas1",
				table: "Entradas");

			migrationBuilder.AddColumn<bool>(
				name: "Exportado",
				table: "VentasLinias",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<bool>(
				name: "Importado",
				table: "VentasLinias",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<bool>(
				name: "Exportado",
				table: "Ventas",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<bool>(
				name: "Importado",
				table: "Ventas",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "SalidasViajes",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "Importado",
				table: "SalidasViajes",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "SalidasLinias",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "Importado",
				table: "SalidasLinias",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Salidas",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "Importado",
				table: "Salidas",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Proveedores",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Proveedores",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Productos",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Productos",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Ordenes",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Ordenes",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Lotes",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Lotes",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "exportado",
				table: "EntradasLineas",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "Importado",
				table: "EntradasLineas",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AlterColumn<bool>(
				name: "exportado",
				table: "Entradas",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true,
				oldDefaultValueSql: "((0))");

			migrationBuilder.AddColumn<bool>(
				name: "Importado",
				table: "Entradas",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Compras",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Compras",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Clientes",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Clientes",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Exportado",
				table: "VentasLinias");

			migrationBuilder.DropColumn(
				name: "Importado",
				table: "VentasLinias");

			migrationBuilder.DropColumn(
				name: "Exportado",
				table: "Ventas");

			migrationBuilder.DropColumn(
				name: "Importado",
				table: "Ventas");

			migrationBuilder.DropColumn(
				name: "Importado",
				table: "SalidasViajes");

			migrationBuilder.DropColumn(
				name: "Importado",
				table: "SalidasLinias");

			migrationBuilder.DropColumn(
				name: "Importado",
				table: "Salidas");

			migrationBuilder.DropColumn(
				name: "Importado",
				table: "EntradasLineas");

			migrationBuilder.DropColumn(
				name: "Importado",
				table: "Entradas");

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "SalidasViajes",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "SalidasLinias",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Salidas",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Proveedores",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Proveedores",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Productos",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Productos",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Ordenes",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Ordenes",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Lotes",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Lotes",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "exportado",
				table: "EntradasLineas",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "exportado",
				table: "Entradas",
				type: "bit",
				nullable: true,
				defaultValueSql: "((0))",
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Compras",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Compras",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Clientes",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Clientes",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.CreateIndex(
				name: "ISalidasLinias1",
				table: "SalidasLinias",
				columns: new[] { "id", "idSalidas", "idProducto", "idFormato", "idEnvase", "idUnidad", "idDomicilio", "Origen1", "Origen2", "Origen3", "Origen4", "FueraCajon", "Cajon1", "Cajon2", "Cajon3", "Cajon4", "Cajon5", "Cajon6", "Cajon7", "Cajon8", "Cajon9", "Cajon10", "FechaFinCarga", "FechaInicioCarga", "Bultos", "Bruto", "Tara", "Estado", "PrecioUnidad", "Cantidad", "LedControlDocumental", "LedAnalisisLaboratorio", "LedAutorizacion", "LedCargaProducto", "LedDevolucionTarjeta", "idorden", "TransitoActivo", "idmodulo", "Fecha", "Precio", "PrecioTransporte", "EstadoTarjeta", "Observaciones", "Autorizada", "idBasculaPesajeNeto", "idBasculaPesajeBruto", "PesoNetoManual", "CampoLibre1", "CampoLibre2", "LedViajeAsignado", "idPuntoDescarga", "Exportado", "ErrorExportacion", "idAlbaran", "TipoOrigen", "CamionBanera", "VaciarSilos", "RefPedidoERP", "idviajes" });

			migrationBuilder.CreateIndex(
				name: "IProductos1",
				table: "Productos",
				columns: new[] { "Id", "Nombre", "Familia", "Densidad", "Unidad", "Tipo", "Stock", "ControlStock", "Dosificable", "Automatico", "TipoDosificacion", "Formato", "Envase", "Referencia", "Referencia2", "Importado", "Humedad", "PesoEspecifico", "Entradas", "Muestras", "EtiquetaGranel", "EtiquetaSacos", "EtiquetaMuestras", "EtiquetaControl", "Formula", "Analisi", "NumeroRegistro", "Inhabilitado", "Caducidad", "Refrescado", "Receptable", "Exportado", "Medicamento", "AplicacionDirecta", "Modulo", "FamiliaMedidor", "Afeccion", "PrecioCompra", "PrecioVenta", "PrecioMedioCompra", "StockMinimo", "Bloqueado", "TiempoEspera", "TipoIva", "PrecioCompraMedio", "PrecioCompraUltimo", "Estado", "EtiquetaEntradas", "ViaAdministracion", "MostrarEnEtiqueta", "NombreAMostrarEnEtiqueta", "idOld", "ToleranciaSuperior", "ToleranciaInferior", "PausaPosteriorDosificacion", "DesviacionMaxima", "PlantillaCabCargaPiquera", "TipoPR", "PlantillaCabProduccion", "PlantillaCabCargaPiquera2", "PlantillaCabSecadero", "EAN13", "Medidor" });

			migrationBuilder.CreateIndex(
				name: "IEntradasLineas",
				table: "EntradasLineas",
				columns: new[] { "id", "idProducto", "CantidadPedida", "FechaInicioRecepcion", "FechaFinRecepcion", "PesoBruto", "Cajon1", "Cajon2", "Cajon3", "Cajon4", "Cajon5", "Cajon6", "Cajon7", "Cajon8", "Cajon9", "Cajon10", "TransitoActivo", "idBasculaPesajeBruto", "idBasculaPesajeNeto", "EntradaManualPesos", "Estado", "FueraCajon", "idProveedor", "LedControlDocumental", "LedAnalisisLaboratorio", "LedAutorizacion", "LedCargaProducto", "LedDevolucionTarjeta", "Lote", "Tara", "PesoNetoManual", "RecogerPesoEnBascula", "Unidad", "Destino1", "Destino2", "Destino3", "Destino4", "Formato", "Envase", "Bultos", "Observaciones", "Precio", "PagarKgTeoricos", "CampoLibre1", "CampoLIbre2", "Fecha", "idModulo", "Autorizada", "EstadoTarjeta", "exportado", "ErrorExport", "CamionBanera", "TipoOrigen", "Origen1", "Origen2", "Origen3", "Origen4", "NetoOrigen", "NumLineaCompra", "idEntradas" });

			migrationBuilder.CreateIndex(
				name: "IEntradas1",
				table: "Entradas",
				columns: new[] { "id", "FechaCreacion", "FechaPrevista", "idVehiculo", "idChofer", "idProveedor", "idTarjeta", "EstadoTransito", "MatriculaCamion", "NombreConductor", "Observaciones", "idEmpresaTransporte", "LedControlDocumental", "MatriculaRemolque", "Precio", "FInicio", "Referencia", "ReferenciaCompra", "PreDesinfeccion", "PostDesinfeccion", "PreDesinfeccionOK", "PostDesinfeccionOK", "exportado", "Serie", "Numero", "FFin", "Estado" });
		}
	}
}
