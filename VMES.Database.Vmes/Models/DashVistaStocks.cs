using System;
using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class DashVistaStocks
	{

		[StringLength(50)]
		public string ProductoNombre { get; set; }

		[StringLength(20)]
		public string ProductoReferencia { get; set; }

		[StringLength(20)]
		public string ProductoReferencia2 { get; set; }

		public float ProductoDensidad { get; set; }

		[Required]
		[StringLength(13)]
		public string TipoProducto { get; set; }

		public float CantidadStock { get; set; }

		[Required]
		[StringLength(50)]
		public string UbicacionNombre { get; set; }

	}

}
