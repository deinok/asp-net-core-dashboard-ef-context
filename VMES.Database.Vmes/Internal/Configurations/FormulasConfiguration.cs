using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class FormulasConfiguration : IEntityTypeConfiguration<Formulas>
	{

		public void Configure(EntityTypeBuilder<Formulas> entityTypeBuilder)
		{
			entityTypeBuilder.HasOne(x => x.DepartamentoNavigation)
				.WithMany(x => x.Formulas)
				.HasForeignKey(x => x.Departamento)
				.HasConstraintName("FK_Formulas_Departamentos");
			entityTypeBuilder.HasOne(x => x.FamiliaNavigation)
				.WithMany(x => x.Formulas)
				.HasForeignKey(x => x.Familia)
				.HasConstraintName("FK_Formulas_Familias");
			entityTypeBuilder.HasOne(x => x.ModuloNavigation)
				.WithMany(x => x.Formulas)
				.HasForeignKey(x => x.Modulo)
				.HasConstraintName("FK_Formulas_Modulos");
			entityTypeBuilder.HasOne(x => x.ProductoNavigation)
				.WithMany(x => x.Formulas)
				.HasForeignKey(x => x.Producto)
				.HasConstraintName("FK_Formulas_Productos");
		}

	}

}
