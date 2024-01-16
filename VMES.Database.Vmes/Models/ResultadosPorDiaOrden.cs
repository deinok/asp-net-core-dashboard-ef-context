using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class ResultadosPorDiaOrden
	{

		public int Serie { get; set; }

		public int IdOrden { get; set; }

		public int? ProductoId { get; set; }

		[StringLength(50)]
		public string NombreProducto { get; set; }

		[Column(TypeName = "date")]
		public DateTime? fecha { get; set; }

		public double? cantidad { get; set; }

		[StringLength(20)]
		public string RefProducto { get; set; }

		[StringLength(30)]
		public string Lote { get; set; }

	}

}
