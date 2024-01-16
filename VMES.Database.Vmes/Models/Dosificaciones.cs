using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Dosificaciones
	{

		[Key]
		public int Id { get; set; }

		public int Serie { get; set; }

		public int Orden { get; set; }

		public int IdOld { get; set; }

		public int? Producto { get; set; }

		public int? Formato { get; set; }

		public int? Proceso { get; set; }

		[Column(TypeName = "decimal(28, 15)")]
		public decimal? Porcentaje { get; set; }

		[Column(TypeName = "decimal(28, 15)")]
		public decimal? Cantidad { get; set; }

		public int? Unidad { get; set; }

		public float? Servida { get; set; }

		public int? NumeroPesadas { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Inicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fin { get; set; }

		public DosificacionType? Tipo { get; set; }

		public bool? Exportado { get; set; }

		public int? Lote { get; set; }

		public int? Ubicacion { get; set; }

		public int? Grupo { get; set; }

		public DosificacionStatus? Estado { get; set; }

		public int? Medidor { get; set; }

		[Column(TypeName = "decimal(28, 15)")]
		public decimal? CantidadPrincipal { get; set; }

		public int? TipoRegistro { get; set; }

		public bool? Importado { get; set; }

		public int? PosicionDosificacion { get; set; }

		public int? CicloActual { get; set; }

		public float? CantidadActual { get; set; }

		public int? UbicacionActual { get; set; }

		public int? ProductoActual { get; set; }

		public int? LoteActual { get; set; }

		public int? DosificacionActual { get; set; }

		public int? IdModulo { get; set; }

		public DosificacionStatus? EstadoActual { get; set; }

		[Column(TypeName = "numeric(18, 2)")]
		public decimal? ToleranciaSuperior { get; set; }

		[Column(TypeName = "numeric(18, 2)")]
		public decimal? ToleranciaInferior { get; set; }

		public bool? PausaPosteriorDosificacion { get; set; }

		public int? NumCorrecion { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? Afino { get; set; }

		public int? ConVibrador { get; set; }

		public int? VelocidadLenta { get; set; }

		public int? VelocidadRapida { get; set; }

		public int? IdOperMotor { get; set; }

		public int? IdOperAccion { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? OperVariable { get; set; }

		[StringLength(250)]
		public string TextoVariable { get; set; }

		public int? OperTiempo { get; set; }

		public bool? DosificarProductoAnterior { get; set; }

		public int? PosicionDosificacionPLC { get; set; }

		public int? PosicionOperacionPLC { get; set; }

		public int? PosicionMultidosiPLC { get; set; }

		public int? PosicionTemperaturaPLC { get; set; }

		public int? idPlantilla { get; set; }

		public int? idFormulaOriginal { get; set; }

		public int? idComponenteOriginal { get; set; }

		public int? idVersionOriginal { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? OperVariable2 { get; set; }

		[StringLength(500)]
		public string Comentario { get; set; }

		public bool? OrigenERP { get; set; }

		public int? IdTempControl { get; set; }

		public int? TempModo { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? MinAlarma { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? MaxAlarma { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? Consigna { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? Histeresys { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? ConsignaPausa { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? ZonaMuerta { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? DosiVariable1 { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? DosiVariable2 { get; set; }

		[StringLength(20)]
		public string RefERP1 { get; set; }

		[StringLength(20)]
		public string RefERP2 { get; set; }

		[StringLength(20)]
		public string RefERP3 { get; set; }

		public int TipoAutoRespuesta { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? DosiVariable3 { get; set; }

		public int? Prioridad { get; set; }

		public int? idMedGenerador { get; set; }


		[ForeignKey(nameof(Formato))]
		[InverseProperty(nameof(Formatos.Dosificaciones))]
		public virtual Formatos FormatoNavigation { get; set; }

		[ForeignKey(nameof(IdModulo))]
		[InverseProperty(nameof(Modulos.Dosificaciones))]
		public virtual Modulos IdModuloNavigation { get; set; }

		[ForeignKey(nameof(IdOperAccion))]
		[InverseProperty(nameof(OperAcciones.Dosificaciones))]
		public virtual OperAcciones IdOperAccionNavigation { get; set; }

		[ForeignKey(nameof(IdOperMotor))]
		[InverseProperty(nameof(OperMotores.Dosificaciones))]
		public virtual OperMotores IdOperMotorNavigation { get; set; }

		[ForeignKey(nameof(IdTempControl))]
		[InverseProperty(nameof(TempControles.Dosificaciones))]
		public virtual TempControles IdTempControlNavigation { get; set; }

		[ForeignKey(nameof(LoteActual))]
		[InverseProperty(nameof(Lotes.DosificacionesLoteActualNavigation))]
		public virtual Lotes LoteActualNavigation { get; set; }

		[ForeignKey(nameof(Lote))]
		[InverseProperty(nameof(Lotes.DosificacionesLoteNavigation))]
		public virtual Lotes LoteNavigation { get; set; }

		[ForeignKey(nameof(Medidor))]
		[InverseProperty(nameof(Models.Medidor.DosificacionesNavigation))]
		public virtual Medidor MedidorNavigation { get; set; }

		[ForeignKey(nameof(Orden))]
		[InverseProperty(nameof(Ordenes.Dosificaciones))]
		public virtual Ordenes OrdenNavigation { get; set; }

		[ForeignKey(nameof(ProductoActual))]
		[InverseProperty(nameof(Productos.DosificacionesProductoActualNavigation))]
		public virtual Productos ProductoActualNavigation { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Productos.DosificacionesProductoNavigation))]
		public virtual Productos ProductoNavigation { get; set; }

		[ForeignKey(nameof(Ubicacion))]
		[InverseProperty(nameof(Ubicaciones.Dosificaciones))]
		public virtual Ubicaciones UbicacionNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.Dosificaciones))]
		public virtual Unidades UnidadNavigation { get; set; }

		[ForeignKey(nameof(idMedGenerador))]
		[InverseProperty(nameof(MedidoresDosificaciones.Dosificaciones))]
		public virtual MedidoresDosificaciones idMedGeneradorNavigation { get; set; }

		[ForeignKey(nameof(idPlantilla))]
		[InverseProperty(nameof(OperCabPlantillas.Dosificaciones))]
		public virtual OperCabPlantillas idPlantillaNavigation { get; set; }

		[InverseProperty(nameof(Models.MultiDosificaciones.idDosificacionNavigation))]
		public virtual ICollection<MultiDosificaciones> MultiDosificaciones { get; set; } = new HashSet<MultiDosificaciones>();

		[InverseProperty(nameof(Models.NetAlarmas.idDosificacionNavigation))]
		public virtual ICollection<NetAlarmas> NetAlarmas { get; set; } = new HashSet<NetAlarmas>();

		[InverseProperty(nameof(Models.NetAlarmasAutomaticasOrdenUbicaciones.IdDosificacionNavigation))]
		public virtual ICollection<NetAlarmasAutomaticasOrdenUbicaciones> NetAlarmasAutomaticasOrdenUbicaciones { get; set; } = new HashSet<NetAlarmasAutomaticasOrdenUbicaciones>();

	}

}
