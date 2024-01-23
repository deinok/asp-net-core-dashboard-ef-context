using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes
{

	public partial class VmesDbContext
	{

		public virtual DbSet<Aditivos> Aditivos { get; set; }

		public virtual DbSet<Afecciones> Afecciones { get; set; }

		public virtual DbSet<Alarmas> Alarmas { get; set; }

		public virtual DbSet<AlertasSmtpConfigs> AlertasSmtpConfigs { get; set; }

		public virtual DbSet<AlertasUsuarios> AlertasUsuarios { get; set; }

		public virtual DbSet<AlertasUsuariosAlarmas> AlertasUsuariosAlarmas { get; set; }

		public virtual DbSet<AlertasUsuariosInformes> AlertasUsuariosInformes { get; set; }

		public virtual DbSet<AlertasUsuariosInformesParametros> AlertasUsuariosInformesParametros { get; set; }

		public virtual DbSet<Analisis> Analisis { get; set; }

		public virtual DbSet<Audit> Audits { get; set; }

		public virtual DbSet<AuditColumn> AuditColumns { get; set; }

		public virtual DbSet<AuditTable> AuditTables { get; set; }

		[Obsolete]
		public virtual DbSet<Backups> Backups { get; set; }

		public virtual DbSet<Bascula> Basculas { get; set; }

		public virtual DbSet<BufferConsumidos> BufferConsumidos { get; set; }

		public virtual DbSet<BufferERPCabOrdenes> BufferERPCabOrdenes { get; set; }

		public virtual DbSet<BufferERPChoferes> BufferERPChoferes { get; set; }

		public virtual DbSet<BufferERPClienteDomicilioPuntoDescarga> BufferERPClienteDomicilioPuntoDescarga { get; set; }

		public virtual DbSet<BufferERPClientes> BufferERPClientes { get; set; }

		public virtual DbSet<BufferERPClientesDomicilios> BufferERPClientesDomicilios { get; set; }

		public virtual DbSet<BufferERPComponentes> BufferERPComponentes { get; set; }

		public virtual DbSet<BufferERPCompras> BufferERPCompras { get; set; }

		public virtual DbSet<BufferERPComprasLineas> BufferERPComprasLineas { get; set; }

		public virtual DbSet<BufferERPConsumidos> BufferERPConsumidos { get; set; }

		public virtual DbSet<BufferERPDocumentos> BufferERPDocumentos { get; set; }

		public virtual DbSet<BufferERPEntradas> BufferERPEntradas { get; set; }

		public virtual DbSet<BufferERPEntradasLineas> BufferERPEntradasLineas { get; set; }

		public virtual DbSet<BufferERPEntradasLineasLote> BufferERPEntradasLineasLote { get; set; }

		public virtual DbSet<BufferERPFormulaProductosFinales> BufferERPFormulaProductosFinales { get; set; }

		public virtual DbSet<BufferERPFormulas> BufferERPFormulas { get; set; }

		public virtual DbSet<BufferERPImprimirDocumentos> BufferERPImprimirDocumentos { get; set; }

		public virtual DbSet<BufferERPLinOrdenes> BufferERPLinOrdenes { get; set; }

		public virtual DbSet<BufferERPPedidoVenta> BufferERPPedidoVenta { get; set; }

		public virtual DbSet<BufferERPPedidoVentaExtra> BufferERPPedidoVentaExtra { get; set; }

		public virtual DbSet<BufferERPProducidos> BufferERPProducidos { get; set; }

		public virtual DbSet<BufferERPProductos> BufferERPProductos { get; set; }

		public virtual DbSet<BufferERPProveedores> BufferERPProveedores { get; set; }

		public virtual DbSet<BufferERPRegularizaciones> BufferERPRegularizaciones { get; set; }

		public virtual DbSet<BufferERPSalidas> BufferERPSalidas { get; set; }

		public virtual DbSet<BufferERPSalidasLinMedicamentos> BufferERPSalidasLinMedicamentos { get; set; }

		public virtual DbSet<BufferERPSalidasLinias> BufferERPSalidasLinias { get; set; }

		public virtual DbSet<BufferERPSalidasLiniasLote> BufferERPSalidasLiniasLote { get; set; }

		public virtual DbSet<BufferERPSalidasViajes> BufferERPSalidasViajes { get; set; }

		public virtual DbSet<BufferERPSolicitudRegularizacion> BufferERPSolicitudRegularizacion { get; set; }

		public virtual DbSet<BufferERPSolicitudTraspaso> BufferERPSolicitudTraspaso { get; set; }

		public virtual DbSet<BufferERPStocks> BufferERPStocks { get; set; }

		public virtual DbSet<BufferERPVehiculos> BufferERPVehiculos { get; set; }

		public virtual DbSet<BufferERPVentas> BufferERPVentas { get; set; }

		public virtual DbSet<BufferERPVentasLineas> BufferERPVentasLineas { get; set; }

		public virtual DbSet<BufferERPVersiones> BufferERPVersiones { get; set; }

		public virtual DbSet<BufferProducidos> BufferProducidos { get; set; }

		public virtual DbSet<CabOrdenes> CabOrdenes { get; set; }

		public virtual DbSet<Camino> Caminos { get; set; }

		public virtual DbSet<Caudal> Caudales { get; set; }

		public virtual DbSet<CertificadoDesinfeccion> CertificadoDesinfeccion { get; set; }

		[Obsolete]
		public virtual DbSet<CertificadosDesinfeccionExtended> CertificadosDesinfeccionExtended { get; set; }

		public virtual DbSet<Choferes> Choferes { get; set; }

		public virtual DbSet<Clientes> Clientes { get; set; }

		public virtual DbSet<Componentes> Componentes { get; set; }

		public virtual DbSet<ComponentesActivos> ComponentesActivos { get; set; }

		public virtual DbSet<Compras> Compras { get; set; }

		[Obsolete]
		public virtual DbSet<ComprasExtended> ComprasExtended { get; set; }

		[Obsolete]
		public virtual DbSet<ComprasLineasExtended> ComprasLineasExtended { get; set; }

		public virtual DbSet<Comprobaciones> Comprobaciones { get; set; }

		public virtual DbSet<ConfigWCF> ConfigWCF { get; set; }

		[Obsolete]
		public virtual DbSet<ConsumidoOrden> ConsumidoOrden { get; set; }

		[Obsolete]
		public virtual DbSet<Contadores> Contadores { get; set; }

		public virtual DbSet<Contratos> Contratos { get; set; }

		public virtual DbSet<ControlesNIR> ControlesNIR { get; set; }

		public virtual DbSet<ControlesNIRProductos> ControlesNIRProductos { get; set; }

		[Obsolete]
		public virtual DbSet<DEBUG_ResultadosSinMovimientos> DEBUG_ResultadosSinMovimientos { get; set; }

		[Obsolete]
		public virtual DbSet<DashOrdenes> DashOrdenes { get; set; }

		[Obsolete]
		public virtual DbSet<DashVistaStocks> DashVistaStocks { get; set; }

		public virtual DbSet<Dashboard> Dashboards { get; set; }

		public virtual DbSet<DashboardsLib> DashboardsLib { get; set; }

		public virtual DbSet<DashboardsLibCategorias> DashboardsLibCategorias { get; set; }

		[Obsolete]
		public virtual DbSet<DatosMuestraEntrada> DatosMuestraEntrada { get; set; }

		public virtual DbSet<Departamentos> Departamentos { get; set; }

		public virtual DbSet<Desgloses> Desgloses { get; set; }

		[Obsolete]
		public virtual DbSet<DesglosesDetalle> DesglosesDetalle { get; set; }

		[Obsolete]
		public virtual DbSet<DesglosesExtended> DesglosesExtended { get; set; }

		public virtual DbSet<Destinos> Destinos { get; set; }

		public virtual DbSet<DestinosMedidores> DestinosMedidores { get; set; }

		public virtual DbSet<Disposiciones> Disposiciones { get; set; }

		public virtual DbSet<Documentos> Documentos { get; set; }

		public virtual DbSet<Domicilios> Domicilios { get; set; }

		[Obsolete]
		public virtual DbSet<DomiciliosExtended> DomiciliosExtended { get; set; }

		public virtual DbSet<Dominios> Dominios { get; set; }

		public virtual DbSet<Dosificaciones> Dosificaciones { get; set; }

		[Obsolete]
		public virtual DbSet<DosificacionesDetalle> DosificacionesDetalle { get; set; }

		public virtual DbSet<Electrovalvula> Electrovalvulas { get; set; }

		public virtual DbSet<Empresas> Empresas { get; set; }

		public virtual DbSet<EmpresasTransporte> EmpresasTransporte { get; set; }

		public virtual DbSet<EnlaceERP> EnlaceERP { get; set; }

		public virtual DbSet<EnlaceERPAsigUbi> EnlaceERPAsigUbi { get; set; }

		public virtual DbSet<EnlaceERPConversiones> EnlaceERPConversiones { get; set; }

		public virtual DbSet<EnlaceERPLinea> EnlaceERPLinea { get; set; }

		public virtual DbSet<EnlaceERPTipo> EnlaceERPTipo { get; set; }

		public virtual DbSet<EnlaceERPTipoLinea> EnlaceERPTipoLinea { get; set; }

		public virtual DbSet<Entradas> Entradas { get; set; }

		public virtual DbSet<EntradasContratos> EntradasContratos { get; set; }

		[Obsolete]
		public virtual DbSet<EntradasExtended> EntradasExtended { get; set; }

		[Obsolete]
		public virtual DbSet<EntradasExtendedLineasEntradasExtended> EntradasExtendedLineasEntradasExtended { get; set; }

		public virtual DbSet<EntradasLineas> EntradasLineas { get; set; }

		[Obsolete]
		public virtual DbSet<EntradasLineasExtended> EntradasLineasExtended { get; set; }

		public virtual DbSet<EntradasLineasResultadosNIR> EntradasLineasResultadosNIR { get; set; }

		[Obsolete]
		public virtual DbSet<EntradasLineasResultadosNIRExtended> EntradasLineasResultadosNIRExtended { get; set; }

		public virtual DbSet<EntradasLotes> EntradasLotes { get; set; }

		public virtual DbSet<Envases> Envases { get; set; }

		public virtual DbSet<Especies> Especies { get; set; }

		[Obsolete]
		public virtual DbSet<EtiquetaMuestraProduccion> EtiquetaMuestraProduccion { get; set; }

		[Obsolete]
		public virtual DbSet<EtiquetaStock> EtiquetaStock { get; set; }

		public virtual DbSet<Etiquetas> Etiquetas { get; set; }

		public virtual DbSet<Eventos> Eventos { get; set; }

		public virtual DbSet<EventosDetalle> EventosDetalle { get; set; }

		public virtual DbSet<Existencias> Existencias { get; set; }

		[Obsolete]
		public virtual DbSet<ExistenciasProductoLote> ExistenciasProductoLote { get; set; }

		public virtual DbSet<Familias> Familias { get; set; }

		public virtual DbSet<FamiliasMedidor> FamiliasMedidor { get; set; }

		public virtual DbSet<FileGmaoElement> FileGmaoElement { get; set; }

		public virtual DbSet<Files> Files { get; set; }

		public virtual DbSet<Formatos> Formatos { get; set; }

		public virtual DbSet<FormulaProdModulo> FormulaProdModulo { get; set; }

		public virtual DbSet<Formularios> Formularios { get; set; }

		public virtual DbSet<Formulas> Formulas { get; set; }

		public virtual DbSet<GMAO_Archivos> GMAO_Archivos { get; set; }

		public virtual DbSet<GMAO_Archivos_Elementos> GMAO_Archivos_Elementos { get; set; }

		public virtual DbSet<GMAO_Archivos_Intervenciones> GMAO_Archivos_Intervenciones { get; set; }

		public virtual DbSet<GMAO_Archivos_Modelos> GMAO_Archivos_Modelos { get; set; }

		public virtual DbSet<GMAO_Archivos_Tipos> GMAO_Archivos_Tipos { get; set; }

		public virtual DbSet<GMAO_Caracteristicas> GMAO_Caracteristicas { get; set; }

		public virtual DbSet<GMAO_CaracteristicasElementos> GMAO_CaracteristicasElementos { get; set; }

		public virtual DbSet<GMAO_CaracteristicasTipos> GMAO_CaracteristicasTipos { get; set; }

		public virtual DbSet<GMAO_Compras> GMAO_Compras { get; set; }

		public virtual DbSet<GMAO_ComprasLineas> GMAO_ComprasLineas { get; set; }

		public virtual DbSet<GMAO_Departamentos> GMAO_Departamentos { get; set; }

		public virtual DbSet<GMAO_Deps_Operarios> GMAO_Deps_Operarios { get; set; }

		public virtual DbSet<GMAO_ElemAlternativos> GMAO_ElemAlternativos { get; set; }

		public virtual DbSet<GMAO_ElemIntervenciones> GMAO_ElemIntervenciones { get; set; }

		public virtual DbSet<GMAO_ElemIntervencionesPiezas> GMAO_ElemIntervencionesPiezas { get; set; }

		public virtual DbSet<GMAO_ElemIntervencionesTrabajos> GMAO_ElemIntervencionesTrabajos { get; set; }

		public virtual DbSet<GMAO_ElemPertenencia> GMAO_ElemPertenencia { get; set; }

		public virtual DbSet<GMAO_ElemStocks> GMAO_ElemStocks { get; set; }

		public virtual DbSet<GMAO_ElementReviewSettings> GMAO_ElementReviewSettings { get; set; }

		public virtual DbSet<GMAO_ElementReviewTask> GMAO_ElementReviewTasks { get; set; }

		public virtual DbSet<GMAO_Elementos> GMAO_Elementos { get; set; }

		public virtual DbSet<GMAO_ElementosTipos> GMAO_ElementosTipos { get; set; }

		public virtual DbSet<GMAO_ElementosTiposModelos> GMAO_ElementosTiposModelos { get; set; }

		public virtual DbSet<GMAO_HistStocksYElementos> GMAO_HistStocksYElementos { get; set; }

		public virtual DbSet<GMAO_Marcas> GMAO_Marcas { get; set; }

		public virtual DbSet<GMAO_MarcasModelos> GMAO_MarcasModelos { get; set; }

		public virtual DbSet<GMAO_Operarios> GMAO_Operarios { get; set; }

		public virtual DbSet<GMAO_ParadasConfiguracion> GMAO_ParadasConfiguracion { get; set; }

		public virtual DbSet<GMAO_ParadasConfiguracionModulos> GMAO_ParadasConfiguracionModulos { get; set; }

		public virtual DbSet<GMAO_ParadasConfiguracionTareas> GMAO_ParadasConfiguracionTareas { get; set; }

		public virtual DbSet<GMAO_Proveedores> GMAO_Proveedores { get; set; }

		public virtual DbSet<GMAO_SolicitudOrdenTrabajo> GMAO_SolicitudOrdenTrabajo { get; set; }

		public virtual DbSet<GMAO_WarehouseStocks> GMAO_WarehouseStocks { get; set; }

		public virtual DbSet<GMAO_Warehouses> GMAO_Warehouses { get; set; }

		public virtual DbSet<Gateway> Gateways { get; set; }

		public virtual DbSet<GruposIncompatibilidades> GruposIncompatibilidades { get; set; }

		public virtual DbSet<GruposIncompatibilidadesLineas> GruposIncompatibilidadesLineas { get; set; }

		public virtual DbSet<HumanMachineInterface> HumanMachineInterfaces { get; set; }

		public virtual DbSet<Incompatibilidades> Incompatibilidades { get; set; }

		public virtual DbSet<Indicadores> Indicadores { get; set; }

		[Obsolete]
		public virtual DbSet<InformeExpediciones> InformeExpediciones { get; set; }

		[Obsolete]
		public virtual DbSet<InformeExpediciones_SalidaLinea> InformeExpediciones_SalidaLinea { get; set; }

		[Obsolete]
		public virtual DbSet<InformeExpediciones_SalidaLinea_Resultado> InformeExpediciones_SalidaLinea_Resultado { get; set; }

		public virtual DbSet<InformesLib> InformesLib { get; set; }

		public virtual DbSet<InformesLibCategorias> InformesLibCategorias { get; set; }

		public virtual DbSet<InformesLibUsuarios> InformesLibUsuarios { get; set; }

		public virtual DbSet<Inventarios> Inventarios { get; set; }

		public virtual DbSet<Lectores> Lectores { get; set; }

		public virtual DbSet<LineaVentaLineaSalida> LineaVentaLineaSalida { get; set; }

		public virtual DbSet<LineasCompra> LineasCompra { get; set; }

		[Obsolete]
		public virtual DbSet<LineasSalidasAgrupLoteYOrden> LineasSalidasAgrupLoteYOrden { get; set; }

		[Obsolete]
		public virtual DbSet<ListaAlarmas> ListaAlarmas { get; set; }

		[Obsolete]
		public virtual DbSet<ListaDesgloses> ListaDesgloses { get; set; }

		[Obsolete]
		public virtual DbSet<ListaDosificaciones> ListaDosificaciones { get; set; }

		[Obsolete]
		public virtual DbSet<ListaOrdenes> ListaOrdenes { get; set; }

		[Obsolete]
		public virtual DbSet<ListaResultados> ListaResultados { get; set; }

		public virtual DbSet<LogMovimientosStocks> LogMovimientosStocks { get; set; }

		[Obsolete]
		public virtual DbSet<LoteClienteDomicilio> LoteClienteDomicilio { get; set; }

		[Obsolete]
		public virtual DbSet<LoteProveedor> LoteProveedor { get; set; }

		[Obsolete]
		public virtual DbSet<LoteProveedorNOCantidad> LoteProveedorNOCantidad { get; set; }

		[Obsolete]
		public virtual DbSet<LoteProveedorUnicoNOCantidad> LoteProveedorUnicoNOCantidad { get; set; }

		public virtual DbSet<Lotes> Lotes { get; set; }

		public virtual DbSet<LotesMezclados> LotesMezclados { get; set; }

		[Obsolete]
		public virtual DbSet<Maquinas> Maquinas { get; set; }

		public virtual DbSet<Medicaciones> Medicaciones { get; set; }

		public virtual DbSet<MedicacionesIngredientes> MedicacionesIngredientes { get; set; }

		public virtual DbSet<Medidor> Medidores { get; set; }

		public virtual DbSet<MedidoresDosificaciones> MedidoresDosificaciones { get; set; }

		public virtual DbSet<ModuloEstadoComunicaciones> ModulosEstadoComunicaciones { get; set; }

		public virtual DbSet<Modulos> Modulos { get; set; }

		public virtual DbSet<ModulosAscendentes> ModulosAscendentes { get; set; }

		public virtual DbSet<ModulosIncompatibilidades> ModulosIncompatibilidades { get; set; }

		public virtual DbSet<ModulosMotores> ModulosMotores { get; set; }

		public virtual DbSet<ModulosTagsScada> ModulosTagsScada { get; set; }

		public virtual DbSet<Motor> Motores { get; set; }

		public virtual DbSet<MotoresGrupos> MotoresGrupos { get; set; }

		public virtual DbSet<MotoresGruposRelacion> MotoresGruposRelacion { get; set; }

		public virtual DbSet<MotoresHistorico> MotoresHistorico { get; set; }

		public virtual DbSet<MultiDosificaciones> MultiDosificaciones { get; set; }

		public virtual DbSet<NetAlarmas> NetAlarmas { get; set; }

		public virtual DbSet<NetAlarmasAutomaticas> NetAlarmasAutomaticas { get; set; }

		public virtual DbSet<NetAlarmasAutomaticasOrdenUbicaciones> NetAlarmasAutomaticasOrdenUbicaciones { get; set; }

		public virtual DbSet<NetAlarmasRespuestas> NetAlarmasRespuestas { get; set; }

		public virtual DbSet<NetAlarmasTipos> NetAlarmasTipos { get; set; }

		public virtual DbSet<NetAlarmasTiposRespuestas> NetAlarmasTiposRespuestas { get; set; }

		public virtual DbSet<NetAlarmasTipoRespuestaOrigen> NetAlarmasTiposRespuestasOrigenes { get; set; }

		public virtual DbSet<OpcConfig> OpcConfigs { get; set; }

		public virtual DbSet<Opciones> Opciones { get; set; }

		public virtual DbSet<OpcionesRoles> OpcionesRoles { get; set; }

		public virtual DbSet<OpcionesUsuarios> OpcionesUsuarios { get; set; }

		public virtual DbSet<OperAcciones> OperAcciones { get; set; }

		public virtual DbSet<OperCabPlantillas> OperCabPlantillas { get; set; }

		public virtual DbSet<OperMotores> OperMotores { get; set; }

		public virtual DbSet<OperMotoresModulos> OperMotoresModulos { get; set; }

		public virtual DbSet<OperPlantillas> OperPlantillas { get; set; }

		public virtual DbSet<Ordenes> Ordenes { get; set; }

		public virtual DbSet<OrdenesAutoInicio> OrdenesAutoInicio { get; set; }

		public virtual DbSet<OrdenesDatosExtra> OrdenesDatosExtra { get; set; }

		[Obsolete]
		public virtual DbSet<OrdenesDetalle> OrdenesDetalle { get; set; }

		public virtual DbSet<OrdenesRelacion> OrdenesRelacion { get; set; }

		public virtual DbSet<OrdenesTransicionEstadosHistory> OrdenesTransicionEstadosHistory { get; set; }

		public virtual DbSet<Origenes> Origenes { get; set; }

		public virtual DbSet<Paises> Paises { get; set; }

		public virtual DbSet<Pistolas> Pistolas { get; set; }

		[Obsolete]
		public virtual DbSet<PivotProduccion> PivotProduccion { get; set; }

		[Obsolete]
		public virtual DbSet<PivotProduccionProducidos> PivotProduccionProducidos { get; set; }

		[Obsolete]
		public virtual DbSet<Pivots> Pivots { get; set; }

		public virtual DbSet<PrintJob> PrintJobs { get; set; }

		public virtual DbSet<Printer> Printers { get; set; }

		[Obsolete]
		public virtual DbSet<ProducidoConsumidoOrden> ProducidoConsumidoOrden { get; set; }

		[Obsolete]
		public virtual DbSet<ProducidoOrden> ProducidoOrden { get; set; }

		[Obsolete]
		public virtual DbSet<ProductoLotePrimerNivel> ProductoLotePrimerNivel { get; set; }

		[Obsolete]
		public virtual DbSet<ProductoLotePrimerNivelProvCli> ProductoLotePrimerNivelProvCli { get; set; }

		public virtual DbSet<ProductoEnvaseEtiqueta> ProductosEnvasesEtiquetas { get; set; }

		public virtual DbSet<ProductoMedidorCamino> ProductoMedidorCamino { get; set; }

		public virtual DbSet<Productos> Productos { get; set; }

		public virtual DbSet<ProductosGruposIncompatibilidades> ProductosGruposIncompatibilidades { get; set; }

		public virtual DbSet<ProductosOperCabPlantillas> ProductosOperCabPlantillas { get; set; }

		public virtual DbSet<Proveedores> Proveedores { get; set; }

		public virtual DbSet<ProveedoresOrigenes> ProveedoresOrigenes { get; set; }

		public virtual DbSet<Provincias> Provincias { get; set; }

		[Obsolete]
		public virtual DbSet<Puntos> Puntos { get; set; }

		public virtual DbSet<PuntosDescarga> PuntosDescarga { get; set; }

		public virtual DbSet<Recetas> Recetas { get; set; }

		public virtual DbSet<RecetasLineas> RecetasLineas { get; set; }

		public virtual DbSet<Regularizaciones> Regularizaciones { get; set; }

		public virtual DbSet<Resultados> Resultados { get; set; }

		[Obsolete]
		public virtual DbSet<ResultadosDetalle> ResultadosDetalle { get; set; }

		[Obsolete]
		public virtual DbSet<ResultadosExtended> ResultadosExtended { get; set; }

		[Obsolete]
		public virtual DbSet<ResultadosOrdenAgrupado> ResultadosOrdenAgrupado { get; set; }

		[Obsolete]
		public virtual DbSet<ResultadosPorDiaOrden> ResultadosPorDiaOrden { get; set; }

		[Obsolete]
		public virtual DbSet<SalidaLiniasReduced> SalidaLiniasReduced { get; set; }

		public virtual DbSet<Salidas> Salidas { get; set; }

		public virtual DbSet<SalidasAlbaranes> SalidasAlbaranes { get; set; }

		[Obsolete]
		public virtual DbSet<SalidasExtended> SalidasExtended { get; set; }

		[Obsolete]
		public virtual DbSet<SalidasInformeAduanas> SalidasInformeAduanas { get; set; }

		[Obsolete]
		public virtual DbSet<SalidasLineasExtended> SalidasLineasExtended { get; set; }

		[Obsolete]
		public virtual DbSet<SalidasLineasLoteExtended> SalidasLineasLoteExtended { get; set; }

		[Obsolete]
		public virtual DbSet<SalidasLineasResultados> SalidasLineasResultados { get; set; }

		public virtual DbSet<SalidasLinias> SalidasLinias { get; set; }

		public virtual DbSet<SalidasLiniasLote> SalidasLiniasLote { get; set; }

		public virtual DbSet<SalidasLiniasMedicaciones> SalidasLiniasMedicaciones { get; set; }

		[Obsolete]
		public virtual DbSet<SalidasLiniasMedicacionesExtended> SalidasLiniasMedicacionesExtended { get; set; }

		public virtual DbSet<SalidasLiniasMuestras> SalidasLiniasMuestras { get; set; }

		public virtual DbSet<SalidasLiniasPuntosDescarga> SalidasLiniasPuntosDescarga { get; set; }

		[Obsolete]
		public virtual DbSet<SalidasLotesServidos> SalidasLotesServidos { get; set; }

		public virtual DbSet<SalidasViajes> SalidasViajes { get; set; }

		[Obsolete]
		public virtual DbSet<SalidasViajesExtended> SalidasViajesExtended { get; set; }

		public virtual DbSet<Secciones> Secciones { get; set; }

		public virtual DbSet<SeccionesGrupos> SeccionesGrupos { get; set; }

		public virtual DbSet<Series> Series { get; set; }

		public virtual DbSet<ServerConfigs> ServerConfigs { get; set; }

		public virtual DbSet<Sesiones> Sesiones { get; set; }

		public virtual DbSet<SesionesModulo> SesionesModulo { get; set; }

		public virtual DbSet<SesionesSeccion> SesionesSeccion { get; set; }

		public virtual DbSet<SolicitudAjusteCaudal> SolicitudesAjusteCaudal { get; set; }

		[Obsolete]
		public virtual DbSet<StatusDisks> StatusDisks { get; set; }

		[Obsolete]
		public virtual DbSet<StockProductoLoteCaducidad> StockProductoLoteCaducidad { get; set; }

		public virtual DbSet<Stocks> Stocks { get; set; }

		public virtual DbSet<StocksReserva> StocksReserva { get; set; }

		public virtual DbSet<Tags> Tags { get; set; }

		public virtual DbSet<TagsBasculas> TagsBasculas { get; set; }

		public virtual DbSet<TagsLecturas> TagsLecturas { get; set; }

		public virtual DbSet<Tarifas> Tarifas { get; set; }

		public virtual DbSet<Tarjetas> Tarjetas { get; set; }

		public virtual DbSet<TempControles> TempControles { get; set; }

		public virtual DbSet<TempControlesMedidores> TempControlesMedidores { get; set; }

		public virtual DbSet<Tenant> Tenants { get; set; }

		[Obsolete]
		public virtual DbSet<TextosParametros> TextosParametros { get; set; }

		public virtual DbSet<TiempoLimpieza> TiempoLimpieza { get; set; }

		public virtual DbSet<TiposIva> TiposIva { get; set; }

		[Obsolete]
		public virtual DbSet<TotalCantidadPorOrden> TotalCantidadPorOrden { get; set; }

		[Obsolete]
		public virtual DbSet<TotalProducidoPorOrden> TotalProducidoPorOrden { get; set; }

		public virtual DbSet<Ubicaciones> Ubicaciones { get; set; }

		public virtual DbSet<UbicacionesAsociadas> UbicacionesAsociadas { get; set; }

		public virtual DbSet<UbicacionesOpcConfig> UbicacionesOpcConfig { get; set; }

		public virtual DbSet<UbisMedsAfino> UbisMedsAfino { get; set; }

		public virtual DbSet<Unidades> Unidades { get; set; }

		public virtual DbSet<Usuarios> Usuarios { get; set; }

		public virtual DbSet<UsuariosGruposLDAP> UsuariosGruposLDAP { get; set; }

		public virtual DbSet<UsuariosLogs> UsuariosLogs { get; set; }

		public virtual DbSet<UsuariosRoles> UsuariosRoles { get; set; }

		public virtual DbSet<UsuariosRolesConfigForm> UsuariosRolesConfigForm { get; set; }

		public virtual DbSet<UsuariosRolesInformes> UsuariosRolesInformes { get; set; }

		public virtual DbSet<UsuariosRolesModulos> UsuariosRolesModulos { get; set; }

		public virtual DbSet<Valores> Valores { get; set; }

		public virtual DbSet<Variables> Variables { get; set; }

		public virtual DbSet<Vehiculos> Vehiculos { get; set; }

		public virtual DbSet<Ventas> Ventas { get; set; }

		[Obsolete]
		public virtual DbSet<VentasExtended> VentasExtended { get; set; }

		[Obsolete]
		public virtual DbSet<VentasLineasExtended> VentasLineasExtended { get; set; }

		[Obsolete]
		public virtual DbSet<VentasLineasMedicacionesExtended> VentasLineasMedicacionesExtended { get; set; }

		public virtual DbSet<VentasLinias> VentasLinias { get; set; }

		public virtual DbSet<VentasLiniasMedicaciones> VentasLiniasMedicaciones { get; set; }

		public virtual DbSet<VentasLiniasPuntosDescarga> VentasLiniasPuntosDescarga { get; set; }

		public virtual DbSet<VersionTPrevisto> VersionTPrevisto { get; set; }

		public virtual DbSet<Versiones> Versiones { get; set; }

		public virtual DbSet<Veterinarios> Veterinarios { get; set; }

		[Obsolete]
		public virtual DbSet<recursivo> recursivo { get; set; }

		public VmesDbContext(DbContextOptions<VmesDbContext> dbContextOptions) : base(dbContextOptions) { }

		public async Task<int> GetNewLoteAsync(CancellationToken cancellationToken = default)
		{
			var loteSqlParameter = new SqlParameter
			{
				Direction = ParameterDirection.Output,
				ParameterName = "@lote",
				SqlDbType = SqlDbType.Int
			};
			await this.Database.ExecuteSqlInterpolatedAsync($"EXECUTE [GetNewLote] {loteSqlParameter} OUTPUT;", cancellationToken);
			return (int)loteSqlParameter.Value;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new Internal.Configurations.AditivosConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.AlarmasConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.AlertasSmtpConfigsConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.AlertasUsuariosConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.AlertasUsuariosAlarmasConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.AlertasUsuariosInformesConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.AlertasUsuariosInformesParametrosConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.AuditConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BackupsConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BasculaConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferConsumidosConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferERPCabOrdenesConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferERPChoferesConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferERPClienteDomicilioPuntoDescargaConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferERPClientesConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferERPClientesDomiciliosConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferERPComponentesConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferERPComprasConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferERPComprasLineasConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferERPConsumidosConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferERPDocumentosConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferERPEntradasConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferERPEntradasLineasConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferERPEntradasLineasLoteConfiguration());

			modelBuilder.Entity<BufferERPFormulaProductosFinales>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.HasOne(x => x.idFormulaNavigation)
					.WithMany(x => x.BufferERPFormulaProductosFinales)
					.HasForeignKey(x => x.idFormula)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_BufferERPFormulaProductosFinales_BufferERPFormulas");
			});

			modelBuilder.Entity<BufferERPFormulas>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.Property(x => x.VersionNueva)
					.HasDefaultValueSql("((0))");
			});

			modelBuilder.Entity<BufferERPImprimirDocumentos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasIndex(x => new { x.id, x.Preparado, x.Tratado, x.FTratado, x.Errores, x.RefERP, x.IdEntrada, x.IdSalida, x.FechaInsercion })
					.HasName("IBufferERPImprimirDocumentos1");
				entityTypeBuilder.HasIndex(x => new { x.id, x.Preparado, x.Tratado, x.FTratado, x.Errores, x.RefERP, x.IdSalida, x.IdEntrada, x.FechaInsercion })
					.HasName("IBufferERPImprimirDocumentos2");
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
			});

			modelBuilder.Entity<BufferERPLinOrdenes>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.Property(x => x.Tratado)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.HasOne(x => x.idCabordenNavigation)
					.WithMany(x => x.BufferERPLinOrdenes)
					.HasForeignKey(x => x.idCaborden)
					.HasConstraintName("FK_BufferERPLinOrdenes_BufferERPCabOrdenes");
			});

			modelBuilder.Entity<BufferERPPedidoVenta>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
			});

			modelBuilder.Entity<BufferERPPedidoVentaExtra>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
			});

			modelBuilder.Entity<BufferERPProducidos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasIndex(x => x.Tratado)
					.HasName("_dta_index_BufferERPProducidos_1");
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.Property(x => x.Tratado)
					.HasDefaultValueSql("((0))");
			});

			modelBuilder.Entity<BufferERPProductos>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.Property(x => x.PausaPosteriorDosificacion)
					.HasDefaultValueSql("((0))");
			});

			modelBuilder.Entity<BufferERPProveedores>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
			});

			modelBuilder.Entity<BufferERPRegularizaciones>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
			});

			modelBuilder.Entity<BufferERPSalidas>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
			});

			modelBuilder.Entity<BufferERPSalidasLinMedicamentos>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.HasOne(x => x.idSalidasLiniaNavigation)
					.WithMany(x => x.BufferERPSalidasLinMedicamentos)
					.HasForeignKey(x => x.idSalidasLinia)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_BufferERPSalidasLinMedicamentos_BufferERPSalidasLinias");
			});

			modelBuilder.Entity<BufferERPSalidasLinias>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.HasOne(x => x.idSalidasNavigation)
					.WithMany(x => x.BufferERPSalidasLinias)
					.HasForeignKey(x => x.idSalidas)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_BufferERPSalidasLinias_BufferERPSalidas");
				entityTypeBuilder.HasOne(x => x.idviajesNavigation)
					.WithMany(x => x.BufferERPSalidasLinias)
					.HasForeignKey(x => x.idviajes)
					.HasConstraintName("FK_BufferERPSalidasLinias_BufferERPSalidasViajes");
			});

			modelBuilder.Entity<BufferERPSalidasLiniasLote>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.Property(x => x.Timestamp)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.HasOne(x => x.idLineaSalidaNavigation)
					.WithMany(x => x.BufferERPSalidasLiniasLote)
					.HasForeignKey(x => x.idLineaSalida)
					.HasConstraintName("FK_BufferERPSalidasLiniasLote_BufferERPSalidasLinias");
				entityTypeBuilder.HasOne(x => x.idLineaSalidaMedicamentoNavigation)
					.WithMany(x => x.BufferERPSalidasLiniasLote)
					.HasForeignKey(x => x.idLineaSalidaMedicamento)
					.HasConstraintName("FK_BufferERPSalidasLiniasLote_BufferERPSalidasLinMedicamentos");
			});

			modelBuilder.Entity<BufferERPSalidasViajes>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
			});

			modelBuilder.Entity<BufferERPSolicitudRegularizacion>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.HasOne(x => x.IdLoteNavigation)
					.WithMany(x => x.BufferERPSolicitudRegularizacion)
					.HasForeignKey(x => x.IdLote)
					.HasConstraintName("FK_BufferERPSolicitudRegularizacion_Lotes");
				entityTypeBuilder.HasOne(x => x.IdUbicacionNavigation)
					.WithMany(x => x.BufferERPSolicitudRegularizacion)
					.HasForeignKey(x => x.IdUbicacion)
					.HasConstraintName("FK_BufferERPSolicitudRegularizacion_Ubicaciones");
				entityTypeBuilder.HasOne(x => x.IdUsuarioNavigation)
					.WithMany(x => x.BufferERPSolicitudRegularizacion)
					.HasForeignKey(x => x.IdUsuario)
					.HasConstraintName("FK_BufferERPSolicitudRegularizacion_Usuarios");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferERPSolicitudTraspasoConfiguration());

			modelBuilder.Entity<BufferERPStocks>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Acumulativo)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.Fecha)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.Property(x => x.Tratado)
					.HasDefaultValueSql("((0))");
			});

			modelBuilder.Entity<BufferERPVehiculos>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.Property(x => x.Timestamp)
					.HasDefaultValueSql("(getdate())");
			});

			modelBuilder.Entity<BufferERPVentas>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
			});

			modelBuilder.Entity<BufferERPVentasLineas>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
			});

			modelBuilder.Entity<BufferERPVersiones>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaInsercion)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.HasOne(x => x.idFormulaNavigation)
					.WithMany(x => x.BufferERPVersiones)
					.HasForeignKey(x => x.idFormula)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_BufferERPVersiones_BufferERPFormulas");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.BufferProducidosConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.CabOrdenesConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.CaminoConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.CaudalConfiguration());

			modelBuilder.Entity<CertificadoDesinfeccion>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.SerieNavigation)
					.WithMany(x => x.CertificadoDesinfeccion)
					.HasForeignKey(x => x.Serie)
					.HasConstraintName("FK_CertificadoDesinfeccion_Series");
				entityTypeBuilder.HasOne(x => x.idCamionNavigation)
					.WithMany(x => x.CertificadoDesinfeccion)
					.HasForeignKey(x => x.idCamion)
					.HasConstraintName("FK_CertificadoDesinfeccion_Vehiculos");
				entityTypeBuilder.HasOne(x => x.idOrdenNavigation)
					.WithMany(x => x.CertificadoDesinfeccion)
					.HasForeignKey(x => x.idOrden)
					.HasConstraintName("FK_CertificadoDesinfeccion_Ordenes");
				entityTypeBuilder.HasOne(x => x.idTransportistaNavigation)
					.WithMany(x => x.CertificadoDesinfeccion)
					.HasForeignKey(x => x.idTransportista)
					.HasConstraintName("FK_CertificadoDesinfeccion_Choferes");

