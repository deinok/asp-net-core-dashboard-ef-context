using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Especies
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[InverseProperty(nameof(Models.Domicilios.EspecieNavigation))]
		public virtual ICollection<Domicilios> Domicilios { get; set; } = new HashSet<Domicilios>();

		[InverseProperty(nameof(Models.Recetas.EspecieNavigation))]
		public virtual ICollection<Recetas> Recetas { get; set; } = new HashSet<Recetas>();

	}

}
