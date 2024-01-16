using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class EnlaceERPLinea
	{

		[Key]
		public int id { get; set; }

		public int? idEnlaceERP { get; set; }

		public int? idEnlaceERPTipoLinea { get; set; }

		public int? PosicionEnFichero { get; set; }

		public bool? TamFijo { get; set; }

		public int? PosicionInicial { get; set; }

		public int? NumCaracteres { get; set; }

		[StringLength(50)]
		public string CampoXML { get; set; }

		public bool? Activado { get; set; }

		[StringLength(50)]
		public string ValorDefecto { get; set; }

		[StringLength(50)]
		public string ValorObligatorio { get; set; }

		[StringLength(50)]
		public string ValorExcluido { get; set; }

		[ForeignKey(nameof(idEnlaceERP))]
		[InverseProperty(nameof(EnlaceERP.EnlaceERPLinea))]
		public virtual EnlaceERP idEnlaceERPNavigation { get; set; }

		[ForeignKey(nameof(idEnlaceERPTipoLinea))]
		[InverseProperty(nameof(EnlaceERPTipoLinea.EnlaceERPLinea))]
		public virtual EnlaceERPTipoLinea idEnlaceERPTipoLineaNavigation { get; set; }

	}

}
