using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class OrdenesRelacion
	{

		[Key]
		public int id { get; set; }

		public int? idOrdenPadre { get; set; }

		public int? idOrdenHijo { get; set; }

		[Column(TypeName = "numeric(8, 2)")]
		public decimal? Porcentaje { get; set; }

		[ForeignKey(nameof(idOrdenHijo))]
		[InverseProperty(nameof(Ordenes.OrdenesRelacionidOrdenHijoNavigation))]
		public virtual Ordenes idOrdenHijoNavigation { get; set; }

		[ForeignKey(nameof(idOrdenPadre))]
		[InverseProperty(nameof(Ordenes.OrdenesRelacionidOrdenPadreNavigation))]
		public virtual Ordenes idOrdenPadreNavigation { get; set; }

	}

}
