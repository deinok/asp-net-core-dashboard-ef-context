using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_Marcas
	{

		[Key]
		public int id { get; set; }

		[Required]
		[StringLength(64)]
		public string Nombre { get; set; }

		[StringLength(1024)]
		public string Observaciones { get; set; }

		[InverseProperty(nameof(Models.GMAO_MarcasModelos.idMarcaNavigation))]
		public virtual ICollection<GMAO_MarcasModelos> GMAO_MarcasModelos { get; set; } = new HashSet<GMAO_MarcasModelos>();

	}

}
