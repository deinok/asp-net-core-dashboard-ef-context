using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class ProductosOperCabPlantillas
	{

		[Key]
		public int Id { get; set; }

		public int IdProducto { get; set; }

		public int IdOperCabPlantilla { get; set; }

		[ForeignKey(nameof(IdOperCabPlantilla))]
		[InverseProperty(nameof(OperCabPlantillas.ProductosOperCabPlantillas))]
		public virtual OperCabPlantillas IdOperCabPlantillaNavigation { get; set; }

		[ForeignKey(nameof(IdProducto))]
		[InverseProperty(nameof(Productos.ProductosOperCabPlantillas))]
		public virtual Productos IdProductoNavigation { get; set; }

	}

}
