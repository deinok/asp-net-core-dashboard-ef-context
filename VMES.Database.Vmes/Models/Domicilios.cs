using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Domicilios
	{

		[Key]
		public int Id { get; set; }

		public int? Cliente { get; set; }

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

		[StringLength(50)]
		public string MarcaOficial { get; set; }

		public bool? Importado { get; set; }

		public bool? Refrescado { get; set; }

		public bool? Exportado { get; set; }

		[StringLength(50)]
		public string Responsable { get; set; }

		public int? Especie { get; set; }

		public int? NumeroEspecies { get; set; }

		public bool? Inhabilitado { get; set; }

		[StringLength(50)]
		public string Descripcion { get; set; }

		[StringLength(20)]
		public string Simogan { get; set; }

		[StringLength(20)]
		public string REGA { get; set; }

		[StringLength(20)]
		public string LoteAnimalActual { get; set; }

		public int? IntegraId { get; set; }

		[ForeignKey(nameof(Cliente))]
		[InverseProperty(nameof(Clientes.Domicilios))]
		public virtual Clientes ClienteNavigation { get; set; }

		[ForeignKey(nameof(Especie))]
		[InverseProperty(nameof(Especies.Domicilios))]
		public virtual Especies EspecieNavigation { get; set; }

		[ForeignKey(nameof(Pais))]
		[InverseProperty(nameof(Paises.Domicilios))]
		public virtual Paises PaisNavigation { get; set; }

		[ForeignKey(nameof(Provincia))]
		[InverseProperty(nameof(Provincias.Domicilios))]
		public virtual Provincias ProvinciaNavigation { get; set; }

		[InverseProperty(nameof(Models.PuntosDescarga.idDomicilioNavigation))]
		public virtual ICollection<PuntosDescarga> PuntosDescarga { get; set; } = new HashSet<PuntosDescarga>();

		[InverseProperty(nameof(Models.Recetas.idDomicilioNavigation))]
		public virtual ICollection<Recetas> Recetas { get; set; } = new HashSet<Recetas>();

		[InverseProperty(nameof(Models.SalidasLinias.idDomicilioNavigation))]
		public virtual ICollection<SalidasLinias> SalidasLinias { get; set; } = new HashSet<SalidasLinias>();

		[InverseProperty(nameof(Models.Ventas.idDomicilioNavigation))]
		public virtual ICollection<Ventas> Ventas { get; set; } = new HashSet<Ventas>();

		[InverseProperty(nameof(Models.VentasLinias.idDomicilioNavigation))]
		public virtual ICollection<VentasLinias> VentasLinias { get; set; } = new HashSet<VentasLinias>();

	}

}
