using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class InformesLibUsuariosConfiguration : IEntityTypeConfiguration<InformesLibUsuarios>
	{

		public void Configure(EntityTypeBuilder<InformesLibUsuarios> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.Habilitado)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.NumCopias)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.Visible)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.HasOne(x => x.IdInformeNavigation)
				.WithMany(x => x.InformesLibUsuarios)
				.HasForeignKey(x => x.IdInforme)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_InformesLibUsuarios_InformesLib");
			entityTypeBuilder.HasOne(x => x.IdUsuarioNavigation)
				.WithMany(x => x.InformesLibUsuarios)
				.HasForeignKey(x => x.IdUsuario)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_InformesLibUsuarios_Usuarios");
		}

	}

}
