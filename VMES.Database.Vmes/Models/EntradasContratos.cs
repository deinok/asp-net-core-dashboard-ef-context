using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class EntradasContratos
	{

		[Key]
		public int id { get; set; }

		public int? idEntradasLineas { get; set; }

		public int? idContrato { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Cantidad { get; set; }

		[ForeignKey(nameof(idContrato))]
		[InverseProperty(nameof(Contratos.EntradasContratos))]
		public virtual Contratos idContratoNavigation { get; set; }

		[ForeignKey(nameof(idEntradasLineas))]
		[InverseProperty(nameof(EntradasLineas.EntradasContratos))]
		public virtual EntradasLineas idEntradasLineasNavigation { get; set; }

	}

}
