using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Choferes
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public bool? Importado { get; set; }

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

		public bool? Refrescado { get; set; }

		public bool? Exportado { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		public int? idOld { get; set; }

		public int? Tarjeta { get; set; }

		public bool? Activo { get; set; }

		[ForeignKey(nameof(Pais))]
		[InverseProperty(nameof(Paises.Choferes))]
		public virtual Paises PaisNavigation { get; set; }

		[ForeignKey(nameof(Provincia))]
		[InverseProperty(nameof(Provincias.Choferes))]
		public virtual Provincias ProvinciaNavigation { get; set; }

		[ForeignKey(nameof(Tarjeta))]
		[InverseProperty(nameof(Tarjetas.Choferes))]
		public virtual Tarjetas TarjetaNavigation { get; set; }

		[InverseProperty(nameof(Models.CertificadoDesinfeccion.idTransportistaNavigation))]
		public virtual ICollection<CertificadoDesinfeccion> CertificadoDesinfeccion { get; set; } = new HashSet<CertificadoDesinfeccion>();

		[InverseProperty(nameof(Models.Entradas.idChoferNavigation))]
		public virtual ICollection<Entradas> Entradas { get; set; } = new HashSet<Entradas>();

		[InverseProperty(nameof(Models.Ordenes.idChoferNavigation))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

		[InverseProperty(nameof(Models.SalidasViajes.idChoferNavigation))]
		public virtual ICollection<SalidasViajes> SalidasViajes { get; set; } = new HashSet<SalidasViajes>();

		[InverseProperty(nameof(Models.Vehiculos.ChoferNavigation))]
		public virtual ICollection<Vehiculos> Vehiculos { get; set; } = new HashSet<Vehiculos>();

	}

}
