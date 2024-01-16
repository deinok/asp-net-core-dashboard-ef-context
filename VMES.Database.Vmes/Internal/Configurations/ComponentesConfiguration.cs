using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class ComponentesConfiguration : IEntityTypeConfiguration<Componentes>
	{

		public void Configure(EntityTypeBuilder<Componentes> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.Orden)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PausaPosteriorDosificacion)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasOne(x => x.FormatoNavigation)
				.WithMany(x => x.Componentes)
				.HasForeignKey(x => x.Formato)
				.HasConstraintName("FK_Componentes_Formatos");
			entityTypeBuilder.HasOne(x => x.IdTempControlNavigation)
				.WithMany(x => x.Componentes)
				.HasForeignKey(x => x.IdTempControl)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Componentes_TempControles");
			entityTypeBuilder.HasOne(x => x.MedidorNavigation)
				.WithMany(x => x.Componentes)
				.HasForeignKey(x => x.Medidor)
				.HasConstraintName("FK_Componentes_Medidores");
			entityTypeBuilder.HasOne(x => x.ModuloNavigation)
				.WithMany(x => x.Componentes)
				.HasForeignKey(x => x.Modulo)
				.HasConstraintName("FK_Componentes_Modulos");
			entityTypeBuilder.HasOne(x => x.OperAccionNavigation)
				.WithMany(x => x.Componentes)
				.HasForeignKey(x => x.OperAccion)
				.HasConstraintName("FK_Componentes_OperAcciones");
			entityTypeBuilder.HasOne(x => x.OperMotorNavigation)
				.WithMany(x => x.Componentes)
				.HasForeignKey(x => x.OperMotor)
				.HasConstraintName("FK_Componentes_OperMotores");
			entityTypeBuilder.HasOne(x => x.ProductoNavigation)
				.WithMany(x => x.Componentes)
				.HasForeignKey(x => x.Producto)
				.HasConstraintName("FK_Componentes_Productos");
			entityTypeBuilder.HasOne(x => x.UnidadNavigation)
				.WithMany(x => x.Componentes)
				.HasForeignKey(x => x.Unidad)
				.HasConstraintName("FK_Componentes_Unidades");
			entityTypeBuilder.HasOne(x => x.idPlantillaNavigation)
				.WithMany(x => x.Componentes)
				.HasForeignKey(x => x.idPlantilla)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Componentes_OperCabPlantillas");
		}

	}

}
