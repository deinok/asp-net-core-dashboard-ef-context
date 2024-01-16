using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class LineasSalidasAgrupLoteYOrden
	{

		public int Lote { get; set; }

		public int IdOrdenAgrup { get; set; }

		public int IdSalidaLinea { get; set; }

		public double? CantidadAgrup { get; set; }

		public int? id { get; set; }

		public int? idSalidas { get; set; }

		public int? idviajes { get; set; }

		public int? idorden { get; set; }

		public int? idAlbaran { get; set; }

		public int? AlbaranSerie { get; set; }

		[StringLength(50)]
		public string AlbaranSerieNombre { get; set; }

		public int? AlbaranNumero { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? AlbaranFecha { get; set; }

		public int? idProducto { get; set; }

		[StringLength(50)]
		public string ProductoNombre { get; set; }

		public int? idFormato { get; set; }

		[StringLength(50)]
		public string FormatoNombre { get; set; }

		[StringLength(50)]
		public string FormatoDescripcion { get; set; }

		public int? idEnvase { get; set; }

		[StringLength(50)]
		public string EnvaseNombre { get; set; }

		public int? idUnidad { get; set; }

		[StringLength(50)]
		public string UnidadTexto { get; set; }

		public int? idDomicilio { get; set; }

		public int? DomicilioIdCliente { get; set; }

		[StringLength(50)]
		public string DomicilioClienteNombre { get; set; }

		[StringLength(50)]
		public string DomicilioNombre { get; set; }

		[StringLength(50)]
		public string DomicilioReferencia { get; set; }

		[StringLength(50)]
		public string DomicilioDireccion { get; set; }

		[StringLength(50)]
		public string DomicilioPoblacion { get; set; }

		[StringLength(20)]
		public string DomicilioTelefono { get; set; }

		[StringLength(5)]
		public string DomicilioCodigoPostal { get; set; }

		public int? DomicilioProvincia { get; set; }

		[StringLength(50)]
		public string DomicilioProvinciaNombre { get; set; }

		public int? DomicilioPais { get; set; }

		[StringLength(50)]
		public string DomicilioPaisNombre { get; set; }

		public bool? Inhabilitado { get; set; }

		[StringLength(50)]
		public string DomicilioInhabilitadoStr { get; set; }

		[StringLength(50)]
		public string DomicilioDescripcion { get; set; }

		[StringLength(20)]
		public string DomicilioSIMOGAN { get; set; }

		[StringLength(20)]
		public string DomicilioREGA { get; set; }

		[StringLength(50)]
		public string DomicilioEspecie { get; set; }

		public int? TipoOrigen { get; set; }

		public int? Origen1 { get; set; }

		[StringLength(50)]
		public string Origen1Nombre { get; set; }

		public int? Origen2 { get; set; }

		[StringLength(50)]
		public string Origen2Nombre { get; set; }

		public int? Origen3 { get; set; }

		[StringLength(50)]
		public string Origen3Nombre { get; set; }

		public int? Origen4 { get; set; }

		[StringLength(50)]
		public string Origen4Nombre { get; set; }

		[StringLength(207)]
		public string OrigenesStr { get; set; }

		public bool? FueraCajon { get; set; }

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

		[StringLength(571)]
		public string CajonesStr { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFinCarga { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicioCarga { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Bultos { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Bruto { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Tara { get; set; }

		[Column(TypeName = "numeric(19, 3)")]
		public decimal? NetoCalculado { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? PesoNetoManual { get; set; }

		[Column(TypeName = "decimal(19, 3)")]
		public decimal? NetoEfectivo { get; set; }

		public int? Estado { get; set; }

		[StringLength(50)]
		public string EstadoStr { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioUnidad { get; set; }

		public int? IdMonedaPrecioUnidad { get; set; }

		public int? PrecioUnidadMonedaNombre { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? Cantidad { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? Precio { get; set; }

		public int? IdMonedaPrecio { get; set; }

		public int? PrecioMonedaNombre { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioTransporte { get; set; }

		public int? IdMonedaPrecioTransporte { get; set; }

		public int? PrecioTransporteMonedaNombre { get; set; }

		[StringLength(250)]
		public string Observaciones { get; set; }

		public int? idBasculaPesajeBruto { get; set; }

		[StringLength(50)]
		public string BasculaPesajeBrutoStr { get; set; }

		public int? idBasculaPesajeNeto { get; set; }

		[StringLength(50)]
		public string BasculaPesajeNetoStr { get; set; }

		[StringLength(50)]
		public string CampoLibre1 { get; set; }

		[StringLength(50)]
		public string CampoLibre2 { get; set; }

		public int? idPuntoDescarga { get; set; }

		[StringLength(50)]
		public string PuntoDescargaStr { get; set; }

		[StringLength(250)]
		public string PuntoDescargaDescripcion { get; set; }

		public int? OrdenId { get; set; }

		[StringLength(250)]
		public string OrdenNombre { get; set; }

		[StringLength(30)]
		public string PrimerLoteNombre { get; set; }

		public string TodosLotesNombre { get; set; }

		public string TodosPuntosDescarga { get; set; }

		public long? RowID { get; set; }

	}

}
