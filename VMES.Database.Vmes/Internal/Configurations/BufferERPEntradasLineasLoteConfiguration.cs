using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BufferERPEntradasLineasLoteConfiguration : IEntityTypeConfiguration<BufferERPEntradasLineasLote>
	{

		public void Configure(EntityTypeBuilder<BufferERPEntradasLineasLote> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.FechaInsercion)
				.HasDefaultValueSql("(getdate())");
			entityTypeBuilder.Property(x => x.Timestamp)
				.HasDefaultValueSql("(getdate())");
			entityTypeBuilder.HasOne(x => x.IdLineaEntradaNavigation)
				.WithMany(x => x.BufferERPEntradasLineasLote)
				.HasForeignKey(x => x.IdLineaEntrada)
				.HasConstraintName("FK_BufferERPEntradasLineasLote_BufferERPEntradasLineas");
		}

	}

}
