using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class AlertasUsuariosInformesConfiguration : IEntityTypeConfiguration<AlertasUsuariosInformes>
	{

		public void Configure(EntityTypeBuilder<AlertasUsuariosInformes> entityTypeBuilder)
		{
			entityTypeBuilder.HasOne(x => x.idAlertasUsuariosNavigation)
				.WithMany(x => x.AlertasUsuariosInformes)
				.HasForeignKey(x => x.idAlertasUsuarios)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK_AlertasUsuariosInformes_AlertasUsuarios");
		}

	}

}
