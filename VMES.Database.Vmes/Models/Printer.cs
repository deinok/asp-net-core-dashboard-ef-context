using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Printer
	{

		[Key]
		public Guid Id { get; set; }

		[Required]
		[StringLength(64)]
		public string Name { get; set; }

		public PrinterType Type { get; set; }

		[InverseProperty(nameof(InformesLib.DefaultPrinter))]
		public virtual ICollection<InformesLib> InformeLibs { get; set; }

		[InverseProperty(nameof(InformesLibUsuarios.DefaultPrinter))]
		public virtual ICollection<InformesLibUsuarios> InformeLibUsuarios { get; set; }

		[InverseProperty(nameof(PrintJob.Printer))]
		public virtual ICollection<PrintJob> PrintJobs { get; set; }

		public class IPPPrinter : Printer
		{

			[Required]
			[StringLength(64)]
			public Uri Url { get; set; }

		}

		public class WindowsPrinter : Printer
		{

			[Required]
			[StringLength(64)]
			public string WindowsName { get; set; }

		}

	}

}
