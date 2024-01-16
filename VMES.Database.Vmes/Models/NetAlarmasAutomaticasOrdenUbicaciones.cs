using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class NetAlarmasAutomaticasOrdenUbicaciones
	{

		[Key]
		public int id { get; set; }

		public int? IdNetAlarmaAutomatica { get; set; }

		public int? IdOrden { get; set; }

		public int? IdUbicacion { get; set; }

		public int? Ordenacion { get; set; }

		public bool? Procesada { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaCreacion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaProcesada { get; set; }

		public int? IdDosificacion { get; set; }

		[ForeignKey(nameof(IdDosificacion))]
		[InverseProperty(nameof(Dosificaciones.NetAlarmasAutomaticasOrdenUbicaciones))]
		public virtual Dosificaciones IdDosificacionNavigation { get; set; }

		[ForeignKey(nameof(IdNetAlarmaAutomatica))]
		[InverseProperty(nameof(NetAlarmasAutomaticas.NetAlarmasAutomaticasOrdenUbicaciones))]
		public virtual NetAlarmasAutomaticas IdNetAlarmaAutomaticaNavigation { get; set; }

		[ForeignKey(nameof(IdOrden))]
		[InverseProperty(nameof(Ordenes.NetAlarmasAutomaticasOrdenUbicaciones))]
		public virtual Ordenes IdOrdenNavigation { get; set; }

		[ForeignKey(nameof(IdUbicacion))]
		[InverseProperty(nameof(Ubicaciones.NetAlarmasAutomaticasOrdenUbicaciones))]
		public virtual Ubicaciones IdUbicacionNavigation { get; set; }

	}

}
