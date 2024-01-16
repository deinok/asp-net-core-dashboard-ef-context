using System;
using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class ListaDesgloses
	{

		public int Id { get; set; }

		public int Orden { get; set; }

		[StringLength(50)]
		public string Producto { get; set; }

		[StringLength(50)]
		public string Ubicacion { get; set; }

		public float? Cantidad { get; set; }

		public float? CantidadPrincipal { get; set; }

		[StringLength(50)]
		public string Unidad { get; set; }

		[StringLength(30)]
		public string Lote { get; set; }

	}

}
