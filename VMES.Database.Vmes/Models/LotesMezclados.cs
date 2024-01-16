using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class LotesMezclados
	{

		[Key]
		public int id { get; set; }

		public int? idLoteNuevo { get; set; }

		public int? idLoteOrigen { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[Column(TypeName = "numeric(18, 5)")]
		public decimal? Cantidad { get; set; }

		[Column(TypeName = "decimal(15, 5)")]
		public decimal? CantidadActual { get; set; }

		[ForeignKey(nameof(idLoteNuevo))]
		[InverseProperty(nameof(Lotes.LotesMezcladosidLoteNuevoNavigation))]
		public virtual Lotes idLoteNuevoNavigation { get; set; }

		[ForeignKey(nameof(idLoteOrigen))]
		[InverseProperty(nameof(Lotes.LotesMezcladosidLoteOrigenNavigation))]
		public virtual Lotes idLoteOrigenNavigation { get; set; }

	}

}
