using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPComponentes
	{

		[Key]
		public int id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FImportado { get; set; }

		public bool? Preparado { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		public int? idVersion { get; set; }

		public int? IdProducto { get; set; }

		[StringLength(50)]
		public string RefProducto { get; set; }

		public float? Porcentaje { get; set; }

		public float? Cantidad { get; set; }

		public int? Unidad { get; set; }

		public int? Tipo { get; set; }

		public bool? Automatico { get; set; }

		public int? TipoDosificacion { get; set; }

		public int? Modulo { get; set; }

		public int? Medidor { get; set; }

		public int? Orden { get; set; }

		[Column(TypeName = "numeric(18, 2)")]
		public decimal? ToleranciaSuperior { get; set; }

		[Column(TypeName = "numeric(18, 2)")]
		public decimal? ToleranciaInferior { get; set; }

		public bool? PausaPosteriorDosificacion { get; set; }

		public bool? DosificarProductoAnterior { get; set; }

		public int? OperTiempo { get; set; }

		public int? OperMotor { get; set; }

		public int? OperAccion { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? OperVariable { get; set; }

		[StringLength(250)]
		public string TextoVariable { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? OperVariable2 { get; set; }

		[StringLength(20)]
		public string RefERPUnidades { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		[StringLength(20)]
		public string RefVersion { get; set; }

		[StringLength(20)]
		public string RefFormula { get; set; }

		public bool? AddVersionActiva { get; set; }

		[ForeignKey(nameof(idVersion))]
		[InverseProperty(nameof(BufferERPVersiones.BufferERPComponentes))]
		public virtual BufferERPVersiones idVersionNavigation { get; set; }

	}

}
