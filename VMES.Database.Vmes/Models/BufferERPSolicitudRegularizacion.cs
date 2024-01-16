using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPSolicitudRegularizacion
	{

		[Key]
		public int id { get; set; }

		public int? IdUbicacion { get; set; }

		[Column(TypeName = "decimal(15, 5)")]
		public decimal? Cantidad { get; set; }

		public int? IdUsuario { get; set; }

		public BufferERPSolicitudRegularizacionResponse? Respuesta { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaEnvio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaSolicitud { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaRespuesta { get; set; }

		public BufferERPSolicitudRegularizacionStatus? Estado { get; set; }

		[StringLength(50)]
		public string TxtErrores { get; set; }

		public int? IdLote { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		[ForeignKey(nameof(IdLote))]
		[InverseProperty(nameof(Lotes.BufferERPSolicitudRegularizacion))]
		public virtual Lotes IdLoteNavigation { get; set; }

		[ForeignKey(nameof(IdUbicacion))]
		[InverseProperty(nameof(Ubicaciones.BufferERPSolicitudRegularizacion))]
		public virtual Ubicaciones IdUbicacionNavigation { get; set; }

		[ForeignKey(nameof(IdUsuario))]
		[InverseProperty(nameof(Usuarios.BufferERPSolicitudRegularizacion))]
		public virtual Usuarios IdUsuarioNavigation { get; set; }

	}

}
