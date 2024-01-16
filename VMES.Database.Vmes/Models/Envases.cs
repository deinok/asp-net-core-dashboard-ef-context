using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Envases
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public float? Capacidad { get; set; }

		public int? Unidad { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		[StringLength(20)]
		public string Referencia2 { get; set; }

		public int? Producto { get; set; }

		[StringLength(20)]
		public string Rerefencia { get; set; }

		[StringLength(20)]
		public string Rerefencia2 { get; set; }

		[StringLength(20)]
		public string RefERP { get; set; }

		public bool? ModoUdsFormato { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.Envases))]
		public virtual Unidades UnidadNavigation { get; set; }

		[InverseProperty(nameof(Models.Desgloses.EnvaseNavigation))]
		public virtual ICollection<Desgloses> Desgloses { get; set; } = new HashSet<Desgloses>();

		[InverseProperty(nameof(Models.EntradasLineas.EnvaseNavigation))]
		public virtual ICollection<EntradasLineas> EntradasLineas { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(Models.Existencias.EnvaseNavigation))]
		public virtual ICollection<Existencias> Existencias { get; set; } = new HashSet<Existencias>();

		[InverseProperty(nameof(Models.LineasCompra.EnvaseNavigation))]
		public virtual ICollection<LineasCompra> LineasCompra { get; set; } = new HashSet<LineasCompra>();

		[InverseProperty(nameof(Models.Ordenes.EnvaseOrigenNavigation))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

		[InverseProperty(nameof(Models.Productos.EnvaseNavigation))]
		public virtual ICollection<Productos> Productos { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(ProductoEnvaseEtiqueta.Envase))]
		public virtual ICollection<ProductoEnvaseEtiqueta> ProductosEnvasesEtiquetas { get; set; } = new HashSet<ProductoEnvaseEtiqueta>();

		[InverseProperty(nameof(Models.Regularizaciones.EnvaseNavigation))]
		public virtual ICollection<Regularizaciones> Regularizaciones { get; set; } = new HashSet<Regularizaciones>();

		[InverseProperty(nameof(Models.SalidasLinias.idEnvaseNavigation))]
		public virtual ICollection<SalidasLinias> SalidasLinias { get; set; } = new HashSet<SalidasLinias>();

		[InverseProperty(nameof(Models.SalidasLiniasMedicaciones.idEnvaseNavigation))]
		public virtual ICollection<SalidasLiniasMedicaciones> SalidasLiniasMedicaciones { get; set; } = new HashSet<SalidasLiniasMedicaciones>();

		[InverseProperty(nameof(Models.Stocks.EnvaseNavigation))]
		public virtual ICollection<Stocks> Stocks { get; set; } = new HashSet<Stocks>();

		[InverseProperty(nameof(Models.Tarifas.EnvaseNavigation))]
		public virtual ICollection<Tarifas> Tarifas { get; set; } = new HashSet<Tarifas>();

		[InverseProperty(nameof(VentasLinias.MedEnvaseNavigation))]
		public virtual ICollection<VentasLinias> VentasLiniasMedEnvaseNavigation { get; set; } = new HashSet<VentasLinias>();

		[InverseProperty(nameof(Models.VentasLiniasMedicaciones.idEnvaseNavigation))]
		public virtual ICollection<VentasLiniasMedicaciones> VentasLiniasMedicaciones { get; set; } = new HashSet<VentasLiniasMedicaciones>();

		[InverseProperty(nameof(VentasLinias.idEnvaseNavigation))]
		public virtual ICollection<VentasLinias> VentasLiniasidEnvaseNavigation { get; set; } = new HashSet<VentasLinias>();

	}

}
