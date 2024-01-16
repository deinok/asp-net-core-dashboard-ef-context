using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class EnlaceERPAsigUbi
	{

		[Key]
		public int Id { get; set; }

		public int? IdProducto { get; set; }

		public int? IdUbicacion { get; set; }

		[ForeignKey(nameof(IdProducto))]
		[InverseProperty(nameof(Productos.EnlaceERPAsigUbi))]
		public virtual Productos IdProductoNavigation { get; set; }

		[ForeignKey(nameof(IdUbicacion))]
		[InverseProperty(nameof(Ubicaciones.EnlaceERPAsigUbi))]
		public virtual Ubicaciones IdUbicacionNavigation { get; set; }

	}

}
