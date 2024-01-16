using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class RecetasLineas
	{

		[Key]
		public int id { get; set; }

		public int idReceta { get; set; }

		public int ProductoId { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? Cantidad { get; set; }

		[Column(TypeName = "decimal(8, 5)")]
		public decimal? Porcentaje { get; set; }

		[ForeignKey(nameof(ProductoId))]
		[InverseProperty(nameof(Productos.RecetasLineas))]
		public virtual Productos ProductoNavigation { get; set; }

		[ForeignKey(nameof(idReceta))]
		[InverseProperty(nameof(Recetas.RecetasLineas))]
		public virtual Recetas idRecetaNavigation { get; set; }

	}

}
