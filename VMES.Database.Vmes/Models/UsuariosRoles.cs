using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class UsuariosRoles
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(250)]
		public string Descripcion { get; set; }

		public bool? UbicacionesVer { get; set; }

		public bool? UbicacionesEditar { get; set; }

		public bool? ProductosVer { get; set; }

		public bool? ProductosEditar { get; set; }

		public bool? Configuracion { get; set; }

		public bool? Usuarios { get; set; }

		public bool? EntradasVer { get; set; }

		public bool? EntradasEditar { get; set; }

		public bool? SalidasVer { get; set; }

		public bool? SalidasEditar { get; set; }

		public bool? VerTodasAlarmas { get; set; }

		public bool? ResponderTodasAlarmas { get; set; }

		public bool? VerTodosModulos { get; set; }

		public bool? EditarTodosModulos { get; set; }

		public bool? Formulacion { get; set; }

		public bool? Maestros { get; set; }

		public bool? InformesVer { get; set; }

		public bool? InformesEditar { get; set; }

		public bool? ConfigUbicaciones { get; set; }

		public bool? ContratosVer { get; set; }

		public bool? ContratosEditar { get; set; }

		public bool? Quimica { get; set; }

		public bool? Produccion { get; set; }

		public bool? OrdenesAConfirmarVer { get; set; }

		public bool? OrdenesAConfirmarEditar { get; set; }

		public bool? OrdenesVer { get; set; }

		public bool? OrdenesEditar { get; set; }

		public bool? ERP { get; set; }

		public bool? Copias { get; set; }

		public bool? Utilidades { get; set; }

		public bool? Comunicaciones { get; set; }

		public bool? Transito { get; set; }

		public bool? LotesVer { get; set; }

		public bool? LotesEditar { get; set; }

		public bool? StocksVer { get; set; }

		public bool? StocksEditar { get; set; }

		public bool? Laboratorio { get; set; }

		public bool? DashboardVer { get; set; }

		public bool? Premezclas { get; set; }

		public bool? PlantillasVer { get; set; }

		public bool? PlantillasEditar { get; set; }

		public bool? Productividad { get; set; }

		public bool? Inventarios { get; set; }

		public bool? Incompatibilidades { get; set; }

		public bool? Tarjetas { get; set; }

		public bool? DesinfeccionVer { get; set; }

		public bool? DesinfeccionEditar { get; set; }

		public bool? MedicamentosVer { get; set; }

		public bool? MedicamentosEditar { get; set; }

		public bool? StocksPestana { get; set; }

		public bool? Gestion { get; set; }

		public bool? ComprasVer { get; set; }

		public bool? ComprasEditar { get; set; }

		public bool? VentasVer { get; set; }

		public bool? VentasEditar { get; set; }

		public bool? GMAO { get; set; }

		public bool? ModuloEnergia { get; set; }

		public bool? ModuloOEE { get; set; }

		public bool? VisorDosificacionesVer { get; set; }

		public bool? AutoRespuestasVer { get; set; }

		public bool? EntradasAlmacenVer { get; set; }

		public bool? EntradasAlmacenEditar { get; set; }

		public bool? SalidasViajesVer { get; set; }

		public bool? SalidasViajesEditar { get; set; }

		public bool? RecetasVer { get; set; }

		public bool? RecetasEditar { get; set; }

		public bool? PRECabOrdenesProduccion { get; set; }

		public bool? PRECabOrdenesSalidasViajes { get; set; }

		public bool? TrazabilidadResumenVer { get; set; }

		public bool? CambioRapidoOPC { get; set; }

		public bool? SMTP { get; set; }

		public bool? Alertas { get; set; }

		public bool? ResetComunicaciones { get; set; }

		public bool? DashboardEditar { get; set; }

		public bool? LayoutMaximizar { get; set; }

		public bool ForzarPopupAlarmas { get; set; }

		[InverseProperty(nameof(Models.Modulos.RolBaseNavigation))]
		public virtual ICollection<Modulos> Modulos { get; set; } = new HashSet<Modulos>();

		[InverseProperty(nameof(Models.NetAlarmasTipos.RolShowNavigation))]
		public virtual ICollection<NetAlarmasTipos> NetAlarmasTipos { get; set; } = new HashSet<NetAlarmasTipos>();

		[InverseProperty(nameof(Models.OpcionesRoles.idRolNavigation))]
		public virtual ICollection<OpcionesRoles> OpcionesRoles { get; set; } = new HashSet<OpcionesRoles>();

		[InverseProperty(nameof(Models.UsuariosGruposLDAP.idRolNavigation))]
		public virtual ICollection<UsuariosGruposLDAP> UsuariosGruposLDAP { get; set; } = new HashSet<UsuariosGruposLDAP>();

		[InverseProperty(nameof(Models.Usuarios.RolNavigation))]
		public virtual ICollection<Usuarios> UsuariosNavigation { get; set; } = new HashSet<Usuarios>();

		[InverseProperty(nameof(Models.UsuariosRolesConfigForm.UsuarioRolNavigation))]
		public virtual ICollection<UsuariosRolesConfigForm> UsuariosRolesConfigForm { get; set; } = new HashSet<UsuariosRolesConfigForm>();

		[InverseProperty(nameof(Models.UsuariosRolesInformes.idRolNavigation))]
		public virtual ICollection<UsuariosRolesInformes> UsuariosRolesInformes { get; set; } = new HashSet<UsuariosRolesInformes>();

		[InverseProperty(nameof(Models.UsuariosRolesModulos.idRolNavigation))]
		public virtual ICollection<UsuariosRolesModulos> UsuariosRolesModulos { get; set; } = new HashSet<UsuariosRolesModulos>();

	}

}
