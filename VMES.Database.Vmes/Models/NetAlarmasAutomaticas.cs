using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class NetAlarmasAutomaticas
	{

		[Key]
		public int id { get; set; }

		public int? IdModulo { get; set; }

		public int? IdMedidor { get; set; }

		public int? IdAlarmasTipo { get; set; }

		public int? IdNetAlarmasRespuesta { get; set; }

		public bool? Activa { get; set; }

		public int? SegundosControl { get; set; }

		public int? Reintentos { get; set; }

		public int? IdUbicacion { get; set; }

		public bool ForzarFinalizacion { get; set; }

		[ForeignKey(nameof(IdAlarmasTipo))]
		[InverseProperty(nameof(NetAlarmasTipos.NetAlarmasAutomaticas))]
		public virtual NetAlarmasTipos IdAlarmasTipoNavigation { get; set; }

		[ForeignKey(nameof(IdMedidor))]
		[InverseProperty(nameof(Medidor.NetAlarmasAutomaticas))]
		public virtual Medidor IdMedidorNavigation { get; set; }

		[ForeignKey(nameof(IdModulo))]
		[InverseProperty(nameof(Modulos.NetAlarmasAutomaticas))]
		public virtual Modulos IdModuloNavigation { get; set; }

		[ForeignKey(nameof(IdNetAlarmasRespuesta))]
		[InverseProperty(nameof(NetAlarmasTiposRespuestas.NetAlarmasAutomaticas))]
		public virtual NetAlarmasTiposRespuestas IdNetAlarmasRespuestaNavigation { get; set; }

		[ForeignKey(nameof(IdUbicacion))]
		[InverseProperty(nameof(Ubicaciones.NetAlarmasAutomaticas))]
		public virtual Ubicaciones IdUbicacionNavigation { get; set; }

		[InverseProperty(nameof(Models.NetAlarmasAutomaticasOrdenUbicaciones.IdNetAlarmaAutomaticaNavigation))]
		public virtual ICollection<NetAlarmasAutomaticasOrdenUbicaciones> NetAlarmasAutomaticasOrdenUbicaciones { get; set; } = new HashSet<NetAlarmasAutomaticasOrdenUbicaciones>();

	}

}
