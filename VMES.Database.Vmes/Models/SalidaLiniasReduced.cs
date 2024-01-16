using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class SalidaLiniasReduced
	{

		public int Id { get; set; }

		[StringLength(50)]
		public string NombreProducto { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? Cantidad { get; set; }

		[StringLength(50)]
		public string NombreUnidad { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal Bultos { get; set; }

		[StringLength(50)]
		public string NombreFormato { get; set; }

		[StringLength(50)]
		public string NombreEnvase { get; set; }

		[Required]
		[StringLength(204)]
		public string Origenes { get; set; }

		[Required]
		[StringLength(31)]
		public string Cajones { get; set; }

	}

}
