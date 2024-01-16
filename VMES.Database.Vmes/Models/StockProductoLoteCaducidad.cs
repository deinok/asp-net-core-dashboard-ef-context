using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{


	[Obsolete]
	public class StockProductoLoteCaducidad
	{

		public int? idProducto { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		[StringLength(20)]
		public string Referencia2 { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? Tipo { get; set; }

		public int? idLote { get; set; }

		[StringLength(20)]
		public string ReferenciaLote { get; set; }

		[StringLength(30)]
		public string Lote { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FCaducidad { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FFabricacion { get; set; }

		public int? Familia { get; set; }

		[StringLength(50)]
		public string FamiliaNombre { get; set; }

		public double? Cantidad { get; set; }

		public long RowID { get; set; }

	}

}
