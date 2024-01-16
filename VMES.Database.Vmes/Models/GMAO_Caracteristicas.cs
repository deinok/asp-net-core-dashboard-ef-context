using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_Caracteristicas
	{

		[Key]
		public int id { get; set; }

		[Required]
		[StringLength(64)]
		public string Nombre { get; set; }

		[InverseProperty(nameof(Models.GMAO_CaracteristicasElementos.idCaracteristicaNavigation))]
		public virtual ICollection<GMAO_CaracteristicasElementos> GMAO_CaracteristicasElementos { get; set; } = new HashSet<GMAO_CaracteristicasElementos>();

		[InverseProperty(nameof(Models.GMAO_CaracteristicasTipos.idCaracteristicaNavigation))]
		public virtual ICollection<GMAO_CaracteristicasTipos> GMAO_CaracteristicasTipos { get; set; } = new HashSet<GMAO_CaracteristicasTipos>();

	}

}
