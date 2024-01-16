using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class UbicacionesConfiguration : IEntityTypeConfiguration<Ubicaciones>
	{

		public void Configure(EntityTypeBuilder<Ubicaciones> entityTypeBuilder)
		{
			entityTypeBuilder.HasIndex(x => x.Ordenacion);
			entityTypeBuilder.HasIndex(x => x.ModoBigBag)
				.HasName("_dta_index_Ubicaciones_2");
			entityTypeBuilder.HasIndex(x => new { x.Id, x.Nombre, x.Departamento, x.Referencia, x.Tipo, x.CargaManual, x.DescargaManual, x.Capacidad, x.Unidad, x.Individual, x.Producto, x.Formato, x.Prioridad, x.Stock, x.ControlStock, x.AvisosActivo, x.AvisosEquipo, x.Configurable, x.PosicionX, x.PosicionY, x.Minima, x.Maxima, x.Nivel, x.Lote, x.Entradas, x.Salidas, x.Duplicado, x.Desasignable, x.Asociacion, x.Premezclas, x.Importado, x.Exportado, x.Bloqueado, x.StockMinimo, x.NivelMinimo, x.NivelMaximo, x.AvisosSesion, x.Color, x.AsociacionObligatoria, x.idOld, x.MaPGrupo, x.MaPTiempoLimpiezaLlenado, x.Type, x.MaPNivelMaximoActivo, x.MaPNivelMinimoActivo, x.MaPNivelMedioActivo, x.MaPNivelPorcentajeActivo, x.MaPVolumenSilo, x.MaPCaudalMaxEstLlenando, x.MaPCaudalMaxEstVaciando, x.PaMHabilitadoLlenado, x.PaMHabilitadoVaciado, x.PaMNivelMaximo, x.PaMNivelMinimo, x.PaMNivelMedio, x.PaMForzarLleno, x.PaMForzarVacio, x.PaMNivelPorcentaje, x.PaMTemperatura, x.PaMPresion, x.PaMVariable1, x.PaMVariable2, x.PaMVariable3, x.PaMVariable0, x.MaPVariable0, x.MaPVariable1, x.MaPVariable2, x.MaPVariable3, x.Afino, x.ConVibrador, x.VelocidadLenta, x.VelocidadRapida, x.PaMCola, x.PLCPosicion, x.ModoBigBag, x.DosificacionMaxima, x.AfinoMaximo, x.EnviarEnPorcentaje, x.AfinoMultiDosi, x.AfinoMaxMultiDosi, x.PermitirAsociar, x.AfinoMinimo, x.MaPTiempoRegistros, x.MinimoSiloResetUbi, x.NoNegativos, x.MezcladoLotes, x.MezcladoMinimoDisolucion, x.MezcladoDiasMinimoFCaducidad, x.Visible, x.Ordenacion })
				.HasName("_dta_index_Ubicaciones_1");
			entityTypeBuilder.HasIndex(x => new { x.Id, x.Nombre, x.Departamento, x.Referencia, x.Tipo, x.CargaManual, x.DescargaManual, x.Capacidad, x.Unidad, x.Individual, x.Producto, x.Formato, x.Prioridad, x.Stock, x.ControlStock, x.AvisosActivo, x.AvisosEquipo, x.Configurable, x.PosicionX, x.PosicionY, x.Minima, x.Maxima, x.Nivel, x.Lote, x.Entradas, x.Salidas, x.Duplicado, x.Desasignable, x.Asociacion, x.Premezclas, x.Importado, x.Exportado, x.Bloqueado, x.StockMinimo, x.NivelMinimo, x.NivelMaximo, x.AvisosSesion, x.Color, x.AsociacionObligatoria, x.idOld, x.MaPGrupo, x.MaPTiempoLimpiezaLlenado, x.Type, x.MaPNivelMaximoActivo, x.MaPNivelMinimoActivo, x.MaPNivelMedioActivo, x.MaPNivelPorcentajeActivo, x.MaPVolumenSilo, x.MaPCaudalMaxEstLlenando, x.MaPCaudalMaxEstVaciando, x.PaMHabilitadoLlenado, x.PaMHabilitadoVaciado, x.PaMNivelMaximo, x.PaMNivelMinimo, x.PaMNivelMedio, x.PaMForzarLleno, x.PaMForzarVacio, x.PaMNivelPorcentaje, x.PaMTemperatura, x.PaMPresion, x.PaMVariable1, x.PaMVariable2, x.PaMVariable3, x.PaMVariable0, x.MaPVariable0, x.MaPVariable1, x.MaPVariable2, x.MaPVariable3, x.Afino, x.ConVibrador, x.VelocidadLenta, x.VelocidadRapida, x.PaMCola, x.PLCPosicion, x.ModoBigBag, x.DosificacionMaxima, x.AfinoMaximo, x.EnviarEnPorcentaje, x.AfinoMultiDosi, x.AfinoMaxMultiDosi, x.PermitirAsociar, x.AfinoMinimo, x.MaPTiempoRegistros, x.MinimoSiloResetUbi, x.NoNegativos, x.MezcladoLotes, x.MezcladoMinimoDisolucion, x.MezcladoDiasMinimoFCaducidad, x.TipoPR, x.ColaPropuesta, x.Visible, x.Ordenacion })
				.HasName("IndexUbicaciones_1");
			entityTypeBuilder.HasIndex(x => new { x.Id, x.Nombre, x.Departamento, x.Referencia, x.Tipo, x.CargaManual, x.DescargaManual, x.Capacidad, x.Unidad, x.Individual, x.Producto, x.Formato, x.Prioridad, x.Stock, x.ControlStock, x.AvisosActivo, x.AvisosEquipo, x.Configurable, x.PosicionX, x.PosicionY, x.Minima, x.Maxima, x.Nivel, x.Lote, x.Entradas, x.Salidas, x.Duplicado, x.Desasignable, x.Asociacion, x.Premezclas, x.Importado, x.Exportado, x.Bloqueado, x.StockMinimo, x.NivelMinimo, x.NivelMaximo, x.AvisosSesion, x.Color, x.AsociacionObligatoria, x.idOld, x.MaPGrupo, x.MaPTiempoLimpiezaLlenado, x.Type, x.MaPNivelMaximoActivo, x.MaPNivelMinimoActivo, x.MaPNivelMedioActivo, x.MaPNivelPorcentajeActivo, x.MaPVolumenSilo, x.MaPCaudalMaxEstLlenando, x.MaPCaudalMaxEstVaciando, x.PaMHabilitadoLlenado, x.PaMHabilitadoVaciado, x.PaMNivelMaximo, x.PaMNivelMinimo, x.PaMNivelMedio, x.PaMForzarLleno, x.PaMForzarVacio, x.PaMNivelPorcentaje, x.PaMTemperatura, x.PaMPresion, x.PaMVariable1, x.PaMVariable2, x.PaMVariable3, x.PaMVariable0, x.MaPVariable0, x.MaPVariable1, x.MaPVariable2, x.MaPVariable3, x.Afino, x.ConVibrador, x.VelocidadLenta, x.VelocidadRapida, x.PaMCola, x.PLCPosicion, x.ModoBigBag, x.DosificacionMaxima, x.AfinoMaximo, x.EnviarEnPorcentaje, x.AfinoMultiDosi, x.AfinoMaxMultiDosi, x.PermitirAsociar, x.AfinoMinimo, x.MaPTiempoRegistros, x.MinimoSiloResetUbi, x.NoNegativos, x.MezcladoLotes, x.MezcladoMinimoDisolucion, x.MezcladoDiasMinimoFCaducidad, x.TipoPR, x.ColaPropuesta, x.PaMColaMulti, x.Visible, x.Ordenacion })
				.HasName("IUbicaciones1");
			entityTypeBuilder.Property(x => x.Bloqueable)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.LoteActual)
				.HasComputedColumnSql("([dbo].[LoteEnUbicacion]([id]))")
				.ValueGeneratedNever();
			entityTypeBuilder.Property(x => x.MaPCaudalMaxEstLlenando)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.MaPCaudalMaxEstVaciando)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.MaPGrupo)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.MaPNivelMaximoActivo)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.MaPNivelMedioActivo)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.MaPNivelMinimoActivo)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.MaPNivelPorcentajeActivo)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.MaPTiempoLimpiezaLlenado)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.MaPTiempoRegistros)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.Type)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.MaPVariable0)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.MaPVariable1)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.MaPVariable2)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.MaPVariable3)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.MaPVolumenSilo)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.NoAsignable)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PaMCola)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PaMForzarLleno)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PaMForzarVacio)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PaMHabilitadoLlenado)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PaMHabilitadoVaciado)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PaMNivelMaximo)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PaMNivelMedio)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PaMNivelMinimo)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PaMNivelPorcentaje)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PaMPresion)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PaMTemperatura)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PaMVariable0)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PaMVariable1)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PaMVariable2)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PaMVariable3)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.SincronizarERP)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.StockActual)
				.HasComputedColumnSql("([dbo].[StockEnUbicacion]([id],[NoNegativos]))")
				.ValueGeneratedNever();
			entityTypeBuilder.HasOne(x => x.AsociacionNavigation)
				.WithMany(x => x.InverseAsociacionNavigation)
				.HasForeignKey(x => x.Asociacion)
				.HasConstraintName("FK_Ubicaciones_Ubicaciones");
			entityTypeBuilder.HasOne(x => x.AvisosSesionNavigation)
				.WithMany(x => x.Ubicaciones)
				.HasForeignKey(x => x.AvisosSesion)
				.HasConstraintName("FK_Ubicaciones_Sesiones");
			entityTypeBuilder.HasOne(x => x.DepartamentoNavigation)
				.WithMany(x => x.Ubicaciones)
				.HasForeignKey(x => x.Departamento)
				.HasConstraintName("FK_Ubicaciones_Departamentos");
			entityTypeBuilder.HasOne(x => x.FormatoNavigation)
				.WithMany(x => x.Ubicaciones)
				.HasForeignKey(x => x.Formato)
				.HasConstraintName("FK_Ubicaciones_Formatos");
			entityTypeBuilder.HasOne(x => x.LoteNavigation)
				.WithMany(x => x.Ubicaciones)
				.HasForeignKey(x => x.Lote)
				.HasConstraintName("FK_Ubicaciones_Lotes");
			entityTypeBuilder.HasOne(x => x.OpcConfig)
				.WithMany(x => x.Ubicaciones)
				.HasForeignKey(x => x.OpcConfigId)
				.HasConstraintName("FK__Ubicacion__OpcCo__3AE1A5DA");
			entityTypeBuilder.HasOne(x => x.ProductoNavigation)
				.WithMany(x => x.Ubicaciones)
				.HasForeignKey(x => x.Producto)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Ubicaciones_Productos");
			entityTypeBuilder.HasOne(x => x.UnidadNavigation)
				.WithMany(x => x.Ubicaciones)
				.HasForeignKey(x => x.Unidad)
				.HasConstraintName("FK_Ubicaciones_Unidades");
		}

	}

}
