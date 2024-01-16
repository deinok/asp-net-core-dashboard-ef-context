using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Veterinarios
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string Apellidos { get; set; }

		[StringLength(50)]
		public string NColegiado { get; set; }

		[StringLength(9)]
		public string DNI { get; set; }

		[StringLength(120)]
		public string Domicilio { get; set; }

		[StringLength(10)]
		public string CodigoPostal { get; set; }

		[StringLength(120)]
		public string Poblacion { get; set; }

		public int? ProvinciaId { get; set; }

		public int? IdEmpresa { get; set; }

		public bool Predeterminado { get; set; }

		[ForeignKey(nameof(IdEmpresa))]
		[InverseProperty(nameof(Empresas.Veterinarios))]
		public virtual Empresas IdEmpresaNavigation { get; set; }

		[ForeignKey(nameof(ProvinciaId))]
		[InverseProperty(nameof(Provincias.Veterinarios))]
		public virtual Provincias ProvinciaNavigation { get; set; }

		[InverseProperty(nameof(Models.Recetas.idVeterinarioNavigation))]
		public virtual ICollection<Recetas> Recetas { get; set; } = new HashSet<Recetas>();

	}

}
