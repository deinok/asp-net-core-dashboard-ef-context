using System;
using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class Puntos
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string DireccionPlc { get; set; }

		public int? Digitos { get; set; }

		public int? Decimales { get; set; }

		public int? ColorInicial { get; set; }

		public int? ColorFinal { get; set; }

		public int? ColorDigitos { get; set; }

		public int? ColorSombra { get; set; }

		public int? ColorFondo { get; set; }

		public int? ColorTitulo { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

	}

}
