using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPEntradasLineasLote
	{

		[Key]
		public int Id { get; set; }

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

		public int? IdLineaEntrada { get; set; }

		public int? NumLineaEntrada { get; set; }

		public int? NumLoteLineaEntrada { get; set; }

		public int? LoteId { get; set; }

		[StringLength(50)]
		public string LoteRef { get; set; }

		[StringLength(50)]
		public string LoteNombre { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? LoteFecha { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? LoteFechaCaducidad { get; set; }

		[StringLength(50)]
		public string LoteProveedor { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? LoteProveedorFCad { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Cantidad { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		public int? SerieId { get; set; }

		[StringLength(20)]
		public string SerieNombre { get; set; }

		public int? IdEntradaMes { get; set; }

		public int? IdEntradaLineaMes { get; set; }

		public int? IdProducto { get; set; }

		[StringLength(50)]
		public string ProductoNombre { get; set; }

		[StringLength(20)]
		public string ProductoReferencia { get; set; }

		[ForeignKey(nameof(IdLineaEntrada))]
		[InverseProperty(nameof(BufferERPEntradasLineas.BufferERPEntradasLineasLote))]
		public virtual BufferERPEntradasLineas IdLineaEntradaNavigation { get; set; }

	}

}
