using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class UbicacionesOpcConfigConfiguration : IEntityTypeConfiguration<UbicacionesOpcConfig>
	{

		public void Configure(EntityTypeBuilder<UbicacionesOpcConfig> entityTypeBuilder)
		{
			entityTypeBuilder.HasKey(x => new { x.UbicacionId, x.OpcConfigId, x.IdPlc });
			entityTypeBuilder.HasOne(x => x.OpcConfig)
				.WithMany(x => x.UbicacionesOpcConfig)
				.HasForeignKey(x => x.OpcConfigId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_UbicacionesOpcConfig_OpcConfig");
			entityTypeBuilder.HasOne(x => x.Ubicacion)
				.WithMany(x => x.UbicacionesOpcConfig)
				.HasForeignKey(x => x.UbicacionId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_UbicacionesOpcConfig_Ubicacion");
		}

	}

}
