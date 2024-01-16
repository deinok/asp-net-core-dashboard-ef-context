using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class GMAO_ElementosTiposConfiguration : IEntityTypeConfiguration<GMAO_ElementosTipos>
	{

		public void Configure(EntityTypeBuilder<GMAO_ElementosTipos> entityTypeBuilder)
		{
			entityTypeBuilder.HasOne(x => x.ProveedorHabitualNavigation)
				.WithMany(x => x.GMAO_ElementosTipos)
				.HasForeignKey(x => x.ProveedorHabitual)
				.HasConstraintName("FK_GMAO_ElementosTipos_GMAO_Proveedores");
		}

	}

}
