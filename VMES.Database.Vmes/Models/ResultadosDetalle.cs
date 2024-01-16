using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class ResultadosDetalle
	{

		public int Orden { get; set; }

		public float? Cantidad { get; set; }

		[StringLength(50)]
		public string NombreMedidor { get; set; }

		[StringLength(50)]
		public string NombreUnidad { get; set; }

		[StringLength(50)]
		public string NombreUbicacion { get; set; }

		[StringLength(50)]
		public string NombreProducto { get; set; }

		public int? PosicionDosificacion { get; set; }

		[StringLength(30)]
		public string NombreLote { get; set; }

		public int? Ciclo { get; set; }

		[Column(TypeName = "decimal(28, 15)")]
		public decimal? CantidadTeorica { get; set; }

		[Column(TypeName = "numeric(18, 2)")]
		public decimal? DesviacionProducto { get; set; }

		public int? Producto { get; set; }

	}

}
