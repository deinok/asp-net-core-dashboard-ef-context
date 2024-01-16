using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Paises
	{

		[Key]
		public int Id { get; set; }

		public int? CodigoUE { get; set; }

		[StringLength(50)]
		public string Nacionalidad { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(5)]
		public string Prefijo { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[Obsolete]
		public int? idOld { get; set; }

		[InverseProperty(nameof(Models.Choferes.PaisNavigation))]
		public virtual ICollection<Choferes> Choferes { get; set; } = new HashSet<Choferes>();

		[InverseProperty(nameof(Models.Clientes.PaisNavigation))]
		public virtual ICollection<Clientes> Clientes { get; set; } = new HashSet<Clientes>();

		[InverseProperty(nameof(Models.Domicilios.PaisNavigation))]
		public virtual ICollection<Domicilios> Domicilios { get; set; } = new HashSet<Domicilios>();

		[InverseProperty(nameof(Models.EmpresasTransporte.PaisNavigation))]
		public virtual ICollection<EmpresasTransporte> EmpresasTransporte { get; set; } = new HashSet<EmpresasTransporte>();

		[InverseProperty(nameof(Models.Proveedores.PaisNavigation))]
		public virtual ICollection<Proveedores> Proveedores { get; set; } = new HashSet<Proveedores>();

		[InverseProperty(nameof(Models.ProveedoresOrigenes.PaisNavigation))]
		public virtual ICollection<ProveedoresOrigenes> ProveedoresOrigenes { get; set; } = new HashSet<ProveedoresOrigenes>();

		[InverseProperty(nameof(Models.Provincias.PaisNavigation))]
		public virtual ICollection<Provincias> Provincias { get; set; } = new HashSet<Provincias>();

	}

}
