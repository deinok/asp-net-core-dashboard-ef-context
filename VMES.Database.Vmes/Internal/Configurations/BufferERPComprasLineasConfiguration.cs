using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BufferERPComprasLineasConfiguration : IEntityTypeConfiguration<BufferERPComprasLineas>
	{

		public void Configure(EntityTypeBuilder<BufferERPComprasLineas> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.FechaInsercion)
				.HasDefaultValueSql("(getdate())");
			entityTypeBuilder.HasOne(x => x.Compra)
				.WithMany(x => x.BufferERPComprasLineas)
				.HasForeignKey(x => x.CompraId)
				.HasConstraintName("FK_BufferERPComprasLineas_BufferERPCompras");
		}

	}

}
