using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class LoteProveedorUnicoNOCantidad
	{

		public int IdLote { get; set; }

		[StringLength(50)]
		public string Proveedor { get; set; }

		public string LotesProveedor { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaCreacion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FFin { get; set; }

		public long? NUM_PROVEEDOR { get; set; }

	}

}
