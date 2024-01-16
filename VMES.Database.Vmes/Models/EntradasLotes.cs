using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class EntradasLotes
	{

		[Key]
		public int id { get; set; }

		public int? IdEntradasLineas { get; set; }

		public int? IdLote { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Cantidad { get; set; }

		[StringLength(50)]
		public string LoteProveedor { get; set; }

		[Column(TypeName = "date")]
		public DateTime? FCaducidad { get; set; }

		public bool Exportado { get; set; }

		[ForeignKey(nameof(IdEntradasLineas))]
		[InverseProperty(nameof(EntradasLineas.EntradasLotes))]
		public virtual EntradasLineas IdEntradasLineasNavigation { get; set; }

		[ForeignKey(nameof(IdLote))]
		[InverseProperty(nameof(Lotes.EntradasLotes))]
		public virtual Lotes IdLoteNavigation { get; set; }

	}

}
