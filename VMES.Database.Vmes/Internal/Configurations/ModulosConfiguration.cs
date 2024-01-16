using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class ModulosConfiguration : IEntityTypeConfiguration<Modulos>
	{

		public void Configure(EntityTypeBuilder<Modulos> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.CodBarrasLoteConfirmacion)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.CodBarrasLoteConfirmacionParcial)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.CrearOrden)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.EnviarIdCabOrden)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.EnviarReset)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.GenerarAutoInicio)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.GenerarLote)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.ModoDebugServidor)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.NumValidaciones)
				.HasDefaultValueSql("20");
			entityTypeBuilder.Property(x => x.OEEKgHora)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.OPCEnvioEan13Var2Var3)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.OPCEnvioFCaducidadVar1)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PermitirAlertas)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PermitirCambiarLote)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PermitirCambiarProducto)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PermitirCambioNumCiclos)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PermitirDosificacionParcial)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PermitirModoVolteo)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PermitirResetear)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.PermitirVariosOrigenes)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.RecibirAutoInicio)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.RequiereEnvase)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.RequiereValidacion)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.SeleccionarCajones)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.VerBotonBrutoACero)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.VerBotonCambioLote)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.VerBotonConfirmar)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.VerBotonParcial)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.VerBotonSaltar)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.VerBotonTaraACero)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.VerBotonTeorico)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasOne(x => x.DepartamentoNavigation)
				.WithMany(x => x.Modulos)
				.HasForeignKey(x => x.Departamento)
				.HasConstraintName("FK_Modulos_Departamentos");
			entityTypeBuilder.HasOne(x => x.ModuloAsociadoOrdenes1Navigation)
				.WithMany(x => x.InverseModuloAsociadoOrdenes1Navigation)
				.HasForeignKey(x => x.ModuloAsociadoOrdenes1)
				.HasConstraintName("FK_Modulos_ModulosAsociadoOrden1");
			entityTypeBuilder.HasOne(x => x.ModuloAsociadoOrdenes2Navigation)
				.WithMany(x => x.InverseModuloAsociadoOrdenes2Navigation)
				.HasForeignKey(x => x.ModuloAsociadoOrdenes2)
				.HasConstraintName("FK_Modulos_ModulosAsociadoOrden2");
			entityTypeBuilder.HasOne(x => x.OpcConfig)
				.WithMany(x => x.Modulos)
				.HasForeignKey(x => x.OpcConfigId)
				.HasConstraintName("FK_Modulos_OpcConfig");
			entityTypeBuilder.HasOne(x => x.PLCOrdenNumActualNavigation)
				.WithMany(x => x.Modulos)
				.HasForeignKey(x => x.PLCOrdenNumActual)
				.HasConstraintName("FK_Modulos_Ordenes");
			entityTypeBuilder.HasOne(x => x.ProdFinalDefectoNavigation)
				.WithMany(x => x.Modulos)
				.HasForeignKey(x => x.ProdFinalDefecto)
				.HasConstraintName("FK_Modulos_ProdFinal");
			entityTypeBuilder.HasOne(x => x.RolBaseNavigation)
				.WithMany(x => x.Modulos)
				.HasForeignKey(x => x.RolBase)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Modulos_UsuariosRoles");
			entityTypeBuilder.HasOne(x => x.idPlantillaBaseNavigation)
				.WithMany(x => x.ModulosidPlantillaBaseNavigation)
				.HasForeignKey(x => x.idPlantillaBase)
				.HasConstraintName("FK_Modulos_OperCabPlantillas");
			entityTypeBuilder.HasOne(x => x.idPlantillaLimpiezaNavigation)
				.WithMany(x => x.ModulosidPlantillaLimpiezaNavigation)
				.HasForeignKey(x => x.idPlantillaLimpieza)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Modulos_OperCabPlantillasLimpieza");
		}

	}

}
