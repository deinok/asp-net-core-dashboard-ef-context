using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Medidor
	{

		[Key]
		public int Id { get; set; }

		[Column("Modulo")]
		public int ModuloId { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? Sesion { get; set; }

		public int? Capacidad { get; set; }

		public bool? Automatico { get; set; }

		public int? Tipo { get; set; }

		public int? UnidadParte { get; set; }

		public int? Unidad { get; set; }

		public int? UnidadEnvio { get; set; }

		public float? CantidadMinima { get; set; }

		[StringLength(50)]
		public string Dosificaciones { get; set; }

		[StringLength(50)]
		public string Resultados { get; set; }

		public int? UbicacionesMaximo { get; set; }

		public int? OrigenesMaximo { get; set; }

		public int? ProductosMaximo { get; set; }

		public int? CantidadesMaximo { get; set; }

		public bool? LecturaReal { get; set; }

		public bool? Consecutivo { get; set; }

		public bool? Dinamico { get; set; }

		public bool? Principal { get; set; }

		public int? Decimales { get; set; }

		public int? TipoOrigen { get; set; }

		public bool? Visible { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? SeleccionProducto { get; set; }

		public int? OrigenesParteMaximo { get; set; }

		public bool? RegistroAutomatico { get; set; }

		public int? RegistroPeriodo { get; set; }

		public int? TipoDosificacion { get; set; }

		public int? FamiliaMedidor { get; set; }

		public int? CantidadesParteMaximo { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? RegistroTiempo { get; set; }

		public int? TipoRegularizacion { get; set; }

		public int? Equipo { get; set; }

		public bool? Terminal { get; set; }

		public int? OrdenAFinalizar { get; set; }

		public bool? ControlStock { get; set; }

		[StringLength(50)]
		public string EventoPesadaRegistrada { get; set; }

		[StringLength(50)]
		public string EventoOrdenFinalizada { get; set; }

		public int? IdOrdenActual { get; set; }

		public int? IdCicloActual { get; set; }

		public bool? AutoValidacionLotes { get; set; }

		public bool? BorradoLotesInicioOrden { get; set; }

		public int? IdOrdenAnterior { get; set; }

		public int? IdCicloAnterior { get; set; }

		public int? IdBascula { get; set; }

		[Obsolete]
		public int? OpcConfigId { get; set; }

		[Column("IdPLC")]
		public int IdPlc { get; set; }

		public bool PlcEnabled { get; set; }

		public int? PLCOrdenNumActual { get; set; }

		public int? PLCCicloNumActual { get; set; }

		public int? PLCSecuenciaNumActual { get; set; }

		public int? PLCEstadoActual { get; set; }

		public int? PLCEstadoAlarma { get; set; }

		public int? PLCOrigenIdActual0 { get; set; }

		public int? PLCOrigenIdActual1 { get; set; }

		public int? PLCOrigenIdActual2 { get; set; }

		public int? PLCOrigenIdActual3 { get; set; }

		public int? PLCOrigenIdActual4 { get; set; }

		public int? PLCOrigenIdActual5 { get; set; }

		public int? PLCOrigenIdActual6 { get; set; }

		public int? PLCOrigenIdActual7 { get; set; }

		public int? PLCOrigenIdActual8 { get; set; }

		public int? PLCOrigenIdActual9 { get; set; }

		public int? PLCOrigenIdActual10 { get; set; }

		public int? PLCOrigenIdActual11 { get; set; }

		public int? PLCOrigenIdActual12 { get; set; }

		public int? PLCOrigenIdActual13 { get; set; }

		public int? PLCOrigenIdActual14 { get; set; }

		public int? PLCOrigenIdActual15 { get; set; }

		public int? PLCOrigenIdActual16 { get; set; }

		public int? PLCOrigenIdActual17 { get; set; }

		public int? PLCOrigenIdActual18 { get; set; }

		public int? PLCOrigenIdActual19 { get; set; }

		public int? PLCIndicadoresId0 { get; set; }

		public int? PLCIndicadoresId1 { get; set; }

		public int? PLCIndicadoresId2 { get; set; }

		public int? PLCIndicadoresId3 { get; set; }

		public int? PLCIndicadoresId4 { get; set; }

		public int? PLCIndicadoresId5 { get; set; }

		public int? PLCIndicadoresId6 { get; set; }

		public int? PLCIndicadoresId7 { get; set; }

		public int? PLCIndicadoresId8 { get; set; }

		public int? PLCIndicadoresId9 { get; set; }

		public int? PLCIndicadoresId10 { get; set; }

		public int? PLCIndicadoresId11 { get; set; }

		public int? PLCIndicadoresId12 { get; set; }

		public int? PLCIndicadoresId13 { get; set; }

		public int? PLCIndicadoresId14 { get; set; }

		public int? PLCIndicadoresId15 { get; set; }

		public int? PLCIndicadoresId16 { get; set; }

		public int? PLCIndicadoresId17 { get; set; }

		public int? PLCIndicadoresId18 { get; set; }

		public int? PLCIndicadoresId19 { get; set; }

		public int? ModoAsumido { get; set; }

		public bool? ParticionarDosificacion { get; set; }

		public bool ModoMultidosificacion { get; set; }

		[Column(TypeName = "decimal(15, 5)")]
		public decimal? MinTolerancia { get; set; }

		[Column(TypeName = "decimal(15, 5)")]
		public decimal? MaxTolerancia { get; set; }

		public int? idPlantillaOculta { get; set; }

		public bool? AutoAlarmaFaltaProducto { get; set; }

		public bool? AutoAlarmaFaltaProductoCiclo { get; set; }

		public bool? AutoAlarmaMaxSiloCiclo { get; set; }

		public bool? AutoAlarmaMaxSilo { get; set; }

		public bool? RequiereOperaciones { get; set; }

		public bool? ForzarDosificacionConjunta { get; set; }

		public bool? AsumidoPrincipal { get; set; }

		public bool? VerDosiVariables { get; set; }

		[StringLength(250)]
		public string TextoDosiVariables { get; set; }

		[Obsolete]
		public int? EstadoForzado { get; set; }

		[Obsolete]
		public bool? DisponibleOEE { get; set; }

		[Obsolete]
		public bool? MedirOEE { get; set; }

		public bool? PermitirModoMantenimiento { get; set; }

		public bool RevisarDosiVariable1Ascendente { get; set; }

		public int? IDAlarmaOrigenesFaltaProducto { get; set; }

		public int? IDAlarmaOrigenesFaltaProductoCiclico { get; set; }

		public int? IDAlarmaOrigenesMaximoSilo { get; set; }

		public int? IDAlarmaOrigenesMaximoSiloCiclico { get; set; }

		public int? IDAlarmaOrigenDeshabilitado { get; set; }

		public int? IDAlarmaDestinoDeshabilitado { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		public bool? ForzarConsumidos { get; set; }

		public bool? Obligatorio { get; set; }

		public bool? AutoAlarmaOrigenDeshabilitado { get; set; }

		public bool? AutoAlarmaDestinoDeshabilitado { get; set; }

		public int? PrioridadDosificacion { get; set; }

		[ForeignKey(nameof(FamiliaMedidor))]
		[InverseProperty(nameof(FamiliasMedidor.Medidores))]
		public virtual FamiliasMedidor FamiliaMedidorNavigation { get; set; }

		[ForeignKey(nameof(IdBascula))]
		[InverseProperty(nameof(Bascula.Medidores))]
		public virtual Bascula IdBasculaNavigation { get; set; }

		[ForeignKey(nameof(ModuloId))]
		[InverseProperty(nameof(Modulos.Medidores))]
		public virtual Modulos ModuloNavigation { get; set; }

		[ForeignKey(nameof(idPlantillaOculta))]
		[InverseProperty(nameof(OperCabPlantillas.Medidores))]
		public virtual OperCabPlantillas idPlantillaOcultaNavigation { get; set; }

		[InverseProperty(nameof(Models.Alarmas.MedidorNavigation))]
		public virtual ICollection<Alarmas> Alarmas { get; set; } = new HashSet<Alarmas>();

		[InverseProperty(nameof(Camino.Medidor))]
		public virtual ICollection<Camino> Caminos { get; set; } = new HashSet<Camino>();

		[InverseProperty(nameof(Models.Componentes.MedidorNavigation))]
		public virtual ICollection<Componentes> Componentes { get; set; } = new HashSet<Componentes>();

		[InverseProperty(nameof(Models.Desgloses.Medidor))]
		public virtual ICollection<Desgloses> Desgloses { get; set; } = new HashSet<Desgloses>();

		[InverseProperty(nameof(Models.DestinosMedidores.idMedidorNavigation))]
		public virtual ICollection<DestinosMedidores> DestinosMedidores { get; set; } = new HashSet<DestinosMedidores>();

		[InverseProperty(nameof(Models.Dosificaciones.MedidorNavigation))]
		public virtual ICollection<Dosificaciones> DosificacionesNavigation { get; set; } = new HashSet<Dosificaciones>();

		[InverseProperty(nameof(Models.Indicadores.IdMedidorNavigation))]
		public virtual ICollection<Indicadores> Indicadores { get; set; } = new HashSet<Indicadores>();

		[InverseProperty(nameof(Models.LogMovimientosStocks.MedidorNavigation))]
		public virtual ICollection<LogMovimientosStocks> LogMovimientosStocks { get; set; } = new HashSet<LogMovimientosStocks>();

		[InverseProperty(nameof(Models.MedidoresDosificaciones.idMedidorNavigation))]
		public virtual ICollection<MedidoresDosificaciones> MedidoresDosificaciones { get; set; } = new HashSet<MedidoresDosificaciones>();

		[InverseProperty(nameof(Models.ModulosAscendentes.MedidorNavigation))]
		public virtual ICollection<ModulosAscendentes> ModulosAscendentes { get; set; } = new HashSet<ModulosAscendentes>();

		[InverseProperty(nameof(Models.NetAlarmas.idMedidorNavigation))]
		public virtual ICollection<NetAlarmas> NetAlarmas { get; set; } = new HashSet<NetAlarmas>();

		[InverseProperty(nameof(Models.NetAlarmasAutomaticas.IdMedidorNavigation))]
		public virtual ICollection<NetAlarmasAutomaticas> NetAlarmasAutomaticas { get; set; } = new HashSet<NetAlarmasAutomaticas>();

		[InverseProperty(nameof(OperMotores.IdMedidorNavigation))]
		public virtual ICollection<OperMotores> OperMotoresIdMedidorNavigation { get; set; } = new HashSet<OperMotores>();

		[InverseProperty(nameof(Models.OperMotoresModulos.IdMedidorNavigation))]
		public virtual ICollection<OperMotoresModulos> OperMotoresModulos { get; set; } = new HashSet<OperMotoresModulos>();

		[InverseProperty(nameof(OperMotores.idMedidorForzadoNavigation))]
		public virtual ICollection<OperMotores> OperMotoresidMedidorForzadoNavigation { get; set; } = new HashSet<OperMotores>();

		[InverseProperty(nameof(Models.OperPlantillas.MedidorNavigation))]
		public virtual ICollection<OperPlantillas> OperPlantillas { get; set; } = new HashSet<OperPlantillas>();

		[InverseProperty(nameof(Models.Origenes.MedidorNavigation))]
		public virtual ICollection<Origenes> Origenes { get; set; } = new HashSet<Origenes>();

		[InverseProperty(nameof(Models.Pistolas.IdMedidorNavigation))]
		public virtual ICollection<Pistolas> Pistolas { get; set; } = new HashSet<Pistolas>();

		[InverseProperty(nameof(ProductoMedidorCamino.Medidor))]
		public virtual ICollection<ProductoMedidorCamino> ProductosMedidoresCaminos { get; set; } = new HashSet<ProductoMedidorCamino>();

		[InverseProperty(nameof(Models.Productos.MedidorNavigation))]
		public virtual ICollection<Productos> Productos { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Models.Resultados.MedidorNavigation))]
		public virtual ICollection<Resultados> ResultadosNavigation { get; set; } = new HashSet<Resultados>();

		[InverseProperty(nameof(Models.TempControlesMedidores.idMedidorNavigation))]
		public virtual ICollection<TempControlesMedidores> TempControlesMedidores { get; set; } = new HashSet<TempControlesMedidores>();

		[InverseProperty(nameof(Models.UbisMedsAfino.idMedidorNavigation))]
		public virtual ICollection<UbisMedsAfino> UbisMedsAfino { get; set; } = new HashSet<UbisMedsAfino>();

	}

}
