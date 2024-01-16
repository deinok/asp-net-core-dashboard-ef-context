using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class CaudalConfiguration : IEntityTypeConfiguration<Caudal>
	{

		public void Configure(EntityTypeBuilder<Caudal> entityTypeBuilder)
		{
			entityTypeBuilder.HasKey(x => new { x.ProductoId, x.UbicacionId })
				.HasName("PK__Caudales__E533DB7E003CA3A8");
			entityTypeBuilder.HasOne(x => x.Producto)
				.WithMany(x => x.Caudales)
				.HasForeignKey(x => x.ProductoId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Caudales__Produc__6F6A7CB2");
			entityTypeBuilder.HasOne(x => x.Ubicacion)
				.WithMany(x => x.Caudales)
				.HasForeignKey(x => x.UbicacionId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Caudales__Ubicac__15B0212B");
			entityTypeBuilder.Property(x => x.PorcentajeAjusteAutomaticoMaximo)
				.HasDefaultValueSql("5");
			entityTypeBuilder.Property(x => x.PorcentajeAjusteMaximo)
				.HasDefaultValueSql("10");
		}

	}

}
