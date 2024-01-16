using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class ComponentesActivos
	{

		[Key]
		public int Producto { get; set; }

		[Key]
		public int Orden { get; set; }

		[Required]
		[StringLength(120)]
		public string Nombre { get; set; }

		public float Cantidad { get; set; }

		public int? Unidad { get; set; }

		public bool Importado { get; set; }

		public bool Exportado { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Productos.ComponentesActivos))]
		public virtual Productos ProductoNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.ComponentesActivos))]
		public virtual Unidades UnidadNavigation { get; set; }

	}

}
