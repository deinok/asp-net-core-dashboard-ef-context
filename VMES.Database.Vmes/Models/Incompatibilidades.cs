using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Incompatibilidades
	{

		public int Formula { get; set; }

		[Key]
		public int Id { get; set; }

		public int? Producto { get; set; }

		public int Tipo { get; set; }

		public int? NumeroMezclas { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? idOld { get; set; }

		[ForeignKey(nameof(Formula))]
		[InverseProperty(nameof(Formulas.Incompatibilidades))]
		public virtual Formulas FormulaNavigation { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Productos.Incompatibilidades))]
		public virtual Productos ProductoNavigation { get; set; }

	}

}
