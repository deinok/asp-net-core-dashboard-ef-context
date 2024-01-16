using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class InformesLibCategorias
	{

		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Nombre { get; set; }

		[Required]
		public bool? isModificable { get; set; }

		[Required]
		public bool? isVisible { get; set; }

		[InverseProperty(nameof(Models.InformesLib.IdCategoriaNavigation))]
		public virtual ICollection<InformesLib> InformesLib { get; set; } = new HashSet<InformesLib>();

	}

}
