using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class OperPlantillas
	{

		[Key]
		public int Id { get; set; }

		public int? OperTiempo { get; set; }

		public int? IdOperMotor { get; set; }

		public int? IdOperAccion { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? OperVariable { get; set; }

		public int? Medidor { get; set; }

		[StringLength(250)]
		public string TextoVariable { get; set; }

		public int? IdOperCabPlantillas { get; set; }

		public int? TipoDosificacion { get; set; }

		public int? IdProducto { get; set; }

		public int? IdUbicacion { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? Cantidad { get; set; }

		public bool? DosificarProductoAnterior { get; set; }

		public int? KGxSeg { get; set; }

		public bool? KGxSegPesoAcumulado { get; set; }

		public bool? KGxSegPesoAntDosificacion { get; set; }

		public int? Ordenacion { get; set; }

		[Column(TypeName = "decimal(28, 15)")]
		public decimal? Porcentaje { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? OperVariable2 { get; set; }

		[StringLength(500)]
		public string Comentario { get; set; }

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

		public int? Prioridad { get; set; }

		[ForeignKey(nameof(IdOperAccion))]
		[InverseProperty(nameof(OperAcciones.OperPlantillas))]
		public virtual OperAcciones IdOperAccionNavigation { get; set; }

		[ForeignKey(nameof(IdOperCabPlantillas))]
		[InverseProperty(nameof(OperCabPlantillas.OperPlantillas))]
		public virtual OperCabPlantillas IdOperCabPlantillasNavigation { get; set; }

		[ForeignKey(nameof(IdOperMotor))]
		[InverseProperty(nameof(OperMotores.OperPlantillas))]
		public virtual OperMotores IdOperMotorNavigation { get; set; }

		[ForeignKey(nameof(IdProducto))]
		[InverseProperty(nameof(Productos.OperPlantillas))]
		public virtual Productos IdProductoNavigation { get; set; }

		[ForeignKey(nameof(IdTempControl))]
		[InverseProperty(nameof(TempControles.OperPlantillas))]
		public virtual TempControles IdTempControlNavigation { get; set; }

		[ForeignKey(nameof(IdUbicacion))]
		[InverseProperty(nameof(Ubicaciones.OperPlantillas))]
		public virtual Ubicaciones IdUbicacionNavigation { get; set; }

		[ForeignKey(nameof(Medidor))]
		[InverseProperty(nameof(Models.Medidor.OperPlantillas))]
		public virtual Medidor MedidorNavigation { get; set; }

	}

}
