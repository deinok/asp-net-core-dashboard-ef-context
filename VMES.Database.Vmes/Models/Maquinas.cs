using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class Maquinas
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string TiempoPlc { get; set; }

		public int? HorasAlarma { get; set; }

		public int? Estado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaAccion { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[StringLength(50)]
		public string ReiniciarPlc { get; set; }

		public int Sesion { get; set; }

		public int? SesionNotificacion { get; set; }

		[StringLength(256)]
		public string Marca { get; set; }

		[StringLength(256)]
		public string Modelo { get; set; }

		[StringLength(256)]
		public string Observaciones { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[StringLength(256)]
		public string Situacion { get; set; }

		[StringLength(256)]
		public string Proveedor { get; set; }

		[StringLength(10)]
		public string Telefono { get; set; }

		[StringLength(10)]
		public string Voltaje { get; set; }

		[StringLength(10)]
		public string Potencia { get; set; }

		[StringLength(10)]
		public string Amperaje { get; set; }

		[StringLength(10)]
		public string Rpm { get; set; }

		[StringLength(10)]
		public string Cos { get; set; }

		[StringLength(10)]
		public string Kilos { get; set; }

		[ForeignKey(nameof(Sesion))]
		[InverseProperty(nameof(Sesiones.MaquinasSesionNavigation))]
		public virtual Sesiones SesionNavigation { get; set; }

		[ForeignKey(nameof(SesionNotificacion))]
		[InverseProperty(nameof(Sesiones.MaquinasSesionNotificacionNavigation))]
		public virtual Sesiones SesionNotificacionNavigation { get; set; }

	}

}
