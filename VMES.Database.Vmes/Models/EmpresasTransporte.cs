using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class EmpresasTransporte
	{

		[Key]
		public int Id { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(14)]
		public string CIF { get; set; }

		[StringLength(50)]
		public string Direccion { get; set; }

		[StringLength(50)]
		public string Poblacion { get; set; }

		[StringLength(5)]
		public string CodigoPostal { get; set; }

		public int? Provincia { get; set; }

		public int? Pais { get; set; }

		[StringLength(20)]
		public string Telefono { get; set; }

		[StringLength(20)]
		public string Fax { get; set; }

		public bool? Refrescado { get; set; }

		public bool? Exportado { get; set; }

		public bool? Importado { get; set; }

		public int? idOld { get; set; }

		public bool? Activo { get; set; }

		[ForeignKey(nameof(Pais))]
		[InverseProperty(nameof(Paises.EmpresasTransporte))]
		public virtual Paises PaisNavigation { get; set; }

		[ForeignKey(nameof(Provincia))]
		[InverseProperty(nameof(Provincias.EmpresasTransporte))]
		public virtual Provincias ProvinciaNavigation { get; set; }

		[InverseProperty(nameof(Models.Entradas.idEmpresaTransporteNavigation))]
		public virtual ICollection<Entradas> Entradas { get; set; } = new HashSet<Entradas>();

		[InverseProperty(nameof(Models.SalidasViajes.idEmpresaTransporteNavigation))]
		public virtual ICollection<SalidasViajes> SalidasViajes { get; set; } = new HashSet<SalidasViajes>();

		[InverseProperty(nameof(Models.Vehiculos.EmpresaTransporteNavigation))]
		public virtual ICollection<Vehiculos> Vehiculos { get; set; } = new HashSet<Vehiculos>();

	}

}
