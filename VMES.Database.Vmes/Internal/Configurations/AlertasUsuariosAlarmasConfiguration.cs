using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class AlertasUsuariosAlarmasConfiguration : IEntityTypeConfiguration<AlertasUsuariosAlarmas>
	{

		public void Configure(EntityTypeBuilder<AlertasUsuariosAlarmas> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.ActivoMail)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.ActivoSMS)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasOne(x => x.idAlertaUsuarioNavigation)
				.WithMany(x => x.AlertasUsuariosAlarmas)
				.HasForeignKey(x => x.idAlertaUsuario)
				.HasConstraintName("FK_AlertasUsuariosAlarmas_AlertasUsuarios");
			entityTypeBuilder.HasOne(x => x.idModuloNavigation)
				.WithMany(x => x.AlertasUsuariosAlarmas)
				.HasForeignKey(x => x.idModulo)
				.HasConstraintName("FK_AlertasUsuariosAlarmas_Modulos");
			entityTypeBuilder.HasOne(x => x.idNetAlarmaTipoNavigation)
				.WithMany(x => x.AlertasUsuariosAlarmas)
				.HasForeignKey(x => x.idNetAlarmaTipo)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_AlertasUsuariosAlarmas_NetAlarmasTipos");
		}

	}

}
