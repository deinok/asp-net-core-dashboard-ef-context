using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPStocks
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string Referencia2 { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? Cantidad { get; set; }

		public int? Tipo { get; set; }

		[Column(TypeName = "date")]
		public DateTime? FProducido { get; set; }

		[Column(TypeName = "date")]
		public DateTime? FCaducidad { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		[StringLength(50)]
		public string Lote { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public bool? Acumulativo { get; set; }

		public int? idUbicacion { get; set; }

		[Column(TypeName = "date")]
		public DateTime? FFabricacion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

	}

}