#warning
#if NET7_0_OR_GREATER
				entityTypeBuilder.ToTable(x => x.HasTrigger("triggerInsertCertificadoDesinfeccion"));
#endif
			});

			modelBuilder.Entity<CertificadosDesinfeccionExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("CertificadosDesinfeccionExtended");
			});

			modelBuilder.Entity<Choferes>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Activo)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.HasOne(x => x.PaisNavigation)
					.WithMany(x => x.Choferes)
					.HasForeignKey(x => x.Pais)
					.HasConstraintName("FK_Choferes_Paises");
				entityTypeBuilder.HasOne(x => x.ProvinciaNavigation)
					.WithMany(x => x.Choferes)
					.HasForeignKey(x => x.Provincia)
					.HasConstraintName("FK_Choferes_Provincias");
				entityTypeBuilder.HasOne(x => x.TarjetaNavigation)
					.WithMany(x => x.Choferes)
					.HasForeignKey(x => x.Tarjeta)
					.HasConstraintName("FK_Choferes_SalidasViajes");
			});

			modelBuilder.Entity<Clientes>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.PaisNavigation)
					.WithMany(x => x.Clientes)
					.HasForeignKey(x => x.Pais)
					.HasConstraintName("FK_Clientes_Paises");
				entityTypeBuilder.HasOne(x => x.ProvinciaNavigation)
					.WithMany(x => x.Clientes)
					.HasForeignKey(x => x.Provincia)
					.HasConstraintName("FK_Clientes_Provincias");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.ComponentesConfiguration());

			modelBuilder.Entity<ComponentesActivos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.Producto, x.Orden });
			});

			modelBuilder.Entity<Compras>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasIndex(x => new { x.Serie, x.Numero })
					.HasName("IX_Compras")
					.IsUnique();
				entityTypeBuilder.HasOne(x => x.DepartamentoNavigation)
					.WithMany(x => x.Compras)
					.HasForeignKey(x => x.Departamento)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Compras_Departamentos");
				entityTypeBuilder.HasOne(x => x.ProveedorNavigation)
					.WithMany(x => x.Compras)
					.HasForeignKey(x => x.Proveedor)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Compras_Proveedores");
				entityTypeBuilder.HasOne(x => x.SerieNavigation)
					.WithMany(x => x.Compras)
					.HasForeignKey(x => x.Serie)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Compras_Series");
				entityTypeBuilder.HasOne(x => x.idContratoNavigation)
					.WithMany(x => x.Compras)
					.HasForeignKey(x => x.idContrato)
					.HasConstraintName("FK__Compras__idContr__0559BDD1");

