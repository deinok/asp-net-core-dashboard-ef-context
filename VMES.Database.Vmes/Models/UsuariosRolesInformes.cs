using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class UsuariosRolesInformes
	{

		[Key]
		public int id { get; set; }

		public int? idRol { get; set; }

		public int? idInforme { get; set; }

		public bool? Ver { get; set; }

		public bool? Editar { get; set; }

		[ForeignKey(nameof(idRol))]
		[InverseProperty(nameof(UsuariosRoles.UsuariosRolesInformes))]
		public virtual UsuariosRoles idRolNavigation { get; set; }

	}

}
