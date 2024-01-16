using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class Contadores
	{

		[Key]
		[StringLength(50)]
		public string Nombre { get; set; }

		public int Contador { get; set; }

		[Column(TypeName = "date")]
		public DateTime Fecha { get; set; }

		public bool Visible { get; set; }

		public int? IdSerie { get; set; }

		public int id { get; set; }

	}

}
