using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class NetAlarmasTipos
	{

		[Key]
		public int Id { get; set; }

		[Column("IdAlarmaPLC")]
		public NetAlarmasType? IdPlc { get; set; }

		[StringLength(250)]
		public string TextoError { get; set; }

		public int? Nivel { get; set; }

		public int? UserShow { get; set; }

		public int? RolShow { get; set; }

		public bool? MostrarUsuario { get; set; }

		public int? OEETipo { get; set; }

		public bool? AutoFinalizar { get; set; }

		[ForeignKey(nameof(RolShow))]
		[InverseProperty(nameof(UsuariosRoles.NetAlarmasTipos))]
		public virtual UsuariosRoles RolShowNavigation { get; set; }

		[ForeignKey(nameof(UserShow))]
		[InverseProperty(nameof(Usuarios.NetAlarmasTipos))]
		public virtual Usuarios UserShowNavigation { get; set; }

		[InverseProperty(nameof(Models.AlertasUsuariosAlarmas.idNetAlarmaTipoNavigation))]
		public virtual ICollection<AlertasUsuariosAlarmas> AlertasUsuariosAlarmas { get; set; } = new HashSet<AlertasUsuariosAlarmas>();

		[InverseProperty(nameof(Models.NetAlarmas.IdErrorNavigation))]
		public virtual ICollection<NetAlarmas> NetAlarmas { get; set; } = new HashSet<NetAlarmas>();

		[InverseProperty(nameof(Models.NetAlarmasAutomaticas.IdAlarmasTipoNavigation))]
		public virtual ICollection<NetAlarmasAutomaticas> NetAlarmasAutomaticas { get; set; } = new HashSet<NetAlarmasAutomaticas>();

		[InverseProperty(nameof(Models.NetAlarmasTiposRespuestas.idTipoNavigation))]
		public virtual ICollection<NetAlarmasTiposRespuestas> NetAlarmasTiposRespuestas { get; set; } = new HashSet<NetAlarmasTiposRespuestas>();

		[InverseProperty(nameof(NetAlarmasTipoRespuestaOrigen.NetAlarmasTipo))]
		public virtual ICollection<NetAlarmasTipoRespuestaOrigen> NetAlarmasTiposRespuestasOrigenes { get; set; } = new HashSet<NetAlarmasTipoRespuestaOrigen>();

	}

}
