using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class NetAlarmasTiposConfiguration : IEntityTypeConfiguration<NetAlarmasTipos>
	{

		public void Configure(EntityTypeBuilder<NetAlarmasTipos> entityTypeBuilder)
		{
			entityTypeBuilder.HasData(
				new NetAlarmasTipos
				{
					AutoFinalizar = false,
					Id = 2050,
					IdPlc = NetAlarmasType.ComprobacionOrigenVacio,
					MostrarUsuario = true,
					Nivel = null,
					OEETipo = null,
					RolShow = null,
					TextoError = "Comprobacion Origen Vacio",
					UserShow = null,
				}
			);
			entityTypeBuilder.Property(x => x.AutoFinalizar)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.OEETipo)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasOne(x => x.RolShowNavigation)
				.WithMany(x => x.NetAlarmasTipos)
				.HasForeignKey(x => x.RolShow)
				.HasConstraintName("FK_NetAlarmasTipos_UsuariosRoles");
			entityTypeBuilder.HasOne(x => x.UserShowNavigation)
				.WithMany(x => x.NetAlarmasTipos)
				.HasForeignKey(x => x.UserShow)
				.HasConstraintName("FK_NetAlarmasTipos_Usuarios");
		}

	}

}
