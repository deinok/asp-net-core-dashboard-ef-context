using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class AlertasSmtpConfigs
	{

		[Key]
		public int id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string smtpServer { get; set; }

		public int? smtpPort { get; set; }

		[StringLength(50)]
		public string smtpUser { get; set; }

		[StringLength(50)]
		public string smtpPass { get; set; }

		public bool? smtpSSL { get; set; }

		[StringLength(50)]
		public string smtpEmisor { get; set; }

		[InverseProperty(nameof(Models.AlertasUsuarios.idServerSmtpNavigation))]
		public virtual ICollection<AlertasUsuarios> AlertasUsuarios { get; set; } = new HashSet<AlertasUsuarios>();

	}

}
