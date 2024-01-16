using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Empresas
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string Direccion { get; set; }

		[StringLength(40)]
		public string Poblacion { get; set; }

		[StringLength(5)]
		public string CodigoPostal { get; set; }

		[StringLength(50)]
		public string Provincia { get; set; }

		[StringLength(15)]
		public string Telefono { get; set; }

		[StringLength(15)]
		public string Fax { get; set; }

		public byte[] Logotipo { get; set; }

		[StringLength(50)]
		public string RSanidad { get; set; }

		[StringLength(50)]
		public string RIA { get; set; }

		[StringLength(50)]
		public string Cabecera1 { get; set; }

		[StringLength(50)]
		public string Cabecera2 { get; set; }

		[StringLength(50)]
		public string Cabecera3 { get; set; }

		[StringLength(50)]
		public string Cabecera4 { get; set; }

		[StringLength(50)]
		public string Cabecera5 { get; set; }

		[StringLength(254)]
		public string RegistroMercantil { get; set; }

		[StringLength(50)]
		public string Autorizacion { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[StringLength(14)]
		public string CIF { get; set; }

		[StringLength(50)]
		public string AutorizacionDestinoFinal { get; set; }

		[InverseProperty(nameof(Models.Veterinarios.IdEmpresaNavigation))]
		public virtual ICollection<Veterinarios> Veterinarios { get; set; } = new HashSet<Veterinarios>();

	}

}
