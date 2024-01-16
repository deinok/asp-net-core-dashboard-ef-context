using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class PivotProduccion
	{

		public int Id { get; set; }

		[StringLength(250)]
		public string Nombre { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int Serie { get; set; }

		[StringLength(50)]
		public string NombreProductoFinal { get; set; }

		[StringLength(50)]
		public string NombreProducto { get; set; }

		public int? CodProducto { get; set; }

		[Column(TypeName = "decimal(28, 15)")]
		public decimal? CantidadTeorica { get; set; }

		public int? CodUbicacionTeorica { get; set; }

		[StringLength(50)]
		public string NombreUbicacionTeorica { get; set; }

		public int? NCiclo { get; set; }

		public float? CantidadReal { get; set; }

		public int? CodUbicacionReal { get; set; }

		[StringLength(50)]
		public string NombreUbicacionReal { get; set; }

		[StringLength(50)]
		public string Medidor { get; set; }

		[StringLength(50)]
		public string Modulo { get; set; }

		public int? TipoModulo { get; set; }

		public int IdOrden { get; set; }

		[StringLength(20)]
		public string ReferenciaProductoFinal { get; set; }

		[StringLength(20)]
		public string ReferenciaIngrediente { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Inicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fin { get; set; }

		public int? TiempoEfectivo { get; set; }

		public int? TiempoTotal { get; set; }

		[StringLength(30)]
		public string LoteIngrediente { get; set; }

		public int? IdLoteIngrediente { get; set; }

		[Column(TypeName = "decimal(18, 5)")]
		public decimal? kwhEfectivo { get; set; }

		[Column(TypeName = "decimal(18, 5)")]
		public decimal? KwhTotal { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? Temperatura { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? Humedad { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaConsumido { get; set; }

		public int? TipoProducto { get; set; }

		public int? TipoProductoFinal { get; set; }

		public int? IdConsumido { get; set; }

		public int IdDosificacion { get; set; }

		public long RowID { get; set; }

	}

}
