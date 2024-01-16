using System;
using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class ResultadosOrdenAgrupado
	{

		public int Orden { get; set; }

		public int? IdDosificacion { get; set; }

		public int? Producto { get; set; }

		public double? cantidad { get; set; }

		public int? posicion { get; set; }

		[StringLength(50)]
		public string ProductoNombre { get; set; }

		public int? Lote { get; set; }

		[StringLength(30)]
		public string LoteNombre { get; set; }

		[StringLength(20)]
		public string RefProducto { get; set; }

	}

}
