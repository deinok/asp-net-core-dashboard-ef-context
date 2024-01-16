using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class OrdenesDetalle
	{

		[StringLength(250)]
		public string NombreOrden { get; set; }

		public int Id { get; set; }

		[StringLength(50)]
		public string NombreCabecera { get; set; }

		[StringLength(50)]
		public string NombreModulo { get; set; }

		[Column(TypeName = "date")]
		public DateTime? Fecha { get; set; }

		public int? NumeroCiclos { get; set; }

		[StringLength(50)]
		public string NombreProducto { get; set; }

		[StringLength(50)]
		public string NombreUnidad { get; set; }

		[StringLength(30)]
		public string NombreLote { get; set; }

		[Column(TypeName = "decimal(38, 15)")]
		public decimal? CantidadTCiclo { get; set; }

		[Column(TypeName = "decimal(38, 6)")]
		public decimal? CantidadTOrden { get; set; }

	}

}
