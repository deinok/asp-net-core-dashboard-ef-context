using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class TarjetasConfiguration : IEntityTypeConfiguration<Tarjetas>
	{

		public void Configure(EntityTypeBuilder<Tarjetas> entityTypeBuilder)
		{
			entityTypeBuilder.HasOne(x => x.EntradaLinea)
				.WithMany(x => x.Tarjetas)
				.HasForeignKey(x => x.EntradaLineaId)
				.HasConstraintName("FK_Tarjetas_EntradasLineas");
			entityTypeBuilder.HasOne(x => x.SalidaLinea)
				.WithMany(x => x.Tarjetas)
				.HasForeignKey(x => x.SalidaLineaId)
				.HasConstraintName("FK_Tarjetas_SalidasLinias");
			entityTypeBuilder.HasOne(x => x.OrdenActual)
				.WithMany(x => x.Tarjetas)
				.HasForeignKey(x => x.OrdenActualId)
				.HasConstraintName("FK_Tarjetas_ordenes");
		}

	}

}
