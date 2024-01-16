using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class ElectrovalvulaConfiguration : IEntityTypeConfiguration<Electrovalvula>
	{

		public void Configure(EntityTypeBuilder<Electrovalvula> entityTypeBuilder)
		{
			entityTypeBuilder.HasOne(x => x.OpcConfig)
				.WithMany(x => x.Electrovalvulas)
				.HasForeignKey(x => x.OpcConfigId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Electrovalvulas_OpcConfig");
		}

	}

}
