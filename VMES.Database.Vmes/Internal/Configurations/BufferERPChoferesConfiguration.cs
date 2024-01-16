using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BufferERPChoferesConfiguration : IEntityTypeConfiguration<BufferERPChoferes>
	{

		public void Configure(EntityTypeBuilder<BufferERPChoferes> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.FechaInsercion)
				.HasDefaultValueSql("(getdate())");
			entityTypeBuilder.Property(x => x.Timestamp)
				.HasDefaultValueSql("(getdate())");
		}

	}

}
