using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class TarjetasConfiguration : IEntityTypeConfiguration<Tarjetas>
	{

		public void Configure(EntityTypeBuilder<Tarjetas> entityTypeBuilder)
		{
			entityTypeBuilder.HasOne(x => x.IdLinEntradaNavigation)
				.WithMany(x => x.Tarjetas)
				.HasForeignKey(x => x.IdLinEntrada)
				.HasConstraintName("FK_Tarjetas_EntradasLineas");
			entityTypeBuilder.HasOne(x => x.IdLinSalidaNavigation)
				.WithMany(x => x.Tarjetas)
				.HasForeignKey(x => x.IdLinSalida)
				.HasConstraintName("FK_Tarjetas_SalidasLinias");
			entityTypeBuilder.HasOne(x => x.IdOrdenActualNavigation)
				.WithMany(x => x.Tarjetas)
				.HasForeignKey(x => x.IdOrdenActual)
				.HasConstraintName("FK_Tarjetas_ordenes");
		}

	}

}
