using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Valores
	{

		[Key]
		public int Id { get; set; }

		public int Serie { get; set; }

		public int Orden { get; set; }

		public int IdOld { get; set; }

		public int? Variable { get; set; }

		public float? Valor { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? SerieOld { get; set; }

		[ForeignKey(nameof(Orden))]
		[InverseProperty(nameof(Ordenes.Valores))]
		public virtual Ordenes OrdenNavigation { get; set; }

		[ForeignKey(nameof(Variable))]
		[InverseProperty(nameof(Variables.Valores))]
		public virtual Variables VariableNavigation { get; set; }

	}

}
