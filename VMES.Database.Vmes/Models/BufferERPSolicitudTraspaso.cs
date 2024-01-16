using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPSolicitudTraspaso
	{

		[Key]
		public int Id { get; set; }

		public int LoteId { get; set; }

		public int DestinoId { get; set; }

		public int OrigenId { get; set; }

		public int UsuarioId { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal Cantidad { get; set; }

		public DateTime FechaSolicitud { get; set; }

		public BufferERPSolicitudTraspasoStatus Estado { get; set; }

		public BufferERPSolicitudTraspasoResponse? Respuesta { get; set; }

		public DateTime? FechaRespuesta { get; set; }

		[StringLength(50)]
		public string TxtErrores { get; set; }

		[ForeignKey(nameof(LoteId))]
		[InverseProperty(nameof(Lotes.BufferERPSolicitudTraspaso))]
		public virtual Lotes Lote { get; set; }

		[ForeignKey(nameof(DestinoId))]
		[InverseProperty(nameof(Ubicaciones.BufferERPSolicitudTraspasoDestinos))]
		public virtual Ubicaciones Destino { get; set; }

		[ForeignKey(nameof(OrigenId))]
		[InverseProperty(nameof(Ubicaciones.BufferERPSolicitudTraspasoOrigenes))]
		public virtual Ubicaciones Origen { get; set; }

		[ForeignKey(nameof(UsuarioId))]
		[InverseProperty(nameof(Usuarios.BufferERPSolicitudTraspaso))]
		public virtual Usuarios Usuario { get; set; }

	}

}