#warning
#if NET7_0_OR_GREATER
				entityTypeBuilder.ToTable(x => x.HasTrigger("triggerInsertCompras"));
#endif
			});

			modelBuilder.Entity<ComprasExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ComprasExtended");
			});

			modelBuilder.Entity<ComprasLineasExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ComprasLineasExtended");
			});

			modelBuilder.Entity<Comprobaciones>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.Tabla, x.Comprobacion });
				entityTypeBuilder.Property(x => x.Activo)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.Property(x => x.Id)
					.ValueGeneratedOnAdd();
			});

			modelBuilder.Entity<ConfigWCF>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.id)
					.ValueGeneratedOnAdd();
			});

			modelBuilder.Entity<ConsumidoOrden>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ConsumidoOrden");
			});

			modelBuilder.Entity<Contadores>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Fecha)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.Property(x => x.id)
					.ValueGeneratedOnAdd();
			});

			modelBuilder.Entity<Contratos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.IdClienteNavigation)
					.WithMany(x => x.Contratos)
					.HasForeignKey(x => x.IdCliente)
					.HasConstraintName("FK_Contratos_Clientes");
				entityTypeBuilder.HasOne(x => x.IdProductoNavigation)
					.WithMany(x => x.Contratos)
					.HasForeignKey(x => x.IdProducto)
					.HasConstraintName("FK_Contratos_Productos");
				entityTypeBuilder.HasOne(x => x.IdProveedorNavigation)
					.WithMany(x => x.Contratos)
					.HasForeignKey(x => x.IdProveedor)
					.HasConstraintName("FK_Contratos_Proveedores");
				entityTypeBuilder.HasOne(x => x.UnidadNavigation)
					.WithMany(x => x.Contratos)
					.HasForeignKey(x => x.Unidad)
					.HasConstraintName("FK_Contratos_Unidades");
			});

			modelBuilder.Entity<ControlesNIRProductos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.idControlNir, x.idProducto });
				entityTypeBuilder.Property(x => x.id)
					.ValueGeneratedOnAdd();
				entityTypeBuilder.HasOne(x => x.idControlNirNavigation)
					.WithMany(x => x.ControlesNIRProductos)
					.HasForeignKey(x => x.idControlNir)
					.HasConstraintName("FK_ControlesNIRProductos_ControlesNIR");
				entityTypeBuilder.HasOne(x => x.idProductoNavigation)
					.WithMany(x => x.ControlesNIRProductos)
					.HasForeignKey(x => x.idProducto)
					.HasConstraintName("FK_ControlesNIRProductos_Productos");
			});

			modelBuilder.Entity<DEBUG_ResultadosSinMovimientos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("DEBUG_ResultadosSinMovimientos");
			});

			modelBuilder.Entity<DashOrdenes>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("DashOrdenes");
				entityTypeBuilder.Property(x => x.Estado)
					.IsUnicode(false);
				entityTypeBuilder.Property(x => x.Modificada)
					.IsUnicode(false);
				entityTypeBuilder.Property(x => x.Turno)
					.IsUnicode(false);
			});

			modelBuilder.Entity<DashVistaStocks>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("DashVistaStocks");
				entityTypeBuilder.Property(x => x.TipoProducto)
					.IsUnicode(false);
			});

			modelBuilder.Entity<DashboardsLib>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.VisibleUsuario)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.HasOne(x => x.IdCategoriaNavigation)
					.WithMany(x => x.DashboardsLib)
					.HasForeignKey(x => x.IdCategoria)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_DashboardsLib_DashboardsLibCategorias");
				entityTypeBuilder.HasOne(x => x.IdDashboardBaseNavigation)
					.WithMany(x => x.InverseIdDashboardBaseNavigation)
					.HasForeignKey(x => x.IdDashboardBase)
					.HasConstraintName("FK_DashboardsLib_DashboardsLib");
			});

			modelBuilder.Entity<DashboardsLibCategorias>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.isModificable)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.Property(x => x.isVisible)
					.HasDefaultValueSql("((1))");
			});

			modelBuilder.Entity<DatosMuestraEntrada>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("DatosMuestraEntrada");
			});

			modelBuilder.Entity<Departamentos>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Activo)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.HasOne(x => x.ProvinciaNavigation)
					.WithMany(x => x.Departamentos)
					.HasForeignKey(x => x.Provincia)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Departamentos_Provincias");
			});

			modelBuilder.Entity<Desgloses>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasIndex(x => x.Fecha)
					.HasName("IndDesgloses_Fecha");
				entityTypeBuilder.HasIndex(x => x.FinalMedidor)
					.HasName("_dta_index_Desgloses_1");
				entityTypeBuilder.HasIndex(x => new { x.Lote, x.Cantidad, x.Orden })
					.HasName("_dta_index_Desgloses_6_1357247890__K3_6_8");
				entityTypeBuilder.HasIndex(x => new { x.MedidorId, x.Orden, x.Producto, x.Ubicacion, x.Lote })
					.HasName("IndDesgloses_MedidorOrdenProductoUbicacionLote");
				entityTypeBuilder.HasIndex(x => new { x.Id, x.Producto, x.Lote, x.Ubicacion, x.Cantidad, x.Ciclo, x.Fecha, x.Temperatura, x.Humedad, x.TiempoEfectivo, x.TiempoTotal, x.KWhEfectivo, x.KWhTotal, x.MedidorId, x.Orden })
					.HasName("IndDesgloses_Orden");
				entityTypeBuilder.HasOne(x => x.EnvaseNavigation)
					.WithMany(x => x.Desgloses)
					.HasForeignKey(x => x.Envase)
					.HasConstraintName("FK_Desgloses_Envases");
				entityTypeBuilder.HasOne(x => x.LoteNavigation)
					.WithMany(x => x.Desgloses)
					.HasForeignKey(x => x.Lote)
					.HasConstraintName("FK_Desgloses_Lotes");
				entityTypeBuilder.HasOne(x => x.Medidor)
					.WithMany(x => x.Desgloses)
					.HasForeignKey(x => x.MedidorId)
					.HasConstraintName("FK_Desgloses_Medidores");
				entityTypeBuilder.HasOne(x => x.OrdenNavigation)
					.WithMany(x => x.Desgloses)
					.HasForeignKey(x => x.Orden)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Desgloses_Ordenes");
				entityTypeBuilder.HasOne(x => x.ProductoNavigation)
					.WithMany(x => x.Desgloses)
					.HasForeignKey(x => x.Producto)
					.HasConstraintName("FK_Desgloses_Productos");
				entityTypeBuilder.HasOne(x => x.UbicacionNavigation)
					.WithMany(x => x.Desgloses)
					.HasForeignKey(x => x.Ubicacion)
					.HasConstraintName("FK_Desgloses_Ubicaciones");
				entityTypeBuilder.HasOne(x => x.UnidadNavigation)
					.WithMany(x => x.Desgloses)
					.HasForeignKey(x => x.Unidad)
					.HasConstraintName("FK_Desgloses_Unidades");
			});

			modelBuilder.Entity<DesglosesDetalle>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("DesglosesDetalle");
			});

			modelBuilder.Entity<DesglosesExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("DesglosesExtended");
			});

			modelBuilder.Entity<Destinos>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Activo)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.Property(x => x.ComprobarProducto)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.Property(x => x.DestinoVolteo)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.HasOne(x => x.ModuloNavigation)
					.WithMany(x => x.Destinos)
					.HasForeignKey(x => x.Modulo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Destinos_Modulos");
				entityTypeBuilder.HasOne(x => x.UbicacionNavigation)
					.WithMany(x => x.Destinos)
					.HasForeignKey(x => x.Ubicacion)
					.HasConstraintName("FK_Destinos_Ubicaciones");
			});

			modelBuilder.Entity<DestinosMedidores>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idDestinoNavigation)
					.WithMany(x => x.DestinosMedidores)
					.HasForeignKey(x => x.idDestino)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_DestinosMedidores_Destinos");
				entityTypeBuilder.HasOne(x => x.idMedidorNavigation)
					.WithMany(x => x.DestinosMedidores)
					.HasForeignKey(x => x.idMedidor)
					.HasConstraintName("FK_DestinosMedidores_Medidores");
			});

			modelBuilder.Entity<Disposiciones>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasIndex(x => new { x.Id, x.Serie, x.IdOld, x.Producto, x.Lote, x.Ubicacion, x.Cantidad, x.Servida, x.Unidad, x.Tipo, x.CantidadPrincipal, x.TipoRegistro, x.Finalizado, x.Porcentaje, x.Importado, x.Exportado, x.ordenacion, x.SerieOld, x.Orden })
					.HasName("IDisposiciones1");
				entityTypeBuilder.Property(x => x.ordenacion)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.HasOne(x => x.FormatoNavigation)
					.WithMany(x => x.Disposiciones)
					.HasForeignKey(x => x.Formato)
					.HasConstraintName("FK_Disposiciones_Formatos");
				entityTypeBuilder.HasOne(x => x.LoteNavigation)
					.WithMany(x => x.Disposiciones)
					.HasForeignKey(x => x.Lote)
					.HasConstraintName("FK_Disposiciones_Lotes");
				entityTypeBuilder.HasOne(x => x.OrdenNavigation)
					.WithMany(x => x.Disposiciones)
					.HasForeignKey(x => x.Orden)
					.HasConstraintName("FK_Disposiciones_Ordenes");
				entityTypeBuilder.HasOne(x => x.ProductoNavigation)
					.WithMany(x => x.Disposiciones)
					.HasForeignKey(x => x.Producto)
					.HasConstraintName("FK_Disposiciones_Productos");
				entityTypeBuilder.HasOne(x => x.UbicacionNavigation)
					.WithMany(x => x.Disposiciones)
					.HasForeignKey(x => x.Ubicacion)
					.HasConstraintName("FK_Disposiciones_Ubicaciones");
				entityTypeBuilder.HasOne(x => x.UnidadNavigation)
					.WithMany(x => x.Disposiciones)
					.HasForeignKey(x => x.Unidad)
					.HasConstraintName("FK_Disposiciones_Unidades");
			});

			modelBuilder.Entity<Domicilios>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.ClienteNavigation)
					.WithMany(x => x.Domicilios)
					.HasForeignKey(x => x.Cliente)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_Domicilios_Clientes");
				entityTypeBuilder.HasOne(x => x.EspecieNavigation)
					.WithMany(x => x.Domicilios)
					.HasForeignKey(x => x.Especie)
					.HasConstraintName("FK_Domicilios_Especies");
				entityTypeBuilder.HasOne(x => x.PaisNavigation)
					.WithMany(x => x.Domicilios)
					.HasForeignKey(x => x.Pais)
					.HasConstraintName("FK_Domicilios_Paises");
				entityTypeBuilder.HasOne(x => x.ProvinciaNavigation)
					.WithMany(x => x.Domicilios)
					.HasForeignKey(x => x.Provincia)
					.HasConstraintName("FK_Domicilios_Provincias");
			});

			modelBuilder.Entity<DomiciliosExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("DomiciliosExtended");
			});

			modelBuilder.Entity<Dominios>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.DepartamentoNavigation)
					.WithMany(x => x.Dominios)
					.HasForeignKey(x => x.Departamento)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_Dominios_Departamentos");
				entityTypeBuilder.HasOne(x => x.FamiliaNavigation)
					.WithMany(x => x.Dominios)
					.HasForeignKey(x => x.Familia)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_Dominios_Familias");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.DosificacionesConfiguration());

			modelBuilder.Entity<DosificacionesDetalle>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("DosificacionesDetalle");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.ElectrovalvulaConfiguration());

			modelBuilder.Entity<EmpresasTransporte>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Activo)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.HasOne(x => x.PaisNavigation)
					.WithMany(x => x.EmpresasTransporte)
					.HasForeignKey(x => x.Pais)
					.HasConstraintName("FK_EmpresasTransporte_Paises");
				entityTypeBuilder.HasOne(x => x.ProvinciaNavigation)
					.WithMany(x => x.EmpresasTransporte)
					.HasForeignKey(x => x.Provincia)
					.HasConstraintName("FK_EmpresasTransporte_Provincias");
			});

			modelBuilder.Entity<EnlaceERP>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Activo)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.DependenciaEstricta)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.Property(x => x.EliminarFichero)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.Property(x => x.ImportarMP)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.Manual)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.NumDecimales)
					.HasDefaultValueSql("((3))");
				entityTypeBuilder.HasOne(x => x.idEnlaceERPTipoNavigation)
					.WithMany(x => x.EnlaceERP)
					.HasForeignKey(x => x.idEnlaceERPTipo)
					.HasConstraintName("FK_EnlaceERP_EnlaceERPTipo");
			});

			modelBuilder.Entity<EnlaceERPAsigUbi>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Id)
					.ValueGeneratedNever();
				entityTypeBuilder.HasOne(x => x.IdProductoNavigation)
					.WithMany(x => x.EnlaceERPAsigUbi)
					.HasForeignKey(x => x.IdProducto)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_EnlaceERPAsigUbi_Productos");
				entityTypeBuilder.HasOne(x => x.IdUbicacionNavigation)
					.WithMany(x => x.EnlaceERPAsigUbi)
					.HasForeignKey(x => x.IdUbicacion)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_EnlaceERPAsigUbi_Ubicaciones");
			});

			modelBuilder.Entity<EnlaceERPLinea>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idEnlaceERPNavigation)
					.WithMany(x => x.EnlaceERPLinea)
					.HasForeignKey(x => x.idEnlaceERP)
					.HasConstraintName("FK_EnlaceERPLinea_EnlaceERP");
				entityTypeBuilder.HasOne(x => x.idEnlaceERPTipoLineaNavigation)
					.WithMany(x => x.EnlaceERPLinea)
					.HasForeignKey(x => x.idEnlaceERPTipoLinea)
					.HasConstraintName("FK_EnlaceERPLinea_EnlaceERPTipoLinea");
			});

			modelBuilder.Entity<EnlaceERPTipoLinea>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idEnlaceERPTipoNavigation)
					.WithMany(x => x.EnlaceERPTipoLinea)
					.HasForeignKey(x => x.idEnlaceERPTipo)
					.HasConstraintName("FK_EnlaceERPTipoLinea_EnlaceERPTipo");
			});

			modelBuilder.Entity<Entradas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.SerieNavigation)
					.WithMany(x => x.Entradas)
					.HasForeignKey(x => x.Serie)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Entradas_Series");
				entityTypeBuilder.HasOne(x => x.idChoferNavigation)
					.WithMany(x => x.Entradas)
					.HasForeignKey(x => x.idChofer)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Entradas_Choferes");
				entityTypeBuilder.HasOne(x => x.idEmpresaTransporteNavigation)
					.WithMany(x => x.Entradas)
					.HasForeignKey(x => x.idEmpresaTransporte)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Entradas_EmpresasTransporte");
				entityTypeBuilder.HasOne(x => x.idProveedorNavigation)
					.WithMany(x => x.Entradas)
					.HasForeignKey(x => x.idProveedor)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Entradas_Proveedores");
				entityTypeBuilder.HasOne(x => x.idTarjetaNavigation)
					.WithMany(x => x.Entradas)
					.HasForeignKey(x => x.idTarjeta)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Entradas_Tarjetas");
				entityTypeBuilder.HasOne(x => x.idVehiculoNavigation)
					.WithMany(x => x.Entradas)
					.HasForeignKey(x => x.idVehiculo)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Entradas_Vehiculos");

#warning
#if NET7_0_OR_GREATER
				entityTypeBuilder.ToTable(x => x.HasTrigger("triggerInsertEntradas"));
