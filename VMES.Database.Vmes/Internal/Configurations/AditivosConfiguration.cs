using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class AditivosConfiguration : IEntityTypeConfiguration<Aditivos>
	{

		public void Configure(EntityTypeBuilder<Aditivos> entityTypeBuilder)
		{
			entityTypeBuilder.HasOne(x => x.FormatoNavigation)
				.WithMany(x => x.Aditivos)
				.HasForeignKey(x => x.Formato)
				.HasConstraintName("FK_Aditivos_Formatos");
			entityTypeBuilder.HasOne(x => x.OrdenNavigation)
				.WithMany(x => x.Aditivos)
				.HasForeignKey(x => x.Orden)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Aditivos_Ordenes");
			entityTypeBuilder.HasOne(x => x.ProductoNavigation)
				.WithMany(x => x.Aditivos)
				.HasForeignKey(x => x.Producto)
				.HasConstraintName("FK_Aditivos_Productos");
			entityTypeBuilder.HasOne(x => x.UbicacionNavigation)
				.WithMany(x => x.Aditivos)
				.HasForeignKey(x => x.Ubicacion)
				.HasConstraintName("FK_Aditivos_Ubicaciones");
			entityTypeBuilder.HasOne(x => x.UnidadNavigation)
				.WithMany(x => x.Aditivos)
				.HasForeignKey(x => x.Unidad)
				.HasConstraintName("FK_Aditivos_Unidades");
		}

	}

}
