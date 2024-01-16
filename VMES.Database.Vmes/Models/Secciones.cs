using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Secciones
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string Estado { get; set; }

		public int? Modulo { get; set; }

		public bool? Entradas { get; set; }

		public bool? Salidas { get; set; }

		public int? Medidor { get; set; }

		public int? Equipo { get; set; }

		public bool? Mantener { get; set; }

		public bool? Registrar { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? EquipoRemoto { get; set; }

		public int? Sesion { get; set; }

		public int? SesionRemoto { get; set; }

		public int? IdPlc { get; set; }

		public int? OpcConfigId { get; set; }

		[ForeignKey(nameof(OpcConfigId))]
		[InverseProperty(nameof(Models.OpcConfig.Secciones))]
		public virtual OpcConfig OpcConfig { get; set; }

		[InverseProperty(nameof(Models.NetAlarmas.IdSeccionNavigation))]
		public virtual ICollection<NetAlarmas> NetAlarmas { get; set; } = new HashSet<NetAlarmas>();

		[InverseProperty(nameof(Models.SesionesSeccion.SeccionNavigation))]
		public virtual ICollection<SesionesSeccion> SesionesSeccion { get; set; } = new HashSet<SesionesSeccion>();

	}

}
