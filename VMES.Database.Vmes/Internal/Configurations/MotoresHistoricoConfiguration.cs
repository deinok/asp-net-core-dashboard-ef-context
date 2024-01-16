using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class MotoresHistoricoConfiguration : IEntityTypeConfiguration<MotoresHistorico>
	{

		public void Configure(EntityTypeBuilder<MotoresHistorico> entityTypeBuilder)
		{
			entityTypeBuilder.HasKey(x => new { x.MotorId, x.Timestamp });
			entityTypeBuilder.Property(x => x.Timestamp)
				.HasConversion(
					x => x.ToUniversalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Utc)
				);
		}

	}

}
