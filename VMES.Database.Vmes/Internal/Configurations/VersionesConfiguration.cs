using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class VersionesConfiguration : IEntityTypeConfiguration<Versiones>
	{

		public void Configure(EntityTypeBuilder<Versiones> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.comentarios)
				.IsUnicode(false);
			entityTypeBuilder.HasOne(x => x.UnidadNavigation)
				.WithMany(x => x.Versiones)
				.HasForeignKey(x => x.Unidad)
				.HasConstraintName("FK_Versiones_Unidades");
		}

	}

}
