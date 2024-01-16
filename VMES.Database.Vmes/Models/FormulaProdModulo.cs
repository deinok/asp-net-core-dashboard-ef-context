using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class FormulaProdModulo
	{

		[Key]
		public int id { get; set; }

		public int? idFormulario { get; set; }

		public int? idModulo { get; set; }

		public int? idProducto { get; set; }

		public int? idUbicacion { get; set; }

		public bool ForzarModulo { get; set; }

		[ForeignKey(nameof(idFormulario))]
		[InverseProperty(nameof(Formularios.FormulaProdModulo))]
		public virtual Formularios idFormularioNavigation { get; set; }

		[ForeignKey(nameof(idModulo))]
		[InverseProperty(nameof(Modulos.FormulaProdModulo))]
		public virtual Modulos idModuloNavigation { get; set; }

		[ForeignKey(nameof(idProducto))]
		[InverseProperty(nameof(Productos.FormulaProdModulo))]
		public virtual Productos idProductoNavigation { get; set; }

		[ForeignKey(nameof(idUbicacion))]
		[InverseProperty(nameof(Ubicaciones.FormulaProdModulo))]
		public virtual Ubicaciones idUbicacionNavigation { get; set; }

	}

}
