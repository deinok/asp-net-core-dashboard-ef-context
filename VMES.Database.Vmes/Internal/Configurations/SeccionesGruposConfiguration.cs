using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class SeccionesGruposConfiguration : IEntityTypeConfiguration<SeccionesGrupos>
	{

		public void Configure(EntityTypeBuilder<SeccionesGrupos> entityTypeBuilder)
		{
			entityTypeBuilder.HasOne(x => x.OpcConfig)
				.WithMany(x => x.SeccionesGrupos)
				.HasForeignKey(x => x.OpcConfigId)
				.HasConstraintName("FK__Secciones__OpcCo__7A3D10E0");
		}

	}

}
