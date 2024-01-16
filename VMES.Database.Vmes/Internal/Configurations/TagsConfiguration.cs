using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class TagsConfiguration : IEntityTypeConfiguration<Tags>
	{

		public void Configure(EntityTypeBuilder<Tags> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.OpcEntradaAlmacen)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasOne(x => x.UbicacionNavigation)
				.WithMany(x => x.Tags)
				.HasForeignKey(x => x.Ubicacion)
				.HasConstraintName("FK_Tags_Ubicaciones");
			entityTypeBuilder.HasOne(x => x.idLecturaTagNavigation)
				.WithMany(x => x.Tags)
				.HasForeignKey(x => x.idLecturaTag)
				.HasConstraintName("FK_Tags_TagsLecturas");
			entityTypeBuilder.HasOne(x => x.idModuloNavigation)
				.WithMany(x => x.Tags)
				.HasForeignKey(x => x.idModulo)
				.HasConstraintName("FK_Tags_Modulos");
		}

	}

}
