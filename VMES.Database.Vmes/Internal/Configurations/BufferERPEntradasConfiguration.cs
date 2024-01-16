using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BufferERPEntradasConfiguration : IEntityTypeConfiguration<BufferERPEntradas>
	{

		public void Configure(EntityTypeBuilder<BufferERPEntradas> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.FechaInsercion)
				.HasDefaultValueSql("(getdate())");
			entityTypeBuilder.Property(x => x.Preparado2)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.exportado)
				.HasDefaultValueSql("((0))");
		}

	}

}
