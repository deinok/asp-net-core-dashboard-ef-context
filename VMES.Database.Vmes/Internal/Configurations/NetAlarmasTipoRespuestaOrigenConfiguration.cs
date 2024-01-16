using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class NetAlarmasTipoRespuestaOrigenConfiguration : IEntityTypeConfiguration<NetAlarmasTipoRespuestaOrigen>
	{

		public void Configure(EntityTypeBuilder<NetAlarmasTipoRespuestaOrigen> entityTypeBuilder)
		{
			entityTypeBuilder.HasOne(x => x.NetAlarmasRespuesta)
				.WithMany(x => x.NetAlarmasTiposRespuestasOrigenes)
				.OnDelete(DeleteBehavior.Cascade);
			entityTypeBuilder.HasOne(x => x.NetAlarmasTipo)
				.WithMany(x => x.NetAlarmasTiposRespuestasOrigenes)
				.OnDelete(DeleteBehavior.Cascade);
			entityTypeBuilder.HasOne(x => x.Origen)
				.WithMany(x => x.NetAlarmasTiposRespuestasOrigenes)
				.OnDelete(DeleteBehavior.Cascade);
		}

	}

}
