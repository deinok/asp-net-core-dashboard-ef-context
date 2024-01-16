using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_ParadasConfiguracionTareas
	{

		[Key]
		public int id { get; set; }

		public int idParadaConfiguracion { get; set; }

		public int? idOperario { get; set; }

		public int? idElemento { get; set; }

		[StringLength(1024)]
		public string Descripcion { get; set; }

		[StringLength(1024)]
		public string Observaciones { get; set; }

		public TimeSpan? DuracionEstimada { get; set; }

		[ForeignKey(nameof(idElemento))]
		[InverseProperty(nameof(GMAO_Elementos.GMAO_ParadasConfiguracionTareas))]
		public virtual GMAO_Elementos idElementoNavigation { get; set; }

		[ForeignKey(nameof(idOperario))]
		[InverseProperty(nameof(GMAO_Operarios.GMAO_ParadasConfiguracionTareas))]
		public virtual GMAO_Operarios idOperarioNavigation { get; set; }

		[ForeignKey(nameof(idParadaConfiguracion))]
		[InverseProperty(nameof(GMAO_ParadasConfiguracion.GMAO_ParadasConfiguracionTareas))]
		public virtual GMAO_ParadasConfiguracion idParadaConfiguracionNavigation { get; set; }

	}

}
