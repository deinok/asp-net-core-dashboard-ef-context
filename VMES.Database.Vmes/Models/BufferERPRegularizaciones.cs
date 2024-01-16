using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPRegularizaciones
	{

		[Key]
		public int id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FImportado { get; set; }

		public bool? Preparado { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		[StringLength(50)]
		public string ProductoRef2 { get; set; }

		[StringLength(50)]
		public string ProductoRef { get; set; }

		[StringLength(50)]
		public string ProductoNombre { get; set; }

		[Column(TypeName = "decimal(18, 5)")]
		public decimal? Cantidad { get; set; }

		public int? idUbicacion { get; set; }

		public int? LoteId { get; set; }

		[StringLength(50)]
		public string LoteNombre { get; set; }

		public int? idMovimientoMes { get; set; }

		public int? Tipo { get; set; }

		[StringLength(50)]
		public string TipoTxt { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

	}

}
