using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_ElementosTiposModelos
	{

		[Key]
		public int idTipo { get; set; }

		[Key]
		public int idModelo { get; set; }

		public bool? Preferencia { get; set; }

		[ForeignKey(nameof(idModelo))]
		[InverseProperty(nameof(GMAO_MarcasModelos.GMAO_ElementosTiposModelos))]
		public virtual GMAO_MarcasModelos idModeloNavigation { get; set; }

		[ForeignKey(nameof(idTipo))]
		[InverseProperty(nameof(GMAO_ElementosTipos.GMAO_ElementosTiposModelos))]
		public virtual GMAO_ElementosTipos idTipoNavigation { get; set; }

	}

}