#endif
			});

			modelBuilder.Entity<EntradasContratos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idContratoNavigation)
					.WithMany(x => x.EntradasContratos)
					.HasForeignKey(x => x.idContrato)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_EntradasContratos_Contratos");
				entityTypeBuilder.HasOne(x => x.idEntradasLineasNavigation)
					.WithMany(x => x.EntradasContratos)
					.HasForeignKey(x => x.idEntradasLineas)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_EntradasContratos_EntradasLineas");
			});

			modelBuilder.Entity<EntradasExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("EntradasExtended");
			});

			modelBuilder.Entity<EntradasExtendedLineasEntradasExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("EntradasExtendedLineasEntradasExtended");
			});

			modelBuilder.Entity<EntradasLineas>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.AnadirStockPesaje)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.TaraAplicada)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.TipoOrigen)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.HasOne(x => x.Destino1Navigation)
					.WithMany(x => x.EntradasLineasDestino1Navigation)
					.HasForeignKey(x => x.Destino1)
					.HasConstraintName("FK_EntradasLineas_Ubicaciones1");
				entityTypeBuilder.HasOne(x => x.Destino2Navigation)
					.WithMany(x => x.EntradasLineasDestino2Navigation)
					.HasForeignKey(x => x.Destino2)
					.HasConstraintName("FK_EntradasLineas_Ubicaciones2");
				entityTypeBuilder.HasOne(x => x.Destino3Navigation)
					.WithMany(x => x.EntradasLineasDestino3Navigation)
					.HasForeignKey(x => x.Destino3)
					.HasConstraintName("FK_EntradasLineas_Ubicaciones3");
				entityTypeBuilder.HasOne(x => x.Destino4Navigation)
					.WithMany(x => x.EntradasLineasDestino4Navigation)
					.HasForeignKey(x => x.Destino4)
					.HasConstraintName("FK_EntradasLineas_Ubicaciones4");
				entityTypeBuilder.HasOne(x => x.EnvaseNavigation)
					.WithMany(x => x.EntradasLineas)
					.HasForeignKey(x => x.Envase)
					.HasConstraintName("FK_EntradasLineas_Envases");
				entityTypeBuilder.HasOne(x => x.FormatoNavigation)
					.WithMany(x => x.EntradasLineas)
					.HasForeignKey(x => x.Formato)
					.HasConstraintName("FK_EntradasLineas_Formatos");
				entityTypeBuilder.HasOne(x => x.LoteNavigation)
					.WithMany(x => x.EntradasLineas)
					.HasForeignKey(x => x.Lote)
					.HasConstraintName("FK_EntradasLineas_Lotes");
				entityTypeBuilder.HasOne(x => x.Origen1Navigation)
					.WithMany(x => x.EntradasLineasOrigen1Navigation)
					.HasForeignKey(x => x.Origen1)
					.HasConstraintName("FK_EntradasLineas_Ubicaciones5");
				entityTypeBuilder.HasOne(x => x.Origen2Navigation)
					.WithMany(x => x.EntradasLineasOrigen2Navigation)
					.HasForeignKey(x => x.Origen2)
					.HasConstraintName("FK_EntradasLineas_Ubicaciones6");
				entityTypeBuilder.HasOne(x => x.Origen3Navigation)
					.WithMany(x => x.EntradasLineasOrigen3Navigation)
					.HasForeignKey(x => x.Origen3)
					.HasConstraintName("FK_EntradasLineas_Ubicaciones7");
				entityTypeBuilder.HasOne(x => x.Origen4Navigation)
					.WithMany(x => x.EntradasLineasOrigen4Navigation)
					.HasForeignKey(x => x.Origen4)
					.HasConstraintName("FK_EntradasLineas_Ubicaciones8");
				entityTypeBuilder.HasOne(x => x.UnidadNavigation)
					.WithMany(x => x.EntradasLineas)
					.HasForeignKey(x => x.Unidad)
					.HasConstraintName("FK_EntradasLineas_Unidades");
				entityTypeBuilder.HasOne(x => x.idBasculaPesajeBrutoNavigation)
					.WithMany(x => x.EntradasLineasidBasculaPesajeBrutoNavigation)
					.HasForeignKey(x => x.idBasculaPesajeBruto)
					.HasConstraintName("FK_EntradasLineas_BasculasBruto");
				entityTypeBuilder.HasOne(x => x.idBasculaPesajeNetoNavigation)
					.WithMany(x => x.EntradasLineasidBasculaPesajeNetoNavigation)
					.HasForeignKey(x => x.idBasculaPesajeNeto)
					.HasConstraintName("FK_EntradasLineas_BasculasNeto");
				entityTypeBuilder.HasOne(x => x.idEntradasNavigation)
					.WithMany(x => x.EntradasLineas)
					.HasForeignKey(x => x.idEntradas)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_EntradasLineas_Entradas");
				entityTypeBuilder.HasOne(x => x.idModuloNavigation)
					.WithMany(x => x.EntradasLineas)
					.HasForeignKey(x => x.idModulo)
					.HasConstraintName("FK_EntradasLineas_Modulos");
				entityTypeBuilder.HasOne(x => x.idOrigenProvNavigation)
					.WithMany(x => x.EntradasLineas)
					.HasForeignKey(x => x.idOrigenProv)
					.HasConstraintName("FK_EntradasLineas_ProveedoresOrigenes");
				entityTypeBuilder.HasOne(x => x.idProductoNavigation)
					.WithMany(x => x.EntradasLineas)
					.HasForeignKey(x => x.idProducto)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_EntradasLineas_Productos");
				entityTypeBuilder.HasOne(x => x.idProveedorNavigation)
					.WithMany(x => x.EntradasLineas)
					.HasForeignKey(x => x.idProveedor)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_EntradasLineas_Proveedores");
			});

			modelBuilder.Entity<EntradasLineasExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("EntradasLineasExtended");
			});

			modelBuilder.Entity<EntradasLineasResultadosNIR>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idControlesNirNavigation)
					.WithMany(x => x.EntradasLineasResultadosNIR)
					.HasForeignKey(x => x.idControlesNir)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_EntradasLineasResultadosNIR_ControlesNIR");
				entityTypeBuilder.HasOne(x => x.idEntradasLineasNavigation)
					.WithMany(x => x.EntradasLineasResultadosNIR)
					.HasForeignKey(x => x.idEntradasLineas)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_EntradasLineasResultadosNIR_EntradasLineas");
			});

			modelBuilder.Entity<EntradasLineasResultadosNIRExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("EntradasLineasResultadosNIRExtended");
				entityTypeBuilder.Property(x => x.id)
					.ValueGeneratedOnAdd();
			});

			modelBuilder.Entity<EntradasLotes>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.IdEntradasLineasNavigation)
					.WithMany(x => x.EntradasLotes)
					.HasForeignKey(x => x.IdEntradasLineas)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_EntradasLotes_EntradasLineas");
				entityTypeBuilder.HasOne(x => x.IdLoteNavigation)
					.WithMany(x => x.EntradasLotes)
					.HasForeignKey(x => x.IdLote)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_EntradasLotes_Lotes");
			});

			modelBuilder.Entity<Envases>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.ModoUdsFormato)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.HasOne(x => x.UnidadNavigation)
					.WithMany(x => x.Envases)
					.HasForeignKey(x => x.Unidad)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Envases_Unidades");
			});

			modelBuilder.Entity<EtiquetaMuestraProduccion>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("EtiquetaMuestraProduccion");
			});

			modelBuilder.Entity<EtiquetaStock>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("EtiquetaStock");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.EventosConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.EventosDetalleConfiguration());

			modelBuilder.Entity<Existencias>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.EnvaseNavigation)
					.WithMany(x => x.Existencias)
					.HasForeignKey(x => x.Envase)
					.HasConstraintName("FK_Existencias_Envases");
				entityTypeBuilder.HasOne(x => x.FormatoNavigation)
					.WithMany(x => x.Existencias)
					.HasForeignKey(x => x.Formato)
					.HasConstraintName("FK_Existencias_Formatos");
				entityTypeBuilder.HasOne(x => x.InventarioNavigation)
					.WithMany(x => x.Existencias)
					.HasForeignKey(x => x.Inventario)
					.HasConstraintName("FK_Existencias_Inventarios");
				entityTypeBuilder.HasOne(x => x.LoteNavigation)
					.WithMany(x => x.Existencias)
					.HasForeignKey(x => x.Lote)
					.HasConstraintName("FK_Existencias_Lotes");
				entityTypeBuilder.HasOne(x => x.ProductoNavigation)
					.WithMany(x => x.Existencias)
					.HasForeignKey(x => x.Producto)
					.HasConstraintName("FK_Existencias_Productos");
				entityTypeBuilder.HasOne(x => x.UbicacionNavigation)
					.WithMany(x => x.Existencias)
					.HasForeignKey(x => x.Ubicacion)
					.HasConstraintName("FK_Existencias_Ubicaciones");
				entityTypeBuilder.HasOne(x => x.UnidadNavigation)
					.WithMany(x => x.Existencias)
					.HasForeignKey(x => x.Unidad)
					.HasConstraintName("FK_Existencias_Unidades");
				entityTypeBuilder.HasOne(x => x.idEntradaLineaNavigation)
					.WithMany(x => x.Existencias)
					.HasForeignKey(x => x.idEntradaLinea)
					.HasConstraintName("FK_Existencias_EntradasLineas");
				entityTypeBuilder.HasOne(x => x.idProveedorNavigation)
					.WithMany(x => x.Existencias)
					.HasForeignKey(x => x.idProveedor)
					.HasConstraintName("FK_Existencias_Proveedores");
			});

			modelBuilder.Entity<ExistenciasProductoLote>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ExistenciasProductoLote");
			});

			modelBuilder.Entity<Familias>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.AnalisiNavigation)
					.WithMany(x => x.Familias)
					.HasForeignKey(x => x.Analisi)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Familias_Analisis");
				entityTypeBuilder.HasOne(x => x.DepartamentoNavigation)
					.WithMany(x => x.Familias)
					.HasForeignKey(x => x.Departamento)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Familias_Departamentos");
			});

			modelBuilder.Entity<FileGmaoElement>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.FileId, x.GmaoElementId })
					.HasName("PK__FileGmao__99EA4154D1B29574");
				entityTypeBuilder.HasOne(x => x.File)
					.WithMany(x => x.FileGmaoElement)
					.HasForeignKey(x => x.FileId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__FileGmaoE__FileI__5575A085");
				entityTypeBuilder.HasOne(x => x.GmaoElement)
					.WithMany(x => x.FileGmaoElement)
					.HasForeignKey(x => x.GmaoElementId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__FileGmaoE__GmaoE__5669C4BE");
			});

			modelBuilder.Entity<Files>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Id)
					.ValueGeneratedNever();
			});

			modelBuilder.Entity<FormulaProdModulo>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idFormularioNavigation)
					.WithMany(x => x.FormulaProdModulo)
					.HasForeignKey(x => x.idFormulario)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_FormulaProdModulo_Formularios");
				entityTypeBuilder.HasOne(x => x.idModuloNavigation)
					.WithMany(x => x.FormulaProdModulo)
					.HasForeignKey(x => x.idModulo)
					.HasConstraintName("FK_FormulaProdModulo_Modulos");
				entityTypeBuilder.HasOne(x => x.idProductoNavigation)
					.WithMany(x => x.FormulaProdModulo)
					.HasForeignKey(x => x.idProducto)
					.HasConstraintName("FK_FormulaProdModulo_Productos");
				entityTypeBuilder.HasOne(x => x.idUbicacionNavigation)
					.WithMany(x => x.FormulaProdModulo)
					.HasForeignKey(x => x.idUbicacion)
					.HasConstraintName("FK_FormulaProdModulo_Ubicaciones");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.FormulariosConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.FormulasConfiguration());

			modelBuilder.Entity<GMAO_Archivos_Elementos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.idElemento, x.idArchivo });
				entityTypeBuilder.HasOne(x => x.idArchivoNavigation)
					.WithMany(x => x.GMAO_Archivos_Elementos)
					.HasForeignKey(x => x.idArchivo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_Archivos_Elementos_GMAO_Archivos");
				entityTypeBuilder.HasOne(x => x.idElementoNavigation)
					.WithMany(x => x.GMAO_Archivos_Elementos)
					.HasForeignKey(x => x.idElemento)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_Archivos_Elementos_GMAO_Elementos");
			});

			modelBuilder.Entity<GMAO_Archivos_Intervenciones>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.idIntervencion, x.idArchivo })
					.HasName("PK_GMAO_Intervenciones");
				entityTypeBuilder.HasOne(x => x.idArchivoNavigation)
					.WithMany(x => x.GMAO_Archivos_Intervenciones)
					.HasForeignKey(x => x.idArchivo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_ElemIntervenciones_GMAO_Archivos");
				entityTypeBuilder.HasOne(x => x.idIntervencionNavigation)
					.WithMany(x => x.GMAO_Archivos_Intervenciones)
					.HasForeignKey(x => x.idIntervencion)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_Archivos_Intervenciones_GMAO_ElemIntervenciones");
			});

			modelBuilder.Entity<GMAO_Archivos_Modelos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.idModelo, x.idArchivo })
					.HasName("PK_GMAO_ArchivosModelos");
				entityTypeBuilder.HasOne(x => x.idArchivoNavigation)
					.WithMany(x => x.GMAO_Archivos_Modelos)
					.HasForeignKey(x => x.idArchivo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_Modelos_GMAO_Archivos");
				entityTypeBuilder.HasOne(x => x.idModeloNavigation)
					.WithMany(x => x.GMAO_Archivos_Modelos)
					.HasForeignKey(x => x.idModelo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_Archivos_Modelos_GMAO_MarcasModelos");
			});

			modelBuilder.Entity<GMAO_Archivos_Tipos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.idTipoElemento, x.idArchivo });
				entityTypeBuilder.HasOne(x => x.idArchivoNavigation)
					.WithMany(x => x.GMAO_Archivos_Tipos)
					.HasForeignKey(x => x.idArchivo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_Archivos_Tipos_GMAO_Archivos");
				entityTypeBuilder.HasOne(x => x.idTipoElementoNavigation)
					.WithMany(x => x.GMAO_Archivos_Tipos)
					.HasForeignKey(x => x.idTipoElemento)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_Archivos_Tipos_GMAO_ElementosTipos");
			});

			modelBuilder.Entity<GMAO_CaracteristicasElementos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.idElemento, x.idCaracteristica });
				entityTypeBuilder.HasOne(x => x.idCaracteristicaNavigation)
					.WithMany(x => x.GMAO_CaracteristicasElementos)
					.HasForeignKey(x => x.idCaracteristica)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_CaracteristicasElementos_GMAO_Caracteristicas");
				entityTypeBuilder.HasOne(x => x.idElementoNavigation)
					.WithMany(x => x.GMAO_CaracteristicasElementos)
					.HasForeignKey(x => x.idElemento)
					.HasConstraintName("FK_GMAO_CaracteristicasElementos_GMAO_Elementos");
			});

			modelBuilder.Entity<GMAO_CaracteristicasTipos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.idTipoElemento, x.idCaracteristica });
				entityTypeBuilder.HasOne(x => x.idCaracteristicaNavigation)
					.WithMany(x => x.GMAO_CaracteristicasTipos)
					.HasForeignKey(x => x.idCaracteristica)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_CaracteristicasTipos_GMAO_Caracteristicas");
				entityTypeBuilder.HasOne(x => x.idTipoElementoNavigation)
					.WithMany(x => x.GMAO_CaracteristicasTipos)
					.HasForeignKey(x => x.idTipoElemento)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_CaracteristicasTipos_GMAO_ElementosTipos");
			});

			modelBuilder.Entity<GMAO_Compras>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaPedido)
					.HasConversion(
						x => x.ToLocalTime(),
						x => DateTime.SpecifyKind(x, DateTimeKind.Local)
					);
				entityTypeBuilder.Property(x => x.FechaRecepcion)
					.HasConversion(
						x => x.Value.ToLocalTime(),
						x => DateTime.SpecifyKind(x, DateTimeKind.Local)
					);
				entityTypeBuilder.Property(x => x.FechaRecepcionPrevista)
					.HasConversion(
						x => x.Value.ToLocalTime(),
						x => DateTime.SpecifyKind(x, DateTimeKind.Local)
					);
				entityTypeBuilder.HasOne(x => x.IdProveedorNavigation)
					.WithMany(x => x.GMAO_Compras)
					.HasForeignKey(x => x.IdProveedor)
					.HasConstraintName("FK_GMAO_Compras_GMAO_Proveedores");
			});

			modelBuilder.Entity<GMAO_ComprasLineas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idCompraNavigation)
					.WithMany(x => x.GMAO_ComprasLineas)
					.HasForeignKey(x => x.idCompra)
					.HasConstraintName("FK_GMAO_ComprasLineas_GMAO_Compras");
				entityTypeBuilder.HasOne(x => x.idElementoNavigation)
					.WithMany(x => x.GMAO_ComprasLineas)
					.HasForeignKey(x => x.idElemento)
					.HasConstraintName("FK_GMAO_ComprasLineas_GMAO_Elementos");
			});

			modelBuilder.Entity<GMAO_Departamentos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.IdResponsableNavigation)
					.WithMany(x => x.GMAO_Departamentos)
					.HasForeignKey(x => x.IdResponsable)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_GMAO_Departamentos_GMAO_Operarios");
			});

			modelBuilder.Entity<GMAO_Deps_Operarios>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.idDepartamento, x.idOperario });
				entityTypeBuilder.HasOne(x => x.idDepartamentoNavigation)
					.WithMany(x => x.GMAO_Deps_Operarios)
					.HasForeignKey(x => x.idDepartamento)
					.HasConstraintName("FK_GMAO_Deps_Operarios_GMAO_Departamentos");
				entityTypeBuilder.HasOne(x => x.idOperarioNavigation)
					.WithMany(x => x.GMAO_Deps_Operarios)
					.HasForeignKey(x => x.idOperario)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_Deps_Operarios_GMAO_Operarios");
			});

			modelBuilder.Entity<GMAO_ElemAlternativos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.IdPadre, x.IdHijo });
				entityTypeBuilder.HasOne(x => x.IdHijoNavigation)
					.WithMany(x => x.GMAO_ElemAlternativosIdHijoNavigation)
					.HasForeignKey(x => x.IdHijo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_ElemAlternativos_Hijo");
				entityTypeBuilder.HasOne(x => x.IdPadreNavigation)
					.WithMany(x => x.GMAO_ElemAlternativosIdPadreNavigation)
					.HasForeignKey(x => x.IdPadre)
					.HasConstraintName("FK_GMAO_ElemAlternativos_Padre");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.GMAO_ElemIntervencionesConfiguration());

			modelBuilder.Entity<GMAO_ElemIntervencionesPiezas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.Element)
					.WithMany(x => x.GMAO_ElemIntervencionesPiezas)
					.HasForeignKey(x => x.ElementId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_ElemIntervencionesPiezas_GMAO_Elementos");
				entityTypeBuilder.HasOne(x => x.IdIntervencionNavigation)
					.WithMany(x => x.GMAO_ElemIntervencionesPiezas)
					.HasForeignKey(x => x.IdIntervencion)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_GMAO_ElemIntervencionesPiezas_GMAO_ElemIntervenciones");
				entityTypeBuilder.HasOne(x => x.Warehouse)
					.WithMany(x => x.GMAO_ElemIntervencionesPiezas)
					.HasForeignKey(x => x.WarehouseId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_ElemIntervencionesPiezas_GMAO_Warehouses");
			});

			modelBuilder.Entity<GMAO_ElemIntervencionesTrabajos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.IdIntervencionNavigation)
					.WithMany(x => x.GMAO_ElemIntervencionesTrabajos)
					.HasForeignKey(x => x.IdIntervencion)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_GMAO_ElemIntervencionesTrabajos_GMAO_ElemIntervenciones");
				entityTypeBuilder.HasOne(x => x.IdOperarioNavigation)
					.WithMany(x => x.GMAO_ElemIntervencionesTrabajos)
					.HasForeignKey(x => x.IdOperario)
					.HasConstraintName("FK_GMAO_ElemIntervencionesTrabajos_GMAO_Operarios");
			});

			modelBuilder.Entity<GMAO_ElemPertenencia>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.IdPadre, x.IdHijo });
				entityTypeBuilder.HasOne(x => x.IdHijoNavigation)
					.WithMany(x => x.GMAO_ElemPertenenciaIdHijoNavigation)
					.HasForeignKey(x => x.IdHijo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_ElemPertenencia_Hijo");
				entityTypeBuilder.HasOne(x => x.IdPadreNavigation)
					.WithMany(x => x.GMAO_ElemPertenenciaIdPadreNavigation)
					.HasForeignKey(x => x.IdPadre)
					.HasConstraintName("FK_GMAO_ElemPertenencia_Padre");
			});

			modelBuilder.Entity<GMAO_ElemStocks>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.IdCompraLineaNavigation)
					.WithMany(x => x.GMAO_ElemStocks)
					.HasForeignKey(x => x.IdCompraLinea)
					.HasConstraintName("FK_GMAO_ElemStocks_GMAO_ComprasLineas");
				entityTypeBuilder.HasOne(x => x.IdModeloNavigation)
					.WithMany(x => x.GMAO_ElemStocks)
					.HasForeignKey(x => x.IdModelo)
					.HasConstraintName("FK_GMAO_ElemStocks_GMAO_MarcasModelo");
				entityTypeBuilder.HasOne(x => x.IdProveedorNavigation)
					.WithMany(x => x.GMAO_ElemStocks)
					.HasForeignKey(x => x.IdProveedor)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_GMAO_ElemStocks_GMAO_Proveedores");
				entityTypeBuilder.HasOne(x => x.idElementoNavigation)
					.WithMany(x => x.GMAO_ElemStocks)
					.HasForeignKey(x => x.idElemento)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_GMAO_ElemStocks_GMAO_Elementos");
			});

			modelBuilder.Entity<GMAO_ElementReviewSettings>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => x.ElementId)
					.HasName("PK__GMAO_Ele__A429721ACB3DB9FF");
				entityTypeBuilder.Property(x => x.ElementId)
					.ValueGeneratedNever();
				entityTypeBuilder.HasOne(x => x.Element)
					.WithOne(x => x.GMAO_ElementReviewSettings)
					.HasForeignKey<GMAO_ElementReviewSettings>(x => x.ElementId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__GMAO_Elem__Eleme__7D8391DF");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.GMAO_ElementReviewTaskConfiguration());

			modelBuilder.Entity<GMAO_Elementos>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.LastReview)
					.HasConversion(
						x => x.ToLocalTime(),
						x => DateTime.SpecifyKind(x, DateTimeKind.Local)
					)
					.HasDefaultValueSql("('1900-01-01 00:00:00')");
				entityTypeBuilder.Property(x => x.OrdenArbol)
					.HasDefaultValueSql("((-1))");
				entityTypeBuilder.HasOne(x => x.Electrovalvula)
					.WithMany(x => x.GMAO_Elementos)
					.HasForeignKey(x => x.ElectrovalvulaId)
					.HasConstraintName("FK__GMAO_Elem__Elect__75E27017");
				entityTypeBuilder.HasOne(x => x.ElementoPadre)
					.WithMany(x => x.InverseElementoPadre)
					.HasForeignKey(x => x.ElementoPadreId)
					.HasConstraintName("FK__GMAO_Elem__Eleme__74EE4BDE");
				entityTypeBuilder.HasOne(x => x.Modelo)
					.WithMany(x => x.GMAO_Elementos)
					.HasForeignKey(x => x.ModeloId)
					.HasConstraintName("FK_GMAO_Elementos_MarcasModelos");
				entityTypeBuilder.HasOne(x => x.TipoNavigation)
					.WithMany(x => x.GMAO_Elementos)
					.HasForeignKey(x => x.Tipo)
					.HasConstraintName("FK_GMAO_Elementos_GMAO_ElementosTipos");
				entityTypeBuilder.HasOne(x => x.idMotorNavigation)
					.WithMany(x => x.GMAO_Elementos)
					.HasForeignKey(x => x.idMotor)
					.HasConstraintName("FK_GMAO_Elementos_Motores");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.GMAO_ElementosTiposConfiguration());

			modelBuilder.Entity<GMAO_ElementosTiposModelos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.idTipo, x.idModelo });
				entityTypeBuilder.HasOne(x => x.idModeloNavigation)
					.WithMany(x => x.GMAO_ElementosTiposModelos)
					.HasForeignKey(x => x.idModelo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_ElementosTiposModelos_GMAO_MarcasModelos");
				entityTypeBuilder.HasOne(x => x.idTipoNavigation)
					.WithMany(x => x.GMAO_ElementosTiposModelos)
					.HasForeignKey(x => x.idTipo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_ElementosTiposModelos_GMAO_ElementosTipos");
			});

			modelBuilder.Entity<GMAO_HistStocksYElementos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idElementoNavigation)
					.WithMany(x => x.GMAO_HistStocksYElementos)
					.HasForeignKey(x => x.idElemento)
					.HasConstraintName("FK_GMAO_HistStocksYElementos_GMAO_Elementos");
				entityTypeBuilder.HasOne(x => x.idStockNavigation)
					.WithMany(x => x.GMAO_HistStocksYElementos)
					.HasForeignKey(x => x.idStock)
					.HasConstraintName("FK_GMAO_HistStocksYElementos_GMAO_ElemStocks");
			});

			modelBuilder.Entity<GMAO_MarcasModelos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idMarcaNavigation)
					.WithMany(x => x.GMAO_MarcasModelos)
					.HasForeignKey(x => x.idMarca)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_MarcasModelos_GMAO_Marcas");
			});

			modelBuilder.Entity<GMAO_ParadasConfiguracionModulos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.idParadaConfiguracion, x.idModulo });
				entityTypeBuilder.HasOne(x => x.idModuloNavigation)
					.WithMany(x => x.GMAO_ParadasConfiguracionModulos)
					.HasForeignKey(x => x.idModulo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_ParadasConfiguracionModulos_Modulos");
				entityTypeBuilder.HasOne(x => x.idParadaConfiguracionNavigation)
					.WithMany(x => x.GMAO_ParadasConfiguracionModulos)
					.HasForeignKey(x => x.idParadaConfiguracion)
					.HasConstraintName("FK_GMAO_ParadasConfiguracionModulos_GMAO_ParadasConfiguracion");
			});

			modelBuilder.Entity<GMAO_ParadasConfiguracionTareas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idElementoNavigation)
					.WithMany(x => x.GMAO_ParadasConfiguracionTareas)
					.HasForeignKey(x => x.idElemento)
					.HasConstraintName("FK_GMAO_ParadasConfiguracionTareas_GMAO_Elementos");
				entityTypeBuilder.HasOne(x => x.idOperarioNavigation)
					.WithMany(x => x.GMAO_ParadasConfiguracionTareas)
					.HasForeignKey(x => x.idOperario)
					.HasConstraintName("FK_GMAO_ParadasConfiguracionTareas_GMAO_Operarios");
				entityTypeBuilder.HasOne(x => x.idParadaConfiguracionNavigation)
					.WithMany(x => x.GMAO_ParadasConfiguracionTareas)
					.HasForeignKey(x => x.idParadaConfiguracion)
					.HasConstraintName("FK_GMAO_ParadasConfiguracionTareas_GMAO_ParadasConfiguracion");
			});

			modelBuilder.Entity<GMAO_SolicitudOrdenTrabajo>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.CreadaPor)
					.WithMany(x => x.GMAO_SolicitudOrdenTrabajoCreadaPor)
					.HasForeignKey(x => x.CreadaPorId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_SolicitudOrdenTrabajo_CreadaPor");
				entityTypeBuilder.HasOne(x => x.Elemento)
					.WithMany(x => x.GMAO_SolicitudOrdenTrabajo)
					.HasForeignKey(x => x.ElementoId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_GMAO_SolicitudOrdenTrabajo_Elemento");
				entityTypeBuilder.HasOne(x => x.GestionadaPor)
					.WithMany(x => x.GMAO_SolicitudOrdenTrabajoGestionadaPor)
					.HasForeignKey(x => x.GestionadaPorId)
					.HasConstraintName("FK_GMAO_SolicitudOrdenTrabajo_GestionadaPor");
			});

			modelBuilder.Entity<GMAO_WarehouseStocks>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.ElementId, x.WarehouseId, x.ModelId })
					.HasName("PK__GMAO_War__0BA12F4480D20B06");
				entityTypeBuilder.Property(x => x.ModelId)
					.HasDefaultValueSql("((-1))");
				entityTypeBuilder.HasOne(x => x.Element)
					.WithMany(x => x.GMAO_WarehouseStocks)
					.HasForeignKey(x => x.ElementId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__GMAO_Ware__Eleme__1837881B");
				entityTypeBuilder.HasOne(x => x.Model)
					.WithMany(x => x.GMAO_WarehouseStocks)
					.HasForeignKey(x => x.ModelId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__GMAO_Ware__Model__174363E2");
				entityTypeBuilder.HasOne(x => x.Warehouse)
					.WithMany(x => x.GMAO_WarehouseStocks)
					.HasForeignKey(x => x.WarehouseId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__GMAO_Ware__Wareh__192BAC54");
			});

			modelBuilder.Entity<GMAO_Warehouses>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Id)
					.HasDefaultValueSql("(newid())");
			});

			modelBuilder.Entity<GruposIncompatibilidadesLineas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.IdGrupoNavigation)
					.WithMany(x => x.GruposIncompatibilidadesLineas)
					.HasForeignKey(x => x.IdGrupo)
					.HasConstraintName("FK_GruposIncompatibilidadesLineas_GruposIncompatibilidades");
				entityTypeBuilder.HasOne(x => x.IdProductoNavigation)
					.WithMany(x => x.GruposIncompatibilidadesLineas)
					.HasForeignKey(x => x.IdProducto)
					.HasConstraintName("FK_GruposIncompatibilidadesLineas_Productos");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.HumanMachineInterfaceConfiguration());

			modelBuilder.Entity<Incompatibilidades>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.FormulaNavigation)
					.WithMany(x => x.Incompatibilidades)
					.HasForeignKey(x => x.Formula)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Incompatibilidades_Formulas");
				entityTypeBuilder.HasOne(x => x.ProductoNavigation)
					.WithMany(x => x.Incompatibilidades)
					.HasForeignKey(x => x.Producto)
					.HasConstraintName("FK_Incompatibilidades_Productos");
			});

			modelBuilder.Entity<Indicadores>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.IdBasculaNavigation)
					.WithMany(x => x.Indicadores)
					.HasForeignKey(x => x.IdBascula)
					.HasConstraintName("FK_Indicadores_Basculas");
				entityTypeBuilder.HasOne(x => x.IdMedidorNavigation)
					.WithMany(x => x.Indicadores)
					.HasForeignKey(x => x.IdMedidor)
					.HasConstraintName("FK_Indicadores_Medidores");
			});

			modelBuilder.Entity<InformeExpediciones>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("InformeExpediciones");
			});

			modelBuilder.Entity<InformeExpediciones_SalidaLinea>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("InformeExpediciones_SalidaLinea");
			});

			modelBuilder.Entity<InformeExpediciones_SalidaLinea_Resultado>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("InformeExpediciones_SalidaLinea_Resultado");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.InformesLibConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.InformesLibCategoriasConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.InformesLibUsuariosConfiguration());

			modelBuilder.Entity<LineaVentaLineaSalida>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idLineaSalidaNavigation)
					.WithMany(x => x.LineaVentaLineaSalida)
					.HasForeignKey(x => x.idLineaSalida)
					.HasConstraintName("FK_LineaVentaLineaSalida_SalidasLinias");
				entityTypeBuilder.HasOne(x => x.idLineaVentaNavigation)
					.WithMany(x => x.LineaVentaLineaSalida)
					.HasForeignKey(x => x.idLineaVenta)
					.HasConstraintName("FK_LineaVentaLineaSalida_VentasLinias");
			});

			modelBuilder.Entity<LineasCompra>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.CompraNavigation)
					.WithMany(x => x.LineasCompra)
					.HasForeignKey(x => x.Compra)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_LineasCompra_Compras");
				entityTypeBuilder.HasOne(x => x.EnvaseNavigation)
					.WithMany(x => x.LineasCompra)
					.HasForeignKey(x => x.Envase)
					.HasConstraintName("FK_LineasCompra_Envases");
				entityTypeBuilder.HasOne(x => x.FormatoNavigation)
					.WithMany(x => x.LineasCompra)
					.HasForeignKey(x => x.Formato)
					.HasConstraintName("FK_LineasCompra_Formatos");
				entityTypeBuilder.HasOne(x => x.IdContratoNavigation)
					.WithMany(x => x.LineasCompra)
					.HasForeignKey(x => x.IdContrato)
					.HasConstraintName("FK_LineasCompra_Contratos");
				entityTypeBuilder.HasOne(x => x.ProductoNavigation)
					.WithMany(x => x.LineasCompra)
					.HasForeignKey(x => x.Producto)
					.HasConstraintName("FK_LineasCompra_Productos");
				entityTypeBuilder.HasOne(x => x.UnidadNavigation)
					.WithMany(x => x.LineasCompra)
					.HasForeignKey(x => x.Unidad)
					.HasConstraintName("FK_LineasCompra_Unidades");
				entityTypeBuilder.HasOne(x => x.idLineaEntradaNavigation)
					.WithMany(x => x.LineasCompra)
					.HasForeignKey(x => x.idLineaEntrada)
					.HasConstraintName("FK_LineasCompra_EntradasLineas");
			});

			modelBuilder.Entity<LineasSalidasAgrupLoteYOrden>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("LineasSalidasAgrupLoteYOrden");
			});

			modelBuilder.Entity<ListaAlarmas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ListaAlarmas");
			});

			modelBuilder.Entity<ListaDesgloses>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ListaDesgloses");
			});

			modelBuilder.Entity<ListaDosificaciones>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ListaDosificaciones");
			});

			modelBuilder.Entity<ListaOrdenes>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ListaOrdenes");
				entityTypeBuilder.Property(x => x.Estado)
					.IsUnicode(false);
				entityTypeBuilder.Property(x => x.Modificada)
					.IsUnicode(false);
			});

			modelBuilder.Entity<ListaResultados>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ListaResultados");
				entityTypeBuilder.Property(x => x.Estado)
					.IsUnicode(false);
			});

			modelBuilder.Entity<LogMovimientosStocks>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasIndex(x => x.IdStock)
					.HasName("_dta_index_LogMovimientosStocks_1");
				entityTypeBuilder.HasOne(x => x.IdLoteNavigation)
					.WithMany(x => x.LogMovimientosStocks)
					.HasForeignKey(x => x.IdLote)
					.HasConstraintName("FK_LogMovimientosStocks_Lotes");
				entityTypeBuilder.HasOne(x => x.IdProductoNavigation)
					.WithMany(x => x.LogMovimientosStocks)
					.HasForeignKey(x => x.IdProducto)
					.HasConstraintName("FK_LogMovimientosStocks_Productos");
				entityTypeBuilder.HasOne(x => x.IdUbicacionNavigation)
					.WithMany(x => x.LogMovimientosStocks)
					.HasForeignKey(x => x.IdUbicacion)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_LogMovimientosStocks_Ubicaciones");
				entityTypeBuilder.HasOne(x => x.MedidorNavigation)
					.WithMany(x => x.LogMovimientosStocks)
					.HasForeignKey(x => x.Medidor)
					.HasConstraintName("FK_LogMovimientosStocks_Medidores");
				entityTypeBuilder.HasOne(x => x.ModuloNavigation)
					.WithMany(x => x.LogMovimientosStocks)
					.HasForeignKey(x => x.Modulo)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_LogMovimientosStocks_Modulos");
				entityTypeBuilder.HasOne(x => x.OperarioNavigation)
					.WithMany(x => x.LogMovimientosStocks)
					.HasForeignKey(x => x.Operario)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_LogMovimientosStocks_Usuarios");
				entityTypeBuilder.HasOne(x => x.idOrdenNavigation)
					.WithMany(x => x.LogMovimientosStocks)
					.HasForeignKey(x => x.idOrden)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_LogMovimientosStocks_Ordenes");
			});

			modelBuilder.Entity<LoteClienteDomicilio>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("LoteClienteDomicilio");
			});

			modelBuilder.Entity<LoteProveedor>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("LoteProveedor");
			});

			modelBuilder.Entity<LoteProveedorNOCantidad>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("LoteProveedorNOCantidad");
			});

			modelBuilder.Entity<LoteProveedorUnicoNOCantidad>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("LoteProveedorUnicoNOCantidad");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.LotesConfiguration());

			modelBuilder.Entity<LotesMezclados>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idLoteNuevoNavigation)
					.WithMany(x => x.LotesMezcladosidLoteNuevoNavigation)
					.HasForeignKey(x => x.idLoteNuevo)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_LotesMezclados_LotesNuevo");
				entityTypeBuilder.HasOne(x => x.idLoteOrigenNavigation)
					.WithMany(x => x.LotesMezcladosidLoteOrigenNavigation)
					.HasForeignKey(x => x.idLoteOrigen)
					.HasConstraintName("FK_LotesMezclados_LotesOrigen");
			});

			modelBuilder.Entity<Maquinas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.SesionNavigation)
					.WithMany(x => x.MaquinasSesionNavigation)
					.HasForeignKey(x => x.Sesion)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Maquinas_Sesiones");
				entityTypeBuilder.HasOne(x => x.SesionNotificacionNavigation)
					.WithMany(x => x.MaquinasSesionNotificacionNavigation)
					.HasForeignKey(x => x.SesionNotificacion)
					.HasConstraintName("FK_Maquinas_Sesiones1");
			});

			modelBuilder.Entity<Medicaciones>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.AfeccionNavigation)
					.WithMany(x => x.Medicaciones)
					.HasForeignKey(x => x.Afeccion)
					.HasConstraintName("FK_Medicaciones_Afecciones");
			});

			modelBuilder.Entity<MedicacionesIngredientes>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.Medicacion, x.Producto });
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.MedidorConfiguration());

			modelBuilder.Entity<MedidoresDosificaciones>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Activo)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.Property(x => x.GenerarConProductos)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.HasOne(x => x.idMedidorNavigation)
					.WithMany(x => x.MedidoresDosificaciones)
					.HasForeignKey(x => x.idMedidor)
					.HasConstraintName("FK_MedidoresDosificaciones_Medidores");
				entityTypeBuilder.HasOne(x => x.idOrigenNavigation)
					.WithMany(x => x.MedidoresDosificaciones)
					.HasForeignKey(x => x.idOrigen)
					.HasConstraintName("FK_MedidoresDosificaciones_Origenes");
				entityTypeBuilder.HasOne(x => x.idProductoNavigation)
					.WithMany(x => x.MedidoresDosificaciones)
					.HasForeignKey(x => x.idProducto)
					.HasConstraintName("FK_MedidoresDosificaciones_Productos");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.ModuloEstadoComunicacionesConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.ModulosConfiguration());

			modelBuilder.Entity<ModulosAscendentes>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.AscendenteNavigation)
					.WithMany(x => x.ModulosAscendentes)
					.HasForeignKey(x => x.Ascendente)
					.HasConstraintName("FK_ModulosAscendentes_Modulos");
				entityTypeBuilder.HasOne(x => x.MedidorNavigation)
					.WithMany(x => x.ModulosAscendentes)
					.HasForeignKey(x => x.Medidor)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_ModulosAscendentes_Medidores");
			});

			modelBuilder.Entity<ModulosIncompatibilidades>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.ModuloBaseNavigation)
					.WithMany(x => x.ModulosIncompatibilidadesModuloBaseNavigation)
					.HasForeignKey(x => x.ModuloBase)
					.HasConstraintName("FK_ModulosIncompatibilidadesBase_ModulosBase");
				entityTypeBuilder.HasOne(x => x.ModuloRelacionadoNavigation)
					.WithMany(x => x.ModulosIncompatibilidadesModuloRelacionadoNavigation)
					.HasForeignKey(x => x.ModuloRelacionado)
					.HasConstraintName("FK_ModulosIncompatibilidadesRelacionado_ModulosRelacionado");
			});

			modelBuilder.Entity<ModulosMotores>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.ModuloId, x.MotorId });
				entityTypeBuilder.HasIndex(x => x.MotorId);
			});

			modelBuilder.Entity<ModulosTagsScada>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.ModuloNavigation)
					.WithMany(x => x.ModulosTagsScada)
					.HasForeignKey(x => x.Modulo)
					.HasConstraintName("FK_ModulosTagsScada_Modulos");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.MotorConfiguration());

			modelBuilder.Entity<MotoresGruposRelacion>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.idGrupo, x.idMotor });
				entityTypeBuilder.HasOne(x => x.idGrupoNavigation)
					.WithMany(x => x.MotoresGruposRelacion)
					.HasForeignKey(x => x.idGrupo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_MotoresGruposRelacion_MotoresGrupos");
				entityTypeBuilder.HasOne(x => x.idMotorNavigation)
					.WithMany(x => x.MotoresGruposRelacion)
					.HasForeignKey(x => x.idMotor)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_MotoresGruposRelacion_Motores");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.MotoresHistoricoConfiguration());

			modelBuilder.Entity<MultiDosificaciones>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idDosificacionNavigation)
					.WithMany(x => x.MultiDosificaciones)
					.HasForeignKey(x => x.idDosificacion)
					.HasConstraintName("FK_MultiDosificaciones_Dosificaciones");
				entityTypeBuilder.HasOne(x => x.idUbicacionNavigation)
					.WithMany(x => x.MultiDosificaciones)
					.HasForeignKey(x => x.idUbicacion)
					.HasConstraintName("FK_MultiDosificaciones_Ubicaciones");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.NetAlarmasConfiguration());

			modelBuilder.Entity<NetAlarmasAutomaticas>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Activa)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.Reintentos)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.HasOne(x => x.IdAlarmasTipoNavigation)
					.WithMany(x => x.NetAlarmasAutomaticas)
					.HasForeignKey(x => x.IdAlarmasTipo)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_NetAlarmasAutomaticas_NetAlarmasTipos");
				entityTypeBuilder.HasOne(x => x.IdMedidorNavigation)
					.WithMany(x => x.NetAlarmasAutomaticas)
					.HasForeignKey(x => x.IdMedidor)
					.HasConstraintName("FK_NetAlarmasAutomaticas_Medidores");
				entityTypeBuilder.HasOne(x => x.IdModuloNavigation)
					.WithMany(x => x.NetAlarmasAutomaticas)
					.HasForeignKey(x => x.IdModulo)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_NetAlarmasAutomaticas_Modulos");
				entityTypeBuilder.HasOne(x => x.IdNetAlarmasRespuestaNavigation)
					.WithMany(x => x.NetAlarmasAutomaticas)
					.HasForeignKey(x => x.IdNetAlarmasRespuesta)
					.HasConstraintName("FK_NetAlarmasAutomaticas_NetAlarmasTiposRespuestas");
				entityTypeBuilder.HasOne(x => x.IdUbicacionNavigation)
					.WithMany(x => x.NetAlarmasAutomaticas)
					.HasForeignKey(x => x.IdUbicacion)
					.HasConstraintName("FK_NetAlarmasAutomaticas_Ubicaciones");
			});

			modelBuilder.Entity<NetAlarmasAutomaticasOrdenUbicaciones>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.FechaCreacion)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.Property(x => x.Procesada)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.HasOne(x => x.IdDosificacionNavigation)
					.WithMany(x => x.NetAlarmasAutomaticasOrdenUbicaciones)
					.HasForeignKey(x => x.IdDosificacion)
					.HasConstraintName("FK_NetAlarmasAutomaticasOrdenUbicaciones_Dosificaciones");
				entityTypeBuilder.HasOne(x => x.IdNetAlarmaAutomaticaNavigation)
					.WithMany(x => x.NetAlarmasAutomaticasOrdenUbicaciones)
					.HasForeignKey(x => x.IdNetAlarmaAutomatica)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_NetAlarmasAutomaticasOrdenUbicaciones_NetAlarmasAutomaticas");
				entityTypeBuilder.HasOne(x => x.IdOrdenNavigation)
					.WithMany(x => x.NetAlarmasAutomaticasOrdenUbicaciones)
					.HasForeignKey(x => x.IdOrden)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_NetAlarmasAutomaticasOrdenUbicaciones_Ordenes");
				entityTypeBuilder.HasOne(x => x.IdUbicacionNavigation)
					.WithMany(x => x.NetAlarmasAutomaticasOrdenUbicaciones)
					.HasForeignKey(x => x.IdUbicacion)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_NetAlarmasAutomaticasOrdenUbicaciones_Ubicaciones");
			});

			modelBuilder.Entity<NetAlarmasRespuestas>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.SeleccArgumento0)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.SeleccArgumento1)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.SeleccArgumento2)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.SeleccArgumento3)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.SeleccTextoAdicional)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.SeleccUbicacionDestino)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.SeleccVariables0)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.SeleccVariables1)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.SeleccVariables2)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.SeleccVariables3)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.SeleccVariables4)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.SeleccionLote)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.SeleccionProducto)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.SeleccionUbicacion)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.txtArgumento0)
					.HasDefaultValueSql("('')");
				entityTypeBuilder.Property(x => x.txtArgumento1)
					.HasDefaultValueSql("('')");
				entityTypeBuilder.Property(x => x.txtArgumento2)
					.HasDefaultValueSql("('')");
				entityTypeBuilder.Property(x => x.txtArgumento3)
					.HasDefaultValueSql("('')");
				entityTypeBuilder.Property(x => x.txtTextoAdicional)
					.HasDefaultValueSql("('')");
				entityTypeBuilder.Property(x => x.txtVariables0)
					.HasDefaultValueSql("('')");
				entityTypeBuilder.Property(x => x.txtVariables1)
					.HasDefaultValueSql("('')");
				entityTypeBuilder.Property(x => x.txtVariables2)
					.HasDefaultValueSql("('')");
				entityTypeBuilder.Property(x => x.txtVariables3)
					.HasDefaultValueSql("('')");
				entityTypeBuilder.Property(x => x.txtVariables4)
					.HasDefaultValueSql("('')");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.NetAlarmasTiposConfiguration());

			modelBuilder.Entity<NetAlarmasTiposRespuestas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idRespuestaNavigation)
					.WithMany(x => x.NetAlarmasTiposRespuestas)
					.HasForeignKey(x => x.idRespuesta)
					.HasConstraintName("FK_NetAlarmasTiposRespuestas_NetAlarmasRespuestas");
				entityTypeBuilder.HasOne(x => x.idTipoNavigation)
					.WithMany(x => x.NetAlarmasTiposRespuestas)
					.HasForeignKey(x => x.idTipo)
					.HasConstraintName("FK_NetAlarmasTiposRespuestas_NetAlarmasTipos");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.NetAlarmasTipoRespuestaOrigenConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.OpcConfigConfiguration());

			modelBuilder.Entity<Opciones>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.id)
					.ValueGeneratedOnAdd();
			});

			modelBuilder.Entity<OpcionesRoles>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.idClave, x.idRol });
				entityTypeBuilder.HasOne(x => x.idClaveNavigation)
					.WithMany(x => x.OpcionesRoles)
					.HasForeignKey(x => x.idClave)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_OpcionesRoles_Opciones");
				entityTypeBuilder.HasOne(x => x.idRolNavigation)
					.WithMany(x => x.OpcionesRoles)
					.HasForeignKey(x => x.idRol)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_OpcionesRoles_UsuariosRoles");
			});

			modelBuilder.Entity<OpcionesUsuarios>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.idClave, x.idUsuario });
				entityTypeBuilder.HasOne(x => x.idClaveNavigation)
					.WithMany(x => x.OpcionesUsuarios)
					.HasForeignKey(x => x.idClave)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_OpcionesUsuarios_Opciones");
				entityTypeBuilder.HasOne(x => x.idUsuarioNavigation)
					.WithMany(x => x.OpcionesUsuarios)
					.HasForeignKey(x => x.idUsuario)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_OpcionesUsuarios_Usuarios");
			});

			modelBuilder.Entity<OperCabPlantillas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.IdModuloNavigation)
					.WithMany(x => x.OperCabPlantillas)
					.HasForeignKey(x => x.IdModulo)
					.HasConstraintName("FK_OperCabPlantillas_Modulos");
			});

			modelBuilder.Entity<OperMotores>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Cajon1)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.Cajon10)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.Cajon2)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.Cajon3)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.Cajon4)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.Cajon5)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.Cajon6)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.Cajon7)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.Cajon8)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.Cajon9)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.EsTiempoMezclaERP)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.RaseraTunelCarga)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.HasOne(x => x.IdMedidorNavigation)
					.WithMany(x => x.OperMotoresIdMedidorNavigation)
					.HasForeignKey(x => x.IdMedidor)
					.HasConstraintName("FK_OperMotores_Medidores");
				entityTypeBuilder.HasOne(x => x.OpcConfig)
					.WithMany(x => x.OperMotores)
					.HasForeignKey(x => x.OpcConfigId)
					.HasConstraintName("FK__OperMotor__OpcCo__0307610B");
				entityTypeBuilder.HasOne(x => x.idAccionMotorNavigation)
					.WithMany(x => x.OperMotores)
					.HasForeignKey(x => x.idAccionMotor)
					.HasConstraintName("FK_OperMotores_OperAcciones");
				entityTypeBuilder.HasOne(x => x.idMedidorForzadoNavigation)
					.WithMany(x => x.OperMotoresidMedidorForzadoNavigation)
					.HasForeignKey(x => x.idMedidorForzado)
					.HasConstraintName("FK_OperMotores_MedidoresForzado");
			});

			modelBuilder.Entity<OperMotoresModulos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.IdMedidorNavigation)
					.WithMany(x => x.OperMotoresModulos)
					.HasForeignKey(x => x.IdMedidor)
					.HasConstraintName("FK_OperMotoresModulos_Medidores");
				entityTypeBuilder.HasOne(x => x.IdModuloNavigation)
					.WithMany(x => x.OperMotoresModulos)
					.HasForeignKey(x => x.IdModulo)
					.HasConstraintName("FK_OperMotoresModulos_Modulos");
				entityTypeBuilder.HasOne(x => x.IdOperMotorNavigation)
					.WithMany(x => x.OperMotoresModulos)
					.HasForeignKey(x => x.IdOperMotor)
					.HasConstraintName("FK_OperMotoresModulos_OperMotores");
			});

			modelBuilder.Entity<OperPlantillas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.IdOperAccionNavigation)
					.WithMany(x => x.OperPlantillas)
					.HasForeignKey(x => x.IdOperAccion)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_OperPlantillas_OperAcciones");
				entityTypeBuilder.HasOne(x => x.IdOperCabPlantillasNavigation)
					.WithMany(x => x.OperPlantillas)
					.HasForeignKey(x => x.IdOperCabPlantillas)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_OperPlantillas_OperCabPlantillas");
				entityTypeBuilder.HasOne(x => x.IdOperMotorNavigation)
					.WithMany(x => x.OperPlantillas)
					.HasForeignKey(x => x.IdOperMotor)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_OperPlantillas_OperMotores");
				entityTypeBuilder.HasOne(x => x.IdProductoNavigation)
					.WithMany(x => x.OperPlantillas)
					.HasForeignKey(x => x.IdProducto)
					.HasConstraintName("FK_OperPlantillas_Productos");
				entityTypeBuilder.HasOne(x => x.IdTempControlNavigation)
					.WithMany(x => x.OperPlantillas)
					.HasForeignKey(x => x.IdTempControl)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_OperPlantillas_TempControles");
				entityTypeBuilder.HasOne(x => x.IdUbicacionNavigation)
					.WithMany(x => x.OperPlantillas)
					.HasForeignKey(x => x.IdUbicacion)
					.HasConstraintName("FK_OperPlantillas_Ubicaciones");
				entityTypeBuilder.HasOne(x => x.MedidorNavigation)
					.WithMany(x => x.OperPlantillas)
					.HasForeignKey(x => x.Medidor)
					.HasConstraintName("FK_OperPlantillas_Medidores");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.OrdenesConfiguration());

			modelBuilder.Entity<OrdenesAutoInicio>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Activo)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.HasOne(x => x.idOrdenNavigation)
					.WithMany(x => x.OrdenesAutoInicioidOrdenNavigation)
					.HasForeignKey(x => x.idOrden)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_OrdenesAutoInicio_Ordenes");
				entityTypeBuilder.HasOne(x => x.idOrdenObjetivoNavigation)
					.WithMany(x => x.OrdenesAutoInicioidOrdenObjetivoNavigation)
					.HasForeignKey(x => x.idOrdenObjetivo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_OrdenesAutoInicio_Ordenes1");
			});

			modelBuilder.Entity<OrdenesDatosExtra>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.id)
					.ValueGeneratedNever();
				entityTypeBuilder.Property(x => x.CantidadProducida)
					.HasComputedColumnSql("([dbo].[OrdenCantidadProducida]([id]))")
					.ValueGeneratedNever();
				entityTypeBuilder.Property(x => x.KWConsumidosEfectivo)
					.HasComputedColumnSql("([dbo].[OrdenKWConsumidosEfectivo]([id]))")
					.ValueGeneratedNever();
				entityTypeBuilder.Property(x => x.KWConsumidosTotal)
					.HasComputedColumnSql("([dbo].[OrdenKWConsumidosTotal]([id]))")
					.ValueGeneratedNever();
				entityTypeBuilder.Property(x => x.KWEfectivo)
					.HasComputedColumnSql("([dbo].[OrdenKWProducidosEfectivo]([id])+[dbo].[OrdenKWConsumidosEfectivo]([id]))")
					.ValueGeneratedNever();
				entityTypeBuilder.Property(x => x.KWEfectivoTonelada)
					.HasComputedColumnSql("([dbo].[OrdenKWEfectivoCantidad]([id]))")
					.ValueGeneratedNever();
				entityTypeBuilder.Property(x => x.KWProducidosEfectivo)
					.HasComputedColumnSql("([dbo].[OrdenKWProducidosEfectivo]([id]))")
					.ValueGeneratedNever();
				entityTypeBuilder.Property(x => x.KWProducidosTotal)
					.HasComputedColumnSql("([dbo].[OrdenKWProducidosTotal]([id]))")
					.ValueGeneratedNever();
				entityTypeBuilder.Property(x => x.KWTotal)
					.HasComputedColumnSql("([dbo].[OrdenKWProducidosTotal]([id])+[dbo].[OrdenKWConsumidosTotal]([id]))")
					.ValueGeneratedNever();
				entityTypeBuilder.Property(x => x.KWTotalTonelada)
					.HasComputedColumnSql("([dbo].[OrdenKWTotalCantidad]([id]))")
					.ValueGeneratedNever();
				entityTypeBuilder.HasOne(x => x.idNavigation)
					.WithOne(x => x.OrdenesDatosExtra)
					.HasForeignKey<OrdenesDatosExtra>(x => x.id)
					.HasConstraintName("FK_OrdenesDatosExtra_Ordenes");
			});

			modelBuilder.Entity<OrdenesDetalle>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("OrdenesDetalle");
			});

			modelBuilder.Entity<OrdenesRelacion>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Porcentaje)
					.HasDefaultValueSql("((100))");
				entityTypeBuilder.HasOne(x => x.idOrdenHijoNavigation)
					.WithMany(x => x.OrdenesRelacionidOrdenHijoNavigation)
					.HasForeignKey(x => x.idOrdenHijo)
					.HasConstraintName("FK_OrdenesRelacion_Ordenes1");
				entityTypeBuilder.HasOne(x => x.idOrdenPadreNavigation)
					.WithMany(x => x.OrdenesRelacionidOrdenPadreNavigation)
					.HasForeignKey(x => x.idOrdenPadre)
					.HasConstraintName("FK_OrdenesRelacion_Ordenes");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.OrdenesTransicionEstadosHistoryConfiguration());

			modelBuilder.Entity<Origenes>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Activo)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.Property(x => x.PorcentajeObligatorio)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.VerVariable)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.VerVariable2)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.HasOne(x => x.MedidorNavigation)
					.WithMany(x => x.Origenes)
					.HasForeignKey(x => x.Medidor)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Origenes_Medidores");
				entityTypeBuilder.HasOne(x => x.UbicacionNavigation)
					.WithMany(x => x.Origenes)
					.HasForeignKey(x => x.Ubicacion)
					.HasConstraintName("FK_Origenes_Ubicaciones");
			});

			modelBuilder.Entity<Pistolas>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.ModoEntradasAlmacen)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.ModoPicking)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.ModoSalidasAlmacen)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.HasOne(x => x.IdMedidorNavigation)
					.WithMany(x => x.Pistolas)
					.HasForeignKey(x => x.IdMedidor)
					.HasConstraintName("FK_Pistolas_Medidores");
			});

			modelBuilder.Entity<PivotProduccion>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("PivotProduccion");
			});

			modelBuilder.Entity<PivotProduccionProducidos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("PivotProduccionProducidos");
				entityTypeBuilder.Property(x => x.EstadoOrden)
					.IsUnicode(false);
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.PrintJobConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.PrinterConfiguration());

			modelBuilder.Entity<ProducidoConsumidoOrden>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ProducidoConsumidoOrden");
			});

			modelBuilder.Entity<ProducidoOrden>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ProducidoOrden");
			});

			modelBuilder.Entity<ProductoLotePrimerNivel>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ProductoLotePrimerNivel");
			});

			modelBuilder.Entity<ProductoLotePrimerNivelProvCli>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ProductoLotePrimerNivelProvCli");
			});


			modelBuilder.ApplyConfiguration(new Internal.Configurations.ProductoEnvaseEtiquetaConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.ProductoMedidorCaminoConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.ProductosConfiguration());

			modelBuilder.Entity<ProductosGruposIncompatibilidades>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.IdProducto, x.IdGrupoIncompatibilidad });
				entityTypeBuilder.HasOne(x => x.IdGrupoIncompatibilidadNavigation)
					.WithMany(x => x.ProductosGruposIncompatibilidades)
					.HasForeignKey(x => x.IdGrupoIncompatibilidad)
					.HasConstraintName("FK_ProductosGruposIncompatibilidades_GruposIncompatibilidades");
				entityTypeBuilder.HasOne(x => x.IdProductoNavigation)
					.WithMany(x => x.ProductosGruposIncompatibilidades)
					.HasForeignKey(x => x.IdProducto)
					.HasConstraintName("FK_ProductosGruposIncompatibilidades_Productos");
			});

			modelBuilder.Entity<ProductosOperCabPlantillas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.IdOperCabPlantillaNavigation)
					.WithMany(x => x.ProductosOperCabPlantillas)
					.HasForeignKey(x => x.IdOperCabPlantilla)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_ProductosOperCabPlantillas_OperCabPlantillas");
				entityTypeBuilder.HasOne(x => x.IdProductoNavigation)
					.WithMany(x => x.ProductosOperCabPlantillas)
					.HasForeignKey(x => x.IdProducto)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_ProductosOperCabPlantillas_Productos");
			});

			modelBuilder.Entity<Proveedores>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.PaisNavigation)
					.WithMany(x => x.Proveedores)
					.HasForeignKey(x => x.Pais)
					.HasConstraintName("FK_Proveedores_Paises");
				entityTypeBuilder.HasOne(x => x.ProvinciaNavigation)
					.WithMany(x => x.Proveedores)
					.HasForeignKey(x => x.Provincia)
					.HasConstraintName("FK_Proveedores_Provincias");
			});

			modelBuilder.Entity<ProveedoresOrigenes>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.PaisNavigation)
					.WithMany(x => x.ProveedoresOrigenes)
					.HasForeignKey(x => x.Pais)
					.HasConstraintName("FK_ProveedoresOrigenes_Paises");
				entityTypeBuilder.HasOne(x => x.ProveedorNavigation)
					.WithMany(x => x.ProveedoresOrigenes)
					.HasForeignKey(x => x.Proveedor)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_ProveedoresOrigenes_Proveedores");
				entityTypeBuilder.HasOne(x => x.ProvinciaNavigation)
					.WithMany(x => x.ProveedoresOrigenes)
					.HasForeignKey(x => x.Provincia)
					.HasConstraintName("FK_ProveedoresOrigenes_Provincias");
			});

			modelBuilder.Entity<Provincias>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.PaisNavigation)
					.WithMany(x => x.Provincias)
					.HasForeignKey(x => x.Pais)
					.HasConstraintName("FK_Provincias_Paises");
			});

			modelBuilder.Entity<PuntosDescarga>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idDomicilioNavigation)
					.WithMany(x => x.PuntosDescarga)
					.HasForeignKey(x => x.idDomicilio)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_PuntosDescarga_Domicilios");
			});

			modelBuilder.Entity<Recetas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idAfeccionNavigation)
					.WithMany(x => x.Recetas)
					.HasForeignKey(x => x.idAfeccion)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Recetas_Afecciones");
				entityTypeBuilder.HasOne(x => x.idClienteNavigation)
					.WithMany(x => x.Recetas)
					.HasForeignKey(x => x.idCliente)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Recetas_Clientes");
				entityTypeBuilder.HasOne(x => x.idDomicilioNavigation)
					.WithMany(x => x.Recetas)
					.HasForeignKey(x => x.idDomicilio)
					.HasConstraintName("FK_Recetas_Domicilios");
				entityTypeBuilder.HasOne(x => x.idProductoNavigation)
					.WithMany(x => x.Recetas)
					.HasForeignKey(x => x.idProducto)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Recetas_Productos");
				entityTypeBuilder.HasOne(x => x.idSalidaLineaNavigation)
					.WithMany(x => x.Recetas)
					.HasForeignKey(x => x.idSalidaLinea)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Recetas_SalidasLinias");
				entityTypeBuilder.HasOne(x => x.idSerieNavigation)
					.WithMany(x => x.Recetas)
					.HasForeignKey(x => x.idSerie)
					.HasConstraintName("FK_Recetas_Series");
				entityTypeBuilder.HasOne(x => x.idVeterinarioNavigation)
					.WithMany(x => x.Recetas)
					.HasForeignKey(x => x.idVeterinario)
					.HasConstraintName("FK_Recetas_Veterinarios");
