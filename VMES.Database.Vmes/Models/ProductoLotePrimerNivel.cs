using System;
using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class ProductoLotePrimerNivel
	{

		public int? IdOrden { get; set; }

		[StringLength(250)]
		public string Orden { get; set; }

		public int? Producto { get; set; }

		[StringLength(50)]
		public string NombreProducto { get; set; }

		[StringLength(20)]
		public string RefProducto { get; set; }

		public int? Lote { get; set; }

		[StringLength(30)]
		public string NombreLote { get; set; }

		public int? ProductoOrigen { get; set; }

		[StringLength(50)]
		public string NombreProductoOrigen { get; set; }

		[StringLength(20)]
		public string RefProductoOrigen { get; set; }

		public int? LoteOrigen { get; set; }

		[StringLength(30)]
		public string NombreLoteOrigen { get; set; }

		public double? Total { get; set; }

		public double? TotalOrden { get; set; }

		public double? TotalProducidoOrden { get; set; }

		public int Nivel { get; set; }

	}

}
