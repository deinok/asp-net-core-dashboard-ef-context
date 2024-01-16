using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class EntradasLineasResultadosNIRExtended
	{

		public int id { get; set; }

		public int? idEntradasLineas { get; set; }

		public int? idControlesNir { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(500)]
		public string Descripcion { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Resultado { get; set; }

		public int? IdUnidad { get; set; }

		public int? UnidadTexto { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaResultado { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? ValorMinimo { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? ValorEsperado { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? ValorMaximo { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? ValorMinimoAlerta { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? ValorMaximoAlerta { get; set; }

		public bool? ActivarMinimo { get; set; }

		public bool? ActivarMaximo { get; set; }

		public bool? ActivarMinimoAlerta { get; set; }

		public bool? ActivarMaximoAlerta { get; set; }

	}

}