#warning
#if NET7_0_OR_GREATER
				entityTypeBuilder.ToTable(x => x.HasTrigger("triggerInsertRecetas"));
#endif
			});

			modelBuilder.Entity<Regularizaciones>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.EnvaseNavigation)
					.WithMany(x => x.Regularizaciones)
					.HasForeignKey(x => x.Envase)
					.HasConstraintName("FK_Regularizaciones_Envases");
				entityTypeBuilder.HasOne(x => x.FormatoNavigation)
					.WithMany(x => x.Regularizaciones)
					.HasForeignKey(x => x.Formato)
					.HasConstraintName("FK_Regularizaciones_Formatos");
				entityTypeBuilder.HasOne(x => x.LoteNavigation)
					.WithMany(x => x.Regularizaciones)
					.HasForeignKey(x => x.Lote)
					.HasConstraintName("FK_Regularizaciones_Lotes");
				entityTypeBuilder.HasOne(x => x.ProductoNavigation)
					.WithMany(x => x.Regularizaciones)
					.HasForeignKey(x => x.Producto)
					.HasConstraintName("FK_Regularizaciones_Productos");
				entityTypeBuilder.HasOne(x => x.SerieNavigation)
					.WithMany(x => x.Regularizaciones)
					.HasForeignKey(x => x.Serie)
					.HasConstraintName("FK_Regularizaciones_Series");
				entityTypeBuilder.HasOne(x => x.UbicacionNavigation)
					.WithMany(x => x.Regularizaciones)
					.HasForeignKey(x => x.Ubicacion)
					.HasConstraintName("FK_Regularizaciones_Ubicaciones");
				entityTypeBuilder.HasOne(x => x.UnidadNavigation)
					.WithMany(x => x.Regularizaciones)
					.HasForeignKey(x => x.Unidad)
					.HasConstraintName("FK_Regularizaciones_Unidades");
				entityTypeBuilder.HasOne(x => x.UsuarioNavigation)
					.WithMany(x => x.Regularizaciones)
					.HasForeignKey(x => x.Usuario)
					.HasConstraintName("FK_Regularizaciones_Usuarios");
			});

			modelBuilder.Entity<Resultados>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasIndex(x => x.FinalMedidor)
					.HasName("_dta_index_Resultados_1");
				entityTypeBuilder.HasIndex(x => new { x.Orden, x.Producto })
					.HasName("PK_ResultadosOrdenProducto");
				entityTypeBuilder.HasIndex(x => new { x.Cantidad, x.Orden, x.Id, x.Producto, x.Lote })
					.HasName("_dta_index_Resultados_6_1531152500__K3_K1_K16_K15_7");
				entityTypeBuilder.Property(x => x.TipoPesada)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.HasOne(x => x.FormatoNavigation)
					.WithMany(x => x.Resultados)
					.HasForeignKey(x => x.Formato)
					.HasConstraintName("FK_Resultados_Formatos");
				entityTypeBuilder.HasOne(x => x.LoteNavigation)
					.WithMany(x => x.Resultados)
					.HasForeignKey(x => x.Lote)
					.HasConstraintName("FK_Resultados_Lotes");
				entityTypeBuilder.HasOne(x => x.MedidorNavigation)
					.WithMany(x => x.ResultadosNavigation)
					.HasForeignKey(x => x.Medidor)
					.HasConstraintName("FK_Resultados_Medidores");
				entityTypeBuilder.HasOne(x => x.OrdenNavigation)
					.WithMany(x => x.Resultados)
					.HasForeignKey(x => x.Orden)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Resultados_Ordenes");
				entityTypeBuilder.HasOne(x => x.ProductoNavigation)
					.WithMany(x => x.Resultados)
					.HasForeignKey(x => x.Producto)
					.HasConstraintName("FK_Resultados_Productos");
				entityTypeBuilder.HasOne(x => x.UbicacionNavigation)
					.WithMany(x => x.Resultados)
					.HasForeignKey(x => x.Ubicacion)
					.HasConstraintName("FK_Resultados_Ubicaciones");
				entityTypeBuilder.HasOne(x => x.UnidadNavigation)
					.WithMany(x => x.Resultados)
					.HasForeignKey(x => x.Unidad)
					.HasConstraintName("FK_Resultados_Unidades");
			});

			modelBuilder.Entity<ResultadosDetalle>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ResultadosDetalle");
			});

			modelBuilder.Entity<ResultadosExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ResultadosExtended");
			});

			modelBuilder.Entity<ResultadosOrdenAgrupado>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ResultadosOrdenAgrupado");
			});

			modelBuilder.Entity<ResultadosPorDiaOrden>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("ResultadosPorDiaOrden");
			});

			modelBuilder.Entity<SalidaLiniasReduced>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("SalidaLiniasReduced");
				entityTypeBuilder.Property(x => x.Cajones)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Salidas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.IdDepartamentoNavigation)
					.WithMany(x => x.Salidas)
					.HasForeignKey(x => x.IdDepartamento)
					.HasConstraintName("FK_Salidas_Departamentos");
				entityTypeBuilder.HasOne(x => x.idClienteNavigation)
					.WithMany(x => x.Salidas)
					.HasForeignKey(x => x.idCliente)
					.HasConstraintName("FK_Salidas_Clientes");
				entityTypeBuilder.HasOne(x => x.idSerieNavigation)
					.WithMany(x => x.Salidas)
					.HasForeignKey(x => x.idSerie)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Salidas_Series");
				entityTypeBuilder.HasOne(x => x.idViajeNavigation)
					.WithMany(x => x.Salidas)
					.HasForeignKey(x => x.idViaje)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Salidas_SalidasViajes");

