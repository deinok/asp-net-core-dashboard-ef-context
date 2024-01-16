using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class DashboardsLibCategorias
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

		[InverseProperty(nameof(Models.DashboardsLib.IdCategoriaNavigation))]
		public virtual ICollection<DashboardsLib> DashboardsLib { get; set; } = new HashSet<DashboardsLib>();

	}

}
