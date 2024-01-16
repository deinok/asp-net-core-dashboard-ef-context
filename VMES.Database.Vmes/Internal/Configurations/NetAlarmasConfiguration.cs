using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class NetAlarmasConfiguration : IEntityTypeConfiguration<NetAlarmas>
	{

		public void Configure(EntityTypeBuilder<NetAlarmas> entityTypeBuilder)
		{
			entityTypeBuilder.HasIndex(x => new { x.IdModulo, x.Enviada, x.PostEnvioProcesada });
			entityTypeBuilder.HasIndex(x => x.Respondido);
			entityTypeBuilder.Property(x => x.FechaError)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.FechaRecibido)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.RespFecha)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.FechaErrorMES)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.AlertaGestionada)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.Interno)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.MostrarAUsuario)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.RespArgumentos0)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.RespArgumentos1)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.RespArgumentos2)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.RespArgumentos3)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.RespVariables0)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.RespVariables1)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.RespVariables2)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.RespVariables3)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.RespVariables4)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.Respondido)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.RevisadoAlertas)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasOne(x => x.IdDestinoNavigation)
				.WithMany(x => x.NetAlarmasIdDestinoNavigation)
				.HasForeignKey(x => x.IdDestino)
				.HasConstraintName("FK_NetAlarmas_Ubicaciones2");
			entityTypeBuilder.HasOne(x => x.IdDestinoPropuestoNavigation)
				.WithMany(x => x.NetAlarmasIdDestinoPropuestoNavigation)
				.HasForeignKey(x => x.IdDestinoPropuesto)
				.HasConstraintName("FK_NetAlarmas_Ubicaciones4");
			entityTypeBuilder.HasOne(x => x.IdErrorNavigation)
				.WithMany(x => x.NetAlarmas)
				.HasForeignKey(x => x.IdError)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_NetAlarmas_NetAlarmasTipos");
			entityTypeBuilder.HasOne(x => x.IdGrupoNavigation)
				.WithMany(x => x.NetAlarmas)
				.HasForeignKey(x => x.IdGrupo)
				.HasConstraintName("FK_NetAlarmas_SeccionesGrupos");
			entityTypeBuilder.HasOne(x => x.IdModuloNavigation)
				.WithMany(x => x.NetAlarmas)
				.HasForeignKey(x => x.IdModulo)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_NetAlarmas_Modulos");
			entityTypeBuilder.HasOne(x => x.IdOrigenNavigation)
				.WithMany(x => x.NetAlarmasIdOrigenNavigation)
				.HasForeignKey(x => x.IdOrigen)
				.HasConstraintName("FK_NetAlarmas_Ubicaciones1");
			entityTypeBuilder.HasOne(x => x.IdOrigenPropuestoNavigation)
				.WithMany(x => x.NetAlarmasIdOrigenPropuestoNavigation)
				.HasForeignKey(x => x.IdOrigenPropuesto)
				.HasConstraintName("FK_NetAlarmas_Ubicaciones3");
			entityTypeBuilder.HasOne(x => x.IdSeccionNavigation)
				.WithMany(x => x.NetAlarmas)
				.HasForeignKey(x => x.IdSeccion)
				.HasConstraintName("FK_NetAlarmas_Secciones");
			entityTypeBuilder.HasOne(x => x.OpcConfig)
				.WithMany(x => x.NetAlarmas)
				.HasForeignKey(x => x.OpcConfigId)
				.HasConstraintName("FK__NetAlarma__OpcCo__5AF96FB1");
			entityTypeBuilder.HasOne(x => x.RespIdLoteNavigation)
				.WithMany(x => x.NetAlarmas)
				.HasForeignKey(x => x.RespIdLote)
				.HasConstraintName("FK_NetAlarmas_Lotes");
			entityTypeBuilder.HasOne(x => x.RespIdProductoNavigation)
				.WithMany(x => x.NetAlarmas)
				.HasForeignKey(x => x.RespIdProducto)
				.HasConstraintName("FK_NetAlarmas_Productos");
			entityTypeBuilder.HasOne(x => x.RespuestaNavigation)
				.WithMany(x => x.NetAlarmas)
				.HasForeignKey(x => x.Respuesta)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_NetAlarmas_NetAlarmasRespuestas");
			entityTypeBuilder.HasOne(x => x.idDosificacionNavigation)
				.WithMany(x => x.NetAlarmas)
				.HasForeignKey(x => x.idDosificacion)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_NetAlarmas_Dosificaciones");
			entityTypeBuilder.HasOne(x => x.idMedidorNavigation)
				.WithMany(x => x.NetAlarmas)
				.HasForeignKey(x => x.idMedidor)
				.HasConstraintName("FK_NetAlarmas_Medidores");
			entityTypeBuilder.HasOne(x => x.idOrdenNavigation)
				.WithMany(x => x.NetAlarmas)
				.HasForeignKey(x => x.idOrden)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_NetAlarmas_Ordenes");
			entityTypeBuilder.HasOne(x => x.idUbicacionNavigation)
				.WithMany(x => x.NetAlarmasidUbicacionNavigation)
				.HasForeignKey(x => x.idUbicacion)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_NetAlarmas_Ubicaciones");
		}

	}

}
