using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Formularios
	{

		[Key]
		public int Id { get; set; }

		public int Formula { get; set; }

		public int? Producto { get; set; }

		public bool? Principal { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? Medicacion { get; set; }

		public int? idOld { get; set; }

		[ForeignKey(nameof(Formula))]
		[InverseProperty(nameof(Formulas.Formularios))]
		public virtual Formulas FormulaNavigation { get; set; }

		[ForeignKey(nameof(Medicacion))]
		[InverseProperty(nameof(Medicaciones.Formularios))]
		public virtual Medicaciones MedicacionNavigation { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Productos.Formularios))]
		public virtual Productos ProductoNavigation { get; set; }

		[InverseProperty(nameof(Models.FormulaProdModulo.idFormularioNavigation))]
		public virtual ICollection<FormulaProdModulo> FormulaProdModulo { get; set; } = new HashSet<FormulaProdModulo>();

	}

}
