using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class OpcionesUsuarios
	{

		[Key]
		[StringLength(50)]
		public string idClave { get; set; }

		[Key]
		public int idUsuario { get; set; }

		[Required]
		[StringLength(250)]
		public string valor { get; set; }

		[ForeignKey(nameof(idClave))]
		[InverseProperty(nameof(Opciones.OpcionesUsuarios))]
		public virtual Opciones idClaveNavigation { get; set; }

		[ForeignKey(nameof(idUsuario))]
		[InverseProperty(nameof(Usuarios.OpcionesUsuarios))]
		public virtual Usuarios idUsuarioNavigation { get; set; }

	}

}
