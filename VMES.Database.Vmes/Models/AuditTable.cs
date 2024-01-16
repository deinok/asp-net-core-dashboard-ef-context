using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VMES.Database.Vmes.Models
{

	public class AuditTable
	{

		[Key]
		public int Id { get; set; }

		public int AuditId { get; set; }

		[Required]
		[StringLength(128)]
		public string Table { get; set; }

		public EntityState State { get; set; }

		[ForeignKey(nameof(AuditId))]
		[InverseProperty(nameof(Models.Audit.AuditTables))]
		public virtual Audit Audit { get; set; }

		[InverseProperty(nameof(AuditColumn.AuditTable))]
		public virtual ICollection<AuditColumn> AuditColumns { get; set; } = new HashSet<AuditColumn>();

	}

}
