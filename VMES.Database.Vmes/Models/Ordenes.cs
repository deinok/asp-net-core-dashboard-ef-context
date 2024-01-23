using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Ordenes
	{

		public int? IdCab { get; set; }

		public int Serie { get; set; }

		[Key]
		public int Id { get; set; }

		[StringLength(250)]
		public string Nombre { get; set; }

		public int? Departamento { get; set; }

		public int? Modulo { get; set; }

		public float? Cantidad { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public OrdenStatus? Estado { get; set; }

		public float? Servida { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Inicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fin { get; set; }

		public int? Formula { get; set; }

		public int? NumeroCiclos { get; set; }

		public int? ContadorCiclos { get; set; }

		public bool Exportado { get; set; }

		[StringLength(30)]
		public string LoteNombre { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FormulaFecha { get; set; }

		public int? ProductoDestino { get; set; }

		public int? LoteDestino { get; set; }

		public int? TipoFinalizacion { get; set; }

		public int? Tiempo { get; set; }

		public float? Velocidad { get; set; }

		public float? Ganancia { get; set; }

		public int? GananciaUnidad { get; set; }

		public int? EnvaseOrigen { get; set; }

		public int? BultosOrigen { get; set; }

		public bool? Modificada { get; set; }

		public int? Receta { get; set; }

		public int? Medicacion { get; set; }

		public int? Version { get; set; }

		public bool? Confirmada { get; set; }

		public int? SerieSalida { get; set; }

		public int? Salida { get; set; }

		public int? LineaSalida { get; set; }

		public int? SerieEntrada { get; set; }

		public int? Entrada { get; set; }

		public int? LineaEntrada { get; set; }

		public int? SeriePlanificacion { get; set; }

		public int? Planificacion { get; set; }

		public bool Importado { get; set; }

		[Obsolete("Use VentaLineaId")]
		public int? LineaVenta { get; set; }

		public int? OrdenAscendiente { get; set; }

		public int? SerieOrdenAscendiente { get; set; }

		public int? SerieOrdenRelacionada { get; set; }

		public int? OrdenRelacionada { get; set; }

		public bool? Medicada { get; set; }

		public int? idChofer { get; set; }

		public int? idTarjeta { get; set; }

		public bool? Editada { get; set; }

		public int? idOld { get; set; }

		public int? SerieOld { get; set; }

		public bool? IniciarOrden { get; set; }

		public int? OrdenEnvioPLC { get; set; }

		public int? Caminos { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaEnvioAPlc { get; set; }

		public bool? Bloqueada { get; set; }

		public int? ViajeSalida { get; set; }

		public int? SerieViajeSalida { get; set; }

		[StringLength(50)]
		public string NombreChofer { get; set; }

		[StringLength(15)]
		public string Matricula { get; set; }

		public float ModuloVariables0 { get; set; }

		public float ModuloVariables1 { get; set; }

		public float ModuloVariables2 { get; set; }

		public float ModuloVariables3 { get; set; }

		public float ModuloVariables4 { get; set; }

		public float ModuloVariables5 { get; set; }

		public float ModuloVariables6 { get; set; }

		public float ModuloVariables7 { get; set; }

		public float ModuloVariables8 { get; set; }

		public float ModuloVariables9 { get; set; }

		[StringLength(15)]
		public string Remolque { get; set; }

		public int? IdVehiculo { get; set; }

		[StringLength(50)]
		public string RefERP { get; set; }

		[StringLength(250)]
		public string SegundosCicloTeorico { get; set; }

		public bool? DatosOptimizados { get; set; }

		public bool? IncompatComprobada { get; set; }

		public bool? IncompatFlexible { get; set; }

		public bool? IncompatEstricta { get; set; }

		[StringLength(250)]
		public string IncompatInfo { get; set; }

		public int? TiempoPrevistoCicloSegs { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicioPrevista { get; set; }

		public bool? NecesitaOrigen { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fexportado { get; set; }

		[StringLength(250)]
		public string ExportError { get; set; }

		public int? TotalCiclosReal { get; set; }

		[StringLength(20)]
		public string RefERP1 { get; set; }

		[StringLength(20)]
		public string RefERP2 { get; set; }

		[StringLength(20)]
		public string RefERP3 { get; set; }

		public bool IgnorarConsumidos { get; set; }

		public bool IgnorarProducidos { get; set; }

		public int TipoAutoRespuestaDestino { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal EfectiveJouls { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal TotalJouls { get; set; }

		public bool? Validada { get; set; }

		public int? VentaLineaId { get; set; }

		[ForeignKey(nameof(Departamento))]
		[InverseProperty(nameof(Departamentos.Ordenes))]
		public virtual Departamentos DepartamentoNavigation { get; set; }

		[ForeignKey(nameof(Entrada))]
		[InverseProperty(nameof(Entradas.Ordenes))]
		public virtual Entradas EntradaNavigation { get; set; }

		[ForeignKey(nameof(EnvaseOrigen))]
		[InverseProperty(nameof(Envases.Ordenes))]
		public virtual Envases EnvaseOrigenNavigation { get; set; }

		[ForeignKey(nameof(Formula))]
		[InverseProperty(nameof(Formulas.Ordenes))]
		public virtual Formulas FormulaNavigation { get; set; }

		[ForeignKey(nameof(IdCab))]
		[InverseProperty(nameof(CabOrdenes.Ordenes))]
		public virtual CabOrdenes IdCabNavigation { get; set; }

		[ForeignKey(nameof(IdVehiculo))]
		[InverseProperty(nameof(Vehiculos.Ordenes))]
		public virtual Vehiculos IdVehiculoNavigation { get; set; }

		[ForeignKey(nameof(LineaEntrada))]
		[InverseProperty(nameof(EntradasLineas.Ordenes))]
		public virtual EntradasLineas LineaEntradaNavigation { get; set; }

		[ForeignKey(nameof(LineaSalida))]
		[InverseProperty(nameof(SalidasLinias.Ordenes))]
		public virtual SalidasLinias LineaSalidaNavigation { get; set; }

		[ForeignKey(nameof(LoteDestino))]
		[InverseProperty(nameof(Lotes.Ordenes))]
		public virtual Lotes LoteDestinoNavigation { get; set; }

		[ForeignKey(nameof(Medicacion))]
		[InverseProperty(nameof(Medicaciones.Ordenes))]
		public virtual Medicaciones MedicacionNavigation { get; set; }

		[ForeignKey(nameof(Modulo))]
		[InverseProperty(nameof(Models.Modulos.Ordenes))]
		public virtual Modulos ModuloNavigation { get; set; }

		[ForeignKey(nameof(ProductoDestino))]
		[InverseProperty(nameof(Productos.Ordenes))]
		public virtual Productos ProductoDestinoNavigation { get; set; }

		[ForeignKey(nameof(Version))]
		[InverseProperty(nameof(Versiones.Ordenes))]
		public virtual Versiones VersionNavigation { get; set; }

		[ForeignKey(nameof(ViajeSalida))]
		[InverseProperty(nameof(SalidasViajes.Ordenes))]
		public virtual SalidasViajes ViajeSalidaNavigation { get; set; }

		[ForeignKey(nameof(idChofer))]
		[InverseProperty(nameof(Choferes.Ordenes))]
		public virtual Choferes idChoferNavigation { get; set; }

		[ForeignKey(nameof(idTarjeta))]
		[InverseProperty(nameof(Models.Tarjetas.Ordenes))]
		public virtual Tarjetas idTarjetaNavigation { get; set; }

		[InverseProperty(nameof(Models.OrdenesDatosExtra.idNavigation))]
		public virtual OrdenesDatosExtra OrdenesDatosExtra { get; set; }

		[ForeignKey(nameof(VentaLineaId))]
		[InverseProperty(nameof(VentasLinias.Ordenes))]
		public virtual VentasLinias VentaLinea { get; set; }

		[InverseProperty(nameof(Models.Aditivos.OrdenNavigation))]
		public virtual ICollection<Aditivos> Aditivos { get; set; } = new HashSet<Aditivos>();

		[InverseProperty(nameof(Models.CertificadoDesinfeccion.idOrdenNavigation))]
		public virtual ICollection<CertificadoDesinfeccion> CertificadoDesinfeccion { get; set; } = new HashSet<CertificadoDesinfeccion>();

		[InverseProperty(nameof(Models.Desgloses.OrdenNavigation))]
		public virtual ICollection<Desgloses> Desgloses { get; set; } = new HashSet<Desgloses>();

		[InverseProperty(nameof(Models.Disposiciones.OrdenNavigation))]
		public virtual ICollection<Disposiciones> Disposiciones { get; set; } = new HashSet<Disposiciones>();

		[InverseProperty(nameof(Models.Dosificaciones.OrdenNavigation))]
		public virtual ICollection<Dosificaciones> Dosificaciones { get; set; } = new HashSet<Dosificaciones>();

		[InverseProperty(nameof(Models.LogMovimientosStocks.idOrdenNavigation))]
		public virtual ICollection<LogMovimientosStocks> LogMovimientosStocks { get; set; } = new HashSet<LogMovimientosStocks>();

		[InverseProperty(nameof(Models.Modulos.PLCOrdenNumActualNavigation))]
		public virtual ICollection<Modulos> Modulos { get; set; } = new HashSet<Modulos>();

		[InverseProperty(nameof(Models.NetAlarmas.idOrdenNavigation))]
		public virtual ICollection<NetAlarmas> NetAlarmas { get; set; } = new HashSet<NetAlarmas>();

		[InverseProperty(nameof(Models.NetAlarmasAutomaticasOrdenUbicaciones.IdOrdenNavigation))]
		public virtual ICollection<NetAlarmasAutomaticasOrdenUbicaciones> NetAlarmasAutomaticasOrdenUbicaciones { get; set; } = new HashSet<NetAlarmasAutomaticasOrdenUbicaciones>();

		[InverseProperty(nameof(OrdenesAutoInicio.idOrdenNavigation))]
		public virtual ICollection<OrdenesAutoInicio> OrdenesAutoInicioidOrdenNavigation { get; set; } = new HashSet<OrdenesAutoInicio>();

		[InverseProperty(nameof(OrdenesAutoInicio.idOrdenObjetivoNavigation))]
		public virtual ICollection<OrdenesAutoInicio> OrdenesAutoInicioidOrdenObjetivoNavigation { get; set; } = new HashSet<OrdenesAutoInicio>();

		[InverseProperty(nameof(OrdenesRelacion.idOrdenHijoNavigation))]
		public virtual ICollection<OrdenesRelacion> OrdenesRelacionidOrdenHijoNavigation { get; set; } = new HashSet<OrdenesRelacion>();

		[InverseProperty(nameof(OrdenesRelacion.idOrdenPadreNavigation))]
		public virtual ICollection<OrdenesRelacion> OrdenesRelacionidOrdenPadreNavigation { get; set; } = new HashSet<OrdenesRelacion>();

		[InverseProperty(nameof(Models.OrdenesTransicionEstadosHistory.Orden))]
		public virtual ICollection<OrdenesTransicionEstadosHistory> OrdenesTransicionEstadosHistory { get; set; } = new HashSet<OrdenesTransicionEstadosHistory>();

		[InverseProperty(nameof(Models.Resultados.OrdenNavigation))]
		public virtual ICollection<Resultados> Resultados { get; set; } = new HashSet<Resultados>();

		[InverseProperty(nameof(SolicitudAjusteCaudal.Orden))]
		public virtual ICollection<SolicitudAjusteCaudal> SolicitudesAjusteCaudal { get; set; }

		[InverseProperty(nameof(Models.StocksReserva.idOrdenNavigation))]
		public virtual ICollection<StocksReserva> StocksReserva { get; set; } = new HashSet<StocksReserva>();

		[InverseProperty(nameof(Models.Tarjetas.OrdenActual))]
		public virtual ICollection<Tarjetas> Tarjetas { get; set; } = new HashSet<Tarjetas>();

		[InverseProperty(nameof(Models.Valores.OrdenNavigation))]
		public virtual ICollection<Valores> Valores { get; set; } = new HashSet<Valores>();

	}

}