#warning
#if NET7_0_OR_GREATER
				entityTypeBuilder.ToTable(x => x.HasTrigger("triggerInsertSalidas"));
#endif
			});

			modelBuilder.Entity<SalidasAlbaranes>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasIndex(x => new { x.Numero, x.Serie })
					.HasName("ISalAlbNumSerie");
				entityTypeBuilder.Property(x => x.Auto)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.HasOne(x => x.SerieNavigation)
					.WithMany(x => x.SalidasAlbaranes)
					.HasForeignKey(x => x.Serie)
					.HasConstraintName("FK_SalidasAlbaranes_Series");

#warning
#if NET7_0_OR_GREATER
				entityTypeBuilder.ToTable(x => x.HasTrigger("triggerInsertSalidasAlbaranes"));
#endif
			});

			modelBuilder.Entity<SalidasExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("SalidasExtended");
			});

			modelBuilder.Entity<SalidasInformeAduanas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("SalidasInformeAduanas");
			});

			modelBuilder.Entity<SalidasLineasExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("SalidasLineasExtended");
			});

			modelBuilder.Entity<SalidasLineasLoteExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("SalidasLineasLoteExtended");
			});

			modelBuilder.Entity<SalidasLineasResultados>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("SalidasLineasResultados");
			});

			modelBuilder.Entity<SalidasLinias>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.Origen1Navigation)
					.WithMany(x => x.SalidasLiniasOrigen1Navigation)
					.HasForeignKey(x => x.Origen1)
					.HasConstraintName("FK_SalidasLinias_Ubicaciones1");
				entityTypeBuilder.HasOne(x => x.Origen2Navigation)
					.WithMany(x => x.SalidasLiniasOrigen2Navigation)
					.HasForeignKey(x => x.Origen2)
					.HasConstraintName("FK_SalidasLinias_Ubicaciones2");
				entityTypeBuilder.HasOne(x => x.Origen3Navigation)
					.WithMany(x => x.SalidasLiniasOrigen3Navigation)
					.HasForeignKey(x => x.Origen3)
					.HasConstraintName("FK_SalidasLinias_Ubicaciones3");
				entityTypeBuilder.HasOne(x => x.Origen4Navigation)
					.WithMany(x => x.SalidasLiniasOrigen4Navigation)
					.HasForeignKey(x => x.Origen4)
					.HasConstraintName("FK_SalidasLinias_Ubicaciones4");
				entityTypeBuilder.HasOne(x => x.idAlbaranNavigation)
					.WithMany(x => x.SalidasLinias)
					.HasForeignKey(x => x.idAlbaran)
					.HasConstraintName("FK_SalidasLinias_SalidasAlbaranes");
				entityTypeBuilder.HasOne(x => x.idBasculaPesajeBrutoNavigation)
					.WithMany(x => x.SalidasLiniasidBasculaPesajeBrutoNavigation)
					.HasForeignKey(x => x.idBasculaPesajeBruto)
					.HasConstraintName("FK_SalidasLinias_BasculasBruto");
				entityTypeBuilder.HasOne(x => x.idBasculaPesajeNetoNavigation)
					.WithMany(x => x.SalidasLiniasidBasculaPesajeNetoNavigation)
					.HasForeignKey(x => x.idBasculaPesajeNeto)
					.HasConstraintName("FK_SalidasLinias_BasculasNeto");
				entityTypeBuilder.HasOne(x => x.idDomicilioNavigation)
					.WithMany(x => x.SalidasLinias)
					.HasForeignKey(x => x.idDomicilio)
					.HasConstraintName("FK_SalidasLinias_Domicilios");
				entityTypeBuilder.HasOne(x => x.idEnvaseNavigation)
					.WithMany(x => x.SalidasLinias)
					.HasForeignKey(x => x.idEnvase)
					.HasConstraintName("FK_SalidasLinias_Envases");
				entityTypeBuilder.HasOne(x => x.idFormatoNavigation)
					.WithMany(x => x.SalidasLinias)
					.HasForeignKey(x => x.idFormato)
					.HasConstraintName("FK_SalidasLinias_Formatos");
				entityTypeBuilder.HasOne(x => x.idProductoNavigation)
					.WithMany(x => x.SalidasLinias)
					.HasForeignKey(x => x.idProducto)
					.HasConstraintName("FK_SalidasLinias_Productos");
				entityTypeBuilder.HasOne(x => x.idPuntoDescargaNavigation)
					.WithMany(x => x.SalidasLinias)
					.HasForeignKey(x => x.idPuntoDescarga)
					.HasConstraintName("FK_SalidasLinias_PuntosDescarga");
				entityTypeBuilder.HasOne(x => x.idSalidasNavigation)
					.WithMany(x => x.SalidasLinias)
					.HasForeignKey(x => x.idSalidas)
					.HasConstraintName("FK_SalidasLinias_Salidas");
				entityTypeBuilder.HasOne(x => x.idUnidadNavigation)
					.WithMany(x => x.SalidasLinias)
					.HasForeignKey(x => x.idUnidad)
					.HasConstraintName("FK_SalidasLinias_Unidades");
				entityTypeBuilder.HasOne(x => x.idmoduloNavigation)
					.WithMany(x => x.SalidasLinias)
					.HasForeignKey(x => x.idmodulo)
					.HasConstraintName("FK_SalidasLinias_Modulos");
				entityTypeBuilder.HasOne(x => x.idviajesNavigation)
					.WithMany(x => x.SalidasLinias)
					.HasForeignKey(x => x.idviajes)
					.HasConstraintName("FK_SalidasLinias_SalidasViajes");
			});

			modelBuilder.Entity<SalidasLiniasLote>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idLineaSalidaNavigation)
					.WithMany(x => x.SalidasLiniasLote)
					.HasForeignKey(x => x.idLineaSalida)
					.HasConstraintName("FK_SalidasLiniasLote_SalidasLinias");
				entityTypeBuilder.HasOne(x => x.idLineaSalidaMedicamentoNavigation)
					.WithMany(x => x.SalidasLiniasLote)
					.HasForeignKey(x => x.idLineaSalidaMedicamento)
					.HasConstraintName("FK_SalidasLiniasLote_SalidasLiniasMedicaciones");
				entityTypeBuilder.HasOne(x => x.idLoteNavigation)
					.WithMany(x => x.SalidasLiniasLote)
					.HasForeignKey(x => x.idLote)
					.HasConstraintName("FK_SalidasLiniasLote_Lotes");
			});

			modelBuilder.Entity<SalidasLiniasMedicaciones>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.IdUnidadNavigation)
					.WithMany(x => x.SalidasLiniasMedicaciones)
					.HasForeignKey(x => x.IdUnidad)
					.HasConstraintName("FK_SalidasLiniasMedicaciones_Unidades");
				entityTypeBuilder.HasOne(x => x.idEnvaseNavigation)
					.WithMany(x => x.SalidasLiniasMedicaciones)
					.HasForeignKey(x => x.idEnvase)
					.HasConstraintName("FK_SalidasLiniasMedicaciones_Envases");
				entityTypeBuilder.HasOne(x => x.idFormatoNavigation)
					.WithMany(x => x.SalidasLiniasMedicaciones)
					.HasForeignKey(x => x.idFormato)
					.HasConstraintName("FK_SalidasLiniasMedicaciones_Formatos");
				entityTypeBuilder.HasOne(x => x.idOrigenNavigation)
					.WithMany(x => x.SalidasLiniasMedicaciones)
					.HasForeignKey(x => x.idOrigen)
					.HasConstraintName("FK_SalidasLiniasMedicaciones_Ubicaciones");
				entityTypeBuilder.HasOne(x => x.idSalidaLiniaNavigation)
					.WithMany(x => x.SalidasLiniasMedicaciones)
					.HasForeignKey(x => x.idSalidaLinia)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_SalidasLiniasMedicaciones_SalidasLinias");
			});

			modelBuilder.Entity<SalidasLiniasMedicacionesExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("SalidasLiniasMedicacionesExtended");
			});

			modelBuilder.Entity<SalidasLiniasMuestras>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idControlesNirNavigation)
					.WithMany(x => x.SalidasLiniasMuestras)
					.HasForeignKey(x => x.idControlesNir)
					.HasConstraintName("FK_SalidasLiniasMuestras_ControlesNIR");
				entityTypeBuilder.HasOne(x => x.idSalidasLineasNavigation)
					.WithMany(x => x.SalidasLiniasMuestras)
					.HasForeignKey(x => x.idSalidasLineas)
					.HasConstraintName("FK_SalidasLiniasMuestras_SalidasLinias");
			});

			modelBuilder.Entity<SalidasLiniasPuntosDescarga>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idLineaSalidaNavigation)
					.WithMany(x => x.SalidasLiniasPuntosDescarga)
					.HasForeignKey(x => x.idLineaSalida)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_SalidasLiniasPuntosDescarga_SalidasLinias");
				entityTypeBuilder.HasOne(x => x.idPuntoDescargaNavigation)
					.WithMany(x => x.SalidasLiniasPuntosDescarga)
					.HasForeignKey(x => x.idPuntoDescarga)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_SalidasLiniasPuntosDescarga_PuntosDescarga");
			});

			modelBuilder.Entity<SalidasLotesServidos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("SalidasLotesServidos");
			});

			modelBuilder.Entity<SalidasViajes>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasIndex(x => new { x.id, x.MatriculaRemolque, x.idVehiculo, x.idChofer, x.idTarjeta, x.EstadoTransito, x.MatriculaCamion, x.NombreConductor, x.Observaciones, x.idEmpresaTransporte, x.FInicioTransito, x.FInicioViaje, x.FFinViaje, x.Referencia, x.FechaPrevista, x.idSerie, x.Numero, x.PreDesinfeccion, x.PostDesinfeccion, x.FechaCreacion, x.Estado, x.FFinalTransito })
					.HasName("ISalidasViajes");
				entityTypeBuilder.HasOne(x => x.idChoferNavigation)
					.WithMany(x => x.SalidasViajes)
					.HasForeignKey(x => x.idChofer)
					.HasConstraintName("FK_SalidasViajes_Choferes");
				entityTypeBuilder.HasOne(x => x.idEmpresaTransporteNavigation)
					.WithMany(x => x.SalidasViajes)
					.HasForeignKey(x => x.idEmpresaTransporte)
					.HasConstraintName("FK_SalidasViajes_EmpresasTransporte");
				entityTypeBuilder.HasOne(x => x.idSerieNavigation)
					.WithMany(x => x.SalidasViajes)
					.HasForeignKey(x => x.idSerie)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_SalidasViajes_Series");
				entityTypeBuilder.HasOne(x => x.idTarjetaNavigation)
					.WithMany(x => x.SalidasViajes)
					.HasForeignKey(x => x.idTarjeta)
					.HasConstraintName("FK_SalidasViajes_Tarjetas");
				entityTypeBuilder.HasOne(x => x.idVehiculoNavigation)
					.WithMany(x => x.SalidasViajes)
					.HasForeignKey(x => x.idVehiculo)
					.HasConstraintName("FK_SalidasViajes_Vehiculos");

