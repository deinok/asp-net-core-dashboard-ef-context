using System;
using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class DesglosesDetalle
	{

		public float? Cantidad { get; set; }

		public float? CantidadPrincipal { get; set; }

		public int Orden { get; set; }

		public int Id { get; set; }

		[StringLength(30)]
		public string LoteNombre { get; set; }

		[StringLength(50)]
		public string ProductoNombre { get; set; }

		[StringLength(50)]
		public string UnidadNombre { get; set; }

		[StringLength(50)]
		public string UbicacionNombre { get; set; }

		public int Ciclo { get; set; }

	}

}
