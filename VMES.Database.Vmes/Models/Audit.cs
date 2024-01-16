using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Audit
	{

		[Key]
		public int Id { get; set; }

		public DateTime Timestamp { get; set; }

		[Required]
		[StringLength(256)]
		public string Hostname { get; set; }

		public string StackTrace { get; set; }

		[StringLength(64)]
		public string User { get; set; }

		[StringLength(64)]
		public string Ip { get; set; }

		[StringLength(64)]
		public string Mac { get; set; }

		[InverseProperty(nameof(AuditTable.Audit))]
		public virtual ICollection<AuditTable> AuditTables { get; set; } = new HashSet<AuditTable>();

	}

}
