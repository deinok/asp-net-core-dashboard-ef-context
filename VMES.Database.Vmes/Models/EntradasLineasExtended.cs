using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class EntradasLineasExtended
	{

		public int id { get; set; }

		public int? idEntradas { get; set; }

		public int? idProducto { get; set; }

		[StringLength(50)]
		public string ProductoNombre { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? CantidadPedida { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicioRecepcion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFinRecepcion { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? PesoBruto { get; set; }

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

		public int? Estado { get; set; }

		[StringLength(50)]
		public string EstadoTexto { get; set; }

		public bool? FueraCajon { get; set; }

		public int? Lote { get; set; }

		[StringLength(30)]
		public string LoteNombre { get; set; }

		[StringLength(20)]
		public string LoteReferencia { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? LoteCaducidad { get; set; }

		public int? LoteEstado { get; set; }

		[StringLength(50)]
		public string LoteEstadoTexto { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? Tara { get; set; }

		[Column(TypeName = "decimal(19, 3)")]
		public decimal? Neto { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? PesoNetoManual { get; set; }

		[Column(TypeName = "decimal(19, 3)")]
		public decimal? PesoNeto { get; set; }

		public int? Unidad { get; set; }

		[StringLength(50)]
		public string UnidadTexto { get; set; }

		public int? Destino1 { get; set; }

		[StringLength(50)]
		public string Destino1Nombre { get; set; }

		[StringLength(20)]
		public string Destino1Referencia { get; set; }

		public int? Destino2 { get; set; }

		[StringLength(50)]
		public string Destino2Nombre { get; set; }

		[StringLength(20)]
		public string Destino2Referencia { get; set; }

		public int? Destino3 { get; set; }

		[StringLength(50)]
		public string Destino3Nombre { get; set; }

		[StringLength(20)]
		public string Destino3Referencia { get; set; }

		public int? Destino4 { get; set; }

		[StringLength(50)]
		public string Destino4Nombre { get; set; }

		[StringLength(20)]
		public string Destino4Referencia { get; set; }

		public int? Formato { get; set; }

		[StringLength(50)]
		public string FormatoNombre { get; set; }

		[StringLength(50)]
		public string FormatoDescripcion { get; set; }

		public int? Envase { get; set; }

		[StringLength(50)]
		public string EnvaseNombre { get; set; }

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
		public string ModuloNombre { get; set; }

		[StringLength(50)]
		public string ProveedorOrigenNombre { get; set; }

	}

}
