using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class InformesLibCategoriasConfiguration : IEntityTypeConfiguration<InformesLibCategorias>
	{

		public void Configure(EntityTypeBuilder<InformesLibCategorias> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.isModificable)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.isVisible)
				.HasDefaultValueSql("((1))");
		}

	}

}
