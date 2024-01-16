using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Modulos
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? Departamento { get; set; }

		public int? Sesion { get; set; }

		public int? Formato { get; set; }

		public int? Envase { get; set; }

		public int? Unidad { get; set; }

		public bool? Maquinaria { get; set; }

		public int? Simultaneos { get; set; }

		public bool? Controlado { get; set; }

		public bool GenerarComprovacionOrigenVacio { get; set; }

		public bool? Manual { get; set; }

		public bool? OptimizarPesada { get; set; }

		public bool? ControlEntradas { get; set; }

		public bool? ControlSalidas { get; set; }

		public int? OrigenDefecto { get; set; }

		public int? DestinoDefecto { get; set; }

		public bool? EstadoAlarma { get; set; }

		public bool? Duplicidad { get; set; }

		public bool? Alternativas { get; set; }

		public bool? CambioDestino { get; set; }

		public int? TipoProducto { get; set; }

		public bool? ControlUbicacion { get; set; }

		public bool? ImprimirParte { get; set; }

		public bool? ImprimirOrden { get; set; }

		public bool? ImprimirEtiqueta { get; set; }

		public bool? InicioAutomatico { get; set; }

		public bool? DetenerAutomatico { get; set; }

		public bool? FinAutomatico { get; set; }

		public bool? EsperarServida { get; set; }

		public int? Etiqueta { get; set; }

		public int? TipoEtiqueta { get; set; }

		public float? CantidadCiclo { get; set; }

		public bool? PermitirMuestras { get; set; }

		public bool? MostrarMateriaPrima { get; set; }

		public bool? MostrarSemielaborado { get; set; }

		public bool? MostrarProductoTerminado { get; set; }

		public bool? ProductoDestino { get; set; }

		public bool? Premezclas { get; set; }

		public bool? PermitirCancelar { get; set; }

		public bool? ProcesoVisible { get; set; }

		public int? GananciaUnidad { get; set; }

		public float? Ganancia { get; set; }

		public int? EnvaseOrigen { get; set; }

		[Column("Estado")]
		[Obsolete]
		public ModuleCommunicationStatus CommunicationStatus { get; set; }

		public bool? TransporteInicial { get; set; }

		public bool? Confirmar { get; set; }

		public bool? MostrarFormula { get; set; }

		public int? AvisoCambioSilo { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? TipoMensaje { get; set; }

		public int? ModuloAscendiente { get; set; }

		public bool? ComponentesAsignados { get; set; }

		public int? MedidorAscendientes { get; set; }

		public int? UnidadDosificacion { get; set; }

		public bool? ModuloContinuo { get; set; }

		public float? Velocidad { get; set; }

		public bool? LoteObligatorio { get; set; }

		public bool? VerificarEnvio { get; set; }

		public int? Proceso { get; set; }

		public bool? CantidadTeoricaObligatoria { get; set; }

		public bool? CantidadRealObligatoria { get; set; }

		public float? StockMinimo { get; set; }

		public int? FiltroOrigenes { get; set; }

		public int? FiltroDestinos { get; set; }

		[StringLength(50)]
		public string LotePlc { get; set; }

		public bool? ControlTransito { get; set; }

		public int? Bascula { get; set; }

		public bool? ControlCapacidadSilos { get; set; }

		public bool? CrearOrdenesRelacionadas { get; set; }

		public int? CiclosDefecto { get; set; }

		public bool? MostrarConsumos { get; set; }

		public bool? ProponerSiloDestino { get; set; }

		public int? MetodoLote { get; set; }

		[StringLength(50)]
		public string FormatoLote { get; set; }

		public int? PeriodoCaducidad { get; set; }

		public bool? CaducidadAutomatica { get; set; }

		public bool? PermitirVariosDestinos { get; set; }

		public bool? MostrarEnCalendario { get; set; }

		public int OrdenProduccion { get; set; }

		public ModuleType TipoModulo { get; set; }

		public int? idOld { get; set; }

		public bool? RevisarOrigenes { get; set; }

		public bool? RevisarDestinos { get; set; }

		public int OpcConfigId { get; set; }

		public int? RolBase { get; set; }

		public bool? CodBarrasLoteConfirmacion { get; set; }

		public bool? VerBotonTaraACero { get; set; }

		public bool? VerBotonBrutoACero { get; set; }

		public bool? VerBotonSaltar { get; set; }

		public bool? VerBotonParcial { get; set; }

		public bool? VerBotonTeorico { get; set; }

		public bool? VerBotonConfirmar { get; set; }

		public bool? PermitirCambiarLote { get; set; }

		public bool? PermitirCambiarProducto { get; set; }

		public bool? VerBotonCambioLote { get; set; }

		public bool? PermitirDosificacionParcial { get; set; }

		public bool? CodBarrasLoteConfirmacionParcial { get; set; }

		public bool? PermitirCambioNumCiclos { get; set; }

		[Column("idPLC")]
		public int IdPlc { get; set; }

		public bool? EnviarReset { get; set; }

		public bool? EnviarOrdenesAPLC { get; set; }

		public bool? ModoDebugServidor { get; set; }

		public bool? ComprobarPlantilla { get; set; }

		public int? idPlantillaBase { get; set; }

		public bool? NecesitaMotores { get; set; }

		public bool? PLCOMarcha { get; set; }

		public bool? PLCOParo { get; set; }

		public bool? PLCOPausa { get; set; }

		public bool? PLCOReanudar { get; set; }

		public bool? PLCOResetear { get; set; }

		public int? PLCDestinoIdActual { get; set; }

		public int? PLCOrdenNumActual { get; set; }

		public int? PLCTCiclosNumActual { get; set; }

		public int? PLCCaminoActual { get; set; }

		public ModuleStatus PLCEstadoActual { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? PLCVariablesActual0 { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? PLCVariablesActual1 { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? PLCVariablesActual2 { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? PLCVariablesActual3 { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? PLCVariablesActual4 { get; set; }

		public int? PLCMedidoresIdSocios0 { get; set; }

		public int? PLCMedidoresIdSocios1 { get; set; }

		public int? PLCMedidoresIdSocios2 { get; set; }

		public int? PLCMedidoresIdSocios3 { get; set; }

		public int? PLCMedidoresIdSocios4 { get; set; }

		public int? PLCMedidoresIdSocios5 { get; set; }

		public int? PLCMedidoresIdSocios6 { get; set; }

		public int? PLCMedidoresIdSocios7 { get; set; }

		public int? PLCMedidoresIdSocios8 { get; set; }

		public int? PLCMedidoresIdSocios9 { get; set; }

		public bool? IniciarEnServidor { get; set; }

		public bool? PLCPermisoSiguienteOrden { get; set; }

		public bool? PermitirOrdenesLimpieza { get; set; }

		public bool? LimpiezaProdFinalDiferente { get; set; }

		[Column(TypeName = "numeric(18, 2)")]
		public decimal? DuracionOrden { get; set; }

		public int? idPlantillaLimpieza { get; set; }

		public bool ConOrigenes { get; set; }

		public bool ConDestinos { get; set; }

		public bool? AjusteStockFinalOrden { get; set; }

		public bool? MinimoSiloResetUbi { get; set; }

		public bool? VaciarSilosMinimosFinOrden { get; set; }

		public bool? CaminosActivar { get; set; }

		public int? CaminosMin { get; set; }

		public int? CaminosMax { get; set; }

		public string CaminosDescripcion { get; set; }

		public bool? ResituarEnServidor { get; set; }

		public bool? ProducidosDeConsumidos { get; set; }

		public bool? FinalizarNopAlarmas { get; set; }

		public bool? PermitirVariosOrigenes { get; set; }

		public bool? PermitirModoVolteo { get; set; }

		public int? ProdFinalDefecto { get; set; }

		public bool? ImpEtiquetaMuestraFinal { get; set; }

		public bool? NoEnviarOrdenes { get; set; }

		public int? ModuloAsociadoOrdenes1 { get; set; }

		public int? ModuloAsociadoOrdenes2 { get; set; }

		public int? CaminoDefecto { get; set; }

		public bool? AjusteTiempoEfectivo { get; set; }

		public bool? SeleccionarCajones { get; set; }

		public bool? IncompatComprobar { get; set; }

		public bool? MostrarEnGantt { get; set; }

		[Obsolete]
		public int? EstadoForzado { get; set; }

		[Obsolete]
		public bool? DisponibleOEE { get; set; }

		[Obsolete]
		public bool? MedirOEE { get; set; }

		public bool? PermitirModoMantenimiento { get; set; }

		public bool? RequiereEnvase { get; set; }

		public bool? ScadaDatos { get; set; }

		[Column(TypeName = "decimal(15, 3)")]
		[Obsolete]
		public decimal? OEEKgHora { get; set; }

		public bool? ResetearIntegraModulo { get; set; }

		public bool? OPCEnvioFCaducidadVar1 { get; set; }

		public bool? OPCEnvioEan13Var2Var3 { get; set; }

		public bool? PermitirAlertas { get; set; }

		public bool? GenerarLote { get; set; }

		[StringLength(30)]
		public string Referencia { get; set; }

		public bool PermitirOrdenArranque { get; set; }

		public bool PermitirAutoRespuesta { get; set; }

		public bool PermitirMismoOrigenDestino { get; set; }

		public bool? EnviarIdCabOrden { get; set; }

		public bool? PermitirResetear { get; set; }

		public bool? GenerarAutoInicio { get; set; }

		public bool? RecibirAutoInicio { get; set; }

		public bool? CrearOrden { get; set; }

		public bool? RequiereValidacion { get; set; }

		public bool VolteoHabilitarModoTiempo { get; set; }

		public bool VolteoHabilitarVaciarOrigen { get; set; }

		public bool VolteoHabilitarLlenarDestino { get; set; }

		public bool AsignarProductoDestino { get; set; }

		public bool IgnorarConsumidos { get; set; }

		public bool IgnorarProducidos { get; set; }

		public bool PlcEnabled { get; set; }

		public int NumValidaciones { get; set; }

		public bool PermitirPausar { get; set; }

		public bool PermitirReanudar { get; set; }

		[ForeignKey(nameof(Departamento))]
		[InverseProperty(nameof(Departamentos.Modulos))]
		public virtual Departamentos DepartamentoNavigation { get; set; }

		[ForeignKey(nameof(ModuloAsociadoOrdenes1))]
		[InverseProperty(nameof(Modulos.InverseModuloAsociadoOrdenes1Navigation))]
		public virtual Modulos ModuloAsociadoOrdenes1Navigation { get; set; }

		[ForeignKey(nameof(ModuloAsociadoOrdenes2))]
		[InverseProperty(nameof(Modulos.InverseModuloAsociadoOrdenes2Navigation))]
		public virtual Modulos ModuloAsociadoOrdenes2Navigation { get; set; }

		[InverseProperty(nameof(Models.ModuloEstadoComunicaciones.Modulo))]
		public virtual ModuloEstadoComunicaciones ModuloEstadoComunicaciones { get; set; }

		[ForeignKey(nameof(OpcConfigId))]
		[InverseProperty(nameof(Models.OpcConfig.Modulos))]
		public virtual OpcConfig OpcConfig { get; set; }

		[ForeignKey(nameof(PLCOrdenNumActual))]
		[InverseProperty(nameof(Models.Ordenes.Modulos))]
		public virtual Ordenes PLCOrdenNumActualNavigation { get; set; }

		[ForeignKey(nameof(ProdFinalDefecto))]
		[InverseProperty(nameof(Models.Productos.Modulos))]
		public virtual Productos ProdFinalDefectoNavigation { get; set; }

		[ForeignKey(nameof(RolBase))]
		[InverseProperty(nameof(UsuariosRoles.Modulos))]
		public virtual UsuariosRoles RolBaseNavigation { get; set; }

		[ForeignKey(nameof(idPlantillaBase))]
		[InverseProperty(nameof(Models.OperCabPlantillas.ModulosidPlantillaBaseNavigation))]
		public virtual OperCabPlantillas idPlantillaBaseNavigation { get; set; }

		[ForeignKey(nameof(idPlantillaLimpieza))]
		[InverseProperty(nameof(Models.OperCabPlantillas.ModulosidPlantillaLimpiezaNavigation))]
		public virtual OperCabPlantillas idPlantillaLimpiezaNavigation { get; set; }

		[InverseProperty(nameof(Models.AlertasUsuariosAlarmas.idModuloNavigation))]
		public virtual ICollection<AlertasUsuariosAlarmas> AlertasUsuariosAlarmas { get; set; } = new HashSet<AlertasUsuariosAlarmas>();

		[InverseProperty(nameof(Models.CabOrdenes.ModuloNavigation))]
		public virtual ICollection<CabOrdenes> CabOrdenes { get; set; } = new HashSet<CabOrdenes>();

		[InverseProperty(nameof(Models.Componentes.ModuloNavigation))]
		public virtual ICollection<Componentes> Componentes { get; set; } = new HashSet<Componentes>();

		[InverseProperty(nameof(Models.Destinos.ModuloNavigation))]
		public virtual ICollection<Destinos> Destinos { get; set; } = new HashSet<Destinos>();

		[InverseProperty(nameof(Models.Dosificaciones.IdModuloNavigation))]
		public virtual ICollection<Dosificaciones> Dosificaciones { get; set; } = new HashSet<Dosificaciones>();

		[InverseProperty(nameof(Models.EntradasLineas.idModuloNavigation))]
		public virtual ICollection<EntradasLineas> EntradasLineas { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(Models.FormulaProdModulo.idModuloNavigation))]
		public virtual ICollection<FormulaProdModulo> FormulaProdModulo { get; set; } = new HashSet<FormulaProdModulo>();

		[InverseProperty(nameof(Models.Formulas.ModuloNavigation))]
		public virtual ICollection<Formulas> Formulas { get; set; } = new HashSet<Formulas>();

		[InverseProperty(nameof(Models.GMAO_ParadasConfiguracionModulos.idModuloNavigation))]
		public virtual ICollection<GMAO_ParadasConfiguracionModulos> GMAO_ParadasConfiguracionModulos { get; set; } = new HashSet<GMAO_ParadasConfiguracionModulos>();

		[InverseProperty(nameof(Modulos.ModuloAsociadoOrdenes1Navigation))]
		public virtual ICollection<Modulos> InverseModuloAsociadoOrdenes1Navigation { get; set; } = new HashSet<Modulos>();

		[InverseProperty(nameof(Modulos.ModuloAsociadoOrdenes2Navigation))]
		public virtual ICollection<Modulos> InverseModuloAsociadoOrdenes2Navigation { get; set; } = new HashSet<Modulos>();

		[InverseProperty(nameof(Models.LogMovimientosStocks.ModuloNavigation))]
		public virtual ICollection<LogMovimientosStocks> LogMovimientosStocks { get; set; } = new HashSet<LogMovimientosStocks>();

		[InverseProperty(nameof(Models.Medidor.ModuloNavigation))]
		public virtual ICollection<Medidor> Medidores { get; set; } = new HashSet<Medidor>();

		[InverseProperty(nameof(Models.ModulosAscendentes.AscendenteNavigation))]
		public virtual ICollection<ModulosAscendentes> ModulosAscendentes { get; set; } = new HashSet<ModulosAscendentes>();

		[InverseProperty(nameof(ModulosIncompatibilidades.ModuloBaseNavigation))]
		public virtual ICollection<ModulosIncompatibilidades> ModulosIncompatibilidadesModuloBaseNavigation { get; set; } = new HashSet<ModulosIncompatibilidades>();

		[InverseProperty(nameof(ModulosIncompatibilidades.ModuloRelacionadoNavigation))]
		public virtual ICollection<ModulosIncompatibilidades> ModulosIncompatibilidadesModuloRelacionadoNavigation { get; set; } = new HashSet<ModulosIncompatibilidades>();

		[InverseProperty(nameof(Models.ModulosMotores.Modulo))]
		public virtual ICollection<ModulosMotores> ModulosMotores { get; set; } = new HashSet<ModulosMotores>();

		[InverseProperty(nameof(Models.ModulosTagsScada.ModuloNavigation))]
		public virtual ICollection<ModulosTagsScada> ModulosTagsScada { get; set; } = new HashSet<ModulosTagsScada>();

		[InverseProperty(nameof(Models.NetAlarmas.IdModuloNavigation))]
		public virtual ICollection<NetAlarmas> NetAlarmas { get; set; } = new HashSet<NetAlarmas>();

		[InverseProperty(nameof(Models.NetAlarmasAutomaticas.IdModuloNavigation))]
		public virtual ICollection<NetAlarmasAutomaticas> NetAlarmasAutomaticas { get; set; } = new HashSet<NetAlarmasAutomaticas>();

		[InverseProperty(nameof(Models.OperCabPlantillas.IdModuloNavigation))]
		public virtual ICollection<OperCabPlantillas> OperCabPlantillas { get; set; } = new HashSet<OperCabPlantillas>();

		[InverseProperty(nameof(Models.OperMotoresModulos.IdModuloNavigation))]
		public virtual ICollection<OperMotoresModulos> OperMotoresModulos { get; set; } = new HashSet<OperMotoresModulos>();

		[InverseProperty(nameof(Models.Ordenes.ModuloNavigation))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

		[InverseProperty(nameof(Models.Productos.ModuloNavigation))]
		public virtual ICollection<Productos> Productos { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Models.SalidasLinias.idmoduloNavigation))]
		public virtual ICollection<SalidasLinias> SalidasLinias { get; set; } = new HashSet<SalidasLinias>();

		[InverseProperty(nameof(Models.SesionesModulo.ModuloNavigation))]
		public virtual ICollection<SesionesModulo> SesionesModulo { get; set; } = new HashSet<SesionesModulo>();

		[InverseProperty(nameof(Models.Tags.idModuloNavigation))]
		public virtual ICollection<Tags> Tags { get; set; } = new HashSet<Tags>();

		[InverseProperty(nameof(Models.TiempoLimpieza.Modulo))]
		public virtual ICollection<TiempoLimpieza> TiempoLimpieza { get; set; } = new HashSet<TiempoLimpieza>();

		[InverseProperty(nameof(Models.UsuariosRolesModulos.idModuloNavigation))]
		public virtual ICollection<UsuariosRolesModulos> UsuariosRolesModulos { get; set; } = new HashSet<UsuariosRolesModulos>();

		[InverseProperty(nameof(Models.Variables.ModuloNavigation))]
		public virtual ICollection<Variables> Variables { get; set; } = new HashSet<Variables>();

		[InverseProperty(nameof(Models.VersionTPrevisto.idModuloNavigation))]
		public virtual ICollection<VersionTPrevisto> VersionTPrevisto { get; set; } = new HashSet<VersionTPrevisto>();

	}

}
