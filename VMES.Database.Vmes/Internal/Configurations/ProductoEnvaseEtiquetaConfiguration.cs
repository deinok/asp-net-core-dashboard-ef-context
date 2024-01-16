using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class ProductoEnvaseEtiquetaConfiguration : IEntityTypeConfiguration<ProductoEnvaseEtiqueta>
	{

		public void Configure(EntityTypeBuilder<ProductoEnvaseEtiqueta> entityTypeBuilder)
		{
			entityTypeBuilder.HasKey(x => new { x.ProductoId, x.EnvaseId });
		}

	}

}
