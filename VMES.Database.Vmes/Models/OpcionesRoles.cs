using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class OpcionesRoles
	{

		[Key]
		[StringLength(50)]
		public string idClave { get; set; }

		[Key]
		public int idRol { get; set; }

		[Required]
		[StringLength(250)]
		public string valor { get; set; }

		[ForeignKey(nameof(idClave))]
		[InverseProperty(nameof(Opciones.OpcionesRoles))]
		public virtual Opciones idClaveNavigation { get; set; }

		[ForeignKey(nameof(idRol))]
		[InverseProperty(nameof(UsuariosRoles.OpcionesRoles))]
		public virtual UsuariosRoles idRolNavigation { get; set; }

	}

}
