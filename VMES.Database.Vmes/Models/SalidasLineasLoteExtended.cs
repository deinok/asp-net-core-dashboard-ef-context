using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class SalidasLineasLoteExtended
	{

		public int id { get; set; }

		public int? idLineaSalida { get; set; }

		public int? idLineaSalidaMedicamento { get; set; }

		public int? idLote { get; set; }

		[StringLength(30)]
		public string LoteNombre { get; set; }

		[StringLength(20)]
		public string LoteReferencia { get; set; }

		public int? LoteIdProducto { get; set; }

		[StringLength(50)]
		public string LoteProductoNombre { get; set; }

		[StringLength(20)]
		public string LoteProductoReferencia { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? LoteCaducidad { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Cantidad { get; set; }

		public int? idUnidad { get; set; }

		public int? UnidadStr { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

	}

}