#warning
#if NET7_0_OR_GREATER
				entityTypeBuilder.ToTable(x => x.HasTrigger("triggerInsertSalidasViajes"));
#endif
			});

			modelBuilder.Entity<SalidasViajesExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("SalidasViajesExtended");
			});

			modelBuilder.Entity<Secciones>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.OpcConfig)
					.WithMany(x => x.Secciones)
					.HasForeignKey(x => x.OpcConfigId)
					.HasConstraintName("FK__Secciones__OpcCo__7948ECA7");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.SeccionesGruposConfiguration());
			modelBuilder.ApplyConfiguration(new Internal.Configurations.SeriesConfiguration());

			modelBuilder.Entity<ServerConfigs>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.id)
					.ValueGeneratedOnAdd();
			});

			modelBuilder.Entity<SesionesModulo>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.ModuloNavigation)
					.WithMany(x => x.SesionesModulo)
					.HasForeignKey(x => x.Modulo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_SesionesModulo_Modulos");
				entityTypeBuilder.HasOne(x => x.SesionNavigation)
					.WithMany(x => x.SesionesModulo)
					.HasForeignKey(x => x.Sesion)
					.HasConstraintName("FK_SesionesModulo_Sesiones");
			});

			modelBuilder.Entity<SesionesSeccion>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.SeccionNavigation)
					.WithMany(x => x.SesionesSeccion)
					.HasForeignKey(x => x.Seccion)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_SesionesSeccion_Secciones");
				entityTypeBuilder.HasOne(x => x.SesionNavigation)
					.WithMany(x => x.SesionesSeccion)
					.HasForeignKey(x => x.Sesion)
					.HasConstraintName("FK_SesionesSeccion_Sesiones");
			});

			modelBuilder.Entity<StatusDisks>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasIndex(x => x.Id)
					.HasName("_dta_index_StatusDisks_1");
				entityTypeBuilder.Property(x => x.Fecha)
					.HasDefaultValueSql("(getdate())");
			});

			modelBuilder.Entity<StockProductoLoteCaducidad>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("StockProductoLoteCaducidad");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.StocksConfiguration());

			modelBuilder.Entity<StocksReserva>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Activo)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.HasOne(x => x.idEntradasLineasNavigation)
					.WithMany(x => x.StocksReserva)
					.HasForeignKey(x => x.idEntradasLineas)
					.HasConstraintName("FK_StocksReserva_EntradasLineas");
				entityTypeBuilder.HasOne(x => x.idLoteNavigation)
					.WithMany(x => x.StocksReserva)
					.HasForeignKey(x => x.idLote)
					.HasConstraintName("FK_StocksReserva_Lotes");
				entityTypeBuilder.HasOne(x => x.idOrdenNavigation)
					.WithMany(x => x.StocksReserva)
					.HasForeignKey(x => x.idOrden)
					.HasConstraintName("FK_StocksReserva_Ordenes");
				entityTypeBuilder.HasOne(x => x.idProductoNavigation)
					.WithMany(x => x.StocksReserva)
					.HasForeignKey(x => x.idProducto)
					.HasConstraintName("FK_StocksReserva_Productos");
				entityTypeBuilder.HasOne(x => x.idSalidasLineasNavigation)
					.WithMany(x => x.StocksReserva)
					.HasForeignKey(x => x.idSalidasLineas)
					.HasConstraintName("FK_StocksReserva_SalidasLinias");
				entityTypeBuilder.HasOne(x => x.idSalidasLineasMedicNavigation)
					.WithMany(x => x.StocksReserva)
					.HasForeignKey(x => x.idSalidasLineasMedic)
					.HasConstraintName("FK_StocksReserva_SalidasLiniasMedicaciones");
				entityTypeBuilder.HasOne(x => x.idStockNavigation)
					.WithMany(x => x.StocksReserva)
					.HasForeignKey(x => x.idStock)
					.HasConstraintName("FK_StocksReserva_Stocks");
				entityTypeBuilder.HasOne(x => x.idUbicacionNavigation)
					.WithMany(x => x.StocksReserva)
					.HasForeignKey(x => x.idUbicacion)
					.HasConstraintName("FK_StocksReserva_Ubicaciones");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.TagsConfiguration());

			modelBuilder.Entity<TagsBasculas>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Predeterminada)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.HasOne(x => x.idBasculaNavigation)
					.WithMany(x => x.TagsBasculas)
					.HasForeignKey(x => x.idBascula)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_TagsBasculas_Basculas");
				entityTypeBuilder.HasOne(x => x.idTagNavigation)
					.WithMany(x => x.TagsBasculas)
					.HasForeignKey(x => x.idTag)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_TagsBasculas_Tags");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.TagsLecturasConfiguration());

			modelBuilder.Entity<Tarifas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.ClienteNavigation)
					.WithMany(x => x.Tarifas)
					.HasForeignKey(x => x.Cliente)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_Tarifas_Clientes");
				entityTypeBuilder.HasOne(x => x.EnvaseNavigation)
					.WithMany(x => x.Tarifas)
					.HasForeignKey(x => x.Envase)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Tarifas_Envases");
				entityTypeBuilder.HasOne(x => x.MedicacionNavigation)
					.WithMany(x => x.Tarifas)
					.HasForeignKey(x => x.Medicacion)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Tarifas_Medicaciones");
				entityTypeBuilder.HasOne(x => x.ProductoNavigation)
					.WithMany(x => x.Tarifas)
					.HasForeignKey(x => x.Producto)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_Tarifas_Productos");
				entityTypeBuilder.HasOne(x => x.UnidadNavigation)
					.WithMany(x => x.Tarifas)
					.HasForeignKey(x => x.Unidad)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Tarifas_Unidades");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.TarjetasConfiguration());

			modelBuilder.Entity<TempControlesMedidores>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idMedidorNavigation)
					.WithMany(x => x.TempControlesMedidores)
					.HasForeignKey(x => x.idMedidor)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_TempControlesMedidores_Medidores");
				entityTypeBuilder.HasOne(x => x.idTempControlNavigation)
					.WithMany(x => x.TempControlesMedidores)
					.HasForeignKey(x => x.idTempControl)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_TempControlesMedidores_TempControles");
			});

			modelBuilder.Entity<TextosParametros>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasIndex(x => new { x.Grupo, x.Parametro, x.IdTexto })
					.HasName("NonClusteredIndex-20180409-131855")
					.IsUnique();
			});

			modelBuilder.Entity<TiempoLimpieza>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.ModuloId, x.UbicacionId });
			});

			modelBuilder.Entity<TotalCantidadPorOrden>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("TotalCantidadPorOrden");
			});

			modelBuilder.Entity<TotalProducidoPorOrden>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("TotalProducidoPorOrden");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.UbicacionesConfiguration());

			modelBuilder.Entity<UbicacionesAsociadas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idUbicacion1Navigation)
					.WithMany(x => x.UbicacionesAsociadasidUbicacion1Navigation)
					.HasForeignKey(x => x.idUbicacion1)
					.HasConstraintName("FK_UbicacionesAsociadas_Ubicaciones");
				entityTypeBuilder.HasOne(x => x.idUbicacion2Navigation)
					.WithMany(x => x.UbicacionesAsociadasidUbicacion2Navigation)
					.HasForeignKey(x => x.idUbicacion2)
					.HasConstraintName("FK_UbicacionesAsociadas_Ubicaciones1");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.UbicacionesOpcConfigConfiguration());

			modelBuilder.Entity<UbisMedsAfino>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasKey(x => new { x.idUbicacion, x.idMedidor });
				entityTypeBuilder.Property(x => x.id)
					.ValueGeneratedOnAdd();
				entityTypeBuilder.HasOne(x => x.idMedidorNavigation)
					.WithMany(x => x.UbisMedsAfino)
					.HasForeignKey(x => x.idMedidor)
					.HasConstraintName("FK_UbisMedsAfino_Medidores");
				entityTypeBuilder.HasOne(x => x.idUbicacionNavigation)
					.WithMany(x => x.UbisMedsAfino)
					.HasForeignKey(x => x.idUbicacion)
					.HasConstraintName("FK_UbisMedsAfino_Ubicaciones");
			});

			modelBuilder.Entity<Usuarios>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasIndex(x => x.Rol)
					.HasName("IX_FK_Usuarios_UsuariosRoles");
				entityTypeBuilder.Property(x => x.ActivoScada)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.AutoEntAlmacen)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.AutoPremezclas)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.LDAPUser)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.Property(x => x.PermisoScada)
					.HasDefaultValueSql("((0))");
				entityTypeBuilder.HasOne(x => x.RolNavigation)
					.WithMany(x => x.UsuariosNavigation)
					.HasForeignKey(x => x.Rol)
					.HasConstraintName("FK_Usuarios_UsuariosRoles");
			});

			modelBuilder.Entity<UsuariosGruposLDAP>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idRolNavigation)
					.WithMany(x => x.UsuariosGruposLDAP)
					.HasForeignKey(x => x.idRol)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_UsuariosGruposLDAP_UsuariosRoles");
			});

			modelBuilder.Entity<UsuariosLogs>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasIndex(x => x.Activo)
					.HasName("_dta_index_UsuariosLogs_1");
				entityTypeBuilder.Property(x => x.Activo)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.Property(x => x.Desconexion)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.Property(x => x.Login)
					.HasDefaultValueSql("(getdate())");
				entityTypeBuilder.HasOne(x => x.idUsuarioNavigation)
					.WithMany(x => x.UsuariosLogs)
					.HasForeignKey(x => x.idUsuario)
					.HasConstraintName("FK_UsuariosLogs_Usuarios");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.UsuariosRolesConfiguration());

			modelBuilder.Entity<UsuariosRolesConfigForm>(entityTypeBuilder =>
			{
				entityTypeBuilder.Property(x => x.Activo)
					.HasDefaultValueSql("((1))");
				entityTypeBuilder.HasOne(x => x.UsuarioRolNavigation)
					.WithMany(x => x.UsuariosRolesConfigForm)
					.HasForeignKey(x => x.UsuarioRol)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_UsuariosRolesConfigForm_UsuariosRoles");
			});

			modelBuilder.Entity<UsuariosRolesInformes>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idRolNavigation)
					.WithMany(x => x.UsuariosRolesInformes)
					.HasForeignKey(x => x.idRol)
					.HasConstraintName("FK_UsuariosRolesInformes_UsuariosRoles");
			});

			modelBuilder.Entity<UsuariosRolesModulos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasIndex(x => x.idModulo)
					.HasName("IX_FK_UsuariosRolesModulos_Modulos");
				entityTypeBuilder.HasIndex(x => x.idRol)
					.HasName("IX_FK_UsuariosRolesModulos_UsuariosRoles");
				entityTypeBuilder.HasOne(x => x.idModuloNavigation)
					.WithMany(x => x.UsuariosRolesModulos)
					.HasForeignKey(x => x.idModulo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_UsuariosRolesModulos_Modulos");
				entityTypeBuilder.HasOne(x => x.idRolNavigation)
					.WithMany(x => x.UsuariosRolesModulos)
					.HasForeignKey(x => x.idRol)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_UsuariosRolesModulos_UsuariosRoles");
			});

			modelBuilder.Entity<Valores>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.OrdenNavigation)
					.WithMany(x => x.Valores)
					.HasForeignKey(x => x.Orden)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Valores_Ordenes");
				entityTypeBuilder.HasOne(x => x.VariableNavigation)
					.WithMany(x => x.Valores)
					.HasForeignKey(x => x.Variable)
					.HasConstraintName("FK_Valores_Variables");
			});

			modelBuilder.Entity<Variables>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.ModuloNavigation)
					.WithMany(x => x.Variables)
					.HasForeignKey(x => x.Modulo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Variables_Modulos");
			});

			modelBuilder.Entity<Vehiculos>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.ChoferNavigation)
					.WithMany(x => x.Vehiculos)
					.HasForeignKey(x => x.Chofer)
					.HasConstraintName("FK_Vehiculos_Choferes");
				entityTypeBuilder.HasOne(x => x.EmpresaTransporteNavigation)
					.WithMany(x => x.Vehiculos)
					.HasForeignKey(x => x.EmpresaTransporte)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Vehiculos_EmpresasTransporte");
				entityTypeBuilder.HasOne(x => x.TarjetaNavigation)
					.WithMany(x => x.Vehiculos)
					.HasForeignKey(x => x.Tarjeta)
					.HasConstraintName("FK_Vehiculos_Tarjetas");
			});

			modelBuilder.Entity<Ventas>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.DepartamentoNavigation)
					.WithMany(x => x.Ventas)
					.HasForeignKey(x => x.Departamento)
					.HasConstraintName("FK_Ventas_Departamentos");
				entityTypeBuilder.HasOne(x => x.idClienteNavigation)
					.WithMany(x => x.Ventas)
					.HasForeignKey(x => x.idCliente)
					.HasConstraintName("FK_Ventas_Clientes");
				entityTypeBuilder.HasOne(x => x.idDomicilioNavigation)
					.WithMany(x => x.Ventas)
					.HasForeignKey(x => x.idDomicilio)
					.HasConstraintName("FK_Ventas_Domicilios");
				entityTypeBuilder.HasOne(x => x.idSerieNavigation)
					.WithMany(x => x.Ventas)
					.HasForeignKey(x => x.idSerie)
					.HasConstraintName("FK_Ventas_Series");

