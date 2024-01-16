using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class UsuariosGruposLDAP
	{

		[Key]
		public int id { get; set; }

		[StringLength(100)]
		public string GrupoLDAP { get; set; }

		public int? idRol { get; set; }

		[ForeignKey(nameof(idRol))]
		[InverseProperty(nameof(UsuariosRoles.UsuariosGruposLDAP))]
		public virtual UsuariosRoles idRolNavigation { get; set; }

	}

}
