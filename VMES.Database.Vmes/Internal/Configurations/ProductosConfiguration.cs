using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class ProductosConfiguration : IEntityTypeConfiguration<Productos>
	{

		public void Configure(EntityTypeBuilder<Productos> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.PausaPosteriorDosificacion)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasOne(x => x.AfeccionNavigation)
				.WithMany(x => x.Productos)
				.HasForeignKey(x => x.Afeccion)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Productos_Afecciones");
			entityTypeBuilder.HasOne(x => x.DestinoDefectoNavigation)
				.WithMany(x => x.Productos)
				.HasForeignKey(x => x.DestinoDefecto)
				.HasConstraintName("FK_Productos_Ubicaciones");
			entityTypeBuilder.HasOne(x => x.EnvaseNavigation)
				.WithMany(x => x.Productos)
				.HasForeignKey(x => x.Envase)
				.HasConstraintName("FK_Productos_Envases");
			entityTypeBuilder.HasOne(x => x.EtiquetaControlNavigation)
				.WithMany(x => x.ProductosEtiquetaControlNavigation)
				.HasForeignKey(x => x.EtiquetaControl)
				.HasConstraintName("FK_Productos_Etiquetas3");
			entityTypeBuilder.HasOne(x => x.EtiquetaEntradasNavigation)
				.WithMany(x => x.ProductosEtiquetaEntradasNavigation)
				.HasForeignKey(x => x.EtiquetaEntradas)
				.HasConstraintName("FK_Productos_Etiquetas4");
			entityTypeBuilder.HasOne(x => x.EtiquetaGranelNavigation)
				.WithMany(x => x.ProductosEtiquetaGranelNavigation)
				.HasForeignKey(x => x.EtiquetaGranel)
				.HasConstraintName("FK_Productos_Etiquetas");
			entityTypeBuilder.HasOne(x => x.EtiquetaMuestrasNavigation)
				.WithMany(x => x.ProductosEtiquetaMuestrasNavigation)
				.HasForeignKey(x => x.EtiquetaMuestras)
				.HasConstraintName("FK_Productos_Etiquetas2");
			entityTypeBuilder.HasOne(x => x.EtiquetaSacosNavigation)
				.WithMany(x => x.ProductosEtiquetaSacosNavigation)
				.HasForeignKey(x => x.EtiquetaSacos)
				.HasConstraintName("FK_Productos_Etiquetas1");
			entityTypeBuilder.HasOne(x => x.FamiliaNavigation)
				.WithMany(x => x.Productos)
				.HasForeignKey(x => x.Familia)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Productos_Familias");
			entityTypeBuilder.HasOne(x => x.FamiliaMedidorNavigation)
				.WithMany(x => x.Productos)
				.HasForeignKey(x => x.FamiliaMedidor)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Productos_FamiliasMedidor");
			entityTypeBuilder.HasOne(x => x.FormatoNavigation)
				.WithMany(x => x.Productos)
				.HasForeignKey(x => x.Formato)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Productos_Formatos");
			entityTypeBuilder.HasOne(x => x.MedidorNavigation)
				.WithMany(x => x.Productos)
				.HasForeignKey(x => x.Medidor)
				.HasConstraintName("FK_Productos_Medidores");
			entityTypeBuilder.HasOne(x => x.ModuloNavigation)
				.WithMany(x => x.Productos)
				.HasForeignKey(x => x.Modulo)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Productos_Modulos");
			entityTypeBuilder.HasOne(x => x.PlantillaCabCargaPiqueraNavigation)
				.WithMany(x => x.ProductosPlantillaCabCargaPiqueraNavigation)
				.HasForeignKey(x => x.PlantillaCabCargaPiquera)
				.HasConstraintName("FK_Productos_OperCabPlantillas");
			entityTypeBuilder.HasOne(x => x.PlantillaCabCargaPiquera2Navigation)
				.WithMany(x => x.ProductosPlantillaCabCargaPiquera2Navigation)
				.HasForeignKey(x => x.PlantillaCabCargaPiquera2)
				.HasConstraintName("FK_Productos_OperCabPlantillas3");
			entityTypeBuilder.HasOne(x => x.PlantillaCabMolturacionNavigation)
				.WithMany(x => x.ProductosPlantillaCabMolturacionNavigation)
				.HasForeignKey(x => x.PlantillaCabMolturacion)
				.HasConstraintName("FK_Productos_OperCabPlantillas7");
			entityTypeBuilder.HasOne(x => x.PlantillaCabProduccionNavigation)
				.WithMany(x => x.ProductosPlantillaCabProduccionNavigation)
				.HasForeignKey(x => x.PlantillaCabProduccion)
				.HasConstraintName("FK_Productos_OperCabPlantillas2");
			entityTypeBuilder.HasOne(x => x.PlantillaCabProduccion2Navigation)
				.WithMany(x => x.ProductosPlantillaCabProduccion2Navigation)
				.HasForeignKey(x => x.PlantillaCabProduccion2)
				.HasConstraintName("FK_Productos_OperCabPlantillas5");
			entityTypeBuilder.HasOne(x => x.PlantillaCabProduccion3Navigation)
				.WithMany(x => x.ProductosPlantillaCabProduccion3Navigation)
				.HasForeignKey(x => x.PlantillaCabProduccion3)
				.HasConstraintName("FK_Productos_OperCabPlantillas6");
			entityTypeBuilder.HasOne(x => x.PlantillaCabSecaderoNavigation)
				.WithMany(x => x.ProductosPlantillaCabSecaderoNavigation)
				.HasForeignKey(x => x.PlantillaCabSecadero)
				.HasConstraintName("FK_Productos_OperCabPlantillas4");
			entityTypeBuilder.HasOne(x => x.TipoIvaNavigation)
				.WithMany(x => x.Productos)
				.HasForeignKey(x => x.TipoIva)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Productos_TiposIva");
			entityTypeBuilder.HasOne(x => x.UnidadNavigation)
				.WithMany(x => x.Productos)
				.HasForeignKey(x => x.Unidad)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Productos_Unidades");
		}

	}

}
