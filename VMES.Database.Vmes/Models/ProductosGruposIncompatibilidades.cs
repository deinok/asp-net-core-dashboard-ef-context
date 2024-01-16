using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class ProductosGruposIncompatibilidades
	{

		[Key]
		public int IdProducto { get; set; }

		[Key]
		public int IdGrupoIncompatibilidad { get; set; }

		[ForeignKey(nameof(IdGrupoIncompatibilidad))]
		[InverseProperty(nameof(GruposIncompatibilidades.ProductosGruposIncompatibilidades))]
		public virtual GruposIncompatibilidades IdGrupoIncompatibilidadNavigation { get; set; }

		[ForeignKey(nameof(IdProducto))]
		[InverseProperty(nameof(Productos.ProductosGruposIncompatibilidades))]
		public virtual Productos IdProductoNavigation { get; set; }

	}

}
