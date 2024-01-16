using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Formatos
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string Descripcion { get; set; }

		public bool? ControlStock { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? idOld { get; set; }

		[StringLength(20)]
		public string RefERP { get; set; }

		[InverseProperty(nameof(Models.Aditivos.FormatoNavigation))]
		public virtual ICollection<Aditivos> Aditivos { get; set; } = new HashSet<Aditivos>();

		[InverseProperty(nameof(Models.Componentes.FormatoNavigation))]
		public virtual ICollection<Componentes> Componentes { get; set; } = new HashSet<Componentes>();

		[InverseProperty(nameof(Models.Disposiciones.FormatoNavigation))]
		public virtual ICollection<Disposiciones> Disposiciones { get; set; } = new HashSet<Disposiciones>();

		[InverseProperty(nameof(Models.Dosificaciones.FormatoNavigation))]
		public virtual ICollection<Dosificaciones> Dosificaciones { get; set; } = new HashSet<Dosificaciones>();

		[InverseProperty(nameof(Models.EntradasLineas.FormatoNavigation))]
		public virtual ICollection<EntradasLineas> EntradasLineas { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(Models.Existencias.FormatoNavigation))]
		public virtual ICollection<Existencias> Existencias { get; set; } = new HashSet<Existencias>();

		[InverseProperty(nameof(Models.LineasCompra.FormatoNavigation))]
		public virtual ICollection<LineasCompra> LineasCompra { get; set; } = new HashSet<LineasCompra>();

		[InverseProperty(nameof(Models.Lotes.FormatoNavigation))]
		public virtual ICollection<Lotes> Lotes { get; set; } = new HashSet<Lotes>();

		[InverseProperty(nameof(Models.Productos.FormatoNavigation))]
		public virtual ICollection<Productos> Productos { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Models.Regularizaciones.FormatoNavigation))]
		public virtual ICollection<Regularizaciones> Regularizaciones { get; set; } = new HashSet<Regularizaciones>();

		[InverseProperty(nameof(Models.Resultados.FormatoNavigation))]
		public virtual ICollection<Resultados> Resultados { get; set; } = new HashSet<Resultados>();

		[InverseProperty(nameof(Models.SalidasLinias.idFormatoNavigation))]
		public virtual ICollection<SalidasLinias> SalidasLinias { get; set; } = new HashSet<SalidasLinias>();

		[InverseProperty(nameof(Models.SalidasLiniasMedicaciones.idFormatoNavigation))]
		public virtual ICollection<SalidasLiniasMedicaciones> SalidasLiniasMedicaciones { get; set; } = new HashSet<SalidasLiniasMedicaciones>();

		[InverseProperty(nameof(Models.Stocks.FormatoNavigation))]
		public virtual ICollection<Stocks> Stocks { get; set; } = new HashSet<Stocks>();

		[InverseProperty(nameof(Models.Ubicaciones.FormatoNavigation))]
		public virtual ICollection<Ubicaciones> Ubicaciones { get; set; } = new HashSet<Ubicaciones>();

		[InverseProperty(nameof(VentasLinias.MedFormatoNavigation))]
		public virtual ICollection<VentasLinias> VentasLiniasMedFormatoNavigation { get; set; } = new HashSet<VentasLinias>();

		[InverseProperty(nameof(Models.VentasLiniasMedicaciones.idFormatoNavigation))]
		public virtual ICollection<VentasLiniasMedicaciones> VentasLiniasMedicaciones { get; set; } = new HashSet<VentasLiniasMedicaciones>();

		[InverseProperty(nameof(VentasLinias.idFormatoNavigation))]
		public virtual ICollection<VentasLinias> VentasLiniasidFormatoNavigation { get; set; } = new HashSet<VentasLinias>();

	}

}
