using System;
using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{


	[Obsolete]
	public class ConsumidoOrden
	{

		public int Id { get; set; }

		public int IdOrden { get; set; }

		public float? Cantidad { get; set; }

		public int? Lote { get; set; }

		[StringLength(30)]
		public string LoteNombre { get; set; }

		[StringLength(20)]
		public string LoteReferencia { get; set; }

		public int? Producto { get; set; }

		[StringLength(50)]
		public string ProductoNombre { get; set; }

		[StringLength(50)]
		public string PartidaArancelariaCompras { get; set; }

		[StringLength(50)]
		public string PartidaArancelariaFabricacion { get; set; }

		public int? Unidad { get; set; }

		[StringLength(50)]
		public string UnidadNombre { get; set; }

	}

}
