using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Usuarios
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? Nivel { get; set; }

		public int? Grupo { get; set; }

		[StringLength(20)]
		public string Clave { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? Rol { get; set; }

		public bool? ActivoScada { get; set; }

		public bool? AutoPremezclas { get; set; }

		public bool? PermisoScada { get; set; }

		public bool? AutoTransito { get; set; }

		public bool? AutoEntAlmacen { get; set; }

		public int? IdOpc { get; set; }

		public bool? LDAPUser { get; set; }

		[StringLength(100)]
		public string LDAPUserName { get; set; }

		[StringLength(100)]
		public string LDAPUserSid { get; set; }

		[ForeignKey(nameof(IdOpc))]
		[InverseProperty(nameof(OpcConfig.Usuarios))]
		public virtual OpcConfig IdOpcNavigation { get; set; }

		[ForeignKey(nameof(Rol))]
		[InverseProperty(nameof(UsuariosRoles.UsuariosNavigation))]
		public virtual UsuariosRoles RolNavigation { get; set; }

		[InverseProperty(nameof(Models.BufferERPSolicitudRegularizacion.IdUsuarioNavigation))]
		public virtual ICollection<BufferERPSolicitudRegularizacion> BufferERPSolicitudRegularizacion { get; set; } = new HashSet<BufferERPSolicitudRegularizacion>();

		[InverseProperty(nameof(Models.BufferERPSolicitudTraspaso.Usuario))]
		public virtual ICollection<BufferERPSolicitudTraspaso> BufferERPSolicitudTraspaso { get; set; } = new HashSet<BufferERPSolicitudTraspaso>();

		[InverseProperty(nameof(GMAO_SolicitudOrdenTrabajo.CreadaPor))]
		public virtual ICollection<GMAO_SolicitudOrdenTrabajo> GMAO_SolicitudOrdenTrabajoCreadaPor { get; set; } = new HashSet<GMAO_SolicitudOrdenTrabajo>();

		[InverseProperty(nameof(GMAO_SolicitudOrdenTrabajo.GestionadaPor))]
		public virtual ICollection<GMAO_SolicitudOrdenTrabajo> GMAO_SolicitudOrdenTrabajoGestionadaPor { get; set; } = new HashSet<GMAO_SolicitudOrdenTrabajo>();

		[InverseProperty(nameof(Models.InformesLibUsuarios.IdUsuarioNavigation))]
		public virtual ICollection<InformesLibUsuarios> InformesLibUsuarios { get; set; } = new HashSet<InformesLibUsuarios>();

		[InverseProperty(nameof(Models.LogMovimientosStocks.OperarioNavigation))]
		public virtual ICollection<LogMovimientosStocks> LogMovimientosStocks { get; set; } = new HashSet<LogMovimientosStocks>();

		[InverseProperty(nameof(Models.NetAlarmasTipos.UserShowNavigation))]
		public virtual ICollection<NetAlarmasTipos> NetAlarmasTipos { get; set; } = new HashSet<NetAlarmasTipos>();

		[InverseProperty(nameof(Models.OpcionesUsuarios.idUsuarioNavigation))]
		public virtual ICollection<OpcionesUsuarios> OpcionesUsuarios { get; set; } = new HashSet<OpcionesUsuarios>();

		[InverseProperty(nameof(Models.Regularizaciones.UsuarioNavigation))]
		public virtual ICollection<Regularizaciones> Regularizaciones { get; set; } = new HashSet<Regularizaciones>();

		[InverseProperty(nameof(SolicitudAjusteCaudal.Usuario))]
		public virtual ICollection<SolicitudAjusteCaudal> SolicitudesAjusteCaudal { get; set; } = new HashSet<SolicitudAjusteCaudal>();

		[InverseProperty(nameof(Models.UsuariosLogs.idUsuarioNavigation))]
		public virtual ICollection<UsuariosLogs> UsuariosLogs { get; set; } = new HashSet<UsuariosLogs>();

	}

}
