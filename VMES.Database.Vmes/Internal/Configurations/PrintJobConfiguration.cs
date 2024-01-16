using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class PrintJobConfiguration : IEntityTypeConfiguration<PrintJob>
	{

		public void Configure(EntityTypeBuilder<PrintJob> entityTypeBuilder)
		{
		}

	}

}
