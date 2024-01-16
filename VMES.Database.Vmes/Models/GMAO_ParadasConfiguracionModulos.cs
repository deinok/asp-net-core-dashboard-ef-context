using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_ParadasConfiguracionModulos
	{

		[Key]
		public int idParadaConfiguracion { get; set; }

		[Key]
		public int idModulo { get; set; }

		public bool RequiereParar { get; set; }

		[ForeignKey(nameof(idModulo))]
		[InverseProperty(nameof(Modulos.GMAO_ParadasConfiguracionModulos))]
		public virtual Modulos idModuloNavigation { get; set; }

		[ForeignKey(nameof(idParadaConfiguracion))]
		[InverseProperty(nameof(GMAO_ParadasConfiguracion.GMAO_ParadasConfiguracionModulos))]
		public virtual GMAO_ParadasConfiguracion idParadaConfiguracionNavigation { get; set; }

	}

}
