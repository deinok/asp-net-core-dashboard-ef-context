using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class EventosConfiguration : IEntityTypeConfiguration<Eventos>
	{

		public void Configure(EntityTypeBuilder<Eventos> entityTypeBuilder)
		{
			entityTypeBuilder.HasIndex(x => x.Elemento)
				.HasName("_dta_index_Eventos_1");
			entityTypeBuilder.Property(x => x.Fecha)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
		}

	}

}
