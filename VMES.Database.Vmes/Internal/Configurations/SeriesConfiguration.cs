using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class SeriesConfiguration : IEntityTypeConfiguration<Series>
	{

		public void Configure(EntityTypeBuilder<Series> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.ContadorAlbaranes)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.ContadorCertificadoDesinfeccion)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.ContadorCompras)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.ContadorEntradas)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.ContadorOrdenes)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.ContadorRecetas)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.ContadorSalidas)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.ContadorVentas)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.ContadorViajes)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.Fecha)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
		}

	}

}
