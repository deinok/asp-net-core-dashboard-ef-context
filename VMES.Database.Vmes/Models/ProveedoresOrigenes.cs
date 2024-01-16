using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class ProveedoresOrigenes
	{

		[Key]
		public int id { get; set; }

		public int Proveedor { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[StringLength(50)]
		public string Direccion { get; set; }

		[StringLength(50)]
		public string Poblacion { get; set; }

		[StringLength(20)]
		public string Telefono { get; set; }

		[StringLength(5)]
		public string CodigoPostal { get; set; }

		public int? Provincia { get; set; }

		public int? Pais { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[StringLength(50)]
		public string Responsable { get; set; }

		public bool? Inhabilitado { get; set; }

		[StringLength(50)]
		public string Descripcion { get; set; }

		[ForeignKey(nameof(Pais))]
		[InverseProperty(nameof(Paises.ProveedoresOrigenes))]
		public virtual Paises PaisNavigation { get; set; }

		[ForeignKey(nameof(Proveedor))]
		[InverseProperty(nameof(Proveedores.ProveedoresOrigenes))]
		public virtual Proveedores ProveedorNavigation { get; set; }

		[ForeignKey(nameof(Provincia))]
		[InverseProperty(nameof(Provincias.ProveedoresOrigenes))]
		public virtual Provincias ProvinciaNavigation { get; set; }

		[InverseProperty(nameof(Models.EntradasLineas.idOrigenProvNavigation))]
		public virtual ICollection<EntradasLineas> EntradasLineas { get; set; } = new HashSet<EntradasLineas>();

	}

}
