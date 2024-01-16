using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BufferERPComponentesConfiguration : IEntityTypeConfiguration<BufferERPComponentes>
	{

		public void Configure(EntityTypeBuilder<BufferERPComponentes> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.AddVersionActiva)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.FechaInsercion)
				.HasDefaultValueSql("(getdate())");
			entityTypeBuilder.Property(x => x.Orden)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PausaPosteriorDosificacion)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasOne(x => x.idVersionNavigation)
				.WithMany(x => x.BufferERPComponentes)
				.HasForeignKey(x => x.idVersion)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK_BufferERPComponentes_BufferERPVersiones");
		}

	}

}
