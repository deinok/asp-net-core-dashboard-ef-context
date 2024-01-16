using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class UsuariosRolesModulos
	{

		public int idRol { get; set; }

		public int idModulo { get; set; }

		public bool? AlarmasVer { get; set; }

		public bool? AlarmasResponder { get; set; }

		public bool? OrdenesVer { get; set; }

		public bool? OrdenesEditar { get; set; }

		[Key]
		public int Id { get; set; }

		public bool? OrdenesControlar { get; set; }

		[ForeignKey(nameof(idModulo))]
		[InverseProperty(nameof(Modulos.UsuariosRolesModulos))]
		public virtual Modulos idModuloNavigation { get; set; }

		[ForeignKey(nameof(idRol))]
		[InverseProperty(nameof(UsuariosRoles.UsuariosRolesModulos))]
		public virtual UsuariosRoles idRolNavigation { get; set; }

	}

}
