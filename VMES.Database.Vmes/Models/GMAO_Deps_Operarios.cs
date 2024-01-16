using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_Deps_Operarios
	{

		[Key]
		public int idDepartamento { get; set; }

		[Key]
		public int idOperario { get; set; }

		[ForeignKey(nameof(idDepartamento))]
		[InverseProperty(nameof(GMAO_Departamentos.GMAO_Deps_Operarios))]
		public virtual GMAO_Departamentos idDepartamentoNavigation { get; set; }

		[ForeignKey(nameof(idOperario))]
		[InverseProperty(nameof(GMAO_Operarios.GMAO_Deps_Operarios))]
		public virtual GMAO_Operarios idOperarioNavigation { get; set; }

	}

}
