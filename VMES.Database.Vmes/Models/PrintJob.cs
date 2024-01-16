using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class PrintJob
	{

		[Key]
		public Guid Id { get; set; }

		public Guid PrinterId { get; set; }

		public PrintJobStatus Status { get; set; }

		public DateTimeOffset Timestamp { get; set; }

		public int Copies { get; set; }

		[Required]
		public byte[] Content { get; set; }

		[ForeignKey(nameof(PrinterId))]
		[InverseProperty(nameof(Printer.PrintJobs))]
		public virtual Printer Printer { get; set; }

	}

}
