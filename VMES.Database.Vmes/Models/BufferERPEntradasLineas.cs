using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPEntradasLineas
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

		public int? idBufferEntrada { get; set; }

		public int? idProducto { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? CantidadPedida { get; set; }

		public bool? Cajon1 { get; set; }

		public bool? Cajon2 { get; set; }

		public bool? Cajon3 { get; set; }

		public bool? Cajon4 { get; set; }

		public bool? Cajon5 { get; set; }

		public bool? Cajon6 { get; set; }

		public bool? Cajon7 { get; set; }

		public bool? Cajon8 { get; set; }

		public bool? Cajon9 { get; set; }

		public bool? Cajon10 { get; set; }

		public bool? FueraCajon { get; set; }

		[StringLength(50)]
		public string RefProveedor { get; set; }

		public int? Unidad { get; set; }

		public int? Destino1 { get; set; }

		public int? Destino2 { get; set; }

		public int? Destino3 { get; set; }

		public int? Destino4 { get; set; }

		public int? Formato { get; set; }

		public int? Envase { get; set; }

		public int? Bultos { get; set; }

		[StringLength(250)]
		public string Observaciones { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Precio { get; set; }

		public bool? PagarKgTeoricos { get; set; }

		[StringLength(50)]
		public string CampoLibre1 { get; set; }

		[StringLength(50)]
		public string CampoLIbre2 { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? idModulo { get; set; }

		[StringLength(50)]
		public string LoteRef { get; set; }

		[StringLength(50)]
		public string LoteNombre { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? LoteFecha { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Caducidad { get; set; }

		[StringLength(20)]
		public string RefERPUnidades { get; set; }

		[StringLength(20)]
		public string RefERPFormatos { get; set; }

		[StringLength(20)]
		public string RefERPEnvases { get; set; }

		public bool? isExport { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PesoTara { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PesoBruto { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PesoNeto { get; set; }

		[StringLength(50)]
		public string Ref2Producto { get; set; }

		public int? idEntradaMes { get; set; }

		public int? idLiniaMes { get; set; }

		[StringLength(50)]
		public string RefProducto { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		[StringLength(50)]
		public string Destino1Nombre { get; set; }

		[StringLength(50)]
		public string Destino2Nombre { get; set; }

		[StringLength(50)]
		public string Destino3Nombre { get; set; }

		[StringLength(50)]
		public string Destino4Nombre { get; set; }

		public int? idSerie { get; set; }

		[StringLength(20)]
		public string NombreSerie { get; set; }

		[StringLength(20)]
		public string RefEntrada { get; set; }

		public int? NumLinea { get; set; }

		[StringLength(20)]
		public string RefCompra { get; set; }

		public int? NumLineaCompra { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? NetoOrigen { get; set; }

		public int? NumeroEntrada { get; set; }

		public int? idLote { get; set; }

		[ForeignKey(nameof(idBufferEntrada))]
		[InverseProperty(nameof(BufferERPEntradas.BufferERPEntradasLineas))]
		public virtual BufferERPEntradas idBufferEntradaNavigation { get; set; }

		[InverseProperty(nameof(Models.BufferERPEntradasLineasLote.IdLineaEntradaNavigation))]
		public virtual ICollection<BufferERPEntradasLineasLote> BufferERPEntradasLineasLote { get; set; } = new HashSet<BufferERPEntradasLineasLote>();

	}

}
