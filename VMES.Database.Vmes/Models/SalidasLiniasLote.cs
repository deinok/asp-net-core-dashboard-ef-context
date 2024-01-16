using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class SalidasLiniasLote
	{

		[Key]
		public int id { get; set; }

		public int? idLineaSalida { get; set; }

		public int? idLineaSalidaMedicamento { get; set; }

		public int? idLote { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Cantidad { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public bool Exportado { get; set; }

		[ForeignKey(nameof(idLineaSalidaMedicamento))]
		[InverseProperty(nameof(SalidasLiniasMedicaciones.SalidasLiniasLote))]
		public virtual SalidasLiniasMedicaciones idLineaSalidaMedicamentoNavigation { get; set; }

		[ForeignKey(nameof(idLineaSalida))]
		[InverseProperty(nameof(SalidasLinias.SalidasLiniasLote))]
		public virtual SalidasLinias idLineaSalidaNavigation { get; set; }

		[ForeignKey(nameof(idLote))]
		[InverseProperty(nameof(Lotes.SalidasLiniasLote))]
		public virtual Lotes idLoteNavigation { get; set; }

	}

}
