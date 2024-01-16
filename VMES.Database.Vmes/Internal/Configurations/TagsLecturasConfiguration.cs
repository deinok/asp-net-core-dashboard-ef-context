using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class TagsLecturasConfiguration : IEntityTypeConfiguration<TagsLecturas>
	{

		public void Configure(EntityTypeBuilder<TagsLecturas> entityTypeBuilder)
		{
			entityTypeBuilder.HasIndex(x => new { x.Tratado, x.idTag, x.FTratado })
				.HasName("BusquedaTagsLecturas");
			entityTypeBuilder.Property(x => x.FRecibido)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.FTratado)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.Tratado)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasOne(x => x.idTagNavigation)
				.WithMany(x => x.TagsLecturas)
				.HasForeignKey(x => x.idTag)
				.HasConstraintName("FK_TagsLecturas_Tags");
		}

	}

}
