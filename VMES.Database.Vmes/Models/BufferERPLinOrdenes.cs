using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPLinOrdenes
	{

		[Key]
		public int id { get; set; }

		[StringLength(50)]
		public string NombreOrden { get; set; }

		public int? NumLinea { get; set; }

		[StringLength(50)]
		public string RefProducto { get; set; }

		[StringLength(50)]
		public string LoteProducto { get; set; }

		[Column(TypeName = "date")]
		public DateTime? CaducidadLoteProducto { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Cantidad { get; set; }

		public int? Tipo { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? CantidadTotal { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FImportado { get; set; }

		public int? idCaborden { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		[ForeignKey(nameof(idCaborden))]
		[InverseProperty(nameof(BufferERPCabOrdenes.BufferERPLinOrdenes))]
		public virtual BufferERPCabOrdenes idCabordenNavigation { get; set; }

	}

}
