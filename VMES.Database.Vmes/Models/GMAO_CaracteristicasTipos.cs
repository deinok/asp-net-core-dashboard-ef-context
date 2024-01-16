using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_CaracteristicasTipos
	{

		[Key]
		public int idTipoElemento { get; set; }

		[Key]
		public int idCaracteristica { get; set; }

		[Required]
		[StringLength(256)]
		public string ValorString { get; set; }

		[ForeignKey(nameof(idCaracteristica))]
		[InverseProperty(nameof(GMAO_Caracteristicas.GMAO_CaracteristicasTipos))]
		public virtual GMAO_Caracteristicas idCaracteristicaNavigation { get; set; }

		[ForeignKey(nameof(idTipoElemento))]
		[InverseProperty(nameof(GMAO_ElementosTipos.GMAO_CaracteristicasTipos))]
		public virtual GMAO_ElementosTipos idTipoElementoNavigation { get; set; }

	}

}
