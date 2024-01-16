using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class GMAO_ElemIntervencionesConfiguration : IEntityTypeConfiguration<GMAO_ElemIntervenciones>
	{

		public void Configure(EntityTypeBuilder<GMAO_ElemIntervenciones> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.FechaFinal)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.Property(x => x.FechaInicio)
				.HasConversion(
					x => x.Value.ToLocalTime(),
					x => DateTime.SpecifyKind(x, DateTimeKind.Local)
				);
			entityTypeBuilder.HasOne(x => x.IDDepartamentoNavigation)
				.WithMany(x => x.GMAO_ElemIntervenciones)
				.HasForeignKey(x => x.IDDepartamento)
				.HasConstraintName("FK_GMAO_ElemIntervenciones_GMAO_Departamentos");
			entityTypeBuilder.HasOne(x => x.IdOperarioResponsableNavigation)
				.WithMany(x => x.GMAO_ElemIntervenciones)
				.HasForeignKey(x => x.IdOperarioResponsable)
				.HasConstraintName("FK_GMAO_ElemIntervenciones_GMAO_Operarios");
			entityTypeBuilder.HasOne(x => x.IdParadaConfiguracionNavigation)
				.WithMany(x => x.GMAO_ElemIntervenciones)
				.HasForeignKey(x => x.IdParadaConfiguracion)
				.HasConstraintName("FK_GMAO_ElemIntervenciones_GMAO_ParadasConfiguracion");
			entityTypeBuilder.HasOne(x => x.idElementoNavigation)
				.WithMany(x => x.GMAO_ElemIntervenciones)
				.HasForeignKey(x => x.idElemento)
				.HasConstraintName("FK_GMAO_ElemIntervenciones_GMAO_Elementos");
		}

	}

}
