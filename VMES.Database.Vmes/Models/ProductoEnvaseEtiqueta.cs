using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class ProductoEnvaseEtiqueta
	{

		public int ProductoId { get; set; }

		public int EnvaseId { get; set; }

		public ProductoEnvaseEtiquetaType Type { get; set; }

		[Required]
		[StringLength(128)]
		public string Code { get; set; }

		[ForeignKey(nameof(ProductoId))]
		[InverseProperty(nameof(Models.Productos.ProductosEnvasesEtiquetas))]
		public virtual Productos Producto { get; set; }

		[ForeignKey(nameof(EnvaseId))]
		[InverseProperty(nameof(Models.Envases.ProductosEnvasesEtiquetas))]
		public virtual Envases Envase { get; set; }

	}

}
