using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BufferConsumidosConfiguration : IEntityTypeConfiguration<BufferConsumidos>
	{

		public void Configure(EntityTypeBuilder<BufferConsumidos> entityTypeBuilder)
		{
			entityTypeBuilder.HasIndex(x => new { x.Tratado, x.ModuloId })
				.HasName("NonClusteredIndex-20210719-021448");
			entityTypeBuilder.Property(x => x.FechaRecibido)
				.HasDefaultValueSql("(getdate())");
			entityTypeBuilder.Property(x => x.FechaConsumido)
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
				.WithMany(x => x.BufferConsumidos)
				.HasForeignKey(x => x.OpcConfigId)
				.HasConstraintName("FK__BufferCon__OpcCo__569ECEE8");
		}

	}

}
