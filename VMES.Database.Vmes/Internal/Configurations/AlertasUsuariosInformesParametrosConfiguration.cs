using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class AlertasUsuariosInformesParametrosConfiguration : IEntityTypeConfiguration<AlertasUsuariosInformesParametros>
	{

		public void Configure(EntityTypeBuilder<AlertasUsuariosInformesParametros> entityTypeBuilder)
		{
			entityTypeBuilder.HasOne(x => x.idAlertaUsuarioInformesNavigation)
				.WithMany(x => x.AlertasUsuariosInformesParametros)
				.HasForeignKey(x => x.idAlertaUsuarioInformes)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK_AlertasUsuariosInformesParametros_AlertasUsuariosInformes");
		}

	}

}
