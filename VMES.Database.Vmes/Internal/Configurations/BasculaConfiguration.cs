using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BasculaConfiguration : IEntityTypeConfiguration<Bascula>
	{

		public void Configure(EntityTypeBuilder<Bascula> entityTypeBuilder)
		{
			entityTypeBuilder.HasDiscriminator(x => x.Type)
				.HasValue<Bascula>(BasculaType.Undefined)
				.HasValue<Bascula.BasculaPenko>(BasculaType.Penko)
				.HasValue<Bascula.BasculaPerle>(BasculaType.Perle);
			entityTypeBuilder.Property(x => x.CadenaPeticion)
				.IsUnicode(false);
			entityTypeBuilder.Property(x => x.GrabarEnPLC)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.LeerEnPLC)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.ModoTransmisionPeso)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.TiempoMaximoLectura)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.ToleranciaInferior)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.ToleranciaSuperior)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasOne(x => x.OpcConfig)
				.WithMany(x => x.Basculas)
				.OnDelete(DeleteBehavior.NoAction);
			entityTypeBuilder.Property(x => x.FLectura)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.FechaLecturaPeso)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
		}

	}

}
