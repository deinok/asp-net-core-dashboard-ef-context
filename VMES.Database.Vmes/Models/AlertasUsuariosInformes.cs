using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class AlertasUsuariosInformes
	{

		[Key]
		public int id { get; set; }

		public int? idAlertasUsuarios { get; set; }

		public int? idInforme { get; set; }

		[StringLength(50)]
		public string Asunto { get; set; }

		public string Mensaje { get; set; }

		public int? TipoProgramacion { get; set; }

		public int? DiaSemana { get; set; }

		public int? DiaMes1 { get; set; }

		public int? DiaMes2 { get; set; }

		public int? HoraEntrega { get; set; }

		[ForeignKey(nameof(idAlertasUsuarios))]
		[InverseProperty(nameof(AlertasUsuarios.AlertasUsuariosInformes))]
		public virtual AlertasUsuarios idAlertasUsuariosNavigation { get; set; }

		[InverseProperty(nameof(Models.AlertasUsuariosInformesParametros.idAlertaUsuarioInformesNavigation))]
		public virtual ICollection<AlertasUsuariosInformesParametros> AlertasUsuariosInformesParametros { get; set; } = new HashSet<AlertasUsuariosInformesParametros>();

	}

}
