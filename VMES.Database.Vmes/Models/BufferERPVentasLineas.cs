using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPVentasLineas
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

		public int? Serie { get; set; }

		[StringLength(50)]
		public string RevVenta { get; set; }

		[StringLength(50)]
		public string RefProducto { get; set; }

		[StringLength(50)]
		public string RefFormato { get; set; }

		[StringLength(50)]
		public string RefEnvase { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Bultos { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? Cantidad { get; set; }

		[StringLength(50)]
		public string RefUnidad { get; set; }

		[StringLength(50)]
		public string RefDomicilio { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioUnidad { get; set; }

		public int? linea { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[StringLength(250)]
		public string Observaciones { get; set; }

		[StringLength(50)]
		public string RefPuntoDescarga { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		public int? BufferErpVentaId { get; set; }

		[ForeignKey(nameof(BufferErpVentaId))]
		[InverseProperty(nameof(BufferERPVentas.BufferErpVentaLineas))]
		public virtual BufferERPVentas BufferErpVenta { get; set; }

	}

}
