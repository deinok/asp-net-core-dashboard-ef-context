using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class ProductoMedidorCaminoConfiguration : IEntityTypeConfiguration<ProductoMedidorCamino>
	{

		public void Configure(EntityTypeBuilder<ProductoMedidorCamino> entityTypeBuilder)
		{
			entityTypeBuilder.HasIndex(x => new
			{
				x.CaminoId,
				x.MedidorId,
				x.ProductoId,
			})
			.IsUnique();
			entityTypeBuilder.Property(x => x.FechaCreacion)
				.HasConversion(
					x => x.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				)
				.HasDefaultValueSql("GETDATE()");
			entityTypeBuilder.Property(x => x.FechaEdicion)
				.HasConversion(
					x => x.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				)
				.HasDefaultValueSql("GETDATE()")
				.ValueGeneratedOnAddOrUpdate();
		}

	}

}
