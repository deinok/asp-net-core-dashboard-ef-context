using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class CabOrdenesConfiguration : IEntityTypeConfiguration<CabOrdenes>
	{

		public void Configure(EntityTypeBuilder<CabOrdenes> entityTypeBuilder)
		{
			entityTypeBuilder.HasIndex(x => new { x.id, x.Nombre, x.FechaCreacion, x.FechaInicio, x.FechaFinal, x.Tipo, x.ProductoDestino, x.UbicacionDestino, x.LoteDestino, x.Prioridad, x.Formula, x.Cantidad, x.Version, x.idOld, x.SerieOld, x.Entrada, x.ViajeSalida, x.Modulo })
					.HasName("IndexCabOrdenes_1");
			entityTypeBuilder.Property(x => x.Cantidad)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasOne(x => x.EntradaNavigation)
				.WithMany(x => x.CabOrdenes)
				.HasForeignKey(x => x.Entrada)
				.HasConstraintName("FK_CabOrdenes_Entradas");
			entityTypeBuilder.HasOne(x => x.FormulaNavigation)
				.WithMany(x => x.CabOrdenes)
				.HasForeignKey(x => x.Formula)
				.HasConstraintName("FK_CabOrdenes_Formulas");
			entityTypeBuilder.HasOne(x => x.LoteDestinoNavigation)
				.WithMany(x => x.CabOrdenes)
				.HasForeignKey(x => x.LoteDestino)
				.HasConstraintName("FK_CabOrdenes_Lotes");
			entityTypeBuilder.HasOne(x => x.ModuloNavigation)
				.WithMany(x => x.CabOrdenes)
				.HasForeignKey(x => x.Modulo)
				.HasConstraintName("FK_CabOrdenes_Modulos");
			entityTypeBuilder.HasOne(x => x.ProductoDestinoNavigation)
				.WithMany(x => x.CabOrdenes)
				.HasForeignKey(x => x.ProductoDestino)
				.HasConstraintName("FK_CabOrdenes_Productos");
			entityTypeBuilder.HasOne(x => x.UbicacionDestinoNavigation)
				.WithMany(x => x.CabOrdenes)
				.HasForeignKey(x => x.UbicacionDestino)
				.HasConstraintName("FK_CabOrdenes_Ubicaciones");
			entityTypeBuilder.HasOne(x => x.VersionNavigation)
				.WithMany(x => x.CabOrdenes)
				.HasForeignKey(x => x.Version)
				.HasConstraintName("FK_CabOrdenes_Versiones");
			entityTypeBuilder.HasOne(x => x.ViajeSalidaNavigation)
				.WithMany(x => x.CabOrdenes)
				.HasForeignKey(x => x.ViajeSalida)
				.HasConstraintName("FK_CabOrdenes_SalidasViajes");
		}

	}

}
