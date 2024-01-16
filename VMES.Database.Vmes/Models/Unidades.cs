using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Unidades
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string Singular { get; set; }

		[StringLength(50)]
		public string Medicion { get; set; }

		public float? Relacion { get; set; }

		public bool? Principal { get; set; }

		public int? Tipo { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public bool? Monetaria { get; set; }

		[Column(TypeName = "decimal(12, 3)")]
		public decimal? Conversion { get; set; }

		public bool? FiltroCantidad { get; set; }

		[StringLength(20)]
		public string RefERP { get; set; }

		[Obsolete]
		public int? idOld { get; set; }

		[InverseProperty(nameof(Models.Aditivos.UnidadNavigation))]
		public virtual ICollection<Aditivos> Aditivos { get; set; } = new HashSet<Aditivos>();

		[InverseProperty(nameof(Models.Componentes.UnidadNavigation))]
		public virtual ICollection<Componentes> Componentes { get; set; } = new HashSet<Componentes>();

		[InverseProperty(nameof(Models.Contratos.UnidadNavigation))]
		public virtual ICollection<Contratos> Contratos { get; set; } = new HashSet<Contratos>();

		[InverseProperty(nameof(Models.Desgloses.UnidadNavigation))]
		public virtual ICollection<Desgloses> Desgloses { get; set; } = new HashSet<Desgloses>();

		[InverseProperty(nameof(Models.Disposiciones.UnidadNavigation))]
		public virtual ICollection<Disposiciones> Disposiciones { get; set; } = new HashSet<Disposiciones>();

		[InverseProperty(nameof(Models.Dosificaciones.UnidadNavigation))]
		public virtual ICollection<Dosificaciones> Dosificaciones { get; set; } = new HashSet<Dosificaciones>();

		[InverseProperty(nameof(Models.EntradasLineas.UnidadNavigation))]
		public virtual ICollection<EntradasLineas> EntradasLineas { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(Models.Envases.UnidadNavigation))]
		public virtual ICollection<Envases> Envases { get; set; } = new HashSet<Envases>();

		[InverseProperty(nameof(Models.Existencias.UnidadNavigation))]
		public virtual ICollection<Existencias> Existencias { get; set; } = new HashSet<Existencias>();

		[InverseProperty(nameof(Models.LineasCompra.UnidadNavigation))]
		public virtual ICollection<LineasCompra> LineasCompra { get; set; } = new HashSet<LineasCompra>();

		[InverseProperty(nameof(Models.MedicacionesIngredientes.UnidadNavigation))]
		public virtual ICollection<MedicacionesIngredientes> MedicacionesIngredientes { get; set; } = new HashSet<MedicacionesIngredientes>();

		[InverseProperty(nameof(Models.Productos.UnidadNavigation))]
		public virtual ICollection<Productos> Productos { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Models.Regularizaciones.UnidadNavigation))]
		public virtual ICollection<Regularizaciones> Regularizaciones { get; set; } = new HashSet<Regularizaciones>();

		[InverseProperty(nameof(Models.Resultados.UnidadNavigation))]
		public virtual ICollection<Resultados> Resultados { get; set; } = new HashSet<Resultados>();

		[InverseProperty(nameof(Models.SalidasLinias.idUnidadNavigation))]
		public virtual ICollection<SalidasLinias> SalidasLinias { get; set; } = new HashSet<SalidasLinias>();

		[InverseProperty(nameof(Models.SalidasLiniasMedicaciones.IdUnidadNavigation))]
		public virtual ICollection<SalidasLiniasMedicaciones> SalidasLiniasMedicaciones { get; set; } = new HashSet<SalidasLiniasMedicaciones>();

		[InverseProperty(nameof(Models.Stocks.UnidadNavigation))]
		public virtual ICollection<Stocks> Stocks { get; set; } = new HashSet<Stocks>();

		[InverseProperty(nameof(Models.Tarifas.UnidadNavigation))]
		public virtual ICollection<Tarifas> Tarifas { get; set; } = new HashSet<Tarifas>();

		[InverseProperty(nameof(Models.Ubicaciones.UnidadNavigation))]
		public virtual ICollection<Ubicaciones> Ubicaciones { get; set; } = new HashSet<Ubicaciones>();

		[InverseProperty(nameof(VentasLinias.MedUnidadNavigation))]
		public virtual ICollection<VentasLinias> VentasLiniasMedUnidadNavigation { get; set; } = new HashSet<VentasLinias>();

		[InverseProperty(nameof(Models.VentasLiniasMedicaciones.idUnidadNavigation))]
		public virtual ICollection<VentasLiniasMedicaciones> VentasLiniasMedicaciones { get; set; } = new HashSet<VentasLiniasMedicaciones>();

		[InverseProperty(nameof(VentasLinias.idUnidadNavigation))]
		public virtual ICollection<VentasLinias> VentasLiniasidUnidadNavigation { get; set; } = new HashSet<VentasLinias>();

		[InverseProperty(nameof(Models.Versiones.UnidadNavigation))]
		public virtual ICollection<Versiones> Versiones { get; set; } = new HashSet<Versiones>();

		[InverseProperty(nameof(Models.ComponentesActivos.UnidadNavigation))]
		public virtual ICollection<ComponentesActivos> ComponentesActivos { get; set; } = new HashSet<ComponentesActivos>();

	}

}
