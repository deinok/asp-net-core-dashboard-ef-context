using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class PivotProduccionProducidos
	{

		public int IdOrden { get; set; }

		[StringLength(250)]
		public string NombreOrden { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaOrden { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicioOrden { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFinOrden { get; set; }

		public int? CaminoOrden { get; set; }

		public int? CiclosOrden { get; set; }

		public float? CantidadOrdenCiclo { get; set; }

		public float? CantidadTotalOrden { get; set; }

		[Required]
		[StringLength(10)]
		public string EstadoOrden { get; set; }

		public int? IdFormual { get; set; }

		[StringLength(50)]
		public string NombreFormula { get; set; }

		public int? IdVersionFormula { get; set; }

		[StringLength(50)]
		public string NombreVersion { get; set; }

		[StringLength(50)]
		public string Medidor { get; set; }

		[StringLength(50)]
		public string Modulo { get; set; }

		[StringLength(50)]
		public string NombreProductoProducido { get; set; }

		[StringLength(20)]
		public string RefProductoProducido { get; set; }

		[StringLength(50)]
		public string NombreProductoOrden { get; set; }

		[StringLength(20)]
		public string RefProductoOrden { get; set; }

		[StringLength(50)]
		public string NombreDestino { get; set; }

		public float? Cantidad { get; set; }

		public int? TiempoEfectivo { get; set; }

		public int? TiempoTotal { get; set; }

		[Column(TypeName = "decimal(18, 5)")]
		public decimal? KwhEfectivo { get; set; }

		[Column(TypeName = "decimal(18, 5)")]
		public decimal? KwhTotal { get; set; }

		[Column(TypeName = "decimal(12, 5)")]
		public decimal? Temperatura { get; set; }

		[Column(TypeName = "decimal(12, 5)")]
		public decimal? Humedad { get; set; }

		public int Ciclo { get; set; }

		public int? IdLoteProducido { get; set; }

		[StringLength(30)]
		public string NombreLoteProducido { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaProducido { get; set; }

		public int? TipoProducto { get; set; }

		public int IdProducido { get; set; }

		public long RowID { get; set; }

	}

}
