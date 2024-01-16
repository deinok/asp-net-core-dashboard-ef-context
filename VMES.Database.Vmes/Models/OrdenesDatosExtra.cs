using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class OrdenesDatosExtra
	{

		[Key]
		public int id { get; set; }

		[Column(TypeName = "decimal(18, 4)")]
		public decimal? KWConsumidosTotal { get; set; }

		[Column(TypeName = "decimal(18, 4)")]
		public decimal? KWProducidosTotal { get; set; }

		[Column(TypeName = "decimal(19, 4)")]
		public decimal? KWTotal { get; set; }

		[Column(TypeName = "decimal(18, 4)")]
		public decimal? KWConsumidosEfectivo { get; set; }

		[Column(TypeName = "decimal(18, 4)")]
		public decimal? KWProducidosEfectivo { get; set; }

		[Column(TypeName = "decimal(19, 4)")]
		public decimal? KWEfectivo { get; set; }

		[Column(TypeName = "decimal(18, 4)")]
		public decimal? CantidadProducida { get; set; }

		[Column(TypeName = "decimal(18, 6)")]
		public decimal? KWEfectivoTonelada { get; set; }

		[Column(TypeName = "decimal(18, 6)")]
		public decimal? KWTotalTonelada { get; set; }

		[ForeignKey(nameof(id))]
		[InverseProperty(nameof(Ordenes.OrdenesDatosExtra))]
		public virtual Ordenes idNavigation { get; set; }

	}

}
