using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class InitialMigration : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
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
				name: "AnalizadoresRed",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Descripcion = table.Column<string>(maxLength: 250, nullable: true),
					ModoMaximetro = table.Column<bool>(nullable: true),
					TensionSimple0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					TensionSimple1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					TensionSimple2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Corriente0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Corriente1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Corriente2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaActiva0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaActiva1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaActiva2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaReactiva0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaReactiva1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaReactiva2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaAparente0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaAparente1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaAparente2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					FactorPotencia0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					FactorPotencia1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					FactorPotencia2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					THD_V0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					THD_V1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					THD_V2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					THD_A0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					THD_A1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					THD_A2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaActiva_Trifasica = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaInductiva_Trifasica = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaCapacitativa_Trifasica = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					CosFi_Trifasico = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					FactorPotencia_Trifasico = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Frecuencia = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					VCompuestaL1_L2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					VCompuestaL2_L3 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					VCompuestaL3_L1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaAparente_Trifasica = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Max_Demanda = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Corriente_Neutro = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Max_Demanda_L1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Max_Demanda_L2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Max_Demanda_L3 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Energia_Activa = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Energia_Reactiva_Inductiva = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Energia_Reactiva_Capacitiva = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Energia_Aparente = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Energia_Activa_Generada = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Energia_Capacitiva_Generada = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Energia_Aparente_Generada = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					SobreConsumo = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					RegistrarDatos = table.Column<bool>(nullable: true),
					PosicionPLC = table.Column<int>(nullable: true),
					Corriente_trifasica = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Temperatura = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Energia_Inductiva_Generada = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					IdOpc = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AnalizadoresRed", x => x.id);
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
					Observaciones = table.Column<string>(type: "ntext", nullable: true),
					Comentario = table.Column<string>(type: "ntext", nullable: true),
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
					Observaciones = table.Column<string>(type: "ntext", nullable: true),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Comentario = table.Column<string>(type: "ntext", nullable: true),
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
					Comentario = table.Column<string>(type: "ntext", nullable: true),
					Observaciones = table.Column<string>(type: "ntext", nullable: true),
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
					FechaInsercion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BufferERPVentasLineas", x => x.id);
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
					Logotipo = table.Column<byte[]>(type: "image", nullable: true),
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
					Contenido = table.Column<string>(type: "ntext", nullable: true),
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
					Formulario = table.Column<string>(maxLength: 50, nullable: true),
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
					Descripcion = table.Column<string>(type: "ntext", nullable: true),
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
				name: "OEEEstadosTipo",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Descripcion = table.Column<string>(maxLength: 250, nullable: true),
					EstadoEnHorario = table.Column<bool>(nullable: true),
					EstadoMantenimiento = table.Column<bool>(nullable: true),
					EstadoAveria = table.Column<bool>(nullable: true),
					EstadoProduciendo = table.Column<bool>(nullable: true),
					EstadoAveriaGrave = table.Column<bool>(nullable: true),
					Tipo = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OEEEstadosTipo", x => x.id);
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
				name: "PLCAddons",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: false),
					Descripción = table.Column<string>(maxLength: 100, nullable: false),
					Tipo = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PLCAddons", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "PLCRead",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: false),
					posicion = table.Column<int>(nullable: false),
					Valor = table.Column<string>(maxLength: 100, nullable: true),
					UltimaLectura = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PLCRead", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "PLCWrite",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: false),
					Valor = table.Column<string>(maxLength: 100, nullable: false),
					FechaEnviado = table.Column<DateTime>(type: "datetime", nullable: false),
					FechaWrite = table.Column<DateTime>(type: "datetime", nullable: true),
					Estado = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PLCWrite", x => x.id);
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
					ContadorOrdenes = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					ContadorCompras = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					ContadorVentas = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
					ContadorViajes = table.Column<int>(nullable: false),
					ContadorRecetas = table.Column<int>(nullable: true),
					ContadorAlbaranes = table.Column<int>(nullable: true),
					ContadorCertificadoDesinfeccion = table.Column<int>(nullable: true),
					ContadorSalidas = table.Column<int>(nullable: true),
					ContadorEntradas = table.Column<int>(nullable: true)
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
				name: "Turnos",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					HoraInicio = table.Column<TimeSpan>(nullable: true),
					HoraFinal = table.Column<TimeSpan>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Turnos", x => x.id);
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
					TrazabilidadResumenVer = table.Column<bool>(nullable: true, defaultValueSql: "((1))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UsuariosRoles", x => x.Id);
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
					smtpMensaje = table.Column<string>(type: "ntext", nullable: true),
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
				name: "Veterinarios",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Apellidos = table.Column<string>(maxLength: 50, nullable: true),
					NColegiado = table.Column<string>(maxLength: 50, nullable: true),
					IdEmpresa = table.Column<int>(nullable: true)
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
					Descripcion = table.Column<string>(type: "ntext", nullable: true),
					Observaciones = table.Column<string>(type: "ntext", nullable: true),
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
					CopiaPara = table.Column<string>(maxLength: 250, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_InformesLib", x => x.Id);
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
				name: "OEEEstadosTipoLista",
				columns: table => new
				{
					IdEstadoTipo = table.Column<int>(nullable: false),
					IdEstadoEnum = table.Column<int>(nullable: false)
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
				name: "PLCAddonsVars",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idAddon = table.Column<int>(nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: false),
					Descripcion = table.Column<string>(maxLength: 100, nullable: true),
					subscribir = table.Column<bool>(nullable: false),
					Tipo = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PLCAddonsVars", x => x.id);
					table.ForeignKey(
						name: "FK_PLCAddonsVars_PLCAddons",
						column: x => x.idAddon,
						principalTable: "PLCAddons",
						principalColumn: "id",
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
				name: "CompActivosLista",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Descripcion = table.Column<string>(maxLength: 250, nullable: true),
					Medicamento = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CompActivosLista", x => x.id);
					table.ForeignKey(
						name: "FK_CompActivosLista_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
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
					Mensaje = table.Column<string>(type: "ntext", nullable: true),
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
					Importado = table.Column<bool>(nullable: true),
					Refrescado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
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
					Importado = table.Column<bool>(nullable: true),
					Pais = table.Column<int>(nullable: true),
					Inhabilitado = table.Column<bool>(nullable: true),
					Refrescado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
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
				name: "OpcConfig",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Tipo = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
					Activado = table.Column<bool>(nullable: false),
					SincUbicaciones = table.Column<bool>(nullable: false),
					SincUsuarios = table.Column<bool>(nullable: false),
					Version = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
					Topic = table.Column<string>(maxLength: 250, nullable: true),
					OPCIP = table.Column<string>(maxLength: 50, nullable: true),
					OPCRate = table.Column<int>(nullable: true),
					OPCNombre = table.Column<string>(maxLength: 250, nullable: true),
					IsGeneral = table.Column<bool>(nullable: false),
					BitVida = table.Column<DateTime>(type: "datetime", nullable: true),
					Calidad = table.Column<int>(nullable: true),
					Endpoint = table.Column<string>(maxLength: 256, nullable: true),
					DeviceAlias = table.Column<string>(maxLength: 256, nullable: true),
					IsPrincipal = table.Column<bool>(nullable: false),
					Maestro = table.Column<bool>(nullable: false),
					GatewayId = table.Column<Guid>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OpcConfig", x => x.Id);
					table.ForeignKey(
						name: "FK_OpcConfig_Gateways_GatewayId",
						column: x => x.GatewayId,
						principalTable: "Gateways",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "AlertasUsuariosInformesParametros",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Descripción = table.Column<string>(type: "ntext", nullable: true),
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
					Variable1 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					Variable2 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
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
					Variable1 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
					Variable2 = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
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
					IdPlc = table.Column<int>(nullable: false)
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
					TAG = table.Column<string>(maxLength: 50, nullable: true),
					IOCfgParInIntensidadNominal = table.Column<float>(nullable: true),
					IOCfgParInCosFi = table.Column<float>(nullable: true),
					IOCfgParInTension = table.Column<int>(nullable: true),
					IOCfgParInMonofasico = table.Column<bool>(nullable: true),
					IOCfgParInControlActivoVF = table.Column<bool>(nullable: true),
					IOCfgParInConsignaAvisoIAlta = table.Column<float>(nullable: true),
					IOCfgParInConsignaAlarmaI = table.Column<float>(nullable: true),
					IOCfgParInIntensidadEnVacio = table.Column<float>(nullable: true),
					IOCfgParInHysteresisMotorEnVacio = table.Column<float>(nullable: true),
					IOCfgParInPorcentajeSobrecarga = table.Column<int>(nullable: true),
					IOCfgParInPorcentajeCargaMaxima = table.Column<int>(nullable: true),
					IOCfgParInHysteresisCarga = table.Column<float>(nullable: true),
					IOCfgParInConsignaAvisoTempRod1 = table.Column<float>(nullable: true),
					IOCfgParInConsignaAvisoTempRod2 = table.Column<float>(nullable: true),
					IOCfgParInConsignaAlarmaTempRod1 = table.Column<float>(nullable: true),
					IOCfgParInConsignaAlarmaTempRod2 = table.Column<float>(nullable: true),
					IOCfgParInVelocidadErrorMax = table.Column<float>(nullable: true),
					IOCfgParInVelocidadEscalado = table.Column<float>(nullable: true),
					IOCfgParInSeccion0 = table.Column<int>(nullable: true),
					IOCfgParInSeccion1 = table.Column<int>(nullable: true),
					IOCfgParInSeccion2 = table.Column<int>(nullable: true),
					IOCfgParInSeccion3 = table.Column<int>(nullable: true),
					IOCfgParInSeccion4 = table.Column<int>(nullable: true),
					IOCfgParInSeccion5 = table.Column<int>(nullable: true),
					IOCfgParInSeccion6 = table.Column<int>(nullable: true),
					IOCfgParInSeccion7 = table.Column<int>(nullable: true),
					IOCfgParInSeccion8 = table.Column<int>(nullable: true),
					IOCfgParInSeccion9 = table.Column<int>(nullable: true),
					IOCfgParInParametroAux2 = table.Column<float>(nullable: true),
					IOCfgParInParametroAux3 = table.Column<float>(nullable: true),
					IOCfgSeguridadesInDesactivarCM = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInDesactivarOtrasSeguridades = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInDesactivarAtasco = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInDesactivarPTC = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInDesactivarFalloVF = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInDesactivarFalloAE = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInDesactivarFalloAux = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInDesactivarAlDB1 = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInDesactivarAlDB2 = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInDesactivarAlDB3 = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInDesactivarAlDB4 = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInDesactivarDG = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInTipoDG = table.Column<int>(nullable: true),
					IOCfgSeguridadesInTempRod1Habilitada = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInTempRod2Habilitada = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInActivarEncadenadoAuto = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInActivarEncadenadoMan = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInActivarAlVelocidadFBack = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInActivarPreavisoArranque = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInPermisoRearranqManTrasFallo = table.Column<bool>(nullable: true),
					IOCfgSeguridadesInAccionFalloSuministro = table.Column<bool>(nullable: true),
					IOCfgTiemposInTimEsperaCM = table.Column<int>(nullable: true),
					IOCfgTiemposInTimDelayOtrasSeguridades = table.Column<int>(nullable: true),
					IOCfgTiemposInTimDelayAtasco = table.Column<int>(nullable: true),
					IOCfgTiemposInTimDelayTermistorPTC = table.Column<int>(nullable: true),
					IOCfgTiemposInTimDelayFalloVF = table.Column<int>(nullable: true),
					IOCfgTiemposInTimDelayFalloAE = table.Column<int>(nullable: true),
					IOCfgTiemposInTimDelayFalloAux = table.Column<int>(nullable: true),
					IOCfgTiemposInTimDelayAlDB1 = table.Column<int>(nullable: true),
					IOCfgTiemposInTimDelayAlDB2 = table.Column<int>(nullable: true),
					IOCfgTiemposInTimDelayAlDB3 = table.Column<int>(nullable: true),
					IOCfgTiemposInTimDelayAlDB4 = table.Column<int>(nullable: true),
					IOCfgTiemposInTimMaximoOnDG = table.Column<int>(nullable: true),
					IOCfgTiemposInTimMaximoOffDG = table.Column<int>(nullable: true),
					IOCfgTiemposInTimDelayActivarCargaMax = table.Column<int>(nullable: true),
					IOCfgTiemposInTimDelayDesactivarCargaMax = table.Column<int>(nullable: true),
					IOCfgTiemposInTimDelayIntensidadElevada = table.Column<int>(nullable: true),
					IOCfgTiemposInTimDelayIntensidadMaxima = table.Column<int>(nullable: true),
					IOCfgTiemposInTimInhibirCargaArranque = table.Column<int>(nullable: true),
					IOCfgTiemposInTimRetardoStopAuto = table.Column<int>(nullable: true),
					IOCfgTiemposInTimOMSiguienteMotor = table.Column<int>(nullable: true),
					IOCfgTiemposInTimPreavisoArranque = table.Column<int>(nullable: true),
					IOMantenOutHorasMarchaTotal = table.Column<float>(nullable: true),
					IOMantenOutHorasMarchaParcial = table.Column<float>(nullable: true),
					IOMantenOutHorasMarchaEnCarga = table.Column<float>(nullable: true),
					IOMantenOutEnergiaEfectiva = table.Column<float>(nullable: true),
					IOMantenOutEnergiaTotal = table.Column<float>(nullable: true),
					IOMantenOutNumeroManiobras = table.Column<int>(nullable: true),
					IOMantenOutContadorTotAlarmas = table.Column<int>(nullable: true),
					IOMantenOutContAlFalloCM = table.Column<int>(nullable: true),
					IOMantenOutContAlTermico = table.Column<int>(nullable: true),
					IOMantenOutContAlDiferencial = table.Column<int>(nullable: true),
					IOMantenOutContAlParoEmerg = table.Column<int>(nullable: true),
					IOMantenOutContAlOtrasSeguridades = table.Column<int>(nullable: true),
					IOMantenOutContAlTermistorPTC = table.Column<int>(nullable: true),
					IOMantenOutContAlVF = table.Column<int>(nullable: true),
					IOMantenOutContAlAE = table.Column<int>(nullable: true),
					IOMantenOutContAlAux = table.Column<int>(nullable: true),
					IOMantenOutContAlDB1 = table.Column<int>(nullable: true),
					IOMantenOutContAlDB2 = table.Column<int>(nullable: true),
					IOMantenOutContAlDB3 = table.Column<int>(nullable: true),
					IOMantenOutContAlDB4 = table.Column<int>(nullable: true),
					IOMantenOutContAlDG = table.Column<int>(nullable: true),
					IOMantenOutContAlAtasco = table.Column<int>(nullable: true),
					IOMantenOutContAlIMax = table.Column<int>(nullable: true),
					IOMantenOutContAlIElevada = table.Column<int>(nullable: true),
					IOMantenOutContAlTempMaxRod1 = table.Column<int>(nullable: true),
					IOMantenOutContAlTempElevRod1 = table.Column<int>(nullable: true),
					IOMantenOutContAlTempMaxRod2 = table.Column<int>(nullable: true),
					IOMantenOutContAlTempElevRod2 = table.Column<int>(nullable: true),
					IOMantenOutContAlVelocidad = table.Column<int>(nullable: true),
					IOMantenOutContAlComunica = table.Column<int>(nullable: true),
					IOMantenOutContAlDeshabil = table.Column<int>(nullable: true),
					IOMantenInResetHorasTotal = table.Column<bool>(nullable: true),
					IOMantenInResetHorasParcial = table.Column<bool>(nullable: true),
					IOMantenInResetHorasEnCarga = table.Column<bool>(nullable: true),
					IOMantenInResetEnergias = table.Column<bool>(nullable: true),
					IOMantenInResetContadorManiobras = table.Column<bool>(nullable: true),
					IOMantenInResetContadorAlarmas = table.Column<bool>(nullable: true),
					LeerEnPLC = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					GrabarEnPLC = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					idPLC = table.Column<int>(nullable: true),
					MedirKW = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
					NombreMes = table.Column<string>(maxLength: 50, nullable: true),
					AlertaConsumoAlto = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					AlertaConsumoExcesivo = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					IsMaximetro = table.Column<bool>(nullable: true),
					MaximetroGeneral = table.Column<bool>(nullable: true),
					InicioVentana = table.Column<DateTime>(type: "datetime", nullable: true),
					ValorVentanaMaximetro = table.Column<decimal>(type: "decimal(12, 3)", nullable: true),
					MinsMaxVentana = table.Column<int>(nullable: true),
					IOMantenOutContAlLockOut = table.Column<int>(nullable: true),
					IOMantenOutContAlPuertaAbierta = table.Column<int>(nullable: true),
					IOMantenOutContAlInversor = table.Column<int>(nullable: true),
					IOMantenInResetContadores = table.Column<bool>(nullable: true),
					IOMantenInResetContadorEnergiaParciales = table.Column<bool>(nullable: true),
					IOMantenInResetContadorEnergiaTotales = table.Column<bool>(nullable: true),
					IOMantenInResetMaxPotenciasIntensidad = table.Column<bool>(nullable: true),
					IOMantenOutPotenciaActiva = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutPotenciaReactiva = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutPotenciaAparente = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutPotenciaActivaEfectiva = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutPotenciaReactivaEfectiva = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutPotenciaAparenteEfectiva = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutEnergiaEnCargaTotales = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutEnergiaEnVacioTotales = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutEnergiaEnCargaParciales = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutEnergiaEnVacioParciales = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutMemoriaMaxPotenciaActiva = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutMemoriaMaxPotenciaAparente = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutMemoriaMaxPotenciaReactiva = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IOMantenOutMemoriaMaxIntensidad = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					EnergiaEnCargaAnterior = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					EnergiaEnVacioAnterior = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					EnergiaTotalAnterior = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					EnergiaEfectivaAnterior = table.Column<decimal>(type: "decimal(18, 7)", nullable: true),
					IdOpc = table.Column<int>(nullable: true),
					OpcConfigId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Motores", x => x.Id);
					table.ForeignKey(
						name: "FK__Motores__OpcConf__5634BA94",
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
					Comentario = table.Column<string>(type: "ntext", nullable: true),
					Observaciones = table.Column<string>(type: "ntext", nullable: true),
					FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
					FechaFin = table.Column<DateTime>(type: "datetime", nullable: true),
					RefERP = table.Column<string>(maxLength: 50, nullable: true),
					isImport = table.Column<bool>(nullable: true),
					Impresiones = table.Column<int>(nullable: false)
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
					Habilitado = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_InformesLibUsuarios", x => x.Id);
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
					Observaciones = table.Column<string>(type: "ntext", nullable: true),
					Descripcion = table.Column<string>(type: "ntext", nullable: true),
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
					Observaciones = table.Column<string>(type: "ntext", nullable: true),
					Descripcion = table.Column<string>(type: "ntext", nullable: true)
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
				name: "Medicaciones",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					Nombre = table.Column<string>(maxLength: 50, nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Frecuencia = table.Column<int>(nullable: true),
					Duracion = table.Column<int>(nullable: true),
					TiempoEspera = table.Column<int>(nullable: true),
					Conservacion = table.Column<int>(nullable: true),
					Total = table.Column<int>(nullable: true),
					Cliente = table.Column<int>(nullable: true),
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
					idProducto = table.Column<int>(nullable: true),
					StockIngredientes = table.Column<bool>(nullable: true)
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
					Importado = table.Column<bool>(nullable: true),
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
					Exportado = table.Column<bool>(nullable: true),
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
					PlantillaCabMolturacion = table.Column<int>(nullable: true)
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
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Producto = table.Column<int>(nullable: false),
					Cantidad = table.Column<float>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					IdCompActivosLista = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ComponentesActivos", x => x.Id);
					table.ForeignKey(
						name: "FK_ComponentesActivos_CompActivosLista",
						column: x => x.IdCompActivosLista,
						principalTable: "CompActivosLista",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_ComponentesActivos_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
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
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					PrecioCoste = table.Column<float>(nullable: true),
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
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Medicacion = table.Column<int>(nullable: true),
					Producto = table.Column<int>(nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Porcentaje = table.Column<float>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					AplicacionDirecta = table.Column<bool>(nullable: true),
					Produccion = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_MedicacionesIngredientes", x => x.Id);
					table.ForeignKey(
						name: "FK_MedicacionesIngredientes_Medicaciones",
						column: x => x.Medicacion,
						principalTable: "Medicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_MedicacionesIngredientes_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_MedicacionesIngredientes_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
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
					Importado = table.Column<bool>(nullable: true),
					Departamento = table.Column<int>(nullable: true),
					Entrega = table.Column<DateTime>(type: "datetime", nullable: true),
					Comentario = table.Column<string>(maxLength: 100, nullable: true),
					Impresa = table.Column<bool>(nullable: true),
					Refrescado = table.Column<bool>(nullable: true),
					Fin = table.Column<DateTime>(type: "datetime", nullable: true),
					Exportado = table.Column<bool>(nullable: true),
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
					FechaFin = table.Column<DateTime>(type: "datetime", nullable: true)
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

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [StockEnUbicacion] 
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

				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [LoteEnUbicacion] 
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

				GO
			");

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
				name: "Caudales",
				columns: table => new
				{
					ProductoId = table.Column<int>(nullable: false),
					UbicacionId = table.Column<int>(nullable: false),
					Mode = table.Column<byte>(nullable: false),
					CaudalEntrada = table.Column<decimal>(type: "decimal(18, 5)", nullable: false),
					CaudalSalida = table.Column<decimal>(type: "decimal(18, 5)", nullable: false)
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
					IdPlc = table.Column<int>(nullable: false)
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
					AutoGenerada = table.Column<bool>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Recetas", x => x.id);
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
					idReceta = table.Column<int>(nullable: true),
					idMedicamento = table.Column<int>(nullable: true),
					Cantidad = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
					Porcentaje = table.Column<decimal>(type: "decimal(8, 5)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_RecetasLineas", x => x.id);
					table.ForeignKey(
						name: "FK_RecetasLineas_Medicaciones",
						column: x => x.idMedicamento,
						principalTable: "Medicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_RecetasLineas_Recetas",
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
					exportado = table.Column<bool>(nullable: true),
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
					TaraAplicada = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
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
					Modulo = table.Column<int>(nullable: true),
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
					IdPLC = table.Column<int>(nullable: true),
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
					ModoMultidosificacion = table.Column<bool>(nullable: true),
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
						name: "FK_Medidores_OEEEstadosTipo",
						column: x => x.EstadoForzado,
						principalTable: "OEEEstadosTipo",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
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
				name: "OEEEstadosMedidores",
				columns: table => new
				{
					idEstadoTipo = table.Column<int>(nullable: false),
					idMedidor = table.Column<int>(nullable: false)
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
					Capacidad = table.Column<decimal>(type: "decimal(18, 2)", nullable: true)
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
				name: "SalidasLinias",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idSalidas = table.Column<int>(nullable: true),
					idProducto = table.Column<int>(nullable: true),
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
					Exportado = table.Column<bool>(nullable: true),
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
					idSalidaLinia = table.Column<int>(nullable: true),
					idMedicamento = table.Column<int>(nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Bultos = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					IdUnidad = table.Column<int>(nullable: true),
					idFormato = table.Column<int>(nullable: true),
					idEnvase = table.Column<int>(nullable: true),
					PrecioUnidad = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					Estado = table.Column<int>(nullable: true),
					Precio = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					idOrigen = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SalidasLiniasMedicaciones", x => x.id);
					table.ForeignKey(
						name: "FK_SalidasLiniasMedicaciones_Unidades",
						column: x => x.IdUnidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
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
						name: "FK_SalidasLiniasMedicaciones_Medicaciones",
						column: x => x.idMedicamento,
						principalTable: "Medicaciones",
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

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [EnvasesDeStock] 
				(
					-- Add the parameters for the function here
					@idEnvase int,
					@Cantidad real
				)
				RETURNS decimal(18,5)
				AS
				BEGIN
					DECLARE @ResultVar decimal(18,5);
					declare @EnvaseCapacidad real;

					SELECT @EnvaseCapacidad =  isnull(Capacidad,0)  FROM Envases WHERE Id=@idEnvase and ModoUdsFormato=1;

					if @EnvaseCapacidad = null or @EnvaseCapacidad=0 or @Cantidad =0
					begin
						RETURN 0
					end
						return @Cantidad/@EnvaseCapacidad
		

				END


				GO
			");

			migrationBuilder.CreateTable(
				name: "Stocks",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Ubicacion = table.Column<int>(nullable: true),
					Producto = table.Column<int>(nullable: true),
					Formato = table.Column<int>(nullable: true),
					Lote = table.Column<int>(nullable: true),
					Envase = table.Column<int>(nullable: true),
					Cantidad = table.Column<float>(nullable: true),
					Unidad = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Estado = table.Column<int>(nullable: true),
					Importado = table.Column<bool>(nullable: true),
					Exportado = table.Column<bool>(nullable: true),
					Palet = table.Column<int>(nullable: true),
					Procesando = table.Column<bool>(nullable: true),
					Observaciones = table.Column<string>(maxLength: 4000, nullable: true),
					idOld = table.Column<int>(nullable: true),
					idEntradasLineas = table.Column<int>(nullable: true),
					idSalidasLineas = table.Column<int>(nullable: true),
					UdsEnvase = table.Column<decimal>(type: "decimal(18, 5)", nullable: true, computedColumnSql: "([dbo].[EnvasesDeStock]([envase],[Cantidad]))"),
					FechaERP = table.Column<DateTime>(type: "datetime", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Stocks", x => x.Id);
					table.ForeignKey(
						name: "FK_Stocks_Envases",
						column: x => x.Envase,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Stocks_Formatos",
						column: x => x.Formato,
						principalTable: "Formatos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Stocks_Lotes",
						column: x => x.Lote,
						principalTable: "Lotes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Stocks_Productos",
						column: x => x.Producto,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Stocks_Ubicaciones",
						column: x => x.Ubicacion,
						principalTable: "Ubicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Stocks_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Stocks_EntradasLineas",
						column: x => x.idEntradasLineas,
						principalTable: "EntradasLineas",
						principalColumn: "id",
						onDelete: ReferentialAction.SetNull);
					table.ForeignKey(
						name: "FK_Stocks_SalidasLinias",
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
				name: "VentasLiniasMedicaciones",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idVentaLinia = table.Column<int>(nullable: true),
					idEnvase = table.Column<int>(nullable: true),
					idFormato = table.Column<int>(nullable: true),
					idMedicamento = table.Column<int>(nullable: true),
					idUnidad = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					Cantidad = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Bultos = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					Estado = table.Column<int>(nullable: true),
					Precio = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					PrecioUnidad = table.Column<decimal>(type: "numeric(18, 6)", nullable: true),
					idLineaSalidaMedicamento = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_VentasLiniasMedicaciones", x => x.id);
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
						name: "FK_VentasLiniasMedicaciones_SalidasLiniasMedicaciones",
						column: x => x.idLineaSalidaMedicamento,
						principalTable: "SalidasLiniasMedicaciones",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VentasLiniasMedicaciones_Medicaciones",
						column: x => x.idMedicamento,
						principalTable: "Medicaciones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VentasLiniasMedicaciones_Unidades",
						column: x => x.idUnidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_VentasLiniasMedicaciones_VentasLinias",
						column: x => x.idVentaLinia,
						principalTable: "VentasLinias",
						principalColumn: "id",
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
					Exportado = table.Column<bool>(nullable: true),
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
					Importado = table.Column<bool>(nullable: true),
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
					Validada = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
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
					Envase = table.Column<int>(nullable: true),
					UdsEnvase = table.Column<decimal>(type: "decimal(18, 5)", nullable: true, computedColumnSql: "([dbo].[EnvasesDeStock]([Envase],[Cantidad]))")
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

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [OrdenKWConsumidosTotal]
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

				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [OrdenKWProducidosTotal]
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

				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [OrdenKWConsumidosEfectivo]
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

				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [OrdenKWProducidosEfectivo]
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

				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [OrdenCantidadProducida]
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

				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [OrdenKWEfectivoCantidad]
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

				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [OrdenKWTotalCantidad]
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

				GO
			");

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
					Ordenacion = table.Column<int>(nullable: true)
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
						name: "FK_Tarjetas_SalidasLinias",
						column: x => x.IdLinSalida,
						principalTable: "SalidasLinias",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Tarjetas_ordenes",
						column: x => x.IdOrdenActual,
						principalTable: "Ordenes",
						principalColumn: "Id",
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
					exportado = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
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
					Exportado = table.Column<bool>(nullable: true),
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
					Observaciones = table.Column<string>(type: "ntext", nullable: true),
					idSerie = table.Column<int>(nullable: false),
					Codigo = table.Column<int>(nullable: false),
					Referencia = table.Column<string>(maxLength: 50, nullable: true),
					IdDepartamento = table.Column<int>(nullable: true),
					Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
					idCliente = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					Comentario = table.Column<string>(type: "ntext", nullable: true),
					FechaPrevista = table.Column<DateTime>(type: "datetime", nullable: true),
					FInicio = table.Column<DateTime>(type: "datetime", nullable: true),
					FFin = table.Column<DateTime>(type: "datetime", nullable: true),
					idViaje = table.Column<int>(nullable: true),
					Precio = table.Column<decimal>(type: "numeric(18, 3)", nullable: true),
					ReferenciaVenta = table.Column<string>(maxLength: 20, nullable: true),
					Exportado = table.Column<bool>(nullable: true),
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
					idOld = table.Column<int>(nullable: true)
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
						onDelete: ReferentialAction.Restrict);
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

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [FormulaKWToneladaEfectivo]
				(
					-- Add the parameters for the function here
					@idf as int
				)
				RETURNS decimal(18,4)
				AS
				BEGIN
					DECLARE @ret decimal(18,4)

					select @ret= sum(KWEfectivoTonelada) from (
					select  m.TipoModulo ,  avg(OE.KWEfectivoTonelada) as KWEfectivoTonelada   
				from (select top 50 * from Ordenes where Formula =@idf and Estado =5 order by Id desc ) as O 
				inner join ordenesdatosextra as OE on OE.id=O.id
				inner join Modulos as m on m.Id = O.Modulo 
					where OE.KWEfectivoTonelada >0
					group by m.TipoModulo ) as tmp

					RETURN isnull( @ret,0)

				END

				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [FormulaKWToneladaTotal]
				(
					-- Add the parameters for the function here
					@idf as int
				)
				RETURNS decimal(18,4)
				AS
				BEGIN
					DECLARE @ret decimal(18,4)

					select @ret= sum(KWTotalTonelada) from (
					select  m.TipoModulo ,  avg(OE.KWTotalTonelada) as KWTotalTonelada   
				from (select top 50 * from Ordenes where Formula =@idf and Estado =5 order by Id desc ) as O 
				inner join ordenesdatosextra as OE on OE.id=O.id
				inner join Modulos as m on m.Id = O.Modulo 
					where OE.KWTotalTonelada >0
					group by m.TipoModulo ) as tmp

					RETURN isnull( @ret,0)

				END

				GO
			");

			migrationBuilder.CreateTable(
				name: "FormulasDatosExtra",
				columns: table => new
				{
					id = table.Column<int>(nullable: false),
					KWToneladaEfectivo = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, computedColumnSql: "([dbo].[FormulaKWToneladaEfectivo]([id]))"),
					KWToneladaTotal = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, computedColumnSql: "([dbo].[FormulaKWToneladaTotal]([id]))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_FormulasDatosExtra", x => x.id);
					table.ForeignKey(
						name: "FK_FormulasDatosExtra_Formulas",
						column: x => x.id,
						principalTable: "Formulas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
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
						name: "FK_Versiones_Formulas",
						column: x => x.Formula,
						principalTable: "Formulas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Versiones_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [VersionKWToneladaEfectivo]
				(
					-- Add the parameters for the function here
					@idf as int
				)
				RETURNS decimal(18,4)
				AS
				BEGIN
					DECLARE @ret decimal(18,4)

					select @ret= sum(KWEfectivoTonelada) from (
					select  m.TipoModulo ,  avg(OE.KWEfectivoTonelada) as KWEfectivoTonelada   
				from (select top 50 * from Ordenes where [Version] =@idf and Estado =5 order by Id desc ) as O 
				inner join ordenesdatosextra as OE on OE.id=O.id
				inner join Modulos as m on m.Id = O.Modulo 
					where OE.KWEfectivoTonelada >0
					group by m.TipoModulo ) as tmp

					RETURN isnull( @ret,0)

				END

				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [VersionKWToneladaTotal]
				(
					-- Add the parameters for the function here
					@idf as int
				)
				RETURNS decimal(18,4)
				AS
				BEGIN
					DECLARE @ret decimal(18,4)

					select @ret= sum(KWTotalTonelada) from (
					select  m.TipoModulo ,  avg(OE.KWTotalTonelada) as KWTotalTonelada   
				from (select top 50 * from Ordenes where [Version] =@idf and Estado =5 order by Id desc ) as O 
				inner join ordenesdatosextra as OE on OE.id=O.id
				inner join Modulos as m on m.Id = O.Modulo 
					where OE.KWTotalTonelada >0
					group by m.TipoModulo ) as tmp

					RETURN isnull( @ret,0)

				END

				GO
			");

			migrationBuilder.CreateTable(
				name: "VersionDatosExtra",
				columns: table => new
				{
					id = table.Column<int>(nullable: false),
					KWToneladaEfectivo = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, computedColumnSql: "([dbo].[VersionKWToneladaEfectivo]([id]))"),
					KWToneladaTotal = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, computedColumnSql: "([dbo].[VersionKWToneladaTotal]([id]))")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_VersionDatosExtra", x => x.id);
					table.ForeignKey(
						name: "FK_VersionDatosExtra_Version",
						column: x => x.id,
						principalTable: "Versiones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
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
					Estado = table.Column<int>(nullable: true),
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
					PLCEstadoActual = table.Column<int>(nullable: true),
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
					ConOrigenes = table.Column<bool>(nullable: true),
					ConDestinos = table.Column<bool>(nullable: true),
					AjusteStockFinalOrden = table.Column<bool>(nullable: true),
					MinimoSiloResetUbi = table.Column<bool>(nullable: true),
					VaciarSilosMinimosFinOrden = table.Column<bool>(nullable: true),
					CaminosActivar = table.Column<bool>(nullable: true),
					CaminosMin = table.Column<int>(nullable: true),
					CaminosMax = table.Column<int>(nullable: true),
					CaminosDescripcion = table.Column<string>(type: "ntext", nullable: true),
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
					RequiereValidacion = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
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
						name: "FK_Modulos_OEEEstadosTipo",
						column: x => x.EstadoForzado,
						principalTable: "OEEEstadosTipo",
						principalColumn: "id",
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
						name: "FK_LogMovimientosStocks_Stocks",
						column: x => x.IdStock,
						principalTable: "Stocks",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
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
				name: "OEEEstadosModulos",
				columns: table => new
				{
					idEstadoTipo = table.Column<int>(nullable: false),
					idModulo = table.Column<int>(nullable: false)
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
				name: "OEEHorarios",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					idModulo = table.Column<int>(nullable: true),
					idMedidor = table.Column<int>(nullable: true),
					HoraInicio = table.Column<TimeSpan>(nullable: false),
					HoraFin = table.Column<TimeSpan>(nullable: false),
					Lunes = table.Column<bool>(nullable: false),
					Martes = table.Column<bool>(nullable: false),
					Miercoles = table.Column<bool>(nullable: false),
					Jueves = table.Column<bool>(nullable: false),
					Viernes = table.Column<bool>(nullable: false),
					Sabado = table.Column<bool>(nullable: false),
					Domingo = table.Column<bool>(nullable: false)
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
						name: "FK_Componentes_Versiones",
						column: x => x.Version,
						principalTable: "Versiones",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
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
					OpcConfigId = table.Column<int>(nullable: true)
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
				name: "OEEEstados",
				columns: table => new
				{
					id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdModulo = table.Column<int>(nullable: true),
					IdMedidor = table.Column<int>(nullable: true),
					Estado = table.Column<int>(nullable: true),
					FInicio = table.Column<DateTime>(type: "datetime", nullable: true),
					FFinal = table.Column<DateTime>(type: "datetime", nullable: true),
					VentanaSegs = table.Column<int>(nullable: true),
					OperarioId = table.Column<int>(nullable: true),
					IdTurno = table.Column<int>(nullable: true),
					IdAlarmaActual = table.Column<int>(nullable: true),
					IdOrdenActual = table.Column<int>(nullable: true)
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
					IdPLC = table.Column<int>(nullable: true),
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
					OpcConfigId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Tags", x => x.Id);
					table.ForeignKey(
						name: "FK__Tags__OpcConfigI__04BA9F53",
						column: x => x.OpcConfigId,
						principalTable: "OpcConfig",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
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
					Tipo = table.Column<int>(nullable: true),
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
					PosicionPLC = table.Column<int>(nullable: true),
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
					OpcConfigId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Basculas", x => x.Id);
					table.ForeignKey(
						name: "FK__Basculas__OpcCon__54B68676",
						column: x => x.OpcConfigId,
						principalTable: "OpcConfig",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Basculas_Tags",
						column: x => x.Tag,
						principalTable: "Tags",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
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
				name: "IX_CompActivosLista_Unidad",
				table: "CompActivosLista",
				column: "Unidad");

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
				name: "IX_ComponentesActivos_IdCompActivosLista",
				table: "ComponentesActivos",
				column: "IdCompActivosLista");

			migrationBuilder.CreateIndex(
				name: "IX_ComponentesActivos_Producto",
				table: "ComponentesActivos",
				column: "Producto");

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
				name: "IEntradas1",
				table: "Entradas",
				columns: new[] { "id", "FechaCreacion", "FechaPrevista", "idVehiculo", "idChofer", "idProveedor", "idTarjeta", "EstadoTransito", "MatriculaCamion", "NombreConductor", "Observaciones", "idEmpresaTransporte", "LedControlDocumental", "MatriculaRemolque", "Precio", "FInicio", "Referencia", "ReferenciaCompra", "PreDesinfeccion", "PostDesinfeccion", "PreDesinfeccionOK", "PostDesinfeccionOK", "exportado", "Serie", "Numero", "FFin", "Estado" });

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
				name: "IX_InformesLib_IdCategoria",
				table: "InformesLib",
				column: "IdCategoria");

			migrationBuilder.CreateIndex(
				name: "IX_InformesLib_IdInformeBase",
				table: "InformesLib",
				column: "IdInformeBase");

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
				name: "IX_Medicaciones_idProducto",
				table: "Medicaciones",
				column: "idProducto");

			migrationBuilder.CreateIndex(
				name: "IX_MedicacionesIngredientes_Medicacion",
				table: "MedicacionesIngredientes",
				column: "Medicacion");

			migrationBuilder.CreateIndex(
				name: "IX_MedicacionesIngredientes_Producto",
				table: "MedicacionesIngredientes",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_MedicacionesIngredientes_Unidad",
				table: "MedicacionesIngredientes",
				column: "Unidad");

			migrationBuilder.CreateIndex(
				name: "IX_Medidores_EstadoForzado",
				table: "Medidores",
				column: "EstadoForzado");

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
				name: "IX_Modulos_EstadoForzado",
				table: "Modulos",
				column: "EstadoForzado");

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
				name: "IX_NetAlarmas_IdModulo",
				table: "NetAlarmas",
				column: "IdModulo");

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
				name: "_dta_index_NetAlarmas_2",
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
				name: "_dta_index_Ordenes_3",
				table: "Ordenes",
				column: "Medicada");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_Modulo",
				table: "Ordenes",
				column: "Modulo");

			migrationBuilder.CreateIndex(
				name: "IX_Ordenes_ProductoDestino",
				table: "Ordenes",
				column: "ProductoDestino");

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
				name: "iOrdenes_estado_ffin",
				table: "Ordenes",
				columns: new[] { "Estado", "Fin" });

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
				name: "IX_PLCAddonsVars_idAddon",
				table: "PLCAddonsVars",
				column: "idAddon");

			migrationBuilder.CreateIndex(
				name: "IX_PLCRead",
				table: "PLCRead",
				column: "Nombre");

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
				name: "IX_RecetasLineas_idMedicamento",
				table: "RecetasLineas",
				column: "idMedicamento");

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
				name: "IX_SalidasLiniasMedicaciones_idEnvase",
				table: "SalidasLiniasMedicaciones",
				column: "idEnvase");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasMedicaciones_idFormato",
				table: "SalidasLiniasMedicaciones",
				column: "idFormato");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasMedicaciones_idMedicamento",
				table: "SalidasLiniasMedicaciones",
				column: "idMedicamento");

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
				name: "I_StocksUbis",
				table: "Stocks",
				columns: new[] { "Ubicacion", "Cantidad", "Estado" });

			migrationBuilder.CreateIndex(
				name: "IX_Stocks_Ubicacion_Estado",
				table: "Stocks",
				columns: new[] { "Lote", "Fecha", "Ubicacion", "Estado" });

			migrationBuilder.CreateIndex(
				name: "IStocks1",
				table: "Stocks",
				columns: new[] { "Producto", "Formato", "Lote", "Envase", "Cantidad", "Unidad", "Fecha", "Estado", "Importado", "Exportado", "Palet", "Procesando", "Observaciones", "idOld", "idEntradasLineas", "idSalidasLineas", "Ubicacion", "Id" });

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
				name: "IX_Tarjetas_IdLinSalida",
				table: "Tarjetas",
				column: "IdLinSalida");

			migrationBuilder.CreateIndex(
				name: "IX_Tarjetas_IdOrdenActual",
				table: "Tarjetas",
				column: "IdOrdenActual");

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
				name: "IX_Ubicaciones_Producto",
				table: "Ubicaciones",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_Ubicaciones_Unidad",
				table: "Ubicaciones",
				column: "Unidad");

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
				name: "IX_VentasLiniasMedicaciones_idEnvase",
				table: "VentasLiniasMedicaciones",
				column: "idEnvase");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLiniasMedicaciones_idFormato",
				table: "VentasLiniasMedicaciones",
				column: "idFormato");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLiniasMedicaciones_idLineaSalidaMedicamento",
				table: "VentasLiniasMedicaciones",
				column: "idLineaSalidaMedicamento");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLiniasMedicaciones_idMedicamento",
				table: "VentasLiniasMedicaciones",
				column: "idMedicamento");

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

			migrationBuilder.AddForeignKey(
				name: "FK_Medicaciones_Productos",
				table: "Medicaciones",
				column: "idProducto",
				principalTable: "Productos",
				principalColumn: "Id",
				onDelete: ReferentialAction.SetNull);

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

			migrationBuilder.Sql($@"
				CREATE OR ALTER TRIGGER [triggerInsertCertificadoDesinfeccion]
				   ON  [dbo].[CertificadoDesinfeccion]
				   AFTER INSERT, UPDATE
				AS 
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for trigger here
					declare @mynumero as int
					select @mynumero  = i.Numero    from  inserted i;

					if @mynumero =0 or @mynumero is null
					begin

						declare @myserie as int
						declare @mynewnumero as int
	
						select @myserie = i.Serie  from  inserted i;

						SELECT top 1 @mynewnumero= (Numero + 1)
						FROM CertificadoDesinfeccion as T
							inner join Series as S on S.Id =@myserie
						WHERE NOT EXISTS( 		SELECT 1 FROM CertificadoDesinfeccion WHERE (Numero = T.Numero + 1) and Serie = @myserie ) 
							AND Numero >= S.ContadorCertificadoDesinfeccion
							AND Serie=@myserie
						ORDER BY Numero;

						IF @@ROWCOUNT = 0
						begin
							select @mynewnumero=ContadorCertificadoDesinfeccion from Series where Id=@myserie;
							if @mynewnumero =0
							begin
								set @mynewnumero=1;
							end
						end

						--UPDATE  a  SET a.Numero = (select isnull( max(Numero)+1, 1) as nn from Compras where Serie = @myserie ) FROM Compras  a JOIN inserted i ON a.Id = i.Id
						UPDATE  a  SET a.Numero = @mynewnumero FROM CertificadoDesinfeccion  a JOIN inserted i ON a.Id = i.Id

					end 
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER TRIGGER [triggerInsertCompras]
				   ON  [dbo].[Compras]
				   AFTER INSERT,  update
				AS 
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;
					declare @mynumero as int
					select @mynumero  = i.Numero   from  inserted i;

					if @mynumero =0 or @mynumero is null
					begin

						declare @myserie as int
						declare @mynewnumero as int
	
						select @myserie = i.Serie  from  inserted i;

						SELECT top 1 @mynewnumero= (Numero + 1)
						FROM Compras as T
							inner join Series as S on S.Id =@myserie
						WHERE NOT EXISTS( 		SELECT 1 FROM Compras WHERE (Numero = T.Numero + 1) and Serie = @myserie ) 
							AND Numero >= S.ContadorCompras 
							and Serie=@myserie
						ORDER BY Numero;

						IF @@ROWCOUNT = 0
						begin
							select @mynewnumero=ContadorCompras from Series where Id=@myserie;
							if @mynewnumero =0
							begin
								set @mynewnumero=1;
							end
						end

						--UPDATE  a  SET a.Numero = (select isnull( max(Numero)+1, 1) as nn from Compras where Serie = @myserie ) FROM Compras  a JOIN inserted i ON a.Id = i.Id
						UPDATE  a  SET a.Numero = @mynewnumero FROM Compras  a JOIN inserted i ON a.Id = i.Id

					end 
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER TRIGGER [triggerInsertEntradas]
				   ON  [dbo].[Entradas]
				   AFTER INSERT, UPDATE
				AS 
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for trigger here
					declare @mynumero as int
					select @mynumero  = i.Numero   from  inserted i;

					if @mynumero =0 or @mynumero is null
					begin

						declare @myserie as int
						declare @mynewnumero as int
	
						select @myserie = i.Serie  from  inserted i;

						SELECT top 1 @mynewnumero= (Numero + 1)
						FROM Entradas as T
							inner join Series as S on S.Id =@myserie
						WHERE NOT EXISTS( 		SELECT 1 FROM Entradas WHERE (Numero = T.Numero + 1) and Serie = @myserie ) 
							AND Numero >= S.ContadorEntradas 
							and Serie=@myserie
						ORDER BY Numero;

						IF @@ROWCOUNT = 0
						begin
							select @mynewnumero=ContadorEntradas from Series where Id=@myserie;
							if @mynewnumero =0
							begin
								set @mynewnumero=1;
							end
						end

						--UPDATE  a  SET a.Numero = (select isnull( max(Numero)+1, 1) as nn from Compras where Serie = @myserie ) FROM Compras  a JOIN inserted i ON a.Id = i.Id
						UPDATE  a  SET a.Numero = @mynewnumero FROM Entradas  a JOIN inserted i ON a.Id = i.Id

					end 
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER TRIGGER [triggerInsertRecetas]
				   ON  [dbo].[Recetas]
				   AFTER INSERT, UPDATE
				AS 
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for trigger here
					declare @mynumero as int
					select @mynumero  = i.NumReceta    from  inserted i;

					if @mynumero =0 or @mynumero is null
					begin

						declare @myserie as int
						declare @mynewnumero as int
	
						select @myserie = i.idSerie  from  inserted i;

						SELECT top 1 @mynewnumero= (NumReceta + 1)
						FROM Recetas as T
							inner join Series as S on S.Id =@myserie
						WHERE NOT EXISTS( 		SELECT 1 FROM Recetas WHERE (NumReceta = T.NumReceta + 1) and idSerie = @myserie ) 
							AND NumReceta >= S.ContadorRecetas
							AND idSerie=@myserie
						ORDER BY NumReceta;

						IF @@ROWCOUNT = 0
						begin
							select @mynewnumero=ContadorRecetas from Series where Id=@myserie;
							if @mynewnumero =0
							begin
								set @mynewnumero=1;
							end
						end

						--UPDATE  a  SET a.Numero = (select isnull( max(Numero)+1, 1) as nn from Compras where Serie = @myserie ) FROM Compras  a JOIN inserted i ON a.Id = i.Id
						UPDATE  a  SET a.NumReceta  = @mynewnumero FROM Recetas  a JOIN inserted i ON a.Id = i.Id

					end 
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER TRIGGER [triggerInsertSalidas]
				   ON  [dbo].[Salidas]
				   AFTER INSERT
				AS 
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for trigger here
					DECLARE @codigo AS INT;
					DECLARE @serieId AS INT;
					DECLARE @nextCodigo AS INT;
					SELECT @codigo = i.Codigo FROM INSERTED i;
					SELECT @serieId = i.idSerie FROM INSERTED i;

					-- IF Salida.Codigo is null or 0
					IF @codigo = 0 OR @codigo IS NULL
					BEGIN

						-- Get the Salida with the same idSerie that has the biggest Codigo
						SELECT TOP(1)
							@nextCodigo = (salida.Codigo + 1)
						FROM
							Salidas AS salida
						WHERE
							salida.idSerie = @serieId
						ORDER BY
							salida.Codigo DESC;

						-- If there are no results
						IF @@ROWCOUNT = 0
						BEGIN

							-- Load the ContadorSalidas from the required serieId
							SELECT 
								@nextCodigo = serie.ContadorSalidas 
							FROM 
								Series AS serie 
							WHERE 
								serie.Id = @serieId;

							-- In case the serie.ContadorSalidas is 0, load 1
							IF @nextCodigo = 0
							BEGIN
								SET @nextCodigo = 1;
							END
						END

						-- Update the inserted Salida
						UPDATE salida 
						SET salida.Codigo = @nextCodigo 
						FROM Salidas salida 
						JOIN INSERTED i ON salida.Id = i.Id;
					END 
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER TRIGGER [triggerInsertSalidasAlbaranes]
					ON  [dbo].[SalidasAlbaranes]
					AFTER INSERT, UPDATE
				AS 
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for trigger here
					declare @mynumero as int
					select @mynumero  = i.Numero   from  inserted i;

					if @mynumero =0 or @mynumero is null
					begin

						declare @myserie as int
						declare @mynewnumero as int
	
						select @myserie = i.Serie  from  inserted i;

						SELECT top 1 @mynewnumero= (Numero + 1)
						FROM SalidasAlbaranes as T
							inner join Series as S on S.Id =@myserie
						WHERE NOT EXISTS( 		SELECT 1 FROM SalidasAlbaranes WHERE (Numero = T.Numero + 1) and Serie = @myserie ) 
							AND Numero >= S.ContadorAlbaranes
							AND Serie=@myserie
						ORDER BY Numero;

						IF @@ROWCOUNT = 0
						begin
							select @mynewnumero=ContadorAlbaranes from Series where Id=@myserie;
							if @mynewnumero =0
							begin
								set @mynewnumero=1;
							end
						end

						UPDATE  a  SET a.Numero = @mynewnumero, a.Auto = 1 FROM SalidasAlbaranes  a JOIN inserted i ON a.Id = i.Id

					end 
					else
					begin
						UPDATE  a  SET a.Auto = 0 FROM SalidasAlbaranes  a JOIN inserted i ON a.Id = i.Id
					end
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER TRIGGER [triggerInsertSalidasViajes]
				   ON  [dbo].[SalidasViajes]
				   AFTER INSERT, UPDATE
				AS 
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for trigger here
					declare @mynumero as int
					select @mynumero  = i.Numero   from  inserted i;

					if @mynumero =0 or @mynumero is null
					begin

						declare @myserie as int
						declare @mynewnumero as int
	
						select @myserie = i.idSerie  from  inserted i;

						--SELECT top 1 @mynewnumero= (Numero + 1)
						--FROM SalidasViajes as T
						--	inner join Series as S on S.Id =@myserie
						--WHERE NOT EXISTS( 		SELECT 1 FROM SalidasViajes WHERE (Numero = T.Numero + 1) and idSerie = @myserie ) 
						--	AND Numero >= S.ContadorViajes
						--	AND idSerie=@myserie
						--ORDER BY Numero;

						SET @mynewnumero = (SELECT MAX(Numero) + 1
										FROM SalidasViajes as SV
								inner join Series as S on S.Id = @myserie
									WHERE Numero >= S.ContadorViajes  
										and idSerie = @myserie);

						IF @@ROWCOUNT = 0
						begin
							select @mynewnumero=ContadorViajes from Series where Id=@myserie;
							if @mynewnumero =0
							begin
								set @mynewnumero=1;
							end
						end

						--UPDATE  a  SET a.Numero = (select isnull( max(Numero)+1, 1) as nn from Compras where Serie = @myserie ) FROM Compras  a JOIN inserted i ON a.Id = i.Id
						UPDATE  a  SET a.Numero = @mynewnumero FROM SalidasViajes  a JOIN inserted i ON a.Id = i.Id

					end 
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER TRIGGER [triggerInsertVentas]
				   ON  [dbo].[Ventas]
				   AFTER INSERT,  update
				AS 
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;
					declare @mynumero as int
					select @mynumero  = i.Codigo    from  inserted i;

					if @mynumero =0 or @mynumero is null
					begin

						declare @myserie as int
						declare @mynewnumero as int
	
						select @myserie = i.idSerie   from  inserted i;

						SELECT top 1 @mynewnumero= (Codigo + 1)
						FROM Ventas as T
							inner join Series as S on S.Id =@myserie
						WHERE NOT EXISTS( 		SELECT 1 FROM Ventas WHERE (Codigo = T.Codigo + 1) and idSerie = @myserie ) 
							AND Codigo >= S.ContadorCompras 
							and idSerie=@myserie
						ORDER BY Codigo;

						IF @@ROWCOUNT = 0
						begin
							select @mynewnumero=ContadorVentas from Series where Id=@myserie;
							if @mynewnumero =0
							begin
								set @mynewnumero=1;
							end
						end

						--UPDATE  a  SET a.Numero = (select isnull( max(Numero)+1, 1) as nn from Compras where Serie = @myserie ) FROM Compras  a JOIN inserted i ON a.Id = i.Id
						UPDATE  a  SET a.Codigo  = @mynewnumero FROM [Ventas]  a JOIN inserted i ON a.Id = i.Id

					end 
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER TRIGGER [Trigger_OrdenPLC]
				ON [dbo].[Ordenes]
				AFTER INSERT
				AS
				BEGIN
				DECLARE @ID_ORDEN int
				SET @ID_ORDEN =(SELECT Id FROM INSERTED)

				UPDATE Ordenes SET OrdenEnvioPLC = @ID_ORDEN WHERE Id IN (SELECT DISTINCT Id FROM INSERTED);
				insert into OrdenesDatosExtra (id) values (@ID_ORDEN );


				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER TRIGGER [Trigger_Formulas]
				ON [dbo].[Formulas]
				AFTER INSERT
				AS
				BEGIN
				DECLARE @ID_ORDEN int
				SET @ID_ORDEN =(SELECT Id FROM INSERTED)
				insert into FormulasDatosExtra (id) values (@ID_ORDEN );
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER TRIGGER [dbo].[Trigger_Version]
				ON [dbo].[Versiones]
				AFTER INSERT
				AS
				BEGIN
				DECLARE @ID_ORDEN int
				SET @ID_ORDEN =(SELECT Id FROM INSERTED)
				insert into VersionDatosExtra (id) values (@ID_ORDEN );
				END
				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [CantidadSegunTiempo] 
				(
					-- Add the parameters for the function here
					@Cantidad decimal(12,5),
					@PeriodoInicio datetime,
					@PeriodoFinal datetime,
					@FProcesoInicio datetime,
					@FProcesoFinal datetime
				)
				RETURNS decimal(15,8)
				AS
				BEGIN
					-- Declare the return variable here
					DECLARE @resultado decimal(15,5);
					DECLARE @porcentaje decimal(15,8);

					declare @TiempoTotalSegsProceso int;
					declare @TiempoTotalSegsEfectivo int;

	


					if (@PeriodoInicio<= @FProcesoInicio and @PeriodoFinal >= @FProcesoFinal)
					begin
						set @porcentaje =100;
						set @resultado =@Cantidad ;
					end
					else
					begin
						set @TiempoTotalSegsProceso = DATEDIFF(second, @FProcesoInicio, @FProcesoFinal   );

						if(@FProcesoInicio > @PeriodoFinal or @FProcesoFinal < @PeriodoInicio ) 
						begin
							set @porcentaje =0;
						end
						else
						begin
							if (@PeriodoInicio > @FProcesoInicio) 
								set @FProcesoInicio = @PeriodoInicio;
							if (@PeriodoFinal < @FProcesoFinal) 
								set @FProcesoFinal = @PeriodoFinal;

		
							set @TiempoTotalSegsEfectivo = DATEDIFF(second, @FProcesoInicio, @FProcesoFinal);
							set @porcentaje =(@TiempoTotalSegsEfectivo*100) / @TiempoTotalSegsProceso;
							set @resultado = (@Cantidad *@TiempoTotalSegsEfectivo) / @TiempoTotalSegsProceso;
						end 
					end
	
					--set @resultado = @Cantidad * (@porcentaje /100);
					-- Return the result of the function
					RETURN @resultado;

				END

				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [GetTextoParametro](@Grupo nvarchar(50), @Parametro nvarchar(50), @ValorParametro integer) RETURNS nvarchar(50)

				AS
				BEGIN
				   RETURN (SELECT TOP 1 Texto
							 FROM TextosParametros
							WHERE Grupo = @Grupo 
							  AND Parametro = @Parametro
							  AND idTexto = @ValorParametro);
				END
				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [ProductividadModuloDia] 
				(
					-- Add the parameters for the function here
					@idModulo as int,
					@fecha as date
				)
				RETURNS decimal(18,3)
				AS
				BEGIN

					declare @finicio as datetime
					declare @ffinal as datetime
					declare @finicio2 as datetime
					declare @ffinal2 as datetime
					declare @filtrodiafinal as date
					declare @producido as decimal(15,5)
					declare @diffminutos as decimal(18,2)
					declare @KGHora as decimal(18,3)

					set @filtrodiafinal = dateadd(day, 1, @fecha)


				 select top 1 @finicio = Inicio from Ordenes where Modulo =@idModulo and Inicio >@fecha and Inicio<@filtrodiafinal order by Inicio asc;
				 select top 1 @ffinal = Fin  from Ordenes where Modulo =@idModulo and Inicio >@fecha and Inicio<@filtrodiafinal order by Fin desc;

				 select top 1 @finicio2 = D.Fecha 
					from Desgloses   as D
					inner join Ordenes as O on O.id = D.Orden 
					where  O.Modulo =@idModulo and D.Fecha>@Fecha and D.Fecha <@filtrodiafinal    order by D.Fecha asc;

				 select top 1 @ffinal2 = D.Fecha 
					from Desgloses   as D
					inner join Ordenes as O on O.id = D.Orden 
					where  O.Modulo =@idModulo and D.Fecha>@Fecha and D.Fecha <@filtrodiafinal    order by D.Fecha desc;
 
				 /* 
				 Control, si es 24h... y está produciendo, recoga como fecha de inicio el primer desglose encontrado...
				 */
				 if @finicio2 <@finicio 
				 begin
					set @finicio = @finicio2 
				 end

				 if @ffinal2  <@ffinal
				 begin
					set @ffinal = @ffinal2 
				 end





				 select @producido= sum(R.Cantidad)  
				 from Ordenes as O
				 left outer join Desgloses as R on R.Orden = O.Id 
				 where O.Modulo =12 and R.Fecha  >@fecha and R.Fecha <@filtrodiafinal
				 ;

				 set @diffminutos = DATEDIFF( second, @finicio, @ffinal)

				 set @KGHora = @producido / (@diffminutos /60/60)


				 return @KGHora


				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [RangoFechaInicio] 
				(
					-- Add the parameters for the function here
					@valor nvarchar(50)
				)
				RETURNS datetime
				AS
				BEGIN
					-- Declare the return variable here
					DECLARE @ret datetime

					/*
					Personalizada
				Ult. 1 Hora
				Ult. 3 Horas
				Ult. 6 Horas
				Ult. 12 Horas
				Ult. 24 Horas
				Ult. 3 días
				Ult. 7 días
				Ult. 30 días
					*/

					select @ret=case
						when @valor='Ult. 1 Hora' then DATEADD (hour, -1, getdate())
						when @valor='Ult. 3 Horas' then DATEADD (hour, -3, getdate())
						when @valor='Ult. 6 Horas' then DATEADD (hour, -6, getdate())
						when @valor='Ult. 12 Horas' then DATEADD (hour, -12, getdate())
						when @valor='Ult. 24 Horas' then DATEADD (hour, -24, getdate())
						when @valor='Ult. 3 días' then DATEADD (day, -3, getdate())
						when @valor='Ult. 7 días' then DATEADD (day, -7, getdate())
						when @valor='Ult. 30 días' then DATEADD (day, -30, getdate())
						else DATEADD (day, -1, getdate())
					end 

					-- Return the result of the function
					RETURN @ret

				END
				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [VerTurno] 
				(
					-- Add the parameters for the function here
					@fecha as datetime
				)
				RETURNS nvarchar(50)
				AS
				BEGIN
					-- Declare the return variable here
					declare @hora as time = cast(@fecha as time)
					declare @ret as nvarchar(50) = ''

					select  @ret= max( Nombre)
					from turnos
					where (HoraFinal > HoraInicio and @hora >= HoraInicio and @Hora< HoraFinal)
						or (HoraFinal < HoraInicio and ((@hora >= HoraInicio and @hora < '23:59:59.999') or (@hora >= '00:00:00' and @hora < HoraFinal)))

					RETURN @ret

				END


				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [VerTurnoId] 
				(
					-- Add the parameters for the function here
					@fecha as datetime
				)
				RETURNS int
				AS
				BEGIN
					-- Declare the return variable here
					declare @hora as time = cast(@fecha as time)
					declare @ret as nvarchar(50) = ''

					select  @ret= max( id )
					from turnos
					where (HoraFinal > HoraInicio and @hora >= HoraInicio and @Hora< HoraFinal)
						or (HoraFinal < HoraInicio and ((@hora >= HoraInicio and @hora < '23:59:59.999') or (@hora >= '00:00:00' and @hora < HoraFinal)))

					RETURN @ret

				END
				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [dbo].[ListaStringToInt] (@list nvarchar(MAX))
				   RETURNS @tbl TABLE (number int NOT NULL) AS
				BEGIN
				   DECLARE @pos        int,
						   @nextpos    int,
						   @valuelen   int

				   SELECT @pos = 0, @nextpos = 1

				   WHILE @nextpos > 0
				   BEGIN
					  SELECT @nextpos = charindex(',', @list, @pos + 1)
					  SELECT @valuelen = CASE WHEN @nextpos > 0
											  THEN @nextpos
											  ELSE len(@list) + 1
										 END - @pos - 1
					  INSERT @tbl (number)
						 VALUES (convert(int, substring(@list, @pos + 1, @valuelen)))
					  SELECT @pos = @nextpos
				   END
				   RETURN
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [dbo].[ProductividadFechasModulo] 
				(	
					-- Add the parameters for the function here
					@finicio as date, 
					@ffinal as date,
					@idModulo as int
				)
				RETURNS @T table(Fecha date, Productividad decimal(18,3))

				begin	

					declare @diff as int
					declare @i as int
					declare @fecha as date
					declare @Productividad as decimal(18,3)




					set @diff = DATEDIFF (day, @finicio, @ffinal)

					if @diff <0 
					begin
						--return 'No valido'
						--print 'No Valido'
						return 
					end

					set @i=@diff
					set @fecha = @finicio 

					while @i>0
					begin
						set @Productividad = isnull( dbo.ProductividadModuloDia (@idModulo , @fecha),0)
						insert into @T values (@fecha, @Productividad )


						set @i = @i-1
						set @fecha = dateadd(day, 1, @fecha)
					end

					return  
	
					-- Add the SELECT statement with parameter references here
	
				end
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [dbo].[SplitInts]  
				(  
				   @List      VARCHAR(MAX),  
				   @Delimiter VARCHAR(255)  
				)  
				RETURNS TABLE  
				AS  
				  RETURN ( SELECT Item = CONVERT(INT, Item) FROM  
					  ( SELECT Item = x.i.value('(./text())[1]', 'varchar(max)')  
						FROM ( SELECT [XML] = CONVERT(XML, '<i>'  
						+ REPLACE(@List, @Delimiter, '</i><i>') + '</i>').query('.')  
						  ) AS a CROSS APPLY [XML].nodes('i') AS x(i) ) AS y  
					  WHERE Item IS NOT NULL  
				  );
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [dbo].[TVF_TimeRange_Split_To_Grid]
				(
					@eventStartTime datetime
					, @eventDurationMins float
					, @intervalMins int
				)
				RETURNS @retTable table
				(
					intervalStartTime datetime
					,intervalEndTime datetime
					,eventDurationInIntervalMins float
				)
				AS
				BEGIN

					declare @eventMinuteOfDay int
					set @eventMinuteOfDay = datepart(hour,@eventStartTime)*60+datepart(minute,@eventStartTime)

					declare @intervalStartMinute int
					set @intervalStartMinute = @eventMinuteOfDay - @eventMinuteOfDay % @intervalMins

					declare @intervalStartTime datetime
					set @intervalStartTime = dateadd(minute,@intervalStartMinute,cast(floor(cast(@eventStartTime as float)) as datetime))

					declare @intervalEndTime datetime
					set @intervalEndTime = dateadd(minute,@intervalMins,@intervalStartTime)

					declare @eventDurationInIntervalMins float

					while (@eventDurationMins>0)
					begin

						set @eventDurationInIntervalMins = cast(@intervalEndTime-@eventStartTime as float)*24*60
						if @eventDurationMins<@eventDurationInIntervalMins 
							set @eventDurationInIntervalMins = @eventDurationMins

						--set @eventDurationInIntervalMins = @eventDurationInIntervalMins *60

						insert into @retTable
						select @intervalStartTime,@intervalEndTime,@eventDurationInIntervalMins

						set @eventDurationMins = @eventDurationMins - @eventDurationInIntervalMins
						set @eventStartTime = @intervalEndTime

						set @intervalStartTime = @intervalEndTime
						set @intervalEndTime = dateadd(minute,@intervalMins,@intervalEndTime)
					end

					RETURN 
				END
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [dbo].[TVF_TimeRange_Split_To_GridSeconds]
				(
					@eventStartTime datetime
					, @eventDurationSeconds float
					, @intervalSeconds int
				)
				RETURNS @retTable table
				(
					intervalStartTime datetime
					,intervalEndTime datetime
					,eventDurationInIntervalSeconds float
				)
				AS
				BEGIN
	
					declare @eventSecondOfDay int
					set @eventSecondOfDay = datepart(hour,@eventStartTime)*60*60+datepart(second,@eventStartTime)+(datepart(minute,@eventStartTime)*60)

					declare @intervalStartSecond int
					set @intervalStartSecond = @eventSecondOfDay - @eventSecondOfDay % @intervalSeconds

					declare @intervalStartTime datetime
					set @intervalStartTime = dateadd(second,@intervalStartSecond,cast(floor(cast(@eventStartTime as float)) as datetime))

					declare @intervalEndTime datetime
					set @intervalEndTime = dateadd(second,@intervalSeconds,@intervalStartTime)

					declare @eventDurationInIntervalSeconds float

					while (@eventDurationSeconds>0)
					begin

						set @eventDurationInIntervalSeconds = cast(@intervalEndTime-@eventStartTime as float)*24*60*60
						if @eventDurationSeconds<@eventDurationInIntervalSeconds 
							set @eventDurationInIntervalSeconds = @eventDurationSeconds

						--set @eventDurationInIntervalMins = @eventDurationInIntervalMins *60

						insert into @retTable
						select @intervalStartTime,@intervalEndTime,@eventDurationInIntervalSeconds 

						set @eventDurationSeconds = @eventDurationSeconds - @eventDurationInIntervalSeconds
						set @eventStartTime = @intervalEndTime

						set @intervalStartTime = @intervalEndTime
						set @intervalEndTime = dateadd(second,@intervalSeconds,@intervalEndTime)
					end

					RETURN 
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER FUNCTION [dbo].[udfRankingProductosFechas] (
					@fechaInicio DATE,
					@fechaFin DATE
				)
				RETURNS TABLE
				AS
				RETURN
				SELECT DISTINCT ROW_NUMBER() OVER (ORDER BY SUM(d.Cantidad) desc) AS Ranking
					, d.Producto AS ProductoId
					, p.Nombre AS ProductoNombre
					, SUM(d.Cantidad) AS ProductoCantidad
					FROM Desgloses AS d
						LEFT OUTER JOIN Productos AS p on p.Id = d.Producto 
						LEFT OUTER JOIN Ordenes AS o on o.Id = d.Orden
						LEFT OUTER JOIN Modulos AS m on m.Id = o.Modulo
				WHERE m.TipoModulo in (120, 140)
					AND (d.Fecha >= @fechaInicio AND d.Fecha < @fechaFin)
				GROUP BY d.Producto, p.Nombre
				-- ORDER BY SUM(d.Cantidad) DESC
				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[AddIdOld]
					-- Add the parameters for the stored procedure here
					@tabla nvarchar(50) 
	
				AS
				BEGIN
				DECLARE @SQLString nvarchar(500);

				IF not EXISTS (  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(@tabla ) AND name = 'idOld')
					begin
						SET @SQLString = 'ALTER TABLE ' + @tabla +' ADD idOld int;'
						exec sp_executesql @SQLString
					end

				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[AddSerieOld]
					-- Add the parameters for the stored procedure here
					@tabla nvarchar(50) 
	
				AS
				BEGIN
				DECLARE @SQLString nvarchar(500);

				IF not EXISTS (  SELECT *   FROM   sys.columns   WHERE  object_id = OBJECT_ID(@tabla ) AND name = 'SerieOld')
					begin
						SET @SQLString = 'ALTER TABLE ' + @tabla +' ADD SerieOld int;'
						exec sp_executesql @SQLString
					end

				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[AlarmasTop10Modulo] 
					-- Add the parameters for the stored procedure here
					@Modulo int,
					@FechaInicio datetime,
					@FechaFinal datetime
	
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					select A.IdError 
						, MIN (T.textoError) as TxtError
						, COUNT(*) as contador
						, AVG(datediff( SECOND , A.FechaError , isnull(A.RespFecha, A.fechaerror))) as MediaRespuesta
					from NetAlarmas as A
					left outer join NetAlarmasTipos as T on T.Id = A.IdError  
					where A.IdModulo =@Modulo
						and A.FechaError > @FechaInicio 
						and A.FechaError < @FechaFinal 
					group by a.IdError 
					order by COUNT(*) desc

				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER procedure [dbo].[CalculoKWVentana] 
				(
					-- Add the parameters for the function here
					@IdMotor int,
					@FInicio datetime,
					@FFinal datetime,
					@IpServidor as nvarchar(50)
				)
				AS
				BEGIN
					-- Declare the return variable here
	
					DECLARE @authHeader NVARCHAR(64);
				DECLARE @contentType NVARCHAR(64);
				DECLARE @postData NVARCHAR(MAX);
				DECLARE @ValorDefecto as decimal(12,3);

				DECLARE @ret INT;
				DECLARE @token INT;
				DECLARE @url NVARCHAR(256);
				Declare @XmlResponse as nvarchar(MAX);
				declare @xmltable table ( yourXML nvarchar(MAX) );


				set @ValorDefecto =-1;


				declare @Tabla nvarchar(50); -- 0: la semanal, 1: la semestral, 2: la anual
				declare @diffsemanas int;
				set @diffsemanas = (DATEDIFF (week, @FInicio, getdate()));


				select @Tabla = case 
					when @diffsemanas <= 2 then 'Motores'
					when @diffsemanas <= 26 then 'Semestral"".""Motores'
					else 'Anual"".""Motores'
				end 


					declare @Consulta as nvarchar(max)
					set @Consulta ='db=statsVoltec&q=SELECT mean(""KWEnergiaTotal"") FROM ""' + @Tabla + '"" '
					set @Consulta = @Consulta + 'WHERE (""IdMotorPLC"" = ''' + cast(@IdMotor as nvarchar(10)) + ''') '
					set @Consulta = @Consulta + ' AND time >= ''' + convert(varchar, @FInicio , 126) + 'Z'' and time <= ''' + convert(varchar, @FFinal , 126) + 'Z'' '
					set @Consulta = @Consulta + ' GROUP BY ""IdMotorPLC""'
	
					SET @url = 'http://' + @IpServidor  + ':8086/query?'




				SET @authHeader = 'BASIC 0123456789ABCDEF0123456789ABCDEF';
				SET @contentType = 'application/x-www-form-urlencoded';

				-- Open the connection.
				EXEC @ret = sp_OACreate 'MSXML2.ServerXMLHTTP', @token OUT;
				IF @ret <> 0 RAISERROR('Unable to open HTTP connection.', 10, 1);
				--IF @ret <> 0 return 0;

				-- Send the request.
				EXEC @ret = sp_OAMethod @token, 'open', NULL, 'POST', @url, 'false';
				EXEC @ret = sp_OAMethod @token, 'setRequestHeader', NULL, 'Authentication', @authHeader;
				EXEC @ret = sp_OAMethod @token, 'setRequestHeader', NULL, 'Content-type', @contentType;
				EXEC @ret = sp_OAMethod @token, 'send', NULL, @Consulta;


				INSERT @xmltable  ( yourXML ) EXEC @ret = sp_OAGetProperty @token, 'responseText'-- , @Response OUT 

				-- Close the connection.
				EXEC @ret = sp_OADestroy @token;
				IF @ret <> 0 RAISERROR('Unable to close HTTP connection.', 10, 1);
				--IF @ret <> 0 return 0;

				select @XmlResponse=yourXML   from @xmltable 


				SELECT CAST(JSON_Value (p.value, '$[1]') as numeric (12,3)) as ValorMaximetro
					FROM OPENJSON (@XmlResponse, 'lax $.results[0].series') as c
						cross APPLY OPENJSON (c.value, '$.values') as p;
	


				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[ConsumoKWMotores] 
					-- Add the parameters for the stored procedure here
					@FechaInicio datetime 
					, @FechaFin datetime
					, @NumMuestras int
					, @ListaMotores nvarchar(max)
					, @IpServidor as nvarchar(20)
					, @Sumado as bit =0
					--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
					--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;


					declare @xmltable table ( yourXML nvarchar(MAX) );
	
					declare @datos table ( 
					IdMotor nvarchar(5)
					, Fecha  datetime
					, KW decimal(15,3)
					, MaxKW decimal(15,3)
					, MinKW decimal(15,3)
					, KWEfectiva decimal(15,3)
					, MaxKWEfectiva decimal(15,3)
					, MinKWEfectiva decimal(15,3)
					, Turno nvarchar(50)
				)





				DECLARE @authHeader NVARCHAR(64);
				DECLARE @contentType NVARCHAR(64);
				DECLARE @postData NVARCHAR(MAX);
				DECLARE @responseText NVARCHAR(MAX);
				DECLARE @responseText2 VARBINARY(MAX);
				--DECLARE @responseText ntext;
				DECLARE @responseXML xml;
				DECLARE @ret INT;
				DECLARE @status NVARCHAR(32);
				DECLARE @statusText NVARCHAR(32);
				DECLARE @token INT;
				DECLARE @url NVARCHAR(256);
				Declare @XmlResponse as nvarchar(MAX);


				DECLARE @i int
				declare @motores table (nombre nvarchar(50))
				declare @filtromotores as nvarchar(max) = '';
				declare @motoractual as nvarchar(50);

				set @FechaInicio = DATEADD(mi, -1 * DATEDIFF(mi, GETUTCDATE(), GETDATE()), @FechaInicio ) ;
				set @FechaFin = DATEADD(mi, -1 * DATEDIFF(mi, GETUTCDATE(), GETDATE()), @FechaFin ) ;

				insert into @motores SELECT value FROM STRING_SPLIT(@ListaMotores, ',') WHERE RTRIM(value)<>''

				DECLARE cmotores CURSOR FOR  select nombre from  @motores ;
					OPEN cmotores  
					FETCH NEXT FROM cmotores   INTO @motoractual
					WHILE @@FETCH_STATUS = 0  
						BEGIN  
								if (@filtromotores ='')
									begin
									set @filtromotores = '(""IdMotorPLC"" = ' + '''' + @motoractual + '''' ;
									end
								else
									begin
									set @filtromotores = @filtromotores + ' or ""IdMotorPLC"" = ' + '''' + @motoractual + '''' ;
									end	

							FETCH NEXT FROM cmotores   INTO @motoractual
						END   
					CLOSE cmotores;  
					DEALLOCATE cmotores;  

				--filtro de fechas
				declare @tiempototal as int
				declare @particionessegundos as int

				if @NumMuestras > 500 
				begin
					return 'Error, máximo número de muestras 200'
				end


				if (@FechaInicio >= @FechaFin )
					begin
						return 'Error, fecha fin anterior a fecha inicio.'
					end

				set @tiempototal = DATEDIFF(SECOND , @FechaInicio , @FechaFin )
				set @particionessegundos = @tiempototal / @NumMuestras ;




				--filtro de muestras
				/*
				**************************************************************************************************
				Según la fecha inicio ... habrá que consultar a una tabla u otra ...
				Por defecto, 2 semanas la normal, hasta 26 semanas la semestral y resto la anual.
				Más adelante, las semanas de cada uno debería ir por la tabla de opciones y asi sea configurable esta parte.

				*/	

				declare @Tabla int; -- 0: la semanal, 1: la semestral, 2: la anual
				declare @diffsemanas int;
				set @diffsemanas = (DATEDIFF (week, @FechaInicio, getdate()));


				select @Tabla = case 
					when (@particionessegundos<10 and @diffsemanas <= 2) Or @NumMuestras =1 then 0
					when @particionessegundos<60 and @diffsemanas <= 26 then 1
					else 2
				end 

				-- *************************
	


				SET @authHeader = 'BASIC 0123456789ABCDEF0123456789ABCDEF';
				SET @contentType = 'application/x-www-form-urlencoded';


				if @Sumado =0 
				begin
					if @Tabla = 0 
						SET @postData = 'db=statsVoltec&q=SELECT median(""PotenciaTotal""), MAX(""PotenciaTotal""), MIN(""PotenciaTotal""), median(""PotenciaEfectiva""), MAX(""PotenciaEfectiva""), MIN(""PotenciaEfectiva""), median(""PotenciaReactiva""), MAX(""PotenciaReactiva""), MIN(""PotenciaReactiva"") FROM ""Motores"" WHERE ' 
					else if @Tabla =1 
						SET @postData = 'db=statsVoltec&q=SELECT median(""PotenciaTotal""), MAX(""MaxPotenciaTotal""), MIN(""MinPotenciaTotal""), median(""PotenciaEfectiva""), MAX(""MaxPotenciaEfectiva""), MIN(""MinPotenciaEfectiva""), median(""PotenciaReactiva""), MAX(""PotenciaReactiva""), MIN(""PotenciaReactiva"") FROM ""Semestral"".""Motores"" WHERE ' 
					else
						SET @postData = 'db=statsVoltec&q=SELECT median(""PotenciaTotal""), MAX(""MaxPotenciaTotal""), MIN(""MinPotenciaTotal""), median(""PotenciaEfectiva""), MAX(""MaxPotenciaEfectiva""), MIN(""MinPotenciaEfectiva""), median(""PotenciaReactiva""), MAX(""PotenciaReactiva""), MIN(""PotenciaReactiva"") FROM ""Anual"".""Motores"" WHERE ' 
				end
				else
				begin
					if @Tabla = 0 
						begin
							Set @postData ='db=statsVoltec&q=select sum(PotenciaTotal) as PotenciaTotal, sum(MaxPotenciaTotal) as MaxPotenciaTotal, sum(MinPotenciaTotal) as MinPotenciaTotal,  ';
							Set @postData = @postData + 'sum(PotenciaEfectiva) as PotenciaEfectiva, sum(MaxPotenciaEfectiva) as MaxPotenciaEfectiva, sum(MinPotenciaEfectiva) as MinPotenciaEfectiva ';
							Set @postData = @postData + 'sum(PotenciaReactiva) as PotenciaReactiva, sum(MaxPotenciaReactiva) as MaxPotenciaReactiva, sum(MinPotenciaReactiva) as MinPotenciaReactiva from ';
							Set @postData = @postData + '(SELECT median(""PotenciaTotal"") as PotenciaTotal, MAX(""PotenciaTotal"") as MaxPotenciaTotal, MIN(""PotenciaTotal"") as MinPotenciaTotal, median(""PotenciaEfectiva"") as PotenciaEfectiva, MAX(""PotenciaEfectiva"") as MaxPotenciaEfectiva, MIN(""PotenciaEfectiva"") as MinPotenciaEfectiva, median(""PotenciaReactiva"") as PotenciaReactiva, MAX(""PotenciaReactiva"") as MaxPotenciaReactiva, MIN(""PotenciaReactiva"") as MinPotenciaReactiva FROM ""Motores"" WHERE ' 
						end 
					else if @Tabla =1 
						begin
							Set @postData ='db=statsVoltec&q=select sum(PotenciaTotal) as PotenciaTotal, sum(MaxPotenciaTotal) as MaxPotenciaTotal, sum(MinPotenciaTotal) as MinPotenciaTotal,  ';
							Set @postData = @postData + 'sum(PotenciaEfectiva) as PotenciaEfectiva, sum(MaxPotenciaEfectiva) as MaxPotenciaEfectiva, sum(MinPotenciaEfectiva) as MinPotenciaEfectiva ';
							Set @postData = @postData + 'sum(PotenciaReactiva) as PotenciaReactiva, sum(MaxPotenciaReactiva) as MaxPotenciaReactiva, sum(MinPotenciaReactiva) as MinPotenciaReactiva from ';
							Set @postData = @postData + '(SELECT median(""PotenciaTotal"") as PotenciaTotal, MAX(""MaxPotenciaTotal"") as MaxPotenciaTotal, MIN(""MinPotenciaTotal"") as MinPotenciaTotal, median(""PotenciaEfectiva"") as PotenciaEfectiva, MAX(""MaxPotenciaEfectiva"") as MaxPotenciaEfectiva, MIN(""MinPotenciaEfectiva"") as MinPotenciaEfectiva, median(""PotenciaReactiva"") as PotenciaReactiva, MAX(""MaxPotenciaReactiva"") as MaxPotenciaReactiva, MIN(""MinPotenciaReactiva"") as MinPotenciaReactiva FROM ""Semestral"".""Motores"" WHERE ' 
						end
					else
						begin
							Set @postData ='db=statsVoltec&q=select sum(PotenciaTotal) as PotenciaTotal, sum(MaxPotenciaTotal) as MaxPotenciaTotal, sum(MinPotenciaTotal) as MinPotenciaTotal,  ';
							Set @postData = @postData + 'sum(PotenciaEfectiva) as PotenciaEfectiva, sum(MaxPotenciaEfectiva) as MaxPotenciaEfectiva, sum(MinPotenciaEfectiva) as MinPotenciaEfectiva ';
							Set @postData = @postData + 'sum(PotenciaReactiva) as PotenciaReactiva, sum(MaxPotenciaReactiva) as MaxPotenciaReactiva, sum(MinPotenciaReactiva) as MinPotenciaReactiva from ';
							Set @postData = @postData + '(SELECT median(""PotenciaTotal"") as PotenciaTotal, MAX(""MaxPotenciaTotal"") as MaxPotenciaTotal, MIN(""MinPotenciaTotal"") as MinPotenciaTotal, median(""PotenciaEfectiva"") as PotenciaEfectiva, MAX(""MaxPotenciaEfectiva"") as MaxPotenciaEfectiva, MIN(""MinPotenciaEfectiva"") as MinPotenciaEfectiva, median(""PotenciaReactiva"") as PotenciaReactiva, MAX(""MaxPotenciaReactiva"") as MaxPotenciaReactiva, MIN(""MinPotenciaReactiva"") as MinPotenciaReactiva FROM ""Anual"".""Motores"" WHERE ' 
						end
				end

		
				if (@filtromotores <>'')
					begin
						set @filtromotores = @filtromotores + ')';
						set @postData = @postData + @filtromotores + ' and ';
					end
				if @NumMuestras > 1
					if @Sumado =0 
						set @postdata = @postdata + 'time >= ''' + convert(varchar, @FechaInicio , 126) + 'Z'' and time <= ''' + convert(varchar, @FechaFin , 126) + 'Z'' GROUP BY time(' + cast(@particionessegundos as nvarchar(20)) + 's), ""IdMotorPLC""'
					else
						set @postdata = @postdata + 'time >= ''' + convert(varchar, @FechaInicio , 126) + 'Z'' and time <= ''' + convert(varchar, @FechaFin , 126) + 'Z'' GROUP BY ""IdMotorPLC"") 
						where time >= ''' + convert(varchar, @FechaInicio , 126) + 'Z'' and time <= ''' + convert(varchar, @FechaFin , 126) + 'Z''  GROUP BY time(' + cast(@particionessegundos as nvarchar(20)) + 's)'

	
				else
					if @Sumado =0 
						set @postdata = @postdata + 'time >= ''' + convert(varchar, @FechaInicio , 126) + 'Z'' and time <= ''' + convert(varchar, @FechaFin , 126) + 'Z'' GROUP BY ""IdMotorPLC""'
					else
						set @postdata = @postdata + 'time >= ''' + convert(varchar, @FechaInicio , 126) + 'Z'' and time <= ''' + convert(varchar, @FechaFin , 126) + 'Z'') group by  time(' + cast(@particionessegundos as nvarchar(20)) + 's) GROUP BY ""IdMotorPLC""'


				--=~ /aa|bb/
				--SET @url = 'http://192.168.200.13:8086/query?'
				SET @url = 'http://' + @IpServidor  + ':8086/query?'

				-- Open the connection.
				EXEC @ret = sp_OACreate 'MSXML2.ServerXMLHTTP', @token OUT;
				IF @ret <> 0 RAISERROR('Unable to open HTTP connection.', 10, 1);

				-- Send the request.
				EXEC @ret = sp_OAMethod @token, 'open', NULL, 'POST', @url, 'false';
				EXEC @ret = sp_OAMethod @token, 'setRequestHeader', NULL, 'Authentication', @authHeader;
				EXEC @ret = sp_OAMethod @token, 'setRequestHeader', NULL, 'Content-type', @contentType;
				EXEC @ret = sp_OAMethod @token, 'send', NULL, @postData;


				INSERT @xmltable  ( yourXML ) EXEC @ret = sp_OAGetProperty @token, 'responseText'--, @Response OUT 

				-- Close the connection.
				EXEC @ret = sp_OADestroy @token;
				IF @ret <> 0 RAISERROR('Unable to close HTTP connection.', 10, 1);


				-- Show the response.
				--PRINT 'Status: ' + @status + ' (' + @statusText + ')';
				--PRINT 'Response text: ' + @responseText;

				select @XmlResponse=yourXML   from @xmltable 



				if @Sumado =0
					SELECT
						CAST(JSON_Value (c.value, '$.tags.IdMotorPLC') as int) as IdMotor,
						m.TAG as Tag,
						DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), JSON_Value (p.value, '$[0]') )   as Fecha ,
						CAST(JSON_Value (p.value, '$[1]') as numeric (12,3)) as PotenciaTotal,
						CAST(JSON_Value (p.value, '$[2]') as numeric (12,3)) as MaxPotenciaTotal,
						CAST(JSON_Value (p.value, '$[3]') as numeric (12,3)) as MinPotenciaTotal,
						CAST(JSON_Value (p.value, '$[4]') as numeric (12,3)) as PotenciaEfectiva,
						CAST(JSON_Value (p.value, '$[5]') as numeric (12,3)) as MaxPotenciaEfectiva,
						CAST(JSON_Value (p.value, '$[6]') as numeric (12,3)) as MinPotenciaEfectiva,
						CAST(JSON_Value (p.value, '$[7]') as numeric (12,3)) as PotenciaReactiva,
						CAST(JSON_Value (p.value, '$[8]') as numeric (12,3)) as MaxPotenciaReactiva,
						CAST(JSON_Value (p.value, '$[9]') as numeric (12,3)) as MinPotenciaReactiva,
						dbo.VerTurno(JSON_Value (p.value, '$[0]')) as Turno
					FROM OPENJSON (@XmlResponse, 'lax $.results[0].series') as c
						cross APPLY OPENJSON (c.value, '$.values') as p
						left outer join Motores as m on JSON_Value (c.value, '$.tags.IdMotorPLC') = m.idPLC 
					order by Fecha, IdMotor;
				else
					SELECT
						0 as IdMotor,
						'' as Tag,
						DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), JSON_Value (p.value, '$[0]') )   as Fecha ,
						CAST(JSON_Value (p.value, '$[1]') as numeric (12,3)) as PotenciaTotal,
						CAST(JSON_Value (p.value, '$[2]') as numeric (12,3)) as MaxPotenciaTotal,
						CAST(JSON_Value (p.value, '$[3]') as numeric (12,3)) as MinPotenciaTotal,
						CAST(JSON_Value (p.value, '$[4]') as numeric (12,3)) as PotenciaEfectiva,
						CAST(JSON_Value (p.value, '$[5]') as numeric (12,3)) as MaxPotenciaEfectiva,
						CAST(JSON_Value (p.value, '$[6]') as numeric (12,3)) as MinPotenciaEfectiva,
						CAST(JSON_Value (p.value, '$[7]') as numeric (12,3)) as PotenciaReactiva,
						CAST(JSON_Value (p.value, '$[8]') as numeric (12,3)) as MaxPotenciaReactiva,
						CAST(JSON_Value (p.value, '$[9]') as numeric (12,3)) as MinPotenciaReactiva,
						dbo.VerTurno(JSON_Value (p.value, '$[0]')) as Turno
					FROM OPENJSON (@XmlResponse, 'lax $.results[0].series') as c
						cross APPLY OPENJSON (c.value, '$.values') as p
					order by Fecha;


				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[DashProduccion] 
					@finicio as datetime,
					@ffinal as datetime
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
	

					select * from DashOrdenes where Fecha >= @finicio  and Fecha<= @ffinal 
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[DashProduccionUlt7Dias] 
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					declare @fecha as date 
					set @fecha = DATEadd (day, -7, getdate())

					select * from DashOrdenes where Fecha > @fecha
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[EnergiaRellenoAlarmasSobreConsumo] 
					-- Add the parameters for the stored procedure here
					@Inicio date = '01-01-2000',
					@Fin date = '01-01-2000',
					@MaxMotor int =10
				AS
				BEGIN
	
					SET NOCOUNT ON;

					if @Inicio = '01-01-2000'
					begin
						set @Inicio = DATEADD ( month, -1, getdate())
						set @Fin = DATEADD ( week, 1, getdate())
					end
	 
					declare @Fecha as datetime 
					declare @tiempoExtra as int
					declare @aleatorio as int
					declare @duracion as int
					declare @idmotor as int
					declare @tipoerror as int
					declare @tipoalarma as int
					declare @respuesta as int
					declare @finAlarma as datetime



					select @respuesta =id from NetAlarmasRespuestas where IdPlc =8

					set @Fecha = @Inicio 

					while @Fecha < @Fin
					begin
						set @aleatorio = RAND() * 100
						if @aleatorio >80 and datepart(hour,@Fecha) <22 and datepart(hour,@Fecha) > 06
						begin
							--Si entramos aquí.. hay alarma...
							set @duracion = 40 + (RAND() * 300) --en segundos...
							set @finAlarma = DATEADD( second, @duracion, @Fecha)

							set @idmotor = RAND() * @MaxMotor 

							--con aleatorio, decidimos si es consumo alto o excesivo... (80 para alto, 20 para excesivo)
							set @aleatorio = RAND() * 100
							if @aleatorio <80
							begin
								set @tipoerror =800
								select @tipoalarma=id from NetAlarmasTipos where IdAlarmaPLC =800
							end
							else
							begin
								set @tipoerror = 810
								select @tipoalarma=id from NetAlarmasTipos where IdAlarmaPLC =810
							end

			

							insert into NetAlarmas (Interno , TipoInterno , Respondido , Enviada , IdModulo, idMotor , IdPlc , RequiereRespuesta, MostrarAUsuario , FechaError , IdError , txtError , FechaRecibido , Respuesta , RespFecha )
							values (1, @tipoerror , 1, 1, 12, @idmotor , @tipoalarma, 1, 1, @Fecha , @tipoalarma , '' , @Fecha, @respuesta, @finAlarma )

						end


						--Proxima revisión de posible alarma... 
						set @tiempoExtra = RAND() * 15
						set @Fecha = DATEADD(minute, 10 + @tiempoExtra , @fecha)
					end



	
	
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[GenerarIdMuestraEntrada]
					-- Add the parameters for the stored procedure here
					@IdLinea int
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					if (@IdLinea is null or @IdLinea =0 )
					begin
						return
					end


					Declare @idMuestra int;



					select @idMuestra = IdMuestra from EntradasLineas where id = @IdLinea ;

					if (@idMuestra is not null and @idMuestra >0)
					begin
						return  --Ya tiene idmuestra
					end

					--Buscamos el último
					select top 1 @idMuestra = IdMuestra from EntradasLineas where IdMuestra is not null order by IdMuestra desc ;

					if (@idMuestra is null or @idMuestra =0)
					begin
						set @idMuestra =0;
					end

					set @idMuestra =@idMuestra +1;

					update EntradasLineas set IdMuestra =@idMuestra where id=@IdLinea ;






				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[GenerarKWEnOrdenesTeoricos] 
					-- Add the parameters for the stored procedure here
					@TotalKWTonelada decimal
					, @PorcConsumo decimal
					, @PorcProducido decimal
					, @PorcMolino decimal
					, @PorcGranuladora decimal
					, @PorcProduccion decimal
					, @PorcTuneles decimal
					, @PorcEntradas decimal
					, @MargenAleatorio decimal
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

	
				/*
				set @TotalKWTonelada =60
				set @PorcConsumo =30
				set @PorcProducido =70

				set @PorcMolino =30
				set @PorcGranuladora =50
				set @PorcProduccion =15
				set @PorcTuneles =2
				set @PorcEntradas =5
				set @MargenAleatorio =15
				*/



				declare @idItem int;
				declare @idOrden int;
				declare @idModulo int;
				declare @Cantidad decimal(18,3);

				declare @KWaGastar decimal (18,3);
				declare @aleatorio decimal(5,2)
				declare @tipomodulo int

				DECLARE cur CURSOR FOR   
					SELECT Id  , Orden , Cantidad 
					FROM Resultados 
					ORDER BY Id asc;  

				OPEN cur  

				FETCH NEXT FROM cur INTO @idItem, @idOrden, @Cantidad

				WHILE @@FETCH_STATUS = 0  
					BEGIN  
						--BUscamos tipo de módulo
		
						select @tipomodulo = M.TipoModulo
							from Ordenes as O
							inner join Modulos as M on M.Id = O.Modulo 
							where O.id =@idOrden ;

				set @aleatorio =1 + (rand() * @MargenAleatorio /100)

				select @KWaGastar=
					case 
						--entradas
						when @idModulo in (0,1,2,3,4,6,100) then ((@Cantidad * @TotalKWTonelada / 1000) / 100) * @PorcEntradas * @aleatorio 
						--Molinos
						when @idModulo =7 then ((@Cantidad * @TotalKWTonelada / 1000) / 100) * @PorcMolino * @aleatorio 
						--granuladoras
						when @idModulo =140 then ((@Cantidad * @TotalKWTonelada / 1000) / 100) * @PorcGranuladora  * @aleatorio 
						--Produccion
						when @idModulo =120 then ((@Cantidad * @TotalKWTonelada / 1000) / 100) * @PorcGranuladora  * @aleatorio 
						--salidas tuneles
						when @idModulo =5 then ((@Cantidad * @TotalKWTonelada / 1000) / 100) * @PorcTuneles   * @aleatorio
						else ((@Cantidad * @TotalKWTonelada / 1000) / 100) * 1   * @aleatorio
					end

					set @aleatorio = 1+ (rand() * @MargenAleatorio /100)

					update Resultados set KwhEfectivo = (@KWaGastar /100 * @PorcConsumo ), KWhTotal = (@KWaGastar /100 * @PorcConsumo )* @aleatorio 
						where id = @idItem 


						FETCH NEXT FROM cur INTO @idItem, @idOrden, @Cantidad
					END   

				CLOSE cur;  
				DEALLOCATE cur;  



				DECLARE cur2 CURSOR FOR   
					SELECT Id  , Orden , Cantidad 
					FROM Desgloses  
					ORDER BY Id asc;  

				OPEN cur2  

				FETCH NEXT FROM cur2 INTO @idItem, @idOrden, @Cantidad

				WHILE @@FETCH_STATUS = 0  
					BEGIN  
						--BUscamos tipo de módulo
		
						select @tipomodulo = M.TipoModulo
							from Ordenes as O
							inner join Modulos as M on M.Id = O.Modulo 
							where O.id =@idOrden ;

				set @aleatorio =1 + (rand() * @MargenAleatorio /100)

				select @KWaGastar=
					case 
						--entradas
						when @idModulo in (0,1,2,3,4,6,100) then ((@Cantidad * @TotalKWTonelada / 1000) / 100) * @PorcEntradas * @aleatorio 
						--Molinos
						when @idModulo =7 then ((@Cantidad * @TotalKWTonelada / 1000) / 100) * @PorcMolino * @aleatorio 
						--granuladoras
						when @idModulo =140 then ((@Cantidad * @TotalKWTonelada / 1000) / 100) * @PorcGranuladora  * @aleatorio 
						--Produccion
						when @idModulo =120 then ((@Cantidad * @TotalKWTonelada / 1000) / 100) * @PorcGranuladora  * @aleatorio 
						--salidas tuneles
						when @idModulo =5 then ((@Cantidad * @TotalKWTonelada / 1000) / 100) * @PorcTuneles   * @aleatorio
						else ((@Cantidad * @TotalKWTonelada / 1000) / 100) * 1   * @aleatorio
					end

					set @aleatorio = 1+ (rand() * @MargenAleatorio /100)

					update Desgloses  set KwhEfectivo = (@KWaGastar /100 * @PorcProducido  ), KWhTotal = (@KWaGastar /100 * @PorcProducido )* @aleatorio 
						where id = @idItem 


						FETCH NEXT FROM cur2 INTO @idItem, @idOrden, @Cantidad
					END   

				CLOSE cur2;  
				DEALLOCATE cur2;  
	
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[GetNewLote]
				@lote int OUTPUT 
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

						-- Declare the return variable here
					--DECLARE @lote int;
					Declare @fecha date = null;
					declare @campo nvarchar(50);
					set @campo ='Lotes';

					set @lote=-1;
	
					 select @lote=Contador, @fecha = Fecha  from Contadores where Nombre=@campo 

					 if @fecha is null
						begin
							insert into Contadores(Nombre,Contador,Fecha,Visible) values(@campo, 0, cast(GETDATE() as date), 1);
							set @lote=0;
						end
					 else
						begin
							if @fecha = cast(GETDATE() as date) 
								begin
									update Contadores set Contador=@Lote+1 where Nombre=@campo ;
									set @lote=@lote+1;
								end	
							else
								begin
									update Contadores set Contador=0, Fecha =getdate() where Nombre=@campo ;
									set @lote=0;
								end
						end



					-- Return the result of the function
					--select @lote;
					--return
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[GrabarReadPLC] 
					-- Add the parameters for the stored procedure here
					@nombre nvarchar(50),
					@posicion int,
					@valor nvarchar(100)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;


					if exists(Select 1 From PLCRead  Where Nombre  = @nombre and posicion=@posicion )
					  BEGIN
							update PLCRead set Valor=@valor, UltimaLectura=GETDATE () where Nombre=@nombre and posicion=@posicion 
					   END
					ELSE
					  BEGIN
							insert into PLCRead (Nombre, posicion, Valor, UltimaLectura) values (@nombre, @posicion,  @valor, GETDATE ())
					  END
	
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[LimpiezaBaseDatos] 
					@password nvarchar(20) = N''
				AS
				BEGIN
					DECLARE @return_value int = 0

					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					IF @password = '1_voltecsl'
					BEGIN
						SET @return_value = 0

						--DesActivamos los constaints
						EXEC sp_MSforeachtable @command1=""ALTER TABLE ? NOCHECK CONSTRAINT ALL""

						--Iniciamos el borrado de datos
						delete from Aditivos;
						delete from Afecciones;
						delete from Alarmas;
						delete from Analisis;
						delete from Backups;
						--delete from Basculas;
						delete from BufferConsumidos;
						delete from BufferERPCabOrdenes;
						delete from BufferERPConsumidos ;
						delete from BufferERPLinOrdenes;
						delete from BufferERPProducidos;
						delete from BufferERPStocks;
						delete from BufferProducidos;
						delete from BufferERPFormulaProductosFinales ;
						delete from BufferERPFormulas ;

						delete from CertificadoDesinfeccion ;
		

						delete from CabOrdenes;
						delete from Choferes;
						delete from Clientes;
						delete from CompActivosLista;
						delete from Componentes;
						delete from ComponentesActivos;
						delete from Compras;
						delete from Contadores;
						delete from Contratos;
						delete from ControlesNIR;
						delete from ControlesNIRProductos;
						--Departamentos
						delete from Desgloses;
						--Destinos
						--DestinosMedidores
						delete from Disposiciones;
						delete from Documentos;
						delete from Domicilios;
						delete from Dominios;
						delete from Dosificaciones;
						delete from Empresas;
						delete from EmpresasTransporte;
						delete from Entradas;
						delete from EntradasContratos;
						delete from EntradasLineas;
						delete from EntradasLineasResultadosNIR;
						delete from EntradasLotes;
						delete from Etiquetas;
						delete from Eventos;
						delete from EventosDetalle;
						delete from Existencias;
						--Familias
						--FamiliasMedidor
						--Formatos
						delete from FormulaProdModulo;
						delete from Formularios;
						delete from Formulas;
						delete from GruposIncompatibilidades;
						delete from GruposIncompatibilidadesLineas;
						delete from Incompatibilidades;
						--Indicadores
						--InformesLib
						--InformesLibCategorias
						delete from Inventarios;
						--delete from Lectores
						delete from LineasCompra;
						delete from LogMovimientosStocks;
						delete from Lotes;
						delete from Maquinas;
						delete from Medicaciones;
						delete from MedicacionesIngredientes;
						--Medidores
						--Modulos
						--ModulosAscendentes
						--ModulosIncompatibilidades
						delete from MultiDosificaciones;
						delete from NetAlarmas;
						--NetAlarmasRespuestas
						--NetAlarmasTipos
						--NetAlarmasTiposRespuestas
						--OpcConfig
						--Opciones
						--OperAcciones
						--OperCabPlantillas
						--OperMotores
						--OperMotoresModulos
						--OperPlantillas
						delete from Ordenes;
						delete from OrdenesRelacion;
						--Origenes
						--Paises
						--Pistolas
	
						update Ubicaciones set Producto =null;
						update OperPlantillas set IdProducto =null;
						delete from Productos;
						delete from ProductosGruposIncompatibilidades;
						delete from Proveedores;
						--Provincias
						--Puntos
						delete from PuntosDescarga;
						delete from Regularizaciones;
						delete from Resultados;
						delete from SalidasLiniasMedicaciones;
						delete from SalidasLinias;
						delete from SalidasLiniasMuestras;
						delete from SalidasLiniasLote;
						delete from Salidas;
						delete from SalidasViajes;
						delete from StocksReserva;
						--Sesiones
						--SesionesModulo
						--SesionesSeccion
						delete from StatusDisks;
						delete from Stocks;
						--Tags
						delete from Tarifas;
						delete from Tarjetas;
						--TiposIva
						--Ubicaciones
						--UbicacionesAsociadas
						--UbisMedsAfino
						--Unidades
						--Usuarios
						delete from UsuariosLogs;
						--UsuariosRoles
						--UsuariosRolesInformes
						--UsuariosRolesModulos
						delete from Valores;
						delete from Variables;
						delete from Vehiculos;

						delete from LotesMezclados ;
						delete from OrdenesDatosExtra ;
						delete from FormulasDatosExtra ;

						delete from LineaVentaLineaSalida ;
						delete from VentasLiniasMedicaciones ;
						delete from VentasLinias;
						delete from Ventas;
		
						delete from versiondatosextra;
						delete from Versiones;
						delete from VersionTPrevisto;
	

						delete from RecetasLineas ;
						delete from Recetas;
						delete from Veterinarios ;
		
						--update modulos set idPlantillaBase = null, idPlantillaLimpieza =null;
						--delete from OperPlantillas ;
						--delete from OperCabPlantillas ;


						--update tags set idLecturaTag = null
						delete from TagsLecturas 
						--delete from Pistolas ;
						--Dejamos los contadores a cero...
						--exec sp_MSforeachtable @command1 = 'DBCC CHECKIDENT(''?'', RESEED, 0)';
						EXEC @return_value = [dbo].[spReseedUserTables] @password = @password

						--Activamos los constaints
						EXEC sp_msforeachtable ""ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all"";
					END
					ELSE
					BEGIN
						SET @return_value = 1
						PRINT 'Incorrect password'
						SELECT 'Incorrect password';
					END		

					return @return_value
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[LimpiezaBuffers] 
					-- Add the parameters for the stored procedure here
					@fecha datetime
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					declare @fechalimite datetime
					set @fechalimite = DATEADD (week, -4, getdate());



					WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferConsumidos
				where Tratado=1 and FechaTratado < @fecha 
				)
				DELETE FROM CTE;

					WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferConsumidos
				where FechaRecibido  < @fechalimite
				)
				DELETE FROM CTE;


				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferProducidos
				where Tratado=1 and FechaTratado < @fecha
				)
				DELETE FROM CTE;


				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferProducidos
				where  FechaRecibido  < @fechalimite
				)
				DELETE FROM CTE;


				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPCabOrdenes
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;



				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPClienteDomicilioPuntoDescarga
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;



				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPClientes
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;


				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPClientesDomicilios
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;


				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPComponentes
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;



				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPEntradasLineasLote as bell
				where bell.Tratado=1 and (bell.FTratado < @fecha or bell.FechaInsercion is null or (bell.FTratado is null and bell.FechaInsercion < @fechalimite))
				)
				DELETE FROM CTE;


				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPEntradasLineas as bel
				where bel.Tratado=1 and (bel.FTratado < @fecha or bel.FechaInsercion is null or (bel.FTratado is null and bel.FechaInsercion < @fechalimite))
				and not exists (select top 1 id from BufferERPEntradasLineasLote as bellot where bellot.IdLineaEntrada = bel.id)
				)
				DELETE FROM CTE;


				WITH CTE AS
				(
				SELECT TOP 10000 be.*
				FROM BufferERPEntradas as be
				where be.Tratado=1 and (be.FTratado < @fecha or be.FechaInsercion is null or (be.FTratado is null and be.FechaInsercion < @fechalimite  ))
				and not exists (select top 1 id from BufferERPEntradasLineas as bel where bel.idBufferEntrada = be.id)
				)
				DELETE FROM CTE;



				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPFormulaProductosFinales
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;




				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPFormulas
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;



				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPLinOrdenes
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;


				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPConsumidos
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;

				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPConsumidos
				where  FechaInicio < @fechalimite 
				)
				DELETE FROM CTE;




				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPProducidos
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;


				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPProducidos
				where FechaOrden  < @fechalimite 
				)
				DELETE FROM CTE;



				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPProductos
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;



				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPProveedores
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;


				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPSalidasLinMedicamentos
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;


				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPSalidas
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;

				WITH CTE AS
				(
				select * from buffererpsalidasliniaslote
				where exists (SELECT TOP 10000 *
								FROM BufferERPSalidasLinias
								where id = idLineaSalida 
								  and (Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  )))
							)
				)
				DELETE FROM CTE;

				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPSalidasLinias
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;

				--Esborrem viatges
				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPSalidasViajes
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				AND id NOT IN (SELECT DISTINCT bs.Id FROM BufferERPSalidasViajes bs, BufferERPSalidasLinias bl WHERE bl.idviajes = bs.id)
				)
				DELETE FROM CTE;







				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPStocks
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;


				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM BufferERPVersiones
				where Tratado=1 and (FTratado < @fecha or FechaInsercion is null or (FTratado is null and FechaInsercion < @fechalimite  ))
				)
				DELETE FROM CTE;


				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM Eventos
				where Fecha <  DateAdd(day, -5,  getdate())
				)
				DELETE FROM CTE;



				WITH CTE AS
				(
				SELECT TOP 10000 *
				FROM TagsLecturas 
				where Tratado=1 and FTratado < @fecha AND id NOT IN (SELECT idLecturaTag FROM Tags)
				)
				DELETE FROM CTE;


				update Stocks set idEntradasLineas = null , idSalidasLineas =null where Fecha < @fecha and Cantidad =0 and Estado =3;

				delete from StocksReserva where Activo =0;

				delete from Stocks where id in (
				select S.id from stocks as S
				left outer join StocksReserva as R on S.id = R.idStock 
				where R.id is null 
					and S.Fecha < @fecha 
					and S.cantidad =0 
					and (S.Estado =3 or S.Estado=2)
					and S.idEntradasLineas is null 
					and S.idSalidasLineas is null);


				delete from UsuariosLogs where Login < @fecha;

				delete from StatusDisks where Fecha  < @fecha;

					/*
				declare @dbname as nvarchar(30) =  DB_NAME();
				DBCC SHRINKDATABASE(@dbname);
				*/

				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[ListaAlarmasConsumoMotores] 
					-- Add the parameters for the stored procedure here
					@TipoRango nvarchar(50)
					, @FechaInicio datetime 
					, @FechaFin datetime
				AS
				BEGIN
	
					SET NOCOUNT ON;

					if @TipoRango <> 'Personalizada' 
					begin 
						set @FechaFin = getdate();
						set @FechaInicio  = dbo.RangoFechaInicio(@TipoRango );
					end

					select *
					from ListaAlarmas
					where MotorId>0 and FechaError >=@FechaInicio and FechaError <=@FechaFin 
 

	
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[SalidasLineasExtended]
				AS
				WITH CTE AS(
					SELECT SL.id
					  , SL.idSalidas
					  , SL.idviajes
					  , SL.idorden
					  , SL.idAlbaran 
						, Alb.Serie AS AlbaranSerie
							, SerieAlbaran.Nombre AS AlbaranSerieNombre
						, Alb.Numero AS AlbaranNumero
						, Alb.Fecha AS AlbaranFecha
					  , SL.idProducto
						, P.Nombre AS ProductoNombre
					  , SL.idFormato
						, Form.Nombre AS FormatoNombre
						, Form.Descripcion AS FormatoDescripcion
					  , SL.idEnvase
						, Enva.Nombre AS EnvaseNombre
					  , SL.idUnidad
						, Uni.Nombre AS UnidadTexto
					  , SL.idDomicilio
						  , Domi.Cliente AS DomicilioIdCliente
							, Cli.Nombre AS DomicilioClienteNombre
						  , Domi.Nombre AS DomicilioNombre
						  , Domi.Referencia AS DomicilioReferencia
						  , Domi.Direccion AS DomicilioDireccion
						  , Domi.Poblacion AS DomicilioPoblacion
						  , Domi.Telefono AS DomicilioTelefono
						  , Domi.CodigoPostal DomicilioCodigoPostal
						  , Domi.Provincia AS DomicilioProvincia
						  , Provincias.Nombre AS DomicilioProvinciaNombre
						  , Domi.Pais AS DomicilioPais
								, Pais.Nombre AS DomicilioPaisNombre
						  , Domi.Inhabilitado
							, dbo.GetTextoParametro('Domicilio', 'Inhabilitado', Domi.Inhabilitado) AS DomicilioInhabilitadoStr
						  , Domi.Descripcion AS DomicilioDescripcion
						  , Domi.Simogan AS DomicilioSIMOGAN
						  , Domi.REGA AS DomicilioREGA
						  , Es.Nombre AS DomicilioEspecie
					  , SL.TipoOrigen
					  , SL.Origen1
						, UbiOrig1.Nombre AS Origen1Nombre
					  , SL.Origen2
						, UbiOrig2.Nombre AS Origen2Nombre
					  , SL.Origen3
						, UbiOrig3.Nombre AS Origen3Nombre
					  , SL.Origen4
						, UbiOrig4.Nombre AS Origen4Nombre
					  , STUFF(
							ISNULL(', ' + UbiOrig1.Nombre, '') + 
							ISNULL(', ' + UbiOrig2.Nombre, '') + 
							ISNULL(', ' + UbiOrig3.Nombre, '') + 
							ISNULL(', ' + UbiOrig4.Nombre, ''),
							1, 2, '') AS OrigenesStr  -- con STUFF quitamos la coma y espacio iniciales
					  , SL.FueraCajon
					  , SL.Cajon1
					  , SL.Cajon2
					  , SL.Cajon3
					  , SL.Cajon4
					  , SL.Cajon5
					  , SL.Cajon6
					  , SL.Cajon7
					  , SL.Cajon8
					  , SL.Cajon9
					  , SL.Cajon10
					  , STUFF(
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Fueracajon', SL.FueraCajon), '') + 
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon1', SL.Cajon1), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon2', SL.Cajon2), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon3', SL.Cajon3), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon4', SL.Cajon4), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon5', SL.Cajon5), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon6', SL.Cajon6), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon7', SL.Cajon7), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon8', SL.Cajon8), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon9', SL.Cajon9), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon10', SL.Cajon10), ''),
							1, 2, '') AS CajonesStr  -- con STUFF quitamos la coma y espacio iniciales
					  , SL.FechaFinCarga
					  , SL.FechaInicioCarga
					  , SL.Bultos
					  , SL.Bruto
					  , SL.Tara
					  , (SL.Bruto - SL.Tara) AS NetoCalculado
					  , SL.PesoNetoManual
					  , COALESCE(PesoNetoManual, (SL.Bruto - SL.Tara)) AS NetoEfectivo  -- El peso neto entrado manualmente tiene prevalencia sobre el calculado
					  , SL.Estado
						, dbo.GetTextoParametro('SalidasLineas', 'Estado', SL.Estado) AS EstadoStr
					  , SL.PrecioUnidad
						, NULL AS IdMonedaPrecioUnidad
						, NULL AS PrecioUnidadMonedaNombre
					  , SL.Cantidad
				--      , SL.LedControlDocumental
				--      , SL.LedAnalisisLaboratorio
				--      , SL.LedAutorizacion
				--      , SL.LedCargaProducto
				--      , SL.LedDevolucionTarjeta
				--      , SL.TransitoActivo
				--      , SL.idmodulo
					  , SL.Fecha
					  , SL.Precio
						, NULL AS IdMonedaPrecio
						, NULL AS PrecioMonedaNombre
					  , SL.PrecioTransporte
						, NULL AS IdMonedaPrecioTransporte
						, NULL AS PrecioTransporteMonedaNombre
				--      , SL.EstadoTarjeta
					  , SL.Observaciones
				--      , SL.Autorizada
					  , SL.idBasculaPesajeBruto
						, BascBruto.Nombre AS BasculaPesajeBrutoStr
					  , SL.idBasculaPesajeNeto
						, BascNeto.Nombre AS BasculaPesajeNetoStr
					  , SL.CampoLibre1
					  , SL.CampoLibre2
				--      , SL.LedViajeAsignado
					  , SL.idPuntoDescarga
						, PD.Nombre AS PuntoDescargaStr
						, PD.Descripcion AS PuntoDescargaDescripcion
						,Ord.Id AS OrdenId
						,Ord.Nombre AS OrdenNombre
						, lot.Nombre AS PrimerLoteNombre

						,STUFF((
						  SELECT DISTINCT ' - ' + lot.Nombre
						  FROM Resultados as Res
						  LEFT OUTER JOIN Lotes AS Lot ON Lot.Id = Res.Lote AND Lot.Producto = Res.Producto
						  WHERE Res.Orden = Ord.Id
						  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 3, '') AS TodosLotesNombre
						,STUFF((
							SELECT DISTINCT ' - ' + pd.Nombre
							FROM SalidasLiniasPuntosDescarga AS slpd 
							LEFT OUTER JOIN PuntosDescarga AS pd ON slpd.idPuntoDescarga = pd.id 
							WHERE idLineaSalida = SL.id
							FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 3, '') AS TodosPuntosDescarga
			
						  ,ISNULL(ROW_NUMBER() OVER(PARTITION BY SL.Id ORDER BY SL.Id ASC), -1) AS RowID 

				  FROM dbo.SalidasLinias AS SL
					LEFT OUTER JOIN SalidasAlbaranes AS Alb ON Alb.Id = SL.idAlbaran 
						LEFT OUTER JOIN Series AS SerieAlbaran ON Alb.Serie = SerieAlbaran.Id
					LEFT OUTER JOIN Productos AS P ON P.Id = SL.idProducto
					LEFT OUTER JOIN Formatos AS Form ON Form.Id = SL.idFormato
					LEFT OUTER JOIN Envases AS Enva ON Enva.Id = SL.idEnvase
					LEFT OUTER JOIN Unidades AS Uni ON Uni.Id = SL.idUnidad
					LEFT OUTER JOIN Domicilios AS Domi ON Domi.Id = SL.idDomicilio
						LEFT OUTER JOIN Clientes AS Cli ON Cli.Id = Domi.Cliente
						LEFT OUTER JOIN Paises AS Pais ON Pais.Id = Domi.Pais
						LEFT OUTER JOIN Provincias AS Provincias ON Provincias.Id = Domi.Provincia
					LEFT OUTER JOIN Especies AS Es ON Domi.Especie = Es.Id
					LEFT OUTER JOIN Ubicaciones AS UbiOrig1 ON UbiOrig1.Id = SL.Origen1
					LEFT OUTER JOIN Ubicaciones AS UbiOrig2 ON UbiOrig2.Id = SL.Origen2
					LEFT OUTER JOIN Ubicaciones AS UbiOrig3 ON UbiOrig3.Id = SL.Origen3
					LEFT OUTER JOIN Ubicaciones AS UbiOrig4 ON UbiOrig4.Id = SL.Origen4
					LEFT OUTER JOIN Basculas AS BascBruto ON BascBruto.Id = SL.idBasculaPesajeBruto
					LEFT OUTER JOIN Basculas AS BascNeto ON BascNeto.Id = SL.idBasculaPesajeNeto
					LEFT OUTER JOIN PuntosDescarga AS PD ON PD.id = SL.idPuntoDescarga
						LEFT OUTER JOIN Ordenes AS Ord ON Ord.LineaSalida = SL.id
						LEFT OUTER JOIN Resultados AS Res ON res.Orden = Ord.id
						LEFT OUTER JOIN Lotes AS lot ON lot.Id = res.Lote)


						SELECT * FROM CTE WHERE RowID = 1
				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[ListaClientesDeUnLote] 
					-- Add the parameters for the stored procedure here
					@idlote int
				AS
				BEGIN
	
					SET NOCOUNT ON;

					select consulta.* , ext.*
				from (
				select 
					ords.LineaSalida as IdLineaSalida
					, res.lote as idLote
					, sum(res.Cantidad ) as cantidad

				from Resultados as res

				inner join Ordenes as ords on ords.Id = res.Orden 


				where ords.LineaSalida >0 and res.Lote = @idlote 

				group by ords.LineaSalida , res.Lote ) as consulta


				left outer join SalidasLineasExtended as ext on ext.id = consulta.IdLineaSalida 
  
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[NuevoContador] 
					-- Add the parameters for the stored procedure here
					@contador int output
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					declare @num int;


					SELECT @num= (Numero + 1)
				FROM Compras as T
				inner join Series as S on S.Estado =1
				WHERE NOT EXISTS( 
					SELECT 1 FROM Compras WHERE (Numero = T.Numero + 1) and Serie = T.Serie ) 
				--AND Numero >= 1000
				AND Numero >= S.ContadorCompras 
				ORDER BY Numero;



	
	
					--devolvemos el nuevo contador.


					set @contador =@num;
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[OEEDesgloses]
					@FechaInicio datetime
					, @FechaFinal datetime
					, @IntervalosSegs int
					, @ListaModulos nvarchar(max)
					, @ListaMedidores nvarchar(max)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;


					declare @LModulos table (id nvarchar(10));
					declare @LMedidores table (id nvarchar(10));

					--Si no funciona el StringSplit ... comprobar compatibilidad de la base de datos sea mínimo a 13 (2016)

					insert into @LModulos SELECT value FROM STRING_SPLIT(@ListaModulos, ',') WHERE RTRIM(value)<>'';
					insert into @LMedidores SELECT value FROM STRING_SPLIT(@ListaMedidores, ',') WHERE RTRIM(value)<>''


					if @ListaModulos='' and @ListaMedidores=''
					begin
						select result.intervalStartTime as IntervaloInicio
							, result.intervalEndTime as IntervaloFinal
							, result.eventDurationInIntervalSeconds as IntervaloDuracionSegs
							, o.Id 
							, o.Cantidad 
							, o.MedidorId 
							, o.DuracionStamp 
							, dbo.CantidadSegunTiempo(o.Cantidad , result.intervalStartTime, result.intervalEndTime, o.Fecha , o.FechaFin )  as IntervaloCantidad
							--, (o.Cantidad /DuracionStamp ) * result.eventDurationInIntervalSeconds as IntervaloCantidad
							--, o.* 
						from (
							select  D.id, D.Fecha , D.DuracionStamp , dateadd(second, D.DuracionStamp , D.Fecha) as FechaFin, D.Cantidad , D.MedidorId , M.Modulo 
								from Desgloses as D
								left outer join Medidores as M on M.Id=D.MedidorId  
								where D.Fecha >= @FechaInicio 
									and dateadd(second, DuracionStamp , D.Fecha) <= @FechaFinal 
							union
							select  D.id, D.Fecha , D.DuracionStamp , dateadd(second, D.DuracionStamp , D.Fecha) as FechaFin, D.Cantidad , D.MedidorId , M.Modulo 
								from Desgloses  as D
								left outer join Medidores as M on M.Id=D.MedidorId  
								where D.Fecha < @FechaInicio 
									and dateadd(second, D.DuracionStamp , D.Fecha) > @FechaInicio 
							union
							select  D.id, D.Fecha , D.DuracionStamp , dateadd(second, D.DuracionStamp , D.Fecha) as FechaFin, D.Cantidad , D.MedidorId , M.Modulo 
								from Desgloses  as D
								left outer join Medidores as M on M.Id=D.MedidorId  
								where D.Fecha < @FechaFinal 
									and dateadd(second, D.DuracionStamp , D.Fecha) > @FechaFinal )  as o


						cross apply dbo.TVF_TimeRange_Split_To_GridSeconds(o.Fecha  , DATEDIFF (second, o.Fecha, o.FechaFin  ),@IntervalosSegs) result
						where o.FechaFin  >= @FechaInicio and o.Fecha <= @FechaFinal 
						order by o.id 

					end
					else
					begin
						select result.intervalStartTime as IntervaloInicio
							, result.intervalEndTime as IntervaloFinal
							, result.eventDurationInIntervalSeconds as IntervaloDuracionSegs
							, o.Id 
							, o.Cantidad 
							, o.MedidorId 
							, o.DuracionStamp 
							, (o.Cantidad /DuracionStamp ) * result.eventDurationInIntervalSeconds as IntervaloCantidad
							--, o.* 
						from (
							select  D.id, D.Fecha , D.DuracionStamp , dateadd(second, D.DuracionStamp , D.Fecha) as FechaFin, D.Cantidad , D.MedidorId , M.Modulo 
								from Desgloses as D
								left outer join Medidores as M on M.Id=D.MedidorId  
								where D.Fecha >= @FechaInicio 
									and dateadd(second, DuracionStamp , D.Fecha) <= @FechaFinal 
							union
							select  D.id, D.Fecha , D.DuracionStamp , dateadd(second, D.DuracionStamp , D.Fecha) as FechaFin, D.Cantidad , D.MedidorId , M.Modulo 
								from Desgloses  as D
								left outer join Medidores as M on M.Id=D.MedidorId  
								where D.Fecha < @FechaInicio 
									and dateadd(second, D.DuracionStamp , D.Fecha) > @FechaInicio 
							union
							select  D.id, D.Fecha , D.DuracionStamp , dateadd(second, D.DuracionStamp , D.Fecha) as FechaFin, D.Cantidad , D.MedidorId , M.Modulo 
								from Desgloses  as D
								left outer join Medidores as M on M.Id=D.MedidorId  
								where D.Fecha < @FechaFinal 
									and dateadd(second, D.DuracionStamp , D.Fecha) > @FechaFinal )  as o


						cross apply dbo.TVF_TimeRange_Split_To_GridSeconds(o.Fecha  , DATEDIFF (second, o.Fecha, o.FechaFin  ),@IntervalosSegs) result
						where o.FechaFin  >= @FechaInicio and o.Fecha <= @FechaFinal and (o.Modulo  in (select id from @LModulos  ) or o.MedidorId  in (select id from @LMedidores ))
						order by o.id 
						end
				end
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[OEEEstadosFechaCompleto]
					@FechaInicio datetime
					, @FechaFinal datetime
					, @IntervalosSegs int
					, @ListaModulos nvarchar(max)
					, @ListaMedidores nvarchar(max)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					--SET NOCOUNT ON;
					--SET FMTONLY OFF

					if (1=0)
					begin
						declare @OEEEstadosFechaCompletoResult table(
						NombreModuloMedidor nvarchar(255)
						, ModuloNombre nvarchar(255)
						, MedidorNombre nvarchar(255)
						, OrdenNombre nvarchar(255)
						, ProductoFinal nvarchar(255)
						, AlarmaDescripcion nvarchar(255)
						, AlarmaFechaInicio datetime
						, EstadoNombre nvarchar(255)
						, IntervaloInicio datetime
						, IntervaloFinal  datetime
						, IntervaloDuracionSegs float
						, id int
						, IdModulo int
						, IdMedidor int
						, Estado int
						, FInicio datetime
						, FFinal datetime
						, VentanaSegs int
						, OperarioId int
						, IdTurno int
						, IdAlarmaActual int
						, IdOrdenActual int
						);
						select * from @OEEEstadosFechaCompletoResult;
					end


					CREATE TABLE #tmpOeeEstadosCompleto(
					IntervaloInicio datetime,
					IntervaloFinal datetime,
					IntervaloDuracionSegs float,
					[id] [int] NULL,
					[IdModulo] [int] NULL,
					[IdMedidor] [int] NULL,
					[Estado] [int] NULL,
					[FInicio] [datetime] NULL,
					[FFinal] [datetime] NULL,
					[VentanaSegs] [int] NULL,
					[OperarioId] [int] NULL,
					[IdTurno] [int] NULL,
					[IdAlarmaActual] [int] NULL,
					[IdOrdenActual] [int] NULL
					)
   
					insert into #tmpOeeEstadosCompleto 
					EXEC	[dbo].[OEEEStadosFechaIntervalos]
						@FechaInicio = @FechaInicio,
						@FechaFinal = @FechaFinal,
						@IntervalosSegs = @IntervalosSegs,
						@ListaModulos = @ListaModulos,
						@ListaMedidores = @ListaMedidores



					Select 
						isnull(M.Nombre, Meds.Nombre ) as NombreModuloMedidor
						, M.Nombre as ModuloNombre
						, Meds.Nombre as MedidorNombre
						, ords.Nombre as OrdenNombre
						, prod.Nombre as ProductoFinal
						, alt.TextoError as AlarmaDescripcion
						, al.FechaError as AlarmaFechaInicio
						, oeetipo.Nombre as EstadoNombre
						, base.IntervaloInicio 
						, base.IntervaloFinal 
						, base.IntervaloDuracionSegs 
						, base.id 
						, base.IdModulo 
						, base.IdMedidor 
						, base.Estado 
						, base.FInicio 
						, base.FFinal 
						, base.VentanaSegs 
						, base.OperarioId 
						, base.IdTurno 
						, base.IdAlarmaActual 
						, base.IdOrdenActual 
					from #tmpOeeEstadosCompleto as base
					left outer join Modulos as M on M.Id = base.IdModulo 
					left outer join Medidores as Meds on Meds.Id = base.IdMedidor 
					left outer join Ordenes as ords on ords.Id = base.IdOrdenActual 
					left outer join Productos as prod on prod.Id = ords.ProductoDestino 
					left outer join NetAlarmas as al on al.Id = base.IdAlarmaActual 
					left outer join NetAlarmasTipos as alt on alt.Id = al.IdError 
					left outer join OEEEstadosTipo as oeetipo on oeetipo.id = base.Estado 




				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[OEEEStadosFechaIntervalos] 
					-- Add the parameters for the stored procedure here
					@FechaInicio datetime
					, @FechaFinal datetime
					, @IntervalosSegs int
					, @ListaModulos nvarchar(max)
					, @ListaMedidores nvarchar(max)
				AS
				BEGIN
	
					if @ListaModulos='' and @ListaMedidores=''
					begin
						select result.intervalStartTime as IntervaloInicio
							, result.intervalEndTime as IntervaloFinal
							, result.eventDurationInIntervalSeconds as IntervaloDuracionSegs
							, o.* 
						from OEEEstados as o
						cross apply dbo.TVF_TimeRange_Split_To_GridSeconds(o.FInicio , DATEDIFF (second, o.FInicio, isnull(o.FFinal, @FechaFinal) ),@IntervalosSegs) result
						where isnull(o.FFinal, getdate()) > @FechaInicio and o.FInicio < @FechaFinal
						order by o.id 
					end
					else
					begin
						declare @LModulos table (id nvarchar(10));
						declare @LMedidores table (id nvarchar(10));

						--Si no funciona el StringSplit ... comprobar compatibilidad de la base de datos sea mínimo a 13 (2016)

						insert into @LModulos SELECT value FROM STRING_SPLIT(@ListaModulos, ',') WHERE RTRIM(value)<>'';
						insert into @LMedidores SELECT value FROM STRING_SPLIT(@ListaMedidores, ',') WHERE RTRIM(value)<>''

						select result.intervalStartTime as IntervaloInicio
							, result.intervalEndTime as IntervaloFinal
							, result.eventDurationInIntervalSeconds as IntervaloDuracionSegs
							, o.* 
						from 
						(
							select id, IdModulo , IdMedidor , Estado 
							, case when FInicio > @FechaInicio then FInicio else @FechaInicio end  as FInicio
							, case when ISNULL ( FFinal , GETDATE()) < @FechaFinal  then ISNULL ( FFinal , GETDATE()) else @FechaFinal end as FFinal
							, VentanaSegs , OperarioId , IdTurno , IdAlarmaActual , IdOrdenActual  
								from OEEEstados
								where FInicio < @FechaFinal 
									and (FFinal > @FechaInicio or FFinal is null) 
						 ) 
						 as o
						cross apply dbo.TVF_TimeRange_Split_To_GridSeconds(o.FInicio , DATEDIFF (second, o.FInicio, isnull(o.FFinal, @FechaFinal) ),@IntervalosSegs) result
						where isnull(o.FFinal, getdate()) > @FechaInicio and o.FInicio < @FechaFinal and (o.IdModulo in (select id from @LModulos  ) or o.IdMedidor in (select id from @LMedidores ))
						order by o.id 


					end
	



				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[OEEGenerarDatosFalsos] 
					-- Add the parameters for the stored procedure here
					@Finicio datetime, 
					@FFinal datetime,
					@MinutosIntervalo int,
					@Modulo int
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;
					declare @EstadoActual int
					declare @Fecha datetime
					set @Fecha = @Finicio 
					--set @EstadoActual = RAND(DATEPART(millisecond, getdate()))
					set @EstadoActual = 6 --Fuera de horario



					while @Fecha < @FFinal 
					begin
						declare @hora int
						set @hora = DATEPART (hour, @Fecha)

		
						--Dentro del horario
						set @EstadoActual = RAND() * 100;

						select @EstadoActual = case @EstadoActual 
							when 1 then 1
							when 2 then 2
							when 3 then 2
							when 4 then 3
							when 5 then 4
							when 6 then 5
							when 7 then 2
							when 8 then 7
							when 9 then 7
							when 10 then 4
							else 1
						end 

		

						declare @myturno int;
						set @myturno = dbo.VerTurnoId(@Fecha);

						if (@myturno is null)
						begin
							set @EstadoActual = 6
						end
		


						INSERT INTO [dbo].[OEEEstados]
						   ([IdModulo], [Estado], [FInicio], [FFinal], [VentanaSegs], [OperarioId], [IdTurno])
						 VALUES
						   (@Modulo , @EstadoActual , @Fecha , DATEADD(minute, @MinutosIntervalo, @Fecha), @MinutosIntervalo *60, 1, @myturno);

		

						set @Fecha = DATEADD(minute, @MinutosIntervalo, @Fecha)
					end


	
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[OrdenesACabOrdenes] 
				AS
				BEGIN
					SET NOCOUNT ON;
					update ordenes set IdCab=null;
					delete from cabordenes;

					declare @id as int;
					declare @nombre as nvarchar(250)
					declare @myfecha as datetime;
					declare @ProductoDestino as int;
					declare @LoteDestino as int;
					declare @formula as int;
					declare @Modulo as int;
					declare @ultimaId as int;
					declare @relacionada as int;
					declare @idCab as int;



					--miramos todas una a una, si alguna es dependiente, su base ha de existir antes, por lo tanto ya estará tratada.
					DECLARE myorden CURSOR
					FOR select id,  Nombre, 
						Fecha as FechaCreacion, 
						ProductoDestino as ProductoDestino, 
						LoteDestino as LoteDestino, 
						Formula as Formula, 
						Modulo as Modulo,
						OrdenRelacionada   from ordenes

	
					--Abrimos y leemos primer registro.
					OPEN myorden;
					FETCH NEXT FROM myorden into @id, @nombre, @myfecha, @ProductoDestino, @LoteDestino, @formula, @Modulo, @relacionada ;
	
					WHILE @@FETCH_STATUS = 0
					BEGIN
						if (@relacionada <>0)
						begin
							-- Es una relacionada, que por lo tanto ya tiene cabecera existente, hemos de buscarla y asignarla únicamente.
							SET @idCab  =  (select IdCab  from Ordenes where Id= @relacionada) ;
							update Ordenes set IdCab = @idCab where Id= @id;
						end
						else
						begin 
							--Es una orden que no existe cabecera, hemos de generarla.
							insert into cabordenes ([Nombre]
								,[FechaCreacion]
								,[FechaInicio]
								,[FechaFinal]
								,[Tipo]
								,[ProductoDestino]
								,[UbicacionDestino]
								,[LoteDestino]
								,[Prioridad]
								,[Formula]
								,[Modulo]) 
							values
								(@nombre, @myfecha , null, null, 1, @ProductoDestino , null, @LoteDestino , 1, @formula , @Modulo );

							SELECT @ultimaId  = SCOPE_IDENTITY();

							update Ordenes set IdCab = @ultimaId where Id= @id;
						 end




						--Siguiente registro
						FETCH NEXT FROM myorden into @id, @nombre, @myfecha, @ProductoDestino, @LoteDestino, @formula, @Modulo, @relacionada ;
					END
	
					CLOSE myorden;
					DEALLOCATE myorden;



	
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[P_ERPProductoUbicacion] 
				AS 
				BEGIN
					SET NOCOUNT ON

					DECLARE @MyTempTable TABLE
					(
						ItemId nvarchar(20),
						InventLocation nvarchar(10),
						wMSLocationId nvarchar(10)
					)

					SELECT ItemId, InventLocation, wMSLocationId FROM @MyTempTable;
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[P_ERPStockDisponibleCargaSilo] 
				AS 
				BEGIN
					SET NOCOUNT ON

					DECLARE @MyTempTable TABLE
					(
						ITEMID nvarchar(20),
						ITEMNAME nvarchar(60),
						INVENTSITEID nvarchar(10),
						INVENTLOCATIONID nvarchar(10),
						WMSLOCATIONID nvarchar(10),
						INVENTBATCHID nvarchar(20),
						CONFIGID nvarchar(25),
						AvailableQty numeric(28, 12),
						DATAAREAID nvarchar(4)
					)

					SELECT ITEMID, ITEMNAME, INVENTSITEID, INVENTLOCATIONID, WMSLOCATIONID,
							INVENTBATCHID, CONFIGID, AvailableQty, DATAAREAID 
					  FROM @MyTempTable;
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[Productividad] 
					-- Add the parameters for the stored procedure here
					@finicio as datetime,
					@ffinal as datetime
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					create table #temporal (Modulo nvarchar(50), Fecha date, Productividad decimal(18,3))

					declare @nombreMod as nvarchar(50)
					declare @idMod as int
	

					declare @diff as int
					declare @i as int
					declare @fecha as date
					declare @Productividad as decimal(18,3)

					DECLARE c CURSOR  
					FOR SELECT Nombre , id FROM Modulos where TipoModulo >100 and TipoModulo <200
					OPEN C  
					FETCH NEXT FROM C into @nombreMod, @idMod;  
					WHILE @@FETCH_STATUS = 0  
					BEGIN 


		


						set @diff = DATEDIFF (day, @finicio, @ffinal)

						if @diff <0 
						begin
							return 
						end

						set @i=@diff
						set @fecha = @finicio 

						while @i>0
						begin
							set @Productividad = isnull( dbo.ProductividadModuloDia (@idMod , @fecha),0)
							insert into #temporal  values (@nombreMod , @fecha, @Productividad )
							set @i = @i-1
							set @fecha = dateadd(day, 1, @fecha)
						end
		
						FETCH NEXT FROM C into @nombreMod, @idMod;  
					END

					CLOSE c;  
					DEALLOCATE c;  

					select * from #temporal 

	
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[Productividad7Dias] 
					-- Add the parameters for the stored procedure here
	
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					create table #temporal (Modulo nvarchar(50), Fecha date, Productividad decimal(18,3))

					declare @nombreMod as nvarchar(50)
					declare @idMod as int
					declare @finicio as date
					declare @ffinal as date

					declare @diff as int
					declare @i as int
					declare @fecha as date
					declare @Productividad as decimal(18,3)

					DECLARE c CURSOR  
					FOR SELECT Nombre , id FROM Modulos where TipoModulo >100 and TipoModulo <200
					OPEN C  
					FETCH NEXT FROM C into @nombreMod, @idMod;  
					WHILE @@FETCH_STATUS = 0  
					BEGIN 


						set @ffinal = dateadd(day, 1, getdate())
						set @finicio = dateadd(day, -7, @ffinal)


						set @diff = DATEDIFF (day, @finicio, @ffinal)

						if @diff <0 
						begin
							return 
						end

						set @i=@diff
						set @fecha = @finicio 

						while @i>0
						begin
							set @Productividad = isnull( dbo.ProductividadModuloDia (@idMod , @fecha),0)
							insert into #temporal  values (@nombreMod , @fecha, @Productividad )
							set @i = @i-1
							set @fecha = dateadd(day, 1, @fecha)
						end
		
						FETCH NEXT FROM C into @nombreMod, @idMod;  
					END

					CLOSE c;  
					DEALLOCATE c;  

					select * from #temporal 

	
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[RangoConsumoKWMotores] 
					-- Add the parameters for the stored procedure here
					@TipoRango nvarchar(50)
					, @FechaInicio datetime 
					, @FechaFin datetime
					, @NumMuestras int
					, @ListaMotores nvarchar(max)
					, @IpServidor as nvarchar(20)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					if @TipoRango <> 'Personalizada' 
					begin 
						set @FechaFin = getdate();
						set @FechaInicio  = dbo.RangoFechaInicio(@TipoRango );
					end



					EXEC [dbo].[ConsumoKWMotores]
						@FechaInicio = @FechaInicio ,
						@FechaFin = @FechaFin ,
						@NumMuestras = @NumMuestras ,
						@IpServidor = @IpServidor ,
						@ListaMotores = @ListaMotores
	
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[RangoConsumoKWMotoresSumas] 
					-- Add the parameters for the stored procedure here
					@TipoRango nvarchar(50)
					, @FechaInicio datetime 
					, @FechaFin datetime
					, @NumMuestras int
					, @ListaMotores nvarchar(max)
					, @IpServidor as nvarchar(20)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					if @TipoRango <> 'Personalizada' 
					begin 
						set @FechaFin = getdate();
						set @FechaInicio  = dbo.RangoFechaInicio(@TipoRango );
					end



					EXEC [dbo].[ConsumoKWMotores]
						@FechaInicio = @FechaInicio ,
						@FechaFin = @FechaFin ,
						@NumMuestras = @NumMuestras ,
						@IpServidor = @IpServidor ,
						@ListaMotores = @ListaMotores,
						@Sumado =1
	
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[RangoConsumoKWSecciones] 
					-- Add the parameters for the stored procedure here
					@TipoRango nvarchar(50)
					, @FechaInicio datetime 
					, @FechaFin datetime
					, @NumMuestras int
					, @ListaSecciones nvarchar(max)
					, @IpServidor as nvarchar(20)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					if @TipoRango <> 'Personalizada' 
					begin 
						set @FechaFin = getdate();
						set @FechaInicio  = dbo.RangoFechaInicio(@TipoRango );
					end



					EXEC [dbo].[ConsumoKWMotoresSecciones]
						@FechaInicio = @FechaInicio ,
						@FechaFin = @FechaFin ,
						@NumMuestras = @NumMuestras ,
						@IpServidor = @IpServidor ,
						@ListaSecciones  = @ListaSecciones
	
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[RangoConsumoKWSeccionesSumas] 
					-- Add the parameters for the stored procedure here
					@TipoRango nvarchar(50)
					, @FechaInicio datetime 
					, @FechaFin datetime
					, @NumMuestras int
					, @ListaSecciones nvarchar(max)
					, @IpServidor as nvarchar(20)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					if @TipoRango <> 'Personalizada' 
					begin 
						set @FechaFin = getdate();
						set @FechaInicio  = dbo.RangoFechaInicio(@TipoRango );
					end



					EXEC [dbo].[ConsumoKWMotoresSecciones]
						@FechaInicio = @FechaInicio ,
						@FechaFin = @FechaFin ,
						@NumMuestras = @NumMuestras ,
						@IpServidor = @IpServidor ,
						@ListaSecciones  = @ListaSecciones,
						@Sumado =1
	
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[spReseedUserTables] 
					@password nvarchar(20) = N''
				AS
				BEGIN
					DECLARE @TableName sysname = N''
					DECLARE @ColumnName sysname = N''
					DECLARE @CurrentSeed bigint = 0
					DECLARE @NewSeed bigint = 0
					DECLARE @SQL nvarchar(4000) = N''

					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					IF @password = '1_voltecsl'
					BEGIN
						-- find all non-system tables and load into a cursor
						DECLARE IdentityTables CURSOR FAST_FORWARD
						FOR
						SELECT TableName = c.TABLE_SCHEMA + N'.' + t.TABLE_NAME
						, c.COLUMN_NAME
						FROM INFORMATION_SCHEMA.COLUMNS AS c
						INNER JOIN INFORMATION_SCHEMA.TABLES AS t ON t.TABLE_NAME = c.TABLE_NAME
						AND t.TABLE_SCHEMA = c.TABLE_SCHEMA
						WHERE COLUMNPROPERTY(OBJECT_ID(c.TABLE_SCHEMA + '.' + c.TABLE_NAME), c.COLUMN_NAME, 'IsIdentity') = 1
						AND t.TABLE_TYPE = 'Base Table'

						OPEN IdentityTables

						FETCH NEXT FROM IdentityTables INTO @TableName, @ColumnName
						WHILE @@FETCH_STATUS = 0
						BEGIN
						-- leer el valor actual de IDENTITY de la tabla
						SET @CurrentSeed = (SELECT IDENT_CURRENT(@TableName) AS IDENT_CURRENT)
						--PRINT @CurrentSeed;
						-- find the max value of the identity column in the table, use 1 if there are no rows
						SET @SQL = N'SELECT @NewSeed_out = ISNULL(MAX([' + @ColumnName + ']), 0) FROM ' + '['+REPLACE(@tablename,'.','].[')+']'
						--PRINT @SQL
						EXECUTE sys.sp_executesql @SQL, N'@NewSeed_out bigint OUTPUT', @NewSeed_out = @NewSeed OUTPUT

						IF (@CurrentSeed <> 1 AND @NewSeed >= 0) AND @CurrentSeed <> @NewSeed BEGIN
							-- reseed the identity with the max value found in the previous step, SQL Server will automatically pick up at the next value
							SET @SQL = N'DBCC CHECKIDENT(''' + @TableName + ''', RESEED, ' + CAST(@NewSeed AS varchar(25)) + ')' + ' -- Current: ' + CAST(@CurrentSeed AS varchar(25))
							--PRINT @SQL
							PRINT @TableName + ' : Current seed ' + CAST(@CurrentSeed AS varchar(25)) + ' ; New seed ' + CAST(@NewSeed AS varchar(25))
							EXECUTE (@SQL)
						END

						FETCH NEXT FROM IdentityTables INTO @TableName, @ColumnName
						END

						DEALLOCATE IdentityTables
					END
					ELSE
					BEGIN
						PRINT 'Incorrect password'
					END
				END
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER PROCEDURE [dbo].[UpdateBufferOrdenes] 
	
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					DECLARE @Orden nvarchar(50)
					, @Fecha date
					, @Referencia nvarchar(50)
					, @NombreProducto nvarchar(50)
					, @Lote nvarchar(50)
					, @FCaducidad date
					, @Cantidad decimal(18,3)
					, @NumCiclos int
					; 

					DECLARE @LinOrden nvarchar(50)
					, @LinNumLinea int
					, @LinRefProducto nvarchar(50)
					, @LinLoteProducto nvarchar(50)
					, @LinCaducidadLoteProducto date
					, @LinCantidad numeric(18,3)
					, @LinTipo int
					, @LinCantidadTotal numeric(18,3)
					; 
	
					DECLARE filas CURSOR FOR   
						SELECT Nombre , Fecha, RefProducto, NombreProducto, NombreLoteProducto , FCaducidadLoteProducto ,
							Cantidad , NumCiclos
						FROM BufferERPCabOrdenes  
						WHERE Tratado=0
						ORDER BY Fecha ;  
  
					OPEN filas  
  
					FETCH NEXT FROM filas   
						INTO @Orden, @Fecha, @Referencia, @NombreProducto, @Lote, @FCaducidad, @Cantidad, @NumCiclos ;


  
					WHILE @@FETCH_STATUS = 0  
					BEGIN  
						BEGIN TRY 

							SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
							BEGIN TRANSACTION;
								DECLARE @ESTADO AS BIT=0;

								--Comprobacion de valores...
								if @Orden is null or @orden=''
								begin
									set @Estado=1;
									update BufferERPCabOrdenes set Tratado=1, Errores='Campo de Nombre vacío' where Nombre  = @Orden  ;
								end

								if @Fecha is null 
								begin
									set @Fecha = getdate();
								end

								if @Referencia is null or @Referencia=''
								begin
									set @Estado=1;
									update BufferERPCabOrdenes set Tratado=1, Errores='Campo de referencia vacío' where Nombre  = @Orden  ;
								end

								if @NombreProducto is null or @NombreProducto=''
								begin
									--Si existe la referencia no hay problema, sino, no podemos crear el producto final...
									declare @tmpProd int = (select count(*) from Productos where Referencia =@Referencia )
									if @tmpProd=0
									begin
									set @Estado=1;
									update BufferERPCabOrdenes set Tratado=1, Errores='Campo de Nombre producto vacío' where Nombre  = @Orden  ;
									end
								end

								if @Cantidad <=0 
								begin
									set @Estado=1;
									update BufferERPCabOrdenes set Tratado=1, Errores='Cantidad debe ser mayor que 0' where Nombre  = @Orden  ;
								end







				


								if @ESTADO =0
								begin

									--Guardamos los datos de la cabecera.


									--Buscamos lineas
									DECLARE lineas CURSOR FOR   
										SELECT NombreOrden, NumLinea, RefProducto, LoteProducto , CaducidadLoteProducto , Cantidad , Tipo , CantidadTotal 
										FROM BufferERPLinOrdenes  
										WHERE NombreOrden =@Orden 
										ORDER BY NumLinea  ;  
  
									OPEN lineas

									FETCH NEXT FROM lineas   
										INTO @LinOrden, @LinNumLinea, @LinRefProducto,
										@LinLoteProducto, @LinCaducidadLoteProducto, 
										@LinCantidad, @LinTipo, @LinCantidadTotal ;

					 
									WHILE @@FETCH_STATUS = 0  
									BEGIN 
					  
						
									--Comprobamos datos lineas, si algo mal, toda transacción fuera ...

									--Entramos datos lineas

									--Recogemos siguiente fila...
									FETCH NEXT FROM lineas   
											INTO @LinOrden, @LinNumLinea, @LinRefProducto,
											@LinLoteProducto, @LinCaducidadLoteProducto, 
											@LinCantidad, @LinTipo, @LinCantidadTotal ;
									END
									CLOSE lineas;  
									DEALLOCATE lineas;
									--Guardamos y fuera.
									--Guardaremos con Importado=1, y desde integra se revisará para añadir medidores oportunos
									--y que todo esté correcto, y entonces pondrá con Importado=2.

									COMMIT TRANSACTION; 
								END
								
						END TRY  
						BEGIN CATCH 
							print ERROR_MESSAGE();
							IF(@@TRANCOUNT > 0)
							ROLLBACK TRANSACTION
							update BufferERPCabOrdenes set errores = ERROR_MESSAGE(), Tratado =1, FTratado =getdate() where Nombre =@Orden  ;
						END CATCH 


						FETCH NEXT FROM filas   
						INTO @Orden, @Fecha, @Referencia, @NombreProducto, @Lote, @FCaducidad, @Cantidad, @NumCiclos ;
					END   
					CLOSE filas;  
					DEALLOCATE filas;  

				END
				GO
			");

			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[CertificadosDesinfeccionExtended] AS
					SELECT CD.id
						  , CD.Serie
						  , CD.Numero
						  , CD.NRegistroCentro
						  , CD.Responsable
						  , CD.DNIResponsable
						  , CD.NombreCentro
						  , CD.fecha
						  , CD.idCamion AS VehiculoId
							, ISNULL(V.Matricula, CD.Matricula) AS VehiculoMatricula
							, ISNULL(V.Remolque, CD.Remolque) AS VehiculoRemolque
							, V.Referencia AS VehiculoReferencia
					--      , CD.Matricula
					--      , CD.Remolque
						  , CD.idTransportista AS ChoferId
							  , ISNULL(C.Nombre, CD.Conductor) AS ChoferNombre
					--		, C.DNI AS ChoferDNI  -- para cuando se cree el campo
					--      , CD.Conductor AS ChoferNombre
						  , CD.Desinfectante AS DesinfectanteNombre
						  , CD.Precinto
						  , CD.FechaCertificado
						  , CD.idOrden
					  FROM CertificadoDesinfeccion AS CD
						LEFT OUTER JOIN Vehiculos AS V ON V.Id = CD.idCamion
						LEFT OUTER JOIN Choferes AS C ON C.Id = CD.idTransportista
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ComprasExtended]
				AS
				SELECT C.Id 
					  , C.Serie AS idSerie
						, S.Nombre AS SerieNombre
						, S.Estado AS SerieEstado
						, dbo.GetTextoParametro('Series', 'Estado', S.Estado) as SerieEstadoTexto
					  , C.Numero
					  , C.Proveedor AS idProveedor
						  , Prove.Referencia AS ProveedorReferencia
						  , Prove.Nombre AS ProveedorNombre
						  , Prove.CIF AS ProveedorCIF
						  , Prove.Direccion AS ProveedorDireccion
						  , Prove.CodigoPostal AS ProveedorCodigoPostal
						  , Prove.Poblacion AS ProveedorPoblacion
						  , Prove.Telefono AS ProveedorTelefono
						  , Prove.Provincia AS ProveedorProvincia
							, Provi.Nombre AS ProveedorProvinciaNombre
						  , Prove.Abreviado AS ProveedorAbreviado
						  , Prove.Pais AS ProveedorPais
							, Pais.Nombre AS ProveedorPaisNombre
						  , Prove.Inhabilitado AS ProveedorInhabilitado
							, dbo.GetTextoParametro('Proveedores', 'Inhabilitado', Prove.Inhabilitado) AS ProveedorInhabilitadoTexto
					  , C.Fecha
					  , C.Estado
						, dbo.GetTextoParametro('Compras', 'Estado', C.Estado) as EstadoTexto
				--      , C.UltimaFecha
					  , C.Importado
					  , C.Departamento
					  , C.Entrega AS FechaEntrega
					  , C.Comentario
					  , C.Impresa
					  , C.Refrescado
					  , C.Fin
					  , C.Exportado
					  , C.Referencia
					  , C.idContrato
					  , C.ReferenciaContrato
				  FROM dbo.Compras AS C
					  LEFT OUTER JOIN Series AS S ON S.Id = C.Serie
					  LEFT OUTER JOIN dbo.Proveedores AS Prove ON Prove.Id = C.Proveedor 
						LEFT OUTER JOIN Provincias AS Provi ON Provi.Id = Prove.Provincia AND Provi.Pais = Prove.Pais 
						LEFT OUTER JOIN Paises AS Pais ON Pais.Id = Prove.Pais
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ComprasLineasExtended]
				AS
				SELECT LC.Id
				--      , LC.Serie
					  , LC.Compra AS idCompra
					  , LC.Linea
					  , LC.Producto AS idProducto
						, P.Nombre AS ProductoNombre
					  , LC.Cantidad
					  , LC.Servida
					  , LC.Estado
						, dbo.GetTextoParametro('ComprasLineas', 'Estado', LC.Estado) AS EstadoStr
					  , LC.Importado
					  , LC.Departamento
					  , LC.Lote AS idLote
					  , LC.Bultos
					  , LC.Envase AS idEnvase
						, Enva.Nombre AS EnvaseNombre
					  , LC.Unidad AS idUnidad
						, Uni.Nombre AS UnidadTexto
					  , LC.Contrato AS ContratoTextoLibre
					  , LC.Comentario
					  , LC.Exportado
					  , LC.PrecioCompra
				-- idMonedaCompra...
					  , LC.IdContrato
				-- Contrato...
					  , LC.Fecha
					  , LC.FechaInicio
					  , LC.FechaFin
				  FROM dbo.LineasCompra AS LC
					LEFT OUTER JOIN Productos as P ON P.Id = LC.Producto
					LEFT OUTER JOIN Envases AS Enva ON Enva.Id = LC.Envase
					LEFT OUTER JOIN Unidades AS Uni ON Uni.Id = LC.Unidad
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ConsumidoOrden]
				AS
 
				SELECT Res.Id
					  , Res.Orden AS IdOrden
					  , Res.Cantidad
					  , Res.Lote
						, L.Nombre AS LoteNombre
						, L.Referencia AS LoteReferencia
					  , Res.Producto
						, P.Nombre AS ProductoNombre
						, P.PartidaArancelariaCompras 
						, P.PartidaArancelariaFabricacion 
					  , Res.Unidad
						, Uni.Nombre AS UnidadNombre
				  FROM .dbo.Resultados AS Res
					LEFT OUTER JOIN Lotes AS L ON L.Id = Res.Lote
					LEFT OUTER JOIN Productos AS P ON P.Id = Res.Producto
					LEFT OUTER JOIN Unidades AS Uni ON Uni.Id = Res.Unidad
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[DashOrdenes]
				AS

				select 
				O.Id as IdOrden
				, S.Nombre as Serie
				, M.Nombre as Modulo
				, O.Nombre
				, CO.Id as IdCabecera 
				, CO.Nombre as NombreCabecera
				, isnull(P.Nombre,'') as Producto
				, isnull(L.Nombre, '') as Lote
				--, O.Fecha as Fecha
				, cast(O.Fecha  as date)  as Fecha
				, O.Cantidad as Cantidad
				, O.NumeroCiclos as Ciclos
				, O.Cantidad * O.NumeroCiclos as CantidadTotal
				, round((select isnull(sum(cantidad),0) from Resultados as R where R.Orden = O.Id ),3) as CantidadReal
				, round((select isnull(sum(KwhEfectivo),0) from Resultados as R where R.Orden = O.Id ),3) as KwhEfectivo
				, round((select isnull(sum(KWhTotal),0) from Resultados as R where R.Orden = O.Id ),3) as KWhTotal
				, isnull(F.Nombre ,'') as Formula
				, case 
					when DATEPART(HOUR, FechaInicio )<14 then 'Mañana'
					else 'Tarde'
				  end as Turno

				,  STUFF((
						  SELECT ',' + U.Nombre
						  from Dosificaciones  as D 
							INNER JOIN Ubicaciones AS U ON U.Id = D.Ubicacion 
							where D.Orden = O.Id
							order by D.PosicionDosificacion desc
						  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') as Origenes

				,  STUFF((
						  SELECT ',' + U.Nombre
						  from Desgloses   as D 
							INNER JOIN Ubicaciones AS U ON U.Id = D.Ubicacion 
							where D.Orden = O.Id
							order by D.Id  desc
						  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') as Destinos


				, case O.Estado 
					when 0 then 'Pendiente'
					when 1 then 'Procesando'
					when 2 then 'Retenida'
					when 3 then 'Iniciando'
					when 4 then 'Eliminada'
					when 5 then 'Detenida'
					when 6 then 'Finalizada'
					when 7 then 'Interrumpida'
					when 8 then 'Forzada'
					else 'Desconocido'
					end as Estado
		
				, cast(O.Inicio as time)  as Inicio
				, cast(O.Fin as time)  as Fin  
				, Case O.Modificada
					when 1 then 'Si'
					when 0 then 'No'
					end as Modificada

				 from Ordenes as O
				 inner join CabOrdenes as CO on O.IdCab = CO.id 
				 left outer join Series as S on S.Id = O.Serie 
				 left outer join Productos as P on O.ProductoDestino  = P.Id 
				 left outer join Modulos as M on M.Id = O.Modulo 
				 left outer join Lotes as L on O.LoteDestino = L.Id 
				 left outer join Formulas as F on O.Formula = F.Id  
 
				 where O.Estado <>4 and M.TipoModulo>100 and M.TipoModulo < 200
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[DashVistaStocks] as
				select 
					P.Nombre as ProductoNombre
					, P.Referencia as ProductoReferencia
					, P.Referencia2 as ProductoReferencia2
					, isnull(P.Densidad,0) as ProductoDensidad
					, case P.Tipo 
						when 0 then 'Materia Prima'
						when 1 then 'SemiElaborado'
						when 2 then 'Acabado'
						else 'Indefinido' end as TipoProducto
					, isnull(S.Cantidad,0) as CantidadStock
					, isnull(U.Nombre,'') as UbicacionNombre

				from Productos as P
				left outer join Stocks as S on S.Producto = P.id 
				left outer join Ubicaciones as U on U.id = S.Ubicacion
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[DatosMuestraEntrada] AS
				SELECT el.id AS idLineaEntrada, p.Nombre AS producto , p.Referencia AS prodRef , p.Referencia2 AS prodRef2 , l.Nombre AS lote , l.Fecha AS lotefecha , l.Caducidad AS lotecaducidad , pr.Nombre AS proveedor , 
					pr.CIF AS provCif , pr.Referencia AS provRef , e.Referencia AS EntradaRef, e.ReferenciaCompra AS refcompra,
					el.CantidadPedida , el.PesoBruto , el.NetoOrigen , el.FechaInicioRecepcion , el.FechaFinRecepcion , el.IdMuestra, 
					l.id AS loteId, p.Id AS ProductoId, e.Numero, s.Nombre AS Serie

				 from EntradasLineas AS el
				inner join Entradas AS e on e.id = el.idEntradas 
				inner join Productos AS p on p.Id = el.idProducto 
				left outer join Proveedores AS pr on pr.Id = e.idProveedor 
				left outer join Lotes AS l on l.Id = el.Lote 
				left outer join Series AS s on s.Id = e.Serie
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[DEBUG_ResultadosSinMovimientos]
				AS

				SELECT DISTINCT r.Orden AS idOrden, o.Nombre AS Orden, o.Inicio AS InicioOrden, r.Ciclo, u.Nombre AS Ubicacion, r.Producto AS idProducto, p.Nombre AS ProductoSinMovimientoStock, r.Inicio AS FechaResultado
				FROM Ubicaciones u, Productos p, Resultados r, Ordenes o 
				WHERE r.Ubicacion = u.id AND r.Producto = p.Id AND r.orden = o.id AND r.Producto NOT IN (SELECT DISTINCT l.IdProducto FROM LogMovimientosStocks l WHERE l.idOrden = r.Orden AND l.Ciclo = r.Ciclo)
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[DesglosesDetalle]
				AS

				SELECT        
				d.Cantidad, 
				d.CantidadPrincipal, 
				d.Orden, 
				d.Id, 
				l.Nombre AS LoteNombre, 
				p.Nombre AS ProductoNombre, 
				un.Nombre AS UnidadNombre, 
				u.Nombre AS UbicacionNombre, 
				d.Ciclo

				FROM            dbo.Desgloses   AS d
				LEFT OUTER JOIN dbo.Productos	AS p ON p.Id = d.Producto
				LEFT OUTER JOIN dbo.Ubicaciones AS u ON u.Id = d.Ubicacion
				LEFT OUTER JOIN dbo.Lotes		AS l ON l.Id = d.Lote
				LEFT OUTER JOIN dbo.Unidades	AS un ON un.Id = d.Unidad
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[DesglosesExtended]
				AS
				 SELECT Desg.Id
					  , Desg.Serie
					  , Desg.Orden
						, O.Entrada AS IdEntrada
						, O.LineaEntrada AS IdLineaEntrada
					  , Desg.IdOld
					  , Desg.Producto
						, P.Nombre AS ProductoNombre
						, P.Referencia AS ProductoReferencia
						, P.Tipo as ProductoTipo
					  , Desg.Lote
						, L.Nombre AS LoteNombre
						, L.Referencia AS LoteReferencia
					  , Desg.Ubicacion
						, U.Nombre AS UbicacionNombre
						, U.Referencia AS UbicacionReferencia
					  , Desg.Cantidad
					  , Desg.Servida
					  , Desg.Unidad
						, Uni.Nombre AS UnidadNombre
					  , Desg.CantidadPrincipal
					  , Desg.TipoRegistro
							, dbo.GetTextoParametro('Desgloses', 'TipoRegistro', Desg.TipoRegistro) AS TipoRegistroTexto
					  , Desg.Finalizado
					  , Desg.Importado
					  , Desg.Exportado
					  , Desg.Estado
					  , Desg.Ciclo
					  , Desg.Fecha
					  , Desg.NumCorrecion
					  , Desg.ProdDensidad
					  , Desg.ProdNombre
					  , Desg.ProdNombreLoteActual
					  , Desg.Temperatura
					  , Desg.Humedad
					  , Desg.Ph
					  , Desg.DuracionStamp
					  , Desg.TiempoEfectivo
					  , Desg.TiempoTotal
					  , Desg.KWhEfectivo
					  , Desg.KWhTotal
					  , Desg.MedidorId
						, Medid.Nombre AS MedidorNombre
					  , Desg.IndicadorId
					  , Desg.UsuarioId
					  , Desg.MultidosiId
					  , Desg.TotalCiclos
					  , Desg.Camino
					  , Desg.Secuencia
					  , Desg.OperacionId
					  , Desg.ValidacionId
					  , Desg.TemperaturaId
					  , Desg.PhId
					  , Desg.FinalSecuencia
					  , Desg.FinalCiclo
					  , Desg.FinalMedidor
					  , Desg.FinalOrden
					  , Desg.CantidadManual
					  , Desg.OrdenCancelada
					  , Desg.BitAux1
					  , Desg.BitAux2
					  , Desg.Variable1
					  , Desg.Variable2
					  , Desg.Tipo
						, dbo.GetTextoParametro('Desgloses', 'Tipo', Desg.Tipo) AS TipoStr
					  , Desg.Editado
					  , Modulo.Nombre AS ModuloNombre
					  , Modulo.TipoModulo AS ModuloTipo
				  FROM dbo.Desgloses AS Desg

					LEFT OUTER JOIN Productos AS P ON P.Id = Desg.Producto 
					LEFT OUTER JOIN Lotes AS L ON L.Id = Desg.Lote
					LEFT OUTER JOIN Ubicaciones AS U ON U.Id = Desg.Ubicacion 
					LEFT OUTER JOIN Unidades AS Uni ON Uni.Id = Desg.Unidad
					LEFT OUTER JOIN Medidores AS Medid ON Medid.Id = Desg.MedidorId
					LEFT OUTER JOIN Modulos AS Modulo ON Modulo.Id = Medid.Modulo
					LEFT OUTER JOIN Ordenes AS O ON O.Id = Desg.Orden
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[DomiciliosExtended]
				AS
					SELECT Domi.Id AS DomicilioId
					  , Domi.Cliente AS DomicilioIdCliente
					  , Domi.Nombre AS DomicilioNombre
					  , Domi.Referencia AS DomicilioReferencia
					  , Domi.Direccion AS DomicilioDireccion
					  , Domi.Poblacion AS DomicilioPoblacion
					  , Domi.Telefono AS DomicilioTelefono
					  , Domi.CodigoPostal DomicilioCodigoPostal
					  , Domi.Provincia AS DomicilioProvincia
					  , Domi.Pais AS DomicilioPais
							, Pais.Nombre AS DomicilioPaisNombre
				--      , Domi.MarcaOficial
				--      , Domi.Importado
				--      , Domi.Refrescado
				--      , Domi.Exportado
				--      , Domi.Responsable
				--      , Domi.Especie
				--      , Domi.NumeroEspecies
					  , Domi.Inhabilitado
						, dbo.GetTextoParametro('Domicilio', 'Inhabilitado', Domi.Inhabilitado) AS DomicilioInhabilitadoStr
					  , Domi.Descripcion AS DomicilioDescripcion
					  , Domi.Simogan AS DomicilioSIMOGAN
				  FROM dbo.Domicilios AS Domi
					LEFT OUTER JOIN Paises AS Pais ON Pais.Id = Domi.Pais
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[DosificacionesDetalle]
				AS

				SELECT        
				d.Orden, 
				d.PosicionDosificacion, 
				p.Nombre AS NombreProducto, 
				m.Nombre AS NombreMedidor, 
				u.Nombre AS NombreUbicacion, 
				om.Nombre AS NombreMotor,
				oa.Nombre AS NombreAccion,
				d.Cantidad,
				un.Nombre AS Unidad,
				d.OperTiempo AS Tiempo,
				d.Tipo AS TipoDosificacion, 
				d.Id

				FROM            dbo.Dosificaciones	AS d 
				LEFT OUTER JOIN dbo.Productos		AS p ON p.Id = d.Producto and p.TipoPR=0
				LEFT OUTER JOIN dbo.Medidores		AS m ON m.Id = d.Medidor 
				LEFT OUTER JOIN dbo.Ubicaciones		AS u ON u.Id = d.Ubicacion and u.TipoPR=0
				LEFT OUTER JOIN dbo.OperMotores		AS om ON om.Id = d.IdOperMotor
				LEFT OUTER JOIN dbo.OperAcciones	AS oa ON oa.Id = d.IdOperAccion
				LEFT OUTER JOIN dbo.Unidades		AS un ON un.Id = d.Unidad
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[EntradasExtended]
				AS
				 SELECT E.id
					  , E.Serie
						, S.Nombre AS SerieNombre
						, S.Estado AS SerieEstado
						, dbo.GetTextoParametro('Series', 'Estado', S.Estado) as SerieEstadoTexto
					  , E.Numero
					  , E.FechaCreacion
					  , E.FechaPrevista
					  , E.idVehiculo
						, ISNULL(Vehic.Matricula, E.MatriculaCamion) AS VehiculoMatricula
						, ISNULL(Vehic.Remolque, E.MatriculaRemolque) AS VehiculoRemolque
						, Vehic.Referencia AS VehiculoReferencia
					  , E.idChofer
					  , ISNULL(Chof.Nombre, E.NombreConductor) AS ChoferNombre
					  , Chof.CIF AS ChoferCIF
					  , E.idProveedor
						  , Prove.Referencia AS ProveedorReferencia
						  , Prove.Nombre AS ProveedorNombre
						  , Prove.CIF AS ProveedorCIF
						  , Prove.Direccion AS ProveedorDireccion
						  , Prove.CodigoPostal AS ProveedorCodigoPostal
						  , Prove.Poblacion AS ProveedorPoblacion
						  , Prove.Telefono AS ProveedorTelefono
						  , Prove.Provincia AS ProveedorProvincia
							, Provi.Nombre AS ProveedorProvinciaNombre
						  , Prove.Abreviado AS ProveedorAbreviado
						  , Prove.Pais AS ProveedorPais
							, Pais.Nombre AS ProveedorPaisNombre
						  , Prove.Inhabilitado AS ProveedorInhabilitado
						  , Prove.AutorizacionDestinoFinal 
							, dbo.GetTextoParametro('Proveedores', 'Inhabilitado', Prove.Inhabilitado) AS ProveedorInhabilitadoTexto
					  , E.idTarjeta
						, Tarj.Nombre AS TarjetaNombre
					  , E.Estado
						, dbo.GetTextoParametro('Entradas', 'Estado', E.Estado) AS EstadoTexto
					  , E.Observaciones
					  , E.idEmpresaTransporte
						, EmpTrans.Nombre AS EmpresaTransporteNombre
						, EmpTrans.Referencia AS EmpresaTransporteReferencia
						, EmpTrans.CIF AS EmpresaTransporteCIF
					  , E.Precio
					  , E.FInicio AS FechaInicio
					  , E.FFin AS FechaFin
					  , E.Referencia
					  , E.ReferenciaCompra
					  , E.PreDesinfeccion
					  , E.PostDesinfeccion
					  , E.PreDesinfeccionOK
					  , E.CoeficienteRendimiento 
					  , E.DUA 
					  , E.Factura 
					  , E.Albaran 
					  , E.AceptacionDestinoFinal 
					  , (IIF(E.Predesinfeccion IS NOT NULL AND E.PreDesinfeccion=1
								, dbo.GetTextoParametro('Entradas', 'PreDesinfeccionOK', ISNULL(E.PreDesinfeccionOK, 0))
								, NULL)) AS PredesinfeccionOKTexto  -- Si se requiere, se muestra texto de si se ha hecho o no
					  , E.PostDesinfeccionOK
					  , (IIF(E.Postdesinfeccion IS NOT NULL AND E.PostDesinfeccion=1
								, dbo.GetTextoParametro('Entradas', 'PostDesinfeccionOK', ISNULL(E.PostDesinfeccionOK, 0))
								, NULL)) AS PostdesinfeccionOKTexto  -- Si se requiere, se muestra texto de si se ha hecho o no
				  FROM dbo.Entradas AS E
					  LEFT OUTER JOIN Series AS S ON S.Id = E.Serie
					  LEFT OUTER JOIN dbo.Proveedores AS Prove ON Prove.Id = E.idProveedor 
						LEFT OUTER JOIN Provincias AS Provi ON Provi.Id = Prove.Provincia AND Provi.Pais = Prove.Pais 
						LEFT OUTER JOIN Paises AS Pais ON Pais.Id = Prove.Pais
					  LEFT OUTER JOIN Tarjetas AS Tarj ON Tarj.Id = E.idTarjeta 
					  LEFT OUTER JOIN Vehiculos AS Vehic ON Vehic.Id = E.IdVehiculo
					  LEFT OUTER JOIN Choferes AS Chof ON Chof.Id = E.IdChofer
					  LEFT OUTER JOIN EmpresasTransporte AS EmpTrans ON EmpTrans.Id = E.idEmpresaTransporte
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[EntradasLineasExtended]
				AS
				 SELECT EL.id
					  , EL.idEntradas
					  , EL.idProducto
						, P.Nombre AS ProductoNombre
					  , EL.CantidadPedida
					  , EL.FechaInicioRecepcion
					  , EL.FechaFinRecepcion
					  , EL.PesoBruto
					  , EL.Cajon1
					  , EL.Cajon2
					  , EL.Cajon3
					  , EL.Cajon4
					  , EL.Cajon5
					  , EL.Cajon6
					  , EL.Cajon7
					  , EL.Cajon8
					  , EL.Cajon9
					  , EL.Cajon10
				--      , EL.TransitoActivo
				--      , EL.idBasculaPesajeBruto
				--      , EL.idBasculaPesajeNeto
				--      , EL.EntradaManualPesos
					  , EL.Estado
						, dbo.GetTextoParametro('EntradasLineas', 'Estado', EL.Estado) AS EstadoTexto
					  , EL.FueraCajon
				--      , EL.idProveedor
				--      , EL.LedControlDocumental
				--      , EL.LedAnalisisLaboratorio
				--      , EL.LedAutorizacion
				--      , EL.LedCargaProducto
				--      , EL.LedDevolucionTarjeta
					  , EL.Lote
						, L.Nombre AS LoteNombre
						, L.Referencia AS LoteReferencia
						, L.Caducidad AS LoteCaducidad
						, L.Estado AS LoteEstado
						, dbo.GetTextoParametro('Lotes', 'Estado', L.Estado) AS LoteEstadoTexto
					  , EL.Tara
					  , (EL.PesoBruto - EL.Tara) AS Neto
					  , EL.PesoNetoManual
					  , COALESCE(PesoNetoManual, (EL.PesoBruto - EL.Tara)) AS PesoNeto  -- El peso neto entrado manualmente tiene prevalencia
				--      , EL.RecogerPesoEnBascula
					  , EL.Unidad
						, Uni.Nombre AS UnidadTexto
					  , EL.Destino1
						, Ubi1.Nombre AS Destino1Nombre
						, Ubi1.Referencia AS Destino1Referencia
					  , EL.Destino2
						, Ubi2.Nombre AS Destino2Nombre
						, Ubi2.Referencia AS Destino2Referencia
					  , EL.Destino3
						, Ubi3.Nombre AS Destino3Nombre
						, Ubi3.Referencia AS Destino3Referencia
					  , EL.Destino4
						, Ubi4.Nombre AS Destino4Nombre
						, Ubi4.Referencia AS Destino4Referencia
					  , EL.Formato
						, Form.Nombre AS FormatoNombre
						, Form.Descripcion AS FormatoDescripcion
					  , EL.Envase
						, Enva.Nombre AS EnvaseNombre
					  , EL.Bultos
					  , EL.Observaciones
					  , EL.Precio
					  , EL.PagarKgTeoricos
					  , EL.CampoLibre1
					  , EL.CampoLIbre2
					  , EL.Fecha
					  , EL.idModulo
						, Modu.Nombre AS ModuloNombre
				--      , EL.Autorizada
				--      , EL.EstadoTarjeta
					  , porig.Nombre AS ProveedorOrigenNombre
				  FROM dbo.EntradasLineas AS EL
					LEFT OUTER JOIN Productos AS P ON P.Id = EL.idProducto
					LEFT OUTER JOIN Lotes AS L ON L.Id = EL.Lote
					LEFT OUTER JOIN Unidades AS Uni ON Uni.Id = EL.Unidad
					LEFT OUTER JOIN Ubicaciones AS Ubi1 ON Ubi1.Id = EL.Destino1 
					LEFT OUTER JOIN Ubicaciones AS Ubi2 ON Ubi2.Id = EL.Destino2 
					LEFT OUTER JOIN Ubicaciones AS Ubi3 ON Ubi3.Id = EL.Destino3 
					LEFT OUTER JOIN Ubicaciones AS Ubi4 ON Ubi4.Id = EL.Destino4
					LEFT OUTER JOIN Formatos AS Form ON Form.Id = EL.Formato 
					LEFT OUTER JOIN Envases AS Enva ON Enva.Id = EL.Envase
					LEFT OUTER JOIN Modulos AS Modu ON Modu.Id = EL.idModulo 
					LEFT OUTER JOIN ProveedoresOrigenes AS POrig ON POrig.Id = EL.idOrigenProv
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[EntradasExtendedLineasEntradasExtended]
				AS
				 SELECT ee.FechaFin AS FechaEntrada,
						ee.idProveedor,
						ee.ProveedorNombre,
						ee.ProveedorCIF,
						ee.EmpresaTransporteNombre,
						ee.EmpresaTransporteCIF,
						ee.coeficienterendimiento,
						ee.AutorizacionDestinoFinal,
						ee.Factura,
						ee.Albaran,
						ee.DUA,
						ee.AceptacionDestinoFinal,
						ele.*
				FROM EntradasExtended AS ee
					LEFT OUTER JOIN EntradasLineasExtended AS ele ON ele.idEntradas = ee.id
				WHERE EXISTS 
					(SELECT 1 FROM EntradasLineas AS el WHERE el.idEntradas = ee.id and el.idProducto = ele.idProducto)
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[EntradasLineasResultadosNIRExtended]
				AS
				 SELECT ResulsNIR.id
					  , ResulsNIR.idEntradasLineas
					  , ResulsNIR.idControlesNir
					  , ResulsNIR.Nombre
					  , ResulsNIR.Descripcion
					  , ResulsNIR.Resultado
					  , NULL AS IdUnidad
					  , NULL AS UnidadTexto
					  , ResulsNIR.FechaResultado
					  , ResulsNIR.ValorMinimo
					  , ResulsNIR.ValorEsperado
					  , ResulsNIR.ValorMaximo
					  , ResulsNIR.ValorMinimoAlerta
					  , ResulsNIR.ValorMaximoAlerta
					  , ResulsNIR.ActivarMinimo
					  , ResulsNIR.ActivarMaximo
					  , ResulsNIR.ActivarMinimoAlerta
					  , ResulsNIR.ActivarMaximoAlerta
				--      , ResulsNIR.Estado
				  FROM dbo.EntradasLineasResultadosNIR AS ResulsNIR
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[EtiquetaMuestraProduccion] as

						select 
					O.id as IdOrden,
					O.Inicio ,
					isnull(O.Fin, getdate()) as Fin,
					P.Nombre as NombreProducto ,
					L.Nombre as NombreLote ,
					L.Id as IdLote,
					(
					select 
						case count(*) 
							when 0 then 0
							else 1
						end as Medicado
					from
						(select D.Id
							from Dosificaciones as D 
						left outer join Productos as P on P.Id = D.Producto
						where P.Medicamento =1 and D.Orden =O.Id) as T) as Medicado
		
					from Ordenes as O
					left outer join Productos as P on P.id = O.ProductoDestino 
					left outer join Lotes as L on L.Id = O.LoteDestino
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[EtiquetaStock] as
				select 
					D.Nombre as Departamento
					, L.Id
					, isnull(L.Referencia,'') as Referencia 
					, isnull(L.Nombre,'') as Nombre
					, L.Fecha
					, L.Inicio
					, L.Fin
					, format (L.Caducidad , 'dd/MM/yyyy') as Caducidad
					, P.Id as IdProducto
					, isnull(P.Referencia, '') as RefProducto
					, isnull(P.Referencia2,'')  as Ref2Producto
					, isnull(P.Nombre,'') as NombreProducto
					, CASE WHEN (L.Caducidad IS NULL) 
						   THEN 
								concat('91', REPLACE(STR(L.id, 10), SPACE(1), '0'), '|250', L.Nombre , '|240' , P.Referencia , '|10', L.Referencia)
						   ELSE 
								concat('91', REPLACE(STR(L.id, 10), SPACE(1), '0'), '|250', L.Nombre , '|240' , P.Referencia , '|17', format (L.Caducidad , 'ddMMyy'), '|10', L.Referencia) 
						   END AS CodigoBarras
	
				from Lotes as L

				inner join Productos as P on L.Producto = P.Id 
				inner join Departamentos as D on D.Activo = 1
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[LoteProveedorUnicoNOCantidad]
				AS

				WITH LoteProv AS(

				SELECT 
					l.id as IdLote
					, isnull(pl.Nombre, p.Nombre  ) as Proveedor
							,STUFF((
						  SELECT distinct ' - ' + elo.LoteProveedor
						  FROM EntradasLotes  as elo, EntradasLineas el2
							WHERE elo.IdEntradasLineas = el2.id AND el2.Lote = l.Id
						  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 3, '') AS LotesProveedor
						  ,e.FechaCreacion
						  ,e.FFin
						  ,ROW_NUMBER() OVER (PARTITION BY l.Id ORDER BY e.FFin DESC, e.FechaCreacion DESC) AS NUM_PROVEEDOR
				FROM Lotes as l
				LEFT OUTER JOIN Proveedores as pl on pl.Id = l.IdProveedor 
				LEFT OUTER JOIN EntradasLineas as el on el.Lote = l.Id
				LEFT OUTER JOIN Entradas as e on e.id = el.idEntradas  
				LEFT OUTER JOIN Proveedores AS p ON p.Id = e.idProveedor
				LEFT OUTER JOIN Ordenes as O on O.LineaEntrada = el.id 
				LEFT OUTER JOIN Desgloses as D on D.Orden = O.Id 

				GROUP BY l.Id , pl.Nombre, p.Nombre, e.FechaCreacion, e.FFin)

				SELECT * FROM LoteProv WHERE NUM_PROVEEDOR = 1
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ExistenciasProductoLote]
				AS
				SELECT 

						e.[Inventario] AS Inventario, 
						p.Nombre AS ProductoNombre, 
						e.[LoteNombre] AS LoteNombre, 
						un.Nombre AS UnidadNombre, 
						e.[Estado] AS Estado,
						e.[Importado] AS Importado,
						e.[Exportado] AS Exportado,
						lp.Proveedor AS ProveedorNombre,
						l.Caducidad AS LoteCaducidad,
						p.Tipo AS ProductoTipo,
						lp.[LotesProveedor] AS LotesProveedor,
						SUM(e.Cantidad) AS Cantidad,
						u.Nombre AS UbicacionNombre,
						ISNULL(ROW_NUMBER() OVER(ORDER BY l.Caducidad ASC), -1) AS RowID

					FROM Existencias AS e 
					LEFT OUTER JOIN dbo.Lotes AS l ON l.Id = e.Lote
					LEFT OUTER JOIN dbo.Productos AS p ON p.Id = e.Producto
					LEFT OUTER JOIN dbo.Unidades AS un ON un.Id = e.Unidad
					LEFT OUTER JOIN dbo.Ubicaciones AS u ON u.Id = e.Ubicacion
					LEFT OUTER JOIN dbo.LoteProveedorUnicoNOCantidad AS lp ON l.Id = lp.IdLote

					GROUP BY e.Inventario, p.Nombre, e.LoteNombre, un.Nombre, e.Estado, e.Lote, e.Importado, e.Exportado, lp.Proveedor, l.Caducidad, p.Tipo, lp.LotesProveedor, u.Nombre
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[InformeExpediciones] AS (
					SELECT
						cliente.CodigoPostal AS ClienteCodigoPostal,
						cliente.Direccion AS ClienteDireccion,
						cliente.Nombre AS ClienteNombre,
						cliente.Poblacion AS ClientePoblacion,
						cliente.Telefono AS ClienteTelefono,
						domicilio.Nombre AS DomicilioNombre,
						domicilio.Poblacion AS DomicilioPoblacion,
						domicilio.Simogan AS DomicilioSimogan,
						empresaTransporte.CIF AS EmpresasTransporteCif,
						empresaTransporte.Nombre AS EmpresasTransporteNombre,
						provinciaCliente.Nombre AS ProvinciaClienteNombre,
						provinciaDomicilio.Nombre AS ProvinciaDomicilioNombre,
						salida.FFin AS SalidaFechaFin,
						salida.FInicio AS SalidaFechaInicio,
						salida.Fecha AS SalidaFecha,
						salidaViaje.Numero AS SalidaViajeNumero,
						salidaViaje.Observaciones AS SalidaViajeObservaciones,
						salidaViaje.id AS SalidaViajeId,
						serie.Nombre AS SerieNombre,
						vehiculo.Matricula AS VehiculoMatricula,
						vehiculo.Remolque AS VehiculoRemolque
					FROM
						[SalidasViajes] salidaViaje
					INNER JOIN [SalidasLinias] salidaLinea ON salidaViaje.id = salidaLinea.idviajes
						INNER JOIN [Domicilios] domicilio ON salidaLinea.idDomicilio = domicilio.id
							LEFT JOIN [Provincias] provinciaDomicilio ON domicilio.Provincia = provinciaDomicilio.Id
						INNER JOIN [Salidas] salida ON salidaLinea.idSalidas = salida.id
							INNER JOIN [Clientes] cliente ON salida.idCliente = cliente.Id
								LEFT JOIN [Provincias] provinciaCliente ON cliente.Provincia = provinciaCliente.Id
					INNER JOIN [Series] serie ON salidaViaje.idSerie = serie.Id
					INNER JOIN [Vehiculos] vehiculo ON salidaViaje.idVehiculo = vehiculo.Id
						INNER JOIN [EmpresasTransporte] empresaTransporte ON vehiculo.EmpresaTransporte = empresaTransporte.Id
					GROUP BY
						cliente.CodigoPostal,
						cliente.Direccion,
						cliente.Nombre,
						cliente.Poblacion,
						cliente.Provincia,
						cliente.Telefono,
						domicilio.Nombre,
						domicilio.Poblacion,
						domicilio.Simogan,
						empresaTransporte.CIF,
						empresaTransporte.Nombre,
						salida.FFin,
						salida.FInicio,
						salida.Fecha,
						salidaViaje.Numero,
						salidaViaje.Observaciones,
						salidaViaje.id,
						serie.Nombre,
						provinciaCliente.Nombre,
						provinciaDomicilio.Nombre,
						vehiculo.Matricula,
						vehiculo.Remolque
				);
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[InformeExpediciones_SalidaLinea] AS (
					SELECT
						producto.Nombre AS ProductoNombre,
						puntoDescarga.Nombre AS PuntoDescargaNombre,
						salidaLinea.Bruto AS SalidaLineaBruto,
						salidaLinea.Id AS SalidaLineaId,
						(salidaLinea.Bruto - salidaLinea.Tara) AS SalidaLineaNeto,
						salidaLinea.Observaciones AS SalidaLineaObservaciones,
						salidaLinea.Tara AS SalidaLineaTara,
						salidaViaje.id AS SalidaViajeId
					FROM
						[SalidasViajes] salidaViaje
					INNER JOIN [SalidasLinias] salidaLinea ON salidaViaje.id = salidaLinea.idviajes
						INNER JOIN [Ordenes] orden ON salidaLinea.id = orden.LineaSalida
							INNER JOIN [Resultados] resultado ON orden.Id = resultado.Orden
								INNER JOIN [Productos] producto ON resultado.Producto = producto.Id
						LEFT JOIN [PuntosDescarga] puntoDescarga ON salidaLinea.idPuntoDescarga = puntoDescarga.id
					GROUP BY
						salidaLinea.Bruto,
						salidaLinea.id,
						salidaLinea.Observaciones,
						salidaLinea.Tara,
						salidaViaje.id,
						producto.Nombre,
						puntoDescarga.Nombre
				);
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[InformeExpediciones_SalidaLinea_Resultado] AS (
					SELECT
						lote.Nombre AS LoteNombre,
						SUM(resultado.Cantidad) AS ResultadoCantidad,
						salidaLinea.id AS SalidaLineaId,
						unidad.Nombre AS UnidadNombre
					FROM
						[SalidasViajes] salidaViaje
					INNER JOIN [SalidasLinias] salidaLinea ON salidaViaje.id = salidaLinea.idviajes
						INNER JOIN [Ordenes] orden ON salidaLinea.id = orden.LineaSalida
							INNER JOIN [Resultados] resultado ON orden.Id = resultado.Orden
								INNER JOIN [Lotes] lote ON resultado.Lote = lote.Id
								INNER JOIN [Productos] producto ON resultado.Producto = producto.Id
								LEFT JOIN [Unidades] unidad ON resultado.Unidad = unidad.Id
						LEFT JOIN [PuntosDescarga] puntoDescarga ON salidaLinea.idPuntoDescarga = puntoDescarga.id
					GROUP BY
						lote.Nombre,
						salidaLinea.id,
						unidad.Nombre
				);
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[LineasSalidasAgrupLoteYOrden] AS
				(
					SELECT 
						* 
					FROM 
						(
							SELECT 
								ISNULL(r.Lote, 0) AS Lote,
								ISNULL(o.Id, 0) AS IdOrdenAgrup, 
								ISNULL (sl.id, 0) AS IdSalidaLinea,  
								SUM(r.cantidad) AS CantidadAgrup
							FROM 
								Resultados AS r
							LEFT OUTER JOIN 
								Ordenes AS o ON o.Id = r.orden
							LEFT OUTER JOIN  
								Modulos AS m ON m.Id = o.Modulo 
							LEFT OUTER JOIN 
								SalidasLinias AS sl ON sl.id = o.LineaSalida 
							WHERE 
								m.TipoModulo = 5 
							GROUP BY 
								r.Lote, 
								o.Id, 
								sl.id 
						) AS lista
					LEFT OUTER JOIN 
						SalidasLineasExtended AS datos ON datos.id = lista.IdSalidaLinea
				);
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ListaAlarmas] as
				select NA.Id as IDAlarma
					, NA.FechaError as FechaError
					, NA.RespFecha as FechaRespuesta
					, datediff( second, NA.FechaError , NA.RespFecha )  as SegundosAlarma
					, NA.idOrden
					, NA.IdPlc as IDError
					, NATipos.TextoError as DescripcionError
					, NA.Respuesta as IDRespuesta
					, NAResp.Texto 
					, NA.idDosificacion 
					, orden.Nombre as OrdenNombre
					, ordenProd.Nombre as OrdenProductoFinalNombre
					, ordenProd.Referencia as OrdenProductoFinalRef
					, Dosis.Producto as DosificacionIdProducto
					, DosisProd.Nombre as DosificacionNombreProducto
					, DosisProd.Referencia  as DosificacionReferenciaProducto
					, NA.RespPC as PCRespuesta
					, NA.TextoOpcional as textoOpcional
					, NA.TextoAdicional as textoAdicional
					, modulo.Nombre as Modulo
					, medidor.Nombre as Medidor
					, NA.idMotor as MotorId
					, motor.NombreMes as MotorNombreMes
					, motor.TAG as MotorTag
					, seccion.Nombre as seccion
					, gruposeccion.Nombre as gruposeccion

				from NetAlarmas as NA
				left outer join NetAlarmasTipos as NATipos on NATipos.IdAlarmaPLC = NA.IdPlc 
				left outer join NetAlarmasRespuestas  as NAResp on NAResp.id = NA.Respuesta 
				left outer join Ordenes  as orden on orden.Id = NA.idOrden 
				left outer join Productos  as ordenProd on ordenProd.Id = orden.ProductoDestino 
				left outer join Dosificaciones as Dosis on Dosis.Id = NA.idDosificacion 
				left outer join Productos as DosisProd on DosisProd.Id = Dosis.Producto 
				left outer join Modulos  as modulo on modulo.Id = NA.IdModulo 
				left outer join Medidores   as medidor on medidor.Id = NA.idMedidor 
				left outer join Motores    as motor on motor.id = NA.idMotor
				left outer join Secciones as seccion on seccion.Id = NA.IdSeccion 
				left outer join SeccionesGrupos as gruposeccion on gruposeccion.id = NA.IdGrupo
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ListaDesgloses]
				as
				select 
				D.Id 
				, D.Orden
				, P.Nombre as Producto
				, U.Nombre as Ubicacion
				, D.Cantidad 
				, D.CantidadPrincipal 
				, Ud.Nombre as Unidad
				, L.Nombre as Lote
				from Desgloses as D
				left outer join Productos as P on P.Id = D.Producto
				left outer join Ubicaciones as U on U.Id = D.Ubicacion 
				left outer join Unidades as Ud on Ud.Id = D.Unidad 
				left outer join Lotes as L on L.id = D.Lote
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ListaDosificaciones] as

				select 
				D.Id
				, isnull(D.Orden ,0) as Orden
				, P.Nombre 
				, (D.Porcentaje/100 ) as Porcentaje
				, D.Cantidad 
				, U.Nombre as Unidad 
				--, D.Inicio --Esto no sirve.. esto ya son resultados..
				--, D.Fin
				, L.Nombre as Lote  --En teoría no .. ya que se asignará la que corresponda... O se puede especificar lote a usar en producción?
				, Mo.Nombre as Modulo
				, Mo.OrdenProduccion as ModuloOrdenacion
				, M.Nombre as Medidor
				, D.PosicionDosificacion
				, Ub.Nombre as OrigenPrincipal
				, Ub.Nombre + isnull( STUFF((
						  SELECT ',' + U.Nombre
						  from MultiDosificaciones   as D2 
							INNER JOIN Ubicaciones AS U ON U.Id = D2.idUbicacion  
							where D2.idDosificacion  = D.Id 
						  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, ''),'') as Origenes



				from Dosificaciones as D
				inner join Ordenes  as O on O.Id=D.Orden 
				left outer join Productos as P on D.Producto = P.Id 
				left outer join Unidades as U on U.Id = P.Unidad 
				left outer join lotes as L on L.Id = D.Lote 
				left outer join Medidores as M on M.Id = D.Medidor 
				left outer join Modulos as Mo on Mo.id = M.Modulo 
				left outer join Ubicaciones as Ub on Ub.Id = D.Ubicacion 


				--where D.Orden = 161 
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ListaOrdenes]
				AS

				select 
				O.Id as IdOrden
				, S.Nombre as Serie
				, M.Nombre as Modulo
				, O.Nombre
				, CO.Id as IdCabecera 
				, CO.Nombre as NombreCabecera
				, isnull(P.Nombre,'') as Producto
				, isnull(L.Nombre, '') as Lote
				--, O.Fecha as Fecha
				, cast(O.Fecha  as date)  as Fecha
				, O.Cantidad as Cantidad
				, O.NumeroCiclos as Ciclos
				, round((select isnull(sum(cantidad),0) from Resultados as R where R.Orden = O.Id ),3) as CantidadReal
				, isnull(F.Nombre ,'') as Formula

				,  STUFF((
						  SELECT ',' + U.Nombre
						  from Dosificaciones  as D 
							INNER JOIN Ubicaciones AS U ON U.Id = D.Ubicacion 
							where D.Orden = O.Id
							order by D.PosicionDosificacion desc
						  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') as Origenes

				,  STUFF((
						  SELECT ',' + U.Nombre
						  from Desgloses   as D 
							INNER JOIN Ubicaciones AS U ON U.Id = D.Ubicacion 
							where D.Orden = O.Id
							order by D.Id  desc
						  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') as Destinos


				, case O.Estado 
					when 0 then 'Pendiente'
					when 1 then 'Procesando'
					when 2 then 'Retenida'
					when 3 then 'Iniciando'
					when 4 then 'Eliminada'
					when 5 then 'Detenida'
					when 6 then 'Finalizada'
					when 7 then 'Interrumpida'
					when 8 then 'Forzada'
					else 'Desconocido'
					end as Estado
		
				, cast(O.Inicio as time)  as Inicio
				, cast(O.Fin as time)  as Fin  
				, Case O.Modificada
					when 1 then 'Si'
					when 0 then 'No'
					end as Modificada

				 from Ordenes as O
				 inner join CabOrdenes as CO on O.IdCab = CO.id 
				 left outer join Series as S on S.Id = O.Serie 
				 left outer join Productos as P on O.ProductoDestino  = P.Id 
				 left outer join Modulos as M on M.Id = O.Modulo 
				 left outer join Lotes as L on O.LoteDestino = L.Id 
				 left outer join Formulas as F on O.Formula = F.Id  
 
				 --left outer join Ubicaciones as UOri on UOri .Id = O.
				 ;
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ListaResultados] as 
				select 
				R.Id
				, R.Serie
				, R.Orden 
				, R.Ciclo 
				, P.Nombre as Producto
				, P.Referencia as Referencia
				, P.Referencia2 as Referencia2
				, U.Nombre  as Ubicacion
				, R.Cantidad 
				, R.CantidadPrincipal 
				, R.Inicio 
				, R.Fin 
				, L.Nombre as Lote
				, R.PosicionDosificacion 
				, M.Nombre as Medidor
				, Mo.OrdenProduccion as ModuloOrdenacion
				, Mo.Nombre as Modulo 
				, case R.Estado
					when 0 then 'Pendiente'
					when 1 then 'Registrado'
					when 2 then 'Regularizado'
					when 3 then 'Desglosado'
					when 4 then 'Modificado'
					when 5 then 'Agregado Manualmente'
					end as Estado

				from Resultados as R

				left outer join Productos as P on P.Id = R.Producto 
				left outer join Ubicaciones as U on U.Id = R.Ubicacion 
				left outer join Lotes as L on L.Id = R.Lote 
				left outer join Medidores as M on M.Id = R.Medidor 
				left outer join Modulos  as Mo on Mo.Id = M.Modulo 
				;
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[LoteClienteDomicilio]
				AS
				select 
				l.Id AS IdLote,
				min(o.Id) as idorden,
				MIN(s.id) as idsalida,
				min(c.Nombre) AS Cliente,
				min(d.Nombre) AS Domicilio,
				min(d.Direccion) AS Direccion,
				SUM(r.Cantidad) AS TotalServido,
				MIN(s.Codigo ) as NumeroSalida,
				MIN(d.MarcaOficial) as MarcaOficial,
				sl.id as idlinea
				 from Resultados as r
				LEFT OUTER JOIN dbo.Lotes AS l ON l.Id = r.Lote
				LEFT OUTER JOIN dbo.Ordenes AS o ON o.Id = r.Orden
				LEFT OUTER JOIN dbo.Salidas AS s ON s.Id = o.Salida
				LEFT OUTER JOIN dbo.SalidasLinias AS sl ON sl.Id = o.LineaSalida
				LEFT OUTER JOIN dbo.Clientes AS c ON c.Id = s.idCliente
				LEFT OUTER JOIN dbo.Domicilios AS d ON d.Id = sl.idDomicilio

				 --where r.Lote = 35768
				 group by sl.Id , l.Id ;
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[LoteProveedor]
				AS
				select 
					l.id as IdLote
					, isnull(pl.Nombre, p.Nombre  ) as Proveedor
					, isnull(isnull(l.CantidadPedida, sum(D.Cantidad)), el.CantidadPedida) as TotalRecibido,
							STUFF((
						  SELECT distinct ' - ' + elo.LoteProveedor
						  from EntradasLotes  as elo, EntradasLineas el2
							WHERE elo.IdEntradasLineas = el2.id AND el2.Lote = l.Id
						  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 3, '') as LotesProveedor
				from Lotes as l
				left outer join Proveedores as pl on pl.Id = l.IdProveedor 
				left outer join EntradasLineas as el on el.Lote = l.Id
				left outer join Entradas as e on e.id = el.idEntradas  
				LEFT OUTER JOIN Proveedores AS p ON p.Id = e.idProveedor
				left outer join Ordenes as O on O.LineaEntrada = el.id 
				left outer join Desgloses as D on D.Orden = O.Id 
				group by l.Id , pl.Nombre, p.Nombre, el.CantidadPedida, l.CantidadPedida
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[LoteProveedorNOCantidad]
				AS
				SELECT 
					l.id as IdLote
					, isnull(pl.Nombre, p.Nombre  ) as Proveedor
							,STUFF((
						  SELECT distinct ' - ' + elo.LoteProveedor
						  FROM EntradasLotes  as elo, EntradasLineas el2
							WHERE elo.IdEntradasLineas = el2.id AND el2.Lote = l.Id
						  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 3, '') AS LotesProveedor
				FROM Lotes as l
				LEFT OUTER JOIN Proveedores as pl on pl.Id = l.IdProveedor 
				LEFT OUTER JOIN EntradasLineas as el on el.Lote = l.Id
				LEFT OUTER JOIN Entradas as e on e.id = el.idEntradas  
				LEFT OUTER JOIN Proveedores AS p ON p.Id = e.idProveedor
				LEFT OUTER JOIN Ordenes as O on O.LineaEntrada = el.id 
				LEFT OUTER JOIN Desgloses as D on D.Orden = O.Id 

				GROUP BY l.Id , pl.Nombre, p.Nombre
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[OrdenesDetalle]
				AS

				SELECT        
				MIN(o.Nombre) AS NombreOrden, 
				o.Id, MIN(c.Nombre) AS NombreCabecera, 
				MIN(m.Nombre) AS NombreModulo, 
				CONVERT(date, o.Fecha) AS Fecha, 
				o.NumeroCiclos, 
				p.Nombre AS NombreProducto, 
				un.Nombre AS NombreUnidad,
				l.Nombre AS NombreLote,
				ROUND ((SELECT ISNULL(SUM(Cantidad),0)
						FROM Dosificaciones AS d
						WHERE d.Orden = o.Id), 3) AS CantidadTCiclo,
				ROUND ((SELECT ISNULL(SUM(Cantidad),0)
						FROM Dosificaciones AS d
						WHERE d.Orden = o.Id) * o.NumeroCiclos, 3) AS CantidadTOrden

				FROM            dbo.Ordenes		AS o 
				LEFT OUTER JOIN dbo.Productos	AS p	ON p.Id = o.ProductoDestino
				LEFT OUTER JOIN dbo.Lotes		AS l	ON l.Id = o.LoteDestino
				INNER JOIN      dbo.CabOrdenes	AS c	ON c.Id = o.IdCab
				LEFT OUTER JOIN dbo.Modulos		AS m	ON m.Id = o.Modulo
				LEFT OUTER JOIN dbo.Unidades	AS un	ON un.Id = p.Unidad

				GROUP BY o.Id, o.Fecha, o.NumeroCiclos, p.Nombre, l.Nombre, un.Nombre
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[PivotProduccion]
				AS

				--Resgistrs de resultados para ver lo que se ha consumido realmente

				SELECT O.Id ,O.Nombre, O.Fecha , O.Serie    
				, P2.Nombre as NombreProductoFinal
				, P.Nombre as NombreProducto
				, D.Producto as CodProducto
				, D.Cantidad as CantidadTeorica 
				, D.Ubicacion as CodUbicacionTeorica
				, U1.Nombre as NombreUbicacionTeorica
				, R.Ciclo as NCiclo
				, R.Cantidad as CantidadReal
				, R.Ubicacion as CodUbicacionReal
				, U2.Nombre as NombreUbicacionReal
				, Med.Nombre as Medidor
				, M.Nombre as Modulo
				, M.TipoModulo as TipoModulo
				, R.Orden  as IdOrden
				, P2.Referencia as ReferenciaProductoFinal
				, P.Referencia as ReferenciaIngrediente
				, R.Inicio as Inicio
				, R.Fin as Fin
				, R.TiempoEfectivo as TiempoEfectivo
				, R.TiempoTotal as TiempoTotal
				, R.LoteNombre as LoteIngrediente
				, R.Lote as IdLoteIngrediente
				, R.KwhEfectivo as kwhEfectivo
				, R.KWhTotal as KwhTotal
				, R.Temperatura as Temperatura
				, R.Humedad as Humedad
				, R.TimeStamp as FechaConsumido
				, P.Tipo AS TipoProducto
				, P2.Tipo AS TipoProductoFinal
				, ISNULL(R.Id,-1) as IdConsumido
				, ISNULL (D.Id,-1) as IdDosificacion
				--, ISNULL(ROW_NUMBER() OVER(ORDER BY O.Fecha DESC), -1) AS RowID
				,ISNULL(ROW_NUMBER() OVER(ORDER BY (SELECT NULL)),-1) AS RowID

				from Resultados as R
				left outer join Medidores   as Med on Med.Id = R.Medidor  
				left outer join Modulos   as M on M.Id = Med.Modulo 
				left outer join Dosificaciones as D on D.Id = R.IdDosificacion
				inner join Ordenes as O on R.Orden = O.Id 

				--canvi [05/11/2020]-----------------------------
				--inner join Productos as P on D.Producto = P.Id 
				inner join Productos as P on R.Producto = P.Id 
				-------------------------------------------------

				left outer join Productos as P2 on O.ProductoDestino  = P2.Id 
				left outer join Ubicaciones as U1 on D.Ubicacion = U1.Id 
				left outer join Ubicaciones as U2 on R.Ubicacion = U2.Id 

				where (O.estado=5 or O.estado=20) and R.Cantidad is not null
				--where O.Modulo = 6 


				union

				--Dosificaciones que no han tenido registros de resultados... como hay valores de origen, hay que tenerlos en cuenta...
				-- para los valores teoricos

				SELECT O.Id ,O.Nombre, O.Fecha , O.Serie    
				, P2.Nombre as NombreProductoFinal
				, P.Nombre 
				, D.Producto 
				, D.Cantidad 
				, D.Ubicacion as CodUbicacionTeorica
				, U1.Nombre 
				, 0
				, 0
				, 0 
				, ''
				, Med.Nombre as Medidor
				, M.Nombre as Modulo
				, M.TipoModulo as TipoModulo
				, D.Orden  as IdOrden
				, P2.Referencia as ReferenciaProductoFinal
				, '' as ReferenciaIngrediente
				, null as Inicio
				, null as Fin
				, null as TiempoEfectivo
				, null as TiempoTotal
				, '' as LoteIngrediente
				, null as IdLoteIngrediente
				, null as kwhEfectivo
				, null as KwhTotal
				, null as Temperatura
				, null as Humedad
				, null as FechaConsumido
				, P.Tipo AS TipoProducto
				, P2.Tipo AS TipoProductoFinal
				, null as IdConsumido
				, D.Id as IdDosificacion
				--, ISNULL(ROW_NUMBER() OVER(ORDER BY O.Fecha DESC), -1) AS RowID
				,ISNULL(ROW_NUMBER() OVER(ORDER BY (SELECT NULL)),-1) AS RowID

				from Dosificaciones  as D
				left outer join Resultados  as R on D.Orden = R.Orden and D.Producto = R.Producto 
				left outer join Medidores   as Med on Med.Id = D.Medidor 
				left outer join Modulos   as M on M.Id = D.IdModulo 

				inner join Ordenes as O on D.Orden = O.Id 
				inner join Productos as P on D.Producto = P.Id 
				left outer join Productos as P2 on O.ProductoDestino  = P2.Id 
				inner join Ubicaciones as U1 on D.Ubicacion = U1.Id 

				where (O.estado=5 or O.estado=20) and R.id is null
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[PivotProduccionProducidos]
				as
				select 
					O.Id  as IdOrden	
					, O.Nombre as NombreOrden
					, O.Fecha as FechaOrden
					, O.Inicio as FechaInicioOrden
					, O.Fin as FechaFinOrden
					, O.Caminos as CaminoOrden
					, O.NumeroCiclos as CiclosOrden
					, O.Cantidad as CantidadOrdenCiclo
					, O.Cantidad * O.NumeroCiclos as CantidadTotalOrden
					, case O.Estado
						when 5 then 'Finalizada'
						when 20 then 'Cancelada'
						else ''
						 end as EstadoOrden
					, O.Formula as IdFormual
					, F.Nombre as NombreFormula
					, O.[Version] as IdVersionFormula
					, V.Nombre as NombreVersion
					, Med.Nombre as Medidor
					, M.Nombre as Modulo
					, P.Nombre as NombreProductoProducido
					, P.Referencia as RefProductoProducido
					, P2.Nombre as NombreProductoOrden
					, P2.Referencia as RefProductoOrden
					, U1.Nombre as NombreDestino
					, D.Cantidad as Cantidad
					, D.TiempoEfectivo  as TiempoEfectivo
					, D.TiempoTotal as TiempoTotal
					, D.KWhEfectivo as KwhEfectivo
					, D.KWhTotal as KwhTotal
					, D.Temperatura as Temperatura
					, D.Humedad as Humedad
					, D.Ciclo as Ciclo
					, D.Lote as IdLoteProducido
					, L.Nombre as NombreLoteProducido
					, D.Fecha as FechaProducido
					, P.Tipo AS TipoProducto
					, ISNULL(D.Id,-1) as IdProducido
					--, ISNULL(ROW_NUMBER() OVER(ORDER BY O.Fecha DESC), -1) AS RowID
					,ISNULL(ROW_NUMBER() OVER(ORDER BY (SELECT NULL)),-1) AS RowID
	



				from Desgloses as D
					left outer join Medidores   as Med on Med.Id = D.MedidorId 
					left outer join Modulos   as M on M.Id = Med.Modulo 
					inner join Ordenes as O on D.Orden = O.Id 
					inner join Productos as P on D.Producto = P.Id 
					left outer join Productos as P2 on O.ProductoDestino  = P2.Id --Producto original de la orden.
					left outer join Ubicaciones as U1 on D.Ubicacion = U1.Id 
					left outer join Formulas as F on F.Id = O.Formula 
					left outer join Versiones as V on V.Id = O.[Version] 
					left outer join Lotes as L on L.Id = D.Lote 
				where (O.estado=5 or O.estado=20)
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ProducidoOrden]
				AS
 
					SELECT       
					o.Modulo,
					o.Id, 
					o.Fecha,
					p.Id AS IdProducto,
					p.Nombre AS NombreProducto, 
					p.PartidaArancelariaFabricacion,
					l.Id AS IdLote,
					l.Nombre AS NombreLote,
					ROUND ((SELECT ISNULL(SUM(Cantidad),0)
							FROM Desgloses AS d
							WHERE d.Orden = o.Id), 0) AS CantidadProducida,
					un.Nombre AS NombreUnidad,
					u.Nombre AS UbicacionDestino

					FROM            dbo.Ordenes		AS o 
					LEFT OUTER JOIN dbo.Productos	AS p	ON p.Id = o.ProductoDestino
					LEFT OUTER JOIN dbo.Lotes		AS l	ON l.Id = o.LoteDestino
					LEFT OUTER JOIN dbo.Unidades	AS un	ON un.Id = p.Unidad
					LEFT OUTER JOIN dbo.Disposiciones AS d  ON d.Orden = o.Id 
					LEFT OUTER JOIN dbo.Ubicaciones AS u    ON d.Ubicacion = u.Id 

					WHERE o.Modulo  = 12
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ProducidoConsumidoOrden]
				AS
					SELECT 
					PO.Id,
					PO.Fecha,
					PO.IdProducto,
					PO.NombreProducto,
					PO.IdLote,
					PO.NombreLote,
					PO.CantidadProducida,
					PO.NombreUnidad AS UdProd,
					PO.UbicacionDestino,
					--PO.PartidaArancelariaFabricacion,
					ROUND(SUM(CO.Cantidad), 3) AS TotalDosificado,
					CO.UnidadNombre AS UdCons,
					CO.Producto AS IdProDosi,
					CO.PartidaArancelariaCompras,
					CO.PartidaArancelariaFabricacion,
					CO.Lote AS IdLoteDosi
	
					FROM dbo.ProducidoOrden AS PO
					LEFT OUTER JOIN dbo.ConsumidoOrden AS CO ON PO.Id = CO.IdOrden

					--WHERE CO.Producto = 302 AND CO.Lote = 206460

					GROUP BY 
						PO.Id,
						PO.Fecha,
						PO.IdProducto,
						PO.NombreProducto,
						PO.IdLote,
						PO.NombreLote,
						PO.CantidadProducida,
						PO.NombreUnidad,
						PO.UbicacionDestino,
						--PO.PartidaArancelariaFabricacion,
						CO.UnidadNombre,
						CO.Producto,
						CO.Lote,
						CO.PartidaArancelariaCompras,
						CO.PartidaArancelariaFabricacion
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[TotalCantidadPorOrden]
				AS

				SELECT 

				o.Id AS IdOrden,
				SUM(r.Cantidad) AS Total

				FROM			dbo.Resultados	AS r
				LEFT OUTER JOIN dbo.Ordenes		AS o  ON o.Id = r.Orden

				GROUP BY o.Id
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[TotalProducidoPorOrden]
				AS
 
				SELECT 

				o.Id AS IdOrden,
				SUM(d.Cantidad) AS Total

				FROM dbo.Desgloses AS d
				LEFT OUTER JOIN dbo.Ordenes AS o  ON o.Id = d.Orden

				GROUP BY o.Id
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ProductoLotePrimerNivel]
				AS

				SELECT 

				o.Id AS IdOrden,
				MIN(o.Nombre) AS Orden, 
				p.Id AS Producto,
				MIN(p.Nombre) AS NombreProducto,
				MIN(p.Referencia) AS RefProducto,
				o.LoteDestino AS Lote,
				MIN(l.Nombre) AS NombreLote,
				r.Producto AS ProductoOrigen,
				MIN(p2.Nombre) AS NombreProductoOrigen,
				MIN(p2.Referencia) as RefProductoOrigen,
				r.Lote as LoteOrigen,
				MIN(l2.Nombre) AS NombreLoteOrigen,
				SUM(r.Cantidad) AS Total,
				MIN(t.Total) AS TotalOrden,
				MIN(t2.Total) AS TotalProducidoOrden,
				1 AS Nivel 

				FROM			dbo.Resultados	AS r
				LEFT OUTER JOIN dbo.Ordenes		AS o  ON o.Id = r.Orden
				left outer join dbo.Modulos as m on o.Modulo = m.Id 
				LEFT OUTER JOIN dbo.Productos	AS p  ON p.Id = o.ProductoDestino
				LEFT OUTER JOIN dbo.Lotes		AS l  ON l.Id = o.LoteDestino
				LEFT OUTER JOIN dbo.TotalCantidadPorOrden AS t ON o.Id = t.IdOrden
				LEFT OUTER JOIN dbo.TotalProducidoPorOrden AS t2 ON o.Id = t2.IdOrden
				LEFT OUTER JOIN dbo.Productos	AS p2  ON p2.Id = r.Producto
				LEFT OUTER JOIN dbo.Lotes		AS l2  ON l2.Id = r.Lote

				WHERE o.ProductoDestino IS NOT NULL 
					AND o.LoteDestino IS NOT NULL
					and ((m.TipoModulo >=100 and m.TipoModulo <=200) or m.TipoModulo =7)

				GROUP BY o.Id, p.Id, o.LoteDestino, r.Producto, r.Lote
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ProductoLotePrimerNivelProvCli]
				AS

				SELECT 

				o.Id AS IdOrden,
				MIN(o.Nombre) AS Orden, 
				p.Id AS Producto,
				MIN(p.Nombre) AS NombreProducto,
				MIN(p.Referencia) AS RefProducto,
				o.LoteDestino AS Lote,
				MIN(l.Nombre) AS NombreLote,
				r.Producto AS ProductoOrigen,
				MIN(p2.Nombre) AS NombreProductoOrigen,
				MIN(p2.Referencia) as RefProductoOrigen,
				r.Lote as LoteOrigen,
				MIN(l2.Nombre) AS NombreLoteOrigen,
				SUM(r.Cantidad) AS Total,
				MIN(t.Total) AS TotalOrden,
				MIN(t2.Total) AS TotalProducidoOrden,
				1 AS Nivel,
				MIN(l3.Proveedor) AS NombreProveedor,
				MIN(l3.TotalRecibido) AS TotalRecibido,
				l4.Cliente AS NombreCliente,
				l4.Direccion AS DireccionCliente,
				l4.TotalServido AS TotalServido,
				l4.Domicilio AS DomicilioCliente,
				l4.MarcaOficial AS MarcaOficial

				FROM			dbo.Resultados	AS r
				LEFT OUTER JOIN dbo.Ordenes		AS o  ON o.Id = r.Orden
				LEFT OUTER JOIN dbo.Modulos as m on o.Modulo = m.Id 
				LEFT OUTER JOIN dbo.Productos	AS p  ON p.Id = o.ProductoDestino
				LEFT OUTER JOIN dbo.Lotes		AS l  ON l.Id = o.LoteDestino
				LEFT OUTER JOIN dbo.TotalCantidadPorOrden AS t ON o.Id = t.IdOrden
				LEFT OUTER JOIN dbo.TotalProducidoPorOrden AS t2 ON o.Id = t2.IdOrden
				LEFT OUTER JOIN dbo.Productos	AS p2  ON p2.Id = r.Producto
				LEFT OUTER JOIN dbo.Lotes		AS l2  ON l2.Id = r.Lote
				LEFT OUTER JOIN dbo.LoteProveedor		AS l3  ON l3.IdLote = r.Lote
				LEFT OUTER JOIN dbo.LoteClienteDomicilio		AS l4  ON  l4.idlinea=o.LineaSalida --and l4.IdLote = o.LoteDestino   

				/* Quitados filtros ya que me quitaban la información de los viajes de camiones...*/
				--WHERE --o.ProductoDestino IS NOT NULL 
					--AND o.LoteDestino IS NOT NULL
					--and 
					--((m.TipoModulo >=100 and m.TipoModulo <=200) or m.TipoModulo =7)

				GROUP BY o.Id, p.Id, o.LoteDestino, r.Producto, r.Lote, l3.Proveedor, l3.TotalRecibido, l4.Cliente, l4.Direccion, l4.TotalServido, l4.Domicilio, l4.MarcaOficial
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[RecetasExtended] as
				select 
					R.id 
					, S.Nombre 
					, S.Fecha 
					, R.NumReceta 
					, C.Nombre as ClienteNombre
					, D.Nombre as DomicilioNombre
					, D.Direccion 
					, D.CodigoPostal 
					, D.Poblacion 
					, PD.Nombre  as DomicilioProvincia
					, D.Especie
					, D.NumeroEspecies 
					, D.Simogan 
					, D.REGA 
					, D.MarcaOficial 
					, A.Nombre as Afeccion
					, A.Referencia as RefAfeccion
					, R.Indicaciones 
					, R.Frecuencia 
					, R.Duracion 
					, R.TiempoEspera 
					, R.Conservacion 
					, R.Observaciones 
					, R.NaturalezaTratamiento 
					, R.TiempoEsperaLeche 
					, R.TiempoEsperaHuevos 
					, R.NumRegistro 
					, V.Nombre as VeterinarioNombre
					, V.Apellidos as VeterinarioApellidos
					, V.NColegiado as VeterinarioNColegiado
					, E.Nombre as EmpresaNombre
					, E.Autorizacion as EmpresaAutorizacion
					, E.Direccion as EmpresaDireccion
					, E.Poblacion as EmpresaPoblacion
					, E.CodigoPostal as EmpresaCodPostal
					, E.Provincia as EmpresaProvincia
					, R.CantidadPienso
					, P.Nombre as ProductoNombre
					, P.Referencia as ProductoRef
					, P.Referencia2 as ProductoRef2
					, R.proporcionDiaria

				from Recetas as R
				left outer join Series as S on R.idSerie = S.Id 
				left outer join Clientes  as C on R.idCliente  = C.Id 
				left outer join Domicilios   as D on R.idDomicilio   = D.Id 
				left outer join Provincias     as PD on D.Provincia     = PD.Id 
				left outer join Afecciones    as A on R.idAfeccion    = A.Id 
				left outer join Veterinarios    as V on R.idveterinario    = V.id
				left outer join Empresas    as E on V.idEmpresa    = E.Id 
				left outer join Productos   as P on R.idProducto= P.id
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[RecetasLineasExtended] as
				select 
					RL.idReceta 
					, RL.Cantidad 
					, RL.Porcentaje   
					, M.Nombre as Medicamento
					, M.Referencia as RefMedicamento
					, P.Nombre as Producto
					, P.Referencia as RefProducto
					, P.Referencia2 as RefProducto2
					, P.NumeroRegistro 

				from RecetasLineas as RL
				left outer join Medicaciones  as M on M.Id = RL.idMedicamento 
				left outer join Productos  as P on P.Id = M.idProducto
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[recursivo] as
				WITH VistaProductos (ProductoDest, LoteDest, ProductoOrig, LoteOrig, OrdenProd, NivelProducto)
				AS
				(
				SELECT 

				Producto,
				Lote,
				ProductoOrigen,
				LoteOrigen,
				Orden,
				0 as NivelProducto
	   
				FROM 

				ProductoLotePrimerNivel AS pl

				--WHERE pl.Nivel = 1 AND ProductoOrigen = 24 AND LoteOrigen = 2505

				UNION ALL

				SELECT 

				Producto,
				Lote,
				ProductoOrigen,
				LoteOrigen,
				Orden,
				NivelProducto + 1
	   
				FROM 

				ProductoLotePrimerNivel AS pl

				INNER JOIN VistaProductos as v
				ON pl.ProductoOrigen = v.ProductoDest AND pl.LoteOrigen = v.LoteDest

				)

				SELECT * 
				FROM VistaProductos
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ResultadosDetalle]
				AS

				SELECT        
				r.Orden, 
				r.Cantidad, 
				m.Nombre AS NombreMedidor, 
				un.Nombre AS NombreUnidad, 
				u.Nombre AS NombreUbicacion, 
				p.Nombre AS NombreProducto, 
				r.PosicionDosificacion, 
				l.Nombre AS NombreLote, 
				r.Ciclo,
				d.Cantidad AS CantidadTeorica,
				p.DesviacionMaxima AS DesviacionProducto,
				p.Id AS Producto

				FROM            dbo.Resultados	AS r
				LEFT OUTER JOIN dbo.Lotes		AS l  ON l.Id = r.Lote
				LEFT OUTER JOIN dbo.Productos	AS p  ON p.Id = r.Producto 
				LEFT OUTER JOIN dbo.Ubicaciones AS u  ON u.Id = r.Ubicacion 
				LEFT OUTER JOIN dbo.Medidores	AS m  ON m.Id = r.Medidor 
				LEFT OUTER JOIN dbo.Unidades	AS un ON un.Id = r.Unidad
				LEFT OUTER JOIN dbo.Dosificaciones AS d ON d.PosicionDosificacion = r.PosicionDosificacion

				WHERE d.Orden = r.Orden
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ResultadosExtended] AS 
				SELECT
					Res.Id,
					Res.Orden AS IdOrden,
					orden.Entrada AS IdEntradaOrden,
					orden.LineaEntrada AS IdLineaEntradaOrden,
					orden.Salida AS IdSalidaOrden,
					orden.LineaSalida AS IdLineaSalidaOrden,
					SalLin.idviajes AS IdViajeLineaSalidaOrden,
					Res.Pesada,
					Res.Ubicacion,
					Ubi.Nombre AS UbicacionNombre,
					Ubi.Referencia AS UbicacionReferencia,
					Res.Cantidad,
					Res.Parcial,
					Res.Proceso,
					Res.Estado,
					Res.Inicio,
					Res.Fin,
					Res.Lote,
					L.Nombre AS LoteNombre,
					L.Referencia AS LoteReferencia,
					Res.Producto,
					P.Nombre AS ProductoNombre,
					P.Referencia AS ProductoReferencia,
					P.Referencia2 AS ProductoReferencia2,
					P.Tipo AS ProductoTipo,
					Res.Ciclo,
					Res.Medidor,
					Med.Nombre AS MedidorNombre,
					Res.Unidad,
					Uni.Nombre AS UnidadNombre,
					Res.CantidadPrincipal,
					Res.PosicionDosificacion,
					Res.NumCorreccion,
					Res.Destino,
					UbiDest.Nombre AS DestinoNombre,
					Res.Temperatura,
					Res.Humedad,
					Res.Ph,
					Res.TiempoEfectivo,
					Res.TiempoTotal,
					Res.KwhEfectivo,
					Res.KWhTotal,
					Res.IndicadorId,
					Res.MultiDosiId,
					Res.TotalCiclos,
					Res.idUsuario,
					Usu.Nombre AS UsuarioNombre,
					Res.Editado,
					modulo.TipoModulo AS ModuloTipo
				FROM
					Resultados AS Res
				 LEFT OUTER JOIN 
					Ubicaciones AS Ubi ON Ubi.Id = Res.Ubicacion 
				LEFT OUTER JOIN 
					Lotes AS L ON L.Id = Res.Lote 
				LEFT OUTER JOIN 
					Productos AS P ON P.Id = Res.Producto 
				LEFT OUTER JOIN 
					Medidores AS Med ON Med.Id = Res.Medidor 
				LEFT OUTER JOIN 
					Unidades AS Uni ON Uni.Id = Res.Unidad
				 LEFT OUTER JOIN 
					Ubicaciones AS UbiDest ON UbiDest.Id = Res.Destino
				 LEFT OUTER JOIN 
					Usuarios AS Usu ON Usu.Id = Res.idUsuario 
				INNER JOIN 
					Ordenes orden ON Res.Orden = orden.Id 
				INNER JOIN
					Modulos modulo ON orden.Modulo = modulo.Id
				LEFT OUTER JOIN 
					SalidasLinias AS SalLin ON SalLin.id = orden.LineaSalida
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ResultadosOrdenAgrupado] as
				select r.Orden , r.IdDosificacion , r.Producto , SUM(r.cantidad) as cantidad, min(d.PosicionDosificacion  ) as posicion
					, MIN(p.nombre) as ProductoNombre, r.Lote , min(l.Nombre ) as LoteNombre, min(p.Referencia) as RefProducto
				from Resultados as r
				left outer join dosificaciones as d on d.Id = r.IdDosificacion 
				left outer join productos as p on p.id= r.producto
				left outer join Lotes as l on l.Id= r.lote

				--where r.Orden = 28895
				group by r.Orden , r.IdDosificacion , r.Producto , r.Lote 
				--order by min(d.posicionDosificacion)
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[ResultadosPorDiaOrden]
				AS
				SELECT        R.Serie, R.Orden AS IdOrden, R.Producto AS ProductoId, MIN(P.Nombre) AS NombreProducto, CONVERT(date, R.Inicio) AS fecha, ROUND(SUM(R.Cantidad), 3) AS cantidad, MIN(P.Referencia) AS RefProducto, 
										 MIN(L.Nombre) AS Lote
				FROM            dbo.Resultados AS R LEFT OUTER JOIN
										 dbo.Productos AS P ON P.Id = R.Producto LEFT OUTER JOIN
										 dbo.Ordenes AS O ON O.Id = R.Orden AND O.Serie = R.Serie LEFT OUTER JOIN
										 dbo.Lotes AS L ON R.Lote = L.Id
				GROUP BY R.Producto, CONVERT(date, R.Inicio), R.Orden, R.Serie, L.Id
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[SalidaLiniasReduced]
				AS

				SELECT        
				s.Id, 
				p.Nombre AS NombreProducto, 
				ROUND(s.Cantidad, 3) AS Cantidad,
				un.Nombre AS NombreUnidad,
				ISNULL(ROUND(s.Bultos,0),0) AS Bultos,
				f.Nombre AS NombreFormato,
				e.Nombre AS NombreEnvase, 

				ISNULL(STUFF(Iif(s.Origen1 IS NULL, '', CONCAT('-',(SELECT u.Nombre FROM Ubicaciones u WHERE u.Id = s.Origen1))) +
				Iif(s.Origen2 IS NULL, '', CONCAT('-', (SELECT u.Nombre FROM Ubicaciones u WHERE u.Id = s.Origen2))) +
				Iif(s.Origen3 IS NULL, '', CONCAT('-', (SELECT u.Nombre FROM Ubicaciones u WHERE u.Id = s.Origen3))) +
				Iif(s.Origen4 IS NULL, '', CONCAT('-', (SELECT u.Nombre FROM Ubicaciones u WHERE u.Id = s.Origen4))), 1, 1, ''), '') AS Origenes,

				ISNULL(STUFF(Iif(s.Cajon1 = 1, '-C1', '') +
				Iif(s.Cajon2 = 1, '-C2', '') +
				Iif(s.Cajon3 = 1, '-C3', '') +
				Iif(s.Cajon4 = 1, '-C4', '') +
				Iif(s.Cajon5 = 1, '-C5', '') +
				Iif(s.Cajon6 = 1, '-C6', '') + 
				Iif(s.Cajon7 = 1, '-C7', '') + 
				Iif(s.Cajon8 = 1, '-C8', '') + 
				Iif(s.Cajon9 = 1, '-C9', '') + 
				Iif(s.Cajon10 = 1, '-C10', ''), 1, 1,''),'') AS Cajones

				FROM            dbo.SalidasLinias		AS s 
				LEFT OUTER JOIN dbo.Productos	AS p	ON p.Id = s.idProducto
				LEFT OUTER JOIN dbo.Envases		AS e	ON e.Id = s.idEnvase
				LEFT OUTER JOIN dbo.Formatos	AS f	ON f.Id = s.idFormato
				LEFT OUTER JOIN dbo.Unidades	AS un   ON un.Id = s.idUnidad
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[SalidasExtended]
				AS
					SELECT Sali.id
					  , Sali.idSerie
						, Serie.Nombre AS SerieNombre
					  , Sali.Codigo
					  , Sali.Referencia
					  , Sali.IdDepartamento
						, Depar.Nombre AS DepartamentoNombre
					  , Sali.Fecha
					  , Sali.idCliente
						, Cli.Nombre AS ClienteNombre
						, Cli.Referencia AS ClienteReferencia
						, Cli.RazonSocial AS ClienteRazonSocial
						, Cli.CIF AS ClienteCIF
						, Cli.Direccion AS ClienteDireccion
						, Cli.CodigoPostal AS ClienteCodigoPostal
						, Cli.Poblacion AS ClientePoblacion
						, Cli.Provincia AS ClienteProvincia
							, Provi.Nombre AS ClienteProvicinaNombre
						, Cli.Pais AS ClientePais
							, Pais.Nombre AS ClientePaisNombre
						, Cli.Telefono AS ClienteTelefono
						, Cli.Inhabilitado AS ClienteInhabilitado
							, dbo.GetTextoParametro('Clientes', 'Inhabilitado', Cli.Inhabilitado) AS ClienteInhabilitadoStr
					  , Sali.Estado
						, dbo.GetTextoParametro('Salidas', 'Estado', Sali.Estado) AS EstadoStr
					  , Sali.Comentario
					  , Sali.FechaPrevista
					  , Sali.FInicio AS FechaInicio
					  , Sali.FFin AS FechaFin
					  , Sali.Precio
					  , NULL AS IdMoneda
						, NULL AS MonedaNombre  -- en previsión de que se añada
						, NULL AS MonedaSimbolo  -- en previsión de que se añada
					  , Sali.Observaciones
				  FROM dbo.Salidas AS Sali
					LEFT OUTER JOIN Series AS Serie ON Serie.Id = Sali.idSerie 
					LEFT OUTER JOIN Departamentos AS Depar ON Depar.Id = Sali.IdDepartamento
					LEFT OUTER JOIN Clientes AS Cli ON Cli.Id = Sali.IdCliente
						LEFT OUTER JOIN Provincias AS Provi ON Provi.Id = Cli.Provincia AND Provi.Pais = Cli.Pais 
						LEFT OUTER JOIN Paises AS Pais ON Pais.Id = Cli.Pais
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[SalidasInformeAduanas]
				AS

					SELECT 
					sv.Numero AS Viaje,
					s.id AS IdSalida,
					s.FInicio AS Fecha,
					c.Id AS IdCliente,
					c.Nombre AS NombreCliente,
					c.CIF AS CIFCliente,
					sl.idProducto,
					p.Nombre AS NombreProducto,
					e.id AS IdEmpTransport,
					e.Nombre AS NombreEmpTransport,
					e.CIF AS CIFEmpTransport,
					ch.id AS IdChofer,
					ch.Nombre AS NombreChofer,
					ch.CIF AS CIFChofer,
					ROUND(SUM(r.Cantidad),0) AS Servida,
					r.Lote AS IdLote,
					l.Nombre AS NombreLote


					FROM			dbo.Salidas AS				s
					LEFT OUTER JOIN	dbo.Clientes AS				c	ON s.idCliente = c.Id 
					LEFT OUTER JOIN	dbo.SalidasLinias AS		sl	ON sl.idSalidas = s.id 
					LEFT OUTER JOIN	dbo.SalidasLiniasLote AS	sll ON sll.idLineaSalida = sl.id 
					LEFT OUTER JOIN	dbo.Productos AS			p   ON sl.idProducto = p.Id 
					LEFT OUTER JOIN	dbo.SalidasViajes AS		sv  ON sl.idviajes = sv.id 
					LEFT OUTER JOIN dbo.EmpresasTransporte AS   e	ON sv.idEmpresaTransporte = e.id 
					LEFT OUTER JOIN dbo.Choferes AS				ch	ON sv.idChofer = ch.id 
					LEFT OUTER JOIN dbo.Ordenes AS				o	ON sl.idSalidas = o.Salida
					LEFT OUTER JOIN dbo.Resultados AS			r	ON r.Orden = o.id 
					LEFT OUTER JOIN	dbo.Lotes AS				l	ON r.Lote = l.id

					GROUP BY
					sv.Numero,
					s.id,
					s.FInicio,
					c.Id,
					c.Nombre,
					c.CIF,
					sl.idProducto,
					p.Nombre,
					r.Lote, 
					l.Nombre,
					sll.Cantidad,
					e.id,
					e.Nombre,
					e.CIF,
					ch.id,
					ch.Nombre,
					ch.CIF
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[SalidasLineasLoteExtended]
				AS
				 SELECT SLL.id
					  , SLL.idLineaSalida
					  , SLL.idLineaSalidaMedicamento
					  , SLL.idLote
						, L.Nombre AS LoteNombre
						, L.Referencia AS LoteReferencia
						, L.Producto AS LoteIdProducto  -- debería coincidir con su Lineasalida.Producto correspondiente
							, P.Nombre AS LoteProductoNombre
							, P.Referencia AS LoteProductoReferencia
						, L.Caducidad AS LoteCaducidad
					  , SLL.Cantidad
						, NULL AS idUnidad
						, NULL AS UnidadStr
					  , SLL.Fecha
				  FROM dbo.SalidasLiniasLote AS SLL
					LEFT OUTER JOIN Lotes AS L ON L.Id = SLL.idLote
					LEFT OUTER JOIN Productos AS P ON P.Id = L.Producto
				  WHERE NOT (SLL.idLineaSalida IS NOT NULL AND SLL.idLineaSalidaMedicamento IS NOT NULL)  -- filtramos los resultados que tengan doble id (no permitido, sería un grave error de datos)
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[SalidasLineasResultados]
					AS

					SELECT Res.Orden
					, SUM(Res.Cantidad) AS CantidadTotal
					, Lot.Nombre AS LoteNombre
					, Lot.Caducidad 
					, Uni.Nombre AS UnidadTexto
					FROM dbo.Resultados AS Res 
					LEFT OUTER JOIN Lotes AS Lot ON Res.Lote = Lot.Id
					LEFT OUTER JOIN Unidades AS Uni ON Res.Unidad = Uni.id 
					LEFT OUTER JOIN Ubicaciones AS Ubi ON Res.Ubicacion = Ubi.Id
					GROUP BY Res.Orden, Lot.Nombre, Lot.Caducidad, Uni.Nombre
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[SalidasLiniasMedicacionesExtended]
				AS
					SELECT SLM.id
					  , SLM.idSalidaLinia
					  , SLM.idMedicamento
						, Medi.Nombre AS MedicamentoNombre
						, Medi.Referencia AS MedicamentoReferencia
				--		, Medi.Cliente AS MedicacionIdCliente  -- hay medicaciones que se pueden dar de alta específicamente para un cliente concreto
					  , SLM.Cantidad
					  , SLM.IdUnidad
						, Uni.Nombre AS UnidadTexto
					  , SLM.Bultos
					  , SLM.idFormato
						, Form.Nombre AS FormatoNombre
						, Form.Descripcion AS FormatoDescripcion
					  , SLM.idEnvase
						, Enva.Nombre AS EnvaseNombre
					  , SLM.PrecioUnidad
						, NULL AS IdMonedaPrecioUnidad
						, NULL AS MonedaPrecioUnidadStr
					  , SLM.Estado
						, dbo.GetTextoParametro('SalidasLiniasMedicaciones', 'Estado', SLM.Estado) AS EstadoStr
					  , SLM.Precio
						, NULL AS IdMonedaPrecio
						, NULL AS MonedaPrecioStr
					  , SLM.Fecha
					  , SLM.idOrigen
						, UbiOrig.Nombre AS OrigenNombre
				  FROM dbo.SalidasLiniasMedicaciones AS SLM
					LEFT OUTER JOIN Medicaciones AS Medi ON Medi.Id = SLM.idMedicamento
					LEFT OUTER JOIN Ubicaciones AS UbiOrig ON UbiOrig.Id = SLM.idOrigen
					LEFT OUTER JOIN Unidades AS Uni ON Uni.Id = SLM.IdUnidad
					LEFT OUTER JOIN Envases AS Enva ON Enva.Id = SLM.IdEnvase
					LEFT OUTER JOIN Formatos AS Form ON Form.Id = SLM.IdFormato
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[SalidasLotesServidos]
				AS

					SELECT   
					o.Id as Orden,
					o.Salida,
					p.Id AS IdProducto,
					p.Nombre AS NombreProducto, 
					l.Id AS IdLote,
					l.Nombre AS NombreLote,
					SUM(r.Cantidad) AS CantidadServida,
					un.Nombre AS NombreUnidad,
					sl.Id AS LineaSalida,
					l.Caducidad AS CaducidadLote

					FROM            
					 dbo.Ordenes		AS o 
					LEFT OUTER JOIN dbo.Productos	AS p	ON p.Id = o.ProductoDestino
					LEFT OUTER JOIN dbo.Unidades	AS un	ON un.Id = p.Unidad
					LEFT OUTER JOIN dbo.Resultados	AS r	ON r.Orden = o.Id 
					LEFT OUTER JOIN dbo.Lotes		AS l	ON l.Id = r.Lote 
					LEFT OUTER JOIN dbo.SalidasLinias AS sl ON sl.Id = o.LineaSalida

					WHERE l.Id IS NOT NULL
						AND o.Salida IS NOT NULL
		
					GROUP BY o.Salida, 
							 p.Id, 
							 p.Nombre,
							 l.Id,
							 l.Nombre,
							 un.Nombre,
							 o.Id,
							 sl.Id,
							 l.Caducidad
							 UNION 

				   SELECT NULL, 
				   s2.idSalidas AS Salida,
				   s2.idProducto AS IdProducto,
				   p.Nombre AS NombreProducto,
				   s1.idLote AS IdLote,
				   l.Nombre AS NombreLote,
				   s1.Cantidad AS CantidadServida,
				   un.Nombre AS NombreUnidad,
				   s1.idLineaSalida AS LineaSalida,
				   l.Caducidad AS CaducidadLote
				   FROM SalidasLiniasLote AS s1
				   LEFT OUTER JOIN dbo.SalidasLinias AS s2 ON s2.Id = s1.idLineaSalida
				   LEFT OUTER JOIN dbo.Productos	AS p	ON p.Id = s2.idProducto
				   LEFT OUTER JOIN dbo.Unidades	AS un	ON un.Id = p.Unidad
				   LEFT OUTER JOIN dbo.Lotes AS l	ON l.Id = s1.idLote
   
				   --filtrem per agafar només les linies de sortida en estat finalitzat
				   WHERE s2.Estado = 10
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[SalidasViajesExtended]
				AS
					SELECT SV.id
					  , SV.idSerie
						, Serie.Nombre AS SerieNombre
					  , SV.Numero
					  , SV.FechaCreacion
					  , SV.idVehiculo
						, ISNULL(Vehic.Matricula, SV.MatriculaCamion) AS VehiculoMatricula
						, ISNULL(Vehic.Remolque, SV.MatriculaRemolque) AS VehiculoRemolque
						, Vehic.Referencia AS VehiculoReferencia
					  , SV.idChofer
					  , ISNULL(Chof.Nombre, SV.NombreConductor) AS ChoferNombre
					  , Chof.CIF AS ChoferCIF
					  , SV.idTarjeta
						, Tarj.Nombre AS TarjetaNombre
				--      , SV.EstadoTransito  -- no se usa
					  , SV.idEmpresaTransporte
						, EmpTrans.Nombre AS EmpresaTransporteNombre
						, EmpTrans.CIF AS EmpresaTransporteCIF
						, EmpTrans.Referencia AS EmpresaTransporteReferencia
						, EmpTrans.Direccion AS EmpresaTransporteDireccion
						, EmpTrans.CodigoPostal AS EmpresaTransporteCodigoPostal
						, EmpTrans.Poblacion AS EmpresaTransportePoblacion
						, Prov.Nombre AS EmpresaTransporteProvincia
						, EmpTrans.Telefono AS EmpresaTransporteTlf
				--      , SV.FInicioTransito
				--      , SV.FFinalTransito
					  , SV.FInicioViaje AS FechaSalidaFabrica
				--      , SV.FFinViaje  -- si hubiera control de descarga en destino o control GPS de la flota, aquí se registraría cuándo se ha finalizado el viaje
					  , SV.Referencia
					  , SV.FechaPrevista
					  , SV.Estado
						, dbo.GetTextoParametro('SalidasViajes', 'Estado', SV.Estado) AS EstadoStr
					  , SV.Observaciones
				  FROM dbo.SalidasViajes AS SV
					LEFT OUTER JOIN Series AS Serie ON Serie.Id = SV.idSerie 
					LEFT OUTER JOIN EmpresasTransporte AS EmpTrans ON EmpTrans.Id = SV.idEmpresaTransporte 
					LEFT OUTER JOIN Vehiculos AS Vehic ON Vehic.Id = SV.IdVehiculo
					LEFT OUTER JOIN Choferes AS Chof ON Chof.Id = SV.IdChofer
					LEFT OUTER JOIN Tarjetas AS Tarj ON Tarj.Id = SV.idTarjeta
					LEFT OUTER JOIN Provincias as Prov ON EmpTrans.Provincia = Prov.Id
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[StockProductoLoteCaducidad]
				AS

				SELECT 

				p.Id AS idProducto, 
				p.referencia AS Referencia, 
				p.Referencia2 AS Referencia2, 
				p.Nombre AS Nombre, 
				p.Tipo AS Tipo, 
				l.id AS idLote, 
				l.Referencia AS ReferenciaLote, 
				l.Nombre AS Lote, 
				l.Caducidad AS FCaducidad, 
				l.Fabricacion AS FFabricacion,
				p.Familia AS Familia,
				f.Nombre AS FamiliaNombre,
				SUM(s.Cantidad) AS Cantidad,
				ISNULL(ROW_NUMBER() OVER(ORDER BY l.Caducidad ASC), -1) AS RowID


				FROM Stocks AS s 
				LEFT OUTER JOIN dbo.Lotes AS l ON l.Id = s.Lote
				LEFT OUTER JOIN dbo.Productos AS p ON p.Id = l.Producto
				LEFT OUTER JOIN dbo.Familias AS f ON f.Id = p.Familia

				WHERE s.Estado = 1 OR s.Estado = 2

				GROUP BY p.Id, p.referencia,p.Referencia2, p.Nombre, p.Tipo, l.id, l.Referencia, l.Fabricacion, l.Nombre, l.Caducidad, p.Familia, f.Nombre
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[VentasExtended]
				AS
				SELECT V.id
					  , V.idSerie
						, S.Nombre AS SerieNombre
						, S.Estado AS SerieEstado
						, dbo.GetTextoParametro('Series', 'Estado', S.Estado) as SerieEstadoTexto
					  , V.Codigo -- Número
					  , V.Referencia
					  , V.Departamento
					  , V.Fecha
					  , V.PrecioTransporte
					  , V.idCliente
						, Cli.Nombre AS ClienteNombre
						, Cli.Referencia AS ClienteReferencia
						, Cli.RazonSocial AS ClienteRazonSocial
						, Cli.CIF AS ClienteCIF
						, Cli.Direccion AS ClienteDireccion
						, Cli.CodigoPostal AS ClienteCodigoPostal
						, Cli.Poblacion AS ClientePoblacion
						, Cli.Provincia AS ClienteProvincia
							, Provi.Nombre AS ClienteProvicinaNombre
						, Cli.Pais AS ClientePais
							, PaisCli.Nombre AS ClientePaisNombre
						, Cli.Telefono AS ClienteTelefono
					  , V.FechaEntrega
					  , V.idDomicilio
						  , Domi.Nombre AS DomicilioNombre
						  , Domi.Referencia AS DomicilioReferencia
						  , Domi.Direccion AS DomicilioDireccion
						  , Domi.Poblacion AS DomicilioPoblacion
						  , Domi.Telefono AS DomicilioTelefono
						  , Domi.CodigoPostal DomicilioCodigoPostal
						  , Domi.Provincia AS DomicilioProvincia
						  , Domi.Pais AS DomicilioPais
								, PaisDomi.Nombre AS DomicilioPaisNombre
						  , Domi.Descripcion AS DomicilioDescripcion
						  , Domi.Simogan AS DomicilioSIMOGAN
						  , Domi.REGA AS DomicilioREGA
					  , V.Estado
						, dbo.GetTextoParametro('Ventas', 'Estado', V.Estado) AS EstadoTexto
					  , V.Comentario
					  , V.Observaciones
					  , V.FechaInicio
					  , V.FechaFin
				  FROM dbo.Ventas AS V
					  LEFT OUTER JOIN Series AS S ON S.Id = V.idSerie
					  LEFT OUTER JOIN Clientes AS Cli ON Cli.Id = V.IdCliente
						LEFT OUTER JOIN Provincias AS Provi ON Provi.Id = Cli.Provincia AND Provi.Pais = Cli.Pais 
						LEFT OUTER JOIN Paises AS PaisCli ON PaisCli.Id = Cli.Pais
					  LEFT OUTER JOIN Domicilios AS Domi ON Domi.Id = V.idDomicilio and Domi.Cliente = V.idCliente
						LEFT OUTER JOIN Paises AS PaisDomi ON PaisDomi.Id = Domi.Pais
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[VentasLineasExtended]
				AS

				SELECT VL.id
					  , VL.idVentas
					  , VL.linea
					  , VL.idProducto
						, P.Nombre AS ProductoNombre
					  , VL.idFormato
						, Form.Nombre AS FormatoNombre
						, Form.Descripcion AS FormatoDescripcion
					  , VL.idEnvase
						, Enva.Nombre AS EnvaseNombre
					  , VL.Bultos
					  , VL.Cantidad
					  , VL.idUnidad
						, Uni.Nombre AS UnidadTexto
					  , VL.idDomicilio
						  , Domi.Cliente AS DomicilioIdCliente
						  , Domi.Nombre AS DomicilioNombre
						  , Domi.Referencia AS DomicilioReferencia
						  , Domi.Direccion AS DomicilioDireccion
						  , Domi.Poblacion AS DomicilioPoblacion
						  , Domi.Telefono AS DomicilioTelefono
						  , Domi.CodigoPostal DomicilioCodigoPostal
						  , Domi.Provincia AS DomicilioProvincia
						  , Domi.Pais AS DomicilioPais
								, Pais.Nombre AS DomicilioPaisNombre
						  , Domi.Inhabilitado
							, dbo.GetTextoParametro('Domicilio', 'Inhabilitado', Domi.Inhabilitado) AS DomicilioInhabilitadoStr
						  , Domi.Descripcion AS DomicilioDescripcion
						  , Domi.Simogan AS DomicilioSIMOGAN
						  , Domi.REGA AS DomicilioREGA
				--      , VL.idMedicamento
					  , VL.PrecioUnidad
					  , VL.idContrato
				--      , VL.MedCantidad
				--      , VL.MedBultos
				--      , VL.MedEnvase
				--      , VL.MedUnidad
				--      , VL.MedFormato
				--      , VL.MedPrecioUnidad
					  , VL.Estado
						, dbo.GetTextoParametro('VentasLineas', 'Estado', VL.Estado) AS EstadoStr
					  , VL.Fecha
					  , VL.Observaciones
					  , VL.Precio
						, NULL AS IdMonedaPrecio
						, NULL AS PrecioMonedaNombre
					  , VL.PrecioTransporte
						, NULL AS IdMonedaPrecioTransporte
						, NULL AS PrecioTransporteMonedaNombre
					  , VL.CampoLibre1
					  , VL.CampoLibre2
					  , VL.idPuntoDescarga
						, PD.Nombre AS PuntoDescargaStr
						, PD.Descripcion AS PuntoDescargaDescripcion
						,STUFF((
							SELECT DISTINCT ' - ' + pd.Nombre
							FROM VentasLiniasPuntosDescarga AS vlpd 
							LEFT OUTER JOIN PuntosDescarga AS pd ON vlpd.idPuntoDescarga = pd.id 
							WHERE idLineaVenta = VL.id
							FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 3, '') AS TodosPuntosDescarga
				  FROM dbo.VentasLinias AS VL
					LEFT OUTER JOIN Productos as P ON P.Id = VL.idProducto
					LEFT OUTER JOIN Formatos AS Form ON Form.Id = VL.idFormato
					LEFT OUTER JOIN Envases AS Enva ON Enva.Id = VL.idEnvase
					LEFT OUTER JOIN Unidades AS Uni ON Uni.Id = VL.idUnidad
					LEFT OUTER JOIN Domicilios AS Domi ON Domi.Id = VL.idDomicilio
					LEFT OUTER JOIN Paises AS Pais ON Pais.Id = Domi.Pais
					LEFT OUTER JOIN PuntosDescarga AS PD ON PD.id = VL.idPuntoDescarga
				GO
			");
			migrationBuilder.Sql($@"
				CREATE OR ALTER VIEW [dbo].[VentasLineasMedicacionesExtended]
				AS
				SELECT VLM.id
					  , VLM.idVentaLinia
					  , VLM.idEnvase
						, Enva.Nombre AS EnvaseNombre
					  , VLM.idFormato
						, Form.Nombre AS FormatoNombre
						, Form.Descripcion AS FormatoDescripcion
					  , VLM.idMedicamento
						, Medi.Nombre AS MedicamentoNombre
						, Medi.Referencia AS MedicamentoReferencia
				--		, Medi.Cliente AS MedicacionIdCliente  -- hay medicaciones que se pueden dar de alta específicamente para un cliente concreto
							, Prod.Nombre AS MedicamentoProductoNombre
					  , VLM.idUnidad
						, Uni.Nombre AS UnidadTexto
					  , VLM.Fecha
					  , VLM.Cantidad
					  , VLM.Bultos
					  , VLM.Estado
						, dbo.GetTextoParametro('VentasLiniasMedicaciones', 'Estado', VLM.Estado) AS EstadoStr
					  , VLM.Precio
						, NULL AS IdMonedaPrecio
						, NULL AS MonedaPrecioStr
					  , VLM.PrecioUnidad
						, NULL AS IdMonedaPrecioUnidad
						, NULL AS MonedaPrecioUnidadStr
				  FROM dbo.VentasLiniasMedicaciones AS VLM
					LEFT OUTER JOIN Envases AS Enva ON Enva.Id = VLM.IdEnvase
					LEFT OUTER JOIN Formatos AS Form ON Form.Id = VLM.IdFormato
					LEFT OUTER JOIN Medicaciones AS Medi ON Medi.Id = VLM.idMedicamento
					LEFT OUTER JOIN Productos AS Prod ON Prod.Id = Medi.idProducto
					LEFT OUTER JOIN Unidades AS Uni ON Uni.Id = VLM.IdUnidad
				GO
			");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql($@"DROP VIEW [CertificadosDesinfeccionExtended]");
			migrationBuilder.Sql($@"DROP VIEW [ComprasExtended]");
			migrationBuilder.Sql($@"DROP VIEW [ComprasLineasExtended]");
			migrationBuilder.Sql($@"DROP VIEW [ConsumidoOrden]");
			migrationBuilder.Sql($@"DROP VIEW [DashOrdenes]");
			migrationBuilder.Sql($@"DROP VIEW [DashVistaStocks]");
			migrationBuilder.Sql($@"DROP VIEW [DatosMuestraEntrada]");
			migrationBuilder.Sql($@"DROP VIEW [DEBUG_ResultadosSinMovimientos]");
			migrationBuilder.Sql($@"DROP VIEW [DesglosesDetalle]");
			migrationBuilder.Sql($@"DROP VIEW [DesglosesExtended]");
			migrationBuilder.Sql($@"DROP VIEW [DomiciliosExtended]");
			migrationBuilder.Sql($@"DROP VIEW [DosificacionesDetalle]");
			migrationBuilder.Sql($@"DROP VIEW [EntradasExtended]");
			migrationBuilder.Sql($@"DROP VIEW [EntradasExtendedLineasEntradasExtended]");
			migrationBuilder.Sql($@"DROP VIEW [EntradasLineasExtended]");
			migrationBuilder.Sql($@"DROP VIEW [EntradasLineasResultadosNIRExtended]");
			migrationBuilder.Sql($@"DROP VIEW [EtiquetaMuestraProduccion]");
			migrationBuilder.Sql($@"DROP VIEW [EtiquetaStock]");
			migrationBuilder.Sql($@"DROP VIEW [ExistenciasProductoLote]");
			migrationBuilder.Sql($@"DROP VIEW [InformeExpediciones]");
			migrationBuilder.Sql($@"DROP VIEW [InformeExpediciones_SalidaLinea]");
			migrationBuilder.Sql($@"DROP VIEW [InformeExpediciones_SalidaLinea_Resultado]");
			migrationBuilder.Sql($@"DROP VIEW [LineasSalidasAgrupLoteYOrden]");
			migrationBuilder.Sql($@"DROP VIEW [ListaAlarmas]");
			migrationBuilder.Sql($@"DROP VIEW [ListaDesgloses]");
			migrationBuilder.Sql($@"DROP VIEW [ListaDosificaciones]");
			migrationBuilder.Sql($@"DROP VIEW [ListaOrdenes]");
			migrationBuilder.Sql($@"DROP VIEW [ListaResultados]");
			migrationBuilder.Sql($@"DROP VIEW [LoteClienteDomicilio]");
			migrationBuilder.Sql($@"DROP VIEW [LoteProveedor]");
			migrationBuilder.Sql($@"DROP VIEW [LoteProveedorNOCantidad]");
			migrationBuilder.Sql($@"DROP VIEW [LoteProveedorUnicoNOCantidad]");
			migrationBuilder.Sql($@"DROP VIEW [OrdenesDetalle]");
			migrationBuilder.Sql($@"DROP VIEW [PivotProduccion]");
			migrationBuilder.Sql($@"DROP VIEW [PivotProduccionProducidos]");
			migrationBuilder.Sql($@"DROP VIEW [ProducidoConsumidoOrden]");
			migrationBuilder.Sql($@"DROP VIEW [ProducidoOrden]");
			migrationBuilder.Sql($@"DROP VIEW [ProductoLotePrimerNivel]");
			migrationBuilder.Sql($@"DROP VIEW [ProductoLotePrimerNivelProvCli]");
			migrationBuilder.Sql($@"DROP VIEW [RecetasExtended]");
			migrationBuilder.Sql($@"DROP VIEW [RecetasLineasExtended]");
			migrationBuilder.Sql($@"DROP VIEW [recursivo]");
			migrationBuilder.Sql($@"DROP VIEW [ResultadosDetalle]");
			migrationBuilder.Sql($@"DROP VIEW [ResultadosExtended]");
			migrationBuilder.Sql($@"DROP VIEW [ResultadosOrdenAgrupado]");
			migrationBuilder.Sql($@"DROP VIEW [ResultadosPorDiaOrden]");
			migrationBuilder.Sql($@"DROP VIEW [SalidaLiniasReduced]");
			migrationBuilder.Sql($@"DROP VIEW [SalidasExtended]");
			migrationBuilder.Sql($@"DROP VIEW [SalidasInformeAduanas]");
			migrationBuilder.Sql($@"DROP VIEW [SalidasLineasExtended]");
			migrationBuilder.Sql($@"DROP VIEW [SalidasLineasLoteExtended]");
			migrationBuilder.Sql($@"DROP VIEW [SalidasLineasResultados]");
			migrationBuilder.Sql($@"DROP VIEW [SalidasLiniasMedicacionesExtended]");
			migrationBuilder.Sql($@"DROP VIEW [SalidasLotesServidos]");
			migrationBuilder.Sql($@"DROP VIEW [SalidasViajesExtended]");
			migrationBuilder.Sql($@"DROP VIEW [StockProductoLoteCaducidad]");
			migrationBuilder.Sql($@"DROP VIEW [TotalCantidadPorOrden]");
			migrationBuilder.Sql($@"DROP VIEW [TotalProducidoPorOrden]");
			migrationBuilder.Sql($@"DROP VIEW [VentasExtended]");
			migrationBuilder.Sql($@"DROP VIEW [VentasLineasExtended]");
			migrationBuilder.Sql($@"DROP VIEW [VentasLineasMedicacionesExtended]");

			migrationBuilder.Sql($@"DROP PROCEDURE [AddIdOld]");
			migrationBuilder.Sql($@"DROP PROCEDURE [AddSerieOld]");
			migrationBuilder.Sql($@"DROP PROCEDURE [AlarmasTop10Modulo]");
			migrationBuilder.Sql($@"DROP PROCEDURE [CalculoKWVentana]");
			migrationBuilder.Sql($@"DROP PROCEDURE [ConsumoKWMotores]");
			migrationBuilder.Sql($@"DROP PROCEDURE [DashProduccion]");
			migrationBuilder.Sql($@"DROP PROCEDURE [DashProduccionUlt7Dias]");
			migrationBuilder.Sql($@"DROP PROCEDURE [EnergiaRellenoAlarmasSobreConsumo]");
			migrationBuilder.Sql($@"DROP PROCEDURE [GenerarIdMuestraEntrada]");
			migrationBuilder.Sql($@"DROP PROCEDURE [GenerarKWEnOrdenesTeoricos]");
			migrationBuilder.Sql($@"DROP PROCEDURE [GetNewLote]");
			migrationBuilder.Sql($@"DROP PROCEDURE [GrabarReadPLC]");
			migrationBuilder.Sql($@"DROP PROCEDURE [LimpiezaBaseDatos]");
			migrationBuilder.Sql($@"DROP PROCEDURE [LimpiezaBuffers]");
			migrationBuilder.Sql($@"DROP PROCEDURE [ListaAlarmasConsumoMotores]");
			migrationBuilder.Sql($@"DROP PROCEDURE [ListaClientesDeUnLote]");
			migrationBuilder.Sql($@"DROP PROCEDURE [NuevoContador]");
			migrationBuilder.Sql($@"DROP PROCEDURE [OEEDesgloses]");
			migrationBuilder.Sql($@"DROP PROCEDURE [OEEEstadosFechaCompleto]");
			migrationBuilder.Sql($@"DROP PROCEDURE [OEEEStadosFechaIntervalos]");
			migrationBuilder.Sql($@"DROP PROCEDURE [OEEGenerarDatosFalsos]");
			migrationBuilder.Sql($@"DROP PROCEDURE [OrdenesACabOrdenes]");
			migrationBuilder.Sql($@"DROP PROCEDURE [P_ERPProductoUbicacion]");
			migrationBuilder.Sql($@"DROP PROCEDURE [P_ERPStockDisponibleCargaSilo]");
			migrationBuilder.Sql($@"DROP PROCEDURE [Productividad]");
			migrationBuilder.Sql($@"DROP PROCEDURE [Productividad7Dias]");
			migrationBuilder.Sql($@"DROP PROCEDURE [RangoConsumoKWMotores]");
			migrationBuilder.Sql($@"DROP PROCEDURE [RangoConsumoKWMotoresSumas]");
			migrationBuilder.Sql($@"DROP PROCEDURE [RangoConsumoKWSecciones]");
			migrationBuilder.Sql($@"DROP PROCEDURE [RangoConsumoKWSeccionesSumas]");
			migrationBuilder.Sql($@"DROP PROCEDURE [spReseedUserTables]");
			migrationBuilder.Sql($@"DROP PROCEDURE [UpdateBufferOrdenes]");

			migrationBuilder.Sql($@"DROP FUNCTION [ListaStringToInt]");
			migrationBuilder.Sql($@"DROP FUNCTION [ProductividadFechasModulo]");
			migrationBuilder.Sql($@"DROP FUNCTION [SplitInts]");
			migrationBuilder.Sql($@"DROP FUNCTION [TVF_TimeRange_Split_To_Grid]");
			migrationBuilder.Sql($@"DROP FUNCTION [TVF_TimeRange_Split_To_GridSeconds]");
			migrationBuilder.Sql($@"DROP FUNCTION [udfRankingProductosFechas]");
			migrationBuilder.Sql($@"DROP FUNCTION [CantidadSegunTiempo]");
			migrationBuilder.Sql($@"DROP FUNCTION [GetTextoParametro]");
			migrationBuilder.Sql($@"DROP FUNCTION [ProductividadModuloDia]");
			migrationBuilder.Sql($@"DROP FUNCTION [RangoFechaInicio]");
			migrationBuilder.Sql($@"DROP FUNCTION [VerTurno]");
			migrationBuilder.Sql($@"DROP FUNCTION [VerTurnoId]");

			migrationBuilder.Sql($@"DROP TRIGGER [triggerInsertCertificadoDesinfeccion];");
			migrationBuilder.Sql($@"DROP TRIGGER [triggerInsertCompras];");
			migrationBuilder.Sql($@"DROP TRIGGER [triggerInsertEntradas];");
			migrationBuilder.Sql($@"DROP TRIGGER [triggerInsertRecetas];");
			migrationBuilder.Sql($@"DROP TRIGGER [triggerInsertSalidas];");
			migrationBuilder.Sql($@"DROP TRIGGER [triggerInsertSalidasAlbaranes];");
			migrationBuilder.Sql($@"DROP TRIGGER [triggerInsertSalidasViajes];");
			migrationBuilder.Sql($@"DROP TRIGGER [triggerInsertVentas];");
			migrationBuilder.Sql($@"DROP TRIGGER [Trigger_OrdenPLC];");
			migrationBuilder.Sql($@"DROP TRIGGER [Trigger_Formulas];");
			migrationBuilder.Sql($@"DROP TRIGGER [Trigger_Version];");

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
				name: "FK_Medicaciones_Productos",
				table: "Medicaciones");

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
				name: "FK__Basculas__OpcCon__54B68676",
				table: "Basculas");

			migrationBuilder.DropForeignKey(
				name: "FK__Tags__OpcConfigI__04BA9F53",
				table: "Tags");

			migrationBuilder.DropForeignKey(
				name: "FK_Basculas_Tags",
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
				name: "AnalizadoresRed");

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
				name: "BufferERPStocks");

			migrationBuilder.DropTable(
				name: "BufferERPVehiculos");

			migrationBuilder.DropTable(
				name: "BufferERPVentas");

			migrationBuilder.DropTable(
				name: "BufferERPVentasLineas");

			migrationBuilder.DropTable(
				name: "BufferProducidos");

			migrationBuilder.DropTable(
				name: "Caminos");

			migrationBuilder.DropTable(
				name: "Caudales");

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
				name: "FormulasDatosExtra");

			migrationBuilder.Sql($@"DROP FUNCTION [FormulaKWToneladaEfectivo]");

			migrationBuilder.Sql($@"DROP FUNCTION [FormulaKWToneladaTotal]");

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
				name: "NetAlarmasAutomaticasOrdenUbicaciones");

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
				name: "OpcionesRoles");

			migrationBuilder.DropTable(
				name: "OpcionesUsuarios");

			migrationBuilder.DropTable(
				name: "OperMotoresModulos");

			migrationBuilder.DropTable(
				name: "OperPlantillas");

			migrationBuilder.DropTable(
				name: "OrdenesAutoInicio");

			migrationBuilder.Sql($@"DROP FUNCTION [OrdenKWConsumidosTotal]");

			migrationBuilder.Sql($@"DROP FUNCTION [OrdenKWProducidosTotal]");

			migrationBuilder.Sql($@"DROP FUNCTION [OrdenKWConsumidosEfectivo]");

			migrationBuilder.Sql($@"DROP FUNCTION [OrdenKWProducidosEfectivo]");

			migrationBuilder.Sql($@"DROP FUNCTION [OrdenCantidadProducida]");

			migrationBuilder.Sql($@"DROP FUNCTION [OrdenKWEfectivoCantidad]");

			migrationBuilder.Sql($@"DROP FUNCTION [OrdenKWTotalCantidad]");

			migrationBuilder.DropTable(
				name: "OrdenesDatosExtra");

			migrationBuilder.DropTable(
				name: "OrdenesRelacion");

			migrationBuilder.DropTable(
				name: "Pistolas");

			migrationBuilder.DropTable(
				name: "Pivots");

			migrationBuilder.DropTable(
				name: "PLCAddonsVars");

			migrationBuilder.DropTable(
				name: "PLCRead");

			migrationBuilder.DropTable(
				name: "PLCWrite");

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
				name: "VersionDatosExtra");

			migrationBuilder.Sql($@"DROP FUNCTION [VersionKWToneladaEfectivo]");

			migrationBuilder.Sql($@"DROP FUNCTION [VersionKWToneladaTotal]");

			migrationBuilder.DropTable(
				name: "VersionTPrevisto");

			migrationBuilder.DropTable(
				name: "AlertasUsuariosInformes");

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
				name: "CompActivosLista");

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
				name: "NetAlarmasAutomaticas");

			migrationBuilder.DropTable(
				name: "NetAlarmas");

			migrationBuilder.DropTable(
				name: "Turnos");

			migrationBuilder.DropTable(
				name: "Opciones");

			migrationBuilder.DropTable(
				name: "PLCAddons");

			migrationBuilder.DropTable(
				name: "GruposIncompatibilidades");

			migrationBuilder.DropTable(
				name: "Recetas");

			migrationBuilder.DropTable(
				name: "ControlesNIR");

			migrationBuilder.DropTable(
				name: "Stocks");

			migrationBuilder.Sql($@"DROP FUNCTION [EnvasesDeStock]");

			migrationBuilder.DropTable(
				name: "Variables");

			migrationBuilder.DropTable(
				name: "SalidasLiniasMedicaciones");

			migrationBuilder.DropTable(
				name: "VentasLinias");

			migrationBuilder.DropTable(
				name: "AlertasUsuarios");

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
				name: "InformesLibCategorias");

			migrationBuilder.DropTable(
				name: "NetAlarmasTiposRespuestas");

			migrationBuilder.DropTable(
				name: "SeccionesGrupos");

			migrationBuilder.DropTable(
				name: "Secciones");

			migrationBuilder.DropTable(
				name: "Dosificaciones");

			migrationBuilder.DropTable(
				name: "Veterinarios");

			migrationBuilder.DropTable(
				name: "Contratos");

			migrationBuilder.DropTable(
				name: "Ventas");

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
				name: "NetAlarmasRespuestas");

			migrationBuilder.DropTable(
				name: "NetAlarmasTipos");

			migrationBuilder.DropTable(
				name: "OperMotores");

			migrationBuilder.DropTable(
				name: "TempControles");

			migrationBuilder.DropTable(
				name: "MedidoresDosificaciones");

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
				name: "OperAcciones");

			migrationBuilder.DropTable(
				name: "Origenes");

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
				name: "Versiones");

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

			migrationBuilder.Sql($@"DROP FUNCTION [StockEnUbicacion]");

			migrationBuilder.Sql($@"DROP FUNCTION [LoteEnUbicacion]");

			migrationBuilder.DropTable(
				name: "Sesiones");

			migrationBuilder.DropTable(
				name: "Unidades");

			migrationBuilder.DropTable(
				name: "Modulos");

			migrationBuilder.DropTable(
				name: "OEEEstadosTipo");

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
				name: "Medicaciones");

			migrationBuilder.DropTable(
				name: "Afecciones");

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
