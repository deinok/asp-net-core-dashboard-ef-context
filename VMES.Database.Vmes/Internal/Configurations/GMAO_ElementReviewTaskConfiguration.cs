using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class GMAO_ElementReviewTaskConfiguration : IEntityTypeConfiguration<GMAO_ElementReviewTask>
	{

		public void Configure(EntityTypeBuilder<GMAO_ElementReviewTask> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.CreatedDate)
				.HasConversion(
					x => x.ToUniversalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Utc)
				)
				.HasDefaultValueSql("GETUTCDATE()");
			entityTypeBuilder.Property(x => x.UpdatedDate)
				.HasConversion(
					x => x.ToUniversalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Utc)
				)
				.HasDefaultValueSql("GETUTCDATE()");
			entityTypeBuilder.Property(x => x.ResetDate)
				.HasConversion(
					x => x.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				)
				.HasDefaultValueSql("GETDATE()");
		}

	}

}
