using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Proveedores
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

		[StringLength(20)]
		public string Telefono { get; set; }

		public int? Provincia { get; set; }

		[StringLength(40)]
		public string Abreviado { get; set; }

		public bool Importado { get; set; }

		public int? Pais { get; set; }

		public bool? Inhabilitado { get; set; }

		[Obsolete]
		public bool? Refrescado { get; set; }

		public bool Exportado { get; set; }

		[Obsolete]
		public int? idOld { get; set; }

		[StringLength(50)]
		public string NombreContacto { get; set; }

		[StringLength(20)]
		public string TelefonoContacto { get; set; }

		[StringLength(50)]
		public string Email { get; set; }

		[StringLength(50)]
		public string AutorizacionDestinoFinal { get; set; }

		public bool? PorDefecto { get; set; }

		[ForeignKey(nameof(Pais))]
		[InverseProperty(nameof(Paises.Proveedores))]
		public virtual Paises PaisNavigation { get; set; }

		[ForeignKey(nameof(Provincia))]
		[InverseProperty(nameof(Provincias.Proveedores))]
		public virtual Provincias ProvinciaNavigation { get; set; }

		[InverseProperty(nameof(Models.Compras.ProveedorNavigation))]
		public virtual ICollection<Compras> Compras { get; set; } = new HashSet<Compras>();

		[InverseProperty(nameof(Models.Contratos.IdProveedorNavigation))]
		public virtual ICollection<Contratos> Contratos { get; set; } = new HashSet<Contratos>();

		[InverseProperty(nameof(Models.Entradas.idProveedorNavigation))]
		public virtual ICollection<Entradas> Entradas { get; set; } = new HashSet<Entradas>();

		[InverseProperty(nameof(Models.EntradasLineas.idProveedorNavigation))]
		public virtual ICollection<EntradasLineas> EntradasLineas { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(Models.Existencias.idProveedorNavigation))]
		public virtual ICollection<Existencias> Existencias { get; set; } = new HashSet<Existencias>();

		[InverseProperty(nameof(Models.Lotes.IdProveedorNavigation))]
		public virtual ICollection<Lotes> Lotes { get; set; } = new HashSet<Lotes>();

		[InverseProperty(nameof(Models.ProveedoresOrigenes.ProveedorNavigation))]
		public virtual ICollection<ProveedoresOrigenes> ProveedoresOrigenes { get; set; } = new HashSet<ProveedoresOrigenes>();

	}

}
