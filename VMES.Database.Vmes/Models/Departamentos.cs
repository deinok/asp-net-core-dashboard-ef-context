using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Departamentos
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? Empresa { get; set; }

		public int? EtiquetaSacos { get; set; }

		public int? EtiquetaGranel { get; set; }

		public int? EtiquetaControl { get; set; }

		public int? EtiquetaMuestras { get; set; }

		public int? MetodoLote { get; set; }

		[StringLength(50)]
		public string FormatoLote { get; set; }

		public int? PeriodoCaducidad { get; set; }

		public bool? CaducidadAutomatica { get; set; }

		public int? Analisi { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[StringLength(50)]
		public string Direccion { get; set; }

		[StringLength(50)]
		public string Poblacion { get; set; }

		public int? Provincia { get; set; }

		[StringLength(5)]
		public string CodigoPostal { get; set; }

		[StringLength(15)]
		public string Telefono { get; set; }

		[StringLength(15)]
		public string Telefono2 { get; set; }

		[StringLength(15)]
		public string Fax { get; set; }

		public int? EtiquetaEntradas { get; set; }

		public int? idOld { get; set; }

		public bool? Activo { get; set; }

		[StringLength(50)]
		public string DesinfeccionNumRegistro { get; set; }

		[StringLength(50)]
		public string DesinfeccionResponsable { get; set; }

		[StringLength(50)]
		public string DesinfeccionNombreCentro { get; set; }

		[StringLength(50)]
		public string DesinfeccionDesinfectante { get; set; }

		[StringLength(50)]
		public string DesinfeccionDNIResponsable { get; set; }

		[ForeignKey(nameof(Provincia))]
		[InverseProperty(nameof(Provincias.Departamentos))]
		public virtual Provincias ProvinciaNavigation { get; set; }

		[InverseProperty(nameof(Models.Compras.DepartamentoNavigation))]
		public virtual ICollection<Compras> Compras { get; set; } = new HashSet<Compras>();

		[InverseProperty(nameof(Models.Dominios.DepartamentoNavigation))]
		public virtual ICollection<Dominios> Dominios { get; set; } = new HashSet<Dominios>();

		[InverseProperty(nameof(Models.Familias.DepartamentoNavigation))]
		public virtual ICollection<Familias> Familias { get; set; } = new HashSet<Familias>();

		[InverseProperty(nameof(Models.Formulas.DepartamentoNavigation))]
		public virtual ICollection<Formulas> Formulas { get; set; } = new HashSet<Formulas>();

		[InverseProperty(nameof(Models.Modulos.DepartamentoNavigation))]
		public virtual ICollection<Modulos> Modulos { get; set; } = new HashSet<Modulos>();

		[InverseProperty(nameof(Models.Ordenes.DepartamentoNavigation))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

		[InverseProperty(nameof(Models.Salidas.IdDepartamentoNavigation))]
		public virtual ICollection<Salidas> Salidas { get; set; } = new HashSet<Salidas>();

		[InverseProperty(nameof(Models.Ubicaciones.DepartamentoNavigation))]
		public virtual ICollection<Ubicaciones> Ubicaciones { get; set; } = new HashSet<Ubicaciones>();

		[InverseProperty(nameof(Models.Ventas.DepartamentoNavigation))]
		public virtual ICollection<Ventas> Ventas { get; set; } = new HashSet<Ventas>();

	}

}
