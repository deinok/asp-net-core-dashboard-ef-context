using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Provincias
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? Pais { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[Obsolete]
		public int? idOld { get; set; }

		[ForeignKey(nameof(Pais))]
		[InverseProperty(nameof(Paises.Provincias))]
		public virtual Paises PaisNavigation { get; set; }

		[InverseProperty(nameof(Models.Choferes.ProvinciaNavigation))]
		public virtual ICollection<Choferes> Choferes { get; set; } = new HashSet<Choferes>();

		[InverseProperty(nameof(Models.Clientes.ProvinciaNavigation))]
		public virtual ICollection<Clientes> Clientes { get; set; } = new HashSet<Clientes>();

		[InverseProperty(nameof(Models.Departamentos.ProvinciaNavigation))]
		public virtual ICollection<Departamentos> Departamentos { get; set; } = new HashSet<Departamentos>();

		[InverseProperty(nameof(Models.Domicilios.ProvinciaNavigation))]
		public virtual ICollection<Domicilios> Domicilios { get; set; } = new HashSet<Domicilios>();

		[InverseProperty(nameof(Models.EmpresasTransporte.ProvinciaNavigation))]
		public virtual ICollection<EmpresasTransporte> EmpresasTransporte { get; set; } = new HashSet<EmpresasTransporte>();

		[InverseProperty(nameof(Models.Proveedores.ProvinciaNavigation))]
		public virtual ICollection<Proveedores> Proveedores { get; set; } = new HashSet<Proveedores>();

		[InverseProperty(nameof(Models.ProveedoresOrigenes.ProvinciaNavigation))]
		public virtual ICollection<ProveedoresOrigenes> ProveedoresOrigenes { get; set; } = new HashSet<ProveedoresOrigenes>();

		[InverseProperty(nameof(Models.Veterinarios.ProvinciaNavigation))]
		public virtual ICollection<Veterinarios> Veterinarios { get; set; } = new HashSet<Veterinarios>();

	}

}
