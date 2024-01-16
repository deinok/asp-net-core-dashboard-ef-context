using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class NetAlarmasTiposRespuestas
	{

		[Key]
		public int id { get; set; }

		public int idTipo { get; set; }

		public int idRespuesta { get; set; }

		public bool Activado { get; set; }

		[ForeignKey(nameof(idRespuesta))]
		[InverseProperty(nameof(NetAlarmasRespuestas.NetAlarmasTiposRespuestas))]
		public virtual NetAlarmasRespuestas idRespuestaNavigation { get; set; }

		[ForeignKey(nameof(idTipo))]
		[InverseProperty(nameof(NetAlarmasTipos.NetAlarmasTiposRespuestas))]
		public virtual NetAlarmasTipos idTipoNavigation { get; set; }

		[InverseProperty(nameof(Models.NetAlarmasAutomaticas.IdNetAlarmasRespuestaNavigation))]
		public virtual ICollection<NetAlarmasAutomaticas> NetAlarmasAutomaticas { get; set; } = new HashSet<NetAlarmasAutomaticas>();

	}

}
