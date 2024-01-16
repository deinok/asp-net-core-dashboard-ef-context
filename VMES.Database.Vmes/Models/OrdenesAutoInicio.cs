using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class OrdenesAutoInicio
	{

		[Key]
		public int id { get; set; }

		public int idOrden { get; set; }

		public int idOrdenObjetivo { get; set; }

		[Required]
		public bool? Activo { get; set; }

		[ForeignKey(nameof(idOrden))]
		[InverseProperty(nameof(Ordenes.OrdenesAutoInicioidOrdenNavigation))]
		public virtual Ordenes idOrdenNavigation { get; set; }

		[ForeignKey(nameof(idOrdenObjetivo))]
		[InverseProperty(nameof(Ordenes.OrdenesAutoInicioidOrdenObjetivoNavigation))]
		public virtual Ordenes idOrdenObjetivoNavigation { get; set; }

	}

}
