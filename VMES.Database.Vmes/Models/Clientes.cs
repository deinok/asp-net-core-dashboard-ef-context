using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Clientes
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

		[StringLength(5)]
		public string CodigoPostal { get; set; }

		[StringLength(50)]
		public string Poblacion { get; set; }

		public int? Provincia { get; set; }

		public int? Pais { get; set; }

		[StringLength(20)]
		public string Telefono { get; set; }

		public bool? Inhabilitado { get; set; }

		public bool Importado { get; set; }

		public bool? Refrescado { get; set; }

		public bool Exportado { get; set; }

		[StringLength(50)]
		public string RazonSocial { get; set; }

		public int? idOld { get; set; }

		public bool? PorDefecto { get; set; }

		[ForeignKey(nameof(Pais))]
		[InverseProperty(nameof(Paises.Clientes))]
		public virtual Paises PaisNavigation { get; set; }

		[ForeignKey(nameof(Provincia))]
		[InverseProperty(nameof(Provincias.Clientes))]
		public virtual Provincias ProvinciaNavigation { get; set; }

		[InverseProperty(nameof(Models.Contratos.IdClienteNavigation))]
		public virtual ICollection<Contratos> Contratos { get; set; } = new HashSet<Contratos>();

		[InverseProperty(nameof(Models.Domicilios.ClienteNavigation))]
		public virtual ICollection<Domicilios> Domicilios { get; set; } = new HashSet<Domicilios>();

		[InverseProperty(nameof(Models.Recetas.idClienteNavigation))]
		public virtual ICollection<Recetas> Recetas { get; set; } = new HashSet<Recetas>();

		[InverseProperty(nameof(Models.Salidas.idClienteNavigation))]
		public virtual ICollection<Salidas> Salidas { get; set; } = new HashSet<Salidas>();

		[InverseProperty(nameof(Models.Tarifas.ClienteNavigation))]
		public virtual ICollection<Tarifas> Tarifas { get; set; } = new HashSet<Tarifas>();

		[InverseProperty(nameof(Models.Ventas.idClienteNavigation))]
		public virtual ICollection<Ventas> Ventas { get; set; } = new HashSet<Ventas>();

	}

}
