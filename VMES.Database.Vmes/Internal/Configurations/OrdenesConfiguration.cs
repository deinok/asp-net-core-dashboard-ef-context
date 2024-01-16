using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class OrdenesConfiguration : IEntityTypeConfiguration<Ordenes>
	{

		public void Configure(EntityTypeBuilder<Ordenes> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.Bloqueada)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.Fecha)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.FechaEnvioAPlc)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.FechaInicioPrevista)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.Fin)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.FormulaFecha)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.Fexportado)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.Inicio)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.IniciarOrden)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.Validada)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasOne(x => x.DepartamentoNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.Departamento)
				.HasConstraintName("FK_Ordenes_Departamentos");
			entityTypeBuilder.HasOne(x => x.EntradaNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.Entrada)
				.HasConstraintName("FK_Ordenes_Entradas");
			entityTypeBuilder.HasOne(x => x.EnvaseOrigenNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.EnvaseOrigen)
				.HasConstraintName("FK_Ordenes_Envases");
			entityTypeBuilder.HasOne(x => x.FormulaNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.Formula)
				.HasConstraintName("FK_Ordenes_Formulas");
			entityTypeBuilder.HasOne(x => x.IdCabNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.IdCab)
				.HasConstraintName("FK_Ordenes_CabOrdenes");
			entityTypeBuilder.HasOne(x => x.IdVehiculoNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.IdVehiculo)
				.HasConstraintName("FK_Ordenes_Vehiculos");
			entityTypeBuilder.HasOne(x => x.LineaEntradaNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.LineaEntrada)
				.HasConstraintName("FK_Ordenes_EntradasLineas");
			entityTypeBuilder.HasOne(x => x.LineaSalidaNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.LineaSalida)
				.HasConstraintName("FK_Ordenes_SalidasLinias");
			entityTypeBuilder.HasOne(x => x.LoteDestinoNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.LoteDestino)
				.HasConstraintName("FK_Ordenes_Lotes");
			entityTypeBuilder.HasOne(x => x.MedicacionNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.Medicacion)
				.HasConstraintName("FK_Ordenes_Medicaciones");
			entityTypeBuilder.HasOne(x => x.ModuloNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.Modulo)
				.HasConstraintName("FK_Ordenes_Modulos");
			entityTypeBuilder.HasOne(x => x.ProductoDestinoNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.ProductoDestino)
				.HasConstraintName("FK_Ordenes_Productos");
			entityTypeBuilder.HasOne(x => x.VersionNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.Version)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Ordenes_Versiones");
			entityTypeBuilder.HasOne(x => x.ViajeSalidaNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.ViajeSalida)
				.HasConstraintName("FK_Ordenes_SalidasViajes");
			entityTypeBuilder.HasOne(x => x.idChoferNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.idChofer)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Ordenes_Choferes");
			entityTypeBuilder.HasOne(x => x.idTarjetaNavigation)
				.WithMany(x => x.Ordenes)
				.HasForeignKey(x => x.idTarjeta)
				.HasConstraintName("FK_Ordenes_Tarjetas");

#warning
#if NET7_0_OR_GREATER
			entityTypeBuilder.ToTable(x => x.HasTrigger("trg_Ordenes_OrdenesTransicionEstadosHistory_FU"));
#endif

#warning
#if NET7_0_OR_GREATER
			entityTypeBuilder.ToTable(x => x.HasTrigger("Trigger_OrdenPLC"));
#endif
		}

	}

}
