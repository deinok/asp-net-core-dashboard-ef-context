using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class SalidasLineasResultados
	{

		public int Orden { get; set; }

		public double? CantidadTotal { get; set; }

		[StringLength(30)]
		public string LoteNombre { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Caducidad { get; set; }

		[StringLength(50)]
		public string UnidadTexto { get; set; }

	}

}
