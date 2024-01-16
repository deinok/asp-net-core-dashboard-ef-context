using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class InformesLibConfiguration : IEntityTypeConfiguration<InformesLib>
	{

		public void Configure(EntityTypeBuilder<InformesLib> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.VisibleUsuario)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.HasOne(x => x.IdCategoriaNavigation)
				.WithMany(x => x.InformesLib)
				.HasForeignKey(x => x.IdCategoria)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_InformesLib_InformesLibCategorias");
			entityTypeBuilder.HasOne(x => x.IdInformeBaseNavigation)
				.WithMany(x => x.InverseIdInformeBaseNavigation)
				.HasForeignKey(x => x.IdInformeBase)
				.HasConstraintName("FK_InformesLib_InformesLib");
		}

	}

}
