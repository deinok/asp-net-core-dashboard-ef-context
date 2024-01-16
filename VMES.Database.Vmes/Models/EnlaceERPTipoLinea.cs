using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class EnlaceERPTipoLinea
	{

		[Key]
		public int id { get; set; }

		public int? idEnlaceERPTipo { get; set; }

		[StringLength(50)]
		public string CampoBuffer { get; set; }

		[ForeignKey(nameof(idEnlaceERPTipo))]
		[InverseProperty(nameof(EnlaceERPTipo.EnlaceERPTipoLinea))]
		public virtual EnlaceERPTipo idEnlaceERPTipoNavigation { get; set; }

		[InverseProperty(nameof(Models.EnlaceERPLinea.idEnlaceERPTipoLineaNavigation))]
		public virtual ICollection<EnlaceERPLinea> EnlaceERPLinea { get; set; } = new HashSet<EnlaceERPLinea>();

	}

}
