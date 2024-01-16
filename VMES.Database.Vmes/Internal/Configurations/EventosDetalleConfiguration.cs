using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class EventosDetalleConfiguration : IEntityTypeConfiguration<EventosDetalle>
	{

		public void Configure(EntityTypeBuilder<EventosDetalle> entityTypeBuilder)
		{
			entityTypeBuilder.HasIndex(x => x.Evento)
				.HasName("_dta_index_EventosDetalle_1");
			entityTypeBuilder.HasOne(x => x.EventoNavigation)
				.WithMany(x => x.EventosDetalle)
				.HasForeignKey(x => x.Evento)
				.HasConstraintName("FK_EventosDetalle_Eventos");
		}

	}

}
