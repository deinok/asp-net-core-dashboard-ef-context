using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_CaracteristicasElementos
	{

		[Key]
		public int idElemento { get; set; }

		[Key]
		public int idCaracteristica { get; set; }

		[Required]
		[StringLength(256)]
		public string ValorString { get; set; }

		[ForeignKey(nameof(idCaracteristica))]
		[InverseProperty(nameof(GMAO_Caracteristicas.GMAO_CaracteristicasElementos))]
		public virtual GMAO_Caracteristicas idCaracteristicaNavigation { get; set; }

		[ForeignKey(nameof(idElemento))]
		[InverseProperty(nameof(GMAO_Elementos.GMAO_CaracteristicasElementos))]
		public virtual GMAO_Elementos idElementoNavigation { get; set; }

	}

}
