using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPConsumidos
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Orden { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFinal { get; set; }

		[StringLength(50)]
		public string RefProdFinal { get; set; }

		[StringLength(50)]
		public string NombreProdFinal { get; set; }

		[StringLength(50)]
		public string LoteProdFinal { get; set; }

		[Column(TypeName = "date")]
		public DateTime? FCaducidadLoteProdFinal { get; set; }

		[StringLength(50)]
		public string RefProdConsumido { get; set; }

		[StringLength(50)]
		public string NombreProdConsumido { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? Cantidad { get; set; }

		public int? idModulo { get; set; }

		public int? idMedidor { get; set; }

		[StringLength(50)]
		public string NombreModulo { get; set; }

		[StringLength(50)]
		public string NombreMedidor { get; set; }

		public int? Tipo { get; set; }

		[StringLength(50)]
		public string LoteProdConsumido { get; set; }

		[Column(TypeName = "date")]
		public DateTime? FCadLoteProdConsumido { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		public int? idOrden { get; set; }

		public int? idResultados { get; set; }

		[Column(TypeName = "date")]
		public DateTime? FFabricacionLoteProdFinal { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		public int? Numero { get; set; }

	}

}
