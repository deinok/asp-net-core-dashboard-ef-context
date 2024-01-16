using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_ElementReviewSettings
	{

		[Key]
		public int ElementId { get; set; }

		public bool RequiredReview { get; set; }

		public DateTime? LastReview { get; set; }

		public int? HoursUsageInterval { get; set; }

		public int? HoursServiceInterval { get; set; }

		public int? TotalAlarms { get; set; }

		[ForeignKey(nameof(ElementId))]
		[InverseProperty(nameof(GMAO_Elementos.GMAO_ElementReviewSettings))]
		public virtual GMAO_Elementos Element { get; set; }

	}

}
