using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class EnlaceERPTipo
	{

		[Key]
		public int id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public bool? Importacion { get; set; }

		public bool? Exportacion { get; set; }

		public int? Tipo { get; set; }

		[InverseProperty(nameof(Models.EnlaceERP.idEnlaceERPTipoNavigation))]
		public virtual ICollection<EnlaceERP> EnlaceERP { get; set; } = new HashSet<EnlaceERP>();

		[InverseProperty(nameof(Models.EnlaceERPTipoLinea.idEnlaceERPTipoNavigation))]
		public virtual ICollection<EnlaceERPTipoLinea> EnlaceERPTipoLinea { get; set; } = new HashSet<EnlaceERPTipoLinea>();

	}

}
