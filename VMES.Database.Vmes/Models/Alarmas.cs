using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Alarmas
	{

		public int? Equipo { get; set; }

		[Key]
		public int Id { get; set; }

		[StringLength(255)]
		public string Nombre { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? Usuario { get; set; }

		public int? Medidor { get; set; }

		public int? Aviso { get; set; }

		public float? Argumento { get; set; }

		public int? Tipo { get; set; }

		public int? Contador { get; set; }

		public int? Estado { get; set; }

		public int? Accion { get; set; }

		public int? ArgumentoAccion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaAccion { get; set; }

		public int? Seccion { get; set; }

		public int? Orden { get; set; }

		public int? SerieOrden { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? EquipoRemoto { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaEnvio { get; set; }

		public int? Sesion { get; set; }

		public int? SesionRemoto { get; set; }

		public int? ProductoInicial { get; set; }

		public int? ProductoFinal { get; set; }


		[ForeignKey(nameof(Medidor))]
		[InverseProperty(nameof(Models.Medidor.Alarmas))]
		public virtual Medidor MedidorNavigation { get; set; }

	}

}
