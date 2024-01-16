using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class AlertasUsuariosConfiguration : IEntityTypeConfiguration<AlertasUsuarios>
	{

		public void Configure(EntityTypeBuilder<AlertasUsuarios> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.Activo)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.smtpIsBodyHtml)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasOne(x => x.idServerSmtpNavigation)
				.WithMany(x => x.AlertasUsuarios)
				.HasForeignKey(x => x.idServerSmtp)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_AlertasUsuarios_AlertasSmtpConfigs");
		}

	}

}
