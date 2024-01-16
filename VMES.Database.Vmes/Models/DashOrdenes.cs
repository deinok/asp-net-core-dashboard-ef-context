using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class DashOrdenes
	{

		public int IdOrden { get; set; }

		[StringLength(50)]
		public string Serie { get; set; }

		[StringLength(50)]
		public string Modulo { get; set; }

		[StringLength(250)]
		public string Nombre { get; set; }

		public int IdCabecera { get; set; }

		[StringLength(50)]
		public string NombreCabecera { get; set; }

		[Required]
		[StringLength(50)]
		public string Producto { get; set; }

		[Required]
		[StringLength(30)]
		public string Lote { get; set; }

		[Column(TypeName = "date")]
		public DateTime? Fecha { get; set; }

		public float? Cantidad { get; set; }

		public int? Ciclos { get; set; }

		public float? CantidadTotal { get; set; }

		public double? CantidadReal { get; set; }

		[Column(TypeName = "decimal(38, 5)")]
		public decimal? KwhEfectivo { get; set; }

		[Column(TypeName = "decimal(38, 5)")]
		public decimal? KWhTotal { get; set; }

		[Required]
		[StringLength(50)]
		public string Formula { get; set; }

		[Required]
		[StringLength(6)]
		public string Turno { get; set; }

		public string Origenes { get; set; }

		public string Destinos { get; set; }

		[Required]
		[StringLength(12)]
		public string Estado { get; set; }

		public TimeSpan? Inicio { get; set; }

		public TimeSpan? Fin { get; set; }

		[StringLength(2)]
		public string Modificada { get; set; }

	}

}
