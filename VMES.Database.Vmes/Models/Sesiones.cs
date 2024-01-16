using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Sesiones
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Equipo { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string Cuenta { get; set; }

		public int? Grupo { get; set; }

		public int? Licencias { get; set; }

		public bool? Automatica { get; set; }

		[StringLength(50)]
		public string UsuarioDefecto { get; set; }

		public bool? Servidor { get; set; }

		public bool? Opc { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[StringLength(50)]
		public string IP { get; set; }

		[StringLength(10)]
		public string VersionApp { get; set; }

		public bool? TransitoManual { get; set; }

		[InverseProperty(nameof(Maquinas.SesionNavigation))]
		public virtual ICollection<Maquinas> MaquinasSesionNavigation { get; set; } = new HashSet<Maquinas>();

		[InverseProperty(nameof(Maquinas.SesionNotificacionNavigation))]
		public virtual ICollection<Maquinas> MaquinasSesionNotificacionNavigation { get; set; } = new HashSet<Maquinas>();

		[InverseProperty(nameof(Models.SesionesModulo.SesionNavigation))]
		public virtual ICollection<SesionesModulo> SesionesModulo { get; set; } = new HashSet<SesionesModulo>();

		[InverseProperty(nameof(Models.SesionesSeccion.SesionNavigation))]
		public virtual ICollection<SesionesSeccion> SesionesSeccion { get; set; } = new HashSet<SesionesSeccion>();

		[InverseProperty(nameof(Models.Ubicaciones.AvisosSesionNavigation))]
		public virtual ICollection<Ubicaciones> Ubicaciones { get; set; } = new HashSet<Ubicaciones>();

	}

}
