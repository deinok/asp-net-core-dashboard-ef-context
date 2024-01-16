using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BufferERPConsumidosConfiguration : IEntityTypeConfiguration<BufferERPConsumidos>
	{

		public void Configure(EntityTypeBuilder<BufferERPConsumidos> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.FechaInsercion)
				.HasDefaultValueSql("(getdate())");
			entityTypeBuilder.Property(x => x.Tratado)
				.HasDefaultValueSql("((0))");
		}

	}

}
