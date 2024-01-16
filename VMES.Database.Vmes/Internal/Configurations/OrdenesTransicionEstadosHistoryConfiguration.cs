using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class OrdenesTransicionEstadosHistoryConfiguration : IEntityTypeConfiguration<OrdenesTransicionEstadosHistory>
	{

		public void Configure(EntityTypeBuilder<OrdenesTransicionEstadosHistory> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.FinValidez)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.InicioValidez)
				.HasConversion(
					x => x.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				)
				.HasDefaultValueSql("(getdate())");
		}

	}

}
