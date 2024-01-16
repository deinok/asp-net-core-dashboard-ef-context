using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class AlertasUsuariosInformesParametros
	{

		[Key]
		public int id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public string Descripción { get; set; }

		[StringLength(50)]
		public string Valor { get; set; }

		public int? Tipo { get; set; }

		public int? idAlertaUsuarioInformes { get; set; }

		[ForeignKey(nameof(idAlertaUsuarioInformes))]
		[InverseProperty(nameof(AlertasUsuariosInformes.AlertasUsuariosInformesParametros))]
		public virtual AlertasUsuariosInformes idAlertaUsuarioInformesNavigation { get; set; }

	}

}
