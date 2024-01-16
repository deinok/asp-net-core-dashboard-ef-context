using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class MedidorConfiguration : IEntityTypeConfiguration<Medidor>
	{

		public void Configure(EntityTypeBuilder<Medidor> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.AutoAlarmaDestinoDeshabilitado)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.AutoAlarmaOrigenDeshabilitado)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.Obligatorio)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasOne(x => x.FamiliaMedidorNavigation)
				.WithMany(x => x.Medidores)
				.HasForeignKey(x => x.FamiliaMedidor)
				.HasConstraintName("FK_Medidores_FamiliasMedidor");
			entityTypeBuilder.HasOne(x => x.IdBasculaNavigation)
				.WithMany(x => x.Medidores)
				.HasForeignKey(x => x.IdBascula)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Medidores_Basculas");
			entityTypeBuilder.HasOne(x => x.ModuloNavigation)
				.WithMany(x => x.Medidores)
				.HasForeignKey(x => x.ModuloId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK_Medidores_Modulos");
			entityTypeBuilder.HasOne(x => x.idPlantillaOcultaNavigation)
				.WithMany(x => x.Medidores)
				.HasForeignKey(x => x.idPlantillaOculta)
				.HasConstraintName("FK_Medidores_OperCabPlantillas");
		}

	}

}
