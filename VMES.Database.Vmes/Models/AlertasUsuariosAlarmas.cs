using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class AlertasUsuariosAlarmas
	{

		[Key]
		public int id { get; set; }

		public int idAlertaUsuario { get; set; }

		public int idNetAlarmaTipo { get; set; }

		public int? idModulo { get; set; }

		public bool? ActivoMail { get; set; }

		public bool? ActivoSMS { get; set; }

		[ForeignKey(nameof(idAlertaUsuario))]
		[InverseProperty(nameof(AlertasUsuarios.AlertasUsuariosAlarmas))]
		public virtual AlertasUsuarios idAlertaUsuarioNavigation { get; set; }

		[ForeignKey(nameof(idModulo))]
		[InverseProperty(nameof(Modulos.AlertasUsuariosAlarmas))]
		public virtual Modulos idModuloNavigation { get; set; }

		[ForeignKey(nameof(idNetAlarmaTipo))]
		[InverseProperty(nameof(NetAlarmasTipos.AlertasUsuariosAlarmas))]
		public virtual NetAlarmasTipos idNetAlarmaTipoNavigation { get; set; }

	}

}
