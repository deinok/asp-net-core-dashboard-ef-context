using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class DosificacionesConfiguration : IEntityTypeConfiguration<Dosificaciones>
	{

		public void Configure(EntityTypeBuilder<Dosificaciones> entityTypeBuilder)
		{
			entityTypeBuilder.HasIndex(x => new { x.Id, x.Cantidad, x.Ubicacion, x.Producto })
				.HasName("PK_DosificacionesProducto");
			entityTypeBuilder.HasIndex(x => new { x.Id, x.Serie, x.IdOld, x.Producto, x.Formato, x.Proceso, x.Porcentaje, x.Cantidad, x.Unidad, x.Servida, x.NumeroPesadas, x.Inicio, x.Fin, x.Tipo, x.Exportado, x.Lote, x.Ubicacion, x.Grupo, x.Estado, x.Medidor, x.CantidadPrincipal, x.TipoRegistro, x.Importado, x.PosicionDosificacion, x.CicloActual, x.CantidadActual, x.UbicacionActual, x.ProductoActual, x.LoteActual, x.DosificacionActual, x.IdModulo, x.EstadoActual, x.ToleranciaSuperior, x.ToleranciaInferior, x.PausaPosteriorDosificacion, x.NumCorrecion, x.Afino, x.ConVibrador, x.VelocidadLenta, x.VelocidadRapida, x.IdOperMotor, x.IdOperAccion, x.OperVariable, x.TextoVariable, x.OperTiempo, x.DosificarProductoAnterior, x.PosicionDosificacionPLC, x.PosicionOperacionPLC, x.PosicionMultidosiPLC, x.idPlantilla, x.idFormulaOriginal, x.idComponenteOriginal, x.idVersionOriginal, x.OperVariable2, x.Comentario, x.OrigenERP, x.IdTempControl, x.TempModo, x.MinAlarma, x.MaxAlarma, x.Consigna, x.Histeresys, x.ConsignaPausa, x.ZonaMuerta, x.DosiVariable1, x.DosiVariable2, x.Orden })
				.HasName("IDosificaciones1");
			entityTypeBuilder.Property(x => x.OrigenERP)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PausaPosteriorDosificacion)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.TextoVariable)
				.IsUnicode(false);
			entityTypeBuilder.HasOne(x => x.FormatoNavigation)
				.WithMany(x => x.Dosificaciones)
				.HasForeignKey(x => x.Formato)
				.HasConstraintName("FK_Dosificaciones_Formatos");
			entityTypeBuilder.HasOne(x => x.IdModuloNavigation)
				.WithMany(x => x.Dosificaciones)
				.HasForeignKey(x => x.IdModulo)
				.HasConstraintName("FK_Dosificaciones_Modulos");
			entityTypeBuilder.HasOne(x => x.IdOperAccionNavigation)
				.WithMany(x => x.Dosificaciones)
				.HasForeignKey(x => x.IdOperAccion)
				.HasConstraintName("FK_Dosificaciones_OperAcciones");
			entityTypeBuilder.HasOne(x => x.IdOperMotorNavigation)
				.WithMany(x => x.Dosificaciones)
				.HasForeignKey(x => x.IdOperMotor)
				.HasConstraintName("FK_Dosificaciones_OperMotores");
			entityTypeBuilder.HasOne(x => x.IdTempControlNavigation)
				.WithMany(x => x.Dosificaciones)
				.HasForeignKey(x => x.IdTempControl)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Dosificaciones_TempControles");
			entityTypeBuilder.HasOne(x => x.LoteNavigation)
				.WithMany(x => x.DosificacionesLoteNavigation)
				.HasForeignKey(x => x.Lote)
				.HasConstraintName("FK_Dosificaciones_Lotes");
			entityTypeBuilder.HasOne(x => x.LoteActualNavigation)
				.WithMany(x => x.DosificacionesLoteActualNavigation)
				.HasForeignKey(x => x.LoteActual)
				.HasConstraintName("FK_Dosificaciones_LotesActual");
			entityTypeBuilder.HasOne(x => x.MedidorNavigation)
				.WithMany(x => x.DosificacionesNavigation)
				.HasForeignKey(x => x.Medidor)
				.HasConstraintName("FK_Dosificaciones_Medidores");
			entityTypeBuilder.HasOne(x => x.OrdenNavigation)
				.WithMany(x => x.Dosificaciones)
				.HasForeignKey(x => x.Orden)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Dosificaciones_Ordenes");
			entityTypeBuilder.HasOne(x => x.ProductoNavigation)
				.WithMany(x => x.DosificacionesProductoNavigation)
				.HasForeignKey(x => x.Producto)
				.HasConstraintName("FK_Dosificaciones_Productos");
			entityTypeBuilder.HasOne(x => x.ProductoActualNavigation)
				.WithMany(x => x.DosificacionesProductoActualNavigation)
				.HasForeignKey(x => x.ProductoActual)
				.HasConstraintName("FK_Dosificaciones_ProductosActual");
			entityTypeBuilder.HasOne(x => x.UbicacionNavigation)
				.WithMany(x => x.Dosificaciones)
				.HasForeignKey(x => x.Ubicacion)
				.HasConstraintName("FK_Dosificaciones_Ubicaciones");
			entityTypeBuilder.HasOne(x => x.UnidadNavigation)
				.WithMany(x => x.Dosificaciones)
				.HasForeignKey(x => x.Unidad)
				.HasConstraintName("FK_Dosificaciones_Unidades");
			entityTypeBuilder.HasOne(x => x.idMedGeneradorNavigation)
				.WithMany(x => x.Dosificaciones)
				.HasForeignKey(x => x.idMedGenerador)
				.HasConstraintName("FK_Dosificaciones_MedidoresDosificaciones");
			entityTypeBuilder.HasOne(x => x.idPlantillaNavigation)
				.WithMany(x => x.Dosificaciones)
				.HasForeignKey(x => x.idPlantilla)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Dosificaciones_OperCabPlantillas");
		}

	}

}
