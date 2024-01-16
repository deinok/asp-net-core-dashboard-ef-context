using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Bascula
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? Puerto { get; set; }

		[StringLength(20)]
		public string Configuracion { get; set; }

		public bool? RTS { get; set; }

		[StringLength(50)]
		public string Comando { get; set; }

		[StringLength(50)]
		public string Respuesta { get; set; }

		public int? Periodo { get; set; }

		public int? InicioTrama { get; set; }

		public int? FinTrama { get; set; }

		public int? NuloTrama { get; set; }

		public int? Equipo { get; set; }

		public int? Tag { get; set; }

		public bool? Entradas { get; set; }

		public bool? Salidas { get; set; }

		public float? Minimo { get; set; }

		public int? Captura { get; set; }

		public bool? Visible { get; set; }

		public int? ControlFlujo { get; set; }

		public int? PeriodoVisible { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? Sesion { get; set; }

		[StringLength(50)]
		public string CantidadOpc { get; set; }

		public bool? LecturaNetos { get; set; }

		[StringLength(50)]
		public string ValidadoServidaOpc { get; set; }

		[StringLength(50)]
		public string ValidarServidaOpc { get; set; }

		[StringLength(50)]
		public string ServidaOpc { get; set; }

		[StringLength(20)]
		public string IP { get; set; }

		[Column("Tipo")]
		public BasculaType Type { get; set; }

		[Column(TypeName = "numeric(8, 2)")]
		public decimal? ToleranciaSuperior { get; set; }

		[Column(TypeName = "numeric(8, 2)")]
		public decimal? ToleranciaInferior { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCBCapacidadMaxima { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCBPesoMinBasculaVacia { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCBLimSuperiorCorrColas { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCBLimInferiorCorrColas { get; set; }

		public int? PLCBTiempoMaxDescarga { get; set; }

		public int? PLCBTiempoMaxEstable { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCBValorIncrementoMin { get; set; }

		public int? PLCBTiempoMaxAdicion { get; set; }

		public int? PLCBTiempoMaxIncrementos { get; set; }

		public int? PLCBPorcentCorrColas { get; set; }

		public int? PLCBModoVaciado { get; set; }

		public int? PLCBTipoBascula { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCBPar1 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCBPar2 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCBPar3 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCBPar4 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCBPar5 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCCCaudalMaximo { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCCPulsosKg { get; set; }

		public int? PLCCTipoContaje { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCCValorMinCaudal { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCCValorMaxCaudal { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCCPorcentCorrColas { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCCLimSuperiorCorrColas { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCCLimInferiorCorrColas { get; set; }

		public int? PLCCTiempoMaxIncrementos { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCCValorIncrementoMin { get; set; }

		public int? PLCCTiempoMaxAdicion { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCCPar1 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCCPar2 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCCPar3 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCCPar4 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCCPar5 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCOVMinEscalaIng { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCOVMaxEscalaIng { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCOVMinLogico { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCOVMaxLogico { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCOPar1 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCOPar2 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCOPar3 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCOPar4 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCOPar5 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCOPar6 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCOPar7 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCOPar8 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCOPar9 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCOPar10 { get; set; }

		public int? PLCITipoIndicador { get; set; }

		public int? PLCIModoIndicacion { get; set; }

		public int? PLCINumSerie { get; set; }

		public int? PLCIVersion { get; set; }

		public int? PLCIModelo { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCIValorActual { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCIValorActual2 { get; set; }

		public int? PLCINumDecimales { get; set; }

		public int? PLCINumDecimales2 { get; set; }

		public int? PLCIEstadoActual { get; set; }

		public int? PLCIConFallos { get; set; }

		public int? PLCIDatosAdicionales0 { get; set; }

		public int? PLCIDatosAdicionales1 { get; set; }

		public int? PLCIDatosAdicionales2 { get; set; }

		[StringLength(50)]
		public string PLCITextoAdicional { get; set; }

		[StringLength(50)]
		public string PLCITextoAdicional2 { get; set; }

		public bool? EnviarDatosAPLC { get; set; }

		[Column("PosicionPLC")]
		public int IdPlc { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCBPesoMaxAcumulado { get; set; }

		public int? PLCBTiempoRetardoCiclo1 { get; set; }

		public int? PLCBTiempoRestablecerPerturbacion { get; set; }

		public int? PLCBTiempoMinDescarga { get; set; }

		public int? PLCBTiempoMaxRespuestaPenko { get; set; }

		public int? PLCBModoPesado { get; set; }

		public int? PLCBParticionarPesada { get; set; }

		public bool? PLCBDesactivarALTodas { get; set; }

		public bool? PLCBDesactivarALAcumulados { get; set; }

		public bool? PLCBDesactivarALFaltaProducto { get; set; }

		public bool? PLCBDesactivarALBaNoVacia { get; set; }

		public bool? PLCBDesactivarALTolerancia { get; set; }

		public bool? PLCBDesactivarALTimDescarga { get; set; }

		public bool? PLCBDesactivarALTimMaxDosiAuto { get; set; }

		public bool? PLCBDesactivarALTimMaxDosiMan { get; set; }

		public bool? PLCBDesactivarALEstabilidad { get; set; }

		public bool? PLCCDesactivarALFaltaProducto { get; set; }

		public bool? PLCCDesactivarALTimMaxAdicion { get; set; }

		public bool? PLCODesactivarAlarmas { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? PesoMinimoAviso { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? PesoMaximoAviso { get; set; }

		public bool? Recipiente { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? PesoRecipiente { get; set; }

		public bool? LeerEnPLC { get; set; }

		public bool? GrabarEnPLC { get; set; }

		public bool? PLCBMultidosiReady { get; set; }

		public bool? PLCBDesactivarALProceso { get; set; }

		public bool? PLCBDesactivarALVisorPenko { get; set; }

		public int? PLCCNumerodeOrden { get; set; }

		public bool? PLCCPermitirContajeEnManual { get; set; }

		public bool? PLCCPermitirTestEnAuto { get; set; }

		public bool? PLCCSecuenciarLiquido { get; set; }

		public bool? PLCCInKgOL { get; set; }

		public bool? PLCCAutocalibracionAtivada { get; set; }

		public bool? PLCCDesactivarTodasAlarmas { get; set; }

		public bool? PLCCModoContaje { get; set; }

		public int? PLCBNumMaxCiclos { get; set; }

		public bool? PLCBOmitirToleranciaPrecisionZero { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCBToleranciaPrecisionZero { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FLectura { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaLecturaPeso { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? LecturaPeso { get; set; }

		[StringLength(20)]
		public string PerlePuerto { get; set; }

		[StringLength(20)]
		public string PerleVelocidad { get; set; }

		[StringLength(20)]
		public string PerleBitsDatos { get; set; }

		[StringLength(20)]
		public string PerleBitsParada { get; set; }

		[StringLength(20)]
		public string PerleParidad { get; set; }

		[StringLength(20)]
		public string PerleHandShake { get; set; }

		public bool? PerleDTR { get; set; }

		public bool? PerleRTS { get; set; }

		public int? NDecimales { get; set; }

		public bool? PLCBReintentarDosificacionPerdidaSP { get; set; }

		public int? PLCBTiempoMinEstable { get; set; }

		[StringLength(5)]
		public string SeparadorNewLine { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCCPulsosL { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PLCCLimSuperiorAnalogica { get; set; }

		public bool? PLCCTipoContador { get; set; }

		public int? TiempoMaximoLectura { get; set; }

		[Obsolete]
		public int? IdOpc { get; set; }

		public int? ModoTransmisionPeso { get; set; }

		[StringLength(20)]
		public string CadenaPeticion { get; set; }

		public int OpcConfigId { get; set; }

		public bool PlcEnabled { get; set; }

		[ForeignKey(nameof(OpcConfigId))]
		[InverseProperty(nameof(Models.OpcConfig.Basculas))]
		public virtual OpcConfig OpcConfig { get; set; }

		[ForeignKey(nameof(Tag))]
		[InverseProperty(nameof(Tags.Basculas))]
		public virtual Tags TagNavigation { get; set; }

		[InverseProperty(nameof(EntradasLineas.idBasculaPesajeBrutoNavigation))]
		public virtual ICollection<EntradasLineas> EntradasLineasidBasculaPesajeBrutoNavigation { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(EntradasLineas.idBasculaPesajeNetoNavigation))]
		public virtual ICollection<EntradasLineas> EntradasLineasidBasculaPesajeNetoNavigation { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(Models.Indicadores.IdBasculaNavigation))]
		public virtual ICollection<Indicadores> Indicadores { get; set; } = new HashSet<Indicadores>();

		[InverseProperty(nameof(Models.Medidor.IdBasculaNavigation))]
		public virtual ICollection<Medidor> Medidores { get; set; } = new HashSet<Medidor>();

		[InverseProperty(nameof(SalidasLinias.idBasculaPesajeBrutoNavigation))]
		public virtual ICollection<SalidasLinias> SalidasLiniasidBasculaPesajeBrutoNavigation { get; set; } = new HashSet<SalidasLinias>();

		[InverseProperty(nameof(SalidasLinias.idBasculaPesajeNetoNavigation))]
		public virtual ICollection<SalidasLinias> SalidasLiniasidBasculaPesajeNetoNavigation { get; set; } = new HashSet<SalidasLinias>();

		[InverseProperty(nameof(Models.TagsBasculas.idBasculaNavigation))]
		public virtual ICollection<TagsBasculas> TagsBasculas { get; set; } = new HashSet<TagsBasculas>();

		public class BasculaPenko : Bascula
		{

		}

		public class BasculaPerle : Bascula
		{

			public int? StartIndex { get; set; }

			[Column("Lenght")]
			public int? Length { get; set; }

		}

	}

}
