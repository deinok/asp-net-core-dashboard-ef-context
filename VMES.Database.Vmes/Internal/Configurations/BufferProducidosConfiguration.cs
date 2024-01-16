using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BufferProducidosConfiguration : IEntityTypeConfiguration<BufferProducidos>
	{

		public void Configure(EntityTypeBuilder<BufferProducidos> entityTypeBuilder)
		{
			entityTypeBuilder.HasIndex(x => x.FinalMedidor)
				.HasName("_dta_index_BufferProducidos_1");
			entityTypeBuilder.Property(x => x.FechaRecibido)
				.HasDefaultValueSql("(getdate())");
			entityTypeBuilder.Property(x => x.FechaProducido)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.FechaRecibido)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.FechaTratado)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.HasOne(x => x.OpcConfig)
				.WithMany(x => x.BufferProducidos)
				.HasForeignKey(x => x.OpcConfigId)
				.HasConstraintName("FK__BufferPro__OpcCo__66D536B1");
		}

	}

}
