using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class DosificacionesDetalle
	{

		public int Orden { get; set; }

		public int? PosicionDosificacion { get; set; }

		[StringLength(50)]
		public string NombreProducto { get; set; }

		[StringLength(50)]
		public string NombreMedidor { get; set; }

		[StringLength(50)]
		public string NombreUbicacion { get; set; }

		[StringLength(250)]
		public string NombreMotor { get; set; }

		[StringLength(250)]
		public string NombreAccion { get; set; }

		[Column(TypeName = "decimal(28, 15)")]
		public decimal? Cantidad { get; set; }

		[StringLength(50)]
		public string Unidad { get; set; }

		public int? Tiempo { get; set; }

		public int? TipoDosificacion { get; set; }

		public int Id { get; set; }

	}

}
