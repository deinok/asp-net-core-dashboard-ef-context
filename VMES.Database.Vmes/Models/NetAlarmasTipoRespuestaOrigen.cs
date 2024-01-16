using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class NetAlarmasTipoRespuestaOrigen
	{

		[Key]
		public int Id { get; set; }

		public int NetAlarmasTipoId { get; set; }

		public int NetAlarmasRespuestaId { get; set; }

		public int OrigenId { get; set; }

		public byte Accion { get; set; }

		public bool Activo { get; set; }

		[ForeignKey(nameof(NetAlarmasTipoId))]
		[InverseProperty(nameof(NetAlarmasTipos.NetAlarmasTiposRespuestasOrigenes))]
		public virtual NetAlarmasTipos NetAlarmasTipo { get; set; }

		[ForeignKey(nameof(NetAlarmasRespuestaId))]
		[InverseProperty(nameof(NetAlarmasRespuestas.NetAlarmasTiposRespuestasOrigenes))]
		public virtual NetAlarmasRespuestas NetAlarmasRespuesta { get; set; }

		[ForeignKey(nameof(OrigenId))]
		[InverseProperty(nameof(Origenes.NetAlarmasTiposRespuestasOrigenes))]
		public virtual Origenes Origen { get; set; }

	}

}
