using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BufferERPSolicitudTraspasoConfiguration : IEntityTypeConfiguration<BufferERPSolicitudTraspaso>
	{

		public void Configure(EntityTypeBuilder<BufferERPSolicitudTraspaso> entityTypeBuilder)
		{
			entityTypeBuilder.HasOne(x => x.Destino)
				.WithMany(x => x.BufferERPSolicitudTraspasoDestinos)
				.OnDelete(DeleteBehavior.NoAction);
			entityTypeBuilder.HasOne(x => x.Origen)
				.WithMany(x => x.BufferERPSolicitudTraspasoOrigenes)
				.OnDelete(DeleteBehavior.NoAction);
		}

	}

}
