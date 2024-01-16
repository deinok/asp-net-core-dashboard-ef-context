using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class PrinterConfiguration : IEntityTypeConfiguration<Printer>
	{

		public void Configure(EntityTypeBuilder<Printer> entityTypeBuilder)
		{
			entityTypeBuilder.HasDiscriminator(x => x.Type)
				.HasValue<Printer>(PrinterType.Undefined)
				.HasValue<Printer.IPPPrinter>(PrinterType.IPP)
				.HasValue<Printer.WindowsPrinter>(PrinterType.Windows);
		}

	}

}
