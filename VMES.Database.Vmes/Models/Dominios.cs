using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Dominios
	{

		public int? Familia { get; set; }

		[Key]
		public int Id { get; set; }

		public int? Departamento { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[ForeignKey(nameof(Departamento))]
		[InverseProperty(nameof(Departamentos.Dominios))]
		public virtual Departamentos DepartamentoNavigation { get; set; }

		[ForeignKey(nameof(Familia))]
		[InverseProperty(nameof(Familias.Dominios))]
		public virtual Familias FamiliaNavigation { get; set; }

	}

}
