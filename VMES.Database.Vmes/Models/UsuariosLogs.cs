using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class UsuariosLogs
	{

		[Key]
		public int id { get; set; }

		public int? idUsuario { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Login { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Desconexion { get; set; }

		public bool? Activo { get; set; }

		[StringLength(50)]
		public string PC { get; set; }

		[ForeignKey(nameof(idUsuario))]
		[InverseProperty(nameof(Usuarios.UsuariosLogs))]
		public virtual Usuarios idUsuarioNavigation { get; set; }

	}

}
