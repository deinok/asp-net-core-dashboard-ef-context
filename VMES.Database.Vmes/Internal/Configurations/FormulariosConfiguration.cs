using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class FormulariosConfiguration : IEntityTypeConfiguration<Formularios>
	{

		public void Configure(EntityTypeBuilder<Formularios> entityTypeBuilder)
		{
			entityTypeBuilder.HasOne(x => x.FormulaNavigation)
				.WithMany(x => x.Formularios)
				.HasForeignKey(x => x.Formula)
				.HasConstraintName("FK_Formularios_Formulas");
			entityTypeBuilder.HasOne(x => x.MedicacionNavigation)
				.WithMany(x => x.Formularios)
				.HasForeignKey(x => x.Medicacion)
				.HasConstraintName("FK_Formularios_Medicaciones");
			entityTypeBuilder.HasOne(x => x.ProductoNavigation)
				.WithMany(x => x.Formularios)
				.HasForeignKey(x => x.Producto)
				.HasConstraintName("FK_Formularios_Productos");
		}

	}

}