#warning
#if NET7_0_OR_GREATER
				entityTypeBuilder.ToTable(x => x.HasTrigger("triggerInsertVentas"));
#endif
			});

			modelBuilder.Entity<VentasExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("VentasExtended");
			});

			modelBuilder.Entity<VentasLineasExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("VentasLineasExtended");
			});

			modelBuilder.Entity<VentasLineasMedicacionesExtended>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("VentasLineasMedicacionesExtended");
			});

			modelBuilder.Entity<VentasLinias>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.MedEnvaseNavigation)
					.WithMany(x => x.VentasLiniasMedEnvaseNavigation)
					.HasForeignKey(x => x.MedEnvase)
					.HasConstraintName("FKMed_VentasLinias_Envases");
				entityTypeBuilder.HasOne(x => x.MedFormatoNavigation)
					.WithMany(x => x.VentasLiniasMedFormatoNavigation)
					.HasForeignKey(x => x.MedFormato)
					.HasConstraintName("FKMed_VentasLinias_Formatos");
				entityTypeBuilder.HasOne(x => x.MedUnidadNavigation)
					.WithMany(x => x.VentasLiniasMedUnidadNavigation)
					.HasForeignKey(x => x.MedUnidad)
					.HasConstraintName("FKMed_VentasLinias_Unidades");
				entityTypeBuilder.HasOne(x => x.idContratoNavigation)
					.WithMany(x => x.VentasLinias)
					.HasForeignKey(x => x.idContrato)
					.HasConstraintName("FK_VentasLinias_Contratos");
				entityTypeBuilder.HasOne(x => x.idDomicilioNavigation)
					.WithMany(x => x.VentasLinias)
					.HasForeignKey(x => x.idDomicilio)
					.HasConstraintName("FK_VentasLinias_Domicilios");
				entityTypeBuilder.HasOne(x => x.idEnvaseNavigation)
					.WithMany(x => x.VentasLiniasidEnvaseNavigation)
					.HasForeignKey(x => x.idEnvase)
					.HasConstraintName("FK_VentasLinias_Envases");
				entityTypeBuilder.HasOne(x => x.idFormatoNavigation)
					.WithMany(x => x.VentasLiniasidFormatoNavigation)
					.HasForeignKey(x => x.idFormato)
					.HasConstraintName("FK_VentasLinias_Formatos");
				entityTypeBuilder.HasOne(x => x.idMedicamentoNavigation)
					.WithMany(x => x.VentasLinias)
					.HasForeignKey(x => x.idMedicamento)
					.HasConstraintName("FK_VentasLinias_Medicaciones");
				entityTypeBuilder.HasOne(x => x.idProductoNavigation)
					.WithMany(x => x.VentasLinias)
					.HasForeignKey(x => x.idProducto)
					.HasConstraintName("FK_VentasLinias_Productos");
				entityTypeBuilder.HasOne(x => x.idPuntoDescargaNavigation)
					.WithMany(x => x.VentasLinias)
					.HasForeignKey(x => x.idPuntoDescarga)
					.HasConstraintName("FK_VentasLinias_PuntosDescarga");
				entityTypeBuilder.HasOne(x => x.idUnidadNavigation)
					.WithMany(x => x.VentasLiniasidUnidadNavigation)
					.HasForeignKey(x => x.idUnidad)
					.HasConstraintName("FK_VentasLinias_Unidades");
				entityTypeBuilder.HasOne(x => x.idVentasNavigation)
					.WithMany(x => x.VentasLinias)
					.HasForeignKey(x => x.idVentas)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_VentasLinias_Ventas");
			});

			modelBuilder.Entity<VentasLiniasMedicaciones>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idEnvaseNavigation)
					.WithMany(x => x.VentasLiniasMedicaciones)
					.HasForeignKey(x => x.idEnvase)
					.HasConstraintName("FK_VentasLiniasMedicaciones_Envases");
				entityTypeBuilder.HasOne(x => x.idFormatoNavigation)
					.WithMany(x => x.VentasLiniasMedicaciones)
					.HasForeignKey(x => x.idFormato)
					.HasConstraintName("FK_VentasLiniasMedicaciones_Formatos");
				entityTypeBuilder.HasOne(x => x.idUnidadNavigation)
					.WithMany(x => x.VentasLiniasMedicaciones)
					.HasForeignKey(x => x.idUnidad)
					.HasConstraintName("FK_VentasLiniasMedicaciones_Unidades");
				entityTypeBuilder.HasOne(x => x.idVentaLiniaNavigation)
					.WithMany(x => x.VentasLiniasMedicaciones)
					.HasForeignKey(x => x.idVentaLinia)
					.HasConstraintName("FK_VentasLiniasMedicaciones_VentasLinias");
			});

			modelBuilder.Entity<VentasLiniasPuntosDescarga>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idLineaVentaNavigation)
					.WithMany(x => x.VentasLiniasPuntosDescarga)
					.HasForeignKey(x => x.idLineaVenta)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_VentasLiniasPuntosDescarga_SalidasLinias");
				entityTypeBuilder.HasOne(x => x.idPuntoDescargaNavigation)
					.WithMany(x => x.VentasLiniasPuntosDescarga)
					.HasForeignKey(x => x.idPuntoDescarga)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_VentasLiniasPuntosDescarga_PuntosDescarga");
			});

			modelBuilder.Entity<VersionTPrevisto>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.idModuloNavigation)
					.WithMany(x => x.VersionTPrevisto)
					.HasForeignKey(x => x.idModulo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_VersionTPrevisto_Modulos");
				entityTypeBuilder.HasOne(x => x.idVersionNavigation)
					.WithMany(x => x.VersionTPrevisto)
					.HasForeignKey(x => x.idVersion)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_VersionTPrevisto_Versiones");
			});

			modelBuilder.ApplyConfiguration(new Internal.Configurations.VersionesConfiguration());

			modelBuilder.Entity<Veterinarios>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasOne(x => x.IdEmpresaNavigation)
					.WithMany(x => x.Veterinarios)
					.HasForeignKey(x => x.IdEmpresa)
					.OnDelete(DeleteBehavior.SetNull)
					.HasConstraintName("FK_Veterinarios_Empresas");
				entityTypeBuilder.HasOne(x => x.ProvinciaNavigation)
					.WithMany(x => x.Veterinarios)
					.OnDelete(DeleteBehavior.SetNull);
			});

			modelBuilder.Entity<recursivo>(entityTypeBuilder =>
			{
				entityTypeBuilder.HasNoKey();
				entityTypeBuilder.ToView("recursivo");
			});
		}

	}

}
