using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Ubicaciones
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? Departamento { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		[Obsolete]
		public int? Tipo { get; set; }

		public bool? CargaManual { get; set; }

		public bool? DescargaManual { get; set; }

		public float? Capacidad { get; set; }

		public int? Unidad { get; set; }

		public bool? Individual { get; set; }

		public int? Producto { get; set; }

		public int? Formato { get; set; }

		public int? Prioridad { get; set; }

		public float? Stock { get; set; }

		public bool? ControlStock { get; set; }

		public bool? AvisosActivo { get; set; }

		public int? AvisosEquipo { get; set; }

		public bool? Visible { get; set; }

		public bool? Configurable { get; set; }

		public int? PosicionX { get; set; }

		public int? PosicionY { get; set; }

		[StringLength(50)]
		public string Minima { get; set; }

		[StringLength(50)]
		public string Maxima { get; set; }

		[StringLength(50)]
		public string Nivel { get; set; }

		public int? Lote { get; set; }

		public bool? Entradas { get; set; }

		public bool? Salidas { get; set; }

		public bool? Duplicado { get; set; }

		public bool? Desasignable { get; set; }

		public int? Asociacion { get; set; }

		public bool? Premezclas { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public bool? Bloqueado { get; set; }

		public float? StockMinimo { get; set; }

		public float? NivelMinimo { get; set; }

		public float? NivelMaximo { get; set; }

		public int? AvisosSesion { get; set; }

		public int? Ordenacion { get; set; }

		public int? Color { get; set; }

		public bool? AsociacionObligatoria { get; set; }

		public int? idOld { get; set; }

		public int? MaPGrupo { get; set; }

		public int? MaPTiempoLimpiezaLlenado { get; set; }

		[Column("MaPTipo")]
		public UbicacionType? Type { get; set; }

		public bool? MaPNivelMaximoActivo { get; set; }

		public bool? MaPNivelMinimoActivo { get; set; }

		public bool? MaPNivelMedioActivo { get; set; }

		public bool? MaPNivelPorcentajeActivo { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? MaPVolumenSilo { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? MaPCaudalMaxEstLlenando { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? MaPCaudalMaxEstVaciando { get; set; }

		public bool? PaMHabilitadoLlenado { get; set; }

		public bool? PaMHabilitadoVaciado { get; set; }

		public bool? PaMNivelMaximo { get; set; }

		public bool? PaMNivelMinimo { get; set; }

		public bool? PaMNivelMedio { get; set; }

		public bool? PaMForzarLleno { get; set; }

		public bool? PaMForzarVacio { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PaMNivelPorcentaje { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PaMTemperatura { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PaMPresion { get; set; }

		public int? PaMVariable1 { get; set; }

		public int? PaMVariable2 { get; set; }

		public int? PaMVariable3 { get; set; }

		public int? PaMVariable0 { get; set; }

		public int? MaPVariable0 { get; set; }

		public int? MaPVariable1 { get; set; }

		public int? MaPVariable2 { get; set; }

		public int? MaPVariable3 { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? Afino { get; set; }

		public int? ConVibrador { get; set; }

		public int? VelocidadLenta { get; set; }

		public int? VelocidadRapida { get; set; }

		[Column(TypeName = "numeric(18, 12)")]
		public decimal? PaMCola { get; set; }

		public int? PLCPosicion { get; set; }

		public bool? ModoBigBag { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? DosificacionMaxima { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? AfinoMaximo { get; set; }

		public bool? EnviarEnPorcentaje { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? AfinoMultiDosi { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? AfinoMaxMultiDosi { get; set; }

		public bool? PermitirAsociar { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? AfinoMinimo { get; set; }

		public int? MaPTiempoRegistros { get; set; }

		public bool? MinimoSiloResetUbi { get; set; }

		public bool? NoNegativos { get; set; }

		public bool? MezcladoLotes { get; set; }

		[Column(TypeName = "decimal(15, 3)")]
		public decimal? MezcladoMinimoDisolucion { get; set; }

		public int? MezcladoDiasMinimoFCaducidad { get; set; }

		public bool? TipoPR { get; set; }

		[Column(TypeName = "decimal(8, 6)")]
		public decimal? ColaPropuesta { get; set; }

		[Column(TypeName = "decimal(18, 5)")]
		[Obsolete("ELIMINAR TAMBIEN LA FUNCION DE SQL A LA QUE ESTA UNIDA")]
		public decimal? StockActual { get; set; }

		[Obsolete]
		[StringLength(50)]
		public string LoteActual { get; set; }

		[Column(TypeName = "numeric(18, 12)")]
		public decimal? PaMColaMulti { get; set; }

		[Obsolete]
		public int? IdOpc1 { get; set; }

		[Obsolete]
		public int? IdOpc2 { get; set; }

		[Obsolete]
		public int? IdOpc3 { get; set; }

		[Obsolete]
		public int? IdOpc4 { get; set; }

		[Obsolete]
		public int? PosicionPLC1 { get; set; }

		[Obsolete]
		public int? PosicionPLC2 { get; set; }

		[Obsolete]
		public int? PosicionPLC3 { get; set; }

		[Obsolete]
		public int? PosicionPLC4 { get; set; }

		public byte? ColorFondoAlfa { get; set; }

		public byte? ColorFondoRojo { get; set; }

		public byte? ColorFondoVerde { get; set; }

		public byte? ColorFondoAzul { get; set; }

		public bool? DiferenciaTraspasable { get; set; }

		[Obsolete]
		public int? OpcConfigId { get; set; }

		[StringLength(20)]
		public string Referencia2 { get; set; }

		public bool? NoAsignable { get; set; }

		public bool? Bloqueable { get; set; }

		public bool? SincronizarERP { get; set; }

		[ForeignKey(nameof(Asociacion))]
		[InverseProperty(nameof(Ubicaciones.InverseAsociacionNavigation))]
		public virtual Ubicaciones AsociacionNavigation { get; set; }

		[ForeignKey(nameof(AvisosSesion))]
		[InverseProperty(nameof(Sesiones.Ubicaciones))]
		public virtual Sesiones AvisosSesionNavigation { get; set; }

		[ForeignKey(nameof(Departamento))]
		[InverseProperty(nameof(Departamentos.Ubicaciones))]
		public virtual Departamentos DepartamentoNavigation { get; set; }

		[ForeignKey(nameof(Formato))]
		[InverseProperty(nameof(Formatos.Ubicaciones))]
		public virtual Formatos FormatoNavigation { get; set; }

		[ForeignKey(nameof(Lote))]
		[InverseProperty(nameof(Lotes.Ubicaciones))]
		public virtual Lotes LoteNavigation { get; set; }

		[ForeignKey(nameof(OpcConfigId))]
		[InverseProperty(nameof(Models.OpcConfig.Ubicaciones))]
		public virtual OpcConfig OpcConfig { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Models.Productos.Ubicaciones))]
		public virtual Productos ProductoNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.Ubicaciones))]
		public virtual Unidades UnidadNavigation { get; set; }

		[InverseProperty(nameof(Models.Aditivos.UbicacionNavigation))]
		public virtual ICollection<Aditivos> Aditivos { get; set; } = new HashSet<Aditivos>();

		[InverseProperty(nameof(Models.BufferERPSolicitudRegularizacion.IdUbicacionNavigation))]
		public virtual ICollection<BufferERPSolicitudRegularizacion> BufferERPSolicitudRegularizacion { get; set; } = new HashSet<BufferERPSolicitudRegularizacion>();

		[InverseProperty(nameof(Models.BufferERPSolicitudTraspaso.Destino))]
		public virtual ICollection<BufferERPSolicitudTraspaso> BufferERPSolicitudTraspasoDestinos { get; set; } = new HashSet<BufferERPSolicitudTraspaso>();

		[InverseProperty(nameof(Models.BufferERPSolicitudTraspaso.Origen))]
		public virtual ICollection<BufferERPSolicitudTraspaso> BufferERPSolicitudTraspasoOrigenes { get; set; } = new HashSet<BufferERPSolicitudTraspaso>();

		[InverseProperty(nameof(Models.CabOrdenes.UbicacionDestinoNavigation))]
		public virtual ICollection<CabOrdenes> CabOrdenes { get; set; } = new HashSet<CabOrdenes>();

		[InverseProperty(nameof(Caudal.Ubicacion))]
		public virtual ICollection<Caudal> Caudales { get; set; } = new HashSet<Caudal>();

		[InverseProperty(nameof(Models.Desgloses.UbicacionNavigation))]
		public virtual ICollection<Desgloses> Desgloses { get; set; } = new HashSet<Desgloses>();

		[InverseProperty(nameof(Models.Destinos.UbicacionNavigation))]
		public virtual ICollection<Destinos> Destinos { get; set; } = new HashSet<Destinos>();

		[InverseProperty(nameof(Models.Disposiciones.UbicacionNavigation))]
		public virtual ICollection<Disposiciones> Disposiciones { get; set; } = new HashSet<Disposiciones>();

		[InverseProperty(nameof(Models.Dosificaciones.UbicacionNavigation))]
		public virtual ICollection<Dosificaciones> Dosificaciones { get; set; } = new HashSet<Dosificaciones>();

		[InverseProperty(nameof(Models.EnlaceERPAsigUbi.IdUbicacionNavigation))]
		public virtual ICollection<EnlaceERPAsigUbi> EnlaceERPAsigUbi { get; set; } = new HashSet<EnlaceERPAsigUbi>();

		[InverseProperty(nameof(EntradasLineas.Destino1Navigation))]
		public virtual ICollection<EntradasLineas> EntradasLineasDestino1Navigation { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(EntradasLineas.Destino2Navigation))]
		public virtual ICollection<EntradasLineas> EntradasLineasDestino2Navigation { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(EntradasLineas.Destino3Navigation))]
		public virtual ICollection<EntradasLineas> EntradasLineasDestino3Navigation { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(EntradasLineas.Destino4Navigation))]
		public virtual ICollection<EntradasLineas> EntradasLineasDestino4Navigation { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(EntradasLineas.Origen1Navigation))]
		public virtual ICollection<EntradasLineas> EntradasLineasOrigen1Navigation { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(EntradasLineas.Origen2Navigation))]
		public virtual ICollection<EntradasLineas> EntradasLineasOrigen2Navigation { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(EntradasLineas.Origen3Navigation))]
		public virtual ICollection<EntradasLineas> EntradasLineasOrigen3Navigation { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(EntradasLineas.Origen4Navigation))]
		public virtual ICollection<EntradasLineas> EntradasLineasOrigen4Navigation { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(Models.Existencias.UbicacionNavigation))]
		public virtual ICollection<Existencias> Existencias { get; set; } = new HashSet<Existencias>();

		[InverseProperty(nameof(Models.FormulaProdModulo.idUbicacionNavigation))]
		public virtual ICollection<FormulaProdModulo> FormulaProdModulo { get; set; } = new HashSet<FormulaProdModulo>();

		[InverseProperty(nameof(Ubicaciones.AsociacionNavigation))]
		public virtual ICollection<Ubicaciones> InverseAsociacionNavigation { get; set; } = new HashSet<Ubicaciones>();

		[InverseProperty(nameof(Models.LogMovimientosStocks.IdUbicacionNavigation))]
		public virtual ICollection<LogMovimientosStocks> LogMovimientosStocks { get; set; } = new HashSet<LogMovimientosStocks>();

		[InverseProperty(nameof(Models.MultiDosificaciones.idUbicacionNavigation))]
		public virtual ICollection<MultiDosificaciones> MultiDosificaciones { get; set; } = new HashSet<MultiDosificaciones>();

		[InverseProperty(nameof(Models.NetAlarmasAutomaticas.IdUbicacionNavigation))]
		public virtual ICollection<NetAlarmasAutomaticas> NetAlarmasAutomaticas { get; set; } = new HashSet<NetAlarmasAutomaticas>();

		[InverseProperty(nameof(Models.NetAlarmasAutomaticasOrdenUbicaciones.IdUbicacionNavigation))]
		public virtual ICollection<NetAlarmasAutomaticasOrdenUbicaciones> NetAlarmasAutomaticasOrdenUbicaciones { get; set; } = new HashSet<NetAlarmasAutomaticasOrdenUbicaciones>();

		[InverseProperty(nameof(NetAlarmas.IdDestinoNavigation))]
		public virtual ICollection<NetAlarmas> NetAlarmasIdDestinoNavigation { get; set; } = new HashSet<NetAlarmas>();

		[InverseProperty(nameof(NetAlarmas.IdDestinoPropuestoNavigation))]
		public virtual ICollection<NetAlarmas> NetAlarmasIdDestinoPropuestoNavigation { get; set; } = new HashSet<NetAlarmas>();

		[InverseProperty(nameof(NetAlarmas.IdOrigenNavigation))]
		public virtual ICollection<NetAlarmas> NetAlarmasIdOrigenNavigation { get; set; } = new HashSet<NetAlarmas>();

		[InverseProperty(nameof(NetAlarmas.IdOrigenPropuestoNavigation))]
		public virtual ICollection<NetAlarmas> NetAlarmasIdOrigenPropuestoNavigation { get; set; } = new HashSet<NetAlarmas>();

		[InverseProperty(nameof(NetAlarmas.idUbicacionNavigation))]
		public virtual ICollection<NetAlarmas> NetAlarmasidUbicacionNavigation { get; set; } = new HashSet<NetAlarmas>();

		[InverseProperty(nameof(Models.OperPlantillas.IdUbicacionNavigation))]
		public virtual ICollection<OperPlantillas> OperPlantillas { get; set; } = new HashSet<OperPlantillas>();

		[InverseProperty(nameof(Models.Origenes.UbicacionNavigation))]
		public virtual ICollection<Origenes> Origenes { get; set; } = new HashSet<Origenes>();

		[InverseProperty(nameof(Models.Productos.DestinoDefectoNavigation))]
		public virtual ICollection<Productos> Productos { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Models.Regularizaciones.UbicacionNavigation))]
		public virtual ICollection<Regularizaciones> Regularizaciones { get; set; } = new HashSet<Regularizaciones>();

		[InverseProperty(nameof(Models.Resultados.UbicacionNavigation))]
		public virtual ICollection<Resultados> Resultados { get; set; } = new HashSet<Resultados>();

		[InverseProperty(nameof(Models.SalidasLiniasMedicaciones.idOrigenNavigation))]
		public virtual ICollection<SalidasLiniasMedicaciones> SalidasLiniasMedicaciones { get; set; } = new HashSet<SalidasLiniasMedicaciones>();

		[InverseProperty(nameof(SolicitudAjusteCaudal.Ubicacion))]
		public virtual ICollection<SolicitudAjusteCaudal> SolicitudesAjusteCaudal { get; set; } = new HashSet<SolicitudAjusteCaudal>();

		[InverseProperty(nameof(SalidasLinias.Origen1Navigation))]
		public virtual ICollection<SalidasLinias> SalidasLiniasOrigen1Navigation { get; set; } = new HashSet<SalidasLinias>();

		[InverseProperty(nameof(SalidasLinias.Origen2Navigation))]
		public virtual ICollection<SalidasLinias> SalidasLiniasOrigen2Navigation { get; set; } = new HashSet<SalidasLinias>();

		[InverseProperty(nameof(SalidasLinias.Origen3Navigation))]
		public virtual ICollection<SalidasLinias> SalidasLiniasOrigen3Navigation { get; set; } = new HashSet<SalidasLinias>();

		[InverseProperty(nameof(SalidasLinias.Origen4Navigation))]
		public virtual ICollection<SalidasLinias> SalidasLiniasOrigen4Navigation { get; set; } = new HashSet<SalidasLinias>();

		[InverseProperty(nameof(Models.Stocks.UbicacionNavigation))]
		public virtual ICollection<Stocks> Stocks { get; set; } = new HashSet<Stocks>();

		[InverseProperty(nameof(Models.StocksReserva.idUbicacionNavigation))]
		public virtual ICollection<StocksReserva> StocksReserva { get; set; } = new HashSet<StocksReserva>();

		[InverseProperty(nameof(Models.Tags.UbicacionNavigation))]
		public virtual ICollection<Tags> Tags { get; set; } = new HashSet<Tags>();

		[InverseProperty(nameof(Models.TiempoLimpieza.Ubicacion))]
		public virtual ICollection<TiempoLimpieza> TiempoLimpieza { get; set; } = new HashSet<TiempoLimpieza>();

		[InverseProperty(nameof(UbicacionesAsociadas.idUbicacion1Navigation))]
		public virtual ICollection<UbicacionesAsociadas> UbicacionesAsociadasidUbicacion1Navigation { get; set; } = new HashSet<UbicacionesAsociadas>();

		[InverseProperty(nameof(UbicacionesAsociadas.idUbicacion2Navigation))]
		public virtual ICollection<UbicacionesAsociadas> UbicacionesAsociadasidUbicacion2Navigation { get; set; } = new HashSet<UbicacionesAsociadas>();

		[InverseProperty(nameof(Models.UbicacionesOpcConfig.Ubicacion))]
		public virtual ICollection<UbicacionesOpcConfig> UbicacionesOpcConfig { get; set; } = new HashSet<UbicacionesOpcConfig>();

		[InverseProperty(nameof(Models.UbisMedsAfino.idUbicacionNavigation))]
		public virtual ICollection<UbisMedsAfino> UbisMedsAfino { get; set; } = new HashSet<UbisMedsAfino>();

	}

}
