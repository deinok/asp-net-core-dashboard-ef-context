using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class SalidasLotesServidos
	{

		public int? Orden { get; set; }

		public int? Salida { get; set; }

		public int? IdProducto { get; set; }

		[StringLength(50)]
		public string NombreProducto { get; set; }

		public int? IdLote { get; set; }

		[StringLength(30)]
		public string NombreLote { get; set; }

		public double? CantidadServida { get; set; }

		[StringLength(50)]
		public string NombreUnidad { get; set; }

		public int? LineaSalida { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? CaducidadLote { get; set; }

	}

}
