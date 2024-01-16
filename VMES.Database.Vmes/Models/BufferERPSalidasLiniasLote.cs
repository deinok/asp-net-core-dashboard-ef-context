using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPSalidasLiniasLote
	{

		[Key]
		public int id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Timestamp { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FImportado { get; set; }

		public bool? Preparado { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		public int? idLineaSalida { get; set; }

		public int? idLineaSalidaMedicamento { get; set; }

		[StringLength(50)]
		public string refLote { get; set; }

		[StringLength(50)]
		public string nombreLote { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Cantidad { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		public int? idSerie { get; set; }

		[StringLength(20)]
		public string NombreSerie { get; set; }

		public int? idSalidaMes { get; set; }

		public int? idLiniaMes { get; set; }

		public int? idLoteSalida { get; set; }

		public int? NumLoteLineaViaje { get; set; }

		public int? idProducto { get; set; }

		[StringLength(50)]
		public string ProductoNombre { get; set; }

		[StringLength(20)]
		public string ProductoReferencia { get; set; }

		public int? idViajeMES { get; set; }

		[ForeignKey(nameof(idLineaSalidaMedicamento))]
		[InverseProperty(nameof(BufferERPSalidasLinMedicamentos.BufferERPSalidasLiniasLote))]
		public virtual BufferERPSalidasLinMedicamentos idLineaSalidaMedicamentoNavigation { get; set; }

		[ForeignKey(nameof(idLineaSalida))]
		[InverseProperty(nameof(BufferERPSalidasLinias.BufferERPSalidasLiniasLote))]
		public virtual BufferERPSalidasLinias idLineaSalidaNavigation { get; set; }

	}

}
