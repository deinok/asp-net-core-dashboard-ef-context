using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class ModuloEstadoComunicacionesConfiguration : IEntityTypeConfiguration<ModuloEstadoComunicaciones>
	{

		public void Configure(EntityTypeBuilder<ModuloEstadoComunicaciones> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.UltimaActualizacionIntegraModulo)
				.HasConversion(
					x => x.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.UltimaActualizacionIntegraServer)
				.HasConversion(
					x => x.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
		}

	}

}
