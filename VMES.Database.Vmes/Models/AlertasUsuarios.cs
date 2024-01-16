using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class AlertasUsuarios
	{

		[Key]
		public int id { get; set; }

		[StringLength(50)]
		public string ReceptorNombre { get; set; }

		public bool? Activo { get; set; }

		[StringLength(50)]
		public string smtpReceptor { get; set; }

		[StringLength(50)]
		public string smtpAsunto { get; set; }

		public string smtpMensaje { get; set; }

		public bool? smtpIsBodyHtml { get; set; }

		public int? idServerSmtp { get; set; }

		[StringLength(50)]
		public string SMSReceptor { get; set; }

		[ForeignKey(nameof(idServerSmtp))]
		[InverseProperty(nameof(AlertasSmtpConfigs.AlertasUsuarios))]
		public virtual AlertasSmtpConfigs idServerSmtpNavigation { get; set; }

		[InverseProperty(nameof(Models.AlertasUsuariosAlarmas.idAlertaUsuarioNavigation))]
		public virtual ICollection<AlertasUsuariosAlarmas> AlertasUsuariosAlarmas { get; set; } = new HashSet<AlertasUsuariosAlarmas>();

		[InverseProperty(nameof(Models.AlertasUsuariosInformes.idAlertasUsuariosNavigation))]
		public virtual ICollection<AlertasUsuariosInformes> AlertasUsuariosInformes { get; set; } = new HashSet<AlertasUsuariosInformes>();

	}

}
