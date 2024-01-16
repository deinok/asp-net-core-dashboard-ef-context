using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BufferERPCabOrdenesConfiguration : IEntityTypeConfiguration<BufferERPCabOrdenes>
	{

		public void Configure(EntityTypeBuilder<BufferERPCabOrdenes> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.FechaInsercion)
				.HasDefaultValueSql("(getdate())");
			entityTypeBuilder.Property(x => x.NumCiclos)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.Tratado)
				.HasDefaultValueSql("((0))");
		}

	}

}
