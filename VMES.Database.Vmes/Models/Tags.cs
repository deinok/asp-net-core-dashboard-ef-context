using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Tags
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? Ubicacion { get; set; }

		public bool? Resetear { get; set; }

		public bool? OptSeleccionOrden { get; set; }

		public bool? OptPeso1 { get; set; }

		public bool? OptPeso2 { get; set; }

		public bool? OptIniciarOrden { get; set; }

		[StringLength(200)]
		public string PLCHMIMensaje1 { get; set; }

		[StringLength(200)]
		public string PLCHMIMensaje2 { get; set; }

		[StringLength(200)]
		public string PLCHMIMensaje3 { get; set; }

		[StringLength(200)]
		public string PLCAccionPLCMensaje1 { get; set; }

		[StringLength(200)]
		public string PLCAccionPLCMensaje2 { get; set; }

		[StringLength(200)]
		public string PLCAccionPLCMensaje3 { get; set; }

		public bool? PLCTAGRFIDLeido { get; set; }

		public bool? PLCLedVerdeOn { get; set; }

		public bool? PLCLedRojoOn { get; set; }

		public bool? PLCLedVerdeIterm { get; set; }

		public bool? PLCLedRojoIterm { get; set; }

		public bool? PLCSemaforoRojoOn { get; set; }

		public bool? PLCSemaforoAmbarOn { get; set; }

		public bool? PLCSemaforoVerdeOn { get; set; }

		public bool? PLCActivarZumbador { get; set; }

		public bool? PLCAbrirBarrera { get; set; }

		public bool? PLCAccionAuxiliar1 { get; set; }

		public bool? PLCAccionAuxiliar2 { get; set; }

		public bool? PLCAccionAuxiliar3 { get; set; }

		public bool? PLCHMIActivaBotonAceptar { get; set; }

		public bool? PLCHMIActivaBotonCancelar { get; set; }

		public bool? PLCHMIActivaBotonSiguiente { get; set; }

		public bool? PLCHMIActivaBotonAtras { get; set; }

		public bool? PLCHMIActivaEntradaDato { get; set; }

		public bool? PLCHMIActivaBotonIntro { get; set; }

		public bool? PLCHMIBotonAceptarLeido { get; set; }

		public bool? PLCHMIBotonCancelarLeido { get; set; }

		public bool? PLCHMIBotonSiguienteLeido { get; set; }

		public bool? PLCHMIBotonAtrasLeido { get; set; }

		public bool? PLCHMIBotonIntroLeido { get; set; }

		public bool? PLCHMIActivaBotonOpcion1 { get; set; }

		public bool? PLCHMIActivaBotonOpcion2 { get; set; }

		public bool? PLCHMIBotonOpcion1Leido { get; set; }

		public bool? PLCHMIBotonOpcion2Leido { get; set; }

		[StringLength(200)]
		public string MESTAGRFID { get; set; }

		[StringLength(200)]
		public string MESHMIDato { get; set; }

		public bool? MESHMIBotonAceptar { get; set; }

		public bool? MESHMIBotonCancelar { get; set; }

		public bool? MESHMIBotonSiguiente { get; set; }

		public bool? MESHMIBotonAtras { get; set; }

		public bool? MESHMIBotonIntro { get; set; }

		public bool? MESHMIBotonOpcion1 { get; set; }

		public bool? MESHMIBotonOpcion2 { get; set; }

		[Column("IdPLC")]
		public int IdPlc { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FFinIntermitente { get; set; }

		public int? idModulo { get; set; }

		public bool? OptHMIActivo { get; set; }

		public int? EstadoHMI { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FinalMensaje { get; set; }

		public int? idLecturaTag { get; set; }

		public bool? OrigenPesoBascula { get; set; }

		[Column(TypeName = "decimal(18, 6)")]
		public decimal? PesoActualBascula { get; set; }

		[Column(TypeName = "decimal(18, 6)")]
		public decimal? LecturaPesoActualBascula { get; set; }

		public int? PosicionMenu { get; set; }

		public int? IdLinEntradaMenu { get; set; }

		public int? IdLinSalidaMenu { get; set; }

		public bool? OptFinalizarOrden { get; set; }

		public bool? PreguntarBascula { get; set; }

		public bool? AutoSeleccion { get; set; }

		public bool? OpcEntradaAlmacen { get; set; }

		[Obsolete]
		public int? IdOpc { get; set; }

		public int OpcConfigId { get; set; }

		public bool PlcEnabled { get; set; }

		[ForeignKey(nameof(OpcConfigId))]
		[InverseProperty(nameof(Models.OpcConfig.Tags))]
		public virtual OpcConfig OpcConfig { get; set; }

		[ForeignKey(nameof(Ubicacion))]
		[InverseProperty(nameof(Ubicaciones.Tags))]
		public virtual Ubicaciones UbicacionNavigation { get; set; }

		[ForeignKey(nameof(idLecturaTag))]
		[InverseProperty(nameof(Models.TagsLecturas.Tags))]
		public virtual TagsLecturas idLecturaTagNavigation { get; set; }

		[ForeignKey(nameof(idModulo))]
		[InverseProperty(nameof(Modulos.Tags))]
		public virtual Modulos idModuloNavigation { get; set; }

		[InverseProperty(nameof(Models.Bascula.TagNavigation))]
		public virtual ICollection<Bascula> Basculas { get; set; } = new HashSet<Bascula>();

		[InverseProperty(nameof(Models.HumanMachineInterface.EntradasSalidasHumanMachineInterface.Tag))]
		public virtual ICollection<HumanMachineInterface.EntradasSalidasHumanMachineInterface> EntradasSalidasHumanMachineInterfaces { get; set; } = new HashSet<HumanMachineInterface.EntradasSalidasHumanMachineInterface>();

		[InverseProperty(nameof(Models.TagsBasculas.idTagNavigation))]
		public virtual ICollection<TagsBasculas> TagsBasculas { get; set; } = new HashSet<TagsBasculas>();

		[InverseProperty(nameof(Models.TagsLecturas.idTagNavigation))]
		public virtual ICollection<TagsLecturas> TagsLecturas { get; set; } = new HashSet<TagsLecturas>();

	}

}
