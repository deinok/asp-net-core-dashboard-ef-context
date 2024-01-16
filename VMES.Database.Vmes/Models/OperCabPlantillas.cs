using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class OperCabPlantillas
	{

		[Key]
		public int Id { get; set; }

		[StringLength(250)]
		public string Nombre { get; set; }

		public int? IdModulo { get; set; }

		[ForeignKey(nameof(IdModulo))]
		[InverseProperty(nameof(Modulos.OperCabPlantillas))]
		public virtual Modulos IdModuloNavigation { get; set; }

		[InverseProperty(nameof(Models.Componentes.idPlantillaNavigation))]
		public virtual ICollection<Componentes> Componentes { get; set; } = new HashSet<Componentes>();

		[InverseProperty(nameof(Models.Dosificaciones.idPlantillaNavigation))]
		public virtual ICollection<Dosificaciones> Dosificaciones { get; set; } = new HashSet<Dosificaciones>();

		[InverseProperty(nameof(Medidor.idPlantillaOcultaNavigation))]
		public virtual ICollection<Medidor> Medidores { get; set; } = new HashSet<Medidor>();

		[InverseProperty(nameof(Modulos.idPlantillaBaseNavigation))]
		public virtual ICollection<Modulos> ModulosidPlantillaBaseNavigation { get; set; } = new HashSet<Modulos>();

		[InverseProperty(nameof(Modulos.idPlantillaLimpiezaNavigation))]
		public virtual ICollection<Modulos> ModulosidPlantillaLimpiezaNavigation { get; set; } = new HashSet<Modulos>();

		[InverseProperty(nameof(Models.OperPlantillas.IdOperCabPlantillasNavigation))]
		public virtual ICollection<OperPlantillas> OperPlantillas { get; set; } = new HashSet<OperPlantillas>();

		[InverseProperty(nameof(Models.ProductosOperCabPlantillas.IdOperCabPlantillaNavigation))]
		public virtual ICollection<ProductosOperCabPlantillas> ProductosOperCabPlantillas { get; set; } = new HashSet<ProductosOperCabPlantillas>();

		[InverseProperty(nameof(Productos.PlantillaCabCargaPiquera2Navigation))]
		public virtual ICollection<Productos> ProductosPlantillaCabCargaPiquera2Navigation { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Productos.PlantillaCabCargaPiqueraNavigation))]
		public virtual ICollection<Productos> ProductosPlantillaCabCargaPiqueraNavigation { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Productos.PlantillaCabMolturacionNavigation))]
		public virtual ICollection<Productos> ProductosPlantillaCabMolturacionNavigation { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Productos.PlantillaCabProduccion2Navigation))]
		public virtual ICollection<Productos> ProductosPlantillaCabProduccion2Navigation { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Productos.PlantillaCabProduccion3Navigation))]
		public virtual ICollection<Productos> ProductosPlantillaCabProduccion3Navigation { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Productos.PlantillaCabProduccionNavigation))]
		public virtual ICollection<Productos> ProductosPlantillaCabProduccionNavigation { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Productos.PlantillaCabSecaderoNavigation))]
		public virtual ICollection<Productos> ProductosPlantillaCabSecaderoNavigation { get; set; } = new HashSet<Productos>();

	}

}
