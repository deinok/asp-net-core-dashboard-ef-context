using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class AuditColumn
	{

		[Key]
		public int Id { get; set; }

		public int AuditTableId { get; set; }

		[Required]
		[StringLength(128)]
		public string Column { get; set; }

		[StringLength(256)]
		public string OldValue { get; set; }

		[StringLength(256)]
		public string NewValue { get; set; }

		[ForeignKey(nameof(AuditTableId))]
		[InverseProperty(nameof(Models.AuditTable.AuditColumns))]
		public virtual AuditTable AuditTable { get; set; }

	}

}
