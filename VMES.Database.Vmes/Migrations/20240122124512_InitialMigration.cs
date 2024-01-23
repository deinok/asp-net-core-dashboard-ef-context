using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class InitialMigration : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
CREATE FUNCTION [dbo].[LoteEnUbicacion] 
(
	-- Add the parameters for the function here
	@ubi int
)
RETURNS nvarchar(50)
AS
BEGIN
	DECLARE @ResultVar nvarchar(50);
	
	select top 1 @ResultVar = L.Nombre 
		from stocks as s
		inner join Lotes as L on L.id = s.Lote 
		where s.Ubicacion = @ubi 
			and (s.Estado =1)
		order by s.Fecha asc;


	RETURN @ResultVar

END
			");
			migrationBuilder.Sql(@"
CREATE FUNCTION [dbo].[OrdenCantidadProducida]
(
	-- Add the parameters for the function here
	@idorden as int
)
RETURNS decimal(18,4)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ret decimal(18,4)
	SELECT @ret= sum(Cantidad)   from Desgloses where Orden = @idorden
	RETURN isnull(@ret,0)
END
			");
			migrationBuilder.Sql(@"
CREATE FUNCTION [dbo].[OrdenKWConsumidosEfectivo]
(
	-- Add the parameters for the function here
	@idorden as int
)
RETURNS decimal(18,4)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ret decimal(18,4)
	SELECT @ret= sum(KwhEfectivo)  from Resultados where Orden = @idorden
	RETURN isnull(@ret,0)
END
			");
			migrationBuilder.Sql(@"
CREATE FUNCTION [dbo].[OrdenKWConsumidosTotal]
(
	-- Add the parameters for the function here
	@idorden as int
)
RETURNS decimal(18,4)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ret decimal(18,4)
	SELECT @ret= sum(KWhTotal)  from Resultados where Orden = @idorden
	RETURN isnull(@ret,0)
END
			");
			migrationBuilder.Sql(@"
CREATE FUNCTION [dbo].[OrdenKWEfectivoCantidad]
(
	-- Add the parameters for the function here
	@idorden as int
)
RETURNS decimal(18,6)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ret decimal(18,6)
	declare @cantidad decimal(18,6)

	set @ret= isnull( ([dbo].[OrdenKWProducidosEfectivo](@idorden)) + ([dbo].[OrdenKWConsumidosEfectivo](@idorden)),0)
	set @cantidad = ISNULL( dbo.OrdenCantidadProducida(@idorden),0)

	if @cantidad =0 or @ret=0  return 0;
	
	set @ret= @ret/(@cantidad/1000)

	RETURN isnull(@ret,0)
END
			");
			migrationBuilder.Sql(@"
CREATE FUNCTION [dbo].[OrdenKWProducidosEfectivo]
(
	-- Add the parameters for the function here
	@idorden as int
)
RETURNS decimal(18,4)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ret decimal(18,4)
	SELECT @ret= sum(KWhEfectivo)  from Desgloses where Orden = @idorden
	RETURN isnull(@ret,0)
END
			");
			migrationBuilder.Sql(@"
CREATE FUNCTION [dbo].[OrdenKWProducidosTotal]
(
	-- Add the parameters for the function here
	@idorden as int
)
RETURNS decimal(18,4)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ret decimal(18,4)
	SELECT @ret= sum(KWhTotal)  from Desgloses where Orden = @idorden
	RETURN isnull(@ret,0)
END
			");
			migrationBuilder.Sql(@"
CREATE FUNCTION [dbo].[OrdenKWTotalCantidad]
(
	-- Add the parameters for the function here
	@idorden as int
)
RETURNS decimal(18,6)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ret decimal(18,6)
	declare @cantidad decimal(18,6)

	set @ret= isnull( ([dbo].[OrdenKWProducidosTotal](@idorden)) + ([dbo].[OrdenKWConsumidosTotal](@idorden)),0)
	set @cantidad = ISNULL( dbo.OrdenCantidadProducida(@idorden),0)

	if @cantidad =0 or @ret=0  return 0;
	
	set @ret= @ret/(@cantidad/1000)

	RETURN isnull(@ret,0)
END
			");
			migrationBuilder.Sql(@"
CREATE FUNCTION [dbo].[StockEnUbicacion] 
(
	-- Add the parameters for the function here
	@ubi int,
	@NoNegativos bit
)
RETURNS decimal(18,5)
AS
BEGIN
	DECLARE @ResultVar decimal(18,5)


	if @NoNegativos = 1
	begin
		SELECT @ResultVar =  sum(cantidad) FROM Stocks WHERE Ubicacion  =@ubi and (Estado = 1 or Estado=2) and Cantidad >0
		RETURN @ResultVar
	end

		SELECT @ResultVar =  sum(cantidad) FROM Stocks WHERE Ubicacion  =@ubi and (Estado = 1 or Estado=2)
		RETURN @ResultVar

END
			");

			migrationBuilder.CreateTable(
				name: "Afecciones",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					Nombre = table.Column<string>(maxLength: 255, nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Afecciones", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AlertasSmtpConfigs",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					smtpServer = table.Column<string>(maxLength: 50, nullable: true),
					smtpPort = table.Column<int>(nullable: true),
					smtpUser = table.Column<string>(maxLength: 50, nullable: true),
					smtpPass = table.Column<string>(maxLength: 50, nullable: true),
					smtpSSL = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					smtpEmisor = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AlertasSmtpConfigs", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "Analisis",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Precio = table.Column<float>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					idOld = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Analisis", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Audits",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Timestamp = table.Column<DateTime>(nullable: false),
					Hostname = table.Column<string>(maxLength: 256, nullable: false),
					StackTrace = table.Column<string>(nullable: true),
					User = table.Column<string>(maxLength: 64, nullable: true),
					Ip = table.Column<string>(maxLength: 64, nullable: true),
					Mac = table.Column<string>(maxLength: 64, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Audits", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Backups",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					HayError = table.Column<bool>(nullable: true),
					TextoError = table.Column<string>(maxLength: 500, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Backups", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPCabOrdenes",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: false),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					RefProducto = table.Column<string>(maxLength: 50, nullable: true),
					NombreProducto = table.Column<string>(maxLength: 50, nullable: true),
					NombreLoteProducto = table.Column<string>(maxLength: 50, nullable: true),
					FCaducidadLoteProducto = table.Column<DateTime>(type: "date", nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					NumCiclos = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					Tratado = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					preparado = table.Column<bool>(nullable: true),
					RefERP = table.Column<string>(maxLength: 50, nullable: true),
					FFabricacionLoteProducto = table.Column<DateTime>(type: "date", nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPCabOrdenes", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPChoferes",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Timestamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					CIF = table.Column<string>(maxLength: 14, nullable: true),
					Direccion = table.Column<string>(maxLength: 50, nullable: true),
					CodigoPostal = table.Column<string>(maxLength: 5, nullable: true),
					Poblacion = table.Column<string>(maxLength: 50, nullable: true),
					Provincia = table.Column<string>(maxLength: 50, nullable: true),
					Pais = table.Column<string>(maxLength: 50, nullable: true),
					Telefono = table.Column<string>(maxLength: 20, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPChoferes", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPClientes",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					CIF = table.Column<string>(maxLength: 14, nullable: true),
					Direccion = table.Column<string>(maxLength: 50, nullable: true),
					CodigoPostal = table.Column<string>(maxLength: 5, nullable: true),
					Poblacion = table.Column<string>(maxLength: 50, nullable: true),
					Telefono = table.Column<string>(maxLength: 20, nullable: true),
					Inhabilitado = table.Column<bool>(nullable: true),
					RazonSocial = table.Column<string>(maxLength: 50, nullable: true),
					Provincia = table.Column<string>(maxLength: 50, nullable: true),
					Pais = table.Column<string>(maxLength: 50, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPClientes", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPCompras",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Serie = table.Column<int>(nullable: true),
					ProveedorId = table.Column<int>(nullable: true),
					ProveedorRef = table.Column<string>(maxLength: 20, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					DepartamentoId = table.Column<int>(nullable: true),
					DepartamentoRef = table.Column<string>(maxLength: 20, nullable: true),
					Entrega = table.Column<DateTime>(type: "datetime", nullable: true),
					Comentario = table.Column<string>(maxLength: 100, nullable: true),
					Refrescado = table.Column<bool>(nullable: true),
					Numero = table.Column<int>(nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					ContratoId = table.Column<int>(nullable: true),
					ContratoRef = table.Column<string>(maxLength: 20, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPCompras", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPConsumidos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Orden = table.Column<string>(maxLength: 50, nullable: true),
					FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaFinal = table.Column<DateTime>(type: "datetime", nullable: true),
					RefProdFinal = table.Column<string>(maxLength: 50, nullable: true),
					NombreProdFinal = table.Column<string>(maxLength: 50, nullable: true),
					LoteProdFinal = table.Column<string>(maxLength: 50, nullable: true),
					FCaducidadLoteProdFinal = table.Column<DateTime>(type: "date", nullable: true),
					RefProdConsumido = table.Column<string>(maxLength: 50, nullable: true),
					NombreProdConsumido = table.Column<string>(maxLength: 50, nullable: true),
					Cantidad = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					idModulo = table.Column<int>(nullable: true),
					idMedidor = table.Column<int>(nullable: true),
					NombreModulo = table.Column<string>(maxLength: 50, nullable: true),
					NombreMedidor = table.Column<string>(maxLength: 50, nullable: true),
					Tipo = table.Column<int>(nullable: true),
					LoteProdConsumido = table.Column<string>(maxLength: 50, nullable: true),
					FCadLoteProdConsumido = table.Column<DateTime>(type: "date", nullable: true),
					Tratado = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					idOrden = table.Column<int>(nullable: true),
					idResultados = table.Column<int>(nullable: true),
					FFabricacionLoteProdFinal = table.Column<DateTime>(type: "date", nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					Numero = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPConsumidos", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPDocumentos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					RefERP = table.Column<int>(nullable: true),
					Entrada = table.Column<bool>(nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Visible = table.Column<bool>(nullable: true),
					ViajeSalida = table.Column<bool>(nullable: true),
					Automatico = table.Column<bool>(nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPDocumentos", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPEntradas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Serie = table.Column<int>(nullable: true),
					Numero = table.Column<int>(nullable: true),
					FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaPrevista = table.Column<DateTime>(type: "datetime", nullable: true),
					idVehiculo = table.Column<int>(nullable: true),
					idChofer = table.Column<int>(nullable: true),
					idProveedor = table.Column<int>(nullable: true),
					idTarjeta = table.Column<int>(nullable: true),
					MatriculaCamion = table.Column<string>(maxLength: 15, nullable: true),
					NombreConductor = table.Column<string>(maxLength: 50, nullable: true),
					Observaciones = table.Column<string>(maxLength: 500, nullable: true),
					idEmpresaTransporte = table.Column<int>(nullable: true),
					MatriculaRemolque = table.Column<string>(maxLength: 15, nullable: true),
					Precio = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					ReferenciaCompra = table.Column<string>(maxLength: 20, nullable: true),
					PreDesinfeccion = table.Column<bool>(nullable: true),
					PostDesinfeccion = table.Column<bool>(nullable: true),
					refProveedor = table.Column<string>(maxLength: 20, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					isExport = table.Column<bool>(nullable: true),
					idMES = table.Column<int>(nullable: true),
					SerieNombre = table.Column<string>(maxLength: 50, nullable: true),
					refEmpresaTransporte = table.Column<string>(maxLength: 20, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					exportado = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Preparado2 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					RefConductor = table.Column<string>(maxLength: 20, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPEntradas", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPFormulas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					RefProducto = table.Column<string>(maxLength: 50, nullable: true),
					IdProducto = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					EsMedicamento = table.Column<bool>(nullable: true),
					IdERPFormula = table.Column<int>(nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					VersionNueva = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPFormulas", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPImprimirDocumentos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					RefERP = table.Column<int>(nullable: true),
					IdSalida = table.Column<int>(nullable: true),
					IdEntrada = table.Column<int>(nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPImprimirDocumentos", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPPedidoVenta",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					RefCliente = table.Column<string>(maxLength: 50, nullable: true),
					RefDomicilio = table.Column<string>(maxLength: 50, nullable: true),
					RefPDescarga = table.Column<string>(maxLength: 50, nullable: true),
					Observaciones = table.Column<string>(nullable: true),
					Comentario = table.Column<string>(nullable: true),
					RefProducto = table.Column<string>(maxLength: 50, nullable: true),
					RefEnvase = table.Column<string>(maxLength: 50, nullable: true),
					RefFormato = table.Column<string>(maxLength: 50, nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					RefFormula = table.Column<string>(maxLength: 50, nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					RefChofer = table.Column<string>(maxLength: 50, nullable: true),
					RefVehiculo = table.Column<string>(maxLength: 50, nullable: true),
					RefEmpTransporte = table.Column<string>(maxLength: 50, nullable: true),
					MatriculaVehiculo = table.Column<string>(maxLength: 50, nullable: true),
					MatriculaRemolque = table.Column<string>(maxLength: 50, nullable: true),
					Conductor = table.Column<string>(maxLength: 50, nullable: true),
					FechaPrevista = table.Column<DateTime>(type: "datetime", nullable: true),
					RefUnidades = table.Column<string>(maxLength: 50, nullable: true),
					RefVersionFormula = table.Column<string>(maxLength: 50, nullable: true),
					RefERP = table.Column<string>(maxLength: 20, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPPedidoVenta", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPPedidoVentaExtra",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					RefProducto = table.Column<string>(maxLength: 50, nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					RefUnidad = table.Column<string>(maxLength: 50, nullable: true),
					Modulo = table.Column<int>(nullable: true),
					idPedidoVenta = table.Column<int>(nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPPedidoVentaExtra", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPProducidos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idOrden = table.Column<int>(nullable: true),
					idProducto = table.Column<int>(nullable: true),
					ProductoNombre = table.Column<string>(maxLength: 50, nullable: true),
					idLote = table.Column<int>(nullable: true),
					LoteNombre = table.Column<string>(maxLength: 50, nullable: true),
					LoteFCaducidad = table.Column<DateTime>(type: "date", nullable: true),
					FechaOrden = table.Column<DateTime>(type: "datetime", nullable: true),
					CantidadTotal = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					NCiclos = table.Column<int>(nullable: true),
					CantidadCicloOriginal = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ProductoReferencia = table.Column<string>(maxLength: 50, nullable: true),
					idUbicacion = table.Column<int>(nullable: true),
					UbicacionNombre = table.Column<string>(maxLength: 50, nullable: true),
					idModulo = table.Column<int>(nullable: true),
					ModuloNombre = table.Column<string>(maxLength: 50, nullable: true),
					idDesglose = table.Column<int>(nullable: true),
					Tratado = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					LoteFFabricacion = table.Column<DateTime>(type: "date", nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					IdOrdenLegitimo = table.Column<int>(nullable: true),
					idFormula = table.Column<int>(nullable: true),
					FormulaNombre = table.Column<string>(maxLength: 50, nullable: true),
					FormulaReferencia = table.Column<string>(maxLength: 20, nullable: true),
					FormulaRefERP = table.Column<string>(maxLength: 20, nullable: true),
					idFormulaVersion = table.Column<int>(nullable: true),
					FormulaVersionNombre = table.Column<string>(maxLength: 50, nullable: true),
					FormulaVersionReferencia = table.Column<string>(maxLength: 20, nullable: true),
					FormulaVersionRefERP = table.Column<string>(maxLength: 20, nullable: true),
					idMedicacion = table.Column<int>(nullable: true),
					MedicacionNombre = table.Column<string>(maxLength: 50, nullable: true),
					ModuloRef = table.Column<string>(maxLength: 30, nullable: true),
					MedidorRef = table.Column<string>(maxLength: 20, nullable: true),
					ModuloTipo = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPProducidos", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPProductos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Familia = table.Column<string>(maxLength: 50, nullable: true),
					Densidad = table.Column<float>(nullable: true),
					UnidadRefERP = table.Column<string>(maxLength: 20, nullable: true),
					Tipo = table.Column<int>(nullable: true),
					FormatoRefERP = table.Column<string>(maxLength: 20, nullable: true),
					EnvaseRefERP = table.Column<string>(maxLength: 20, nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Referencia2 = table.Column<string>(maxLength: 20, nullable: true),
					NumeroRegistro = table.Column<string>(maxLength: 50, nullable: true),
					Caducidad = table.Column<int>(nullable: true),
					Medicamento = table.Column<bool>(nullable: true),
					Modulo = table.Column<int>(nullable: true),
					Medidor = table.Column<int>(nullable: true),
					TiempoEspera = table.Column<int>(nullable: true),
					ToleranciaSuperior = table.Column<decimal>(type: "numeric(18, 2)", nullable: true),
					ToleranciaInferior = table.Column<decimal>(type: "numeric(18, 2)", nullable: true),
					PausaPosteriorDosificacion = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					DesviacionMaxima = table.Column<decimal>(type: "numeric(18, 2)", nullable: true),
					Estado = table.Column<int>(nullable: true),
					IdERPProducto = table.Column<int>(nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPProductos", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPProveedores",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					CIF = table.Column<string>(maxLength: 14, nullable: true),
					Direccion = table.Column<string>(maxLength: 50, nullable: true),
					CodigoPostal = table.Column<string>(maxLength: 5, nullable: true),
					Poblacion = table.Column<string>(maxLength: 50, nullable: true),
					Telefono = table.Column<string>(maxLength: 20, nullable: true),
					Provincia = table.Column<string>(maxLength: 50, nullable: true),
					Abreviado = table.Column<string>(maxLength: 40, nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Pais = table.Column<string>(maxLength: 50, nullable: true),
					Inhabilitado = table.Column<bool>(nullable: true),
					Tipo = table.Column<int>(nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPProveedores", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPRegularizaciones",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					ProductoRef2 = table.Column<string>(maxLength: 50, nullable: true),
					ProductoRef = table.Column<string>(maxLength: 50, nullable: true),
					ProductoNombre = table.Column<string>(maxLength: 50, nullable: true),
					Cantidad = table.Column<decimal>(type: "decimal(18, 5)", nullable: true),
					idUbicacion = table.Column<int>(nullable: true),
					LoteId = table.Column<int>(nullable: true),
					LoteNombre = table.Column<string>(maxLength: 50, nullable: true),
					idMovimientoMes = table.Column<int>(nullable: true),
					Tipo = table.Column<int>(nullable: true),
					TipoTxt = table.Column<string>(maxLength: 50, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPRegularizaciones", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPSalidas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Serie = table.Column<int>(nullable: true),
					Numero = table.Column<int>(nullable: true),
					Observaciones = table.Column<string>(nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Comentario = table.Column<string>(nullable: true),
					FechaPrevista = table.Column<DateTime>(type: "datetime", nullable: true),
					RefCliente = table.Column<string>(maxLength: 50, nullable: true),
					esExport = table.Column<bool>(nullable: true),
					SerieNombre = table.Column<string>(maxLength: 50, nullable: true),
					idMES = table.Column<int>(nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					idSerie = table.Column<int>(nullable: true),
					NombreSerie = table.Column<string>(maxLength: 20, nullable: true),
					RefDomicilio = table.Column<string>(maxLength: 20, nullable: true),
					MatriculaCamion = table.Column<string>(maxLength: 20, nullable: true),
					FechaExpedicion = table.Column<DateTime>(type: "datetime", nullable: true),
					NombreChofer = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPSalidas", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPSalidasViajes",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					idSalidas = table.Column<int>(nullable: true),
					MatriculaRemolque = table.Column<string>(maxLength: 15, nullable: true),
					idVehiculo = table.Column<int>(nullable: true),
					idChofer = table.Column<int>(nullable: true),
					idTarjeta = table.Column<int>(nullable: true),
					EstadoTransito = table.Column<int>(nullable: true),
					MatriculaCamion = table.Column<string>(maxLength: 15, nullable: true),
					NombreConductor = table.Column<string>(maxLength: 50, nullable: true),
					Observaciones = table.Column<string>(maxLength: 500, nullable: true),
					idEmpresaTransporte = table.Column<int>(nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					idMES = table.Column<int>(nullable: true),
					FechaFinTransito = table.Column<DateTime>(type: "datetime", nullable: true),
					Serie = table.Column<int>(nullable: true),
					SerieNombre = table.Column<string>(maxLength: 50, nullable: true),
					Numero = table.Column<int>(nullable: true),
					EmpresaTransporteNombre = table.Column<string>(maxLength: 50, nullable: true),
					RefEmpresaTransporte = table.Column<string>(maxLength: 50, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					RefConductor = table.Column<string>(maxLength: 20, nullable: true),
					RefCliente = table.Column<string>(maxLength: 20, nullable: true),
					RefDomicilio = table.Column<string>(maxLength: 20, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPSalidasViajes", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPStocks",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Referencia2 = table.Column<string>(maxLength: 50, nullable: true),
					Cantidad = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					Tipo = table.Column<int>(nullable: true),
					FProducido = table.Column<DateTime>(type: "date", nullable: true),
					FCaducidad = table.Column<DateTime>(type: "date", nullable: true),
					Tratado = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Lote = table.Column<string>(maxLength: 50, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					Acumulativo = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					idUbicacion = table.Column<int>(nullable: true),
					FFabricacion = table.Column<DateTime>(type: "date", nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPStocks", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPVehiculos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Timestamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Matricula = table.Column<string>(maxLength: 10, nullable: true),
					Remolque = table.Column<string>(maxLength: 10, nullable: true),
					Tara = table.Column<float>(nullable: true),
					PesoMaximo = table.Column<int>(nullable: true),
					Chofer = table.Column<string>(maxLength: 50, nullable: true),
					EmpresaTransporte = table.Column<string>(maxLength: 50, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPVehiculos", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPVentas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Serie = table.Column<int>(nullable: true),
					ClienteId = table.Column<int>(nullable: true),
					ClienteRef = table.Column<string>(maxLength: 20, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaEntrega = table.Column<DateTime>(type: "datetime", nullable: true),
					DomicilioId = table.Column<int>(nullable: true),
					DomicilioRef = table.Column<string>(maxLength: 20, nullable: true),
					Comentario = table.Column<string>(nullable: true),
					Observaciones = table.Column<string>(nullable: true),
					PrecioTransporte = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					RefERP = table.Column<string>(maxLength: 50, nullable: true),
					isExport = table.Column<bool>(nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPVentas", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "Comprobaciones",
				columns: table => new
				{
					Tabla = table.Column<string>(maxLength: 50, nullable: false),
					Comprobacion = table.Column<string>(maxLength: 50, nullable: false),
					Id = table.Column<decimal>(type: "numeric(18, 0)", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Activo = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
					ComprobacionNombre = table.Column<string>(maxLength: 50, nullable: true),
					TablaNombre = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Comprobaciones", x => new { x.Tabla, x.Comprobacion });
				});

			migrationBuilder.CreateTable(
				name: "ConfigWCF",
				columns: table => new
				{
					Campo = table.Column<string>(maxLength: 50, nullable: false),
					Valor = table.Column<string>(maxLength: 50, nullable: false),
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ConfigWCF", x => x.Campo);
				});

			migrationBuilder.CreateTable(
				name: "Contadores",
				columns: table => new
				{
					Nombre = table.Column<string>(maxLength: 50, nullable: false),
					Contador = table.Column<int>(nullable: false),
					Fecha = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
					Visible = table.Column<bool>(nullable: false),
					IdSerie = table.Column<int>(nullable: true),
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Contadores", x => x.Nombre);
				});

			migrationBuilder.CreateTable(
				name: "ControlesNIR",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Descripcion = table.Column<string>(maxLength: 500, nullable: true),
					ValorMinimo = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ValorEsperado = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ValorMaximo = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ValorMinimoAlerta = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ValorMaximoAlerta = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ActivarMinimo = table.Column<bool>(nullable: true),
					ActivarMaximo = table.Column<bool>(nullable: true),
					ActivarMinimoAlerta = table.Column<bool>(nullable: true),
					ActivarMaximoAlerta = table.Column<bool>(nullable: true),
					Estado = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ControlesNIR", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "Dashboards",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(maxLength: 64, nullable: false),
					Value = table.Column<string>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Dashboards", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "DashboardsLibCategorias",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: false),
					isModificable = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
					isVisible = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_DashboardsLibCategorias", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Documentos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					TipoMovimiento = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Documentos", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Empresas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Direccion = table.Column<string>(maxLength: 50, nullable: true),
					Poblacion = table.Column<string>(maxLength: 40, nullable: true),
					CodigoPostal = table.Column<string>(maxLength: 5, nullable: true),
					Provincia = table.Column<string>(maxLength: 50, nullable: true),
					Telefono = table.Column<string>(maxLength: 15, nullable: true),
					Fax = table.Column<string>(maxLength: 15, nullable: true),
					Logotipo = table.Column<byte[]>(nullable: true),
					RSanidad = table.Column<string>(maxLength: 50, nullable: true),
					RIA = table.Column<string>(maxLength: 50, nullable: true),
					Cabecera1 = table.Column<string>(maxLength: 50, nullable: true),
					Cabecera2 = table.Column<string>(maxLength: 50, nullable: true),
					Cabecera3 = table.Column<string>(maxLength: 50, nullable: true),
					Cabecera4 = table.Column<string>(maxLength: 50, nullable: true),
					Cabecera5 = table.Column<string>(maxLength: 50, nullable: true),
					RegistroMercantil = table.Column<string>(maxLength: 254, nullable: true),
					Autorizacion = table.Column<string>(maxLength: 50, nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					CIF = table.Column<string>(maxLength: 14, nullable: true),
					AutorizacionDestinoFinal = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Empresas", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "EnlaceERPConversiones",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Tipo = table.Column<int>(nullable: true),
					VOriginal = table.Column<string>(maxLength: 150, nullable: true),
					VNuevo = table.Column<string>(maxLength: 150, nullable: true),
					campo = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EnlaceERPConversiones", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "EnlaceERPTipo",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Importacion = table.Column<bool>(nullable: true),
					Exportacion = table.Column<bool>(nullable: true),
					Tipo = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EnlaceERPTipo", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "Especies",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Especies", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Etiquetas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Contenido = table.Column<string>(nullable: true),
					Impresora = table.Column<int>(nullable: true),
					Inicializacion = table.Column<string>(maxLength: 50, nullable: true),
					Archivo = table.Column<string>(maxLength: 255, nullable: true),
					Tipo = table.Column<int>(nullable: true),
					Copias = table.Column<int>(nullable: true),
					EtiquetaEstilo = table.Column<int>(nullable: true),
					MarcaInicio = table.Column<string>(maxLength: 50, nullable: true),
					MarcaFin = table.Column<string>(maxLength: 50, nullable: true),
					MarcaFormato = table.Column<string>(maxLength: 50, nullable: true),
					MarcaVariable = table.Column<string>(maxLength: 50, nullable: true),
					Variable = table.Column<int>(nullable: true),
					Preliminar = table.Column<bool>(nullable: true),
					MarcaSeparacion = table.Column<string>(maxLength: 50, nullable: true),
					MacroCodigoBarras = table.Column<int>(nullable: true),
					TamanyoCodigoBarras = table.Column<int>(nullable: true),
					TipoCodigoBarras = table.Column<int>(nullable: true),
					FuenteCodigoBarras = table.Column<string>(maxLength: 50, nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					MarcaCampo = table.Column<string>(maxLength: 50, nullable: true),
					MarcaPedirArchivo = table.Column<string>(maxLength: 20, nullable: true),
					Sesion = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Etiquetas", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Eventos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Tabla = table.Column<string>(maxLength: 50, nullable: true),
					Campo = table.Column<string>(maxLength: 50, nullable: true),
					Elemento = table.Column<int>(nullable: true),
					Accion = table.Column<string>(maxLength: 50, nullable: true),
					Usuario = table.Column<int>(nullable: true),
					IP = table.Column<string>(maxLength: 39, nullable: true),
					MAC = table.Column<string>(maxLength: 12, nullable: true),
					Equipo = table.Column<string>(maxLength: 50, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Formulario = table.Column<string>(nullable: true),
					Observaciones = table.Column<string>(maxLength: 1000, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Eventos", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "FamiliasMedidor",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_FamiliasMedidor", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Files",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Bytes = table.Column<byte[]>(nullable: false),
					MimeType = table.Column<string>(maxLength: 64, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Files", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Formatos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Descripcion = table.Column<string>(maxLength: 50, nullable: true),
					ControlStock = table.Column<bool>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					idOld = table.Column<int>(nullable: true),
					RefERP = table.Column<string>(maxLength: 20, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Formatos", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_Archivos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Descripcion = table.Column<string>(nullable: true),
					Tipo = table.Column<int>(nullable: true),
					NombreArchivoOriginal = table.Column<string>(maxLength: 50, nullable: true),
					FechaSubida = table.Column<DateTime>(type: "datetime", nullable: true),
					UltimaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
					IdUsuario = table.Column<int>(nullable: true),
					CMMSFileId = table.Column<Guid>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_Archivos", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_Caracteristicas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 64, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_Caracteristicas", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_Marcas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 64, nullable: false),
					Observaciones = table.Column<string>(maxLength: 1024, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_Marcas", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_Operarios",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 64, nullable: false),
					Apellidos = table.Column<string>(maxLength: 50, nullable: true),
					DNI = table.Column<string>(maxLength: 50, nullable: true),
					Autorizado = table.Column<bool>(nullable: true),
					Telefono = table.Column<string>(maxLength: 50, nullable: true),
					Telefono2 = table.Column<string>(maxLength: 50, nullable: true),
					Email = table.Column<string>(maxLength: 50, nullable: true),
					Externo = table.Column<bool>(nullable: true),
					Login = table.Column<string>(maxLength: 50, nullable: true),
					Pass = table.Column<string>(maxLength: 50, nullable: true),
					CosteDietas = table.Column<decimal>(type: "decimal(12, 3)", nullable: true),
					CosteHora = table.Column<decimal>(type: "decimal(12, 3)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_Operarios", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_ParadasConfiguracion",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 64, nullable: false),
					Descripcion = table.Column<string>(maxLength: 1024, nullable: true),
					Observaciones = table.Column<string>(maxLength: 1024, nullable: true),
					HoraInicio = table.Column<TimeSpan>(nullable: false),
					DayOfMonth = table.Column<long>(nullable: true),
					DayOfWeek = table.Column<byte>(nullable: true),
					Month = table.Column<int>(nullable: true),
					Scheduling = table.Column<byte>(nullable: false),
					WeeklyRepeat = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_ParadasConfiguracion", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_Proveedores",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Ref = table.Column<string>(maxLength: 50, nullable: true),
					Nombre = table.Column<string>(maxLength: 64, nullable: false),
					MesesGarantia = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_Proveedores", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_Warehouses",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
					Name = table.Column<string>(maxLength: 128, nullable: false),
					Reference = table.Column<string>(maxLength: 128, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_Warehouses", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "GruposIncompatibilidades",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Descripcion = table.Column<string>(maxLength: 250, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GruposIncompatibilidades", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "InformesLibCategorias",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: false),
					isModificable = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
					isVisible = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_InformesLibCategorias", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Inventarios",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Estado = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Inventarios", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Lectores",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Tipo = table.Column<int>(nullable: true),
					Receptor = table.Column<int>(nullable: true),
					Inhalambrico = table.Column<bool>(nullable: true),
					Terminal = table.Column<bool>(nullable: true),
					Multipuesto = table.Column<bool>(nullable: true),
					Nodo = table.Column<int>(nullable: true),
					Plc = table.Column<string>(maxLength: 20, nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Lectores", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "MotoresGrupos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_MotoresGrupos", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "NetAlarmasRespuestas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdPlc = table.Column<int>(nullable: true),
					Texto = table.Column<string>(maxLength: 250, nullable: true),
					SeleccionUbicacion = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SeleccionProducto = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SeleccionLote = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SeleccUbicacionDestino = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SeleccArgumento0 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SeleccArgumento1 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SeleccArgumento2 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SeleccArgumento3 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SeleccVariables0 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SeleccVariables1 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SeleccVariables2 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SeleccVariables3 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SeleccVariables4 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SeleccTextoAdicional = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					txtTextoAdicional = table.Column<string>(maxLength: 250, nullable: true, defaultValueSql: "('')"),
					txtArgumento0 = table.Column<string>(maxLength: 250, nullable: true, defaultValueSql: "('')"),
					txtArgumento1 = table.Column<string>(maxLength: 250, nullable: true, defaultValueSql: "('')"),
					txtArgumento2 = table.Column<string>(maxLength: 250, nullable: true, defaultValueSql: "('')"),
					txtArgumento3 = table.Column<string>(maxLength: 250, nullable: true, defaultValueSql: "('')"),
					txtVariables0 = table.Column<string>(maxLength: 250, nullable: true, defaultValueSql: "('')"),
					txtVariables1 = table.Column<string>(maxLength: 250, nullable: true, defaultValueSql: "('')"),
					txtVariables2 = table.Column<string>(maxLength: 250, nullable: true, defaultValueSql: "('')"),
					txtVariables3 = table.Column<string>(maxLength: 250, nullable: true, defaultValueSql: "('')"),
					txtVariables4 = table.Column<string>(maxLength: 250, nullable: true, defaultValueSql: "('')"),
					DecimalesArgumentos = table.Column<int>(nullable: true),
					CopiarAdicional5AVar0 = table.Column<bool>(nullable: true),
					CopiarAdicional5AVar1 = table.Column<bool>(nullable: true),
					CopiarAdicional5AVar2 = table.Column<bool>(nullable: true),
					CopiarAdicional5AVar3 = table.Column<bool>(nullable: true),
					CopiarAdicional5AVar4 = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_NetAlarmasRespuestas", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "Opciones",
				columns: table => new
				{
					Clave = table.Column<string>(maxLength: 50, nullable: false),
					Valor = table.Column<string>(maxLength: 250, nullable: true),
					Comentario = table.Column<string>(maxLength: 1024, nullable: true),
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Opciones", x => x.Clave);
				});

			migrationBuilder.CreateTable(
				name: "OperAcciones",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdPlc = table.Column<int>(nullable: true),
					Nombre = table.Column<string>(maxLength: 250, nullable: true),
					RequiereTiempo = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OperAcciones", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Paises",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					CodigoUE = table.Column<int>(nullable: true),
					Nacionalidad = table.Column<string>(maxLength: 50, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Prefijo = table.Column<string>(maxLength: 5, nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					idOld = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Paises", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Pivots",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					IdPivot = table.Column<int>(nullable: true),
					DatosInforme = table.Column<byte[]>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Pivots", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Printers",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(maxLength: 64, nullable: false),
					Type = table.Column<byte>(nullable: false),
					Url = table.Column<string>(maxLength: 64, nullable: true),
					WindowsName = table.Column<string>(maxLength: 64, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Printers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Puntos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					DireccionPlc = table.Column<string>(maxLength: 50, nullable: true),
					Digitos = table.Column<int>(nullable: true),
					Decimales = table.Column<int>(nullable: true),
					ColorInicial = table.Column<int>(nullable: true),
					ColorFinal = table.Column<int>(nullable: true),
					ColorDigitos = table.Column<int>(nullable: true),
					ColorSombra = table.Column<int>(nullable: true),
					ColorFondo = table.Column<int>(nullable: true),
					ColorTitulo = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Puntos", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Series",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					ContadorOrdenes = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
					Estado = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: false),
					Exportado = table.Column<bool>(nullable: false),
					ContadorCompras = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
					ContadorVentas = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
					ContadorViajes = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
					ContadorRecetas = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
					ContadorAlbaranes = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
					ContadorCertificadoDesinfeccion = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
					ContadorSalidas = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
					ContadorEntradas = table.Column<int>(nullable: false, defaultValueSql: "((0))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Series", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "ServerConfigs",
				columns: table => new
				{
					Campo = table.Column<string>(maxLength: 50, nullable: false),
					Valor = table.Column<string>(maxLength: 250, nullable: false),
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ServerConfigs", x => x.Campo);
				});

			migrationBuilder.CreateTable(
				name: "Sesiones",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Equipo = table.Column<string>(maxLength: 50, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Cuenta = table.Column<string>(maxLength: 50, nullable: true),
					Grupo = table.Column<int>(nullable: true),
					Licencias = table.Column<int>(nullable: true),
					Automatica = table.Column<bool>(nullable: true),
					UsuarioDefecto = table.Column<string>(maxLength: 50, nullable: true),
					Servidor = table.Column<bool>(nullable: true),
					Opc = table.Column<bool>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					IP = table.Column<string>(maxLength: 50, nullable: true),
					VersionApp = table.Column<string>(maxLength: 10, nullable: true),
					TransitoManual = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Sesiones", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "StatusDisks",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					pc = table.Column<string>(maxLength: 50, nullable: true),
					DeviceId = table.Column<string>(maxLength: 250, nullable: true),
					Model = table.Column<string>(maxLength: 250, nullable: true),
					Status = table.Column<string>(maxLength: 50, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					RamLibre = table.Column<int>(nullable: true),
					CPU = table.Column<decimal>(type: "numeric(8, 3)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_StatusDisks", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "TempControles",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idPLC = table.Column<int>(nullable: true),
					ModoDefecto = table.Column<int>(nullable: true),
					MinAlarma_Min = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					MinAlarma_Max = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					MaxAlarma_Min = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					MaxAlarma_Max = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					Consigna_Min = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					Consigna_Max = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					Histeresys_Min = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					Histeresys_Max = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					ConsignaPausa_Min = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					ConsignaPausa_Max = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					ZonaMuerta_Min = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					ZonaMuerta_Max = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					ModoCalentar = table.Column<bool>(nullable: true),
					ModoEnfriar = table.Column<bool>(nullable: true),
					ModoCalentarYEnfriar = table.Column<bool>(nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TempControles", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "Tenants",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(maxLength: 64, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Tenants", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "TextosParametros",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Grupo = table.Column<string>(maxLength: 50, nullable: false),
					Parametro = table.Column<string>(maxLength: 50, nullable: false),
					IdTexto = table.Column<int>(nullable: false),
					Texto = table.Column<string>(maxLength: 50, nullable: false),
					Idioma = table.Column<int>(nullable: true),
					NombreEnum = table.Column<string>(maxLength: 50, nullable: true),
					TextoEnum = table.Column<string>(maxLength: 50, nullable: true),
					Comentarios = table.Column<string>(maxLength: 250, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TextosParametros", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "TiposIva",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Porcentaje = table.Column<float>(nullable: true),
					Principal = table.Column<bool>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TiposIva", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Unidades",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Singular = table.Column<string>(maxLength: 50, nullable: true),
					Medicion = table.Column<string>(maxLength: 50, nullable: true),
					Relacion = table.Column<float>(nullable: true),
					Principal = table.Column<bool>(nullable: true),
					Tipo = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Monetaria = table.Column<bool>(nullable: true),
					Conversion = table.Column<decimal>(type: "decimal(12, 3)", nullable: true),
					FiltroCantidad = table.Column<bool>(nullable: true),
					RefERP = table.Column<string>(maxLength: 20, nullable: true),
					idOld = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Unidades", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "UsuariosRoles",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Descripcion = table.Column<string>(maxLength: 250, nullable: true),
					UbicacionesVer = table.Column<bool>(nullable: true),
					UbicacionesEditar = table.Column<bool>(nullable: true),
					ProductosVer = table.Column<bool>(nullable: true),
					ProductosEditar = table.Column<bool>(nullable: true),
					Configuracion = table.Column<bool>(nullable: true),
					Usuarios = table.Column<bool>(nullable: true),
					EntradasVer = table.Column<bool>(nullable: true),
					EntradasEditar = table.Column<bool>(nullable: true),
					SalidasVer = table.Column<bool>(nullable: true),
					SalidasEditar = table.Column<bool>(nullable: true),
					VerTodasAlarmas = table.Column<bool>(nullable: true),
					ResponderTodasAlarmas = table.Column<bool>(nullable: true),
					VerTodosModulos = table.Column<bool>(nullable: true),
					EditarTodosModulos = table.Column<bool>(nullable: true),
					Formulacion = table.Column<bool>(nullable: true),
					Maestros = table.Column<bool>(nullable: true),
					InformesVer = table.Column<bool>(nullable: true),
					InformesEditar = table.Column<bool>(nullable: true),
					ConfigUbicaciones = table.Column<bool>(nullable: true),
					ContratosVer = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					ContratosEditar = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					Quimica = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					Produccion = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					OrdenesAConfirmarVer = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					OrdenesAConfirmarEditar = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					OrdenesVer = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					OrdenesEditar = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					ERP = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					Copias = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					Utilidades = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					Comunicaciones = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					Transito = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					LotesVer = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					LotesEditar = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					StocksVer = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					StocksEditar = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					Laboratorio = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					DashboardVer = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					Premezclas = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					PlantillasVer = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					PlantillasEditar = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					Productividad = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					Inventarios = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					Incompatibilidades = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					Tarjetas = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					DesinfeccionVer = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					DesinfeccionEditar = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					MedicamentosVer = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					MedicamentosEditar = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					StocksPestana = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					Gestion = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					ComprasVer = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					ComprasEditar = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					VentasVer = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					VentasEditar = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					GMAO = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					ModuloEnergia = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					ModuloOEE = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					VisorDosificacionesVer = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					AutoRespuestasVer = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					EntradasAlmacenVer = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					EntradasAlmacenEditar = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SalidasViajesVer = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					SalidasViajesEditar = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					RecetasVer = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					RecetasEditar = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PRECabOrdenesProduccion = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PRECabOrdenesSalidasViajes = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					TrazabilidadResumenVer = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					CambioRapidoOPC = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SMTP = table.Column<bool>(nullable: true),
					Alertas = table.Column<bool>(nullable: true),
					ResetComunicaciones = table.Column<bool>(nullable: true),
					DashboardEditar = table.Column<bool>(nullable: true),
					LayoutMaximizar = table.Column<bool>(nullable: true),
					ForzarPopupAlarmas = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UsuariosRoles", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Medicaciones",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Fecha = table.Column<DateTime>(nullable: true),
					Frecuencia = table.Column<int>(nullable: true),
					Duracion = table.Column<int>(nullable: true),
					TiempoEspera = table.Column<int>(nullable: true),
					Conservacion = table.Column<int>(nullable: true),
					Total = table.Column<int>(nullable: true),
					Afeccion = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Observaciones = table.Column<string>(maxLength: 254, nullable: true),
					Indicaciones = table.Column<string>(maxLength: 254, nullable: true),
					NaturalezaTratamiento = table.Column<string>(maxLength: 254, nullable: true),
					Literal = table.Column<string>(maxLength: 50, nullable: true),
					TiempoEsperaLeche = table.Column<int>(nullable: true),
					TiempoEsperaHuevos = table.Column<int>(nullable: true),
					StockIngredientes = table.Column<bool>(nullable: true),
					Edad = table.Column<string>(maxLength: 120, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Medicaciones", x => x.Id);
					table.ForeignKey(
						name: "FK_Medicaciones_Afecciones",
						column: x => x.Afeccion,
						principalTable: "Afecciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "AlertasUsuarios",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ReceptorNombre = table.Column<string>(maxLength: 50, nullable: true),
					Activo = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					smtpReceptor = table.Column<string>(maxLength: 50, nullable: true),
					smtpAsunto = table.Column<string>(maxLength: 50, nullable: true),
					smtpMensaje = table.Column<string>(nullable: true),
					smtpIsBodyHtml = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					idServerSmtp = table.Column<int>(nullable: true),
					SMSReceptor = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AlertasUsuarios", x => x.id);
					table.ForeignKey(
						name: "FK_AlertasUsuarios_AlertasSmtpConfigs",
						column: x => x.idServerSmtp,
						principalTable: "AlertasSmtpConfigs",
						principalColumn: "id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "AuditTables",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					AuditId = table.Column<int>(nullable: false),
					Table = table.Column<string>(maxLength: 128, nullable: false),
					State = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AuditTables", x => x.Id);
					table.ForeignKey(
						name: "FK_AuditTables_Audits_AuditId",
						column: x => x.AuditId,
						principalTable: "Audits",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPLinOrdenes",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					NombreOrden = table.Column<string>(maxLength: 50, nullable: true),
					NumLinea = table.Column<int>(nullable: true),
					RefProducto = table.Column<string>(maxLength: 50, nullable: true),
					LoteProducto = table.Column<string>(maxLength: 50, nullable: true),
					CaducidadLoteProducto = table.Column<DateTime>(type: "date", nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Tipo = table.Column<int>(nullable: true),
					CantidadTotal = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Tratado = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					idCaborden = table.Column<int>(nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPLinOrdenes", x => x.id);
					table.ForeignKey(
						name: "FK_BufferERPLinOrdenes_BufferERPCabOrdenes",
						column: x => x.idCaborden,
						principalTable: "BufferERPCabOrdenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPClientesDomicilios",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					idCliente = table.Column<int>(nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					Direccion = table.Column<string>(maxLength: 50, nullable: true),
					Poblacion = table.Column<string>(maxLength: 50, nullable: true),
					Telefono = table.Column<string>(maxLength: 20, nullable: true),
					CodigoPostal = table.Column<string>(maxLength: 5, nullable: true),
					Provincia = table.Column<string>(maxLength: 50, nullable: true),
					Pais = table.Column<string>(maxLength: 50, nullable: true),
					MarcaOficial = table.Column<string>(maxLength: 50, nullable: true),
					Responsable = table.Column<string>(maxLength: 50, nullable: true),
					Especie = table.Column<string>(maxLength: 50, nullable: true),
					NumeroEspecies = table.Column<int>(nullable: true),
					Inhabilitado = table.Column<bool>(nullable: true),
					Descripcion = table.Column<string>(maxLength: 50, nullable: true),
					Simogan = table.Column<string>(maxLength: 20, nullable: true),
					REGA = table.Column<string>(maxLength: 20, nullable: true),
					LoteAnimalActual = table.Column<string>(maxLength: 20, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					RefCliente = table.Column<string>(maxLength: 20, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPClientesDomicilios", x => x.id);
					table.ForeignKey(
						name: "FK_BufferERPClientesDomicilios_BufferERPClientes",
						column: x => x.idCliente,
						principalTable: "BufferERPClientes",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPComprasLineas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Serie = table.Column<int>(nullable: true),
					CompraId = table.Column<int>(nullable: true),
					CompraRef = table.Column<string>(maxLength: 20, nullable: true),
					Linea = table.Column<int>(nullable: false),
					ProductoId = table.Column<int>(nullable: true),
					ProductoRef = table.Column<string>(maxLength: 20, nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Departamento = table.Column<int>(nullable: true),
					LoteId = table.Column<int>(nullable: true),
					LoteRef = table.Column<string>(maxLength: 20, nullable: true),
					Bultos = table.Column<int>(nullable: true),
					EnvaseId = table.Column<int>(nullable: true),
					EnvaseRef = table.Column<string>(maxLength: 20, nullable: true),
					UnidadId = table.Column<int>(nullable: true),
					UnidadRef = table.Column<string>(maxLength: 20, nullable: true),
					ContratoId = table.Column<int>(nullable: true),
					ContratoRef = table.Column<string>(maxLength: 20, nullable: true),
					Comentario = table.Column<string>(maxLength: 100, nullable: true),
					PrecioCompra = table.Column<float>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					FormatoId = table.Column<int>(nullable: true),
					FormatoRef = table.Column<string>(maxLength: 20, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPComprasLineas", x => x.Id);
					table.ForeignKey(
						name: "FK_BufferERPComprasLineas_BufferERPCompras",
						column: x => x.CompraId,
						principalTable: "BufferERPCompras",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPEntradasLineas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					idBufferEntrada = table.Column<int>(nullable: true),
					idProducto = table.Column<int>(nullable: true),
					CantidadPedida = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					Cajon1 = table.Column<bool>(nullable: true),
					Cajon2 = table.Column<bool>(nullable: true),
					Cajon3 = table.Column<bool>(nullable: true),
					Cajon4 = table.Column<bool>(nullable: true),
					Cajon5 = table.Column<bool>(nullable: true),
					Cajon6 = table.Column<bool>(nullable: true),
					Cajon7 = table.Column<bool>(nullable: true),
					Cajon8 = table.Column<bool>(nullable: true),
					Cajon9 = table.Column<bool>(nullable: true),
					Cajon10 = table.Column<bool>(nullable: true),
					FueraCajon = table.Column<bool>(nullable: true),
					RefProveedor = table.Column<string>(maxLength: 50, nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Destino1 = table.Column<int>(nullable: true),
					Destino2 = table.Column<int>(nullable: true),
					Destino3 = table.Column<int>(nullable: true),
					Destino4 = table.Column<int>(nullable: true),
					Formato = table.Column<int>(nullable: true),
					Envase = table.Column<int>(nullable: true),
					Bultos = table.Column<int>(nullable: true),
					Observaciones = table.Column<string>(maxLength: 250, nullable: true),
					Precio = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PagarKgTeoricos = table.Column<bool>(nullable: true),
					CampoLibre1 = table.Column<string>(maxLength: 50, nullable: true),
					CampoLIbre2 = table.Column<string>(maxLength: 50, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					idModulo = table.Column<int>(nullable: true),
					LoteRef = table.Column<string>(maxLength: 50, nullable: true),
					LoteNombre = table.Column<string>(maxLength: 50, nullable: true),
					LoteFecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Caducidad = table.Column<DateTime>(type: "datetime", nullable: true),
					RefERPUnidades = table.Column<string>(maxLength: 20, nullable: true),
					RefERPFormatos = table.Column<string>(maxLength: 20, nullable: true),
					RefERPEnvases = table.Column<string>(maxLength: 20, nullable: true),
					isExport = table.Column<bool>(nullable: true),
					PesoTara = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PesoBruto = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PesoNeto = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Ref2Producto = table.Column<string>(maxLength: 50, nullable: true),
					idEntradaMes = table.Column<int>(nullable: true),
					idLiniaMes = table.Column<int>(nullable: true),
					RefProducto = table.Column<string>(maxLength: 50, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					Destino1Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Destino2Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Destino3Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Destino4Nombre = table.Column<string>(maxLength: 50, nullable: true),
					idSerie = table.Column<int>(nullable: true),
					NombreSerie = table.Column<string>(maxLength: 20, nullable: true),
					RefEntrada = table.Column<string>(maxLength: 20, nullable: true),
					NumLinea = table.Column<int>(nullable: true),
					RefCompra = table.Column<string>(maxLength: 20, nullable: true),
					NumLineaCompra = table.Column<int>(nullable: true),
					NetoOrigen = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					NumeroEntrada = table.Column<int>(nullable: true),
					idLote = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPEntradasLineas", x => x.id);
					table.ForeignKey(
						name: "FK_BufferERPEntradasLineas_BufferERPEntradas",
						column: x => x.idBufferEntrada,
						principalTable: "BufferERPEntradas",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPFormulaProductosFinales",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					idFormula = table.Column<int>(nullable: true),
					idProducto = table.Column<int>(nullable: true),
					RefProducto = table.Column<string>(maxLength: 50, nullable: true),
					Principal = table.Column<bool>(nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					RefFormula = table.Column<string>(maxLength: 20, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPFormulaProductosFinales", x => x.id);
					table.ForeignKey(
						name: "FK_BufferERPFormulaProductosFinales_BufferERPFormulas",
						column: x => x.idFormula,
						principalTable: "BufferERPFormulas",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPVersiones",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					idFormula = table.Column<int>(nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Estado = table.Column<int>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 5)", nullable: true),
					LimitePesoCiclo = table.Column<decimal>(type: "numeric(18, 5)", nullable: true),
					LimpiezaPosteriorObligada = table.Column<bool>(nullable: true),
					RefERPUnidades = table.Column<string>(maxLength: 20, nullable: true),
					IdERPVersion = table.Column<int>(nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					RefFormula = table.Column<string>(maxLength: 20, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPVersiones", x => x.id);
					table.ForeignKey(
						name: "FK_BufferERPVersiones_BufferERPFormulas",
						column: x => x.idFormula,
						principalTable: "BufferERPFormulas",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPSalidasLinias",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					idSalidas = table.Column<int>(nullable: true),
					RefProducto = table.Column<string>(maxLength: 50, nullable: true),
					idFormato = table.Column<int>(nullable: true),
					RefEnvase = table.Column<string>(maxLength: 50, nullable: true),
					idUnidad = table.Column<int>(nullable: true),
					RefDomicilio = table.Column<string>(maxLength: 50, nullable: true),
					Origen1 = table.Column<int>(nullable: true),
					Origen2 = table.Column<int>(nullable: true),
					Origen3 = table.Column<int>(nullable: true),
					Origen4 = table.Column<int>(nullable: true),
					FueraCajon = table.Column<bool>(nullable: true),
					Cajon1 = table.Column<bool>(nullable: true),
					Cajon2 = table.Column<bool>(nullable: true),
					Cajon3 = table.Column<bool>(nullable: true),
					Cajon4 = table.Column<bool>(nullable: true),
					Cajon5 = table.Column<bool>(nullable: true),
					Cajon6 = table.Column<bool>(nullable: true),
					Cajon7 = table.Column<bool>(nullable: true),
					Cajon8 = table.Column<bool>(nullable: true),
					Cajon9 = table.Column<bool>(nullable: true),
					Cajon10 = table.Column<bool>(nullable: true),
					Bultos = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Bruto = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Tara = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PrecioUnidad = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					idviajes = table.Column<int>(nullable: true),
					idmodulo = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Precio = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					PrecioTransporte = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					Observaciones = table.Column<string>(maxLength: 250, nullable: true),
					RefERPUnidades = table.Column<string>(maxLength: 20, nullable: true),
					RefERPFormatos = table.Column<string>(maxLength: 20, nullable: true),
					RefERPEnvases = table.Column<string>(maxLength: 20, nullable: true),
					Origen1Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Origen2Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Origen3Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Origen4Nombre = table.Column<string>(maxLength: 50, nullable: true),
					idViajeMES = table.Column<int>(nullable: true),
					RefPedidoERP = table.Column<string>(maxLength: 20, nullable: true),
					ModuloNombre = table.Column<string>(maxLength: 50, nullable: true),
					RefPuntoDescarga = table.Column<string>(maxLength: 20, nullable: true),
					idSalidaMes = table.Column<int>(nullable: true),
					idLiniaMes = table.Column<int>(nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					idSerie = table.Column<int>(nullable: true),
					NombreSerie = table.Column<string>(maxLength: 20, nullable: true),
					RefVenta = table.Column<string>(maxLength: 20, nullable: true),
					NumLineaVenta = table.Column<int>(nullable: true),
					Neto = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					idDomicilio = table.Column<int>(nullable: true),
					NombreDomicilio = table.Column<string>(maxLength: 50, nullable: true),
					NumLineaViaje = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPSalidasLinias", x => x.id);
					table.ForeignKey(
						name: "FK_BufferERPSalidasLinias_BufferERPSalidas",
						column: x => x.idSalidas,
						principalTable: "BufferERPSalidas",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_BufferERPSalidasLinias_BufferERPSalidasViajes",
						column: x => x.idviajes,
						principalTable: "BufferERPSalidasViajes",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPVentasLineas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Serie = table.Column<int>(nullable: true),
					RevVenta = table.Column<string>(maxLength: 50, nullable: true),
					RefProducto = table.Column<string>(maxLength: 50, nullable: true),
					RefFormato = table.Column<string>(maxLength: 50, nullable: true),
					RefEnvase = table.Column<string>(maxLength: 50, nullable: true),
					Bultos = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					RefUnidad = table.Column<string>(maxLength: 50, nullable: true),
					RefDomicilio = table.Column<string>(maxLength: 50, nullable: true),
					PrecioUnidad = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					linea = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Observaciones = table.Column<string>(maxLength: 250, nullable: true),
					RefPuntoDescarga = table.Column<string>(maxLength: 50, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					BufferErpVentaId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPVentasLineas", x => x.id);
					table.ForeignKey(
						name: "FK_BufferERPVentasLineas_BufferERPVentas_BufferErpVentaId",
						column: x => x.BufferErpVentaId,
						principalTable: "BufferERPVentas",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "DashboardsLib",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					NombreDashboard = table.Column<string>(maxLength: 50, nullable: true),
					IdCategoria = table.Column<int>(nullable: true),
					IsBase = table.Column<bool>(nullable: false),
					IdDashboardBase = table.Column<int>(nullable: true),
					Visible = table.Column<bool>(nullable: false),
					FechaUltima = table.Column<DateTime>(type: "datetime", nullable: true),
					UltimoEditor = table.Column<string>(maxLength: 50, nullable: true),
					DatosDashboard = table.Column<byte[]>(nullable: true),
					Vista = table.Column<string>(maxLength: 50, nullable: true),
					VistaXML = table.Column<byte[]>(nullable: true),
					ImpresoraDefecto = table.Column<string>(maxLength: 50, nullable: true),
					ImpAutomatico = table.Column<bool>(nullable: true),
					NumCopias = table.Column<int>(nullable: true),
					VisibleUsuario = table.Column<bool>(nullable: true, defaultValueSql: "((1))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_DashboardsLib", x => x.Id);
					table.ForeignKey(
						name: "FK_DashboardsLib_DashboardsLibCategorias",
						column: x => x.IdCategoria,
						principalTable: "DashboardsLibCategorias",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_DashboardsLib_DashboardsLib",
						column: x => x.IdDashboardBase,
						principalTable: "DashboardsLib",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "EnlaceERP",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					idEnlaceERPTipo = table.Column<int>(nullable: true),
					FormatoFichero = table.Column<int>(nullable: true),
					TamFijo = table.Column<bool>(nullable: true),
					Separador = table.Column<int>(nullable: true),
					SeparadorDecimal = table.Column<int>(nullable: true),
					SeparadorPersonalizado = table.Column<string>(maxLength: 10, nullable: true),
					NombreTablaXML = table.Column<string>(maxLength: 50, nullable: true),
					Automatico = table.Column<bool>(nullable: true),
					Carpeta = table.Column<string>(maxLength: 250, nullable: true),
					NombreFichero = table.Column<string>(maxLength: 50, nullable: true),
					CualquierFichero = table.Column<bool>(nullable: true),
					DependienteDe = table.Column<int>(nullable: true),
					NombreFicheroDepIgual = table.Column<bool>(nullable: true),
					NombreFicheroDepPre = table.Column<string>(maxLength: 50, nullable: true),
					NombreFicheroDepPost = table.Column<string>(maxLength: 50, nullable: true),
					EjecutarDependientePrimero = table.Column<bool>(nullable: true),
					FicheroEmpiezaPor = table.Column<bool>(nullable: true),
					IgnorarCabecera = table.Column<bool>(nullable: true),
					Manual = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Activo = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					ImportarMP = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					EliminarFichero = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					DependenciaEstricta = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					NumDecimales = table.Column<int>(nullable: true, defaultValueSql: "((3))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EnlaceERP", x => x.id);
					table.ForeignKey(
						name: "FK_EnlaceERP_EnlaceERPTipo",
						column: x => x.idEnlaceERPTipo,
						principalTable: "EnlaceERPTipo",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "EnlaceERPTipoLinea",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idEnlaceERPTipo = table.Column<int>(nullable: true),
					CampoBuffer = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EnlaceERPTipoLinea", x => x.id);
					table.ForeignKey(
						name: "FK_EnlaceERPTipoLinea_EnlaceERPTipo",
						column: x => x.idEnlaceERPTipo,
						principalTable: "EnlaceERPTipo",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "EventosDetalle",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Evento = table.Column<int>(nullable: false),
					Campo = table.Column<string>(maxLength: 50, nullable: true),
					ValorAntiguo = table.Column<string>(maxLength: 200, nullable: true),
					ValorNuevo = table.Column<string>(maxLength: 200, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EventosDetalle", x => x.Id);
					table.ForeignKey(
						name: "FK_EventosDetalle_Eventos",
						column: x => x.Evento,
						principalTable: "Eventos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_MarcasModelos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idMarca = table.Column<int>(nullable: false),
					Nombre = table.Column<string>(maxLength: 64, nullable: false),
					EAN13 = table.Column<string>(maxLength: 13, nullable: true),
					Descripcion = table.Column<string>(maxLength: 1024, nullable: true),
					Observaciones = table.Column<string>(maxLength: 1024, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_MarcasModelos", x => x.id);
					table.ForeignKey(
						name: "FK_GMAO_MarcasModelos_GMAO_Marcas",
						column: x => x.idMarca,
						principalTable: "GMAO_Marcas",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_Departamentos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 64, nullable: false),
					Descripcion = table.Column<string>(maxLength: 250, nullable: true),
					IdResponsable = table.Column<int>(nullable: true),
					Externo = table.Column<bool>(nullable: true),
					Telefono = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_Departamentos", x => x.id);
					table.ForeignKey(
						name: "FK_GMAO_Departamentos_GMAO_Operarios",
						column: x => x.IdResponsable,
						principalTable: "GMAO_Operarios",
						principalColumn: "id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_Compras",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FechaPedido = table.Column<DateTime>(nullable: false),
					RefPedido = table.Column<string>(maxLength: 64, nullable: false),
					IdProveedor = table.Column<int>(nullable: false),
					FechaRecepcionPrevista = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaRecepcion = table.Column<DateTime>(type: "datetime", nullable: true),
					Estado = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_Compras", x => x.id);
					table.ForeignKey(
						name: "FK_GMAO_Compras_GMAO_Proveedores",
						column: x => x.IdProveedor,
						principalTable: "GMAO_Proveedores",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_ElementosTipos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 250, nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					Descripcion = table.Column<string>(nullable: true),
					Observaciones = table.Column<string>(nullable: true),
					ProveedorHabitual = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_ElementosTipos", x => x.id);
					table.ForeignKey(
						name: "FK_GMAO_ElementosTipos_GMAO_Proveedores",
						column: x => x.ProveedorHabitual,
						principalTable: "GMAO_Proveedores",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Provincias",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Pais = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					idOld = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Provincias", x => x.Id);
					table.ForeignKey(
						name: "FK_Provincias_Paises",
						column: x => x.Pais,
						principalTable: "Paises",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "InformesLib",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					NombreInforme = table.Column<string>(maxLength: 50, nullable: true),
					IdCategoria = table.Column<int>(nullable: true),
					IsBase = table.Column<bool>(nullable: false),
					IdInformeBase = table.Column<int>(nullable: true),
					Visible = table.Column<bool>(nullable: false),
					FechaUltima = table.Column<DateTime>(type: "datetime", nullable: true),
					UltimoEditor = table.Column<string>(maxLength: 50, nullable: true),
					DatosInforme = table.Column<byte[]>(nullable: true),
					Vista = table.Column<string>(maxLength: 50, nullable: true),
					VistaXML = table.Column<byte[]>(nullable: true),
					ImpresoraDefecto = table.Column<string>(maxLength: 50, nullable: true),
					ImpAutomatico = table.Column<bool>(nullable: true),
					NumCopias = table.Column<int>(nullable: true),
					VisibleUsuario = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					CopiaPara = table.Column<string>(maxLength: 250, nullable: true),
					DefaultPrinterId = table.Column<Guid>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_InformesLib", x => x.Id);
					table.ForeignKey(
						name: "FK_InformesLib_Printers_DefaultPrinterId",
						column: x => x.DefaultPrinterId,
						principalTable: "Printers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_InformesLib_InformesLibCategorias",
						column: x => x.IdCategoria,
						principalTable: "InformesLibCategorias",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_InformesLib_InformesLib",
						column: x => x.IdInformeBase,
						principalTable: "InformesLib",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "PrintJobs",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					PrinterId = table.Column<Guid>(nullable: false),
					Status = table.Column<byte>(nullable: false),
					Timestamp = table.Column<DateTimeOffset>(nullable: false),
					Copies = table.Column<int>(nullable: false),
					Content = table.Column<byte[]>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PrintJobs", x => x.Id);
					table.ForeignKey(
						name: "FK_PrintJobs_Printers_PrinterId",
						column: x => x.PrinterId,
						principalTable: "Printers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "SalidasAlbaranes",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Serie = table.Column<int>(nullable: true),
					Numero = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Auto = table.Column<bool>(nullable: true, defaultValueSql: "((1))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SalidasAlbaranes", x => x.id);
					table.ForeignKey(
						name: "FK_SalidasAlbaranes_Series",
						column: x => x.Serie,
						principalTable: "Series",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Maquinas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					TiempoPlc = table.Column<string>(maxLength: 50, nullable: true),
					HorasAlarma = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					FechaAccion = table.Column<DateTime>(type: "datetime", nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					ReiniciarPlc = table.Column<string>(maxLength: 50, nullable: true),
					Sesion = table.Column<int>(nullable: false),
					SesionNotificacion = table.Column<int>(nullable: true),
					Marca = table.Column<string>(maxLength: 256, nullable: true),
					Modelo = table.Column<string>(maxLength: 256, nullable: true),
					Observaciones = table.Column<string>(maxLength: 256, nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					Situacion = table.Column<string>(maxLength: 256, nullable: true),
					Proveedor = table.Column<string>(maxLength: 256, nullable: true),
					Telefono = table.Column<string>(maxLength: 10, nullable: true),
					Voltaje = table.Column<string>(maxLength: 10, nullable: true),
					Potencia = table.Column<string>(maxLength: 10, nullable: true),
					Amperaje = table.Column<string>(maxLength: 10, nullable: true),
					Rpm = table.Column<string>(maxLength: 10, nullable: true),
					Cos = table.Column<string>(maxLength: 10, nullable: true),
					Kilos = table.Column<string>(maxLength: 10, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Maquinas", x => x.Id);
					table.ForeignKey(
						name: "FK_Maquinas_Sesiones",
						column: x => x.Sesion,
						principalTable: "Sesiones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Maquinas_Sesiones1",
						column: x => x.SesionNotificacion,
						principalTable: "Sesiones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Gateways",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					TenantId = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(maxLength: 64, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Gateways", x => x.Id);
					table.ForeignKey(
						name: "FK_Gateways_Tenants_TenantId",
						column: x => x.TenantId,
						principalTable: "Tenants",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Envases",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Capacidad = table.Column<float>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Referencia2 = table.Column<string>(maxLength: 20, nullable: true),
					Producto = table.Column<int>(nullable: true),
					Rerefencia = table.Column<string>(maxLength: 20, nullable: true),
					Rerefencia2 = table.Column<string>(maxLength: 20, nullable: true),
					RefERP = table.Column<string>(maxLength: 20, nullable: true),
					ModoUdsFormato = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Envases", x => x.Id);
					table.ForeignKey(
						name: "FK_Envases_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "OpcionesRoles",
				columns: table => new
				{
					idClave = table.Column<string>(maxLength: 50, nullable: false),
					idRol = table.Column<int>(nullable: false),
					valor = table.Column<string>(maxLength: 250, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OpcionesRoles", x => new { x.idClave, x.idRol });
					table.ForeignKey(
						name: "FK_OpcionesRoles_Opciones",
						column: x => x.idClave,
						principalTable: "Opciones",
						principalColumn: "Clave",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OpcionesRoles_UsuariosRoles",
						column: x => x.idRol,
						principalTable: "UsuariosRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "UsuariosGruposLDAP",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					GrupoLDAP = table.Column<string>(maxLength: 100, nullable: true),
					idRol = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UsuariosGruposLDAP", x => x.id);
					table.ForeignKey(
						name: "FK_UsuariosGruposLDAP_UsuariosRoles",
						column: x => x.idRol,
						principalTable: "UsuariosRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "UsuariosRolesConfigForm",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UsuarioRol = table.Column<int>(nullable: false),
					Formulario = table.Column<string>(maxLength: 50, nullable: false),
					Control = table.Column<string>(maxLength: 50, nullable: false),
					Propiedad = table.Column<string>(maxLength: 50, nullable: false),
					Valor = table.Column<string>(maxLength: 500, nullable: true),
					Activo = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
					FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
					Tipo = table.Column<int>(nullable: false),
					Metodo = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UsuariosRolesConfigForm", x => x.Id);
					table.ForeignKey(
						name: "FK_UsuariosRolesConfigForm_UsuariosRoles",
						column: x => x.UsuarioRol,
						principalTable: "UsuariosRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "UsuariosRolesInformes",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idRol = table.Column<int>(nullable: true),
					idInforme = table.Column<int>(nullable: true),
					Ver = table.Column<bool>(nullable: true),
					Editar = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UsuariosRolesInformes", x => x.id);
					table.ForeignKey(
						name: "FK_UsuariosRolesInformes_UsuariosRoles",
						column: x => x.idRol,
						principalTable: "UsuariosRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "AlertasUsuariosInformes",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idAlertasUsuarios = table.Column<int>(nullable: true),
					idInforme = table.Column<int>(nullable: true),
					Asunto = table.Column<string>(maxLength: 50, nullable: true),
					Mensaje = table.Column<string>(nullable: true),
					TipoProgramacion = table.Column<int>(nullable: true),
					DiaSemana = table.Column<int>(nullable: true),
					DiaMes1 = table.Column<int>(nullable: true),
					DiaMes2 = table.Column<int>(nullable: true),
					HoraEntrega = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AlertasUsuariosInformes", x => x.id);
					table.ForeignKey(
						name: "FK_AlertasUsuariosInformes_AlertasUsuarios",
						column: x => x.idAlertasUsuarios,
						principalTable: "AlertasUsuarios",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AuditColumns",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					AuditTableId = table.Column<int>(nullable: false),
					Column = table.Column<string>(maxLength: 128, nullable: false),
					OldValue = table.Column<string>(maxLength: 256, nullable: true),
					NewValue = table.Column<string>(maxLength: 256, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AuditColumns", x => x.Id);
					table.ForeignKey(
						name: "FK_AuditColumns_AuditTables_AuditTableId",
						column: x => x.AuditTableId,
						principalTable: "AuditTables",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPClienteDomicilioPuntoDescarga",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idDomicilio = table.Column<int>(nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Descripcion = table.Column<string>(maxLength: 250, nullable: true),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPClienteDomicilioPuntoDescarga", x => x.id);
					table.ForeignKey(
						name: "FK_BufferERPClienteDomicilioPuntoDescarga_BufferERPClientesDomicilios",
						column: x => x.idDomicilio,
						principalTable: "BufferERPClientesDomicilios",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPEntradasLineasLote",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Timestamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					IdLineaEntrada = table.Column<int>(nullable: true),
					NumLineaEntrada = table.Column<int>(nullable: true),
					NumLoteLineaEntrada = table.Column<int>(nullable: true),
					LoteId = table.Column<int>(nullable: true),
					LoteRef = table.Column<string>(maxLength: 50, nullable: true),
					LoteNombre = table.Column<string>(maxLength: 50, nullable: true),
					LoteFecha = table.Column<DateTime>(type: "datetime", nullable: true),
					LoteFechaCaducidad = table.Column<DateTime>(type: "datetime", nullable: true),
					LoteProveedor = table.Column<string>(maxLength: 50, nullable: true),
					LoteProveedorFCad = table.Column<DateTime>(type: "datetime", nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					SerieId = table.Column<int>(nullable: true),
					SerieNombre = table.Column<string>(maxLength: 20, nullable: true),
					IdEntradaMes = table.Column<int>(nullable: true),
					IdEntradaLineaMes = table.Column<int>(nullable: true),
					IdProducto = table.Column<int>(nullable: true),
					ProductoNombre = table.Column<string>(maxLength: 50, nullable: true),
					ProductoReferencia = table.Column<string>(maxLength: 20, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPEntradasLineasLote", x => x.Id);
					table.ForeignKey(
						name: "FK_BufferERPEntradasLineasLote_BufferERPEntradasLineas",
						column: x => x.IdLineaEntrada,
						principalTable: "BufferERPEntradasLineas",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPComponentes",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					idVersion = table.Column<int>(nullable: true),
					IdProducto = table.Column<int>(nullable: true),
					RefProducto = table.Column<string>(maxLength: 50, nullable: true),
					Porcentaje = table.Column<float>(nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Tipo = table.Column<int>(nullable: true),
					Automatico = table.Column<bool>(nullable: true),
					TipoDosificacion = table.Column<int>(nullable: true),
					Modulo = table.Column<int>(nullable: true),
					Medidor = table.Column<int>(nullable: true),
					Orden = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					ToleranciaSuperior = table.Column<decimal>(type: "numeric(18, 2)", nullable: true),
					ToleranciaInferior = table.Column<decimal>(type: "numeric(18, 2)", nullable: true),
					PausaPosteriorDosificacion = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					DosificarProductoAnterior = table.Column<bool>(nullable: true),
					OperTiempo = table.Column<int>(nullable: true),
					OperMotor = table.Column<int>(nullable: true),
					OperAccion = table.Column<int>(nullable: true),
					OperVariable = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					TextoVariable = table.Column<string>(maxLength: 250, nullable: true),
					OperVariable2 = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					RefERPUnidades = table.Column<string>(maxLength: 20, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					RefVersion = table.Column<string>(maxLength: 20, nullable: true),
					RefFormula = table.Column<string>(maxLength: 20, nullable: true),
					AddVersionActiva = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPComponentes", x => x.id);
					table.ForeignKey(
						name: "FK_BufferERPComponentes_BufferERPVersiones",
						column: x => x.idVersion,
						principalTable: "BufferERPVersiones",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPSalidasLinMedicamentos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					idSalidasLinia = table.Column<int>(nullable: true),
					idMedicamento = table.Column<int>(nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Bultos = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					IdUnidad = table.Column<int>(nullable: true),
					idFormato = table.Column<int>(nullable: true),
					idEnvase = table.Column<int>(nullable: true),
					PrecioUnidad = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					RefERPUnidades = table.Column<string>(maxLength: 20, nullable: true),
					RefERPFormatos = table.Column<string>(maxLength: 20, nullable: true),
					RefERPEnvases = table.Column<string>(maxLength: 20, nullable: true),
					MedicamentoNombre = table.Column<string>(maxLength: 50, nullable: true),
					MedicamentoReferencia = table.Column<string>(maxLength: 50, nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPSalidasLinMedicamentos", x => x.id);
					table.ForeignKey(
						name: "FK_BufferERPSalidasLinMedicamentos_BufferERPSalidasLinias",
						column: x => x.idSalidasLinia,
						principalTable: "BufferERPSalidasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "EnlaceERPLinea",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idEnlaceERP = table.Column<int>(nullable: true),
					idEnlaceERPTipoLinea = table.Column<int>(nullable: true),
					PosicionEnFichero = table.Column<int>(nullable: true),
					TamFijo = table.Column<bool>(nullable: true),
					PosicionInicial = table.Column<int>(nullable: true),
					NumCaracteres = table.Column<int>(nullable: true),
					CampoXML = table.Column<string>(maxLength: 50, nullable: true),
					Activado = table.Column<bool>(nullable: true),
					ValorDefecto = table.Column<string>(maxLength: 50, nullable: true),
					ValorObligatorio = table.Column<string>(maxLength: 50, nullable: true),
					ValorExcluido = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EnlaceERPLinea", x => x.id);
					table.ForeignKey(
						name: "FK_EnlaceERPLinea_EnlaceERP",
						column: x => x.idEnlaceERP,
						principalTable: "EnlaceERP",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EnlaceERPLinea_EnlaceERPTipoLinea",
						column: x => x.idEnlaceERPTipoLinea,
						principalTable: "EnlaceERPTipoLinea",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_Archivos_Modelos",
				columns: table => new
				{
					idModelo = table.Column<int>(nullable: false),
					idArchivo = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_ArchivosModelos", x => new { x.idModelo, x.idArchivo });
					table.ForeignKey(
						name: "FK_GMAO_Modelos_GMAO_Archivos",
						column: x => x.idArchivo,
						principalTable: "GMAO_Archivos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_Archivos_Modelos_GMAO_MarcasModelos",
						column: x => x.idModelo,
						principalTable: "GMAO_MarcasModelos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_Deps_Operarios",
				columns: table => new
				{
					idDepartamento = table.Column<int>(nullable: false),
					idOperario = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_Deps_Operarios", x => new { x.idDepartamento, x.idOperario });
					table.ForeignKey(
						name: "FK_GMAO_Deps_Operarios_GMAO_Departamentos",
						column: x => x.idDepartamento,
						principalTable: "GMAO_Departamentos",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_GMAO_Deps_Operarios_GMAO_Operarios",
						column: x => x.idOperario,
						principalTable: "GMAO_Operarios",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_Archivos_Tipos",
				columns: table => new
				{
					idTipoElemento = table.Column<int>(nullable: false),
					idArchivo = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_Archivos_Tipos", x => new { x.idTipoElemento, x.idArchivo });
					table.ForeignKey(
						name: "FK_GMAO_Archivos_Tipos_GMAO_Archivos",
						column: x => x.idArchivo,
						principalTable: "GMAO_Archivos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_Archivos_Tipos_GMAO_ElementosTipos",
						column: x => x.idTipoElemento,
						principalTable: "GMAO_ElementosTipos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_CaracteristicasTipos",
				columns: table => new
				{
					idTipoElemento = table.Column<int>(nullable: false),
					idCaracteristica = table.Column<int>(nullable: false),
					ValorString = table.Column<string>(maxLength: 256, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_CaracteristicasTipos", x => new { x.idTipoElemento, x.idCaracteristica });
					table.ForeignKey(
						name: "FK_GMAO_CaracteristicasTipos_GMAO_Caracteristicas",
						column: x => x.idCaracteristica,
						principalTable: "GMAO_Caracteristicas",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_CaracteristicasTipos_GMAO_ElementosTipos",
						column: x => x.idTipoElemento,
						principalTable: "GMAO_ElementosTipos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_ElementosTiposModelos",
				columns: table => new
				{
					idTipo = table.Column<int>(nullable: false),
					idModelo = table.Column<int>(nullable: false),
					Preferencia = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_ElementosTiposModelos", x => new { x.idTipo, x.idModelo });
					table.ForeignKey(
						name: "FK_GMAO_ElementosTiposModelos_GMAO_MarcasModelos",
						column: x => x.idModelo,
						principalTable: "GMAO_MarcasModelos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_ElementosTiposModelos_GMAO_ElementosTipos",
						column: x => x.idTipo,
						principalTable: "GMAO_ElementosTipos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Clientes",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					CIF = table.Column<string>(maxLength: 14, nullable: true),
					Direccion = table.Column<string>(maxLength: 50, nullable: true),
					CodigoPostal = table.Column<string>(maxLength: 5, nullable: true),
					Poblacion = table.Column<string>(maxLength: 50, nullable: true),
					Provincia = table.Column<int>(nullable: true),
					Pais = table.Column<int>(nullable: true),
					Telefono = table.Column<string>(maxLength: 20, nullable: true),
					Inhabilitado = table.Column<bool>(nullable: true),
					Importado = table.Column<bool>(nullable: false),
					Refrescado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: false),
					RazonSocial = table.Column<string>(maxLength: 50, nullable: true),
					idOld = table.Column<int>(nullable: true),
					PorDefecto = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Clientes", x => x.Id);
					table.ForeignKey(
						name: "FK_Clientes_Paises",
						column: x => x.Pais,
						principalTable: "Paises",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Clientes_Provincias",
						column: x => x.Provincia,
						principalTable: "Provincias",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Departamentos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Empresa = table.Column<int>(nullable: true),
					EtiquetaSacos = table.Column<int>(nullable: true),
					EtiquetaGranel = table.Column<int>(nullable: true),
					EtiquetaControl = table.Column<int>(nullable: true),
					EtiquetaMuestras = table.Column<int>(nullable: true),
					MetodoLote = table.Column<int>(nullable: true),
					FormatoLote = table.Column<string>(maxLength: 50, nullable: true),
					PeriodoCaducidad = table.Column<int>(nullable: true),
					CaducidadAutomatica = table.Column<bool>(nullable: true),
					Analisi = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Direccion = table.Column<string>(maxLength: 50, nullable: true),
					Poblacion = table.Column<string>(maxLength: 50, nullable: true),
					Provincia = table.Column<int>(nullable: true),
					CodigoPostal = table.Column<string>(maxLength: 5, nullable: true),
					Telefono = table.Column<string>(maxLength: 15, nullable: true),
					Telefono2 = table.Column<string>(maxLength: 15, nullable: true),
					Fax = table.Column<string>(maxLength: 15, nullable: true),
					EtiquetaEntradas = table.Column<int>(nullable: true),
					idOld = table.Column<int>(nullable: true),
					Activo = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					DesinfeccionNumRegistro = table.Column<string>(maxLength: 50, nullable: true),
					DesinfeccionResponsable = table.Column<string>(maxLength: 50, nullable: true),
					DesinfeccionNombreCentro = table.Column<string>(maxLength: 50, nullable: true),
					DesinfeccionDesinfectante = table.Column<string>(maxLength: 50, nullable: true),
					DesinfeccionDNIResponsable = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Departamentos", x => x.Id);
					table.ForeignKey(
						name: "FK_Departamentos_Provincias",
						column: x => x.Provincia,
						principalTable: "Provincias",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "EmpresasTransporte",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					CIF = table.Column<string>(maxLength: 14, nullable: true),
					Direccion = table.Column<string>(maxLength: 50, nullable: true),
					Poblacion = table.Column<string>(maxLength: 50, nullable: true),
					CodigoPostal = table.Column<string>(maxLength: 5, nullable: true),
					Provincia = table.Column<int>(nullable: true),
					Pais = table.Column<int>(nullable: true),
					Telefono = table.Column<string>(maxLength: 20, nullable: true),
					Fax = table.Column<string>(maxLength: 20, nullable: true),
					Refrescado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					idOld = table.Column<int>(nullable: true),
					Activo = table.Column<bool>(nullable: true, defaultValueSql: "((1))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EmpresasTransporte", x => x.Id);
					table.ForeignKey(
						name: "FK_EmpresasTransporte_Paises",
						column: x => x.Pais,
						principalTable: "Paises",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EmpresasTransporte_Provincias",
						column: x => x.Provincia,
						principalTable: "Provincias",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Proveedores",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					CIF = table.Column<string>(maxLength: 14, nullable: true),
					Direccion = table.Column<string>(maxLength: 50, nullable: true),
					CodigoPostal = table.Column<string>(maxLength: 5, nullable: true),
					Poblacion = table.Column<string>(maxLength: 50, nullable: true),
					Telefono = table.Column<string>(maxLength: 20, nullable: true),
					Provincia = table.Column<int>(nullable: true),
					Abreviado = table.Column<string>(maxLength: 40, nullable: true),
					Importado = table.Column<bool>(nullable: false),
					Pais = table.Column<int>(nullable: true),
					Inhabilitado = table.Column<bool>(nullable: true),
					Refrescado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: false),
					idOld = table.Column<int>(nullable: true),
					NombreContacto = table.Column<string>(maxLength: 50, nullable: true),
					TelefonoContacto = table.Column<string>(maxLength: 20, nullable: true),
					Email = table.Column<string>(maxLength: 50, nullable: true),
					AutorizacionDestinoFinal = table.Column<string>(maxLength: 50, nullable: true),
					PorDefecto = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Proveedores", x => x.Id);
					table.ForeignKey(
						name: "FK_Proveedores_Paises",
						column: x => x.Pais,
						principalTable: "Paises",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Proveedores_Provincias",
						column: x => x.Provincia,
						principalTable: "Provincias",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Veterinarios",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Apellidos = table.Column<string>(maxLength: 50, nullable: true),
					NColegiado = table.Column<string>(maxLength: 50, nullable: true),
					DNI = table.Column<string>(maxLength: 9, nullable: true),
					Domicilio = table.Column<string>(maxLength: 120, nullable: true),
					CodigoPostal = table.Column<string>(maxLength: 10, nullable: true),
					Poblacion = table.Column<string>(maxLength: 120, nullable: true),
					ProvinciaId = table.Column<int>(nullable: true),
					IdEmpresa = table.Column<int>(nullable: true),
					Predeterminado = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Veterinarios", x => x.Id);
					table.ForeignKey(
						name: "FK_Veterinarios_Empresas",
						column: x => x.IdEmpresa,
						principalTable: "Empresas",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Veterinarios_Provincias_ProvinciaId",
						column: x => x.ProvinciaId,
						principalTable: "Provincias",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "OpcConfig",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 64, nullable: true),
					Tipo = table.Column<int>(nullable: false),
					Activado = table.Column<bool>(nullable: false),
					SincUbicaciones = table.Column<bool>(nullable: false),
					SincUsuarios = table.Column<bool>(nullable: false),
					Version = table.Column<int>(nullable: false),
					Topic = table.Column<string>(maxLength: 250, nullable: true),
					OPCIP = table.Column<string>(maxLength: 50, nullable: true),
					OPCRate = table.Column<int>(nullable: true),
					OPCNombre = table.Column<string>(maxLength: 250, nullable: true),
					IsGeneral = table.Column<bool>(nullable: false),
					BitVida = table.Column<DateTime>(type: "datetime", nullable: true),
					Calidad = table.Column<int>(nullable: true),
					DiscoveryUrl = table.Column<string>(maxLength: 256, nullable: true),
					Endpoint = table.Column<string>(maxLength: 256, nullable: true),
					DeviceAlias = table.Column<string>(maxLength: 256, nullable: true),
					IsPrincipal = table.Column<bool>(nullable: false),
					Maestro = table.Column<bool>(nullable: false),
					GatewayId = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OpcConfig", x => x.Id);
					table.ForeignKey(
						name: "FK_OpcConfig_Gateways_GatewayId",
						column: x => x.GatewayId,
						principalTable: "Gateways",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AlertasUsuariosInformesParametros",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Descripción = table.Column<string>(nullable: true),
					Valor = table.Column<string>(maxLength: 50, nullable: true),
					Tipo = table.Column<int>(nullable: true),
					idAlertaUsuarioInformes = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AlertasUsuariosInformesParametros", x => x.id);
					table.ForeignKey(
						name: "FK_AlertasUsuariosInformesParametros_AlertasUsuariosInformes",
						column: x => x.idAlertaUsuarioInformes,
						principalTable: "AlertasUsuariosInformes",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPSalidasLiniasLote",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Timestamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					FImportado = table.Column<DateTime>(type: "datetime", nullable: true),
					Preparado = table.Column<bool>(nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					Errores = table.Column<string>(maxLength: 1000, nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					idLineaSalida = table.Column<int>(nullable: true),
					idLineaSalidaMedicamento = table.Column<int>(nullable: true),
					refLote = table.Column<string>(maxLength: 50, nullable: true),
					nombreLote = table.Column<string>(maxLength: 50, nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					idSerie = table.Column<int>(nullable: true),
					NombreSerie = table.Column<string>(maxLength: 20, nullable: true),
					idSalidaMes = table.Column<int>(nullable: true),
					idLiniaMes = table.Column<int>(nullable: true),
					idLoteSalida = table.Column<int>(nullable: true),
					NumLoteLineaViaje = table.Column<int>(nullable: true),
					idProducto = table.Column<int>(nullable: true),
					ProductoNombre = table.Column<string>(maxLength: 50, nullable: true),
					ProductoReferencia = table.Column<string>(maxLength: 20, nullable: true),
					idViajeMES = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPSalidasLiniasLote", x => x.id);
					table.ForeignKey(
						name: "FK_BufferERPSalidasLiniasLote_BufferERPSalidasLinias",
						column: x => x.idLineaSalida,
						principalTable: "BufferERPSalidasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_BufferERPSalidasLiniasLote_BufferERPSalidasLinMedicamentos",
						column: x => x.idLineaSalidaMedicamento,
						principalTable: "BufferERPSalidasLinMedicamentos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Domicilios",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Cliente = table.Column<int>(nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					Direccion = table.Column<string>(maxLength: 50, nullable: true),
					Poblacion = table.Column<string>(maxLength: 50, nullable: true),
					Telefono = table.Column<string>(maxLength: 20, nullable: true),
					CodigoPostal = table.Column<string>(maxLength: 5, nullable: true),
					Provincia = table.Column<int>(nullable: true),
					Pais = table.Column<int>(nullable: true),
					MarcaOficial = table.Column<string>(maxLength: 50, nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Refrescado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Responsable = table.Column<string>(maxLength: 50, nullable: true),
					Especie = table.Column<int>(nullable: true),
					NumeroEspecies = table.Column<int>(nullable: true),
					Inhabilitado = table.Column<bool>(nullable: true),
					Descripcion = table.Column<string>(maxLength: 50, nullable: true),
					Simogan = table.Column<string>(maxLength: 20, nullable: true),
					REGA = table.Column<string>(maxLength: 20, nullable: true),
					LoteAnimalActual = table.Column<string>(maxLength: 20, nullable: true),
					IntegraId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Domicilios", x => x.Id);
					table.ForeignKey(
						name: "FK_Domicilios_Clientes",
						column: x => x.Cliente,
						principalTable: "Clientes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Domicilios_Especies",
						column: x => x.Especie,
						principalTable: "Especies",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Domicilios_Paises",
						column: x => x.Pais,
						principalTable: "Paises",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Domicilios_Provincias",
						column: x => x.Provincia,
						principalTable: "Provincias",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Familias",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Departamento = table.Column<int>(nullable: true),
					Analisi = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					idOld = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Familias", x => x.Id);
					table.ForeignKey(
						name: "FK_Familias_Analisis",
						column: x => x.Analisi,
						principalTable: "Analisis",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Familias_Departamentos",
						column: x => x.Departamento,
						principalTable: "Departamentos",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "ProveedoresOrigenes",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Proveedor = table.Column<int>(nullable: false),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					Direccion = table.Column<string>(maxLength: 50, nullable: true),
					Poblacion = table.Column<string>(maxLength: 50, nullable: true),
					Telefono = table.Column<string>(maxLength: 20, nullable: true),
					CodigoPostal = table.Column<string>(maxLength: 5, nullable: true),
					Provincia = table.Column<int>(nullable: true),
					Pais = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Responsable = table.Column<string>(maxLength: 50, nullable: true),
					Inhabilitado = table.Column<bool>(nullable: true),
					Descripcion = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ProveedoresOrigenes", x => x.id);
					table.ForeignKey(
						name: "FK_ProveedoresOrigenes_Paises",
						column: x => x.Pais,
						principalTable: "Paises",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_ProveedoresOrigenes_Proveedores",
						column: x => x.Proveedor,
						principalTable: "Proveedores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_ProveedoresOrigenes_Provincias",
						column: x => x.Provincia,
						principalTable: "Provincias",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "BufferConsumidos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FechaRecibido = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					Orden = table.Column<int>(nullable: true),
					Ciclo = table.Column<int>(nullable: true),
					NumCorrecion = table.Column<int>(nullable: true),
					Origen = table.Column<int>(nullable: true),
					Destino = table.Column<int>(nullable: true),
					ProdDensidad = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					ProdCodigo = table.Column<int>(nullable: true),
					ProdNombre = table.Column<string>(maxLength: 250, nullable: true),
					ProdIdLoteActual = table.Column<int>(nullable: true),
					ProdNombreLoteActual = table.Column<string>(maxLength: 250, nullable: true),
					Cantidad = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					Temperatura = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					Humedad = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					Ph = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					FechaConsumido = table.Column<DateTime>(type: "datetime", nullable: true),
					DuracionStamp = table.Column<int>(nullable: true),
					TiempoEfectivo = table.Column<int>(nullable: true),
					TiempoTotal = table.Column<int>(nullable: true),
					KWhEfectivo = table.Column<decimal>(type: "decimal(18, 5)", nullable: true),
					KWhTotal = table.Column<decimal>(type: "decimal(18, 5)", nullable: true),
					MedidorId = table.Column<int>(nullable: true),
					IndicadorId = table.Column<int>(nullable: true),
					ModuloId = table.Column<int>(nullable: true),
					UsuarioId = table.Column<int>(nullable: true),
					MultidosiId = table.Column<int>(nullable: true),
					TotalCiclos = table.Column<int>(nullable: true),
					Camino = table.Column<int>(nullable: true),
					Secuencia = table.Column<int>(nullable: true),
					OperacionId = table.Column<int>(nullable: true),
					ValidacionId = table.Column<int>(nullable: true),
					TemperaturaId = table.Column<int>(nullable: true),
					PhId = table.Column<int>(nullable: true),
					FinalSecuencia = table.Column<bool>(nullable: true),
					FinalCiclo = table.Column<bool>(nullable: true),
					FinalMedidor = table.Column<bool>(nullable: true),
					FinalOrden = table.Column<bool>(nullable: true),
					CantidadManual = table.Column<bool>(nullable: true),
					OrdenCancelada = table.Column<bool>(nullable: true),
					BitAux1 = table.Column<bool>(nullable: true),
					BitAux2 = table.Column<bool>(nullable: true),
					Variable1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
					Variable2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FechaTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					CodError = table.Column<int>(nullable: true),
					TxtError = table.Column<string>(nullable: true),
					TimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
					idUsuario = table.Column<int>(nullable: true),
					idDosificacionMes = table.Column<int>(nullable: true),
					idopc = table.Column<int>(nullable: true),
					Hash = table.Column<string>(maxLength: 32, nullable: true),
					OpcConfigId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferConsumidos", x => x.Id);
					table.ForeignKey(
						name: "FK__BufferCon__OpcCo__569ECEE8",
						column: x => x.OpcConfigId,
						principalTable: "OpcConfig",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "BufferProducidos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FechaRecibido = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					Orden = table.Column<int>(nullable: true),
					Ciclo = table.Column<int>(nullable: true),
					NumCorrecion = table.Column<int>(nullable: true),
					Origen = table.Column<int>(nullable: true),
					Destino = table.Column<int>(nullable: true),
					ProdDensidad = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					ProdCodigo = table.Column<int>(nullable: true),
					ProdNombre = table.Column<string>(maxLength: 250, nullable: true),
					ProdIdLoteActual = table.Column<int>(nullable: true),
					ProdNombreLoteActual = table.Column<string>(maxLength: 250, nullable: true),
					Cantidad = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					Temperatura = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					Humedad = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					Ph = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					FechaConsumido = table.Column<DateTime>(type: "datetime", nullable: true),
					DuracionStamp = table.Column<int>(nullable: true),
					TiempoEfectivo = table.Column<int>(nullable: true),
					TiempoTotal = table.Column<int>(nullable: true),
					KWhEfectivo = table.Column<decimal>(type: "decimal(18, 5)", nullable: true),
					KWhTotal = table.Column<decimal>(type: "decimal(18, 5)", nullable: true),
					MedidorId = table.Column<int>(nullable: true),
					IndicadorId = table.Column<int>(nullable: true),
					ModuloId = table.Column<int>(nullable: true),
					UsuarioId = table.Column<int>(nullable: true),
					MultidosiId = table.Column<int>(nullable: true),
					TotalCiclos = table.Column<int>(nullable: true),
					Camino = table.Column<int>(nullable: true),
					Secuencia = table.Column<int>(nullable: true),
					OperacionId = table.Column<int>(nullable: true),
					ValidacionId = table.Column<int>(nullable: true),
					TemperaturaId = table.Column<int>(nullable: true),
					PhId = table.Column<int>(nullable: true),
					FinalSecuencia = table.Column<bool>(nullable: true),
					FinalCiclo = table.Column<bool>(nullable: true),
					FinalMedidor = table.Column<bool>(nullable: true),
					FinalOrden = table.Column<bool>(nullable: true),
					CantidadManual = table.Column<bool>(nullable: true),
					OrdenCancelada = table.Column<bool>(nullable: true),
					BitAux1 = table.Column<bool>(nullable: true),
					BitAux2 = table.Column<bool>(nullable: true),
					Variable1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
					Variable2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
					Tratado = table.Column<bool>(nullable: true),
					FechaTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					CodError = table.Column<int>(nullable: true),
					TxtError = table.Column<string>(nullable: true),
					idDosificacionMes = table.Column<int>(nullable: true),
					idopc = table.Column<int>(nullable: true),
					Hash = table.Column<string>(maxLength: 32, nullable: true),
					OpcConfigId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferProducidos", x => x.Id);
					table.ForeignKey(
						name: "FK__BufferPro__OpcCo__66D536B1",
						column: x => x.OpcConfigId,
						principalTable: "OpcConfig",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Electrovalvulas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Tag = table.Column<string>(maxLength: 64, nullable: false),
					OpcConfigId = table.Column<int>(nullable: false),
					IdPlc = table.Column<int>(nullable: false),
					PlcEnabled = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Electrovalvulas", x => x.Id);
					table.ForeignKey(
						name: "FK_Electrovalvulas_OpcConfig",
						column: x => x.OpcConfigId,
						principalTable: "OpcConfig",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Motores",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					TAG = table.Column<string>(maxLength: 64, nullable: false),
					OpcConfigId = table.Column<int>(nullable: false),
					idPLC = table.Column<int>(nullable: false),
					PlcEnabled = table.Column<bool>(nullable: false),
					AlertaConsumoAlto = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					AlertaConsumoExcesivo = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					EnergiaEfectivaAnterior = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					EnergiaEnCargaAnterior = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					EnergiaEnVacioAnterior = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					EnergiaTotalAnterior = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					GrabarEnPLC = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
					IOCfgParInConsignaAlarmaI = table.Column<float>(type: "real", nullable: true),
					IOCfgParInConsignaAlarmaTempRod1 = table.Column<float>(type: "real", nullable: true),
					IOCfgParInConsignaAlarmaTempRod2 = table.Column<float>(type: "real", nullable: true),
					IOCfgParInConsignaAvisoIAlta = table.Column<float>(type: "real", nullable: true),
					IOCfgParInConsignaAvisoTempRod1 = table.Column<float>(type: "real", nullable: true),
					IOCfgParInConsignaAvisoTempRod2 = table.Column<float>(type: "real", nullable: true),
					IOCfgParInControlActivoVF = table.Column<bool>(type: "bit", nullable: true),
					IOCfgParInCosFi = table.Column<float>(type: "real", nullable: true),
					IOCfgParInHysteresisCarga = table.Column<float>(type: "real", nullable: true),
					IOCfgParInHysteresisMotorEnVacio = table.Column<float>(type: "real", nullable: true),
					IOCfgParInIntensidadEnVacio = table.Column<float>(type: "real", nullable: true),
					IOCfgParInIntensidadNominal = table.Column<float>(type: "real", nullable: true),
					IOCfgParInMonofasico = table.Column<bool>(type: "bit", nullable: true),
					IOCfgParInParametroAux2 = table.Column<float>(type: "real", nullable: true),
					IOCfgParInParametroAux3 = table.Column<float>(type: "real", nullable: true),
					IOCfgParInPorcentajeCargaMaxima = table.Column<int>(type: "int", nullable: true),
					IOCfgParInPorcentajeSobrecarga = table.Column<int>(type: "int", nullable: true),
					IOCfgParInSeccion0 = table.Column<int>(type: "int", nullable: true),
					IOCfgParInSeccion1 = table.Column<int>(type: "int", nullable: true),
					IOCfgParInSeccion2 = table.Column<int>(type: "int", nullable: true),
					IOCfgParInSeccion3 = table.Column<int>(type: "int", nullable: true),
					IOCfgParInSeccion4 = table.Column<int>(type: "int", nullable: true),
					IOCfgParInSeccion5 = table.Column<int>(type: "int", nullable: true),
					IOCfgParInSeccion6 = table.Column<int>(type: "int", nullable: true),
					IOCfgParInSeccion7 = table.Column<int>(type: "int", nullable: true),
					IOCfgParInSeccion8 = table.Column<int>(type: "int", nullable: true),
					IOCfgParInSeccion9 = table.Column<int>(type: "int", nullable: true),
					IOCfgParInTension = table.Column<int>(type: "int", nullable: true),
					IOCfgParInVelocidadErrorMax = table.Column<float>(type: "real", nullable: true),
					IOCfgParInVelocidadEscalado = table.Column<float>(type: "real", nullable: true),
					IOCfgSeguridadesInAccionFalloSuministro = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInActivarAlVelocidadFBack = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInActivarEncadenadoAuto = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInActivarEncadenadoMan = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInActivarPreavisoArranque = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInDesactivarAlDB1 = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInDesactivarAlDB2 = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInDesactivarAlDB3 = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInDesactivarAlDB4 = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInDesactivarAtasco = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInDesactivarCM = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInDesactivarDG = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInDesactivarFalloAE = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInDesactivarFalloAux = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInDesactivarFalloVF = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInDesactivarOtrasSeguridades = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInDesactivarPTC = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInPermisoRearranqManTrasFallo = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInTempRod1Habilitada = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInTempRod2Habilitada = table.Column<bool>(type: "bit", nullable: true),
					IOCfgSeguridadesInTipoDG = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimDelayActivarCargaMax = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimDelayAlDB1 = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimDelayAlDB2 = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimDelayAlDB3 = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimDelayAlDB4 = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimDelayAtasco = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimDelayDesactivarCargaMax = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimDelayFalloAE = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimDelayFalloAux = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimDelayFalloVF = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimDelayIntensidadElevada = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimDelayIntensidadMaxima = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimDelayOtrasSeguridades = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimDelayTermistorPTC = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimEsperaCM = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimInhibirCargaArranque = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimMaximoOffDG = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimMaximoOnDG = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimOMSiguienteMotor = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimPreavisoArranque = table.Column<int>(type: "int", nullable: true),
					IOCfgTiemposInTimRetardoStopAuto = table.Column<int>(type: "int", nullable: true),
					IOMantenInResetContadorAlarmas = table.Column<bool>(type: "bit", nullable: true),
					IOMantenInResetContadorEnergiaParciales = table.Column<bool>(type: "bit", nullable: true),
					IOMantenInResetContadorEnergiaTotales = table.Column<bool>(type: "bit", nullable: true),
					IOMantenInResetContadorManiobras = table.Column<bool>(type: "bit", nullable: true),
					IOMantenInResetContadores = table.Column<bool>(type: "bit", nullable: true),
					IOMantenInResetEnergias = table.Column<bool>(type: "bit", nullable: true),
					IOMantenInResetHorasEnCarga = table.Column<bool>(type: "bit", nullable: true),
					IOMantenInResetHorasParcial = table.Column<bool>(type: "bit", nullable: true),
					IOMantenInResetHorasTotal = table.Column<bool>(type: "bit", nullable: true),
					IOMantenInResetMaxPotenciasIntensidad = table.Column<bool>(type: "bit", nullable: true),
					IOMantenOutContAlAE = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlAtasco = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlAux = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlComunica = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlDB1 = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlDB2 = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlDB3 = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlDB4 = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlDG = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlDeshabil = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlDiferencial = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlFalloCM = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlIElevada = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlIMax = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlInversor = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlLockOut = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlOtrasSeguridades = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlParoEmerg = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlPuertaAbierta = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlTempElevRod1 = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlTempElevRod2 = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlTempMaxRod1 = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlTempMaxRod2 = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlTermico = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlTermistorPTC = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlVF = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContAlVelocidad = table.Column<int>(type: "int", nullable: true),
					IOMantenOutContadorTotAlarmas = table.Column<int>(type: "int", nullable: true),
					IOMantenOutEnergiaEfectiva = table.Column<float>(type: "real", nullable: true),
					IOMantenOutEnergiaEnCargaParciales = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutEnergiaEnCargaTotales = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutEnergiaEnVacioParciales = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutEnergiaEnVacioTotales = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutEnergiaTotal = table.Column<float>(type: "real", nullable: true),
					IOMantenOutHorasMarchaEnCarga = table.Column<float>(type: "real", nullable: true),
					IOMantenOutHorasMarchaParcial = table.Column<float>(type: "real", nullable: true),
					IOMantenOutHorasMarchaTotal = table.Column<float>(type: "real", nullable: true),
					IOMantenOutMemoriaMaxIntensidad = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutMemoriaMaxPotenciaActiva = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutMemoriaMaxPotenciaAparente = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutMemoriaMaxPotenciaReactiva = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutNumeroManiobras = table.Column<int>(type: "int", nullable: true),
					IOMantenOutPotenciaActiva = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutPotenciaActivaEfectiva = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutPotenciaAparente = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutPotenciaAparenteEfectiva = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutPotenciaReactiva = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutPotenciaReactivaEfectiva = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IdOpc = table.Column<int>(type: "int", nullable: true),
					InicioVentana = table.Column<DateTime>(type: "datetime", nullable: true),
					IsMaximetro = table.Column<bool>(type: "bit", nullable: true),
					LeerEnPLC = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
					MaximetroGeneral = table.Column<bool>(type: "bit", nullable: true),
					MedirKW = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
					MinsMaxVentana = table.Column<int>(type: "int", nullable: true),
					NombreMes = table.Column<string>(type: "nvarchar(50)", nullable: true),
					ValorVentanaMaximetro = table.Column<decimal>(type: "decimal(12, 3)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Motores", x => x.Id);
					table.ForeignKey(
						name: "FK_Motores_OpcConfig_OpcConfigId",
						column: x => x.OpcConfigId,
						principalTable: "OpcConfig",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Secciones",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Estado = table.Column<string>(maxLength: 50, nullable: true),
					Modulo = table.Column<int>(nullable: true),
					Entradas = table.Column<bool>(nullable: true),
					Salidas = table.Column<bool>(nullable: true),
					Medidor = table.Column<int>(nullable: true),
					Equipo = table.Column<int>(nullable: true),
					Mantener = table.Column<bool>(nullable: true),
					Registrar = table.Column<bool>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					EquipoRemoto = table.Column<int>(nullable: true),
					Sesion = table.Column<int>(nullable: true),
					SesionRemoto = table.Column<int>(nullable: true),
					IdPlc = table.Column<int>(nullable: true),
					OpcConfigId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Secciones", x => x.Id);
					table.ForeignKey(
						name: "FK__Secciones__OpcCo__7948ECA7",
						column: x => x.OpcConfigId,
						principalTable: "OpcConfig",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "SeccionesGrupos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idPLC = table.Column<int>(nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					OpcConfigId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SeccionesGrupos", x => x.id);
					table.ForeignKey(
						name: "FK__Secciones__OpcCo__7A3D10E0",
						column: x => x.OpcConfigId,
						principalTable: "OpcConfig",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Usuarios",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Nivel = table.Column<int>(nullable: true),
					Grupo = table.Column<int>(nullable: true),
					Clave = table.Column<string>(maxLength: 20, nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Rol = table.Column<int>(nullable: true),
					ActivoScada = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					AutoPremezclas = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PermisoScada = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					AutoTransito = table.Column<bool>(nullable: true),
					AutoEntAlmacen = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					IdOpc = table.Column<int>(nullable: true),
					LDAPUser = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					LDAPUserName = table.Column<string>(maxLength: 100, nullable: true),
					LDAPUserSid = table.Column<string>(maxLength: 100, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Usuarios", x => x.Id);
					table.ForeignKey(
						name: "FK_Usuarios_OpcConfig_IdOpc",
						column: x => x.IdOpc,
						principalTable: "OpcConfig",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Usuarios_UsuariosRoles",
						column: x => x.Rol,
						principalTable: "UsuariosRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "PuntosDescarga",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Descripcion = table.Column<string>(maxLength: 250, nullable: true),
					idDomicilio = table.Column<int>(nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					IntegraId = table.Column<int>(nullable: true),
					IntegraDomicilioId = table.Column<int>(nullable: true),
					Exportado = table.Column<bool>(nullable: false),
					Importado = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PuntosDescarga", x => x.id);
					table.ForeignKey(
						name: "FK_PuntosDescarga_Domicilios",
						column: x => x.idDomicilio,
						principalTable: "Domicilios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Ventas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idSerie = table.Column<int>(nullable: true),
					Codigo = table.Column<int>(nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					Departamento = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "date", nullable: true),
					PrecioTransporte = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					idCliente = table.Column<int>(nullable: true),
					FechaEntrega = table.Column<DateTime>(type: "date", nullable: true),
					idDomicilio = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					Comentario = table.Column<string>(nullable: true),
					Observaciones = table.Column<string>(nullable: true),
					FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaFin = table.Column<DateTime>(type: "datetime", nullable: true),
					RefERP = table.Column<string>(maxLength: 50, nullable: true),
					isImport = table.Column<bool>(nullable: true),
					Impresiones = table.Column<int>(nullable: false),
					Exportado = table.Column<bool>(nullable: false),
					Importado = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Ventas", x => x.id);
					table.ForeignKey(
						name: "FK_Ventas_Departamentos",
						column: x => x.Departamento,
						principalTable: "Departamentos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Ventas_Clientes",
						column: x => x.idCliente,
						principalTable: "Clientes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Ventas_Domicilios",
						column: x => x.idDomicilio,
						principalTable: "Domicilios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Ventas_Series",
						column: x => x.idSerie,
						principalTable: "Series",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Dominios",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Familia = table.Column<int>(nullable: true),
					Departamento = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Dominios", x => x.Id);
					table.ForeignKey(
						name: "FK_Dominios_Departamentos",
						column: x => x.Departamento,
						principalTable: "Departamentos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Dominios_Familias",
						column: x => x.Familia,
						principalTable: "Familias",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_Elementos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Referencia = table.Column<string>(maxLength: 64, nullable: true),
					Nombre = table.Column<string>(maxLength: 128, nullable: true),
					Descripcion = table.Column<string>(maxLength: 1024, nullable: true),
					Observaciones = table.Column<string>(maxLength: 1024, nullable: true),
					PrecioCosteNuevo = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
					Tipo = table.Column<int>(nullable: true),
					IsMaquina = table.Column<bool>(nullable: true),
					IsPieza = table.Column<bool>(nullable: true),
					HorasUsoActuales = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
					RevisionHoras = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
					DiasRevision = table.Column<int>(nullable: true),
					RequiereRevision = table.Column<bool>(nullable: true),
					MesesRevision = table.Column<int>(nullable: true),
					RevisionEnSiguienteParada = table.Column<bool>(nullable: true),
					MaxHorasSiguienteRevision = table.Column<int>(nullable: true),
					MaxDiasSiguienteRevision = table.Column<int>(nullable: true),
					OrdenArbol = table.Column<int>(nullable: true, defaultValueSql: "((-1))"),
					idMotor = table.Column<int>(nullable: true),
					CapturarDatos = table.Column<bool>(nullable: false),
					ModeloId = table.Column<int>(nullable: true),
					SerialNumber = table.Column<string>(maxLength: 256, nullable: true),
					Type = table.Column<byte>(nullable: false),
					ElementoPadreId = table.Column<int>(nullable: true),
					ElectrovalvulaId = table.Column<int>(nullable: true),
					LinkType = table.Column<byte>(nullable: false),
					LastReview = table.Column<DateTime>(nullable: false, defaultValueSql: "('1900-01-01 00:00:00')"),
					TiempoServicio = table.Column<int>(nullable: false),
					TiempoServicioDesdeUltimaRevision = table.Column<int>(nullable: false),
					TiempoTrabajando = table.Column<int>(nullable: false),
					TiempoTrabajandoDesdeUltimaRevision = table.Column<int>(nullable: false),
					ContadorAlarmas = table.Column<int>(nullable: false),
					ContadorAlarmasDesdeUltimaRevision = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_Elementos", x => x.id);
					table.ForeignKey(
						name: "FK__GMAO_Elem__Elect__75E27017",
						column: x => x.ElectrovalvulaId,
						principalTable: "Electrovalvulas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK__GMAO_Elem__Eleme__74EE4BDE",
						column: x => x.ElementoPadreId,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_Elementos_MarcasModelos",
						column: x => x.ModeloId,
						principalTable: "GMAO_MarcasModelos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_Elementos_GMAO_ElementosTipos",
						column: x => x.Tipo,
						principalTable: "GMAO_ElementosTipos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_Elementos_Motores",
						column: x => x.idMotor,
						principalTable: "Motores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "MotoresGruposRelacion",
				columns: table => new
				{
					idGrupo = table.Column<int>(nullable: false),
					idMotor = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_MotoresGruposRelacion", x => new { x.idGrupo, x.idMotor });
					table.ForeignKey(
						name: "FK_MotoresGruposRelacion_MotoresGrupos",
						column: x => x.idGrupo,
						principalTable: "MotoresGrupos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_MotoresGruposRelacion_Motores",
						column: x => x.idMotor,
						principalTable: "Motores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "MotoresHistorico",
				columns: table => new
				{
					MotorId = table.Column<int>(nullable: false),
					Timestamp = table.Column<DateTime>(nullable: false),
					TotalJouls = table.Column<long>(nullable: false),
					EfectiveJouls = table.Column<long>(nullable: false),
					ActiveWatts = table.Column<long>(nullable: false),
					TotalWatts = table.Column<long>(nullable: false),
					ReactiveWatts = table.Column<long>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_MotoresHistorico", x => new { x.MotorId, x.Timestamp });
					table.ForeignKey(
						name: "FK_MotoresHistorico_Motores_MotorId",
						column: x => x.MotorId,
						principalTable: "Motores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "SesionesSeccion",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Seccion = table.Column<int>(nullable: false),
					Sesion = table.Column<int>(nullable: true),
					Visible = table.Column<bool>(nullable: true),
					Controlable = table.Column<bool>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SesionesSeccion", x => x.Id);
					table.ForeignKey(
						name: "FK_SesionesSeccion_Secciones",
						column: x => x.Seccion,
						principalTable: "Secciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SesionesSeccion_Sesiones",
						column: x => x.Sesion,
						principalTable: "Sesiones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "InformesLibUsuarios",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdInforme = table.Column<int>(nullable: false),
					IdUsuario = table.Column<int>(nullable: false),
					ImpAutomatico = table.Column<bool>(nullable: false),
					ImpresoraDefecto = table.Column<string>(maxLength: 50, nullable: true),
					NumCopias = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
					Visible = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
					Habilitado = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
					DefaultPrinterId = table.Column<Guid>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_InformesLibUsuarios", x => x.Id);
					table.ForeignKey(
						name: "FK_InformesLibUsuarios_Printers_DefaultPrinterId",
						column: x => x.DefaultPrinterId,
						principalTable: "Printers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_InformesLibUsuarios_InformesLib",
						column: x => x.IdInforme,
						principalTable: "InformesLib",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_InformesLibUsuarios_Usuarios",
						column: x => x.IdUsuario,
						principalTable: "Usuarios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "NetAlarmasTipos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdAlarmaPLC = table.Column<int>(nullable: true),
					TextoError = table.Column<string>(maxLength: 250, nullable: true),
					Nivel = table.Column<int>(nullable: true),
					UserShow = table.Column<int>(nullable: true),
					RolShow = table.Column<int>(nullable: true),
					MostrarUsuario = table.Column<bool>(nullable: true),
					OEETipo = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					AutoFinalizar = table.Column<bool>(nullable: true, defaultValueSql: "((1))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_NetAlarmasTipos", x => x.Id);
					table.ForeignKey(
						name: "FK_NetAlarmasTipos_UsuariosRoles",
						column: x => x.RolShow,
						principalTable: "UsuariosRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_NetAlarmasTipos_Usuarios",
						column: x => x.UserShow,
						principalTable: "Usuarios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "OpcionesUsuarios",
				columns: table => new
				{
					idClave = table.Column<string>(maxLength: 50, nullable: false),
					idUsuario = table.Column<int>(nullable: false),
					valor = table.Column<string>(maxLength: 250, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OpcionesUsuarios", x => new { x.idClave, x.idUsuario });
					table.ForeignKey(
						name: "FK_OpcionesUsuarios_Opciones",
						column: x => x.idClave,
						principalTable: "Opciones",
						principalColumn: "Clave",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OpcionesUsuarios_Usuarios",
						column: x => x.idUsuario,
						principalTable: "Usuarios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "UsuariosLogs",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idUsuario = table.Column<int>(nullable: true),
					Login = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					Desconexion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					Activo = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					PC = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UsuariosLogs", x => x.id);
					table.ForeignKey(
						name: "FK_UsuariosLogs_Usuarios",
						column: x => x.idUsuario,
						principalTable: "Usuarios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "FileGmaoElement",
				columns: table => new
				{
					FileId = table.Column<Guid>(nullable: false),
					GmaoElementId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK__FileGmao__99EA4154D1B29574", x => new { x.FileId, x.GmaoElementId });
					table.ForeignKey(
						name: "FK__FileGmaoE__FileI__5575A085",
						column: x => x.FileId,
						principalTable: "Files",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK__FileGmaoE__GmaoE__5669C4BE",
						column: x => x.GmaoElementId,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_Archivos_Elementos",
				columns: table => new
				{
					idElemento = table.Column<int>(nullable: false),
					idArchivo = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_Archivos_Elementos", x => new { x.idElemento, x.idArchivo });
					table.ForeignKey(
						name: "FK_GMAO_Archivos_Elementos_GMAO_Archivos",
						column: x => x.idArchivo,
						principalTable: "GMAO_Archivos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_Archivos_Elementos_GMAO_Elementos",
						column: x => x.idElemento,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_CaracteristicasElementos",
				columns: table => new
				{
					idElemento = table.Column<int>(nullable: false),
					idCaracteristica = table.Column<int>(nullable: false),
					ValorString = table.Column<string>(maxLength: 256, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_CaracteristicasElementos", x => new { x.idElemento, x.idCaracteristica });
					table.ForeignKey(
						name: "FK_GMAO_CaracteristicasElementos_GMAO_Caracteristicas",
						column: x => x.idCaracteristica,
						principalTable: "GMAO_Caracteristicas",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_CaracteristicasElementos_GMAO_Elementos",
						column: x => x.idElemento,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_ComprasLineas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idCompra = table.Column<int>(nullable: false),
					idElemento = table.Column<int>(nullable: true),
					Cantidad = table.Column<int>(nullable: false),
					CantidadRecibida = table.Column<int>(nullable: false),
					FechaRecepcion = table.Column<DateTime>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_ComprasLineas", x => x.id);
					table.ForeignKey(
						name: "FK_GMAO_ComprasLineas_GMAO_Compras",
						column: x => x.idCompra,
						principalTable: "GMAO_Compras",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_GMAO_ComprasLineas_GMAO_Elementos",
						column: x => x.idElemento,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_ElemAlternativos",
				columns: table => new
				{
					IdPadre = table.Column<int>(nullable: false),
					IdHijo = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_ElemAlternativos", x => new { x.IdPadre, x.IdHijo });
					table.ForeignKey(
						name: "FK_GMAO_ElemAlternativos_Hijo",
						column: x => x.IdHijo,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_ElemAlternativos_Padre",
						column: x => x.IdPadre,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_ElementReviewSettings",
				columns: table => new
				{
					ElementId = table.Column<int>(nullable: false),
					RequiredReview = table.Column<bool>(nullable: false),
					LastReview = table.Column<DateTime>(nullable: true),
					HoursUsageInterval = table.Column<int>(nullable: true),
					HoursServiceInterval = table.Column<int>(nullable: true),
					TotalAlarms = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK__GMAO_Ele__A429721ACB3DB9FF", x => x.ElementId);
					table.ForeignKey(
						name: "FK__GMAO_Elem__Eleme__7D8391DF",
						column: x => x.ElementId,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_ElementReviewTasks",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					ElementId = table.Column<int>(nullable: false),
					TaskId = table.Column<int>(nullable: false),
					TriggerType = table.Column<byte>(nullable: false),
					Comments = table.Column<string>(maxLength: 256, nullable: true),
					CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
					UpdatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
					ResetDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
					IsEnabled = table.Column<bool>(nullable: false),
					Threshold = table.Column<int>(nullable: false),
					Counter = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_ElementReviewTasks", x => x.Id);
					table.ForeignKey(
						name: "FK_GMAO_ElementReviewTasks_GMAO_Elementos_ElementId",
						column: x => x.ElementId,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_GMAO_ElementReviewTasks_GMAO_ParadasConfiguracion_TaskId",
						column: x => x.TaskId,
						principalTable: "GMAO_ParadasConfiguracion",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_ElemIntervenciones",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idElemento = table.Column<int>(nullable: false),
					FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaFinal = table.Column<DateTime>(type: "datetime", nullable: true),
					IdOperarioResponsable = table.Column<int>(nullable: true),
					IDDepartamento = table.Column<int>(nullable: true),
					Referencia = table.Column<string>(nullable: true),
					Observaciones = table.Column<string>(nullable: true),
					Descripcion = table.Column<string>(nullable: true),
					IdParadaConfiguracion = table.Column<int>(nullable: true),
					IsRevisionElemento = table.Column<bool>(nullable: true),
					Cerrada = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_ElemIntervenciones", x => x.id);
					table.ForeignKey(
						name: "FK_GMAO_ElemIntervenciones_GMAO_Departamentos",
						column: x => x.IDDepartamento,
						principalTable: "GMAO_Departamentos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_ElemIntervenciones_GMAO_Operarios",
						column: x => x.IdOperarioResponsable,
						principalTable: "GMAO_Operarios",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_ElemIntervenciones_GMAO_ParadasConfiguracion",
						column: x => x.IdParadaConfiguracion,
						principalTable: "GMAO_ParadasConfiguracion",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_ElemIntervenciones_GMAO_Elementos",
						column: x => x.idElemento,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_ElemPertenencia",
				columns: table => new
				{
					IdPadre = table.Column<int>(nullable: false),
					IdHijo = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_ElemPertenencia", x => new { x.IdPadre, x.IdHijo });
					table.ForeignKey(
						name: "FK_GMAO_ElemPertenencia_Hijo",
						column: x => x.IdHijo,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_ElemPertenencia_Padre",
						column: x => x.IdPadre,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_ParadasConfiguracionTareas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idParadaConfiguracion = table.Column<int>(nullable: false),
					idOperario = table.Column<int>(nullable: true),
					idElemento = table.Column<int>(nullable: true),
					Descripcion = table.Column<string>(maxLength: 1024, nullable: true),
					Observaciones = table.Column<string>(maxLength: 1024, nullable: true),
					DuracionEstimada = table.Column<TimeSpan>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_ParadasConfiguracionTareas", x => x.id);
					table.ForeignKey(
						name: "FK_GMAO_ParadasConfiguracionTareas_GMAO_Elementos",
						column: x => x.idElemento,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_ParadasConfiguracionTareas_GMAO_Operarios",
						column: x => x.idOperario,
						principalTable: "GMAO_Operarios",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_ParadasConfiguracionTareas_GMAO_ParadasConfiguracion",
						column: x => x.idParadaConfiguracion,
						principalTable: "GMAO_ParadasConfiguracion",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_SolicitudOrdenTrabajo",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					CreadaPorId = table.Column<int>(nullable: false),
					Descripcion = table.Column<string>(maxLength: 1024, nullable: true),
					ElementoId = table.Column<int>(nullable: false),
					Estado = table.Column<byte>(nullable: false),
					GestionadaPorId = table.Column<int>(nullable: true),
					Creada = table.Column<DateTime>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_SolicitudOrdenTrabajo", x => x.Id);
					table.ForeignKey(
						name: "FK_GMAO_SolicitudOrdenTrabajo_CreadaPor",
						column: x => x.CreadaPorId,
						principalTable: "Usuarios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_SolicitudOrdenTrabajo_Elemento",
						column: x => x.ElementoId,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_SolicitudOrdenTrabajo_GestionadaPor",
						column: x => x.GestionadaPorId,
						principalTable: "Usuarios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_WarehouseStocks",
				columns: table => new
				{
					ElementId = table.Column<int>(nullable: false),
					WarehouseId = table.Column<Guid>(nullable: false),
					ModelId = table.Column<int>(nullable: false, defaultValueSql: "((-1))"),
					Quantity = table.Column<int>(nullable: false),
					SafetyStock = table.Column<int>(nullable: true),
					Corridor = table.Column<string>(maxLength: 64, nullable: true),
					RackBody = table.Column<string>(maxLength: 64, nullable: true),
					RackColumn = table.Column<string>(maxLength: 64, nullable: true),
					RackRow = table.Column<string>(maxLength: 64, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK__GMAO_War__0BA12F4480D20B06", x => new { x.ElementId, x.WarehouseId, x.ModelId });
					table.ForeignKey(
						name: "FK__GMAO_Ware__Eleme__1837881B",
						column: x => x.ElementId,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK__GMAO_Ware__Model__174363E2",
						column: x => x.ModelId,
						principalTable: "GMAO_MarcasModelos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK__GMAO_Ware__Wareh__192BAC54",
						column: x => x.WarehouseId,
						principalTable: "GMAO_Warehouses",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "NetAlarmasTiposRespuestas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idTipo = table.Column<int>(nullable: false),
					idRespuesta = table.Column<int>(nullable: false),
					Activado = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_NetAlarmasTiposRespuestas", x => x.id);
					table.ForeignKey(
						name: "FK_NetAlarmasTiposRespuestas_NetAlarmasRespuestas",
						column: x => x.idRespuesta,
						principalTable: "NetAlarmasRespuestas",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_NetAlarmasTiposRespuestas_NetAlarmasTipos",
						column: x => x.idTipo,
						principalTable: "NetAlarmasTipos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_ElemStocks",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idElemento = table.Column<int>(nullable: true),
					Cantidad = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					NumSerie = table.Column<string>(maxLength: 250, nullable: true),
					FechaEntrada = table.Column<DateTime>(type: "datetime", nullable: true),
					IdProveedor = table.Column<int>(nullable: true),
					IdCompraLinea = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					MesesGarantia = table.Column<int>(nullable: true),
					IdModelo = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_ElemStocks", x => x.id);
					table.ForeignKey(
						name: "FK_GMAO_ElemStocks_GMAO_ComprasLineas",
						column: x => x.IdCompraLinea,
						principalTable: "GMAO_ComprasLineas",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_ElemStocks_GMAO_MarcasModelo",
						column: x => x.IdModelo,
						principalTable: "GMAO_MarcasModelos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_ElemStocks_GMAO_Proveedores",
						column: x => x.IdProveedor,
						principalTable: "GMAO_Proveedores",
						principalColumn: "id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_GMAO_ElemStocks_GMAO_Elementos",
						column: x => x.idElemento,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_Archivos_Intervenciones",
				columns: table => new
				{
					idIntervencion = table.Column<int>(nullable: false),
					idArchivo = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_Intervenciones", x => new { x.idIntervencion, x.idArchivo });
					table.ForeignKey(
						name: "FK_GMAO_ElemIntervenciones_GMAO_Archivos",
						column: x => x.idArchivo,
						principalTable: "GMAO_Archivos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_Archivos_Intervenciones_GMAO_ElemIntervenciones",
						column: x => x.idIntervencion,
						principalTable: "GMAO_ElemIntervenciones",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_ElemIntervencionesPiezas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdIntervencion = table.Column<int>(nullable: true),
					ElementId = table.Column<int>(nullable: false),
					Quantity = table.Column<int>(nullable: false),
					WarehouseId = table.Column<Guid>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_ElemIntervencionesPiezas", x => x.id);
					table.ForeignKey(
						name: "FK_GMAO_ElemIntervencionesPiezas_GMAO_Elementos",
						column: x => x.ElementId,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_ElemIntervencionesPiezas_GMAO_ElemIntervenciones",
						column: x => x.IdIntervencion,
						principalTable: "GMAO_ElemIntervenciones",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_GMAO_ElemIntervencionesPiezas_GMAO_Warehouses",
						column: x => x.WarehouseId,
						principalTable: "GMAO_Warehouses",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_ElemIntervencionesTrabajos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idProveedor = table.Column<int>(nullable: true),
					IdOperario = table.Column<int>(nullable: true),
					Operarios = table.Column<string>(maxLength: 250, nullable: true),
					CosteTraslado = table.Column<decimal>(type: "decimal(12, 3)", nullable: true),
					FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaFinal = table.Column<DateTime>(type: "datetime", nullable: true),
					NHoras = table.Column<decimal>(type: "decimal(12, 3)", nullable: true),
					CosteHora = table.Column<decimal>(type: "decimal(12, 3)", nullable: true),
					CosteDietas = table.Column<decimal>(type: "decimal(12, 3)", nullable: true),
					NumOperarios = table.Column<int>(nullable: true),
					IdIntervencion = table.Column<int>(nullable: true),
					EnMantenimiento = table.Column<bool>(nullable: true),
					IdMantenimiento = table.Column<int>(nullable: true),
					Observaciones = table.Column<string>(nullable: true),
					Descripcion = table.Column<string>(nullable: true),
					ReviewTaskId = table.Column<Guid>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_ElemIntervencionesTrabajos", x => x.id);
					table.ForeignKey(
						name: "FK_GMAO_ElemIntervencionesTrabajos_GMAO_ElemIntervenciones",
						column: x => x.IdIntervencion,
						principalTable: "GMAO_ElemIntervenciones",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_GMAO_ElemIntervencionesTrabajos_GMAO_Operarios",
						column: x => x.IdOperario,
						principalTable: "GMAO_Operarios",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_ElemIntervencionesTrabajos_GMAO_ElementReviewTasks_ReviewTaskId",
						column: x => x.ReviewTaskId,
						principalTable: "GMAO_ElementReviewTasks",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_HistStocksYElementos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idStock = table.Column<int>(nullable: true),
					idElemento = table.Column<int>(nullable: true),
					FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaFinal = table.Column<DateTime>(type: "datetime", nullable: true),
					HorasUsoInicio = table.Column<int>(nullable: true),
					HorasUsoFinal = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_HistStocksYElementos", x => x.id);
					table.ForeignKey(
						name: "FK_GMAO_HistStocksYElementos_GMAO_Elementos",
						column: x => x.idElemento,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_HistStocksYElementos_GMAO_ElemStocks",
						column: x => x.idStock,
						principalTable: "GMAO_ElemStocks",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Productos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Familia = table.Column<int>(nullable: true),
					Densidad = table.Column<float>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Tipo = table.Column<int>(nullable: true),
					Stock = table.Column<int>(nullable: true),
					ControlStock = table.Column<bool>(nullable: true),
					Dosificable = table.Column<bool>(nullable: true),
					Automatico = table.Column<bool>(nullable: true),
					TipoDosificacion = table.Column<int>(nullable: true),
					Formato = table.Column<int>(nullable: true),
					Envase = table.Column<int>(nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Referencia2 = table.Column<string>(maxLength: 20, nullable: true),
					Importado = table.Column<bool>(nullable: false),
					Humedad = table.Column<float>(nullable: true),
					PesoEspecifico = table.Column<float>(nullable: true),
					Entradas = table.Column<int>(nullable: true),
					Muestras = table.Column<bool>(nullable: true),
					EtiquetaGranel = table.Column<int>(nullable: true),
					EtiquetaSacos = table.Column<int>(nullable: true),
					EtiquetaMuestras = table.Column<int>(nullable: true),
					EtiquetaControl = table.Column<int>(nullable: true),
					Formula = table.Column<int>(nullable: true),
					Analisi = table.Column<int>(nullable: true),
					NumeroRegistro = table.Column<string>(maxLength: 50, nullable: true),
					Inhabilitado = table.Column<bool>(nullable: true),
					Caducidad = table.Column<int>(nullable: true),
					Refrescado = table.Column<bool>(nullable: true),
					Receptable = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: false),
					Medicamento = table.Column<bool>(nullable: true),
					AplicacionDirecta = table.Column<bool>(nullable: true),
					Modulo = table.Column<int>(nullable: true),
					Medidor = table.Column<int>(nullable: true),
					FamiliaMedidor = table.Column<int>(nullable: true),
					Afeccion = table.Column<int>(nullable: true),
					PrecioCompra = table.Column<float>(nullable: true),
					PrecioVenta = table.Column<float>(nullable: true),
					PrecioMedioCompra = table.Column<float>(nullable: true),
					StockMinimo = table.Column<float>(nullable: true),
					Bloqueado = table.Column<bool>(nullable: true),
					TiempoEspera = table.Column<int>(nullable: true),
					TipoIva = table.Column<int>(nullable: true),
					PrecioCompraMedio = table.Column<float>(nullable: true),
					PrecioCompraUltimo = table.Column<float>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					EtiquetaEntradas = table.Column<int>(nullable: true),
					ViaAdministracion = table.Column<string>(maxLength: 50, nullable: true),
					MostrarEnEtiqueta = table.Column<bool>(nullable: true),
					NombreAMostrarEnEtiqueta = table.Column<string>(maxLength: 254, nullable: true),
					idOld = table.Column<int>(nullable: true),
					ToleranciaSuperior = table.Column<decimal>(type: "numeric(18, 2)", nullable: true),
					ToleranciaInferior = table.Column<decimal>(type: "numeric(18, 2)", nullable: true),
					PausaPosteriorDosificacion = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					DesviacionMaxima = table.Column<decimal>(type: "numeric(18, 2)", nullable: true),
					PlantillaCabCargaPiquera = table.Column<int>(nullable: true),
					TipoPR = table.Column<bool>(nullable: true),
					PlantillaCabProduccion = table.Column<int>(nullable: true),
					PlantillaCabCargaPiquera2 = table.Column<int>(nullable: true),
					PlantillaCabSecadero = table.Column<int>(nullable: true),
					EAN13 = table.Column<string>(maxLength: 20, nullable: true),
					PlantillaCabProduccion2 = table.Column<int>(nullable: true),
					PlantillaCabProduccion3 = table.Column<int>(nullable: true),
					DestinoDefecto = table.Column<int>(nullable: true),
					PartidaArancelariaFabricacion = table.Column<string>(maxLength: 50, nullable: true),
					PartidaArancelariaCompras = table.Column<string>(maxLength: 50, nullable: true),
					PlantillaCabMolturacion = table.Column<int>(nullable: true),
					NombreScada = table.Column<string>(maxLength: 20, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Productos", x => x.Id);
					table.ForeignKey(
						name: "FK_Productos_Afecciones",
						column: x => x.Afeccion,
						principalTable: "Afecciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Productos_Envases",
						column: x => x.Envase,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Productos_Etiquetas3",
						column: x => x.EtiquetaControl,
						principalTable: "Etiquetas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Productos_Etiquetas4",
						column: x => x.EtiquetaEntradas,
						principalTable: "Etiquetas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Productos_Etiquetas",
						column: x => x.EtiquetaGranel,
						principalTable: "Etiquetas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Productos_Etiquetas2",
						column: x => x.EtiquetaMuestras,
						principalTable: "Etiquetas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Productos_Etiquetas1",
						column: x => x.EtiquetaSacos,
						principalTable: "Etiquetas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Productos_Familias",
						column: x => x.Familia,
						principalTable: "Familias",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Productos_FamiliasMedidor",
						column: x => x.FamiliaMedidor,
						principalTable: "FamiliasMedidor",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Productos_Formatos",
						column: x => x.Formato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Productos_TiposIva",
						column: x => x.TipoIva,
						principalTable: "TiposIva",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Productos_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "ComponentesActivos",
				columns: table => new
				{
					Producto = table.Column<int>(nullable: false),
					Orden = table.Column<int>(nullable: false),
					Nombre = table.Column<string>(maxLength: 120, nullable: false),
					Cantidad = table.Column<float>(nullable: false),
					Unidad = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: false),
					Exportado = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ComponentesActivos", x => new { x.Producto, x.Orden });
					table.ForeignKey(
						name: "FK_ComponentesActivos_Productos_Producto",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ComponentesActivos_Unidades_Unidad",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Contratos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Tipo = table.Column<int>(nullable: true),
					IdCliente = table.Column<int>(nullable: true),
					IdProveedor = table.Column<int>(nullable: true),
					IdDireccionCliente = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaInicio = table.Column<DateTime>(type: "date", nullable: true),
					FechaFin = table.Column<DateTime>(type: "date", nullable: true),
					Caduca = table.Column<bool>(nullable: true),
					IdProducto = table.Column<int>(nullable: true),
					CantidadAsignada = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
					Precio = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
					PrecioTransporte = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
					CantidadXPedido = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
					DiasEntrePedidos = table.Column<int>(nullable: true),
					Activo = table.Column<bool>(nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Observaciones = table.Column<string>(maxLength: 1024, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Contratos", x => x.id);
					table.ForeignKey(
						name: "FK_Contratos_Clientes",
						column: x => x.IdCliente,
						principalTable: "Clientes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Contratos_Productos",
						column: x => x.IdProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Contratos_Proveedores",
						column: x => x.IdProveedor,
						principalTable: "Proveedores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Contratos_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "ControlesNIRProductos",
				columns: table => new
				{
					idControlNir = table.Column<int>(nullable: false),
					idProducto = table.Column<int>(nullable: false),
					FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
					Estado = table.Column<int>(nullable: true),
					Obligatorio = table.Column<bool>(nullable: true),
					Restrictivo = table.Column<bool>(nullable: true),
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ControlesNIRProductos", x => new { x.idControlNir, x.idProducto });
					table.ForeignKey(
						name: "FK_ControlesNIRProductos_ControlesNIR",
						column: x => x.idControlNir,
						principalTable: "ControlesNIR",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ControlesNIRProductos_Productos",
						column: x => x.idProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "GruposIncompatibilidadesLineas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdGrupo = table.Column<int>(nullable: false),
					IdProducto = table.Column<int>(nullable: false),
					Tipo = table.Column<int>(nullable: true),
					PorcentajeMinimo = table.Column<decimal>(type: "numeric(18, 3)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GruposIncompatibilidadesLineas", x => x.Id);
					table.ForeignKey(
						name: "FK_GruposIncompatibilidadesLineas_GruposIncompatibilidades",
						column: x => x.IdGrupo,
						principalTable: "GruposIncompatibilidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_GruposIncompatibilidadesLineas_Productos",
						column: x => x.IdProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Lotes",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Producto = table.Column<int>(nullable: false),
					OldId = table.Column<int>(nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Nombre = table.Column<string>(maxLength: 30, nullable: true),
					Formato = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Departamento = table.Column<int>(nullable: true),
					Entrada = table.Column<int>(nullable: true),
					Inicio = table.Column<DateTime>(type: "datetime", nullable: true),
					Fin = table.Column<DateTime>(type: "datetime", nullable: true),
					Caducidad = table.Column<DateTime>(type: "datetime", nullable: true),
					Estado = table.Column<int>(nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Importado = table.Column<bool>(nullable: false),
					Exportado = table.Column<bool>(nullable: false),
					PrecioCoste = table.Column<float>(nullable: true),
					Prioritario = table.Column<bool>(nullable: false),
					Modificado = table.Column<bool>(nullable: true),
					Medicacion = table.Column<int>(nullable: true),
					Mezclado = table.Column<bool>(nullable: true),
					IdProveedor = table.Column<int>(nullable: true),
					CantidadPedida = table.Column<decimal>(type: "decimal(15, 3)", nullable: true),
					Fabricacion = table.Column<DateTime>(type: "datetime", nullable: true),
					NombreEnCodBarras = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					CampoStrLibre1 = table.Column<string>(maxLength: 30, nullable: true),
					CampoStrLibre2 = table.Column<string>(maxLength: 30, nullable: true),
					CampoStrLibre3 = table.Column<string>(maxLength: 30, nullable: true),
					CampoStrLibre4 = table.Column<string>(maxLength: 30, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Lotes", x => x.Id);
					table.ForeignKey(
						name: "FK_Lotes_Formatos",
						column: x => x.Formato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Lotes_Proveedores",
						column: x => x.IdProveedor,
						principalTable: "Proveedores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Lotes_Medicaciones",
						column: x => x.Medicacion,
						principalTable: "Medicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Lotes_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "MedicacionesIngredientes",
				columns: table => new
				{
					Medicacion = table.Column<int>(nullable: false),
					Producto = table.Column<int>(nullable: false),
					Cantidad = table.Column<float>(nullable: false),
					Unidad = table.Column<int>(nullable: false),
					Porcentaje = table.Column<float>(nullable: false),
					Importado = table.Column<bool>(nullable: false),
					Exportado = table.Column<bool>(nullable: false),
					AplicacionDirecta = table.Column<bool>(nullable: false),
					Produccion = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_MedicacionesIngredientes", x => new { x.Medicacion, x.Producto });
					table.ForeignKey(
						name: "FK_MedicacionesIngredientes_Medicaciones_Medicacion",
						column: x => x.Medicacion,
						principalTable: "Medicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_MedicacionesIngredientes_Productos_Producto",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_MedicacionesIngredientes_Unidades_Unidad",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "ProductosEnvasesEtiquetas",
				columns: table => new
				{
					ProductoId = table.Column<int>(nullable: false),
					EnvaseId = table.Column<int>(nullable: false),
					Type = table.Column<byte>(nullable: false),
					Code = table.Column<string>(maxLength: 128, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ProductosEnvasesEtiquetas", x => new { x.ProductoId, x.EnvaseId });
					table.ForeignKey(
						name: "FK_ProductosEnvasesEtiquetas_Envases_EnvaseId",
						column: x => x.EnvaseId,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ProductosEnvasesEtiquetas_Productos_ProductoId",
						column: x => x.ProductoId,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "ProductosGruposIncompatibilidades",
				columns: table => new
				{
					IdProducto = table.Column<int>(nullable: false),
					IdGrupoIncompatibilidad = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ProductosGruposIncompatibilidades", x => new { x.IdProducto, x.IdGrupoIncompatibilidad });
					table.ForeignKey(
						name: "FK_ProductosGruposIncompatibilidades_GruposIncompatibilidades",
						column: x => x.IdGrupoIncompatibilidad,
						principalTable: "GruposIncompatibilidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ProductosGruposIncompatibilidades_Productos",
						column: x => x.IdProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Tarifas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Cliente = table.Column<int>(nullable: true),
					Producto = table.Column<int>(nullable: true),
					Medicacion = table.Column<int>(nullable: true),
					Envase = table.Column<int>(nullable: true),
					Precio = table.Column<float>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Tarifas", x => x.Id);
					table.ForeignKey(
						name: "FK_Tarifas_Clientes",
						column: x => x.Cliente,
						principalTable: "Clientes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Tarifas_Envases",
						column: x => x.Envase,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Tarifas_Medicaciones",
						column: x => x.Medicacion,
						principalTable: "Medicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Tarifas_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Tarifas_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "Compras",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Serie = table.Column<int>(nullable: true),
					Proveedor = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Estado = table.Column<int>(nullable: true),
					UltimaFecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Importado = table.Column<bool>(nullable: false),
					Departamento = table.Column<int>(nullable: true),
					Entrega = table.Column<DateTime>(type: "datetime", nullable: true),
					Comentario = table.Column<string>(maxLength: 100, nullable: true),
					Impresa = table.Column<bool>(nullable: true),
					Refrescado = table.Column<bool>(nullable: true),
					Fin = table.Column<DateTime>(type: "datetime", nullable: true),
					Exportado = table.Column<bool>(nullable: false),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Numero = table.Column<int>(nullable: true),
					idContrato = table.Column<int>(nullable: true),
					ReferenciaContrato = table.Column<string>(maxLength: 20, nullable: true),
					PrecioTransporte = table.Column<decimal>(type: "decimal(18, 2)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Compras", x => x.Id);
					table.ForeignKey(
						name: "FK_Compras_Departamentos",
						column: x => x.Departamento,
						principalTable: "Departamentos",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Compras_Proveedores",
						column: x => x.Proveedor,
						principalTable: "Proveedores",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Compras_Series",
						column: x => x.Serie,
						principalTable: "Series",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK__Compras__idContr__0559BDD1",
						column: x => x.idContrato,
						principalTable: "Contratos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "VentasLinias",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idVentas = table.Column<int>(nullable: true),
					idProducto = table.Column<int>(nullable: true),
					idFormato = table.Column<int>(nullable: true),
					idEnvase = table.Column<int>(nullable: true),
					Bultos = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					idUnidad = table.Column<int>(nullable: true),
					idDomicilio = table.Column<int>(nullable: true),
					idMedicamento = table.Column<int>(nullable: true),
					PrecioUnidad = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					idContrato = table.Column<int>(nullable: true),
					linea = table.Column<int>(nullable: true),
					MedCantidad = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
					MedBultos = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					MedEnvase = table.Column<int>(nullable: true),
					MedUnidad = table.Column<int>(nullable: true),
					MedFormato = table.Column<int>(nullable: true),
					MedPrecioUnidad = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
					Estado = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Observaciones = table.Column<string>(maxLength: 250, nullable: true),
					Precio = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					PrecioTransporte = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					CampoLibre1 = table.Column<string>(maxLength: 50, nullable: true),
					CampoLibre2 = table.Column<string>(maxLength: 50, nullable: true),
					idPuntoDescarga = table.Column<int>(nullable: true),
					FechaFin = table.Column<DateTime>(type: "datetime", nullable: true),
					Exportado = table.Column<bool>(nullable: false),
					Importado = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_VentasLinias", x => x.id);
					table.ForeignKey(
						name: "FKMed_VentasLinias_Envases",
						column: x => x.MedEnvase,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FKMed_VentasLinias_Formatos",
						column: x => x.MedFormato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FKMed_VentasLinias_Unidades",
						column: x => x.MedUnidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VentasLinias_Contratos",
						column: x => x.idContrato,
						principalTable: "Contratos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VentasLinias_Domicilios",
						column: x => x.idDomicilio,
						principalTable: "Domicilios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VentasLinias_Envases",
						column: x => x.idEnvase,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VentasLinias_Formatos",
						column: x => x.idFormato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VentasLinias_Medicaciones",
						column: x => x.idMedicamento,
						principalTable: "Medicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VentasLinias_Productos",
						column: x => x.idProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VentasLinias_PuntosDescarga",
						column: x => x.idPuntoDescarga,
						principalTable: "PuntosDescarga",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VentasLinias_Unidades",
						column: x => x.idUnidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VentasLinias_Ventas",
						column: x => x.idVentas,
						principalTable: "Ventas",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "LotesMezclados",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idLoteNuevo = table.Column<int>(nullable: true),
					idLoteOrigen = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 5)", nullable: true),
					CantidadActual = table.Column<decimal>(type: "decimal(15, 5)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_LotesMezclados", x => x.id);
					table.ForeignKey(
						name: "FK_LotesMezclados_LotesNuevo",
						column: x => x.idLoteNuevo,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_LotesMezclados_LotesOrigen",
						column: x => x.idLoteOrigen,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Ubicaciones",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Departamento = table.Column<int>(nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Tipo = table.Column<int>(nullable: true),
					CargaManual = table.Column<bool>(nullable: true),
					DescargaManual = table.Column<bool>(nullable: true),
					Capacidad = table.Column<float>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Individual = table.Column<bool>(nullable: true),
					Producto = table.Column<int>(nullable: true),
					Formato = table.Column<int>(nullable: true),
					Prioridad = table.Column<int>(nullable: true),
					Stock = table.Column<float>(nullable: true),
					ControlStock = table.Column<bool>(nullable: true),
					AvisosActivo = table.Column<bool>(nullable: true),
					AvisosEquipo = table.Column<int>(nullable: true),
					Visible = table.Column<bool>(nullable: true),
					Configurable = table.Column<bool>(nullable: true),
					PosicionX = table.Column<int>(nullable: true),
					PosicionY = table.Column<int>(nullable: true),
					Minima = table.Column<string>(maxLength: 50, nullable: true),
					Maxima = table.Column<string>(maxLength: 50, nullable: true),
					Nivel = table.Column<string>(maxLength: 50, nullable: true),
					Lote = table.Column<int>(nullable: true),
					Entradas = table.Column<bool>(nullable: true),
					Salidas = table.Column<bool>(nullable: true),
					Duplicado = table.Column<bool>(nullable: true),
					Desasignable = table.Column<bool>(nullable: true),
					Asociacion = table.Column<int>(nullable: true),
					Premezclas = table.Column<bool>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Bloqueado = table.Column<bool>(nullable: true),
					StockMinimo = table.Column<float>(nullable: true),
					NivelMinimo = table.Column<float>(nullable: true),
					NivelMaximo = table.Column<float>(nullable: true),
					AvisosSesion = table.Column<int>(nullable: true),
					Ordenacion = table.Column<int>(nullable: true),
					Color = table.Column<int>(nullable: true),
					AsociacionObligatoria = table.Column<bool>(nullable: true),
					idOld = table.Column<int>(nullable: true),
					MaPGrupo = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					MaPTiempoLimpiezaLlenado = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					MaPTipo = table.Column<int>(nullable: true, defaultValueSql: "((1))"),
					MaPNivelMaximoActivo = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					MaPNivelMinimoActivo = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					MaPNivelMedioActivo = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					MaPNivelPorcentajeActivo = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					MaPVolumenSilo = table.Column<decimal>(type: "numeric(18, 3)", nullable: true, defaultValueSql: "((0))"),
					MaPCaudalMaxEstLlenando = table.Column<decimal>(type: "numeric(18, 3)", nullable: true, defaultValueSql: "((0))"),
					MaPCaudalMaxEstVaciando = table.Column<decimal>(type: "numeric(18, 3)", nullable: true, defaultValueSql: "((0))"),
					PaMHabilitadoLlenado = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PaMHabilitadoVaciado = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PaMNivelMaximo = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PaMNivelMinimo = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PaMNivelMedio = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PaMForzarLleno = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PaMForzarVacio = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PaMNivelPorcentaje = table.Column<decimal>(type: "numeric(18, 3)", nullable: true, defaultValueSql: "((0))"),
					PaMTemperatura = table.Column<decimal>(type: "numeric(18, 3)", nullable: true, defaultValueSql: "((0))"),
					PaMPresion = table.Column<decimal>(type: "numeric(18, 3)", nullable: true, defaultValueSql: "((0))"),
					PaMVariable1 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					PaMVariable2 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					PaMVariable3 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					PaMVariable0 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					MaPVariable0 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					MaPVariable1 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					MaPVariable2 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					MaPVariable3 = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					Afino = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					ConVibrador = table.Column<int>(nullable: true),
					VelocidadLenta = table.Column<int>(nullable: true),
					VelocidadRapida = table.Column<int>(nullable: true),
					PaMCola = table.Column<decimal>(type: "numeric(18, 12)", nullable: true, defaultValueSql: "((0))"),
					PLCPosicion = table.Column<int>(nullable: true),
					ModoBigBag = table.Column<bool>(nullable: true),
					DosificacionMaxima = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					AfinoMaximo = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					EnviarEnPorcentaje = table.Column<bool>(nullable: true),
					AfinoMultiDosi = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					AfinoMaxMultiDosi = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PermitirAsociar = table.Column<bool>(nullable: true),
					AfinoMinimo = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					MaPTiempoRegistros = table.Column<int>(nullable: true, defaultValueSql: "((1))"),
					MinimoSiloResetUbi = table.Column<bool>(nullable: true),
					NoNegativos = table.Column<bool>(nullable: true),
					MezcladoLotes = table.Column<bool>(nullable: true),
					MezcladoMinimoDisolucion = table.Column<decimal>(type: "decimal(15, 3)", nullable: true),
					MezcladoDiasMinimoFCaducidad = table.Column<int>(nullable: true),
					TipoPR = table.Column<bool>(nullable: true),
					ColaPropuesta = table.Column<decimal>(type: "decimal(8, 6)", nullable: true),
					StockActual = table.Column<decimal>(type: "decimal(18, 5)", nullable: true, computedColumnSql: "([dbo].[StockEnUbicacion]([id],[NoNegativos]))"),
					LoteActual = table.Column<string>(maxLength: 50, nullable: true, computedColumnSql: "([dbo].[LoteEnUbicacion]([id]))"),
					PaMColaMulti = table.Column<decimal>(type: "numeric(18, 12)", nullable: true),
					IdOpc1 = table.Column<int>(nullable: true),
					IdOpc2 = table.Column<int>(nullable: true),
					IdOpc3 = table.Column<int>(nullable: true),
					IdOpc4 = table.Column<int>(nullable: true),
					PosicionPLC1 = table.Column<int>(nullable: true),
					PosicionPLC2 = table.Column<int>(nullable: true),
					PosicionPLC3 = table.Column<int>(nullable: true),
					PosicionPLC4 = table.Column<int>(nullable: true),
					ColorFondoAlfa = table.Column<byte>(nullable: true),
					ColorFondoRojo = table.Column<byte>(nullable: true),
					ColorFondoVerde = table.Column<byte>(nullable: true),
					ColorFondoAzul = table.Column<byte>(nullable: true),
					DiferenciaTraspasable = table.Column<bool>(nullable: true),
					OpcConfigId = table.Column<int>(nullable: true),
					Referencia2 = table.Column<string>(maxLength: 20, nullable: true),
					NoAsignable = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Bloqueable = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					SincronizarERP = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Ubicaciones", x => x.Id);
					table.ForeignKey(
						name: "FK_Ubicaciones_Ubicaciones",
						column: x => x.Asociacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Ubicaciones_Sesiones",
						column: x => x.AvisosSesion,
						principalTable: "Sesiones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Ubicaciones_Departamentos",
						column: x => x.Departamento,
						principalTable: "Departamentos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Ubicaciones_Formatos",
						column: x => x.Formato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Ubicaciones_Lotes",
						column: x => x.Lote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK__Ubicacion__OpcCo__3AE1A5DA",
						column: x => x.OpcConfigId,
						principalTable: "OpcConfig",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Ubicaciones_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Ubicaciones_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "VentasLiniasMedicaciones",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idVentaLinia = table.Column<int>(nullable: false),
					idEnvase = table.Column<int>(nullable: true),
					idFormato = table.Column<int>(nullable: true),
					idUnidad = table.Column<int>(nullable: false),
					Fecha = table.Column<DateTime>(nullable: true),
					Cantidad = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
					Bultos = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
					Estado = table.Column<int>(nullable: true),
					Precio = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
					PrecioUnidad = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
					ProductoId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_VentasLiniasMedicaciones", x => x.id);
					table.ForeignKey(
						name: "FK_VentasLiniasMedicaciones_Productos_ProductoId",
						column: x => x.ProductoId,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_VentasLiniasMedicaciones_Envases",
						column: x => x.idEnvase,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VentasLiniasMedicaciones_Formatos",
						column: x => x.idFormato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VentasLiniasMedicaciones_Unidades",
						column: x => x.idUnidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_VentasLiniasMedicaciones_VentasLinias",
						column: x => x.idVentaLinia,
						principalTable: "VentasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "VentasLiniasPuntosDescarga",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idLineaVenta = table.Column<int>(nullable: false),
					idPuntoDescarga = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_VentasLiniasPuntosDescarga", x => x.id);
					table.ForeignKey(
						name: "FK_VentasLiniasPuntosDescarga_SalidasLinias",
						column: x => x.idLineaVenta,
						principalTable: "VentasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VentasLiniasPuntosDescarga_PuntosDescarga",
						column: x => x.idPuntoDescarga,
						principalTable: "PuntosDescarga",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "BufferERPSolicitudRegularizacion",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdUbicacion = table.Column<int>(nullable: true),
					Cantidad = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					IdUsuario = table.Column<int>(nullable: true),
					Respuesta = table.Column<int>(nullable: true),
					FechaEnvio = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaSolicitud = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaRespuesta = table.Column<DateTime>(type: "datetime", nullable: true),
					Estado = table.Column<int>(nullable: true),
					TxtErrores = table.Column<string>(maxLength: 50, nullable: true),
					IdLote = table.Column<int>(nullable: true),
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPSolicitudRegularizacion", x => x.id);
					table.ForeignKey(
						name: "FK_BufferERPSolicitudRegularizacion_Lotes",
						column: x => x.IdLote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_BufferERPSolicitudRegularizacion_Ubicaciones",
						column: x => x.IdUbicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_BufferERPSolicitudRegularizacion_Usuarios",
						column: x => x.IdUsuario,
						principalTable: "Usuarios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

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
					Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
						name: "FK_BufferERPSolicitudTraspaso_Ubicaciones_DestinoId",
						column: x => x.DestinoId,
						principalTable: "Ubicaciones",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_BufferERPSolicitudTraspaso_Lotes_LoteId",
						column: x => x.LoteId,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_BufferERPSolicitudTraspaso_Ubicaciones_OrigenId",
						column: x => x.OrigenId,
						principalTable: "Ubicaciones",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_BufferERPSolicitudTraspaso_Usuarios_UsuarioId",
						column: x => x.UsuarioId,
						principalTable: "Usuarios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Caudales",
				columns: table => new
				{
					ProductoId = table.Column<int>(nullable: false),
					UbicacionId = table.Column<int>(nullable: false),
					Mode = table.Column<byte>(nullable: false),
					CaudalEntrada = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
					CaudalSalida = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
					PorcentajeAjusteAutomaticoMaximo = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValueSql: "5"),
					PorcentajeAjusteMaximo = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValueSql: "10")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK__Caudales__E533DB7E003CA3A8", x => new { x.ProductoId, x.UbicacionId });
					table.ForeignKey(
						name: "FK__Caudales__Produc__6F6A7CB2",
						column: x => x.ProductoId,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK__Caudales__Ubicac__15B0212B",
						column: x => x.UbicacionId,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "EnlaceERPAsigUbi",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false),
					IdProducto = table.Column<int>(nullable: true),
					IdUbicacion = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EnlaceERPAsigUbi", x => x.Id);
					table.ForeignKey(
						name: "FK_EnlaceERPAsigUbi_Productos",
						column: x => x.IdProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_EnlaceERPAsigUbi_Ubicaciones",
						column: x => x.IdUbicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "Regularizaciones",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Serie = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Ubicacion = table.Column<int>(nullable: true),
					Producto = table.Column<int>(nullable: true),
					Formato = table.Column<int>(nullable: true),
					Envase = table.Column<int>(nullable: true),
					LoteNombre = table.Column<string>(maxLength: 20, nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Tipo = table.Column<int>(nullable: true),
					Observaciones = table.Column<string>(maxLength: 250, nullable: true),
					Estado = table.Column<int>(nullable: true),
					Usuario = table.Column<int>(nullable: true),
					Lote = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Regularizaciones", x => x.Id);
					table.ForeignKey(
						name: "FK_Regularizaciones_Envases",
						column: x => x.Envase,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Regularizaciones_Formatos",
						column: x => x.Formato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Regularizaciones_Lotes",
						column: x => x.Lote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Regularizaciones_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Regularizaciones_Series",
						column: x => x.Serie,
						principalTable: "Series",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Regularizaciones_Ubicaciones",
						column: x => x.Ubicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Regularizaciones_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Regularizaciones_Usuarios",
						column: x => x.Usuario,
						principalTable: "Usuarios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "UbicacionesAsociadas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idUbicacion1 = table.Column<int>(nullable: true),
					idUbicacion2 = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UbicacionesAsociadas", x => x.id);
					table.ForeignKey(
						name: "FK_UbicacionesAsociadas_Ubicaciones",
						column: x => x.idUbicacion1,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_UbicacionesAsociadas_Ubicaciones1",
						column: x => x.idUbicacion2,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "UbicacionesOpcConfig",
				columns: table => new
				{
					UbicacionId = table.Column<int>(nullable: false),
					OpcConfigId = table.Column<int>(nullable: false),
					IdPlc = table.Column<int>(nullable: false),
					PlcEnabled = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UbicacionesOpcConfig", x => new { x.UbicacionId, x.OpcConfigId, x.IdPlc });
					table.ForeignKey(
						name: "FK_UbicacionesOpcConfig_OpcConfig",
						column: x => x.OpcConfigId,
						principalTable: "OpcConfig",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_UbicacionesOpcConfig_Ubicacion",
						column: x => x.UbicacionId,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Recetas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idCliente = table.Column<int>(nullable: true),
					idDomicilio = table.Column<int>(nullable: true),
					idAfeccion = table.Column<int>(nullable: true),
					NumReceta = table.Column<int>(nullable: true),
					idSerie = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					idSalidaLinea = table.Column<int>(nullable: true),
					Indicaciones = table.Column<string>(maxLength: 254, nullable: true),
					Frecuencia = table.Column<int>(nullable: true),
					Duracion = table.Column<int>(nullable: true),
					TiempoEspera = table.Column<int>(nullable: true),
					Conservacion = table.Column<int>(nullable: true),
					Observaciones = table.Column<string>(maxLength: 254, nullable: true),
					NaturalezaTratamiento = table.Column<string>(maxLength: 254, nullable: true),
					TiempoEsperaLeche = table.Column<int>(nullable: true),
					TiempoEsperaHuevos = table.Column<int>(nullable: true),
					NumRegistro = table.Column<string>(maxLength: 254, nullable: true),
					idVeterinario = table.Column<int>(nullable: true),
					idProducto = table.Column<int>(nullable: true),
					CantidadPienso = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					proporcionDiaria = table.Column<decimal>(type: "decimal(8, 3)", nullable: true),
					AutoGenerada = table.Column<bool>(nullable: true),
					MedicacionId = table.Column<int>(nullable: true),
					EspecieId = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Recetas", x => x.id);
					table.ForeignKey(
						name: "FK_Recetas_Especies_EspecieId",
						column: x => x.EspecieId,
						principalTable: "Especies",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Recetas_Medicaciones_MedicacionId",
						column: x => x.MedicacionId,
						principalTable: "Medicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Recetas_Afecciones",
						column: x => x.idAfeccion,
						principalTable: "Afecciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Recetas_Clientes",
						column: x => x.idCliente,
						principalTable: "Clientes",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Recetas_Domicilios",
						column: x => x.idDomicilio,
						principalTable: "Domicilios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Recetas_Productos",
						column: x => x.idProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Recetas_Series",
						column: x => x.idSerie,
						principalTable: "Series",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Recetas_Veterinarios",
						column: x => x.idVeterinario,
						principalTable: "Veterinarios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "RecetasLineas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idReceta = table.Column<int>(nullable: false),
					ProductoId = table.Column<int>(nullable: false),
					Cantidad = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					Porcentaje = table.Column<decimal>(type: "decimal(8, 5)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_RecetasLineas", x => x.id);
					table.ForeignKey(
						name: "FK_RecetasLineas_Productos_ProductoId",
						column: x => x.ProductoId,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_RecetasLineas_Recetas_idReceta",
						column: x => x.idReceta,
						principalTable: "Recetas",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AlertasUsuariosAlarmas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idAlertaUsuario = table.Column<int>(nullable: false),
					idNetAlarmaTipo = table.Column<int>(nullable: false),
					idModulo = table.Column<int>(nullable: true),
					ActivoMail = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					ActivoSMS = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AlertasUsuariosAlarmas", x => x.id);
					table.ForeignKey(
						name: "FK_AlertasUsuariosAlarmas_AlertasUsuarios",
						column: x => x.idAlertaUsuario,
						principalTable: "AlertasUsuarios",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AlertasUsuariosAlarmas_NetAlarmasTipos",
						column: x => x.idNetAlarmaTipo,
						principalTable: "NetAlarmasTipos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "EntradasLineas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idEntradas = table.Column<int>(nullable: true),
					idProducto = table.Column<int>(nullable: true),
					CantidadPedida = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					FechaInicioRecepcion = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaFinRecepcion = table.Column<DateTime>(type: "datetime", nullable: true),
					PesoBruto = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					Cajon1 = table.Column<bool>(nullable: true),
					Cajon2 = table.Column<bool>(nullable: true),
					Cajon3 = table.Column<bool>(nullable: true),
					Cajon4 = table.Column<bool>(nullable: true),
					Cajon5 = table.Column<bool>(nullable: true),
					Cajon6 = table.Column<bool>(nullable: true),
					Cajon7 = table.Column<bool>(nullable: true),
					Cajon8 = table.Column<bool>(nullable: true),
					Cajon9 = table.Column<bool>(nullable: true),
					Cajon10 = table.Column<bool>(nullable: true),
					TransitoActivo = table.Column<bool>(nullable: true),
					idBasculaPesajeBruto = table.Column<int>(nullable: true),
					idBasculaPesajeNeto = table.Column<int>(nullable: true),
					EntradaManualPesos = table.Column<bool>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					FueraCajon = table.Column<bool>(nullable: true),
					idProveedor = table.Column<int>(nullable: true),
					LedControlDocumental = table.Column<int>(nullable: true),
					LedAnalisisLaboratorio = table.Column<int>(nullable: true),
					LedAutorizacion = table.Column<int>(nullable: true),
					LedCargaProducto = table.Column<int>(nullable: true),
					LedDevolucionTarjeta = table.Column<int>(nullable: true),
					Lote = table.Column<int>(nullable: true),
					Tara = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					PesoNetoManual = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					RecogerPesoEnBascula = table.Column<bool>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Destino1 = table.Column<int>(nullable: true),
					Destino2 = table.Column<int>(nullable: true),
					Destino3 = table.Column<int>(nullable: true),
					Destino4 = table.Column<int>(nullable: true),
					Formato = table.Column<int>(nullable: true),
					Envase = table.Column<int>(nullable: true),
					Bultos = table.Column<int>(nullable: true),
					Observaciones = table.Column<string>(maxLength: 250, nullable: true),
					Precio = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PagarKgTeoricos = table.Column<bool>(nullable: true),
					CampoLibre1 = table.Column<string>(maxLength: 50, nullable: true),
					CampoLIbre2 = table.Column<string>(maxLength: 50, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					idModulo = table.Column<int>(nullable: true),
					Autorizada = table.Column<bool>(nullable: true),
					exportado = table.Column<bool>(nullable: false),
					Importado = table.Column<bool>(nullable: false),
					ErrorExport = table.Column<string>(maxLength: 200, nullable: true),
					CamionBanera = table.Column<bool>(nullable: true),
					EstadoTarjeta = table.Column<int>(nullable: true),
					TipoOrigen = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					Origen1 = table.Column<int>(nullable: true),
					Origen2 = table.Column<int>(nullable: true),
					Origen3 = table.Column<int>(nullable: true),
					Origen4 = table.Column<int>(nullable: true),
					NetoOrigen = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					NumLineaCompra = table.Column<int>(nullable: true),
					IdMuestra = table.Column<int>(nullable: true),
					AnadirStockPesaje = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					idOrigenProv = table.Column<int>(nullable: true),
					TaraAplicada = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					ReferenciaErp = table.Column<string>(maxLength: 32, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EntradasLineas", x => x.id);
					table.ForeignKey(
						name: "FK_EntradasLineas_Ubicaciones1",
						column: x => x.Destino1,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EntradasLineas_Ubicaciones2",
						column: x => x.Destino2,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EntradasLineas_Ubicaciones3",
						column: x => x.Destino3,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EntradasLineas_Ubicaciones4",
						column: x => x.Destino4,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EntradasLineas_Envases",
						column: x => x.Envase,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EntradasLineas_Formatos",
						column: x => x.Formato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EntradasLineas_Lotes",
						column: x => x.Lote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EntradasLineas_Ubicaciones5",
						column: x => x.Origen1,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EntradasLineas_Ubicaciones6",
						column: x => x.Origen2,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EntradasLineas_Ubicaciones7",
						column: x => x.Origen3,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EntradasLineas_Ubicaciones8",
						column: x => x.Origen4,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EntradasLineas_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EntradasLineas_ProveedoresOrigenes",
						column: x => x.idOrigenProv,
						principalTable: "ProveedoresOrigenes",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_EntradasLineas_Productos",
						column: x => x.idProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_EntradasLineas_Proveedores",
						column: x => x.idProveedor,
						principalTable: "Proveedores",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "EntradasContratos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idEntradasLineas = table.Column<int>(nullable: true),
					idContrato = table.Column<int>(nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 3)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EntradasContratos", x => x.id);
					table.ForeignKey(
						name: "FK_EntradasContratos_Contratos",
						column: x => x.idContrato,
						principalTable: "Contratos",
						principalColumn: "id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_EntradasContratos_EntradasLineas",
						column: x => x.idEntradasLineas,
						principalTable: "EntradasLineas",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "EntradasLineasResultadosNIR",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idEntradasLineas = table.Column<int>(nullable: true),
					Resultado = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					FechaResultado = table.Column<DateTime>(type: "datetime", nullable: true),
					idControlesNir = table.Column<int>(nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Descripcion = table.Column<string>(maxLength: 500, nullable: true),
					ValorMinimo = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ValorEsperado = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ValorMaximo = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ValorMinimoAlerta = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ValorMaximoAlerta = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ActivarMinimo = table.Column<bool>(nullable: true),
					ActivarMaximo = table.Column<bool>(nullable: true),
					ActivarMinimoAlerta = table.Column<bool>(nullable: true),
					ActivarMaximoAlerta = table.Column<bool>(nullable: true),
					Estado = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EntradasLineasResultadosNIR", x => x.id);
					table.ForeignKey(
						name: "FK_EntradasLineasResultadosNIR_ControlesNIR",
						column: x => x.idControlesNir,
						principalTable: "ControlesNIR",
						principalColumn: "id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_EntradasLineasResultadosNIR_EntradasLineas",
						column: x => x.idEntradasLineas,
						principalTable: "EntradasLineas",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "EntradasLotes",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdEntradasLineas = table.Column<int>(nullable: true),
					IdLote = table.Column<int>(nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					LoteProveedor = table.Column<string>(maxLength: 50, nullable: true),
					FCaducidad = table.Column<DateTime>(type: "date", nullable: true),
					Exportado = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EntradasLotes", x => x.id);
					table.ForeignKey(
						name: "FK_EntradasLotes_EntradasLineas",
						column: x => x.IdEntradasLineas,
						principalTable: "EntradasLineas",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_EntradasLotes_Lotes",
						column: x => x.IdLote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "Existencias",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Inventario = table.Column<int>(nullable: false),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Ubicacion = table.Column<int>(nullable: true),
					Producto = table.Column<int>(nullable: true),
					Formato = table.Column<int>(nullable: true),
					Envase = table.Column<int>(nullable: true),
					LoteNombre = table.Column<string>(maxLength: 30, nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					Lote = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					idProveedor = table.Column<int>(nullable: true),
					idEntradaLinea = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Existencias", x => x.Id);
					table.ForeignKey(
						name: "FK_Existencias_Envases",
						column: x => x.Envase,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Existencias_Formatos",
						column: x => x.Formato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Existencias_Inventarios",
						column: x => x.Inventario,
						principalTable: "Inventarios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Existencias_Lotes",
						column: x => x.Lote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Existencias_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Existencias_Ubicaciones",
						column: x => x.Ubicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Existencias_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Existencias_EntradasLineas",
						column: x => x.idEntradaLinea,
						principalTable: "EntradasLineas",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Existencias_Proveedores",
						column: x => x.idProveedor,
						principalTable: "Proveedores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "LineasCompra",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Serie = table.Column<int>(nullable: true),
					Compra = table.Column<int>(nullable: false),
					Linea = table.Column<int>(nullable: false),
					Producto = table.Column<int>(nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Servida = table.Column<float>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Departamento = table.Column<int>(nullable: true),
					Lote = table.Column<int>(nullable: true),
					Bultos = table.Column<int>(nullable: true),
					Envase = table.Column<int>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Contrato = table.Column<string>(maxLength: 20, nullable: true),
					Comentario = table.Column<string>(maxLength: 100, nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					PrecioCompra = table.Column<float>(nullable: true),
					IdContrato = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaFin = table.Column<DateTime>(type: "datetime", nullable: true),
					idLineaEntrada = table.Column<int>(nullable: true),
					Formato = table.Column<int>(nullable: true),
					PagarTeorico = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_LineasCompra", x => x.Id);
					table.ForeignKey(
						name: "FK_LineasCompra_Compras",
						column: x => x.Compra,
						principalTable: "Compras",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_LineasCompra_Envases",
						column: x => x.Envase,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_LineasCompra_Formatos",
						column: x => x.Formato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_LineasCompra_Contratos",
						column: x => x.IdContrato,
						principalTable: "Contratos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_LineasCompra_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_LineasCompra_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_LineasCompra_EntradasLineas",
						column: x => x.idLineaEntrada,
						principalTable: "EntradasLineas",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Indicadores",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					IdPlc = table.Column<int>(nullable: true),
					IdMedidor = table.Column<int>(nullable: true),
					IdBascula = table.Column<int>(nullable: true),
					IdOpc = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Indicadores", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Medidores",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Modulo = table.Column<int>(nullable: false),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Sesion = table.Column<int>(nullable: true),
					Capacidad = table.Column<int>(nullable: true),
					Automatico = table.Column<bool>(nullable: true),
					Tipo = table.Column<int>(nullable: true),
					UnidadParte = table.Column<int>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					UnidadEnvio = table.Column<int>(nullable: true),
					CantidadMinima = table.Column<float>(nullable: true),
					Dosificaciones = table.Column<string>(maxLength: 50, nullable: true),
					Resultados = table.Column<string>(maxLength: 50, nullable: true),
					UbicacionesMaximo = table.Column<int>(nullable: true),
					OrigenesMaximo = table.Column<int>(nullable: true),
					ProductosMaximo = table.Column<int>(nullable: true),
					CantidadesMaximo = table.Column<int>(nullable: true),
					LecturaReal = table.Column<bool>(nullable: true),
					Consecutivo = table.Column<bool>(nullable: true),
					Dinamico = table.Column<bool>(nullable: true),
					Principal = table.Column<bool>(nullable: true),
					Decimales = table.Column<int>(nullable: true),
					TipoOrigen = table.Column<int>(nullable: true),
					Visible = table.Column<bool>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					SeleccionProducto = table.Column<int>(nullable: true),
					OrigenesParteMaximo = table.Column<int>(nullable: true),
					RegistroAutomatico = table.Column<bool>(nullable: true),
					RegistroPeriodo = table.Column<int>(nullable: true),
					TipoDosificacion = table.Column<int>(nullable: true),
					FamiliaMedidor = table.Column<int>(nullable: true),
					CantidadesParteMaximo = table.Column<int>(nullable: true),
					RegistroTiempo = table.Column<DateTime>(type: "datetime", nullable: true),
					TipoRegularizacion = table.Column<int>(nullable: true),
					Equipo = table.Column<int>(nullable: true),
					Terminal = table.Column<bool>(nullable: true),
					OrdenAFinalizar = table.Column<int>(nullable: true),
					ControlStock = table.Column<bool>(nullable: true),
					EventoPesadaRegistrada = table.Column<string>(maxLength: 50, nullable: true),
					EventoOrdenFinalizada = table.Column<string>(maxLength: 50, nullable: true),
					IdOrdenActual = table.Column<int>(nullable: true),
					IdCicloActual = table.Column<int>(nullable: true),
					AutoValidacionLotes = table.Column<bool>(nullable: true),
					BorradoLotesInicioOrden = table.Column<bool>(nullable: true),
					IdOrdenAnterior = table.Column<int>(nullable: true),
					IdCicloAnterior = table.Column<int>(nullable: true),
					IdBascula = table.Column<int>(nullable: true),
					OpcConfigId = table.Column<int>(nullable: true),
					IdPLC = table.Column<int>(nullable: false),
					PlcEnabled = table.Column<bool>(nullable: false),
					PLCOrdenNumActual = table.Column<int>(nullable: true),
					PLCCicloNumActual = table.Column<int>(nullable: true),
					PLCSecuenciaNumActual = table.Column<int>(nullable: true),
					PLCEstadoActual = table.Column<int>(nullable: true),
					PLCEstadoAlarma = table.Column<int>(nullable: true),
					PLCOrigenIdActual0 = table.Column<int>(nullable: true),
					PLCOrigenIdActual1 = table.Column<int>(nullable: true),
					PLCOrigenIdActual2 = table.Column<int>(nullable: true),
					PLCOrigenIdActual3 = table.Column<int>(nullable: true),
					PLCOrigenIdActual4 = table.Column<int>(nullable: true),
					PLCOrigenIdActual5 = table.Column<int>(nullable: true),
					PLCOrigenIdActual6 = table.Column<int>(nullable: true),
					PLCOrigenIdActual7 = table.Column<int>(nullable: true),
					PLCOrigenIdActual8 = table.Column<int>(nullable: true),
					PLCOrigenIdActual9 = table.Column<int>(nullable: true),
					PLCOrigenIdActual10 = table.Column<int>(nullable: true),
					PLCOrigenIdActual11 = table.Column<int>(nullable: true),
					PLCOrigenIdActual12 = table.Column<int>(nullable: true),
					PLCOrigenIdActual13 = table.Column<int>(nullable: true),
					PLCOrigenIdActual14 = table.Column<int>(nullable: true),
					PLCOrigenIdActual15 = table.Column<int>(nullable: true),
					PLCOrigenIdActual16 = table.Column<int>(nullable: true),
					PLCOrigenIdActual17 = table.Column<int>(nullable: true),
					PLCOrigenIdActual18 = table.Column<int>(nullable: true),
					PLCOrigenIdActual19 = table.Column<int>(nullable: true),
					PLCIndicadoresId0 = table.Column<int>(nullable: true),
					PLCIndicadoresId1 = table.Column<int>(nullable: true),
					PLCIndicadoresId2 = table.Column<int>(nullable: true),
					PLCIndicadoresId3 = table.Column<int>(nullable: true),
					PLCIndicadoresId4 = table.Column<int>(nullable: true),
					PLCIndicadoresId5 = table.Column<int>(nullable: true),
					PLCIndicadoresId6 = table.Column<int>(nullable: true),
					PLCIndicadoresId7 = table.Column<int>(nullable: true),
					PLCIndicadoresId8 = table.Column<int>(nullable: true),
					PLCIndicadoresId9 = table.Column<int>(nullable: true),
					PLCIndicadoresId10 = table.Column<int>(nullable: true),
					PLCIndicadoresId11 = table.Column<int>(nullable: true),
					PLCIndicadoresId12 = table.Column<int>(nullable: true),
					PLCIndicadoresId13 = table.Column<int>(nullable: true),
					PLCIndicadoresId14 = table.Column<int>(nullable: true),
					PLCIndicadoresId15 = table.Column<int>(nullable: true),
					PLCIndicadoresId16 = table.Column<int>(nullable: true),
					PLCIndicadoresId17 = table.Column<int>(nullable: true),
					PLCIndicadoresId18 = table.Column<int>(nullable: true),
					PLCIndicadoresId19 = table.Column<int>(nullable: true),
					ModoAsumido = table.Column<int>(nullable: true),
					ParticionarDosificacion = table.Column<bool>(nullable: true),
					ModoMultidosificacion = table.Column<bool>(nullable: false),
					MinTolerancia = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					MaxTolerancia = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					idPlantillaOculta = table.Column<int>(nullable: true),
					AutoAlarmaFaltaProducto = table.Column<bool>(nullable: true),
					AutoAlarmaFaltaProductoCiclo = table.Column<bool>(nullable: true),
					AutoAlarmaMaxSiloCiclo = table.Column<bool>(nullable: true),
					AutoAlarmaMaxSilo = table.Column<bool>(nullable: true),
					RequiereOperaciones = table.Column<bool>(nullable: true),
					ForzarDosificacionConjunta = table.Column<bool>(nullable: true),
					AsumidoPrincipal = table.Column<bool>(nullable: true),
					VerDosiVariables = table.Column<bool>(nullable: true),
					TextoDosiVariables = table.Column<string>(maxLength: 250, nullable: true),
					EstadoForzado = table.Column<int>(nullable: true),
					DisponibleOEE = table.Column<bool>(nullable: true),
					MedirOEE = table.Column<bool>(nullable: true),
					PermitirModoMantenimiento = table.Column<bool>(nullable: true),
					RevisarDosiVariable1Ascendente = table.Column<bool>(nullable: false),
					IDAlarmaOrigenesFaltaProducto = table.Column<int>(nullable: true),
					IDAlarmaOrigenesFaltaProductoCiclico = table.Column<int>(nullable: true),
					IDAlarmaOrigenesMaximoSilo = table.Column<int>(nullable: true),
					IDAlarmaOrigenesMaximoSiloCiclico = table.Column<int>(nullable: true),
					IDAlarmaOrigenDeshabilitado = table.Column<int>(nullable: true),
					IDAlarmaDestinoDeshabilitado = table.Column<int>(nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					ForzarConsumidos = table.Column<bool>(nullable: true),
					Obligatorio = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					AutoAlarmaOrigenDeshabilitado = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					AutoAlarmaDestinoDeshabilitado = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PrioridadDosificacion = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Medidores", x => x.Id);
					table.ForeignKey(
						name: "FK_Medidores_FamiliasMedidor",
						column: x => x.FamiliaMedidor,
						principalTable: "FamiliasMedidor",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Alarmas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Equipo = table.Column<int>(nullable: true),
					Nombre = table.Column<string>(maxLength: 255, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Usuario = table.Column<int>(nullable: true),
					Medidor = table.Column<int>(nullable: true),
					Aviso = table.Column<int>(nullable: true),
					Argumento = table.Column<float>(nullable: true),
					Tipo = table.Column<int>(nullable: true),
					Contador = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					Accion = table.Column<int>(nullable: true),
					ArgumentoAccion = table.Column<int>(nullable: true),
					FechaAccion = table.Column<DateTime>(type: "datetime", nullable: true),
					Seccion = table.Column<int>(nullable: true),
					Orden = table.Column<int>(nullable: true),
					SerieOrden = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					EquipoRemoto = table.Column<int>(nullable: true),
					FechaEnvio = table.Column<DateTime>(type: "datetime", nullable: true),
					Sesion = table.Column<int>(nullable: true),
					SesionRemoto = table.Column<int>(nullable: true),
					ProductoInicial = table.Column<int>(nullable: true),
					ProductoFinal = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Alarmas", x => x.Id);
					table.ForeignKey(
						name: "FK_Alarmas_Medidores",
						column: x => x.Medidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Caminos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					MedidorId = table.Column<int>(nullable: false),
					IdPlc = table.Column<int>(nullable: false),
					Nombre = table.Column<string>(maxLength: 64, nullable: false),
					Tipo = table.Column<byte>(nullable: false),
					Defecto = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Caminos", x => x.Id);
					table.ForeignKey(
						name: "FK_Caminos_Medidores",
						column: x => x.MedidorId,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "OperMotores",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdPlc = table.Column<int>(nullable: true),
					Nombre = table.Column<string>(maxLength: 250, nullable: true),
					Tipo = table.Column<int>(nullable: true),
					ForzarMedidor = table.Column<bool>(nullable: true),
					IdMedidor = table.Column<int>(nullable: true),
					DescargaMezclador = table.Column<bool>(nullable: true),
					NoRepetido = table.Column<bool>(nullable: true),
					Cajon1 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Cajon2 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Cajon3 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Cajon4 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Cajon5 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Cajon6 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Cajon7 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Cajon8 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Cajon9 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Cajon10 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					RaseraTunelCarga = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					idAccionMotor = table.Column<int>(nullable: true),
					idMedidorForzado = table.Column<int>(nullable: true),
					DescargaSoloSiCamino = table.Column<bool>(nullable: true),
					DescargaCaminoFiltro = table.Column<int>(nullable: true),
					EsTiempoMezclaERP = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					OpcConfigId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OperMotores", x => x.Id);
					table.ForeignKey(
						name: "FK_OperMotores_Medidores",
						column: x => x.IdMedidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK__OperMotor__OpcCo__0307610B",
						column: x => x.OpcConfigId,
						principalTable: "OpcConfig",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OperMotores_OperAcciones",
						column: x => x.idAccionMotor,
						principalTable: "OperAcciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OperMotores_MedidoresForzado",
						column: x => x.idMedidorForzado,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Origenes",
				columns: table => new
				{
					ID = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Medidor = table.Column<int>(nullable: false),
					Ubicacion = table.Column<int>(nullable: true),
					Prioridad = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					MultiDosificacion = table.Column<bool>(nullable: true),
					PorcentajeObligatorio = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					VerVariable = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					VerVariable2 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					TextoVariable = table.Column<string>(maxLength: 250, nullable: true),
					TextoVariable2 = table.Column<string>(maxLength: 250, nullable: true),
					ValorDefecto = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					ValorDefecto2 = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					ValorMinimo = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					ValorMinimo2 = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					ValorMaximo = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					ValorMaximo2 = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					PorcentajeAPLC = table.Column<bool>(nullable: true),
					ActivarMinimoDosificacion = table.Column<bool>(nullable: true),
					ActivarMaximoDosificacion = table.Column<bool>(nullable: true),
					MaximoDosificacion = table.Column<decimal>(type: "decimal(15, 3)", nullable: true),
					MinimoDosificacion = table.Column<decimal>(type: "decimal(15, 3)", nullable: true),
					Proponer = table.Column<bool>(nullable: true),
					Activo = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					PrioridadDosificacion = table.Column<int>(nullable: true),
					ProductoStockObligatorio = table.Column<bool>(nullable: false),
					Capacidad = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
					SeleccionCargaAutomatica = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Origenes", x => x.ID);
					table.ForeignKey(
						name: "FK_Origenes_Medidores",
						column: x => x.Medidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Origenes_Ubicaciones",
						column: x => x.Ubicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Pistolas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdMedidor = table.Column<int>(nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					NombrePuerto = table.Column<string>(maxLength: 50, nullable: true),
					Velocidad = table.Column<int>(nullable: true),
					BitsDatos = table.Column<int>(nullable: true),
					BitsParada = table.Column<decimal>(type: "numeric(2, 1)", nullable: true),
					Paridad = table.Column<int>(nullable: true),
					HandShake = table.Column<int>(nullable: true),
					DTR = table.Column<bool>(nullable: true),
					RTS = table.Column<bool>(nullable: true),
					Tipo = table.Column<string>(maxLength: 50, nullable: true),
					IP = table.Column<string>(maxLength: 15, nullable: true),
					Puerto = table.Column<int>(nullable: true),
					ModoEntradasAlmacen = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					ModoSalidasAlmacen = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					ModoPicking = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Pistolas", x => x.Id);
					table.ForeignKey(
						name: "FK_Pistolas_Medidores",
						column: x => x.IdMedidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "TempControlesMedidores",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idTempControl = table.Column<int>(nullable: true),
					idMedidor = table.Column<int>(nullable: true),
					Obligatorio = table.Column<bool>(nullable: true),
					Unico = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TempControlesMedidores", x => x.id);
					table.ForeignKey(
						name: "FK_TempControlesMedidores_Medidores",
						column: x => x.idMedidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_TempControlesMedidores_TempControles",
						column: x => x.idTempControl,
						principalTable: "TempControles",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "UbisMedsAfino",
				columns: table => new
				{
					idUbicacion = table.Column<int>(nullable: false),
					idMedidor = table.Column<int>(nullable: false),
					PAfino = table.Column<int>(nullable: true),
					MaxAfino = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
					VelocidadMaxima = table.Column<int>(nullable: true),
					VelocidadLenta = table.Column<int>(nullable: true),
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UbisMedsAfino", x => new { x.idUbicacion, x.idMedidor });
					table.ForeignKey(
						name: "FK_UbisMedsAfino_Medidores",
						column: x => x.idMedidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_UbisMedsAfino_Ubicaciones",
						column: x => x.idUbicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "ProductoMedidorCamino",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					CaminoId = table.Column<int>(nullable: false),
					MedidorId = table.Column<int>(nullable: false),
					ProductoId = table.Column<int>(nullable: false),
					Activo = table.Column<bool>(nullable: false),
					Tipo = table.Column<byte>(nullable: false),
					FechaCreacion = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
					FechaEdicion = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ProductoMedidorCamino", x => x.Id);
					table.ForeignKey(
						name: "FK_ProductoMedidorCamino_Caminos_CaminoId",
						column: x => x.CaminoId,
						principalTable: "Caminos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ProductoMedidorCamino_Medidores_MedidorId",
						column: x => x.MedidorId,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ProductoMedidorCamino_Productos_ProductoId",
						column: x => x.ProductoId,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "MedidoresDosificaciones",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Activo = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
					idMedidor = table.Column<int>(nullable: false),
					idOrigen = table.Column<int>(nullable: false),
					idProducto = table.Column<int>(nullable: false),
					GenerarConProductos = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_MedidoresDosificaciones", x => x.id);
					table.ForeignKey(
						name: "FK_MedidoresDosificaciones_Medidores",
						column: x => x.idMedidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_MedidoresDosificaciones_Origenes",
						column: x => x.idOrigen,
						principalTable: "Origenes",
						principalColumn: "ID",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_MedidoresDosificaciones_Productos",
						column: x => x.idProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

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
					Activo = table.Column<bool>(nullable: false)
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

			migrationBuilder.CreateTable(
				name: "SalidasLinias",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idSalidas = table.Column<int>(nullable: true),
					idProducto = table.Column<int>(nullable: true),
					MedicacionId = table.Column<int>(nullable: true),
					idFormato = table.Column<int>(nullable: true),
					idEnvase = table.Column<int>(nullable: true),
					idUnidad = table.Column<int>(nullable: true),
					idDomicilio = table.Column<int>(nullable: true),
					Origen1 = table.Column<int>(nullable: true),
					Origen2 = table.Column<int>(nullable: true),
					Origen3 = table.Column<int>(nullable: true),
					Origen4 = table.Column<int>(nullable: true),
					FueraCajon = table.Column<bool>(nullable: true),
					Cajon1 = table.Column<bool>(nullable: true),
					Cajon2 = table.Column<bool>(nullable: true),
					Cajon3 = table.Column<bool>(nullable: true),
					Cajon4 = table.Column<bool>(nullable: true),
					Cajon5 = table.Column<bool>(nullable: true),
					Cajon6 = table.Column<bool>(nullable: true),
					Cajon7 = table.Column<bool>(nullable: true),
					Cajon8 = table.Column<bool>(nullable: true),
					Cajon9 = table.Column<bool>(nullable: true),
					Cajon10 = table.Column<bool>(nullable: true),
					FechaFinCarga = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaInicioCarga = table.Column<DateTime>(type: "datetime", nullable: true),
					Bultos = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Bruto = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Tara = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Estado = table.Column<int>(nullable: true),
					PrecioUnidad = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					LedControlDocumental = table.Column<int>(nullable: true),
					LedAnalisisLaboratorio = table.Column<int>(nullable: true),
					LedAutorizacion = table.Column<int>(nullable: true),
					LedCargaProducto = table.Column<int>(nullable: true),
					LedDevolucionTarjeta = table.Column<int>(nullable: true),
					idviajes = table.Column<int>(nullable: true),
					idorden = table.Column<int>(nullable: true),
					TransitoActivo = table.Column<bool>(nullable: true),
					idmodulo = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Precio = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					PrecioTransporte = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					EstadoTarjeta = table.Column<int>(nullable: true),
					Observaciones = table.Column<string>(maxLength: 250, nullable: true),
					Autorizada = table.Column<bool>(nullable: true),
					idBasculaPesajeBruto = table.Column<int>(nullable: true),
					idBasculaPesajeNeto = table.Column<int>(nullable: true),
					PesoNetoManual = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					CampoLibre1 = table.Column<string>(maxLength: 50, nullable: true),
					CampoLibre2 = table.Column<string>(maxLength: 50, nullable: true),
					LedViajeAsignado = table.Column<int>(nullable: true),
					idPuntoDescarga = table.Column<int>(nullable: true),
					Exportado = table.Column<bool>(nullable: false),
					Importado = table.Column<bool>(nullable: false),
					ErrorExportacion = table.Column<string>(maxLength: 1000, nullable: true),
					idAlbaran = table.Column<int>(nullable: true),
					TipoOrigen = table.Column<int>(nullable: true),
					CamionBanera = table.Column<bool>(nullable: true),
					VaciarSilos = table.Column<bool>(nullable: true),
					RefPedidoERP = table.Column<string>(maxLength: 20, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SalidasLinias", x => x.id);
					table.ForeignKey(
						name: "FK_SalidasLinias_Medicaciones_MedicacionId",
						column: x => x.MedicacionId,
						principalTable: "Medicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLinias_Ubicaciones1",
						column: x => x.Origen1,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLinias_Ubicaciones2",
						column: x => x.Origen2,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLinias_Ubicaciones3",
						column: x => x.Origen3,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLinias_Ubicaciones4",
						column: x => x.Origen4,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLinias_SalidasAlbaranes",
						column: x => x.idAlbaran,
						principalTable: "SalidasAlbaranes",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLinias_Domicilios",
						column: x => x.idDomicilio,
						principalTable: "Domicilios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLinias_Envases",
						column: x => x.idEnvase,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLinias_Formatos",
						column: x => x.idFormato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLinias_Productos",
						column: x => x.idProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLinias_PuntosDescarga",
						column: x => x.idPuntoDescarga,
						principalTable: "PuntosDescarga",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLinias_Unidades",
						column: x => x.idUnidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "LineaVentaLineaSalida",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idLineaVenta = table.Column<int>(nullable: false),
					idLineaSalida = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_LineaVentaLineaSalida", x => x.Id);
					table.ForeignKey(
						name: "FK_LineaVentaLineaSalida_SalidasLinias",
						column: x => x.idLineaSalida,
						principalTable: "SalidasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_LineaVentaLineaSalida_VentasLinias",
						column: x => x.idLineaVenta,
						principalTable: "VentasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "SalidasLiniasMedicaciones",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idSalidaLinia = table.Column<int>(nullable: false),
					Cantidad = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
					Bultos = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
					IdUnidad = table.Column<int>(nullable: false),
					idFormato = table.Column<int>(nullable: true),
					idEnvase = table.Column<int>(nullable: true),
					PrecioUnidad = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
					Estado = table.Column<int>(nullable: true),
					Precio = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
					Fecha = table.Column<DateTime>(nullable: true),
					idOrigen = table.Column<int>(nullable: true),
					ProductoId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SalidasLiniasMedicaciones", x => x.id);
					table.ForeignKey(
						name: "FK_SalidasLiniasMedicaciones_Unidades",
						column: x => x.IdUnidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_SalidasLiniasMedicaciones_Productos_ProductoId",
						column: x => x.ProductoId,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_SalidasLiniasMedicaciones_Envases",
						column: x => x.idEnvase,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLiniasMedicaciones_Formatos",
						column: x => x.idFormato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLiniasMedicaciones_Ubicaciones",
						column: x => x.idOrigen,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLiniasMedicaciones_SalidasLinias",
						column: x => x.idSalidaLinia,
						principalTable: "SalidasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "SalidasLiniasMuestras",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idSalidasLineas = table.Column<int>(nullable: true),
					Resultado = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					FechaResultado = table.Column<DateTime>(type: "datetime", nullable: true),
					idControlesNir = table.Column<int>(nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Descripcion = table.Column<string>(maxLength: 500, nullable: true),
					ValorMinimo = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ValorEsperado = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ValorMaximo = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ValorMinimoAlerta = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ValorMaximoAlerta = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ActivarMinimo = table.Column<bool>(nullable: true),
					ActivarMaximo = table.Column<bool>(nullable: true),
					ActivarMinimoAlerta = table.Column<bool>(nullable: true),
					ActivarMaximoAlerta = table.Column<bool>(nullable: true),
					Estado = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SalidasLiniasMuestras", x => x.id);
					table.ForeignKey(
						name: "FK_SalidasLiniasMuestras_ControlesNIR",
						column: x => x.idControlesNir,
						principalTable: "ControlesNIR",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLiniasMuestras_SalidasLinias",
						column: x => x.idSalidasLineas,
						principalTable: "SalidasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "SalidasLiniasPuntosDescarga",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idLineaSalida = table.Column<int>(nullable: false),
					idPuntoDescarga = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SalidasLiniasPuntosDescarga", x => x.id);
					table.ForeignKey(
						name: "FK_SalidasLiniasPuntosDescarga_SalidasLinias",
						column: x => x.idLineaSalida,
						principalTable: "SalidasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLiniasPuntosDescarga_PuntosDescarga",
						column: x => x.idPuntoDescarga,
						principalTable: "PuntosDescarga",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Stocks",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Ubicacion = table.Column<int>(nullable: false),
					Formato = table.Column<int>(nullable: true),
					Lote = table.Column<int>(nullable: false),
					Envase = table.Column<int>(nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(nullable: false),
					Estado = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: false),
					Exportado = table.Column<bool>(nullable: false),
					Palet = table.Column<int>(nullable: true),
					Procesando = table.Column<bool>(nullable: true),
					Observaciones = table.Column<string>(maxLength: 4000, nullable: true),
					idOld = table.Column<int>(nullable: true),
					idEntradasLineas = table.Column<int>(nullable: true),
					idSalidasLineas = table.Column<int>(nullable: true),
					FechaERP = table.Column<DateTime>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Stocks", x => x.Id);
					table.ForeignKey(
						name: "FK_Stocks_Envases_Envase",
						column: x => x.Envase,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Stocks_Formatos_Formato",
						column: x => x.Formato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Stocks_Lotes_Lote",
						column: x => x.Lote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Stocks_Ubicaciones_Ubicacion",
						column: x => x.Ubicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Stocks_Unidades_Unidad",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Stocks_EntradasLineas_idEntradasLineas",
						column: x => x.idEntradasLineas,
						principalTable: "EntradasLineas",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Stocks_SalidasLinias_idSalidasLineas",
						column: x => x.idSalidasLineas,
						principalTable: "SalidasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "SalidasLiniasLote",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idLineaSalida = table.Column<int>(nullable: true),
					idLineaSalidaMedicamento = table.Column<int>(nullable: true),
					idLote = table.Column<int>(nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Exportado = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SalidasLiniasLote", x => x.id);
					table.ForeignKey(
						name: "FK_SalidasLiniasLote_SalidasLinias",
						column: x => x.idLineaSalida,
						principalTable: "SalidasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLiniasLote_SalidasLiniasMedicaciones",
						column: x => x.idLineaSalidaMedicamento,
						principalTable: "SalidasLiniasMedicaciones",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasLiniasLote_Lotes",
						column: x => x.idLote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "TagsBasculas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idTag = table.Column<int>(nullable: true),
					idBascula = table.Column<int>(nullable: true),
					Predeterminada = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TagsBasculas", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "Ordenes",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdCab = table.Column<int>(nullable: true),
					Serie = table.Column<int>(nullable: false),
					Nombre = table.Column<string>(maxLength: 250, nullable: true),
					Departamento = table.Column<int>(nullable: true),
					Modulo = table.Column<int>(nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Estado = table.Column<int>(nullable: true),
					Servida = table.Column<float>(nullable: true),
					Inicio = table.Column<DateTime>(type: "datetime", nullable: true),
					Fin = table.Column<DateTime>(type: "datetime", nullable: true),
					Formula = table.Column<int>(nullable: true),
					NumeroCiclos = table.Column<int>(nullable: true),
					ContadorCiclos = table.Column<int>(nullable: true),
					Exportado = table.Column<bool>(nullable: false),
					LoteNombre = table.Column<string>(maxLength: 30, nullable: true),
					FormulaFecha = table.Column<DateTime>(type: "datetime", nullable: true),
					ProductoDestino = table.Column<int>(nullable: true),
					LoteDestino = table.Column<int>(nullable: true),
					TipoFinalizacion = table.Column<int>(nullable: true),
					Tiempo = table.Column<int>(nullable: true),
					Velocidad = table.Column<float>(nullable: true),
					Ganancia = table.Column<float>(nullable: true),
					GananciaUnidad = table.Column<int>(nullable: true),
					EnvaseOrigen = table.Column<int>(nullable: true),
					BultosOrigen = table.Column<int>(nullable: true),
					Modificada = table.Column<bool>(nullable: true),
					Receta = table.Column<int>(nullable: true),
					Medicacion = table.Column<int>(nullable: true),
					Version = table.Column<int>(nullable: true),
					Confirmada = table.Column<bool>(nullable: true),
					SerieSalida = table.Column<int>(nullable: true),
					Salida = table.Column<int>(nullable: true),
					LineaSalida = table.Column<int>(nullable: true),
					SerieEntrada = table.Column<int>(nullable: true),
					Entrada = table.Column<int>(nullable: true),
					LineaEntrada = table.Column<int>(nullable: true),
					SeriePlanificacion = table.Column<int>(nullable: true),
					Planificacion = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: false),
					LineaVenta = table.Column<int>(nullable: true),
					OrdenAscendiente = table.Column<int>(nullable: true),
					SerieOrdenAscendiente = table.Column<int>(nullable: true),
					SerieOrdenRelacionada = table.Column<int>(nullable: true),
					OrdenRelacionada = table.Column<int>(nullable: true),
					Medicada = table.Column<bool>(nullable: true),
					idChofer = table.Column<int>(nullable: true),
					idTarjeta = table.Column<int>(nullable: true),
					Editada = table.Column<bool>(nullable: true),
					idOld = table.Column<int>(nullable: true),
					SerieOld = table.Column<int>(nullable: true),
					IniciarOrden = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					OrdenEnvioPLC = table.Column<int>(nullable: true),
					Caminos = table.Column<int>(nullable: true),
					FechaEnvioAPlc = table.Column<DateTime>(type: "datetime", nullable: true),
					Bloqueada = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					ViajeSalida = table.Column<int>(nullable: true),
					SerieViajeSalida = table.Column<int>(nullable: true),
					NombreChofer = table.Column<string>(maxLength: 50, nullable: true),
					Matricula = table.Column<string>(maxLength: 15, nullable: true),
					ModuloVariables0 = table.Column<float>(nullable: false),
					ModuloVariables1 = table.Column<float>(nullable: false),
					ModuloVariables2 = table.Column<float>(nullable: false),
					ModuloVariables3 = table.Column<float>(nullable: false),
					ModuloVariables4 = table.Column<float>(nullable: false),
					ModuloVariables5 = table.Column<float>(nullable: false),
					ModuloVariables6 = table.Column<float>(nullable: false),
					ModuloVariables7 = table.Column<float>(nullable: false),
					ModuloVariables8 = table.Column<float>(nullable: false),
					ModuloVariables9 = table.Column<float>(nullable: false),
					Remolque = table.Column<string>(maxLength: 15, nullable: true),
					IdVehiculo = table.Column<int>(nullable: true),
					RefERP = table.Column<string>(maxLength: 50, nullable: true),
					SegundosCicloTeorico = table.Column<string>(maxLength: 250, nullable: true),
					DatosOptimizados = table.Column<bool>(nullable: true),
					IncompatComprobada = table.Column<bool>(nullable: true),
					IncompatFlexible = table.Column<bool>(nullable: true),
					IncompatEstricta = table.Column<bool>(nullable: true),
					IncompatInfo = table.Column<string>(maxLength: 250, nullable: true),
					TiempoPrevistoCicloSegs = table.Column<int>(nullable: true),
					FechaInicioPrevista = table.Column<DateTime>(type: "datetime", nullable: true),
					NecesitaOrigen = table.Column<bool>(nullable: true),
					Fexportado = table.Column<DateTime>(type: "datetime", nullable: true),
					ExportError = table.Column<string>(maxLength: 250, nullable: true),
					TotalCiclosReal = table.Column<int>(nullable: true),
					RefERP1 = table.Column<string>(maxLength: 20, nullable: true),
					RefERP2 = table.Column<string>(maxLength: 20, nullable: true),
					RefERP3 = table.Column<string>(maxLength: 20, nullable: true),
					IgnorarConsumidos = table.Column<bool>(nullable: false),
					IgnorarProducidos = table.Column<bool>(nullable: false),
					TipoAutoRespuestaDestino = table.Column<int>(nullable: false),
					EfectiveJouls = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
					TotalJouls = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
					Validada = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					VentaLineaId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Ordenes", x => x.Id);
					table.ForeignKey(
						name: "FK_Ordenes_Departamentos",
						column: x => x.Departamento,
						principalTable: "Departamentos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Ordenes_Envases",
						column: x => x.EnvaseOrigen,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Ordenes_EntradasLineas",
						column: x => x.LineaEntrada,
						principalTable: "EntradasLineas",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Ordenes_SalidasLinias",
						column: x => x.LineaSalida,
						principalTable: "SalidasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Ordenes_Lotes",
						column: x => x.LoteDestino,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Ordenes_Medicaciones",
						column: x => x.Medicacion,
						principalTable: "Medicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Ordenes_Productos",
						column: x => x.ProductoDestino,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Ordenes_VentasLinias_VentaLineaId",
						column: x => x.VentaLineaId,
						principalTable: "VentasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Aditivos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Orden = table.Column<int>(nullable: false),
					IdOld = table.Column<int>(nullable: false),
					Producto = table.Column<int>(nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Ubicacion = table.Column<int>(nullable: true),
					Formato = table.Column<int>(nullable: true),
					Lote = table.Column<string>(maxLength: 20, nullable: true),
					Servida = table.Column<float>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Serie = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Aditivos", x => x.Id);
					table.ForeignKey(
						name: "FK_Aditivos_Formatos",
						column: x => x.Formato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Aditivos_Ordenes",
						column: x => x.Orden,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Aditivos_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Aditivos_Ubicaciones",
						column: x => x.Ubicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Aditivos_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Desgloses",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Serie = table.Column<int>(nullable: true),
					Orden = table.Column<int>(nullable: false),
					IdOld = table.Column<int>(nullable: true),
					Producto = table.Column<int>(nullable: true),
					Lote = table.Column<int>(nullable: true),
					Ubicacion = table.Column<int>(nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Servida = table.Column<float>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					CantidadPrincipal = table.Column<float>(nullable: true),
					TipoRegistro = table.Column<int>(nullable: true),
					Finalizado = table.Column<bool>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					Ciclo = table.Column<int>(nullable: false),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					NumCorrecion = table.Column<int>(nullable: true),
					ProdDensidad = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					ProdNombre = table.Column<string>(maxLength: 250, nullable: true),
					ProdNombreLoteActual = table.Column<string>(maxLength: 250, nullable: true),
					Temperatura = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					Humedad = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					Ph = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					DuracionStamp = table.Column<int>(nullable: true),
					TiempoEfectivo = table.Column<int>(nullable: true),
					TiempoTotal = table.Column<int>(nullable: true),
					KWhEfectivo = table.Column<decimal>(type: "decimal(18, 5)", nullable: true),
					KWhTotal = table.Column<decimal>(type: "decimal(18, 5)", nullable: true),
					MedidorId = table.Column<int>(nullable: true),
					IndicadorId = table.Column<int>(nullable: true),
					UsuarioId = table.Column<int>(nullable: true),
					MultidosiId = table.Column<int>(nullable: true),
					TotalCiclos = table.Column<int>(nullable: true),
					Camino = table.Column<int>(nullable: true),
					Secuencia = table.Column<int>(nullable: true),
					OperacionId = table.Column<int>(nullable: true),
					ValidacionId = table.Column<int>(nullable: true),
					TemperaturaId = table.Column<int>(nullable: true),
					PhId = table.Column<int>(nullable: true),
					FinalSecuencia = table.Column<bool>(nullable: true),
					FinalCiclo = table.Column<bool>(nullable: true),
					FinalMedidor = table.Column<bool>(nullable: true),
					FinalOrden = table.Column<bool>(nullable: true),
					CantidadManual = table.Column<bool>(nullable: true),
					OrdenCancelada = table.Column<bool>(nullable: true),
					BitAux1 = table.Column<bool>(nullable: true),
					BitAux2 = table.Column<bool>(nullable: true),
					Variable1 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					Variable2 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					Tipo = table.Column<int>(nullable: true),
					Editado = table.Column<bool>(nullable: true),
					Envase = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Desgloses", x => x.Id);
					table.ForeignKey(
						name: "FK_Desgloses_Envases",
						column: x => x.Envase,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Desgloses_Lotes",
						column: x => x.Lote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Desgloses_Medidores",
						column: x => x.MedidorId,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Desgloses_Ordenes",
						column: x => x.Orden,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Desgloses_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Desgloses_Ubicaciones",
						column: x => x.Ubicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Desgloses_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Disposiciones",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Serie = table.Column<int>(nullable: false),
					Orden = table.Column<int>(nullable: true),
					IdOld = table.Column<int>(nullable: false),
					Producto = table.Column<int>(nullable: true),
					Lote = table.Column<int>(nullable: true),
					Ubicacion = table.Column<int>(nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Servida = table.Column<float>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Tipo = table.Column<int>(nullable: true),
					CantidadPrincipal = table.Column<float>(nullable: true),
					TipoRegistro = table.Column<int>(nullable: true),
					Finalizado = table.Column<bool>(nullable: true),
					Porcentaje = table.Column<float>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					ordenacion = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					SerieOld = table.Column<int>(nullable: true),
					Formato = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Disposiciones", x => x.Id);
					table.ForeignKey(
						name: "FK_Disposiciones_Formatos",
						column: x => x.Formato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Disposiciones_Lotes",
						column: x => x.Lote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Disposiciones_Ordenes",
						column: x => x.Orden,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Disposiciones_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Disposiciones_Ubicaciones",
						column: x => x.Ubicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Disposiciones_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "OrdenesAutoInicio",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idOrden = table.Column<int>(nullable: false),
					idOrdenObjetivo = table.Column<int>(nullable: false),
					Activo = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OrdenesAutoInicio", x => x.id);
					table.ForeignKey(
						name: "FK_OrdenesAutoInicio_Ordenes",
						column: x => x.idOrden,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OrdenesAutoInicio_Ordenes1",
						column: x => x.idOrdenObjetivo,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "OrdenesDatosExtra",
				columns: table => new
				{
					id = table.Column<int>(nullable: false),
					KWConsumidosTotal = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, computedColumnSql: "([dbo].[OrdenKWConsumidosTotal]([id]))"),
					KWProducidosTotal = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, computedColumnSql: "([dbo].[OrdenKWProducidosTotal]([id]))"),
					KWTotal = table.Column<decimal>(type: "decimal(19, 4)", nullable: true, computedColumnSql: "([dbo].[OrdenKWProducidosTotal]([id])+[dbo].[OrdenKWConsumidosTotal]([id]))"),
					KWConsumidosEfectivo = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, computedColumnSql: "([dbo].[OrdenKWConsumidosEfectivo]([id]))"),
					KWProducidosEfectivo = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, computedColumnSql: "([dbo].[OrdenKWProducidosEfectivo]([id]))"),
					KWEfectivo = table.Column<decimal>(type: "decimal(19, 4)", nullable: true, computedColumnSql: "([dbo].[OrdenKWProducidosEfectivo]([id])+[dbo].[OrdenKWConsumidosEfectivo]([id]))"),
					CantidadProducida = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, computedColumnSql: "([dbo].[OrdenCantidadProducida]([id]))"),
					KWEfectivoTonelada = table.Column<decimal>(type: "decimal(18, 6)", nullable: true, computedColumnSql: "([dbo].[OrdenKWEfectivoCantidad]([id]))"),
					KWTotalTonelada = table.Column<decimal>(type: "decimal(18, 6)", nullable: true, computedColumnSql: "([dbo].[OrdenKWTotalCantidad]([id]))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OrdenesDatosExtra", x => x.id);
					table.ForeignKey(
						name: "FK_OrdenesDatosExtra_Ordenes",
						column: x => x.id,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "OrdenesRelacion",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idOrdenPadre = table.Column<int>(nullable: true),
					idOrdenHijo = table.Column<int>(nullable: true),
					Porcentaje = table.Column<decimal>(type: "numeric(8, 2)", nullable: true, defaultValueSql: "((100))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OrdenesRelacion", x => x.id);
					table.ForeignKey(
						name: "FK_OrdenesRelacion_Ordenes1",
						column: x => x.idOrdenHijo,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OrdenesRelacion_Ordenes",
						column: x => x.idOrdenPadre,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "OrdenesTransicionEstadosHistory",
				columns: table => new
				{
					IdAuto = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					InicioValidez = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
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

			migrationBuilder.CreateTable(
				name: "Resultados",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Serie = table.Column<int>(nullable: false),
					Orden = table.Column<int>(nullable: false),
					IdOld = table.Column<int>(nullable: false),
					Pesada = table.Column<int>(nullable: true),
					Ubicacion = table.Column<int>(nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Parcial = table.Column<float>(nullable: true),
					Proceso = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					Inicio = table.Column<DateTime>(type: "datetime", nullable: true),
					Fin = table.Column<DateTime>(type: "datetime", nullable: true),
					LoteNombre = table.Column<string>(maxLength: 30, nullable: true),
					Formato = table.Column<int>(nullable: true),
					Lote = table.Column<int>(nullable: true),
					Producto = table.Column<int>(nullable: true),
					Ciclo = table.Column<int>(nullable: true),
					Medidor = table.Column<int>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					CantidadPrincipal = table.Column<float>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					PosicionDosificacion = table.Column<int>(nullable: true),
					Regularizado = table.Column<bool>(nullable: true),
					TipoPesada = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					PesoAcumuladoBascula = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					NumCorreccion = table.Column<int>(nullable: true),
					Destino = table.Column<int>(nullable: true),
					Temperatura = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					Humedad = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					Ph = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					TiempoEfectivo = table.Column<int>(nullable: true),
					TiempoTotal = table.Column<int>(nullable: true),
					KwhEfectivo = table.Column<decimal>(type: "decimal(18, 5)", nullable: true),
					KWhTotal = table.Column<decimal>(type: "decimal(18, 5)", nullable: true),
					IndicadorId = table.Column<int>(nullable: true),
					MultiDosiId = table.Column<int>(nullable: true),
					TotalCiclos = table.Column<int>(nullable: true),
					Camino = table.Column<int>(nullable: true),
					OperacionId = table.Column<int>(nullable: true),
					ValidacionId = table.Column<int>(nullable: true),
					TemperaturaId = table.Column<int>(nullable: true),
					PhId = table.Column<int>(nullable: true),
					FinalSecuencia = table.Column<bool>(nullable: true),
					FinalCiclo = table.Column<bool>(nullable: true),
					FinalMedidor = table.Column<bool>(nullable: true),
					FinalOrden = table.Column<bool>(nullable: true),
					CantidadManual = table.Column<bool>(nullable: true),
					OrdenCancelada = table.Column<bool>(nullable: true),
					BitAux1 = table.Column<bool>(nullable: true),
					BitAux2 = table.Column<bool>(nullable: true),
					Variable1 = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					Variable2 = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					TimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
					DuracionStamp = table.Column<int>(nullable: true),
					idUsuario = table.Column<int>(nullable: true),
					Editado = table.Column<bool>(nullable: true),
					IdDosificacion = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Resultados", x => x.Id);
					table.ForeignKey(
						name: "FK_Resultados_Formatos",
						column: x => x.Formato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Resultados_Lotes",
						column: x => x.Lote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Resultados_Medidores",
						column: x => x.Medidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Resultados_Ordenes",
						column: x => x.Orden,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Resultados_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Resultados_Ubicaciones",
						column: x => x.Ubicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Resultados_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

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

			migrationBuilder.CreateTable(
				name: "StocksReserva",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idOrden = table.Column<int>(nullable: true),
					idEntradasLineas = table.Column<int>(nullable: true),
					idSalidasLineas = table.Column<int>(nullable: true),
					idSalidasLineasMedic = table.Column<int>(nullable: true),
					idLote = table.Column<int>(nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Activo = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
					FechaServido = table.Column<DateTime>(type: "datetime", nullable: true),
					CantidadReservada = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					idProducto = table.Column<int>(nullable: true),
					idUbicacion = table.Column<int>(nullable: true),
					idStock = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_StocksReserva", x => x.id);
					table.ForeignKey(
						name: "FK_StocksReserva_EntradasLineas",
						column: x => x.idEntradasLineas,
						principalTable: "EntradasLineas",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_StocksReserva_Lotes",
						column: x => x.idLote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_StocksReserva_Ordenes",
						column: x => x.idOrden,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_StocksReserva_Productos",
						column: x => x.idProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_StocksReserva_SalidasLinias",
						column: x => x.idSalidasLineas,
						principalTable: "SalidasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_StocksReserva_SalidasLiniasMedicaciones",
						column: x => x.idSalidasLineasMedic,
						principalTable: "SalidasLiniasMedicaciones",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_StocksReserva_Stocks",
						column: x => x.idStock,
						principalTable: "Stocks",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_StocksReserva_Ubicaciones",
						column: x => x.idUbicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Tarjetas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Valor = table.Column<string>(maxLength: 50, nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					idOld = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					IdOrdenActual = table.Column<int>(nullable: true),
					IdLinEntrada = table.Column<int>(nullable: true),
					IdLinSalida = table.Column<int>(nullable: true),
					PermisoArcosDesinfeccion = table.Column<bool>(nullable: true),
					Ordenacion = table.Column<int>(nullable: true),
					Referencia = table.Column<string>(maxLength: 128, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Tarjetas", x => x.Id);
					table.ForeignKey(
						name: "FK_Tarjetas_EntradasLineas",
						column: x => x.IdLinEntrada,
						principalTable: "EntradasLineas",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Tarjetas_ordenes",
						column: x => x.IdOrdenActual,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Tarjetas_SalidasLinias",
						column: x => x.IdLinSalida,
						principalTable: "SalidasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Choferes",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Importado = table.Column<bool>(nullable: true),
					CIF = table.Column<string>(maxLength: 14, nullable: true),
					Direccion = table.Column<string>(maxLength: 50, nullable: true),
					CodigoPostal = table.Column<string>(maxLength: 5, nullable: true),
					Poblacion = table.Column<string>(maxLength: 50, nullable: true),
					Provincia = table.Column<int>(nullable: true),
					Pais = table.Column<int>(nullable: true),
					Telefono = table.Column<string>(maxLength: 20, nullable: true),
					Refrescado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					idOld = table.Column<int>(nullable: true),
					Tarjeta = table.Column<int>(nullable: true),
					Activo = table.Column<bool>(nullable: true, defaultValueSql: "((1))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Choferes", x => x.Id);
					table.ForeignKey(
						name: "FK_Choferes_Paises",
						column: x => x.Pais,
						principalTable: "Paises",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Choferes_Provincias",
						column: x => x.Provincia,
						principalTable: "Provincias",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Choferes_SalidasViajes",
						column: x => x.Tarjeta,
						principalTable: "Tarjetas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Vehiculos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Matricula = table.Column<string>(maxLength: 10, nullable: true),
					Remolque = table.Column<string>(maxLength: 10, nullable: true),
					Tara = table.Column<float>(nullable: true),
					Chofer = table.Column<int>(nullable: true),
					Tarjeta = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Refrescado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Activo = table.Column<bool>(nullable: true),
					Posicion = table.Column<int>(nullable: true),
					EmpresaTransporte = table.Column<int>(nullable: true),
					PesoMaximo = table.Column<int>(nullable: true),
					idOld = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Vehiculos", x => x.Id);
					table.ForeignKey(
						name: "FK_Vehiculos_Choferes",
						column: x => x.Chofer,
						principalTable: "Choferes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Vehiculos_EmpresasTransporte",
						column: x => x.EmpresaTransporte,
						principalTable: "EmpresasTransporte",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Vehiculos_Tarjetas",
						column: x => x.Tarjeta,
						principalTable: "Tarjetas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "CertificadoDesinfeccion",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Serie = table.Column<int>(nullable: true),
					Numero = table.Column<int>(nullable: true),
					NRegistroCentro = table.Column<string>(maxLength: 50, nullable: true),
					Responsable = table.Column<string>(maxLength: 50, nullable: true),
					DNIResponsable = table.Column<string>(maxLength: 10, nullable: true),
					NombreCentro = table.Column<string>(maxLength: 50, nullable: true),
					fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					idCamion = table.Column<int>(nullable: true),
					Matricula = table.Column<string>(maxLength: 15, nullable: true),
					Remolque = table.Column<string>(maxLength: 15, nullable: true),
					Conductor = table.Column<string>(maxLength: 50, nullable: true),
					Desinfectante = table.Column<string>(maxLength: 50, nullable: true),
					Precinto = table.Column<string>(maxLength: 50, nullable: true),
					FechaCertificado = table.Column<DateTime>(type: "datetime", nullable: true),
					idTransportista = table.Column<int>(nullable: true),
					idOrden = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CertificadoDesinfeccion", x => x.id);
					table.ForeignKey(
						name: "FK_CertificadoDesinfeccion_Series",
						column: x => x.Serie,
						principalTable: "Series",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_CertificadoDesinfeccion_Vehiculos",
						column: x => x.idCamion,
						principalTable: "Vehiculos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_CertificadoDesinfeccion_Ordenes",
						column: x => x.idOrden,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_CertificadoDesinfeccion_Choferes",
						column: x => x.idTransportista,
						principalTable: "Choferes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Entradas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Serie = table.Column<int>(nullable: false),
					Numero = table.Column<int>(nullable: false),
					FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaPrevista = table.Column<DateTime>(type: "datetime", nullable: true),
					idVehiculo = table.Column<int>(nullable: true),
					idChofer = table.Column<int>(nullable: true),
					idProveedor = table.Column<int>(nullable: true),
					idTarjeta = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					EstadoTransito = table.Column<int>(nullable: true),
					MatriculaCamion = table.Column<string>(maxLength: 15, nullable: true),
					NombreConductor = table.Column<string>(maxLength: 50, nullable: true),
					Observaciones = table.Column<string>(maxLength: 500, nullable: true),
					idEmpresaTransporte = table.Column<int>(nullable: true),
					LedControlDocumental = table.Column<int>(nullable: true),
					MatriculaRemolque = table.Column<string>(maxLength: 15, nullable: true),
					Precio = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					FInicio = table.Column<DateTime>(type: "datetime", nullable: true),
					FFin = table.Column<DateTime>(type: "datetime", nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					ReferenciaCompra = table.Column<string>(maxLength: 20, nullable: true),
					PreDesinfeccion = table.Column<bool>(nullable: true),
					PostDesinfeccion = table.Column<bool>(nullable: true),
					PreDesinfeccionOK = table.Column<bool>(nullable: true),
					PostDesinfeccionOK = table.Column<bool>(nullable: true),
					exportado = table.Column<bool>(nullable: false),
					Importado = table.Column<bool>(nullable: false),
					DUA = table.Column<string>(maxLength: 50, nullable: true),
					Factura = table.Column<string>(maxLength: 20, nullable: true),
					Albaran = table.Column<string>(maxLength: 20, nullable: true),
					CoeficienteRendimiento = table.Column<int>(nullable: true),
					AceptacionDestinoFinal = table.Column<string>(maxLength: 100, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Entradas", x => x.id);
					table.ForeignKey(
						name: "FK_Entradas_Series",
						column: x => x.Serie,
						principalTable: "Series",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Entradas_Choferes",
						column: x => x.idChofer,
						principalTable: "Choferes",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Entradas_EmpresasTransporte",
						column: x => x.idEmpresaTransporte,
						principalTable: "EmpresasTransporte",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Entradas_Proveedores",
						column: x => x.idProveedor,
						principalTable: "Proveedores",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Entradas_Tarjetas",
						column: x => x.idTarjeta,
						principalTable: "Tarjetas",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Entradas_Vehiculos",
						column: x => x.idVehiculo,
						principalTable: "Vehiculos",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "SalidasViajes",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					MatriculaRemolque = table.Column<string>(maxLength: 15, nullable: true),
					idVehiculo = table.Column<int>(nullable: true),
					idChofer = table.Column<int>(nullable: true),
					idTarjeta = table.Column<int>(nullable: true),
					EstadoTransito = table.Column<int>(nullable: true),
					MatriculaCamion = table.Column<string>(maxLength: 15, nullable: true),
					NombreConductor = table.Column<string>(maxLength: 50, nullable: true),
					Observaciones = table.Column<string>(maxLength: 500, nullable: true),
					idEmpresaTransporte = table.Column<int>(nullable: true),
					FInicioTransito = table.Column<DateTime>(type: "datetime", nullable: true),
					FFinalTransito = table.Column<DateTime>(type: "datetime", nullable: true),
					FInicioViaje = table.Column<DateTime>(type: "datetime", nullable: true),
					FFinViaje = table.Column<DateTime>(type: "datetime", nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaPrevista = table.Column<DateTime>(type: "datetime", nullable: true),
					Numero = table.Column<int>(nullable: false),
					idSerie = table.Column<int>(nullable: false),
					Estado = table.Column<int>(nullable: true),
					PreDesinfeccion = table.Column<bool>(nullable: true),
					PostDesinfeccion = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: false),
					Importado = table.Column<bool>(nullable: false),
					ErrorExportacion = table.Column<string>(maxLength: 1000, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SalidasViajes", x => x.id);
					table.ForeignKey(
						name: "FK_SalidasViajes_Choferes",
						column: x => x.idChofer,
						principalTable: "Choferes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasViajes_EmpresasTransporte",
						column: x => x.idEmpresaTransporte,
						principalTable: "EmpresasTransporte",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasViajes_Series",
						column: x => x.idSerie,
						principalTable: "Series",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasViajes_Tarjetas",
						column: x => x.idTarjeta,
						principalTable: "Tarjetas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SalidasViajes_Vehiculos",
						column: x => x.idVehiculo,
						principalTable: "Vehiculos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Salidas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Observaciones = table.Column<string>(nullable: true),
					idSerie = table.Column<int>(nullable: false),
					Codigo = table.Column<int>(nullable: false),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					IdDepartamento = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					idCliente = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					Comentario = table.Column<string>(nullable: true),
					FechaPrevista = table.Column<DateTime>(type: "datetime", nullable: true),
					FInicio = table.Column<DateTime>(type: "datetime", nullable: true),
					FFin = table.Column<DateTime>(type: "datetime", nullable: true),
					idViaje = table.Column<int>(nullable: true),
					Precio = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ReferenciaVenta = table.Column<string>(maxLength: 20, nullable: true),
					Exportado = table.Column<bool>(nullable: false),
					Importado = table.Column<bool>(nullable: false),
					ErrorExportacion = table.Column<string>(maxLength: 1000, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Salidas", x => x.id);
					table.ForeignKey(
						name: "FK_Salidas_Departamentos",
						column: x => x.IdDepartamento,
						principalTable: "Departamentos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Salidas_Clientes",
						column: x => x.idCliente,
						principalTable: "Clientes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Salidas_Series",
						column: x => x.idSerie,
						principalTable: "Series",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Salidas_SalidasViajes",
						column: x => x.idViaje,
						principalTable: "SalidasViajes",
						principalColumn: "id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "Formulas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Referencia = table.Column<string>(maxLength: 20, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Medida = table.Column<int>(nullable: true),
					Total = table.Column<float>(nullable: true),
					Producto = table.Column<int>(nullable: true),
					Formato = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Estado = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Familia = table.Column<int>(nullable: true),
					Departamento = table.Column<int>(nullable: true),
					Original = table.Column<int>(nullable: true),
					Modulo = table.Column<int>(nullable: true),
					Mezclas = table.Column<float>(nullable: true),
					Recalculado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Medicamento = table.Column<bool>(nullable: true),
					FechaFin = table.Column<DateTime>(type: "datetime", nullable: true),
					idRefERP = table.Column<string>(maxLength: 20, nullable: true),
					idOld = table.Column<int>(nullable: true),
					IsDeleted = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Formulas", x => x.Id);
					table.ForeignKey(
						name: "FK_Formulas_Departamentos",
						column: x => x.Departamento,
						principalTable: "Departamentos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Formulas_Familias",
						column: x => x.Familia,
						principalTable: "Familias",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Formulas_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Formularios",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Formula = table.Column<int>(nullable: false),
					Producto = table.Column<int>(nullable: true),
					Principal = table.Column<bool>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Medicacion = table.Column<int>(nullable: true),
					idOld = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Formularios", x => x.Id);
					table.ForeignKey(
						name: "FK_Formularios_Formulas",
						column: x => x.Formula,
						principalTable: "Formulas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Formularios_Medicaciones",
						column: x => x.Medicacion,
						principalTable: "Medicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Formularios_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Incompatibilidades",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Formula = table.Column<int>(nullable: false),
					Producto = table.Column<int>(nullable: true),
					Tipo = table.Column<int>(nullable: false),
					NumeroMezclas = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					idOld = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Incompatibilidades", x => x.Id);
					table.ForeignKey(
						name: "FK_Incompatibilidades_Formulas",
						column: x => x.Formula,
						principalTable: "Formulas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Incompatibilidades_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Versiones",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Formula = table.Column<int>(nullable: false),
					IdOld = table.Column<int>(nullable: false),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Estado = table.Column<int>(nullable: true),
					VersionOriginal = table.Column<int>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Refrescado = table.Column<bool>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Recalculado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					UltimaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					LimitePesoCiclo = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					LimpiezaPosteriorObligada = table.Column<bool>(nullable: true),
					Caminos = table.Column<int>(nullable: true),
					FechaFin = table.Column<DateTime>(type: "datetime", nullable: true),
					RefErp = table.Column<string>(maxLength: 20, nullable: true),
					comentarios = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Versiones", x => x.Id);
					table.ForeignKey(
						name: "FK_Versiones_Formulas_Formula",
						column: x => x.Formula,
						principalTable: "Formulas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Versiones_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Modulos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Departamento = table.Column<int>(nullable: true),
					Sesion = table.Column<int>(nullable: true),
					Formato = table.Column<int>(nullable: true),
					Envase = table.Column<int>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Maquinaria = table.Column<bool>(nullable: true),
					Simultaneos = table.Column<int>(nullable: true),
					Controlado = table.Column<bool>(nullable: true),
					GenerarComprovacionOrigenVacio = table.Column<bool>(nullable: false),
					Manual = table.Column<bool>(nullable: true),
					OptimizarPesada = table.Column<bool>(nullable: true),
					ControlEntradas = table.Column<bool>(nullable: true),
					ControlSalidas = table.Column<bool>(nullable: true),
					OrigenDefecto = table.Column<int>(nullable: true),
					DestinoDefecto = table.Column<int>(nullable: true),
					EstadoAlarma = table.Column<bool>(nullable: true),
					Duplicidad = table.Column<bool>(nullable: true),
					Alternativas = table.Column<bool>(nullable: true),
					CambioDestino = table.Column<bool>(nullable: true),
					TipoProducto = table.Column<int>(nullable: true),
					ControlUbicacion = table.Column<bool>(nullable: true),
					ImprimirParte = table.Column<bool>(nullable: true),
					ImprimirOrden = table.Column<bool>(nullable: true),
					ImprimirEtiqueta = table.Column<bool>(nullable: true),
					InicioAutomatico = table.Column<bool>(nullable: true),
					DetenerAutomatico = table.Column<bool>(nullable: true),
					FinAutomatico = table.Column<bool>(nullable: true),
					EsperarServida = table.Column<bool>(nullable: true),
					Etiqueta = table.Column<int>(nullable: true),
					TipoEtiqueta = table.Column<int>(nullable: true),
					CantidadCiclo = table.Column<float>(nullable: true),
					PermitirMuestras = table.Column<bool>(nullable: true),
					MostrarMateriaPrima = table.Column<bool>(nullable: true),
					MostrarSemielaborado = table.Column<bool>(nullable: true),
					MostrarProductoTerminado = table.Column<bool>(nullable: true),
					ProductoDestino = table.Column<bool>(nullable: true),
					Premezclas = table.Column<bool>(nullable: true),
					PermitirCancelar = table.Column<bool>(nullable: true),
					ProcesoVisible = table.Column<bool>(nullable: true),
					GananciaUnidad = table.Column<int>(nullable: true),
					Ganancia = table.Column<float>(nullable: true),
					EnvaseOrigen = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: false),
					TransporteInicial = table.Column<bool>(nullable: true),
					Confirmar = table.Column<bool>(nullable: true),
					MostrarFormula = table.Column<bool>(nullable: true),
					AvisoCambioSilo = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					TipoMensaje = table.Column<int>(nullable: true),
					ModuloAscendiente = table.Column<int>(nullable: true),
					ComponentesAsignados = table.Column<bool>(nullable: true),
					MedidorAscendientes = table.Column<int>(nullable: true),
					UnidadDosificacion = table.Column<int>(nullable: true),
					ModuloContinuo = table.Column<bool>(nullable: true),
					Velocidad = table.Column<float>(nullable: true),
					LoteObligatorio = table.Column<bool>(nullable: true),
					VerificarEnvio = table.Column<bool>(nullable: true),
					Proceso = table.Column<int>(nullable: true),
					CantidadTeoricaObligatoria = table.Column<bool>(nullable: true),
					CantidadRealObligatoria = table.Column<bool>(nullable: true),
					StockMinimo = table.Column<float>(nullable: true),
					FiltroOrigenes = table.Column<int>(nullable: true),
					FiltroDestinos = table.Column<int>(nullable: true),
					LotePlc = table.Column<string>(maxLength: 50, nullable: true),
					ControlTransito = table.Column<bool>(nullable: true),
					Bascula = table.Column<int>(nullable: true),
					ControlCapacidadSilos = table.Column<bool>(nullable: true),
					CrearOrdenesRelacionadas = table.Column<bool>(nullable: true),
					CiclosDefecto = table.Column<int>(nullable: true),
					MostrarConsumos = table.Column<bool>(nullable: true),
					ProponerSiloDestino = table.Column<bool>(nullable: true),
					MetodoLote = table.Column<int>(nullable: true),
					FormatoLote = table.Column<string>(maxLength: 50, nullable: true),
					PeriodoCaducidad = table.Column<int>(nullable: true),
					CaducidadAutomatica = table.Column<bool>(nullable: true),
					PermitirVariosDestinos = table.Column<bool>(nullable: true),
					MostrarEnCalendario = table.Column<bool>(nullable: true),
					OrdenProduccion = table.Column<int>(nullable: false),
					TipoModulo = table.Column<int>(nullable: false),
					idOld = table.Column<int>(nullable: true),
					RevisarOrigenes = table.Column<bool>(nullable: true),
					RevisarDestinos = table.Column<bool>(nullable: true),
					OpcConfigId = table.Column<int>(nullable: false),
					RolBase = table.Column<int>(nullable: true),
					CodBarrasLoteConfirmacion = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					VerBotonTaraACero = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					VerBotonBrutoACero = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					VerBotonSaltar = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					VerBotonParcial = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					VerBotonTeorico = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					VerBotonConfirmar = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PermitirCambiarLote = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PermitirCambiarProducto = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					VerBotonCambioLote = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PermitirDosificacionParcial = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					CodBarrasLoteConfirmacionParcial = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PermitirCambioNumCiclos = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					idPLC = table.Column<int>(nullable: false),
					EnviarReset = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					EnviarOrdenesAPLC = table.Column<bool>(nullable: true),
					ModoDebugServidor = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					ComprobarPlantilla = table.Column<bool>(nullable: true),
					idPlantillaBase = table.Column<int>(nullable: true),
					NecesitaMotores = table.Column<bool>(nullable: true),
					PLCOMarcha = table.Column<bool>(nullable: true),
					PLCOParo = table.Column<bool>(nullable: true),
					PLCOPausa = table.Column<bool>(nullable: true),
					PLCOReanudar = table.Column<bool>(nullable: true),
					PLCOResetear = table.Column<bool>(nullable: true),
					PLCDestinoIdActual = table.Column<int>(nullable: true),
					PLCOrdenNumActual = table.Column<int>(nullable: true),
					PLCTCiclosNumActual = table.Column<int>(nullable: true),
					PLCCaminoActual = table.Column<int>(nullable: true),
					PLCEstadoActual = table.Column<int>(nullable: false),
					PLCVariablesActual0 = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					PLCVariablesActual1 = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					PLCVariablesActual2 = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					PLCVariablesActual3 = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					PLCVariablesActual4 = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					PLCMedidoresIdSocios0 = table.Column<int>(nullable: true),
					PLCMedidoresIdSocios1 = table.Column<int>(nullable: true),
					PLCMedidoresIdSocios2 = table.Column<int>(nullable: true),
					PLCMedidoresIdSocios3 = table.Column<int>(nullable: true),
					PLCMedidoresIdSocios4 = table.Column<int>(nullable: true),
					PLCMedidoresIdSocios5 = table.Column<int>(nullable: true),
					PLCMedidoresIdSocios6 = table.Column<int>(nullable: true),
					PLCMedidoresIdSocios7 = table.Column<int>(nullable: true),
					PLCMedidoresIdSocios8 = table.Column<int>(nullable: true),
					PLCMedidoresIdSocios9 = table.Column<int>(nullable: true),
					IniciarEnServidor = table.Column<bool>(nullable: true),
					PLCPermisoSiguienteOrden = table.Column<bool>(nullable: true),
					PermitirOrdenesLimpieza = table.Column<bool>(nullable: true),
					LimpiezaProdFinalDiferente = table.Column<bool>(nullable: true),
					DuracionOrden = table.Column<decimal>(type: "numeric(18, 2)", nullable: true),
					idPlantillaLimpieza = table.Column<int>(nullable: true),
					ConOrigenes = table.Column<bool>(nullable: false),
					ConDestinos = table.Column<bool>(nullable: false),
					AjusteStockFinalOrden = table.Column<bool>(nullable: true),
					MinimoSiloResetUbi = table.Column<bool>(nullable: true),
					VaciarSilosMinimosFinOrden = table.Column<bool>(nullable: true),
					CaminosActivar = table.Column<bool>(nullable: true),
					CaminosMin = table.Column<int>(nullable: true),
					CaminosMax = table.Column<int>(nullable: true),
					CaminosDescripcion = table.Column<string>(nullable: true),
					ResituarEnServidor = table.Column<bool>(nullable: true),
					ProducidosDeConsumidos = table.Column<bool>(nullable: true),
					FinalizarNopAlarmas = table.Column<bool>(nullable: true),
					PermitirVariosOrigenes = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PermitirModoVolteo = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					ProdFinalDefecto = table.Column<int>(nullable: true),
					ImpEtiquetaMuestraFinal = table.Column<bool>(nullable: true),
					NoEnviarOrdenes = table.Column<bool>(nullable: true),
					ModuloAsociadoOrdenes1 = table.Column<int>(nullable: true),
					ModuloAsociadoOrdenes2 = table.Column<int>(nullable: true),
					CaminoDefecto = table.Column<int>(nullable: true),
					AjusteTiempoEfectivo = table.Column<bool>(nullable: true),
					SeleccionarCajones = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					IncompatComprobar = table.Column<bool>(nullable: true),
					MostrarEnGantt = table.Column<bool>(nullable: true),
					EstadoForzado = table.Column<int>(nullable: true),
					DisponibleOEE = table.Column<bool>(nullable: true),
					MedirOEE = table.Column<bool>(nullable: true),
					PermitirModoMantenimiento = table.Column<bool>(nullable: true),
					RequiereEnvase = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					ScadaDatos = table.Column<bool>(nullable: true),
					OEEKgHora = table.Column<decimal>(type: "decimal(15, 3)", nullable: true, defaultValueSql: "((0))"),
					ResetearIntegraModulo = table.Column<bool>(nullable: true),
					OPCEnvioFCaducidadVar1 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					OPCEnvioEan13Var2Var3 = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PermitirAlertas = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					GenerarLote = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Referencia = table.Column<string>(maxLength: 30, nullable: true),
					PermitirOrdenArranque = table.Column<bool>(nullable: false),
					PermitirAutoRespuesta = table.Column<bool>(nullable: false),
					PermitirMismoOrigenDestino = table.Column<bool>(nullable: false),
					EnviarIdCabOrden = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PermitirResetear = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
					GenerarAutoInicio = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					RecibirAutoInicio = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					CrearOrden = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					RequiereValidacion = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					VolteoHabilitarModoTiempo = table.Column<bool>(nullable: false),
					VolteoHabilitarVaciarOrigen = table.Column<bool>(nullable: false),
					VolteoHabilitarLlenarDestino = table.Column<bool>(nullable: false),
					AsignarProductoDestino = table.Column<bool>(nullable: false),
					IgnorarConsumidos = table.Column<bool>(nullable: false),
					IgnorarProducidos = table.Column<bool>(nullable: false),
					PlcEnabled = table.Column<bool>(nullable: false),
					NumValidaciones = table.Column<int>(nullable: false, defaultValueSql: "20"),
					PermitirPausar = table.Column<bool>(nullable: false),
					PermitirReanudar = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Modulos", x => x.Id);
					table.ForeignKey(
						name: "FK_Modulos_Departamentos",
						column: x => x.Departamento,
						principalTable: "Departamentos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Modulos_ModulosAsociadoOrden1",
						column: x => x.ModuloAsociadoOrdenes1,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Modulos_ModulosAsociadoOrden2",
						column: x => x.ModuloAsociadoOrdenes2,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Modulos_OpcConfig",
						column: x => x.OpcConfigId,
						principalTable: "OpcConfig",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Modulos_Ordenes",
						column: x => x.PLCOrdenNumActual,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Modulos_ProdFinal",
						column: x => x.ProdFinalDefecto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Modulos_UsuariosRoles",
						column: x => x.RolBase,
						principalTable: "UsuariosRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "CabOrdenes",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaFinal = table.Column<DateTime>(type: "datetime", nullable: true),
					Tipo = table.Column<int>(nullable: true),
					ProductoDestino = table.Column<int>(nullable: true),
					UbicacionDestino = table.Column<int>(nullable: true),
					LoteDestino = table.Column<int>(nullable: true),
					Prioridad = table.Column<int>(nullable: true),
					Formula = table.Column<int>(nullable: true),
					Modulo = table.Column<int>(nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 3)", nullable: true, defaultValueSql: "((0))"),
					Version = table.Column<int>(nullable: true),
					idOld = table.Column<int>(nullable: true),
					SerieOld = table.Column<int>(nullable: true),
					Entrada = table.Column<int>(nullable: true),
					ViajeSalida = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CabOrdenes", x => x.id);
					table.ForeignKey(
						name: "FK_CabOrdenes_Entradas",
						column: x => x.Entrada,
						principalTable: "Entradas",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_CabOrdenes_Formulas",
						column: x => x.Formula,
						principalTable: "Formulas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_CabOrdenes_Lotes",
						column: x => x.LoteDestino,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_CabOrdenes_Modulos",
						column: x => x.Modulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_CabOrdenes_Productos",
						column: x => x.ProductoDestino,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_CabOrdenes_Ubicaciones",
						column: x => x.UbicacionDestino,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_CabOrdenes_Versiones",
						column: x => x.Version,
						principalTable: "Versiones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_CabOrdenes_SalidasViajes",
						column: x => x.ViajeSalida,
						principalTable: "SalidasViajes",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Destinos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Modulo = table.Column<int>(nullable: false),
					Ubicacion = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					TraspasoAutomatico = table.Column<bool>(nullable: true),
					DestinoTraspasoAutomatico = table.Column<int>(nullable: true),
					DestinoVolteo = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Activo = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
					ComprobarProducto = table.Column<bool>(nullable: true, defaultValueSql: "((1))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Destinos", x => x.Id);
					table.ForeignKey(
						name: "FK_Destinos_Modulos",
						column: x => x.Modulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Destinos_Ubicaciones",
						column: x => x.Ubicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "FormulaProdModulo",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idFormulario = table.Column<int>(nullable: true),
					idModulo = table.Column<int>(nullable: true),
					idProducto = table.Column<int>(nullable: true),
					idUbicacion = table.Column<int>(nullable: true),
					ForzarModulo = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_FormulaProdModulo", x => x.id);
					table.ForeignKey(
						name: "FK_FormulaProdModulo_Formularios",
						column: x => x.idFormulario,
						principalTable: "Formularios",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_FormulaProdModulo_Modulos",
						column: x => x.idModulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_FormulaProdModulo_Productos",
						column: x => x.idProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_FormulaProdModulo_Ubicaciones",
						column: x => x.idUbicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "GMAO_ParadasConfiguracionModulos",
				columns: table => new
				{
					idParadaConfiguracion = table.Column<int>(nullable: false),
					idModulo = table.Column<int>(nullable: false),
					RequiereParar = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_ParadasConfiguracionModulos", x => new { x.idParadaConfiguracion, x.idModulo });
					table.ForeignKey(
						name: "FK_GMAO_ParadasConfiguracionModulos_Modulos",
						column: x => x.idModulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GMAO_ParadasConfiguracionModulos_GMAO_ParadasConfiguracion",
						column: x => x.idParadaConfiguracion,
						principalTable: "GMAO_ParadasConfiguracion",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "LogMovimientosStocks",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdProducto = table.Column<int>(nullable: true),
					IdLote = table.Column<int>(nullable: true),
					IdStock = table.Column<int>(nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					IdUbicacion = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Modulo = table.Column<int>(nullable: true),
					Medidor = table.Column<int>(nullable: true),
					TipoMovimiento = table.Column<int>(nullable: true),
					Operario = table.Column<int>(nullable: true),
					idOrden = table.Column<int>(nullable: true),
					Ciclo = table.Column<int>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					ErrorTxtExport = table.Column<string>(maxLength: 100, nullable: true),
					Comentario = table.Column<string>(maxLength: 500, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_LogMovimientosStocks", x => x.Id);
					table.ForeignKey(
						name: "FK_LogMovimientosStocks_Lotes",
						column: x => x.IdLote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_LogMovimientosStocks_Productos",
						column: x => x.IdProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_LogMovimientosStocks_Stocks_IdStock",
						column: x => x.IdStock,
						principalTable: "Stocks",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_LogMovimientosStocks_Ubicaciones",
						column: x => x.IdUbicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_LogMovimientosStocks_Medidores",
						column: x => x.Medidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_LogMovimientosStocks_Modulos",
						column: x => x.Modulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_LogMovimientosStocks_Usuarios",
						column: x => x.Operario,
						principalTable: "Usuarios",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_LogMovimientosStocks_Ordenes",
						column: x => x.idOrden,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "ModulosAscendentes",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Medidor = table.Column<int>(nullable: false),
					Ascendente = table.Column<int>(nullable: true),
					Origen = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					ArrastrarLote = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ModulosAscendentes", x => x.Id);
					table.ForeignKey(
						name: "FK_ModulosAscendentes_Modulos",
						column: x => x.Ascendente,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_ModulosAscendentes_Medidores",
						column: x => x.Medidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

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

			migrationBuilder.CreateTable(
				name: "ModulosIncompatibilidades",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ModuloBase = table.Column<int>(nullable: true),
					ModuloRelacionado = table.Column<int>(nullable: true),
					SiempreFlexible = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ModulosIncompatibilidades", x => x.Id);
					table.ForeignKey(
						name: "FK_ModulosIncompatibilidadesBase_ModulosBase",
						column: x => x.ModuloBase,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_ModulosIncompatibilidadesRelacionado_ModulosRelacionado",
						column: x => x.ModuloRelacionado,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "ModulosMotores",
				columns: table => new
				{
					ModuloId = table.Column<int>(nullable: false),
					MotorId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ModulosMotores", x => new { x.ModuloId, x.MotorId });
					table.ForeignKey(
						name: "FK_ModulosMotores_Modulos_ModuloId",
						column: x => x.ModuloId,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ModulosMotores_Motores_MotorId",
						column: x => x.MotorId,
						principalTable: "Motores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "ModulosTagsScada",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Modulo = table.Column<int>(nullable: true),
					TagIndex = table.Column<int>(nullable: true),
					Activo = table.Column<bool>(nullable: true),
					NombreMes = table.Column<string>(maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ModulosTagsScada", x => x.Id);
					table.ForeignKey(
						name: "FK_ModulosTagsScada_Modulos",
						column: x => x.Modulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "NetAlarmasAutomaticas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdModulo = table.Column<int>(nullable: true),
					IdMedidor = table.Column<int>(nullable: true),
					IdAlarmasTipo = table.Column<int>(nullable: true),
					IdNetAlarmasRespuesta = table.Column<int>(nullable: true),
					Activa = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					SegundosControl = table.Column<int>(nullable: true),
					Reintentos = table.Column<int>(nullable: true, defaultValueSql: "((1))"),
					IdUbicacion = table.Column<int>(nullable: true),
					ForzarFinalizacion = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_NetAlarmasAutomaticas", x => x.id);
					table.ForeignKey(
						name: "FK_NetAlarmasAutomaticas_NetAlarmasTipos",
						column: x => x.IdAlarmasTipo,
						principalTable: "NetAlarmasTipos",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_NetAlarmasAutomaticas_Medidores",
						column: x => x.IdMedidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_NetAlarmasAutomaticas_Modulos",
						column: x => x.IdModulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_NetAlarmasAutomaticas_NetAlarmasTiposRespuestas",
						column: x => x.IdNetAlarmasRespuesta,
						principalTable: "NetAlarmasTiposRespuestas",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_NetAlarmasAutomaticas_Ubicaciones",
						column: x => x.IdUbicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "OperCabPlantillas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 250, nullable: true),
					IdModulo = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OperCabPlantillas", x => x.Id);
					table.ForeignKey(
						name: "FK_OperCabPlantillas_Modulos",
						column: x => x.IdModulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "OperMotoresModulos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdOperMotor = table.Column<int>(nullable: true),
					IdModulo = table.Column<int>(nullable: true),
					IdMedidor = table.Column<int>(nullable: true),
					VerVariable = table.Column<bool>(nullable: true),
					TextoVariable = table.Column<string>(maxLength: 250, nullable: true),
					obligatorio = table.Column<bool>(nullable: true),
					ValorMaximo = table.Column<int>(nullable: true),
					ValorMinimo = table.Column<int>(nullable: true),
					TextoVariable2 = table.Column<string>(maxLength: 250, nullable: true),
					ValorMaximo2 = table.Column<int>(nullable: true),
					ValorMinimo2 = table.Column<int>(nullable: true),
					VerVariable2 = table.Column<bool>(nullable: true),
					ControlOrdenacion = table.Column<bool>(nullable: true),
					NumOrdenacion = table.Column<int>(nullable: true),
					ObligatorioConProductos = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OperMotoresModulos", x => x.Id);
					table.ForeignKey(
						name: "FK_OperMotoresModulos_Medidores",
						column: x => x.IdMedidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OperMotoresModulos_Modulos",
						column: x => x.IdModulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OperMotoresModulos_OperMotores",
						column: x => x.IdOperMotor,
						principalTable: "OperMotores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "SesionesModulo",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Modulo = table.Column<int>(nullable: false),
					Sesion = table.Column<int>(nullable: true),
					Visible = table.Column<bool>(nullable: true),
					Controlable = table.Column<bool>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SesionesModulo", x => x.Id);
					table.ForeignKey(
						name: "FK_SesionesModulo_Modulos",
						column: x => x.Modulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_SesionesModulo_Sesiones",
						column: x => x.Sesion,
						principalTable: "Sesiones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "TiempoLimpieza",
				columns: table => new
				{
					ModuloId = table.Column<int>(nullable: false),
					UbicacionId = table.Column<int>(nullable: false),
					Tiempo = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TiempoLimpieza", x => new { x.ModuloId, x.UbicacionId });
					table.ForeignKey(
						name: "FK_TiempoLimpieza_Modulos_ModuloId",
						column: x => x.ModuloId,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_TiempoLimpieza_Ubicaciones_UbicacionId",
						column: x => x.UbicacionId,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "UsuariosRolesModulos",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idRol = table.Column<int>(nullable: false),
					idModulo = table.Column<int>(nullable: false),
					AlarmasVer = table.Column<bool>(nullable: true),
					AlarmasResponder = table.Column<bool>(nullable: true),
					OrdenesVer = table.Column<bool>(nullable: true),
					OrdenesEditar = table.Column<bool>(nullable: true),
					OrdenesControlar = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UsuariosRolesModulos", x => x.Id);
					table.ForeignKey(
						name: "FK_UsuariosRolesModulos_Modulos",
						column: x => x.idModulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_UsuariosRolesModulos_UsuariosRoles",
						column: x => x.idRol,
						principalTable: "UsuariosRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Variables",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Modulo = table.Column<int>(nullable: false),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					ValorPlc = table.Column<string>(maxLength: 50, nullable: true),
					Defecto = table.Column<float>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Minimo = table.Column<float>(nullable: true),
					Maximo = table.Column<float>(nullable: true),
					Modificable = table.Column<bool>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					ValorPartePlc = table.Column<string>(maxLength: 50, nullable: true),
					Producto = table.Column<int>(nullable: true),
					Ubicacion = table.Column<int>(nullable: true),
					RegistrarEnParte = table.Column<bool>(nullable: true),
					RegularizarStock = table.Column<bool>(nullable: true),
					idOld = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Variables", x => x.Id);
					table.ForeignKey(
						name: "FK_Variables_Modulos",
						column: x => x.Modulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "VersionTPrevisto",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idVersion = table.Column<int>(nullable: false),
					idModulo = table.Column<int>(nullable: false),
					Tiempo = table.Column<decimal>(type: "numeric(18, 2)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_VersionTPrevisto", x => x.Id);
					table.ForeignKey(
						name: "FK_VersionTPrevisto_Modulos",
						column: x => x.idModulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VersionTPrevisto_Versiones",
						column: x => x.idVersion,
						principalTable: "Versiones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "DestinosMedidores",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idDestino = table.Column<int>(nullable: true),
					idMedidor = table.Column<int>(nullable: true),
					Incompatible = table.Column<bool>(nullable: true),
					Requerido = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_DestinosMedidores", x => x.id);
					table.ForeignKey(
						name: "FK_DestinosMedidores_Destinos",
						column: x => x.idDestino,
						principalTable: "Destinos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_DestinosMedidores_Medidores",
						column: x => x.idMedidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Componentes",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Version = table.Column<int>(nullable: false),
					Producto = table.Column<int>(nullable: true),
					Porcentaje = table.Column<float>(nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Tipo = table.Column<int>(nullable: true),
					Grupo = table.Column<int>(nullable: true),
					Formato = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Automatico = table.Column<bool>(nullable: true),
					TipoDosificacion = table.Column<int>(nullable: true),
					Modulo = table.Column<int>(nullable: true),
					Medidor = table.Column<int>(nullable: true),
					Orden = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					Exportado = table.Column<bool>(nullable: true),
					idOld = table.Column<int>(nullable: true),
					ToleranciaSuperior = table.Column<decimal>(type: "numeric(18, 2)", nullable: true),
					ToleranciaInferior = table.Column<decimal>(type: "numeric(18, 2)", nullable: true),
					PausaPosteriorDosificacion = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					DosificarProductoAnterior = table.Column<bool>(nullable: true),
					OperTiempo = table.Column<int>(nullable: true),
					OperMotor = table.Column<int>(nullable: true),
					OperAccion = table.Column<int>(nullable: true),
					OperVariable = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					TextoVariable = table.Column<string>(maxLength: 250, nullable: true),
					idPlantilla = table.Column<int>(nullable: true),
					OperVariable2 = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					IdTempControl = table.Column<int>(nullable: true),
					TempModo = table.Column<int>(nullable: true),
					MinAlarma = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					MaxAlarma = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					Consigna = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					Histeresys = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					ConsignaPausa = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					ZonaMuerta = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					DosiVariable1 = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					DosiVariable2 = table.Column<decimal>(type: "decimal(18, 3)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Componentes", x => x.Id);
					table.ForeignKey(
						name: "FK_Componentes_Formatos",
						column: x => x.Formato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Componentes_TempControles",
						column: x => x.IdTempControl,
						principalTable: "TempControles",
						principalColumn: "id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Componentes_Medidores",
						column: x => x.Medidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Componentes_Modulos",
						column: x => x.Modulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Componentes_OperAcciones",
						column: x => x.OperAccion,
						principalTable: "OperAcciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Componentes_OperMotores",
						column: x => x.OperMotor,
						principalTable: "OperMotores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Componentes_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Componentes_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Componentes_Versiones_Version",
						column: x => x.Version,
						principalTable: "Versiones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Componentes_OperCabPlantillas",
						column: x => x.idPlantilla,
						principalTable: "OperCabPlantillas",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "Dosificaciones",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Serie = table.Column<int>(nullable: false),
					Orden = table.Column<int>(nullable: false),
					IdOld = table.Column<int>(nullable: false),
					Producto = table.Column<int>(nullable: true),
					Formato = table.Column<int>(nullable: true),
					Proceso = table.Column<int>(nullable: true),
					Porcentaje = table.Column<decimal>(type: "decimal(28, 15)", nullable: true),
					Cantidad = table.Column<decimal>(type: "decimal(28, 15)", nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Servida = table.Column<float>(nullable: true),
					NumeroPesadas = table.Column<int>(nullable: true),
					Inicio = table.Column<DateTime>(type: "datetime", nullable: true),
					Fin = table.Column<DateTime>(type: "datetime", nullable: true),
					Tipo = table.Column<int>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Lote = table.Column<int>(nullable: true),
					Ubicacion = table.Column<int>(nullable: true),
					Grupo = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					Medidor = table.Column<int>(nullable: true),
					CantidadPrincipal = table.Column<decimal>(type: "decimal(28, 15)", nullable: true),
					TipoRegistro = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					PosicionDosificacion = table.Column<int>(nullable: true),
					CicloActual = table.Column<int>(nullable: true),
					CantidadActual = table.Column<float>(nullable: true),
					UbicacionActual = table.Column<int>(nullable: true),
					ProductoActual = table.Column<int>(nullable: true),
					LoteActual = table.Column<int>(nullable: true),
					DosificacionActual = table.Column<int>(nullable: true),
					IdModulo = table.Column<int>(nullable: true),
					EstadoActual = table.Column<int>(nullable: true),
					ToleranciaSuperior = table.Column<decimal>(type: "numeric(18, 2)", nullable: true),
					ToleranciaInferior = table.Column<decimal>(type: "numeric(18, 2)", nullable: true),
					PausaPosteriorDosificacion = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					NumCorrecion = table.Column<int>(nullable: true),
					Afino = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					ConVibrador = table.Column<int>(nullable: true),
					VelocidadLenta = table.Column<int>(nullable: true),
					VelocidadRapida = table.Column<int>(nullable: true),
					IdOperMotor = table.Column<int>(nullable: true),
					IdOperAccion = table.Column<int>(nullable: true),
					OperVariable = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					TextoVariable = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
					OperTiempo = table.Column<int>(nullable: true),
					DosificarProductoAnterior = table.Column<bool>(nullable: true),
					PosicionDosificacionPLC = table.Column<int>(nullable: true),
					PosicionOperacionPLC = table.Column<int>(nullable: true),
					PosicionMultidosiPLC = table.Column<int>(nullable: true),
					PosicionTemperaturaPLC = table.Column<int>(nullable: true),
					idPlantilla = table.Column<int>(nullable: true),
					idFormulaOriginal = table.Column<int>(nullable: true),
					idComponenteOriginal = table.Column<int>(nullable: true),
					idVersionOriginal = table.Column<int>(nullable: true),
					OperVariable2 = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					Comentario = table.Column<string>(maxLength: 500, nullable: true),
					OrigenERP = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					IdTempControl = table.Column<int>(nullable: true),
					TempModo = table.Column<int>(nullable: true),
					MinAlarma = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					MaxAlarma = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					Consigna = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					Histeresys = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					ConsignaPausa = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					ZonaMuerta = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					DosiVariable1 = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					DosiVariable2 = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					RefERP1 = table.Column<string>(maxLength: 20, nullable: true),
					RefERP2 = table.Column<string>(maxLength: 20, nullable: true),
					RefERP3 = table.Column<string>(maxLength: 20, nullable: true),
					TipoAutoRespuesta = table.Column<int>(nullable: false),
					DosiVariable3 = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					Prioridad = table.Column<int>(nullable: true),
					idMedGenerador = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Dosificaciones", x => x.Id);
					table.ForeignKey(
						name: "FK_Dosificaciones_Formatos",
						column: x => x.Formato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Dosificaciones_Modulos",
						column: x => x.IdModulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Dosificaciones_OperAcciones",
						column: x => x.IdOperAccion,
						principalTable: "OperAcciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Dosificaciones_OperMotores",
						column: x => x.IdOperMotor,
						principalTable: "OperMotores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Dosificaciones_TempControles",
						column: x => x.IdTempControl,
						principalTable: "TempControles",
						principalColumn: "id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Dosificaciones_Lotes",
						column: x => x.Lote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Dosificaciones_LotesActual",
						column: x => x.LoteActual,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Dosificaciones_Medidores",
						column: x => x.Medidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Dosificaciones_Ordenes",
						column: x => x.Orden,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Dosificaciones_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Dosificaciones_ProductosActual",
						column: x => x.ProductoActual,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Dosificaciones_Ubicaciones",
						column: x => x.Ubicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Dosificaciones_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Dosificaciones_MedidoresDosificaciones",
						column: x => x.idMedGenerador,
						principalTable: "MedidoresDosificaciones",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Dosificaciones_OperCabPlantillas",
						column: x => x.idPlantilla,
						principalTable: "OperCabPlantillas",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "OperPlantillas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					OperTiempo = table.Column<int>(nullable: true),
					IdOperMotor = table.Column<int>(nullable: true),
					IdOperAccion = table.Column<int>(nullable: true),
					OperVariable = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					Medidor = table.Column<int>(nullable: true),
					TextoVariable = table.Column<string>(maxLength: 250, nullable: true),
					IdOperCabPlantillas = table.Column<int>(nullable: true),
					TipoDosificacion = table.Column<int>(nullable: true),
					IdProducto = table.Column<int>(nullable: true),
					IdUbicacion = table.Column<int>(nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					DosificarProductoAnterior = table.Column<bool>(nullable: true),
					KGxSeg = table.Column<int>(nullable: true),
					KGxSegPesoAcumulado = table.Column<bool>(nullable: true),
					KGxSegPesoAntDosificacion = table.Column<bool>(nullable: true),
					Ordenacion = table.Column<int>(nullable: true),
					Porcentaje = table.Column<decimal>(type: "decimal(28, 15)", nullable: true),
					OperVariable2 = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					Comentario = table.Column<string>(maxLength: 500, nullable: true),
					IdTempControl = table.Column<int>(nullable: true),
					TempModo = table.Column<int>(nullable: true),
					MinAlarma = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					MaxAlarma = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					Consigna = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					Histeresys = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					ConsignaPausa = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					ZonaMuerta = table.Column<decimal>(type: "decimal(9, 4)", nullable: true),
					DosiVariable1 = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					DosiVariable2 = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					Prioridad = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OperPlantillas", x => x.Id);
					table.ForeignKey(
						name: "FK_OperPlantillas_OperAcciones",
						column: x => x.IdOperAccion,
						principalTable: "OperAcciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_OperPlantillas_OperCabPlantillas",
						column: x => x.IdOperCabPlantillas,
						principalTable: "OperCabPlantillas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_OperPlantillas_OperMotores",
						column: x => x.IdOperMotor,
						principalTable: "OperMotores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_OperPlantillas_Productos",
						column: x => x.IdProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OperPlantillas_TempControles",
						column: x => x.IdTempControl,
						principalTable: "TempControles",
						principalColumn: "id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_OperPlantillas_Ubicaciones",
						column: x => x.IdUbicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_OperPlantillas_Medidores",
						column: x => x.Medidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "ProductosOperCabPlantillas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdProducto = table.Column<int>(nullable: false),
					IdOperCabPlantilla = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ProductosOperCabPlantillas", x => x.Id);
					table.ForeignKey(
						name: "FK_ProductosOperCabPlantillas_OperCabPlantillas",
						column: x => x.IdOperCabPlantilla,
						principalTable: "OperCabPlantillas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_ProductosOperCabPlantillas_Productos",
						column: x => x.IdProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Valores",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Serie = table.Column<int>(nullable: false),
					Orden = table.Column<int>(nullable: false),
					IdOld = table.Column<int>(nullable: false),
					Variable = table.Column<int>(nullable: true),
					Valor = table.Column<float>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					SerieOld = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Valores", x => x.Id);
					table.ForeignKey(
						name: "FK_Valores_Ordenes",
						column: x => x.Orden,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Valores_Variables",
						column: x => x.Variable,
						principalTable: "Variables",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "MultiDosificaciones",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idDosificacion = table.Column<int>(nullable: true),
					idUbicacion = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_MultiDosificaciones", x => x.id);
					table.ForeignKey(
						name: "FK_MultiDosificaciones_Dosificaciones",
						column: x => x.idDosificacion,
						principalTable: "Dosificaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_MultiDosificaciones_Ubicaciones",
						column: x => x.idUbicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "NetAlarmas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdPlc = table.Column<int>(nullable: true),
					idOrden = table.Column<int>(nullable: true),
					idDosificacion = table.Column<int>(nullable: true),
					idMedidor = table.Column<int>(nullable: true),
					IdModulo = table.Column<int>(nullable: true),
					TextoOpcional = table.Column<string>(maxLength: 250, nullable: true),
					IdError = table.Column<int>(nullable: true),
					FechaError = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaRecibido = table.Column<DateTime>(type: "datetime", nullable: true),
					Respuesta = table.Column<int>(nullable: true),
					RespPC = table.Column<string>(maxLength: 250, nullable: true),
					RespUsuario = table.Column<string>(maxLength: 250, nullable: true),
					RespFecha = table.Column<DateTime>(type: "datetime", nullable: true),
					RespTxt = table.Column<string>(maxLength: 250, nullable: true),
					txtError = table.Column<string>(maxLength: 250, nullable: true),
					Opcion1 = table.Column<string>(maxLength: 250, nullable: true),
					Opcion2 = table.Column<string>(maxLength: 250, nullable: true),
					Opcion4 = table.Column<string>(maxLength: 250, nullable: true),
					Opcion3 = table.Column<string>(maxLength: 250, nullable: true),
					Tratada = table.Column<bool>(nullable: false),
					Visualizada = table.Column<bool>(nullable: false),
					idUbicacion = table.Column<int>(nullable: true),
					Finalizada = table.Column<bool>(nullable: false),
					IdSeccion = table.Column<int>(nullable: true),
					IdGrupo = table.Column<int>(nullable: true),
					Ciclo_Num = table.Column<int>(nullable: true),
					IdOrigen = table.Column<int>(nullable: true),
					IdDestino = table.Column<int>(nullable: true),
					IdOrigenPropuesto = table.Column<int>(nullable: true),
					IdDestinoPropuesto = table.Column<int>(nullable: true),
					Ciclo_NumPropuesto = table.Column<int>(nullable: true),
					RequiereRespuesta = table.Column<bool>(nullable: true),
					ConsultarScada = table.Column<bool>(nullable: true),
					InfoAdicScada = table.Column<int>(nullable: true),
					ArgumentoPropuesto = table.Column<int>(nullable: true),
					Enviada = table.Column<bool>(nullable: true),
					TextoAdicional = table.Column<string>(maxLength: 20, nullable: true),
					FechaErrorMilisegundos = table.Column<int>(nullable: true),
					Respondido = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					RespIdOrigen = table.Column<int>(nullable: true),
					RespIdDestino = table.Column<int>(nullable: true),
					RespNumCiclos = table.Column<int>(nullable: true),
					RespIdOrden = table.Column<int>(nullable: true),
					RespArgumentos0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true, defaultValueSql: "((0))"),
					RespArgumentos1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true, defaultValueSql: "((0))"),
					RespArgumentos2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true, defaultValueSql: "((0))"),
					RespArgumentos3 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true, defaultValueSql: "((0))"),
					RespVariables0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true, defaultValueSql: "((0))"),
					RespVariables1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true, defaultValueSql: "((0))"),
					RespVariables2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true, defaultValueSql: "((0))"),
					RespVariables3 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true, defaultValueSql: "((0))"),
					RespVariables4 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true, defaultValueSql: "((0))"),
					RespIdProducto = table.Column<int>(nullable: true),
					RespIdLote = table.Column<int>(nullable: true),
					Interno = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					TipoInterno = table.Column<int>(nullable: true),
					PesadaNum = table.Column<int>(nullable: true),
					MostrarAUsuario = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Deshabilitada = table.Column<bool>(nullable: true),
					InfoAdicional1 = table.Column<decimal>(type: "numeric(18, 8)", nullable: true),
					InfoAdicional2 = table.Column<decimal>(type: "numeric(18, 8)", nullable: true),
					InfoAdicional3 = table.Column<decimal>(type: "numeric(18, 8)", nullable: true),
					InfoAdicional4 = table.Column<decimal>(type: "numeric(18, 8)", nullable: true),
					InfoAdicional5 = table.Column<decimal>(type: "numeric(18, 8)", nullable: true),
					FechaErrorMES = table.Column<DateTime>(type: "datetime", nullable: true),
					idMotor = table.Column<int>(nullable: true),
					idOpc = table.Column<int>(nullable: true),
					RevisadoAlertas = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					AlertaGestionada = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					Hash = table.Column<string>(maxLength: 32, nullable: true),
					OpcConfigId = table.Column<int>(nullable: true),
					PostEnvioProcesada = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_NetAlarmas", x => x.Id);
					table.ForeignKey(
						name: "FK_NetAlarmas_Ubicaciones2",
						column: x => x.IdDestino,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_NetAlarmas_Ubicaciones4",
						column: x => x.IdDestinoPropuesto,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_NetAlarmas_NetAlarmasTipos",
						column: x => x.IdError,
						principalTable: "NetAlarmasTipos",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_NetAlarmas_SeccionesGrupos",
						column: x => x.IdGrupo,
						principalTable: "SeccionesGrupos",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_NetAlarmas_Modulos",
						column: x => x.IdModulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_NetAlarmas_Ubicaciones1",
						column: x => x.IdOrigen,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_NetAlarmas_Ubicaciones3",
						column: x => x.IdOrigenPropuesto,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_NetAlarmas_Secciones",
						column: x => x.IdSeccion,
						principalTable: "Secciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK__NetAlarma__OpcCo__5AF96FB1",
						column: x => x.OpcConfigId,
						principalTable: "OpcConfig",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_NetAlarmas_Lotes",
						column: x => x.RespIdLote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_NetAlarmas_Productos",
						column: x => x.RespIdProducto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_NetAlarmas_NetAlarmasRespuestas",
						column: x => x.Respuesta,
						principalTable: "NetAlarmasRespuestas",
						principalColumn: "id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_NetAlarmas_Dosificaciones",
						column: x => x.idDosificacion,
						principalTable: "Dosificaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_NetAlarmas_Medidores",
						column: x => x.idMedidor,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_NetAlarmas_Ordenes",
						column: x => x.idOrden,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_NetAlarmas_Ubicaciones",
						column: x => x.idUbicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "NetAlarmasAutomaticasOrdenUbicaciones",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdNetAlarmaAutomatica = table.Column<int>(nullable: true),
					IdOrden = table.Column<int>(nullable: true),
					IdUbicacion = table.Column<int>(nullable: true),
					Ordenacion = table.Column<int>(nullable: true),
					Procesada = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					FechaProcesada = table.Column<DateTime>(type: "datetime", nullable: true),
					IdDosificacion = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_NetAlarmasAutomaticasOrdenUbicaciones", x => x.id);
					table.ForeignKey(
						name: "FK_NetAlarmasAutomaticasOrdenUbicaciones_Dosificaciones",
						column: x => x.IdDosificacion,
						principalTable: "Dosificaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_NetAlarmasAutomaticasOrdenUbicaciones_NetAlarmasAutomaticas",
						column: x => x.IdNetAlarmaAutomatica,
						principalTable: "NetAlarmasAutomaticas",
						principalColumn: "id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_NetAlarmasAutomaticasOrdenUbicaciones_Ordenes",
						column: x => x.IdOrden,
						principalTable: "Ordenes",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_NetAlarmasAutomaticasOrdenUbicaciones_Ubicaciones",
						column: x => x.IdUbicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "Tags",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Ubicacion = table.Column<int>(nullable: true),
					Resetear = table.Column<bool>(nullable: true),
					OptSeleccionOrden = table.Column<bool>(nullable: true),
					OptPeso1 = table.Column<bool>(nullable: true),
					OptPeso2 = table.Column<bool>(nullable: true),
					OptIniciarOrden = table.Column<bool>(nullable: true),
					PLCHMIMensaje1 = table.Column<string>(maxLength: 200, nullable: true),
					PLCHMIMensaje2 = table.Column<string>(maxLength: 200, nullable: true),
					PLCHMIMensaje3 = table.Column<string>(maxLength: 200, nullable: true),
					PLCAccionPLCMensaje1 = table.Column<string>(maxLength: 200, nullable: true),
					PLCAccionPLCMensaje2 = table.Column<string>(maxLength: 200, nullable: true),
					PLCAccionPLCMensaje3 = table.Column<string>(maxLength: 200, nullable: true),
					PLCTAGRFIDLeido = table.Column<bool>(nullable: true),
					PLCLedVerdeOn = table.Column<bool>(nullable: true),
					PLCLedRojoOn = table.Column<bool>(nullable: true),
					PLCLedVerdeIterm = table.Column<bool>(nullable: true),
					PLCLedRojoIterm = table.Column<bool>(nullable: true),
					PLCSemaforoRojoOn = table.Column<bool>(nullable: true),
					PLCSemaforoAmbarOn = table.Column<bool>(nullable: true),
					PLCSemaforoVerdeOn = table.Column<bool>(nullable: true),
					PLCActivarZumbador = table.Column<bool>(nullable: true),
					PLCAbrirBarrera = table.Column<bool>(nullable: true),
					PLCAccionAuxiliar1 = table.Column<bool>(nullable: true),
					PLCAccionAuxiliar2 = table.Column<bool>(nullable: true),
					PLCAccionAuxiliar3 = table.Column<bool>(nullable: true),
					PLCHMIActivaBotonAceptar = table.Column<bool>(nullable: true),
					PLCHMIActivaBotonCancelar = table.Column<bool>(nullable: true),
					PLCHMIActivaBotonSiguiente = table.Column<bool>(nullable: true),
					PLCHMIActivaBotonAtras = table.Column<bool>(nullable: true),
					PLCHMIActivaEntradaDato = table.Column<bool>(nullable: true),
					PLCHMIActivaBotonIntro = table.Column<bool>(nullable: true),
					PLCHMIBotonAceptarLeido = table.Column<bool>(nullable: true),
					PLCHMIBotonCancelarLeido = table.Column<bool>(nullable: true),
					PLCHMIBotonSiguienteLeido = table.Column<bool>(nullable: true),
					PLCHMIBotonAtrasLeido = table.Column<bool>(nullable: true),
					PLCHMIBotonIntroLeido = table.Column<bool>(nullable: true),
					PLCHMIActivaBotonOpcion1 = table.Column<bool>(nullable: true),
					PLCHMIActivaBotonOpcion2 = table.Column<bool>(nullable: true),
					PLCHMIBotonOpcion1Leido = table.Column<bool>(nullable: true),
					PLCHMIBotonOpcion2Leido = table.Column<bool>(nullable: true),
					MESTAGRFID = table.Column<string>(maxLength: 200, nullable: true),
					MESHMIDato = table.Column<string>(maxLength: 200, nullable: true),
					MESHMIBotonAceptar = table.Column<bool>(nullable: true),
					MESHMIBotonCancelar = table.Column<bool>(nullable: true),
					MESHMIBotonSiguiente = table.Column<bool>(nullable: true),
					MESHMIBotonAtras = table.Column<bool>(nullable: true),
					MESHMIBotonIntro = table.Column<bool>(nullable: true),
					MESHMIBotonOpcion1 = table.Column<bool>(nullable: true),
					MESHMIBotonOpcion2 = table.Column<bool>(nullable: true),
					IdPLC = table.Column<int>(nullable: false),
					FFinIntermitente = table.Column<DateTime>(type: "datetime", nullable: true),
					idModulo = table.Column<int>(nullable: true),
					OptHMIActivo = table.Column<bool>(nullable: true),
					EstadoHMI = table.Column<int>(nullable: true),
					FinalMensaje = table.Column<DateTime>(type: "datetime", nullable: true),
					idLecturaTag = table.Column<int>(nullable: true),
					OrigenPesoBascula = table.Column<bool>(nullable: true),
					PesoActualBascula = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
					LecturaPesoActualBascula = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
					PosicionMenu = table.Column<int>(nullable: true),
					IdLinEntradaMenu = table.Column<int>(nullable: true),
					IdLinSalidaMenu = table.Column<int>(nullable: true),
					OptFinalizarOrden = table.Column<bool>(nullable: true),
					PreguntarBascula = table.Column<bool>(nullable: true),
					AutoSeleccion = table.Column<bool>(nullable: true),
					OpcEntradaAlmacen = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					IdOpc = table.Column<int>(nullable: true),
					OpcConfigId = table.Column<int>(nullable: false),
					PlcEnabled = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Tags", x => x.Id);
					table.ForeignKey(
						name: "FK_Tags_OpcConfig_OpcConfigId",
						column: x => x.OpcConfigId,
						principalTable: "OpcConfig",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Tags_Ubicaciones",
						column: x => x.Ubicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Tags_Modulos",
						column: x => x.idModulo,
						principalTable: "Modulos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Basculas",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Puerto = table.Column<int>(nullable: true),
					Configuracion = table.Column<string>(maxLength: 20, nullable: true),
					RTS = table.Column<bool>(nullable: true),
					Comando = table.Column<string>(maxLength: 50, nullable: true),
					Respuesta = table.Column<string>(maxLength: 50, nullable: true),
					Periodo = table.Column<int>(nullable: true),
					InicioTrama = table.Column<int>(nullable: true),
					FinTrama = table.Column<int>(nullable: true),
					NuloTrama = table.Column<int>(nullable: true),
					Equipo = table.Column<int>(nullable: true),
					Tag = table.Column<int>(nullable: true),
					Entradas = table.Column<bool>(nullable: true),
					Salidas = table.Column<bool>(nullable: true),
					Minimo = table.Column<float>(nullable: true),
					Captura = table.Column<int>(nullable: true),
					Visible = table.Column<bool>(nullable: true),
					ControlFlujo = table.Column<int>(nullable: true),
					PeriodoVisible = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Sesion = table.Column<int>(nullable: true),
					CantidadOpc = table.Column<string>(maxLength: 50, nullable: true),
					LecturaNetos = table.Column<bool>(nullable: true),
					ValidadoServidaOpc = table.Column<string>(maxLength: 50, nullable: true),
					ValidarServidaOpc = table.Column<string>(maxLength: 50, nullable: true),
					ServidaOpc = table.Column<string>(maxLength: 50, nullable: true),
					IP = table.Column<string>(maxLength: 20, nullable: true),
					Tipo = table.Column<int>(nullable: false),
					ToleranciaSuperior = table.Column<decimal>(type: "numeric(8, 2)", nullable: true, defaultValueSql: "((0))"),
					ToleranciaInferior = table.Column<decimal>(type: "numeric(8, 2)", nullable: true, defaultValueSql: "((0))"),
					PLCBCapacidadMaxima = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCBPesoMinBasculaVacia = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCBLimSuperiorCorrColas = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCBLimInferiorCorrColas = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCBTiempoMaxDescarga = table.Column<int>(nullable: true),
					PLCBTiempoMaxEstable = table.Column<int>(nullable: true),
					PLCBValorIncrementoMin = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCBTiempoMaxAdicion = table.Column<int>(nullable: true),
					PLCBTiempoMaxIncrementos = table.Column<int>(nullable: true),
					PLCBPorcentCorrColas = table.Column<int>(nullable: true),
					PLCBModoVaciado = table.Column<int>(nullable: true),
					PLCBTipoBascula = table.Column<int>(nullable: true),
					PLCBPar1 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCBPar2 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCBPar3 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCBPar4 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCBPar5 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCCCaudalMaximo = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCCPulsosKg = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCCTipoContaje = table.Column<int>(nullable: true),
					PLCCValorMinCaudal = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCCValorMaxCaudal = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCCPorcentCorrColas = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCCLimSuperiorCorrColas = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCCLimInferiorCorrColas = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCCTiempoMaxIncrementos = table.Column<int>(nullable: true),
					PLCCValorIncrementoMin = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCCTiempoMaxAdicion = table.Column<int>(nullable: true),
					PLCCPar1 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCCPar2 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCCPar3 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCCPar4 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCCPar5 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCOVMinEscalaIng = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCOVMaxEscalaIng = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCOVMinLogico = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCOVMaxLogico = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCOPar1 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCOPar2 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCOPar3 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCOPar4 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCOPar5 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCOPar6 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCOPar7 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCOPar8 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCOPar9 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCOPar10 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCITipoIndicador = table.Column<int>(nullable: true),
					PLCIModoIndicacion = table.Column<int>(nullable: true),
					PLCINumSerie = table.Column<int>(nullable: true),
					PLCIVersion = table.Column<int>(nullable: true),
					PLCIModelo = table.Column<int>(nullable: true),
					PLCIValorActual = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCIValorActual2 = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCINumDecimales = table.Column<int>(nullable: true),
					PLCINumDecimales2 = table.Column<int>(nullable: true),
					PLCIEstadoActual = table.Column<int>(nullable: true),
					PLCIConFallos = table.Column<int>(nullable: true),
					PLCIDatosAdicionales0 = table.Column<int>(nullable: true),
					PLCIDatosAdicionales1 = table.Column<int>(nullable: true),
					PLCIDatosAdicionales2 = table.Column<int>(nullable: true),
					PLCITextoAdicional = table.Column<string>(maxLength: 50, nullable: true),
					PLCITextoAdicional2 = table.Column<string>(maxLength: 50, nullable: true),
					EnviarDatosAPLC = table.Column<bool>(nullable: true),
					PosicionPLC = table.Column<int>(nullable: false),
					PLCBPesoMaxAcumulado = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCBTiempoRetardoCiclo1 = table.Column<int>(nullable: true),
					PLCBTiempoRestablecerPerturbacion = table.Column<int>(nullable: true),
					PLCBTiempoMinDescarga = table.Column<int>(nullable: true),
					PLCBTiempoMaxRespuestaPenko = table.Column<int>(nullable: true),
					PLCBModoPesado = table.Column<int>(nullable: true),
					PLCBParticionarPesada = table.Column<int>(nullable: true),
					PLCBDesactivarALTodas = table.Column<bool>(nullable: true),
					PLCBDesactivarALAcumulados = table.Column<bool>(nullable: true),
					PLCBDesactivarALFaltaProducto = table.Column<bool>(nullable: true),
					PLCBDesactivarALBaNoVacia = table.Column<bool>(nullable: true),
					PLCBDesactivarALTolerancia = table.Column<bool>(nullable: true),
					PLCBDesactivarALTimDescarga = table.Column<bool>(nullable: true),
					PLCBDesactivarALTimMaxDosiAuto = table.Column<bool>(nullable: true),
					PLCBDesactivarALTimMaxDosiMan = table.Column<bool>(nullable: true),
					PLCBDesactivarALEstabilidad = table.Column<bool>(nullable: true),
					PLCCDesactivarALFaltaProducto = table.Column<bool>(nullable: true),
					PLCCDesactivarALTimMaxAdicion = table.Column<bool>(nullable: true),
					PLCODesactivarAlarmas = table.Column<bool>(nullable: true),
					PesoMinimoAviso = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					PesoMaximoAviso = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					Recipiente = table.Column<bool>(nullable: true),
					PesoRecipiente = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					LeerEnPLC = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					GrabarEnPLC = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					PLCBMultidosiReady = table.Column<bool>(nullable: true),
					PLCBDesactivarALProceso = table.Column<bool>(nullable: true),
					PLCBDesactivarALVisorPenko = table.Column<bool>(nullable: true),
					PLCCNumerodeOrden = table.Column<int>(nullable: true),
					PLCCPermitirContajeEnManual = table.Column<bool>(nullable: true),
					PLCCPermitirTestEnAuto = table.Column<bool>(nullable: true),
					PLCCSecuenciarLiquido = table.Column<bool>(nullable: true),
					PLCCInKgOL = table.Column<bool>(nullable: true),
					PLCCAutocalibracionAtivada = table.Column<bool>(nullable: true),
					PLCCDesactivarTodasAlarmas = table.Column<bool>(nullable: true),
					PLCCModoContaje = table.Column<bool>(nullable: true),
					PLCBNumMaxCiclos = table.Column<int>(nullable: true),
					PLCBOmitirToleranciaPrecisionZero = table.Column<bool>(nullable: true),
					PLCBToleranciaPrecisionZero = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					FLectura = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaLecturaPeso = table.Column<DateTime>(type: "datetime", nullable: true),
					LecturaPeso = table.Column<decimal>(type: "numeric(15, 3)", nullable: true),
					PerlePuerto = table.Column<string>(maxLength: 20, nullable: true),
					PerleVelocidad = table.Column<string>(maxLength: 20, nullable: true),
					PerleBitsDatos = table.Column<string>(maxLength: 20, nullable: true),
					PerleBitsParada = table.Column<string>(maxLength: 20, nullable: true),
					PerleParidad = table.Column<string>(maxLength: 20, nullable: true),
					PerleHandShake = table.Column<string>(maxLength: 20, nullable: true),
					PerleDTR = table.Column<bool>(nullable: true),
					PerleRTS = table.Column<bool>(nullable: true),
					NDecimales = table.Column<int>(nullable: true),
					PLCBReintentarDosificacionPerdidaSP = table.Column<bool>(nullable: true),
					PLCBTiempoMinEstable = table.Column<int>(nullable: true),
					SeparadorNewLine = table.Column<string>(maxLength: 5, nullable: true),
					PLCCPulsosL = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCCLimSuperiorAnalogica = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					PLCCTipoContador = table.Column<bool>(nullable: true),
					TiempoMaximoLectura = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					IdOpc = table.Column<int>(nullable: true),
					ModoTransmisionPeso = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					CadenaPeticion = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
					OpcConfigId = table.Column<int>(nullable: false),
					PlcEnabled = table.Column<bool>(nullable: false),
					StartIndex = table.Column<int>(nullable: true),
					Lenght = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Basculas", x => x.Id);
					table.ForeignKey(
						name: "FK_Basculas_OpcConfig_OpcConfigId",
						column: x => x.OpcConfigId,
						principalTable: "OpcConfig",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_Basculas_Tags_Tag",
						column: x => x.Tag,
						principalTable: "Tags",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "HumanMachineInterfaces",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Enabled = table.Column<bool>(nullable: false),
					Name = table.Column<string>(maxLength: 64, nullable: false),
					Type = table.Column<byte>(nullable: false),
					TagId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_HumanMachineInterfaces", x => x.Id);
					table.ForeignKey(
						name: "FK_HumanMachineInterfaces_Tags_TagId",
						column: x => x.TagId,
						principalTable: "Tags",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "TagsLecturas",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Lectura = table.Column<string>(maxLength: 100, nullable: true),
					FRecibido = table.Column<DateTime>(type: "datetime", nullable: true),
					Tratado = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					FTratado = table.Column<DateTime>(type: "datetime", nullable: true),
					TextoError = table.Column<string>(maxLength: 250, nullable: true),
					Solucion = table.Column<string>(maxLength: 250, nullable: true),
					idTag = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TagsLecturas", x => x.id);
					table.ForeignKey(
						name: "FK_TagsLecturas_Tags",
						column: x => x.idTag,
						principalTable: "Tags",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.InsertData(
				table: "NetAlarmasTipos",
				columns: new[] { "Id", "AutoFinalizar", "IdAlarmaPLC", "MostrarUsuario", "Nivel", "RolShow", "TextoError", "UserShow" },
				values: new object[] { 2050, false, 2050, true, null, null, "Comprobacion Origen Vacio", null });

			migrationBuilder.CreateIndex(
				name: "IX_Aditivos_Formato",
				table: "Aditivos",
				column: "Formato");

			migrationBuilder.CreateIndex(
				name: "IX_Aditivos_Orden",
				table: "Aditivos",
				column: "Orden");

			migrationBuilder.CreateIndex(
				name: "IX_Aditivos_Producto",
				table: "Aditivos",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_Aditivos_Ubicacion",
				table: "Aditivos",
				column: "Ubicacion");

			migrationBuilder.CreateIndex(
				name: "IX_Aditivos_Unidad",
				table: "Aditivos",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IX_Alarmas_Medidor",
				table: "Alarmas",
				column: "Medidor");

			migrationBuilder.CreateIndex(
				name: "IX_AlertasUsuarios_idServerSmtp",
				table: "AlertasUsuarios",
				column: "idServerSmtp");

			migrationBuilder.CreateIndex(
				name: "IX_AlertasUsuariosAlarmas_idAlertaUsuario",
				table: "AlertasUsuariosAlarmas",
				column: "idAlertaUsuario");

			migrationBuilder.CreateIndex(
				name: "IX_AlertasUsuariosAlarmas_idModulo",
				table: "AlertasUsuariosAlarmas",
				column: "idModulo");

			migrationBuilder.CreateIndex(
				name: "IX_AlertasUsuariosAlarmas_idNetAlarmaTipo",
				table: "AlertasUsuariosAlarmas",
				column: "idNetAlarmaTipo");

			migrationBuilder.CreateIndex(
				name: "IX_AlertasUsuariosInformes_idAlertasUsuarios",
				table: "AlertasUsuariosInformes",
				column: "idAlertasUsuarios");

			migrationBuilder.CreateIndex(
				name: "IX_AlertasUsuariosInformesParametros_idAlertaUsuarioInformes",
				table: "AlertasUsuariosInformesParametros",
				column: "idAlertaUsuarioInformes");

			migrationBuilder.CreateIndex(
				name: "IX_AuditColumns_AuditTableId",
				table: "AuditColumns",
				column: "AuditTableId");

			migrationBuilder.CreateIndex(
				name: "IX_AuditTables_AuditId",
				table: "AuditTables",
				column: "AuditId");

			migrationBuilder.CreateIndex(
				name: "_dta_index_Backups_1",
				table: "Backups",
				column: "HayError");

			migrationBuilder.CreateIndex(
				name: "IX_Basculas_OpcConfigId",
				table: "Basculas",
				column: "OpcConfigId");

			migrationBuilder.CreateIndex(
				name: "IX_Basculas_Tag",
				table: "Basculas",
				column: "Tag");

			migrationBuilder.CreateIndex(
				name: "IX_BufferConsumidos_OpcConfigId",
				table: "BufferConsumidos",
				column: "OpcConfigId");

			migrationBuilder.CreateIndex(
				name: "NonClusteredIndex-20210719-021448",
				table: "BufferConsumidos",
				columns: new[] { "Tratado", "ModuloId" });

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPClienteDomicilioPuntoDescarga_idDomicilio",
				table: "BufferERPClienteDomicilioPuntoDescarga",
				column: "idDomicilio");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPClientesDomicilios_idCliente",
				table: "BufferERPClientesDomicilios",
				column: "idCliente");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPComponentes_idVersion",
				table: "BufferERPComponentes",
				column: "idVersion");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPComprasLineas_CompraId",
				table: "BufferERPComprasLineas",
				column: "CompraId");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPEntradasLineas_idBufferEntrada",
				table: "BufferERPEntradasLineas",
				column: "idBufferEntrada");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPEntradasLineasLote_IdLineaEntrada",
				table: "BufferERPEntradasLineasLote",
				column: "IdLineaEntrada");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPFormulaProductosFinales_idFormula",
				table: "BufferERPFormulaProductosFinales",
				column: "idFormula");

			migrationBuilder.CreateIndex(
				name: "IBufferERPImprimirDocumentos1",
				table: "BufferERPImprimirDocumentos",
				columns: new[] { "id", "Preparado", "Tratado", "FTratado", "Errores", "RefERP", "IdEntrada", "IdSalida", "FechaInsercion" });

			migrationBuilder.CreateIndex(
				name: "IBufferERPImprimirDocumentos2",
				table: "BufferERPImprimirDocumentos",
				columns: new[] { "id", "Preparado", "Tratado", "FTratado", "Errores", "RefERP", "IdSalida", "IdEntrada", "FechaInsercion" });

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPLinOrdenes_idCaborden",
				table: "BufferERPLinOrdenes",
				column: "idCaborden");

			migrationBuilder.CreateIndex(
				name: "_dta_index_BufferERPProducidos_1",
				table: "BufferERPProducidos",
				column: "Tratado");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPSalidasLinias_idSalidas",
				table: "BufferERPSalidasLinias",
				column: "idSalidas");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPSalidasLinias_idviajes",
				table: "BufferERPSalidasLinias",
				column: "idviajes");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPSalidasLiniasLote_idLineaSalida",
				table: "BufferERPSalidasLiniasLote",
				column: "idLineaSalida");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPSalidasLiniasLote_idLineaSalidaMedicamento",
				table: "BufferERPSalidasLiniasLote",
				column: "idLineaSalidaMedicamento");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPSalidasLinMedicamentos_idSalidasLinia",
				table: "BufferERPSalidasLinMedicamentos",
				column: "idSalidasLinia");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPSolicitudRegularizacion_IdLote",
				table: "BufferERPSolicitudRegularizacion",
				column: "IdLote");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPSolicitudRegularizacion_IdUbicacion",
				table: "BufferERPSolicitudRegularizacion",
				column: "IdUbicacion");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPSolicitudRegularizacion_IdUsuario",
				table: "BufferERPSolicitudRegularizacion",
				column: "IdUsuario");

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

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPVentasLineas_BufferErpVentaId",
				table: "BufferERPVentasLineas",
				column: "BufferErpVentaId");

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPVersiones_idFormula",
				table: "BufferERPVersiones",
				column: "idFormula");

			migrationBuilder.CreateIndex(
				name: "_dta_index_BufferProducidos_1",
				table: "BufferProducidos",
				column: "FinalMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_BufferProducidos_OpcConfigId",
				table: "BufferProducidos",
				column: "OpcConfigId");

			migrationBuilder.CreateIndex(
				name: "IX_CabOrdenes_Entrada",
				table: "CabOrdenes",
				column: "Entrada");

			migrationBuilder.CreateIndex(
				name: "IX_CabOrdenes_Formula",
				table: "CabOrdenes",
				column: "Formula");

			migrationBuilder.CreateIndex(
				name: "IX_CabOrdenes_LoteDestino",
				table: "CabOrdenes",
				column: "LoteDestino");

			migrationBuilder.CreateIndex(
				name: "IX_CabOrdenes_Modulo",
				table: "CabOrdenes",
				column: "Modulo");

			migrationBuilder.CreateIndex(
				name: "IX_CabOrdenes_ProductoDestino",
				table: "CabOrdenes",
				column: "ProductoDestino");

			migrationBuilder.CreateIndex(
				name: "IX_CabOrdenes_UbicacionDestino",
				table: "CabOrdenes",
				column: "UbicacionDestino");

			migrationBuilder.CreateIndex(
				name: "IX_CabOrdenes_Version",
				table: "CabOrdenes",
				column: "Version");

			migrationBuilder.CreateIndex(
				name: "IX_CabOrdenes_ViajeSalida",
				table: "CabOrdenes",
				column: "ViajeSalida");

			migrationBuilder.CreateIndex(
				name: "IndexCabOrdenes_1",
				table: "CabOrdenes",
				columns: new[] { "id", "Nombre", "FechaCreacion", "FechaInicio", "FechaFinal", "Tipo", "ProductoDestino", "UbicacionDestino", "LoteDestino", "Prioridad", "Formula", "Cantidad", "Version", "idOld", "SerieOld", "Entrada", "ViajeSalida", "Modulo" });

			migrationBuilder.CreateIndex(
				name: "IX_Caminos_MedidorId",
				table: "Caminos",
				column: "MedidorId");

			migrationBuilder.CreateIndex(
				name: "IX_Caudales_UbicacionId",
				table: "Caudales",
				column: "UbicacionId");

			migrationBuilder.CreateIndex(
				name: "IX_CertificadoDesinfeccion_Serie",
				table: "CertificadoDesinfeccion",
				column: "Serie");

			migrationBuilder.CreateIndex(
				name: "IX_CertificadoDesinfeccion_idCamion",
				table: "CertificadoDesinfeccion",
				column: "idCamion");

			migrationBuilder.CreateIndex(
				name: "IX_CertificadoDesinfeccion_idOrden",
				table: "CertificadoDesinfeccion",
				column: "idOrden");

			migrationBuilder.CreateIndex(
				name: "IX_CertificadoDesinfeccion_idTransportista",
				table: "CertificadoDesinfeccion",
				column: "idTransportista");

			migrationBuilder.CreateIndex(
				name: "IX_Choferes_Pais",
				table: "Choferes",
				column: "Pais");

			migrationBuilder.CreateIndex(
				name: "IX_Choferes_Provincia",
				table: "Choferes",
				column: "Provincia");

			migrationBuilder.CreateIndex(
				name: "IX_Choferes_Tarjeta",
				table: "Choferes",
				column: "Tarjeta");

			migrationBuilder.CreateIndex(
				name: "IX_Clientes_Pais",
				table: "Clientes",
				column: "Pais");

			migrationBuilder.CreateIndex(
				name: "IX_Clientes_Provincia",
				table: "Clientes",
				column: "Provincia");

			migrationBuilder.CreateIndex(
				name: "IX_Componentes_Formato",
				table: "Componentes",
				column: "Formato");

			migrationBuilder.CreateIndex(
				name: "IX_Componentes_IdTempControl",
				table: "Componentes",
				column: "IdTempControl");

			migrationBuilder.CreateIndex(
				name: "IX_Componentes_Medidor",
				table: "Componentes",
				column: "Medidor");

			migrationBuilder.CreateIndex(
				name: "IX_Componentes_Modulo",
				table: "Componentes",
				column: "Modulo");

			migrationBuilder.CreateIndex(
				name: "IX_Componentes_OperAccion",
				table: "Componentes",
				column: "OperAccion");

			migrationBuilder.CreateIndex(
				name: "IX_Componentes_OperMotor",
				table: "Componentes",
				column: "OperMotor");

			migrationBuilder.CreateIndex(
				name: "IX_Componentes_Producto",
				table: "Componentes",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_Componentes_Unidad",
				table: "Componentes",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IX_Componentes_Version",
				table: "Componentes",
				column: "Version");

			migrationBuilder.CreateIndex(
				name: "IX_Componentes_idPlantilla",
				table: "Componentes",
				column: "idPlantilla");

			migrationBuilder.CreateIndex(
				name: "IX_ComponentesActivos_Unidad",
				table: "ComponentesActivos",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IX_Compras_Departamento",
				table: "Compras",
				column: "Departamento");

			migrationBuilder.CreateIndex(
				name: "IX_Compras_Proveedor",
				table: "Compras",
				column: "Proveedor");

			migrationBuilder.CreateIndex(
				name: "IX_Compras_idContrato",
				table: "Compras",
				column: "idContrato");

			migrationBuilder.CreateIndex(
				name: "IX_Compras",
				table: "Compras",
				columns: new[] { "Serie", "Numero" },
				unique: true,
				filter: "[Serie] IS NOT NULL AND [Numero] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_Contratos_IdCliente",
				table: "Contratos",
				column: "IdCliente");

			migrationBuilder.CreateIndex(
				name: "IX_Contratos_IdProducto",
				table: "Contratos",
				column: "IdProducto");

			migrationBuilder.CreateIndex(
				name: "IX_Contratos_IdProveedor",
				table: "Contratos",
				column: "IdProveedor");

			migrationBuilder.CreateIndex(
				name: "IX_Contratos_Unidad",
				table: "Contratos",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IX_ControlesNIRProductos_idProducto",
				table: "ControlesNIRProductos",
				column: "idProducto");

			migrationBuilder.CreateIndex(
				name: "IX_DashboardsLib_IdCategoria",
				table: "DashboardsLib",
				column: "IdCategoria");

			migrationBuilder.CreateIndex(
				name: "IX_DashboardsLib_IdDashboardBase",
				table: "DashboardsLib",
				column: "IdDashboardBase");

			migrationBuilder.CreateIndex(
				name: "IX_Departamentos_Provincia",
				table: "Departamentos",
				column: "Provincia");

			migrationBuilder.CreateIndex(
				name: "IX_Desgloses_Envase",
				table: "Desgloses",
				column: "Envase");

			migrationBuilder.CreateIndex(
				name: "IndDesgloses_Fecha",
				table: "Desgloses",
				column: "Fecha");

			migrationBuilder.CreateIndex(
				name: "_dta_index_Desgloses_1",
				table: "Desgloses",
				column: "FinalMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_Desgloses_Orden",
				table: "Desgloses",
				column: "Orden");

			migrationBuilder.CreateIndex(
				name: "IX_Desgloses_Producto",
				table: "Desgloses",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_Desgloses_Ubicacion",
				table: "Desgloses",
				column: "Ubicacion");

			migrationBuilder.CreateIndex(
				name: "IX_Desgloses_Unidad",
				table: "Desgloses",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "_dta_index_Desgloses_6_1357247890__K3_6_8",
				table: "Desgloses",
				columns: new[] { "Lote", "Cantidad", "Orden" });

			migrationBuilder.CreateIndex(
				name: "IndDesgloses_MedidorOrdenProductoUbicacionLote",
				table: "Desgloses",
				columns: new[] { "MedidorId", "Orden", "Producto", "Ubicacion", "Lote" });

			migrationBuilder.CreateIndex(
				name: "IndDesgloses_Orden",
				table: "Desgloses",
				columns: new[] { "Id", "Producto", "Lote", "Ubicacion", "Cantidad", "Ciclo", "Fecha", "Temperatura", "Humedad", "TiempoEfectivo", "TiempoTotal", "KWhEfectivo", "KWhTotal", "MedidorId", "Orden" });

			migrationBuilder.CreateIndex(
				name: "IX_Destinos_Modulo",
				table: "Destinos",
				column: "Modulo");

			migrationBuilder.CreateIndex(
				name: "IX_Destinos_Ubicacion",
				table: "Destinos",
				column: "Ubicacion");

			migrationBuilder.CreateIndex(
				name: "IX_DestinosMedidores_idDestino",
				table: "DestinosMedidores",
				column: "idDestino");

			migrationBuilder.CreateIndex(
				name: "IX_DestinosMedidores_idMedidor",
				table: "DestinosMedidores",
				column: "idMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_Disposiciones_Formato",
				table: "Disposiciones",
				column: "Formato");

			migrationBuilder.CreateIndex(
				name: "IX_Disposiciones_Lote",
				table: "Disposiciones",
				column: "Lote");

			migrationBuilder.CreateIndex(
				name: "IX_Disposiciones_Orden",
				table: "Disposiciones",
				column: "Orden");

			migrationBuilder.CreateIndex(
				name: "IX_Disposiciones_Producto",
				table: "Disposiciones",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_Disposiciones_Ubicacion",
				table: "Disposiciones",
				column: "Ubicacion");

			migrationBuilder.CreateIndex(
				name: "IX_Disposiciones_Unidad",
				table: "Disposiciones",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IDisposiciones1",
				table: "Disposiciones",
				columns: new[] { "Id", "Serie", "IdOld", "Producto", "Lote", "Ubicacion", "Cantidad", "Servida", "Unidad", "Tipo", "CantidadPrincipal", "TipoRegistro", "Finalizado", "Porcentaje", "Importado", "Exportado", "ordenacion", "SerieOld", "Orden" });

			migrationBuilder.CreateIndex(
				name: "IX_Domicilios_Cliente",
				table: "Domicilios",
				column: "Cliente");

			migrationBuilder.CreateIndex(
				name: "IX_Domicilios_Especie",
				table: "Domicilios",
				column: "Especie");

			migrationBuilder.CreateIndex(
				name: "IX_Domicilios_Pais",
				table: "Domicilios",
				column: "Pais");

			migrationBuilder.CreateIndex(
				name: "IX_Domicilios_Provincia",
				table: "Domicilios",
				column: "Provincia");

			migrationBuilder.CreateIndex(
				name: "IX_Dominios_Departamento",
				table: "Dominios",
				column: "Departamento");

			migrationBuilder.CreateIndex(
				name: "IX_Dominios_Familia",
				table: "Dominios",
				column: "Familia");

			migrationBuilder.CreateIndex(
				name: "IX_Dosificaciones_Formato",
				table: "Dosificaciones",
				column: "Formato");

			migrationBuilder.CreateIndex(
				name: "IX_Dosificaciones_IdModulo",
				table: "Dosificaciones",
				column: "IdModulo");

			migrationBuilder.CreateIndex(
				name: "IX_Dosificaciones_IdOperAccion",
				table: "Dosificaciones",
				column: "IdOperAccion");

			migrationBuilder.CreateIndex(
				name: "IX_Dosificaciones_IdOperMotor",
				table: "Dosificaciones",
				column: "IdOperMotor");

			migrationBuilder.CreateIndex(
				name: "IX_Dosificaciones_IdTempControl",
				table: "Dosificaciones",
				column: "IdTempControl");

			migrationBuilder.CreateIndex(
				name: "IX_Dosificaciones_Lote",
				table: "Dosificaciones",
				column: "Lote");

			migrationBuilder.CreateIndex(
				name: "IX_Dosificaciones_LoteActual",
				table: "Dosificaciones",
				column: "LoteActual");

			migrationBuilder.CreateIndex(
				name: "IX_Dosificaciones_Medidor",
				table: "Dosificaciones",
				column: "Medidor");

			migrationBuilder.CreateIndex(
				name: "IX_Dosificaciones_Orden",
				table: "Dosificaciones",
				column: "Orden");

			migrationBuilder.CreateIndex(
				name: "IX_Dosificaciones_Producto",
				table: "Dosificaciones",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_Dosificaciones_ProductoActual",
				table: "Dosificaciones",
				column: "ProductoActual");

			migrationBuilder.CreateIndex(
				name: "IX_Dosificaciones_Ubicacion",
				table: "Dosificaciones",
				column: "Ubicacion");

			migrationBuilder.CreateIndex(
				name: "IX_Dosificaciones_Unidad",
				table: "Dosificaciones",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IX_Dosificaciones_idMedGenerador",
				table: "Dosificaciones",
				column: "idMedGenerador");

			migrationBuilder.CreateIndex(
				name: "IX_Dosificaciones_idPlantilla",
				table: "Dosificaciones",
				column: "idPlantilla");

			migrationBuilder.CreateIndex(
				name: "PK_DosificacionesProducto",
				table: "Dosificaciones",
				columns: new[] { "Id", "Cantidad", "Ubicacion", "Producto" });

			migrationBuilder.CreateIndex(
				name: "IDosificaciones1",
				table: "Dosificaciones",
				columns: new[] { "Id", "Serie", "IdOld", "Producto", "Formato", "Proceso", "Porcentaje", "Cantidad", "Unidad", "Servida", "NumeroPesadas", "Inicio", "Fin", "Tipo", "Exportado", "Lote", "Ubicacion", "Grupo", "Estado", "Medidor", "CantidadPrincipal", "TipoRegistro", "Importado", "PosicionDosificacion", "CicloActual", "CantidadActual", "UbicacionActual", "IdModulo", "DosiVariable1", "DosiVariable2", "Orden" });

			migrationBuilder.CreateIndex(
				name: "IX_Electrovalvulas_OpcConfigId",
				table: "Electrovalvulas",
				column: "OpcConfigId");

			migrationBuilder.CreateIndex(
				name: "IX_EmpresasTransporte_Pais",
				table: "EmpresasTransporte",
				column: "Pais");

			migrationBuilder.CreateIndex(
				name: "IX_EmpresasTransporte_Provincia",
				table: "EmpresasTransporte",
				column: "Provincia");

			migrationBuilder.CreateIndex(
				name: "IX_EnlaceERP_idEnlaceERPTipo",
				table: "EnlaceERP",
				column: "idEnlaceERPTipo");

			migrationBuilder.CreateIndex(
				name: "IX_EnlaceERPAsigUbi_IdProducto",
				table: "EnlaceERPAsigUbi",
				column: "IdProducto");

			migrationBuilder.CreateIndex(
				name: "IX_EnlaceERPAsigUbi_IdUbicacion",
				table: "EnlaceERPAsigUbi",
				column: "IdUbicacion");

			migrationBuilder.CreateIndex(
				name: "IX_EnlaceERPLinea_idEnlaceERP",
				table: "EnlaceERPLinea",
				column: "idEnlaceERP");

			migrationBuilder.CreateIndex(
				name: "IX_EnlaceERPLinea_idEnlaceERPTipoLinea",
				table: "EnlaceERPLinea",
				column: "idEnlaceERPTipoLinea");

			migrationBuilder.CreateIndex(
				name: "IX_EnlaceERPTipoLinea_idEnlaceERPTipo",
				table: "EnlaceERPTipoLinea",
				column: "idEnlaceERPTipo");

			migrationBuilder.CreateIndex(
				name: "IX_Entradas_Serie",
				table: "Entradas",
				column: "Serie");

			migrationBuilder.CreateIndex(
				name: "IX_Entradas_idChofer",
				table: "Entradas",
				column: "idChofer");

			migrationBuilder.CreateIndex(
				name: "IX_Entradas_idEmpresaTransporte",
				table: "Entradas",
				column: "idEmpresaTransporte");

			migrationBuilder.CreateIndex(
				name: "IX_Entradas_idProveedor",
				table: "Entradas",
				column: "idProveedor");

			migrationBuilder.CreateIndex(
				name: "IX_Entradas_idTarjeta",
				table: "Entradas",
				column: "idTarjeta");

			migrationBuilder.CreateIndex(
				name: "IX_Entradas_idVehiculo",
				table: "Entradas",
				column: "idVehiculo");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasContratos_idContrato",
				table: "EntradasContratos",
				column: "idContrato");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasContratos_idEntradasLineas",
				table: "EntradasContratos",
				column: "idEntradasLineas");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_Destino1",
				table: "EntradasLineas",
				column: "Destino1");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_Destino2",
				table: "EntradasLineas",
				column: "Destino2");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_Destino3",
				table: "EntradasLineas",
				column: "Destino3");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_Destino4",
				table: "EntradasLineas",
				column: "Destino4");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_Envase",
				table: "EntradasLineas",
				column: "Envase");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_Formato",
				table: "EntradasLineas",
				column: "Formato");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_Lote",
				table: "EntradasLineas",
				column: "Lote");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_Origen1",
				table: "EntradasLineas",
				column: "Origen1");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_Origen2",
				table: "EntradasLineas",
				column: "Origen2");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_Origen3",
				table: "EntradasLineas",
				column: "Origen3");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_Origen4",
				table: "EntradasLineas",
				column: "Origen4");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_Unidad",
				table: "EntradasLineas",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_idBasculaPesajeBruto",
				table: "EntradasLineas",
				column: "idBasculaPesajeBruto");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_idBasculaPesajeNeto",
				table: "EntradasLineas",
				column: "idBasculaPesajeNeto");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_idEntradas",
				table: "EntradasLineas",
				column: "idEntradas");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_idModulo",
				table: "EntradasLineas",
				column: "idModulo");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_idOrigenProv",
				table: "EntradasLineas",
				column: "idOrigenProv");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_idProducto",
				table: "EntradasLineas",
				column: "idProducto");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineas_idProveedor",
				table: "EntradasLineas",
				column: "idProveedor");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineasResultadosNIR_idControlesNir",
				table: "EntradasLineasResultadosNIR",
				column: "idControlesNir");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLineasResultadosNIR_idEntradasLineas",
				table: "EntradasLineasResultadosNIR",
				column: "idEntradasLineas");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLotes_IdEntradasLineas",
				table: "EntradasLotes",
				column: "IdEntradasLineas");

			migrationBuilder.CreateIndex(
				name: "IX_EntradasLotes_IdLote",
				table: "EntradasLotes",
				column: "IdLote");

			migrationBuilder.CreateIndex(
				name: "IX_Envases_Unidad",
				table: "Envases",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "_dta_index_Eventos_1",
				table: "Eventos",
				column: "Elemento");

			migrationBuilder.CreateIndex(
				name: "_dta_index_EventosDetalle_1",
				table: "EventosDetalle",
				column: "Evento");

			migrationBuilder.CreateIndex(
				name: "IX_Existencias_Envase",
				table: "Existencias",
				column: "Envase");

			migrationBuilder.CreateIndex(
				name: "IX_Existencias_Formato",
				table: "Existencias",
				column: "Formato");

			migrationBuilder.CreateIndex(
				name: "IX_Existencias_Inventario",
				table: "Existencias",
				column: "Inventario");

			migrationBuilder.CreateIndex(
				name: "IX_Existencias_Lote",
				table: "Existencias",
				column: "Lote");

			migrationBuilder.CreateIndex(
				name: "IX_Existencias_Producto",
				table: "Existencias",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_Existencias_Ubicacion",
				table: "Existencias",
				column: "Ubicacion");

			migrationBuilder.CreateIndex(
				name: "IX_Existencias_Unidad",
				table: "Existencias",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IX_Existencias_idEntradaLinea",
				table: "Existencias",
				column: "idEntradaLinea");

			migrationBuilder.CreateIndex(
				name: "IX_Existencias_idProveedor",
				table: "Existencias",
				column: "idProveedor");

			migrationBuilder.CreateIndex(
				name: "IX_Familias_Analisi",
				table: "Familias",
				column: "Analisi");

			migrationBuilder.CreateIndex(
				name: "IX_Familias_Departamento",
				table: "Familias",
				column: "Departamento");

			migrationBuilder.CreateIndex(
				name: "IX_FileGmaoElement_GmaoElementId",
				table: "FileGmaoElement",
				column: "GmaoElementId");

			migrationBuilder.CreateIndex(
				name: "IX_FormulaProdModulo_idFormulario",
				table: "FormulaProdModulo",
				column: "idFormulario");

			migrationBuilder.CreateIndex(
				name: "IX_FormulaProdModulo_idModulo",
				table: "FormulaProdModulo",
				column: "idModulo");

			migrationBuilder.CreateIndex(
				name: "IX_FormulaProdModulo_idProducto",
				table: "FormulaProdModulo",
				column: "idProducto");

			migrationBuilder.CreateIndex(
				name: "IX_FormulaProdModulo_idUbicacion",
				table: "FormulaProdModulo",
				column: "idUbicacion");

			migrationBuilder.CreateIndex(
				name: "IX_Formularios_Formula",
				table: "Formularios",
				column: "Formula");

			migrationBuilder.CreateIndex(
				name: "IX_Formularios_Medicacion",
				table: "Formularios",
				column: "Medicacion");

			migrationBuilder.CreateIndex(
				name: "IX_Formularios_Producto",
				table: "Formularios",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_Formulas_Departamento",
				table: "Formulas",
				column: "Departamento");

			migrationBuilder.CreateIndex(
				name: "IX_Formulas_Familia",
				table: "Formulas",
				column: "Familia");

			migrationBuilder.CreateIndex(
				name: "IX_Formulas_Modulo",
				table: "Formulas",
				column: "Modulo");

			migrationBuilder.CreateIndex(
				name: "IX_Formulas_Producto",
				table: "Formulas",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_Gateways_TenantId",
				table: "Gateways",
				column: "TenantId");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_Archivos_Elementos_idArchivo",
				table: "GMAO_Archivos_Elementos",
				column: "idArchivo");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_Archivos_Intervenciones_idArchivo",
				table: "GMAO_Archivos_Intervenciones",
				column: "idArchivo");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_Archivos_Modelos_idArchivo",
				table: "GMAO_Archivos_Modelos",
				column: "idArchivo");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_Archivos_Tipos_idArchivo",
				table: "GMAO_Archivos_Tipos",
				column: "idArchivo");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_CaracteristicasElementos_idCaracteristica",
				table: "GMAO_CaracteristicasElementos",
				column: "idCaracteristica");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_CaracteristicasTipos_idCaracteristica",
				table: "GMAO_CaracteristicasTipos",
				column: "idCaracteristica");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_Compras_IdProveedor",
				table: "GMAO_Compras",
				column: "IdProveedor");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ComprasLineas_idCompra",
				table: "GMAO_ComprasLineas",
				column: "idCompra");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ComprasLineas_idElemento",
				table: "GMAO_ComprasLineas",
				column: "idElemento");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_Departamentos_IdResponsable",
				table: "GMAO_Departamentos",
				column: "IdResponsable");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_Deps_Operarios_idOperario",
				table: "GMAO_Deps_Operarios",
				column: "idOperario");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemAlternativos_IdHijo",
				table: "GMAO_ElemAlternativos",
				column: "IdHijo");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_Elementos_ElectrovalvulaId",
				table: "GMAO_Elementos",
				column: "ElectrovalvulaId");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_Elementos_ElementoPadreId",
				table: "GMAO_Elementos",
				column: "ElementoPadreId");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_Elementos_ModeloId",
				table: "GMAO_Elementos",
				column: "ModeloId");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_Elementos_Tipo",
				table: "GMAO_Elementos",
				column: "Tipo");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_Elementos_idMotor",
				table: "GMAO_Elementos",
				column: "idMotor");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElementosTipos_ProveedorHabitual",
				table: "GMAO_ElementosTipos",
				column: "ProveedorHabitual");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElementosTiposModelos_idModelo",
				table: "GMAO_ElementosTiposModelos",
				column: "idModelo");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElementReviewTasks_ElementId",
				table: "GMAO_ElementReviewTasks",
				column: "ElementId");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElementReviewTasks_TaskId",
				table: "GMAO_ElementReviewTasks",
				column: "TaskId");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemIntervenciones_IDDepartamento",
				table: "GMAO_ElemIntervenciones",
				column: "IDDepartamento");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemIntervenciones_IdOperarioResponsable",
				table: "GMAO_ElemIntervenciones",
				column: "IdOperarioResponsable");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemIntervenciones_IdParadaConfiguracion",
				table: "GMAO_ElemIntervenciones",
				column: "IdParadaConfiguracion");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemIntervenciones_idElemento",
				table: "GMAO_ElemIntervenciones",
				column: "idElemento");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemIntervencionesPiezas_ElementId",
				table: "GMAO_ElemIntervencionesPiezas",
				column: "ElementId");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemIntervencionesPiezas_IdIntervencion",
				table: "GMAO_ElemIntervencionesPiezas",
				column: "IdIntervencion");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemIntervencionesPiezas_WarehouseId",
				table: "GMAO_ElemIntervencionesPiezas",
				column: "WarehouseId");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemIntervencionesTrabajos_IdIntervencion",
				table: "GMAO_ElemIntervencionesTrabajos",
				column: "IdIntervencion");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemIntervencionesTrabajos_IdOperario",
				table: "GMAO_ElemIntervencionesTrabajos",
				column: "IdOperario");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemIntervencionesTrabajos_ReviewTaskId",
				table: "GMAO_ElemIntervencionesTrabajos",
				column: "ReviewTaskId");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemPertenencia_IdHijo",
				table: "GMAO_ElemPertenencia",
				column: "IdHijo");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemStocks_IdCompraLinea",
				table: "GMAO_ElemStocks",
				column: "IdCompraLinea");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemStocks_IdModelo",
				table: "GMAO_ElemStocks",
				column: "IdModelo");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemStocks_IdProveedor",
				table: "GMAO_ElemStocks",
				column: "IdProveedor");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemStocks_idElemento",
				table: "GMAO_ElemStocks",
				column: "idElemento");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_HistStocksYElementos_idElemento",
				table: "GMAO_HistStocksYElementos",
				column: "idElemento");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_HistStocksYElementos_idStock",
				table: "GMAO_HistStocksYElementos",
				column: "idStock");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_MarcasModelos_idMarca",
				table: "GMAO_MarcasModelos",
				column: "idMarca");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ParadasConfiguracionModulos_idModulo",
				table: "GMAO_ParadasConfiguracionModulos",
				column: "idModulo");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ParadasConfiguracionTareas_idElemento",
				table: "GMAO_ParadasConfiguracionTareas",
				column: "idElemento");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ParadasConfiguracionTareas_idOperario",
				table: "GMAO_ParadasConfiguracionTareas",
				column: "idOperario");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ParadasConfiguracionTareas_idParadaConfiguracion",
				table: "GMAO_ParadasConfiguracionTareas",
				column: "idParadaConfiguracion");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_SolicitudOrdenTrabajo_CreadaPorId",
				table: "GMAO_SolicitudOrdenTrabajo",
				column: "CreadaPorId");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_SolicitudOrdenTrabajo_ElementoId",
				table: "GMAO_SolicitudOrdenTrabajo",
				column: "ElementoId");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_SolicitudOrdenTrabajo_GestionadaPorId",
				table: "GMAO_SolicitudOrdenTrabajo",
				column: "GestionadaPorId");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_WarehouseStocks_ModelId",
				table: "GMAO_WarehouseStocks",
				column: "ModelId");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_WarehouseStocks_WarehouseId",
				table: "GMAO_WarehouseStocks",
				column: "WarehouseId");

			migrationBuilder.CreateIndex(
				name: "IX_GruposIncompatibilidadesLineas_IdGrupo",
				table: "GruposIncompatibilidadesLineas",
				column: "IdGrupo");

			migrationBuilder.CreateIndex(
				name: "IX_GruposIncompatibilidadesLineas_IdProducto",
				table: "GruposIncompatibilidadesLineas",
				column: "IdProducto");

			migrationBuilder.CreateIndex(
				name: "IX_HumanMachineInterfaces_TagId",
				table: "HumanMachineInterfaces",
				column: "TagId");

			migrationBuilder.CreateIndex(
				name: "IX_Incompatibilidades_Formula",
				table: "Incompatibilidades",
				column: "Formula");

			migrationBuilder.CreateIndex(
				name: "IX_Incompatibilidades_Producto",
				table: "Incompatibilidades",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_Indicadores_IdBascula",
				table: "Indicadores",
				column: "IdBascula");

			migrationBuilder.CreateIndex(
				name: "IX_Indicadores_IdMedidor",
				table: "Indicadores",
				column: "IdMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_InformesLib_DefaultPrinterId",
				table: "InformesLib",
				column: "DefaultPrinterId");

			migrationBuilder.CreateIndex(
				name: "IX_InformesLib_IdCategoria",
				table: "InformesLib",
				column: "IdCategoria");

			migrationBuilder.CreateIndex(
				name: "IX_InformesLib_IdInformeBase",
				table: "InformesLib",
				column: "IdInformeBase");

			migrationBuilder.CreateIndex(
				name: "IX_InformesLibUsuarios_DefaultPrinterId",
				table: "InformesLibUsuarios",
				column: "DefaultPrinterId");

			migrationBuilder.CreateIndex(
				name: "IX_InformesLibUsuarios_IdInforme",
				table: "InformesLibUsuarios",
				column: "IdInforme");

			migrationBuilder.CreateIndex(
				name: "IX_InformesLibUsuarios_IdUsuario",
				table: "InformesLibUsuarios",
				column: "IdUsuario");

			migrationBuilder.CreateIndex(
				name: "IX_LineasCompra_Compra",
				table: "LineasCompra",
				column: "Compra");

			migrationBuilder.CreateIndex(
				name: "IX_LineasCompra_Envase",
				table: "LineasCompra",
				column: "Envase");

			migrationBuilder.CreateIndex(
				name: "IX_LineasCompra_Formato",
				table: "LineasCompra",
				column: "Formato");

			migrationBuilder.CreateIndex(
				name: "IX_LineasCompra_IdContrato",
				table: "LineasCompra",
				column: "IdContrato");

			migrationBuilder.CreateIndex(
				name: "IX_LineasCompra_Producto",
				table: "LineasCompra",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_LineasCompra_Unidad",
				table: "LineasCompra",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IX_LineasCompra_idLineaEntrada",
				table: "LineasCompra",
				column: "idLineaEntrada");

			migrationBuilder.CreateIndex(
				name: "IX_LineaVentaLineaSalida_idLineaSalida",
				table: "LineaVentaLineaSalida",
				column: "idLineaSalida");

			migrationBuilder.CreateIndex(
				name: "IX_LineaVentaLineaSalida_idLineaVenta",
				table: "LineaVentaLineaSalida",
				column: "idLineaVenta");

			migrationBuilder.CreateIndex(
				name: "IX_LogMovimientosStocks_IdLote",
				table: "LogMovimientosStocks",
				column: "IdLote");

			migrationBuilder.CreateIndex(
				name: "IX_LogMovimientosStocks_IdProducto",
				table: "LogMovimientosStocks",
				column: "IdProducto");

			migrationBuilder.CreateIndex(
				name: "_dta_index_LogMovimientosStocks_1",
				table: "LogMovimientosStocks",
				column: "IdStock");

			migrationBuilder.CreateIndex(
				name: "IX_LogMovimientosStocks_IdUbicacion",
				table: "LogMovimientosStocks",
				column: "IdUbicacion");

			migrationBuilder.CreateIndex(
				name: "IX_LogMovimientosStocks_Medidor",
				table: "LogMovimientosStocks",
				column: "Medidor");

			migrationBuilder.CreateIndex(
				name: "IX_LogMovimientosStocks_Modulo",
				table: "LogMovimientosStocks",
				column: "Modulo");

			migrationBuilder.CreateIndex(
				name: "IX_LogMovimientosStocks_Operario",
				table: "LogMovimientosStocks",
				column: "Operario");

			migrationBuilder.CreateIndex(
				name: "IX_LogMovimientosStocks_idOrden",
				table: "LogMovimientosStocks",
				column: "idOrden");

			migrationBuilder.CreateIndex(
				name: "IX_Lotes_Formato",
				table: "Lotes",
				column: "Formato");

			migrationBuilder.CreateIndex(
				name: "IX_Lotes_IdProveedor",
				table: "Lotes",
				column: "IdProveedor");

			migrationBuilder.CreateIndex(
				name: "IX_Lotes_Medicacion",
				table: "Lotes",
				column: "Medicacion");

			migrationBuilder.CreateIndex(
				name: "ILotesProdFecha",
				table: "Lotes",
				columns: new[] { "Producto", "Fecha" });

			migrationBuilder.CreateIndex(
				name: "IX_LotesMezclados_idLoteNuevo",
				table: "LotesMezclados",
				column: "idLoteNuevo");

			migrationBuilder.CreateIndex(
				name: "IX_LotesMezclados_idLoteOrigen",
				table: "LotesMezclados",
				column: "idLoteOrigen");

			migrationBuilder.CreateIndex(
				name: "IX_Maquinas_Sesion",
				table: "Maquinas",
				column: "Sesion");

			migrationBuilder.CreateIndex(
				name: "IX_Maquinas_SesionNotificacion",
				table: "Maquinas",
				column: "SesionNotificacion");

			migrationBuilder.CreateIndex(
				name: "IX_Medicaciones_Afeccion",
				table: "Medicaciones",
				column: "Afeccion");

			migrationBuilder.CreateIndex(
				name: "IX_MedicacionesIngredientes_Producto",
				table: "MedicacionesIngredientes",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_MedicacionesIngredientes_Unidad",
				table: "MedicacionesIngredientes",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IX_Medidores_FamiliaMedidor",
				table: "Medidores",
				column: "FamiliaMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_Medidores_IdBascula",
				table: "Medidores",
				column: "IdBascula");

			migrationBuilder.CreateIndex(
				name: "IX_Medidores_Modulo",
				table: "Medidores",
				column: "Modulo");

			migrationBuilder.CreateIndex(
				name: "IX_Medidores_idPlantillaOculta",
				table: "Medidores",
				column: "idPlantillaOculta");

			migrationBuilder.CreateIndex(
				name: "IX_MedidoresDosificaciones_idMedidor",
				table: "MedidoresDosificaciones",
				column: "idMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_MedidoresDosificaciones_idOrigen",
				table: "MedidoresDosificaciones",
				column: "idOrigen");

			migrationBuilder.CreateIndex(
				name: "IX_MedidoresDosificaciones_idProducto",
				table: "MedidoresDosificaciones",
				column: "idProducto");

			migrationBuilder.CreateIndex(
				name: "IX_Modulos_Departamento",
				table: "Modulos",
				column: "Departamento");

			migrationBuilder.CreateIndex(
				name: "IX_Modulos_ModuloAsociadoOrdenes1",
				table: "Modulos",
				column: "ModuloAsociadoOrdenes1");

			migrationBuilder.CreateIndex(
				name: "IX_Modulos_ModuloAsociadoOrdenes2",
				table: "Modulos",
				column: "ModuloAsociadoOrdenes2");

			migrationBuilder.CreateIndex(
				name: "IX_Modulos_OpcConfigId",
				table: "Modulos",
				column: "OpcConfigId");

			migrationBuilder.CreateIndex(
				name: "IX_Modulos_PLCOrdenNumActual",
				table: "Modulos",
				column: "PLCOrdenNumActual");

			migrationBuilder.CreateIndex(
				name: "IX_Modulos_ProdFinalDefecto",
				table: "Modulos",
				column: "ProdFinalDefecto");

			migrationBuilder.CreateIndex(
				name: "IX_Modulos_RolBase",
				table: "Modulos",
				column: "RolBase");

			migrationBuilder.CreateIndex(
				name: "IX_Modulos_idPlantillaBase",
				table: "Modulos",
				column: "idPlantillaBase");

			migrationBuilder.CreateIndex(
				name: "IX_Modulos_idPlantillaLimpieza",
				table: "Modulos",
				column: "idPlantillaLimpieza");

			migrationBuilder.CreateIndex(
				name: "IX_ModulosAscendentes_Ascendente",
				table: "ModulosAscendentes",
				column: "Ascendente");

			migrationBuilder.CreateIndex(
				name: "IX_ModulosAscendentes_Medidor",
				table: "ModulosAscendentes",
				column: "Medidor");

			migrationBuilder.CreateIndex(
				name: "IX_ModulosIncompatibilidades_ModuloBase",
				table: "ModulosIncompatibilidades",
				column: "ModuloBase");

			migrationBuilder.CreateIndex(
				name: "IX_ModulosIncompatibilidades_ModuloRelacionado",
				table: "ModulosIncompatibilidades",
				column: "ModuloRelacionado");

			migrationBuilder.CreateIndex(
				name: "IX_ModulosMotores_MotorId",
				table: "ModulosMotores",
				column: "MotorId");

			migrationBuilder.CreateIndex(
				name: "IX_ModulosTagsScada_Modulo",
				table: "ModulosTagsScada",
				column: "Modulo");

			migrationBuilder.CreateIndex(
				name: "_dta_index_Motores_1",
				table: "Motores",
				column: "LeerEnPLC");

			migrationBuilder.CreateIndex(
				name: "IX_Motores_OpcConfigId",
				table: "Motores",
				column: "OpcConfigId");

			migrationBuilder.CreateIndex(
				name: "IX_MotoresGruposRelacion_idMotor",
				table: "MotoresGruposRelacion",
				column: "idMotor");

			migrationBuilder.CreateIndex(
				name: "IX_MultiDosificaciones_idDosificacion",
				table: "MultiDosificaciones",
				column: "idDosificacion");

			migrationBuilder.CreateIndex(
				name: "IX_MultiDosificaciones_idUbicacion",
				table: "MultiDosificaciones",
				column: "idUbicacion");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_IdDestino",
				table: "NetAlarmas",
				column: "IdDestino");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_IdDestinoPropuesto",
				table: "NetAlarmas",
				column: "IdDestinoPropuesto");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_IdError",
				table: "NetAlarmas",
				column: "IdError");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_IdGrupo",
				table: "NetAlarmas",
				column: "IdGrupo");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_IdOrigen",
				table: "NetAlarmas",
				column: "IdOrigen");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_IdOrigenPropuesto",
				table: "NetAlarmas",
				column: "IdOrigenPropuesto");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_IdSeccion",
				table: "NetAlarmas",
				column: "IdSeccion");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_OpcConfigId",
				table: "NetAlarmas",
				column: "OpcConfigId");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_RespIdLote",
				table: "NetAlarmas",
				column: "RespIdLote");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_RespIdProducto",
				table: "NetAlarmas",
				column: "RespIdProducto");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_Respondido",
				table: "NetAlarmas",
				column: "Respondido");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_Respuesta",
				table: "NetAlarmas",
				column: "Respuesta");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_idDosificacion",
				table: "NetAlarmas",
				column: "idDosificacion");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_idMedidor",
				table: "NetAlarmas",
				column: "idMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_idOrden",
				table: "NetAlarmas",
				column: "idOrden");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_idUbicacion",
				table: "NetAlarmas",
				column: "idUbicacion");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmas_IdModulo_Enviada_PostEnvioProcesada",
				table: "NetAlarmas",
				columns: new[] { "IdModulo", "Enviada", "PostEnvioProcesada" });

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasAutomaticas_IdAlarmasTipo",
				table: "NetAlarmasAutomaticas",
				column: "IdAlarmasTipo");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasAutomaticas_IdMedidor",
				table: "NetAlarmasAutomaticas",
				column: "IdMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasAutomaticas_IdModulo",
				table: "NetAlarmasAutomaticas",
				column: "IdModulo");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasAutomaticas_IdNetAlarmasRespuesta",
				table: "NetAlarmasAutomaticas",
				column: "IdNetAlarmasRespuesta");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasAutomaticas_IdUbicacion",
				table: "NetAlarmasAutomaticas",
				column: "IdUbicacion");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasAutomaticasOrdenUbicaciones_IdDosificacion",
				table: "NetAlarmasAutomaticasOrdenUbicaciones",
				column: "IdDosificacion");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasAutomaticasOrdenUbicaciones_IdNetAlarmaAutomatica",
				table: "NetAlarmasAutomaticasOrdenUbicaciones",
				column: "IdNetAlarmaAutomatica");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasAutomaticasOrdenUbicaciones_IdOrden",
				table: "NetAlarmasAutomaticasOrdenUbicaciones",
				column: "IdOrden");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasAutomaticasOrdenUbicaciones_IdUbicacion",
				table: "NetAlarmasAutomaticasOrdenUbicaciones",
				column: "IdUbicacion");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasTipos_RolShow",
				table: "NetAlarmasTipos",
				column: "RolShow");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasTipos_UserShow",
				table: "NetAlarmasTipos",
				column: "UserShow");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasTiposRespuestas_idRespuesta",
				table: "NetAlarmasTiposRespuestas",
				column: "idRespuesta");

			migrationBuilder.CreateIndex(
				name: "IX_NetAlarmasTiposRespuestas_idTipo",
				table: "NetAlarmasTiposRespuestas",
				column: "idTipo");

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

			migrationBuilder.CreateIndex(
				name: "IX_OpcConfig_GatewayId",
				table: "OpcConfig",
				column: "GatewayId");

			migrationBuilder.CreateIndex(
				name: "IX_OpcionesRoles_idRol",
				table: "OpcionesRoles",
				column: "idRol");

			migrationBuilder.CreateIndex(
				name: "IX_OpcionesUsuarios_idUsuario",
				table: "OpcionesUsuarios",
				column: "idUsuario");

			migrationBuilder.CreateIndex(
				name: "IX_OperCabPlantillas_IdModulo",
				table: "OperCabPlantillas",
				column: "IdModulo");

			migrationBuilder.CreateIndex(
				name: "IX_OperMotores_IdMedidor",
				table: "OperMotores",
				column: "IdMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_OperMotores_OpcConfigId",
				table: "OperMotores",
				column: "OpcConfigId");

			migrationBuilder.CreateIndex(
				name: "IX_OperMotores_idAccionMotor",
				table: "OperMotores",
				column: "idAccionMotor");

			migrationBuilder.CreateIndex(
				name: "IX_OperMotores_idMedidorForzado",
				table: "OperMotores",
				column: "idMedidorForzado");

			migrationBuilder.CreateIndex(
				name: "IX_OperMotoresModulos_IdMedidor",
				table: "OperMotoresModulos",
				column: "IdMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_OperMotoresModulos_IdModulo",
				table: "OperMotoresModulos",
				column: "IdModulo");

			migrationBuilder.CreateIndex(
				name: "IX_OperMotoresModulos_IdOperMotor",
				table: "OperMotoresModulos",
				column: "IdOperMotor");

			migrationBuilder.CreateIndex(
				name: "IX_OperPlantillas_IdOperAccion",
				table: "OperPlantillas",
				column: "IdOperAccion");

			migrationBuilder.CreateIndex(
				name: "IX_OperPlantillas_IdOperCabPlantillas",
				table: "OperPlantillas",
				column: "IdOperCabPlantillas");

			migrationBuilder.CreateIndex(
				name: "IX_OperPlantillas_IdOperMotor",
				table: "OperPlantillas",
				column: "IdOperMotor");

			migrationBuilder.CreateIndex(
				name: "IX_OperPlantillas_IdProducto",
				table: "OperPlantillas",
				column: "IdProducto");

			migrationBuilder.CreateIndex(
				name: "IX_OperPlantillas_IdTempControl",
				table: "OperPlantillas",
				column: "IdTempControl");

			migrationBuilder.CreateIndex(
				name: "IX_OperPlantillas_IdUbicacion",
				table: "OperPlantillas",
				column: "IdUbicacion");

			migrationBuilder.CreateIndex(
				name: "IX_OperPlantillas_Medidor",
				table: "OperPlantillas",
				column: "Medidor");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_Departamento",
				table: "Ordenes",
				column: "Departamento");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_Entrada",
				table: "Ordenes",
				column: "Entrada");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_EnvaseOrigen",
				table: "Ordenes",
				column: "EnvaseOrigen");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_Formula",
				table: "Ordenes",
				column: "Formula");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_IdCab",
				table: "Ordenes",
				column: "IdCab");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_IdVehiculo",
				table: "Ordenes",
				column: "IdVehiculo");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_LineaEntrada",
				table: "Ordenes",
				column: "LineaEntrada");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_LineaSalida",
				table: "Ordenes",
				column: "LineaSalida");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_LoteDestino",
				table: "Ordenes",
				column: "LoteDestino");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_Medicacion",
				table: "Ordenes",
				column: "Medicacion");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_Modulo",
				table: "Ordenes",
				column: "Modulo");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_ProductoDestino",
				table: "Ordenes",
				column: "ProductoDestino");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_VentaLineaId",
				table: "Ordenes",
				column: "VentaLineaId");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_Version",
				table: "Ordenes",
				column: "Version");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_ViajeSalida",
				table: "Ordenes",
				column: "ViajeSalida");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_idChofer",
				table: "Ordenes",
				column: "idChofer");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_idTarjeta",
				table: "Ordenes",
				column: "idTarjeta");

			migrationBuilder.CreateIndex(
				name: "IX_OrdenesAutoInicio_idOrden",
				table: "OrdenesAutoInicio",
				column: "idOrden");

			migrationBuilder.CreateIndex(
				name: "IX_OrdenesAutoInicio_idOrdenObjetivo",
				table: "OrdenesAutoInicio",
				column: "idOrdenObjetivo");

			migrationBuilder.CreateIndex(
				name: "IX_OrdenesRelacion_idOrdenHijo",
				table: "OrdenesRelacion",
				column: "idOrdenHijo");

			migrationBuilder.CreateIndex(
				name: "IX_OrdenesRelacion_idOrdenPadre",
				table: "OrdenesRelacion",
				column: "idOrdenPadre");

			migrationBuilder.CreateIndex(
				name: "IX_OrdenesTransicionEstadosHistory_IdOrden",
				table: "OrdenesTransicionEstadosHistory",
				column: "IdOrden");

			migrationBuilder.CreateIndex(
				name: "IX_Origenes_Medidor",
				table: "Origenes",
				column: "Medidor");

			migrationBuilder.CreateIndex(
				name: "IX_Origenes_Ubicacion",
				table: "Origenes",
				column: "Ubicacion");

			migrationBuilder.CreateIndex(
				name: "IX_Pistolas_IdMedidor",
				table: "Pistolas",
				column: "IdMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_PrintJobs_PrinterId",
				table: "PrintJobs",
				column: "PrinterId");

			migrationBuilder.CreateIndex(
				name: "IX_ProductoMedidorCamino_MedidorId",
				table: "ProductoMedidorCamino",
				column: "MedidorId");

			migrationBuilder.CreateIndex(
				name: "IX_ProductoMedidorCamino_ProductoId",
				table: "ProductoMedidorCamino",
				column: "ProductoId");

			migrationBuilder.CreateIndex(
				name: "IX_ProductoMedidorCamino_CaminoId_MedidorId_ProductoId",
				table: "ProductoMedidorCamino",
				columns: new[] { "CaminoId", "MedidorId", "ProductoId" },
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Productos_Afeccion",
				table: "Productos",
				column: "Afeccion");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_DestinoDefecto",
				table: "Productos",
				column: "DestinoDefecto");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_Envase",
				table: "Productos",
				column: "Envase");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_EtiquetaControl",
				table: "Productos",
				column: "EtiquetaControl");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_EtiquetaEntradas",
				table: "Productos",
				column: "EtiquetaEntradas");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_EtiquetaGranel",
				table: "Productos",
				column: "EtiquetaGranel");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_EtiquetaMuestras",
				table: "Productos",
				column: "EtiquetaMuestras");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_EtiquetaSacos",
				table: "Productos",
				column: "EtiquetaSacos");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_Familia",
				table: "Productos",
				column: "Familia");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_FamiliaMedidor",
				table: "Productos",
				column: "FamiliaMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_Formato",
				table: "Productos",
				column: "Formato");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_Medidor",
				table: "Productos",
				column: "Medidor");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_Modulo",
				table: "Productos",
				column: "Modulo");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_PlantillaCabCargaPiquera",
				table: "Productos",
				column: "PlantillaCabCargaPiquera");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_PlantillaCabCargaPiquera2",
				table: "Productos",
				column: "PlantillaCabCargaPiquera2");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_PlantillaCabMolturacion",
				table: "Productos",
				column: "PlantillaCabMolturacion");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_PlantillaCabProduccion",
				table: "Productos",
				column: "PlantillaCabProduccion");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_PlantillaCabProduccion2",
				table: "Productos",
				column: "PlantillaCabProduccion2");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_PlantillaCabProduccion3",
				table: "Productos",
				column: "PlantillaCabProduccion3");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_PlantillaCabSecadero",
				table: "Productos",
				column: "PlantillaCabSecadero");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_TipoIva",
				table: "Productos",
				column: "TipoIva");

			migrationBuilder.CreateIndex(
				name: "IX_Productos_Unidad",
				table: "Productos",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IX_ProductosEnvasesEtiquetas_EnvaseId",
				table: "ProductosEnvasesEtiquetas",
				column: "EnvaseId");

			migrationBuilder.CreateIndex(
				name: "IX_ProductosGruposIncompatibilidades_IdGrupoIncompatibilidad",
				table: "ProductosGruposIncompatibilidades",
				column: "IdGrupoIncompatibilidad");

			migrationBuilder.CreateIndex(
				name: "IX_ProductosOperCabPlantillas_IdOperCabPlantilla",
				table: "ProductosOperCabPlantillas",
				column: "IdOperCabPlantilla");

			migrationBuilder.CreateIndex(
				name: "IX_ProductosOperCabPlantillas_IdProducto",
				table: "ProductosOperCabPlantillas",
				column: "IdProducto");

			migrationBuilder.CreateIndex(
				name: "IX_Proveedores_Pais",
				table: "Proveedores",
				column: "Pais");

			migrationBuilder.CreateIndex(
				name: "IX_Proveedores_Provincia",
				table: "Proveedores",
				column: "Provincia");

			migrationBuilder.CreateIndex(
				name: "IX_ProveedoresOrigenes_Pais",
				table: "ProveedoresOrigenes",
				column: "Pais");

			migrationBuilder.CreateIndex(
				name: "IX_ProveedoresOrigenes_Proveedor",
				table: "ProveedoresOrigenes",
				column: "Proveedor");

			migrationBuilder.CreateIndex(
				name: "IX_ProveedoresOrigenes_Provincia",
				table: "ProveedoresOrigenes",
				column: "Provincia");

			migrationBuilder.CreateIndex(
				name: "IX_Provincias_Pais",
				table: "Provincias",
				column: "Pais");

			migrationBuilder.CreateIndex(
				name: "IX_PuntosDescarga_idDomicilio",
				table: "PuntosDescarga",
				column: "idDomicilio");

			migrationBuilder.CreateIndex(
				name: "IX_Recetas_EspecieId",
				table: "Recetas",
				column: "EspecieId");

			migrationBuilder.CreateIndex(
				name: "IX_Recetas_MedicacionId",
				table: "Recetas",
				column: "MedicacionId");

			migrationBuilder.CreateIndex(
				name: "IX_Recetas_idAfeccion",
				table: "Recetas",
				column: "idAfeccion");

			migrationBuilder.CreateIndex(
				name: "IX_Recetas_idCliente",
				table: "Recetas",
				column: "idCliente");

			migrationBuilder.CreateIndex(
				name: "IX_Recetas_idDomicilio",
				table: "Recetas",
				column: "idDomicilio");

			migrationBuilder.CreateIndex(
				name: "IX_Recetas_idProducto",
				table: "Recetas",
				column: "idProducto");

			migrationBuilder.CreateIndex(
				name: "IX_Recetas_idSalidaLinea",
				table: "Recetas",
				column: "idSalidaLinea");

			migrationBuilder.CreateIndex(
				name: "IX_Recetas_idSerie",
				table: "Recetas",
				column: "idSerie");

			migrationBuilder.CreateIndex(
				name: "IX_Recetas_idVeterinario",
				table: "Recetas",
				column: "idVeterinario");

			migrationBuilder.CreateIndex(
				name: "IX_RecetasLineas_ProductoId",
				table: "RecetasLineas",
				column: "ProductoId");

			migrationBuilder.CreateIndex(
				name: "IX_RecetasLineas_idReceta",
				table: "RecetasLineas",
				column: "idReceta");

			migrationBuilder.CreateIndex(
				name: "IX_Regularizaciones_Envase",
				table: "Regularizaciones",
				column: "Envase");

			migrationBuilder.CreateIndex(
				name: "IX_Regularizaciones_Formato",
				table: "Regularizaciones",
				column: "Formato");

			migrationBuilder.CreateIndex(
				name: "IX_Regularizaciones_Lote",
				table: "Regularizaciones",
				column: "Lote");

			migrationBuilder.CreateIndex(
				name: "IX_Regularizaciones_Producto",
				table: "Regularizaciones",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_Regularizaciones_Serie",
				table: "Regularizaciones",
				column: "Serie");

			migrationBuilder.CreateIndex(
				name: "IX_Regularizaciones_Ubicacion",
				table: "Regularizaciones",
				column: "Ubicacion");

			migrationBuilder.CreateIndex(
				name: "IX_Regularizaciones_Unidad",
				table: "Regularizaciones",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IX_Regularizaciones_Usuario",
				table: "Regularizaciones",
				column: "Usuario");

			migrationBuilder.CreateIndex(
				name: "_dta_index_Resultados_1",
				table: "Resultados",
				column: "FinalMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_Resultados_Formato",
				table: "Resultados",
				column: "Formato");

			migrationBuilder.CreateIndex(
				name: "IX_Resultados_Lote",
				table: "Resultados",
				column: "Lote");

			migrationBuilder.CreateIndex(
				name: "IX_Resultados_Medidor",
				table: "Resultados",
				column: "Medidor");

			migrationBuilder.CreateIndex(
				name: "IX_Resultados_Producto",
				table: "Resultados",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_Resultados_Ubicacion",
				table: "Resultados",
				column: "Ubicacion");

			migrationBuilder.CreateIndex(
				name: "IX_Resultados_Unidad",
				table: "Resultados",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "PK_ResultadosOrdenProducto",
				table: "Resultados",
				columns: new[] { "Orden", "Producto" });

			migrationBuilder.CreateIndex(
				name: "_dta_index_Resultados_6_1531152500__K3_K1_K16_K15_7",
				table: "Resultados",
				columns: new[] { "Cantidad", "Orden", "Id", "Producto", "Lote" });

			migrationBuilder.CreateIndex(
				name: "IX_Salidas_IdDepartamento",
				table: "Salidas",
				column: "IdDepartamento");

			migrationBuilder.CreateIndex(
				name: "IX_Salidas_idCliente",
				table: "Salidas",
				column: "idCliente");

			migrationBuilder.CreateIndex(
				name: "IX_Salidas_idSerie",
				table: "Salidas",
				column: "idSerie");

			migrationBuilder.CreateIndex(
				name: "IX_Salidas_idViaje",
				table: "Salidas",
				column: "idViaje");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasAlbaranes_Serie",
				table: "SalidasAlbaranes",
				column: "Serie");

			migrationBuilder.CreateIndex(
				name: "ISalAlbNumSerie",
				table: "SalidasAlbaranes",
				columns: new[] { "Numero", "Serie" });

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_MedicacionId",
				table: "SalidasLinias",
				column: "MedicacionId");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_Origen1",
				table: "SalidasLinias",
				column: "Origen1");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_Origen2",
				table: "SalidasLinias",
				column: "Origen2");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_Origen3",
				table: "SalidasLinias",
				column: "Origen3");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_Origen4",
				table: "SalidasLinias",
				column: "Origen4");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_idAlbaran",
				table: "SalidasLinias",
				column: "idAlbaran");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_idBasculaPesajeBruto",
				table: "SalidasLinias",
				column: "idBasculaPesajeBruto");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_idBasculaPesajeNeto",
				table: "SalidasLinias",
				column: "idBasculaPesajeNeto");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_idDomicilio",
				table: "SalidasLinias",
				column: "idDomicilio");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_idEnvase",
				table: "SalidasLinias",
				column: "idEnvase");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_idFormato",
				table: "SalidasLinias",
				column: "idFormato");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_idProducto",
				table: "SalidasLinias",
				column: "idProducto");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_idPuntoDescarga",
				table: "SalidasLinias",
				column: "idPuntoDescarga");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_idSalidas",
				table: "SalidasLinias",
				column: "idSalidas");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_idUnidad",
				table: "SalidasLinias",
				column: "idUnidad");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_idmodulo",
				table: "SalidasLinias",
				column: "idmodulo");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_idviajes",
				table: "SalidasLinias",
				column: "idviajes");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasLote_idLineaSalida",
				table: "SalidasLiniasLote",
				column: "idLineaSalida");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasLote_idLineaSalidaMedicamento",
				table: "SalidasLiniasLote",
				column: "idLineaSalidaMedicamento");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasLote_idLote",
				table: "SalidasLiniasLote",
				column: "idLote");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasMedicaciones_IdUnidad",
				table: "SalidasLiniasMedicaciones",
				column: "IdUnidad");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasMedicaciones_ProductoId",
				table: "SalidasLiniasMedicaciones",
				column: "ProductoId");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasMedicaciones_idEnvase",
				table: "SalidasLiniasMedicaciones",
				column: "idEnvase");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasMedicaciones_idFormato",
				table: "SalidasLiniasMedicaciones",
				column: "idFormato");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasMedicaciones_idOrigen",
				table: "SalidasLiniasMedicaciones",
				column: "idOrigen");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasMedicaciones_idSalidaLinia",
				table: "SalidasLiniasMedicaciones",
				column: "idSalidaLinia");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasMuestras_idControlesNir",
				table: "SalidasLiniasMuestras",
				column: "idControlesNir");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasMuestras_idSalidasLineas",
				table: "SalidasLiniasMuestras",
				column: "idSalidasLineas");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasPuntosDescarga_idLineaSalida",
				table: "SalidasLiniasPuntosDescarga",
				column: "idLineaSalida");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasPuntosDescarga_idPuntoDescarga",
				table: "SalidasLiniasPuntosDescarga",
				column: "idPuntoDescarga");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasViajes_idChofer",
				table: "SalidasViajes",
				column: "idChofer");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasViajes_idEmpresaTransporte",
				table: "SalidasViajes",
				column: "idEmpresaTransporte");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasViajes_idSerie",
				table: "SalidasViajes",
				column: "idSerie");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasViajes_idTarjeta",
				table: "SalidasViajes",
				column: "idTarjeta");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasViajes_idVehiculo",
				table: "SalidasViajes",
				column: "idVehiculo");

			migrationBuilder.CreateIndex(
				name: "ISalidasViajes",
				table: "SalidasViajes",
				columns: new[] { "id", "MatriculaRemolque", "idVehiculo", "idChofer", "idTarjeta", "EstadoTransito", "MatriculaCamion", "NombreConductor", "Observaciones", "idEmpresaTransporte", "FInicioTransito", "FInicioViaje", "FFinViaje", "Referencia", "FechaPrevista", "idSerie", "Numero", "PreDesinfeccion", "PostDesinfeccion", "FechaCreacion", "Estado", "FFinalTransito" });

			migrationBuilder.CreateIndex(
				name: "IX_Secciones_OpcConfigId",
				table: "Secciones",
				column: "OpcConfigId");

			migrationBuilder.CreateIndex(
				name: "IX_SeccionesGrupos_OpcConfigId",
				table: "SeccionesGrupos",
				column: "OpcConfigId");

			migrationBuilder.CreateIndex(
				name: "IX_SesionesModulo_Modulo",
				table: "SesionesModulo",
				column: "Modulo");

			migrationBuilder.CreateIndex(
				name: "IX_SesionesModulo_Sesion",
				table: "SesionesModulo",
				column: "Sesion");

			migrationBuilder.CreateIndex(
				name: "IX_SesionesSeccion_Seccion",
				table: "SesionesSeccion",
				column: "Seccion");

			migrationBuilder.CreateIndex(
				name: "IX_SesionesSeccion_Sesion",
				table: "SesionesSeccion",
				column: "Sesion");

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

			migrationBuilder.CreateIndex(
				name: "_dta_index_StatusDisks_1",
				table: "StatusDisks",
				column: "Id");

			migrationBuilder.CreateIndex(
				name: "IX_Stocks_Envase",
				table: "Stocks",
				column: "Envase");

			migrationBuilder.CreateIndex(
				name: "IX_Stocks_Formato",
				table: "Stocks",
				column: "Formato");

			migrationBuilder.CreateIndex(
				name: "IX_Stocks_Lote",
				table: "Stocks",
				column: "Lote");

			migrationBuilder.CreateIndex(
				name: "IX_Stocks_Ubicacion",
				table: "Stocks",
				column: "Ubicacion");

			migrationBuilder.CreateIndex(
				name: "IX_Stocks_Unidad",
				table: "Stocks",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IX_Stocks_idEntradasLineas",
				table: "Stocks",
				column: "idEntradasLineas");

			migrationBuilder.CreateIndex(
				name: "IX_Stocks_idSalidasLineas",
				table: "Stocks",
				column: "idSalidasLineas");

			migrationBuilder.CreateIndex(
				name: "IX_StocksReserva_idEntradasLineas",
				table: "StocksReserva",
				column: "idEntradasLineas");

			migrationBuilder.CreateIndex(
				name: "IX_StocksReserva_idLote",
				table: "StocksReserva",
				column: "idLote");

			migrationBuilder.CreateIndex(
				name: "IX_StocksReserva_idOrden",
				table: "StocksReserva",
				column: "idOrden");

			migrationBuilder.CreateIndex(
				name: "IX_StocksReserva_idProducto",
				table: "StocksReserva",
				column: "idProducto");

			migrationBuilder.CreateIndex(
				name: "IX_StocksReserva_idSalidasLineas",
				table: "StocksReserva",
				column: "idSalidasLineas");

			migrationBuilder.CreateIndex(
				name: "IX_StocksReserva_idSalidasLineasMedic",
				table: "StocksReserva",
				column: "idSalidasLineasMedic");

			migrationBuilder.CreateIndex(
				name: "IX_StocksReserva_idStock",
				table: "StocksReserva",
				column: "idStock");

			migrationBuilder.CreateIndex(
				name: "IX_StocksReserva_idUbicacion",
				table: "StocksReserva",
				column: "idUbicacion");

			migrationBuilder.CreateIndex(
				name: "IX_Tags_OpcConfigId",
				table: "Tags",
				column: "OpcConfigId");

			migrationBuilder.CreateIndex(
				name: "IX_Tags_Ubicacion",
				table: "Tags",
				column: "Ubicacion");

			migrationBuilder.CreateIndex(
				name: "IX_Tags_idLecturaTag",
				table: "Tags",
				column: "idLecturaTag");

			migrationBuilder.CreateIndex(
				name: "IX_Tags_idModulo",
				table: "Tags",
				column: "idModulo");

			migrationBuilder.CreateIndex(
				name: "IX_TagsBasculas_idBascula",
				table: "TagsBasculas",
				column: "idBascula");

			migrationBuilder.CreateIndex(
				name: "IX_TagsBasculas_idTag",
				table: "TagsBasculas",
				column: "idTag");

			migrationBuilder.CreateIndex(
				name: "IX_TagsLecturas_idTag",
				table: "TagsLecturas",
				column: "idTag");

			migrationBuilder.CreateIndex(
				name: "BusquedaTagsLecturas",
				table: "TagsLecturas",
				columns: new[] { "Tratado", "idTag", "FTratado" });

			migrationBuilder.CreateIndex(
				name: "IX_Tarifas_Cliente",
				table: "Tarifas",
				column: "Cliente");

			migrationBuilder.CreateIndex(
				name: "IX_Tarifas_Envase",
				table: "Tarifas",
				column: "Envase");

			migrationBuilder.CreateIndex(
				name: "IX_Tarifas_Medicacion",
				table: "Tarifas",
				column: "Medicacion");

			migrationBuilder.CreateIndex(
				name: "IX_Tarifas_Producto",
				table: "Tarifas",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_Tarifas_Unidad",
				table: "Tarifas",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IX_Tarjetas_IdLinEntrada",
				table: "Tarjetas",
				column: "IdLinEntrada");

			migrationBuilder.CreateIndex(
				name: "IX_Tarjetas_IdOrdenActual",
				table: "Tarjetas",
				column: "IdOrdenActual");

			migrationBuilder.CreateIndex(
				name: "IX_Tarjetas_IdLinSalida",
				table: "Tarjetas",
				column: "IdLinSalida");

			migrationBuilder.CreateIndex(
				name: "IX_TempControlesMedidores_idMedidor",
				table: "TempControlesMedidores",
				column: "idMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_TempControlesMedidores_idTempControl",
				table: "TempControlesMedidores",
				column: "idTempControl");

			migrationBuilder.CreateIndex(
				name: "NonClusteredIndex-20180409-131855",
				table: "TextosParametros",
				columns: new[] { "Grupo", "Parametro", "IdTexto" },
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_TiempoLimpieza_UbicacionId",
				table: "TiempoLimpieza",
				column: "UbicacionId");

			migrationBuilder.CreateIndex(
				name: "IX_Ubicaciones_Asociacion",
				table: "Ubicaciones",
				column: "Asociacion");

			migrationBuilder.CreateIndex(
				name: "IX_Ubicaciones_AvisosSesion",
				table: "Ubicaciones",
				column: "AvisosSesion");

			migrationBuilder.CreateIndex(
				name: "IX_Ubicaciones_Departamento",
				table: "Ubicaciones",
				column: "Departamento");

			migrationBuilder.CreateIndex(
				name: "IX_Ubicaciones_Formato",
				table: "Ubicaciones",
				column: "Formato");

			migrationBuilder.CreateIndex(
				name: "IX_Ubicaciones_Lote",
				table: "Ubicaciones",
				column: "Lote");

			migrationBuilder.CreateIndex(
				name: "_dta_index_Ubicaciones_2",
				table: "Ubicaciones",
				column: "ModoBigBag");

			migrationBuilder.CreateIndex(
				name: "IX_Ubicaciones_OpcConfigId",
				table: "Ubicaciones",
				column: "OpcConfigId");

			migrationBuilder.CreateIndex(
				name: "IX_Ubicaciones_Ordenacion",
				table: "Ubicaciones",
				column: "Ordenacion");

			migrationBuilder.CreateIndex(
				name: "IX_Ubicaciones_Producto",
				table: "Ubicaciones",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_Ubicaciones_Unidad",
				table: "Ubicaciones",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "_dta_index_Ubicaciones_1",
				table: "Ubicaciones",
				columns: new[] { "Id", "Nombre", "Departamento", "Referencia", "Tipo", "CargaManual", "DescargaManual", "Capacidad", "Unidad", "Individual", "Producto", "Formato", "Prioridad", "Stock", "ControlStock", "AvisosActivo", "AvisosEquipo", "MezcladoDiasMinimoFCaducidad", "Visible", "Ordenacion" });

			migrationBuilder.CreateIndex(
				name: "IndexUbicaciones_1",
				table: "Ubicaciones",
				columns: new[] { "Id", "Nombre", "Departamento", "Referencia", "Tipo", "CargaManual", "DescargaManual", "Capacidad", "Unidad", "Individual", "Producto", "Formato", "Prioridad", "Stock", "ControlStock", "AvisosActivo", "AvisosEquipo", "MezcladoDiasMinimoFCaducidad", "TipoPR", "ColaPropuesta", "Visible", "Ordenacion" });

			migrationBuilder.CreateIndex(
				name: "IUbicaciones1",
				table: "Ubicaciones",
				columns: new[] { "Id", "Nombre", "Departamento", "Referencia", "Tipo", "CargaManual", "DescargaManual", "Capacidad", "Unidad", "Individual", "Producto", "Formato", "Prioridad", "Stock", "ControlStock", "AvisosActivo", "AvisosEquipo", "MezcladoDiasMinimoFCaducidad", "TipoPR", "ColaPropuesta", "PaMColaMulti", "Visible", "Ordenacion" });

			migrationBuilder.CreateIndex(
				name: "IX_UbicacionesAsociadas_idUbicacion1",
				table: "UbicacionesAsociadas",
				column: "idUbicacion1");

			migrationBuilder.CreateIndex(
				name: "IX_UbicacionesAsociadas_idUbicacion2",
				table: "UbicacionesAsociadas",
				column: "idUbicacion2");

			migrationBuilder.CreateIndex(
				name: "IX_UbicacionesOpcConfig_OpcConfigId",
				table: "UbicacionesOpcConfig",
				column: "OpcConfigId");

			migrationBuilder.CreateIndex(
				name: "IX_UbisMedsAfino_idMedidor",
				table: "UbisMedsAfino",
				column: "idMedidor");

			migrationBuilder.CreateIndex(
				name: "IX_Usuarios_IdOpc",
				table: "Usuarios",
				column: "IdOpc");

			migrationBuilder.CreateIndex(
				name: "IX_FK_Usuarios_UsuariosRoles",
				table: "Usuarios",
				column: "Rol");

			migrationBuilder.CreateIndex(
				name: "IX_UsuariosGruposLDAP_idRol",
				table: "UsuariosGruposLDAP",
				column: "idRol");

			migrationBuilder.CreateIndex(
				name: "_dta_index_UsuariosLogs_1",
				table: "UsuariosLogs",
				column: "Activo");

			migrationBuilder.CreateIndex(
				name: "IX_UsuariosLogs_idUsuario",
				table: "UsuariosLogs",
				column: "idUsuario");

			migrationBuilder.CreateIndex(
				name: "IX_UsuariosRolesConfigForm_UsuarioRol",
				table: "UsuariosRolesConfigForm",
				column: "UsuarioRol");

			migrationBuilder.CreateIndex(
				name: "IX_UsuariosRolesInformes_idRol",
				table: "UsuariosRolesInformes",
				column: "idRol");

			migrationBuilder.CreateIndex(
				name: "IX_FK_UsuariosRolesModulos_Modulos",
				table: "UsuariosRolesModulos",
				column: "idModulo");

			migrationBuilder.CreateIndex(
				name: "IX_FK_UsuariosRolesModulos_UsuariosRoles",
				table: "UsuariosRolesModulos",
				column: "idRol");

			migrationBuilder.CreateIndex(
				name: "IX_Valores_Orden",
				table: "Valores",
				column: "Orden");

			migrationBuilder.CreateIndex(
				name: "IX_Valores_Variable",
				table: "Valores",
				column: "Variable");

			migrationBuilder.CreateIndex(
				name: "IX_Variables_Modulo",
				table: "Variables",
				column: "Modulo");

			migrationBuilder.CreateIndex(
				name: "IX_Vehiculos_Chofer",
				table: "Vehiculos",
				column: "Chofer");

			migrationBuilder.CreateIndex(
				name: "IX_Vehiculos_EmpresaTransporte",
				table: "Vehiculos",
				column: "EmpresaTransporte");

			migrationBuilder.CreateIndex(
				name: "IX_Vehiculos_Tarjeta",
				table: "Vehiculos",
				column: "Tarjeta");

			migrationBuilder.CreateIndex(
				name: "IX_Ventas_Departamento",
				table: "Ventas",
				column: "Departamento");

			migrationBuilder.CreateIndex(
				name: "IX_Ventas_idCliente",
				table: "Ventas",
				column: "idCliente");

			migrationBuilder.CreateIndex(
				name: "IX_Ventas_idDomicilio",
				table: "Ventas",
				column: "idDomicilio");

			migrationBuilder.CreateIndex(
				name: "IX_Ventas_idSerie",
				table: "Ventas",
				column: "idSerie");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLinias_MedEnvase",
				table: "VentasLinias",
				column: "MedEnvase");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLinias_MedFormato",
				table: "VentasLinias",
				column: "MedFormato");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLinias_MedUnidad",
				table: "VentasLinias",
				column: "MedUnidad");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLinias_idContrato",
				table: "VentasLinias",
				column: "idContrato");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLinias_idDomicilio",
				table: "VentasLinias",
				column: "idDomicilio");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLinias_idEnvase",
				table: "VentasLinias",
				column: "idEnvase");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLinias_idFormato",
				table: "VentasLinias",
				column: "idFormato");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLinias_idMedicamento",
				table: "VentasLinias",
				column: "idMedicamento");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLinias_idProducto",
				table: "VentasLinias",
				column: "idProducto");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLinias_idPuntoDescarga",
				table: "VentasLinias",
				column: "idPuntoDescarga");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLinias_idUnidad",
				table: "VentasLinias",
				column: "idUnidad");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLinias_idVentas",
				table: "VentasLinias",
				column: "idVentas");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLiniasMedicaciones_ProductoId",
				table: "VentasLiniasMedicaciones",
				column: "ProductoId");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLiniasMedicaciones_idEnvase",
				table: "VentasLiniasMedicaciones",
				column: "idEnvase");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLiniasMedicaciones_idFormato",
				table: "VentasLiniasMedicaciones",
				column: "idFormato");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLiniasMedicaciones_idUnidad",
				table: "VentasLiniasMedicaciones",
				column: "idUnidad");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLiniasMedicaciones_idVentaLinia",
				table: "VentasLiniasMedicaciones",
				column: "idVentaLinia");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLiniasPuntosDescarga_idLineaVenta",
				table: "VentasLiniasPuntosDescarga",
				column: "idLineaVenta");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLiniasPuntosDescarga_idPuntoDescarga",
				table: "VentasLiniasPuntosDescarga",
				column: "idPuntoDescarga");

			migrationBuilder.CreateIndex(
				name: "IX_Versiones_Formula",
				table: "Versiones",
				column: "Formula");

			migrationBuilder.CreateIndex(
				name: "IX_Versiones_Unidad",
				table: "Versiones",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IX_VersionTPrevisto_idModulo",
				table: "VersionTPrevisto",
				column: "idModulo");

			migrationBuilder.CreateIndex(
				name: "IX_VersionTPrevisto_idVersion",
				table: "VersionTPrevisto",
				column: "idVersion");

			migrationBuilder.CreateIndex(
				name: "IX_Veterinarios_IdEmpresa",
				table: "Veterinarios",
				column: "IdEmpresa");

			migrationBuilder.CreateIndex(
				name: "IX_Veterinarios_ProvinciaId",
				table: "Veterinarios",
				column: "ProvinciaId");

			migrationBuilder.AddForeignKey(
				name: "FK_Productos_Ubicaciones",
				table: "Productos",
				column: "DestinoDefecto",
				principalTable: "Ubicaciones",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Productos_Medidores",
				table: "Productos",
				column: "Medidor",
				principalTable: "Medidores",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Productos_Modulos",
				table: "Productos",
				column: "Modulo",
				principalTable: "Modulos",
				principalColumn: "Id",
				onDelete: ReferentialAction.SetNull);

			migrationBuilder.AddForeignKey(
				name: "FK_Productos_OperCabPlantillas",
				table: "Productos",
				column: "PlantillaCabCargaPiquera",
				principalTable: "OperCabPlantillas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Productos_OperCabPlantillas3",
				table: "Productos",
				column: "PlantillaCabCargaPiquera2",
				principalTable: "OperCabPlantillas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Productos_OperCabPlantillas7",
				table: "Productos",
				column: "PlantillaCabMolturacion",
				principalTable: "OperCabPlantillas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Productos_OperCabPlantillas2",
				table: "Productos",
				column: "PlantillaCabProduccion",
				principalTable: "OperCabPlantillas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Productos_OperCabPlantillas5",
				table: "Productos",
				column: "PlantillaCabProduccion2",
				principalTable: "OperCabPlantillas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Productos_OperCabPlantillas6",
				table: "Productos",
				column: "PlantillaCabProduccion3",
				principalTable: "OperCabPlantillas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Productos_OperCabPlantillas4",
				table: "Productos",
				column: "PlantillaCabSecadero",
				principalTable: "OperCabPlantillas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Recetas_SalidasLinias",
				table: "Recetas",
				column: "idSalidaLinea",
				principalTable: "SalidasLinias",
				principalColumn: "id",
				onDelete: ReferentialAction.SetNull);

			migrationBuilder.AddForeignKey(
				name: "FK_AlertasUsuariosAlarmas_Modulos",
				table: "AlertasUsuariosAlarmas",
				column: "idModulo",
				principalTable: "Modulos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_EntradasLineas_Modulos",
				table: "EntradasLineas",
				column: "idModulo",
				principalTable: "Modulos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_EntradasLineas_Entradas",
				table: "EntradasLineas",
				column: "idEntradas",
				principalTable: "Entradas",
				principalColumn: "id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_EntradasLineas_BasculasBruto",
				table: "EntradasLineas",
				column: "idBasculaPesajeBruto",
				principalTable: "Basculas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_EntradasLineas_BasculasNeto",
				table: "EntradasLineas",
				column: "idBasculaPesajeNeto",
				principalTable: "Basculas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Indicadores_Medidores",
				table: "Indicadores",
				column: "IdMedidor",
				principalTable: "Medidores",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Indicadores_Basculas",
				table: "Indicadores",
				column: "IdBascula",
				principalTable: "Basculas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Medidores_Modulos",
				table: "Medidores",
				column: "Modulo",
				principalTable: "Modulos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Medidores_OperCabPlantillas",
				table: "Medidores",
				column: "idPlantillaOculta",
				principalTable: "OperCabPlantillas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Medidores_Basculas",
				table: "Medidores",
				column: "IdBascula",
				principalTable: "Basculas",
				principalColumn: "Id",
				onDelete: ReferentialAction.SetNull);

			migrationBuilder.AddForeignKey(
				name: "FK_SalidasLinias_Modulos",
				table: "SalidasLinias",
				column: "idmodulo",
				principalTable: "Modulos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_SalidasLinias_SalidasViajes",
				table: "SalidasLinias",
				column: "idviajes",
				principalTable: "SalidasViajes",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_SalidasLinias_BasculasBruto",
				table: "SalidasLinias",
				column: "idBasculaPesajeBruto",
				principalTable: "Basculas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_SalidasLinias_BasculasNeto",
				table: "SalidasLinias",
				column: "idBasculaPesajeNeto",
				principalTable: "Basculas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_SalidasLinias_Salidas",
				table: "SalidasLinias",
				column: "idSalidas",
				principalTable: "Salidas",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_TagsBasculas_Tags",
				table: "TagsBasculas",
				column: "idTag",
				principalTable: "Tags",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_TagsBasculas_Basculas",
				table: "TagsBasculas",
				column: "idBascula",
				principalTable: "Basculas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Ordenes_Modulos",
				table: "Ordenes",
				column: "Modulo",
				principalTable: "Modulos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Ordenes_Entradas",
				table: "Ordenes",
				column: "Entrada",
				principalTable: "Entradas",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Ordenes_Formulas",
				table: "Ordenes",
				column: "Formula",
				principalTable: "Formulas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Ordenes_Versiones",
				table: "Ordenes",
				column: "Version",
				principalTable: "Versiones",
				principalColumn: "Id",
				onDelete: ReferentialAction.SetNull);

			migrationBuilder.AddForeignKey(
				name: "FK_Ordenes_SalidasViajes",
				table: "Ordenes",
				column: "ViajeSalida",
				principalTable: "SalidasViajes",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Ordenes_Vehiculos",
				table: "Ordenes",
				column: "IdVehiculo",
				principalTable: "Vehiculos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Ordenes_Choferes",
				table: "Ordenes",
				column: "idChofer",
				principalTable: "Choferes",
				principalColumn: "Id",
				onDelete: ReferentialAction.SetNull);

			migrationBuilder.AddForeignKey(
				name: "FK_Ordenes_Tarjetas",
				table: "Ordenes",
				column: "idTarjeta",
				principalTable: "Tarjetas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Ordenes_CabOrdenes",
				table: "Ordenes",
				column: "IdCab",
				principalTable: "CabOrdenes",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Formulas_Modulos",
				table: "Formulas",
				column: "Modulo",
				principalTable: "Modulos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Modulos_OperCabPlantillas",
				table: "Modulos",
				column: "idPlantillaBase",
				principalTable: "OperCabPlantillas",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Modulos_OperCabPlantillasLimpieza",
				table: "Modulos",
				column: "idPlantillaLimpieza",
				principalTable: "OperCabPlantillas",
				principalColumn: "Id",
				onDelete: ReferentialAction.SetNull);

			migrationBuilder.AddForeignKey(
				name: "FK_Tags_TagsLecturas",
				table: "Tags",
				column: "idLecturaTag",
				principalTable: "TagsLecturas",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_EntradasLineas_Formatos",
				table: "EntradasLineas");

			migrationBuilder.DropForeignKey(
				name: "FK_Lotes_Formatos",
				table: "Lotes");

			migrationBuilder.DropForeignKey(
				name: "FK_Productos_Formatos",
				table: "Productos");

			migrationBuilder.DropForeignKey(
				name: "FK_SalidasLinias_Formatos",
				table: "SalidasLinias");

			migrationBuilder.DropForeignKey(
				name: "FK_Ubicaciones_Formatos",
				table: "Ubicaciones");

			migrationBuilder.DropForeignKey(
				name: "FKMed_VentasLinias_Formatos",
				table: "VentasLinias");

			migrationBuilder.DropForeignKey(
				name: "FK_VentasLinias_Formatos",
				table: "VentasLinias");

			migrationBuilder.DropForeignKey(
				name: "FK_Modulos_Ordenes",
				table: "Modulos");

			migrationBuilder.DropForeignKey(
				name: "FK_Tarjetas_ordenes",
				table: "Tarjetas");

			migrationBuilder.DropForeignKey(
				name: "FK_EntradasLineas_Productos",
				table: "EntradasLineas");

			migrationBuilder.DropForeignKey(
				name: "FK_Lotes_Productos",
				table: "Lotes");

			migrationBuilder.DropForeignKey(
				name: "FK_Modulos_ProdFinal",
				table: "Modulos");

			migrationBuilder.DropForeignKey(
				name: "FK_SalidasLinias_Productos",
				table: "SalidasLinias");

			migrationBuilder.DropForeignKey(
				name: "FK_Ubicaciones_Productos",
				table: "Ubicaciones");

			migrationBuilder.DropForeignKey(
				name: "FK_EntradasLineas_Ubicaciones1",
				table: "EntradasLineas");

			migrationBuilder.DropForeignKey(
				name: "FK_EntradasLineas_Ubicaciones2",
				table: "EntradasLineas");

			migrationBuilder.DropForeignKey(
				name: "FK_EntradasLineas_Ubicaciones3",
				table: "EntradasLineas");

			migrationBuilder.DropForeignKey(
				name: "FK_EntradasLineas_Ubicaciones4",
				table: "EntradasLineas");

			migrationBuilder.DropForeignKey(
				name: "FK_EntradasLineas_Ubicaciones5",
				table: "EntradasLineas");

			migrationBuilder.DropForeignKey(
				name: "FK_EntradasLineas_Ubicaciones6",
				table: "EntradasLineas");

			migrationBuilder.DropForeignKey(
				name: "FK_EntradasLineas_Ubicaciones7",
				table: "EntradasLineas");

			migrationBuilder.DropForeignKey(
				name: "FK_EntradasLineas_Ubicaciones8",
				table: "EntradasLineas");

			migrationBuilder.DropForeignKey(
				name: "FK_SalidasLinias_Ubicaciones1",
				table: "SalidasLinias");

			migrationBuilder.DropForeignKey(
				name: "FK_SalidasLinias_Ubicaciones2",
				table: "SalidasLinias");

			migrationBuilder.DropForeignKey(
				name: "FK_SalidasLinias_Ubicaciones3",
				table: "SalidasLinias");

			migrationBuilder.DropForeignKey(
				name: "FK_SalidasLinias_Ubicaciones4",
				table: "SalidasLinias");

			migrationBuilder.DropForeignKey(
				name: "FK_Tags_Ubicaciones",
				table: "Tags");

			migrationBuilder.DropForeignKey(
				name: "FK_EntradasLineas_Unidades",
				table: "EntradasLineas");

			migrationBuilder.DropForeignKey(
				name: "FK_Envases_Unidades",
				table: "Envases");

			migrationBuilder.DropForeignKey(
				name: "FK_SalidasLinias_Unidades",
				table: "SalidasLinias");

			migrationBuilder.DropForeignKey(
				name: "FK_EntradasLineas_Modulos",
				table: "EntradasLineas");

			migrationBuilder.DropForeignKey(
				name: "FK_OperCabPlantillas_Modulos",
				table: "OperCabPlantillas");

			migrationBuilder.DropForeignKey(
				name: "FK_SalidasLinias_Modulos",
				table: "SalidasLinias");

			migrationBuilder.DropForeignKey(
				name: "FK_Tags_Modulos",
				table: "Tags");

			migrationBuilder.DropForeignKey(
				name: "FK_Basculas_OpcConfig_OpcConfigId",
				table: "Basculas");

			migrationBuilder.DropForeignKey(
				name: "FK_Tags_OpcConfig_OpcConfigId",
				table: "Tags");

			migrationBuilder.DropForeignKey(
				name: "FK_Basculas_Tags_Tag",
				table: "Basculas");

			migrationBuilder.DropForeignKey(
				name: "FK_TagsLecturas_Tags",
				table: "TagsLecturas");

			migrationBuilder.DropForeignKey(
				name: "FK_EntradasLineas_Lotes",
				table: "EntradasLineas");

			migrationBuilder.DropForeignKey(
				name: "FK_EntradasLineas_Entradas",
				table: "EntradasLineas");

			migrationBuilder.DropForeignKey(
				name: "FK_Salidas_SalidasViajes",
				table: "Salidas");

			migrationBuilder.DropForeignKey(
				name: "FK_SalidasLinias_SalidasViajes",
				table: "SalidasLinias");

			migrationBuilder.DropTable(
				name: "Aditivos");

			migrationBuilder.DropTable(
				name: "Alarmas");

			migrationBuilder.DropTable(
				name: "AlertasUsuariosAlarmas");

			migrationBuilder.DropTable(
				name: "AlertasUsuariosInformesParametros");

			migrationBuilder.DropTable(
				name: "AuditColumns");

			migrationBuilder.DropTable(
				name: "Backups");

			migrationBuilder.DropTable(
				name: "BufferConsumidos");

			migrationBuilder.DropTable(
				name: "BufferERPChoferes");

			migrationBuilder.DropTable(
				name: "BufferERPClienteDomicilioPuntoDescarga");

			migrationBuilder.DropTable(
				name: "BufferERPComponentes");

			migrationBuilder.DropTable(
				name: "BufferERPComprasLineas");

			migrationBuilder.DropTable(
				name: "BufferERPConsumidos");

			migrationBuilder.DropTable(
				name: "BufferERPDocumentos");

			migrationBuilder.DropTable(
				name: "BufferERPEntradasLineasLote");

			migrationBuilder.DropTable(
				name: "BufferERPFormulaProductosFinales");

			migrationBuilder.DropTable(
				name: "BufferERPImprimirDocumentos");

			migrationBuilder.DropTable(
				name: "BufferERPLinOrdenes");

			migrationBuilder.DropTable(
				name: "BufferERPPedidoVenta");

			migrationBuilder.DropTable(
				name: "BufferERPPedidoVentaExtra");

			migrationBuilder.DropTable(
				name: "BufferERPProducidos");

			migrationBuilder.DropTable(
				name: "BufferERPProductos");

			migrationBuilder.DropTable(
				name: "BufferERPProveedores");

			migrationBuilder.DropTable(
				name: "BufferERPRegularizaciones");

			migrationBuilder.DropTable(
				name: "BufferERPSalidasLiniasLote");

			migrationBuilder.DropTable(
				name: "BufferERPSolicitudRegularizacion");

			migrationBuilder.DropTable(
				name: "BufferERPSolicitudTraspaso");

			migrationBuilder.DropTable(
				name: "BufferERPStocks");

			migrationBuilder.DropTable(
				name: "BufferERPVehiculos");

			migrationBuilder.DropTable(
				name: "BufferERPVentasLineas");

			migrationBuilder.DropTable(
				name: "BufferProducidos");

			migrationBuilder.DropTable(
				name: "CertificadoDesinfeccion");

			migrationBuilder.DropTable(
				name: "Componentes");

			migrationBuilder.DropTable(
				name: "ComponentesActivos");

			migrationBuilder.DropTable(
				name: "Comprobaciones");

			migrationBuilder.DropTable(
				name: "ConfigWCF");

			migrationBuilder.DropTable(
				name: "Contadores");

			migrationBuilder.DropTable(
				name: "ControlesNIRProductos");

			migrationBuilder.DropTable(
				name: "Dashboards");

			migrationBuilder.DropTable(
				name: "DashboardsLib");

			migrationBuilder.DropTable(
				name: "Desgloses");

			migrationBuilder.DropTable(
				name: "DestinosMedidores");

			migrationBuilder.DropTable(
				name: "Disposiciones");

			migrationBuilder.DropTable(
				name: "Documentos");

			migrationBuilder.DropTable(
				name: "Dominios");

			migrationBuilder.DropTable(
				name: "EnlaceERPAsigUbi");

			migrationBuilder.DropTable(
				name: "EnlaceERPConversiones");

			migrationBuilder.DropTable(
				name: "EnlaceERPLinea");

			migrationBuilder.DropTable(
				name: "EntradasContratos");

			migrationBuilder.DropTable(
				name: "EntradasLineasResultadosNIR");

			migrationBuilder.DropTable(
				name: "EntradasLotes");

			migrationBuilder.DropTable(
				name: "EventosDetalle");

			migrationBuilder.DropTable(
				name: "Existencias");

			migrationBuilder.DropTable(
				name: "FileGmaoElement");

			migrationBuilder.DropTable(
				name: "FormulaProdModulo");

			migrationBuilder.DropTable(
				name: "GMAO_Archivos_Elementos");

			migrationBuilder.DropTable(
				name: "GMAO_Archivos_Intervenciones");

			migrationBuilder.DropTable(
				name: "GMAO_Archivos_Modelos");

			migrationBuilder.DropTable(
				name: "GMAO_Archivos_Tipos");

			migrationBuilder.DropTable(
				name: "GMAO_CaracteristicasElementos");

			migrationBuilder.DropTable(
				name: "GMAO_CaracteristicasTipos");

			migrationBuilder.DropTable(
				name: "GMAO_Deps_Operarios");

			migrationBuilder.DropTable(
				name: "GMAO_ElemAlternativos");

			migrationBuilder.DropTable(
				name: "GMAO_ElementosTiposModelos");

			migrationBuilder.DropTable(
				name: "GMAO_ElementReviewSettings");

			migrationBuilder.DropTable(
				name: "GMAO_ElemIntervencionesPiezas");

			migrationBuilder.DropTable(
				name: "GMAO_ElemIntervencionesTrabajos");

			migrationBuilder.DropTable(
				name: "GMAO_ElemPertenencia");

			migrationBuilder.DropTable(
				name: "GMAO_HistStocksYElementos");

			migrationBuilder.DropTable(
				name: "GMAO_ParadasConfiguracionModulos");

			migrationBuilder.DropTable(
				name: "GMAO_ParadasConfiguracionTareas");

			migrationBuilder.DropTable(
				name: "GMAO_SolicitudOrdenTrabajo");

			migrationBuilder.DropTable(
				name: "GMAO_WarehouseStocks");

			migrationBuilder.DropTable(
				name: "GruposIncompatibilidadesLineas");

			migrationBuilder.DropTable(
				name: "HumanMachineInterfaces");

			migrationBuilder.DropTable(
				name: "Incompatibilidades");

			migrationBuilder.DropTable(
				name: "Indicadores");

			migrationBuilder.DropTable(
				name: "InformesLibUsuarios");

			migrationBuilder.DropTable(
				name: "Lectores");

			migrationBuilder.DropTable(
				name: "LineasCompra");

			migrationBuilder.DropTable(
				name: "LineaVentaLineaSalida");

			migrationBuilder.DropTable(
				name: "LogMovimientosStocks");

			migrationBuilder.DropTable(
				name: "LotesMezclados");

			migrationBuilder.DropTable(
				name: "Maquinas");

			migrationBuilder.DropTable(
				name: "MedicacionesIngredientes");

			migrationBuilder.DropTable(
				name: "ModulosAscendentes");

			migrationBuilder.DropTable(
				name: "ModulosEstadoComunicaciones");

			migrationBuilder.DropTable(
				name: "ModulosIncompatibilidades");

			migrationBuilder.DropTable(
				name: "ModulosMotores");

			migrationBuilder.DropTable(
				name: "ModulosTagsScada");

			migrationBuilder.DropTable(
				name: "MotoresGruposRelacion");

			migrationBuilder.DropTable(
				name: "MotoresHistorico");

			migrationBuilder.DropTable(
				name: "MultiDosificaciones");

			migrationBuilder.DropTable(
				name: "NetAlarmas");

			migrationBuilder.DropTable(
				name: "NetAlarmasAutomaticasOrdenUbicaciones");

			migrationBuilder.DropTable(
				name: "NetAlarmasTiposRespuestasOrigenes");

			migrationBuilder.DropTable(
				name: "OpcionesRoles");

			migrationBuilder.DropTable(
				name: "OpcionesUsuarios");

			migrationBuilder.DropTable(
				name: "OperMotoresModulos");

			migrationBuilder.DropTable(
				name: "OperPlantillas");

			migrationBuilder.DropTable(
				name: "OrdenesAutoInicio");

			migrationBuilder.DropTable(
				name: "OrdenesDatosExtra");

			migrationBuilder.DropTable(
				name: "OrdenesRelacion");

			migrationBuilder.DropTable(
				name: "OrdenesTransicionEstadosHistory");

			migrationBuilder.DropTable(
				name: "Pistolas");

			migrationBuilder.DropTable(
				name: "Pivots");

			migrationBuilder.DropTable(
				name: "PrintJobs");

			migrationBuilder.DropTable(
				name: "ProductoMedidorCamino");

			migrationBuilder.DropTable(
				name: "ProductosEnvasesEtiquetas");

			migrationBuilder.DropTable(
				name: "ProductosGruposIncompatibilidades");

			migrationBuilder.DropTable(
				name: "ProductosOperCabPlantillas");

			migrationBuilder.DropTable(
				name: "Puntos");

			migrationBuilder.DropTable(
				name: "RecetasLineas");

			migrationBuilder.DropTable(
				name: "Regularizaciones");

			migrationBuilder.DropTable(
				name: "Resultados");

			migrationBuilder.DropTable(
				name: "SalidasLiniasLote");

			migrationBuilder.DropTable(
				name: "SalidasLiniasMuestras");

			migrationBuilder.DropTable(
				name: "SalidasLiniasPuntosDescarga");

			migrationBuilder.DropTable(
				name: "ServerConfigs");

			migrationBuilder.DropTable(
				name: "SesionesModulo");

			migrationBuilder.DropTable(
				name: "SesionesSeccion");

			migrationBuilder.DropTable(
				name: "SolicitudesAjusteCaudal");

			migrationBuilder.DropTable(
				name: "StatusDisks");

			migrationBuilder.DropTable(
				name: "StocksReserva");

			migrationBuilder.DropTable(
				name: "TagsBasculas");

			migrationBuilder.DropTable(
				name: "Tarifas");

			migrationBuilder.DropTable(
				name: "TempControlesMedidores");

			migrationBuilder.DropTable(
				name: "TextosParametros");

			migrationBuilder.DropTable(
				name: "TiempoLimpieza");

			migrationBuilder.DropTable(
				name: "UbicacionesAsociadas");

			migrationBuilder.DropTable(
				name: "UbicacionesOpcConfig");

			migrationBuilder.DropTable(
				name: "UbisMedsAfino");

			migrationBuilder.DropTable(
				name: "UsuariosGruposLDAP");

			migrationBuilder.DropTable(
				name: "UsuariosLogs");

			migrationBuilder.DropTable(
				name: "UsuariosRolesConfigForm");

			migrationBuilder.DropTable(
				name: "UsuariosRolesInformes");

			migrationBuilder.DropTable(
				name: "UsuariosRolesModulos");

			migrationBuilder.DropTable(
				name: "Valores");

			migrationBuilder.DropTable(
				name: "VentasLiniasMedicaciones");

			migrationBuilder.DropTable(
				name: "VentasLiniasPuntosDescarga");

			migrationBuilder.DropTable(
				name: "VersionTPrevisto");

			migrationBuilder.DropTable(
				name: "AlertasUsuariosInformes");

			migrationBuilder.DropTable(
				name: "AuditTables");

			migrationBuilder.DropTable(
				name: "BufferERPClientesDomicilios");

			migrationBuilder.DropTable(
				name: "BufferERPVersiones");

			migrationBuilder.DropTable(
				name: "BufferERPCompras");

			migrationBuilder.DropTable(
				name: "BufferERPEntradasLineas");

			migrationBuilder.DropTable(
				name: "BufferERPCabOrdenes");

			migrationBuilder.DropTable(
				name: "BufferERPSalidasLinMedicamentos");

			migrationBuilder.DropTable(
				name: "BufferERPVentas");

			migrationBuilder.DropTable(
				name: "DashboardsLibCategorias");

			migrationBuilder.DropTable(
				name: "Destinos");

			migrationBuilder.DropTable(
				name: "EnlaceERP");

			migrationBuilder.DropTable(
				name: "EnlaceERPTipoLinea");

			migrationBuilder.DropTable(
				name: "Eventos");

			migrationBuilder.DropTable(
				name: "Inventarios");

			migrationBuilder.DropTable(
				name: "Files");

			migrationBuilder.DropTable(
				name: "Formularios");

			migrationBuilder.DropTable(
				name: "GMAO_Archivos");

			migrationBuilder.DropTable(
				name: "GMAO_Caracteristicas");

			migrationBuilder.DropTable(
				name: "GMAO_ElemIntervenciones");

			migrationBuilder.DropTable(
				name: "GMAO_ElementReviewTasks");

			migrationBuilder.DropTable(
				name: "GMAO_ElemStocks");

			migrationBuilder.DropTable(
				name: "GMAO_Warehouses");

			migrationBuilder.DropTable(
				name: "InformesLib");

			migrationBuilder.DropTable(
				name: "Compras");

			migrationBuilder.DropTable(
				name: "MotoresGrupos");

			migrationBuilder.DropTable(
				name: "SeccionesGrupos");

			migrationBuilder.DropTable(
				name: "Dosificaciones");

			migrationBuilder.DropTable(
				name: "NetAlarmasAutomaticas");

			migrationBuilder.DropTable(
				name: "Opciones");

			migrationBuilder.DropTable(
				name: "Caminos");

			migrationBuilder.DropTable(
				name: "GruposIncompatibilidades");

			migrationBuilder.DropTable(
				name: "Recetas");

			migrationBuilder.DropTable(
				name: "ControlesNIR");

			migrationBuilder.DropTable(
				name: "Secciones");

			migrationBuilder.DropTable(
				name: "Caudales");

			migrationBuilder.DropTable(
				name: "SalidasLiniasMedicaciones");

			migrationBuilder.DropTable(
				name: "Stocks");

			migrationBuilder.DropTable(
				name: "Variables");

			migrationBuilder.DropTable(
				name: "AlertasUsuarios");

			migrationBuilder.DropTable(
				name: "Audits");

			migrationBuilder.DropTable(
				name: "BufferERPClientes");

			migrationBuilder.DropTable(
				name: "BufferERPFormulas");

			migrationBuilder.DropTable(
				name: "BufferERPEntradas");

			migrationBuilder.DropTable(
				name: "BufferERPSalidasLinias");

			migrationBuilder.DropTable(
				name: "EnlaceERPTipo");

			migrationBuilder.DropTable(
				name: "GMAO_Departamentos");

			migrationBuilder.DropTable(
				name: "GMAO_ParadasConfiguracion");

			migrationBuilder.DropTable(
				name: "GMAO_ComprasLineas");

			migrationBuilder.DropTable(
				name: "Printers");

			migrationBuilder.DropTable(
				name: "InformesLibCategorias");

			migrationBuilder.DropTable(
				name: "OperMotores");

			migrationBuilder.DropTable(
				name: "TempControles");

			migrationBuilder.DropTable(
				name: "MedidoresDosificaciones");

			migrationBuilder.DropTable(
				name: "NetAlarmasTiposRespuestas");

			migrationBuilder.DropTable(
				name: "Veterinarios");

			migrationBuilder.DropTable(
				name: "AlertasSmtpConfigs");

			migrationBuilder.DropTable(
				name: "BufferERPSalidas");

			migrationBuilder.DropTable(
				name: "BufferERPSalidasViajes");

			migrationBuilder.DropTable(
				name: "GMAO_Operarios");

			migrationBuilder.DropTable(
				name: "GMAO_Compras");

			migrationBuilder.DropTable(
				name: "GMAO_Elementos");

			migrationBuilder.DropTable(
				name: "OperAcciones");

			migrationBuilder.DropTable(
				name: "Origenes");

			migrationBuilder.DropTable(
				name: "NetAlarmasRespuestas");

			migrationBuilder.DropTable(
				name: "NetAlarmasTipos");

			migrationBuilder.DropTable(
				name: "Empresas");

			migrationBuilder.DropTable(
				name: "Electrovalvulas");

			migrationBuilder.DropTable(
				name: "GMAO_MarcasModelos");

			migrationBuilder.DropTable(
				name: "GMAO_ElementosTipos");

			migrationBuilder.DropTable(
				name: "Motores");

			migrationBuilder.DropTable(
				name: "Usuarios");

			migrationBuilder.DropTable(
				name: "GMAO_Marcas");

			migrationBuilder.DropTable(
				name: "GMAO_Proveedores");

			migrationBuilder.DropTable(
				name: "Formatos");

			migrationBuilder.DropTable(
				name: "Ordenes");

			migrationBuilder.DropTable(
				name: "CabOrdenes");

			migrationBuilder.DropTable(
				name: "VentasLinias");

			migrationBuilder.DropTable(
				name: "Versiones");

			migrationBuilder.DropTable(
				name: "Contratos");

			migrationBuilder.DropTable(
				name: "Ventas");

			migrationBuilder.DropTable(
				name: "Formulas");

			migrationBuilder.DropTable(
				name: "Productos");

			migrationBuilder.DropTable(
				name: "Etiquetas");

			migrationBuilder.DropTable(
				name: "Familias");

			migrationBuilder.DropTable(
				name: "Medidores");

			migrationBuilder.DropTable(
				name: "TiposIva");

			migrationBuilder.DropTable(
				name: "Analisis");

			migrationBuilder.DropTable(
				name: "FamiliasMedidor");

			migrationBuilder.DropTable(
				name: "Ubicaciones");

			migrationBuilder.DropTable(
				name: "Sesiones");

			migrationBuilder.DropTable(
				name: "Unidades");

			migrationBuilder.DropTable(
				name: "Modulos");

			migrationBuilder.DropTable(
				name: "UsuariosRoles");

			migrationBuilder.DropTable(
				name: "OperCabPlantillas");

			migrationBuilder.DropTable(
				name: "OpcConfig");

			migrationBuilder.DropTable(
				name: "Gateways");

			migrationBuilder.DropTable(
				name: "Tenants");

			migrationBuilder.DropTable(
				name: "Tags");

			migrationBuilder.DropTable(
				name: "TagsLecturas");

			migrationBuilder.DropTable(
				name: "Lotes");

			migrationBuilder.DropTable(
				name: "Entradas");

			migrationBuilder.DropTable(
				name: "SalidasViajes");

			migrationBuilder.DropTable(
				name: "Vehiculos");

			migrationBuilder.DropTable(
				name: "Choferes");

			migrationBuilder.DropTable(
				name: "EmpresasTransporte");

			migrationBuilder.DropTable(
				name: "Tarjetas");

			migrationBuilder.DropTable(
				name: "EntradasLineas");

			migrationBuilder.DropTable(
				name: "SalidasLinias");

			migrationBuilder.DropTable(
				name: "ProveedoresOrigenes");

			migrationBuilder.DropTable(
				name: "Medicaciones");

			migrationBuilder.DropTable(
				name: "SalidasAlbaranes");

			migrationBuilder.DropTable(
				name: "Basculas");

			migrationBuilder.DropTable(
				name: "Envases");

			migrationBuilder.DropTable(
				name: "PuntosDescarga");

			migrationBuilder.DropTable(
				name: "Salidas");

			migrationBuilder.DropTable(
				name: "Proveedores");

			migrationBuilder.DropTable(
				name: "Afecciones");

			migrationBuilder.DropTable(
				name: "Domicilios");

			migrationBuilder.DropTable(
				name: "Departamentos");

			migrationBuilder.DropTable(
				name: "Series");

			migrationBuilder.DropTable(
				name: "Clientes");

			migrationBuilder.DropTable(
				name: "Especies");

			migrationBuilder.DropTable(
				name: "Provincias");

			migrationBuilder.DropTable(
				name: "Paises");
		}
	}
}
