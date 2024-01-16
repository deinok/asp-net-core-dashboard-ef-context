using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class AuditConfiguration : IEntityTypeConfiguration<Audit>
	{

		public void Configure(EntityTypeBuilder<Audit> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.Timestamp)
				.HasConversion(
					x => x.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
		}

	}

}
