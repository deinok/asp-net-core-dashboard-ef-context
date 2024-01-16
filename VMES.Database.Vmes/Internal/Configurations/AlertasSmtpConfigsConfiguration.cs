using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class AlertasSmtpConfigsConfiguration : IEntityTypeConfiguration<AlertasSmtpConfigs>
	{

		public void Configure(EntityTypeBuilder<AlertasSmtpConfigs> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.smtpSSL)
				.HasDefaultValueSql("((0))");
		}

	}

}
