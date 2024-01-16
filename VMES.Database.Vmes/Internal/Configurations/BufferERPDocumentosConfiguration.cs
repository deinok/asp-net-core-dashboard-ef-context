using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BufferERPDocumentosConfiguration : IEntityTypeConfiguration<BufferERPDocumentos>
	{

		public void Configure(EntityTypeBuilder<BufferERPDocumentos> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.FechaInsercion)
				.HasDefaultValueSql("(getdate())");
		}

	}

}
