using System;
using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class TextosParametros
	{

		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Grupo { get; set; }

		[Required]
		[StringLength(50)]
		public string Parametro { get; set; }

		public int IdTexto { get; set; }

		[Required]
		[StringLength(50)]
		public string Texto { get; set; }

		public int? Idioma { get; set; }

		[StringLength(50)]
		public string NombreEnum { get; set; }

		[StringLength(50)]
		public string TextoEnum { get; set; }

		[StringLength(250)]
		public string Comentarios { get; set; }

	}

}
