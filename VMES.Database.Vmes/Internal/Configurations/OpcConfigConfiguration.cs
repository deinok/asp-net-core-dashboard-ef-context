using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class OpcConfigConfiguration : IEntityTypeConfiguration<OpcConfig>
	{

		public void Configure(EntityTypeBuilder<OpcConfig> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.DiscoveryUrl)
				.HasConversion(
					x => x.AbsoluteUri,
					x => new Uri(x)
				);
			entityTypeBuilder.Property(x => x.EndpointUrl)
				.HasConversion(
					x => x.AbsoluteUri,
					x => new Uri(x)
				);
			entityTypeBuilder.Property(x => x.BitVida)
				.HasConversion(
					x => x.Value.ToUniversalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Utc)
				);
		}

	}

}
