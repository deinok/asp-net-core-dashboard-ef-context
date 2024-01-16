using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class CaminoConfiguration : IEntityTypeConfiguration<Camino>
	{

		public void Configure(EntityTypeBuilder<Camino> entityTypeBuilder)
		{
			entityTypeBuilder.HasOne(x => x.Medidor)
				.WithMany(x => x.Caminos)
				.HasForeignKey(x => x.MedidorId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Caminos_Medidores");
		}

	}

}
