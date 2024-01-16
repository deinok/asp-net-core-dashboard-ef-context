using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BufferERPEntradasLineasConfiguration : IEntityTypeConfiguration<BufferERPEntradasLineas>
	{

		public void Configure(EntityTypeBuilder<BufferERPEntradasLineas> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.FechaInsercion)
				.HasDefaultValueSql("(getdate())");
			entityTypeBuilder.HasOne(x => x.idBufferEntradaNavigation)
				.WithMany(x => x.BufferERPEntradasLineas)
				.HasForeignKey(x => x.idBufferEntrada)
				.HasConstraintName("FK_BufferERPEntradasLineas_BufferERPEntradas");
		}

	}

}
