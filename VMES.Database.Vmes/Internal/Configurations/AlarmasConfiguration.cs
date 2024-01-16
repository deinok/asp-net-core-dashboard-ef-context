using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class AlarmasConfiguration : IEntityTypeConfiguration<Alarmas>
	{

		public void Configure(EntityTypeBuilder<Alarmas> entityTypeBuilder)
		{
			entityTypeBuilder.HasOne(x => x.MedidorNavigation)
				.WithMany(x => x.Alarmas)
				.HasForeignKey(x => x.Medidor)
				.HasConstraintName("FK_Alarmas_Medidores");
		}

	}

}
