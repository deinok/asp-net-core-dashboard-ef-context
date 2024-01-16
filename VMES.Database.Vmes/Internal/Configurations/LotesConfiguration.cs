using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class LotesConfiguration : IEntityTypeConfiguration<Lotes>
	{

		public void Configure(EntityTypeBuilder<Lotes> entityTypeBuilder)
		{
			entityTypeBuilder.HasIndex(x => new { x.Producto, x.Fecha })
				.HasName("ILotesProdFecha");
			entityTypeBuilder.Property(x => x.NombreEnCodBarras)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasOne(x => x.FormatoNavigation)
				.WithMany(x => x.Lotes)
				.HasForeignKey(x => x.Formato)
				.HasConstraintName("FK_Lotes_Formatos");
			entityTypeBuilder.HasOne(x => x.IdProveedorNavigation)
				.WithMany(x => x.Lotes)
				.HasForeignKey(x => x.IdProveedor)
				.HasConstraintName("FK_Lotes_Proveedores");
			entityTypeBuilder.HasOne(x => x.MedicacionNavigation)
				.WithMany(x => x.Lotes)
				.HasForeignKey(x => x.Medicacion)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Lotes_Medicaciones");
			entityTypeBuilder.HasOne(x => x.ProductoNavigation)
				.WithMany(x => x.Lotes)
				.HasForeignKey(x => x.Producto)
				.HasConstraintName("FK_Lotes_Productos");
		}

	}

}
