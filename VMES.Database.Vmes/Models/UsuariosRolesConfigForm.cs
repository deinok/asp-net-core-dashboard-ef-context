using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class UsuariosRolesConfigForm
	{

		[Key]
		public int Id { get; set; }

		public int UsuarioRol { get; set; }

		[Required]
		[StringLength(50)]
		public string Formulario { get; set; }

		[Required]
		[StringLength(50)]
		public string Control { get; set; }

		[Required]
		[StringLength(50)]
		public string Propiedad { get; set; }

		[StringLength(500)]
		public string Valor { get; set; }

		[Required]
		public bool? Activo { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime FechaCreacion { get; set; }

		public int Tipo { get; set; }

		[StringLength(50)]
		public string Metodo { get; set; }

		[ForeignKey(nameof(UsuarioRol))]
		[InverseProperty(nameof(UsuariosRoles.UsuariosRolesConfigForm))]
		public virtual UsuariosRoles UsuarioRolNavigation { get; set; }

	}

}
