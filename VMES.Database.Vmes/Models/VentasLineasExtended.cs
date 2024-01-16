using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class VentasLineasExtended
	{

		public int id { get; set; }

		public int? idVentas { get; set; }

		public int? linea { get; set; }

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

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Bultos { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? Cantidad { get; set; }

		public int? idUnidad { get; set; }

		[StringLength(50)]
		public string UnidadTexto { get; set; }

		public int? idDomicilio { get; set; }

		public int? DomicilioIdCliente { get; set; }

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

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioUnidad { get; set; }

		public int? idContrato { get; set; }

		public int? Estado { get; set; }

		[StringLength(50)]
		public string EstadoStr { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[StringLength(250)]
		public string Observaciones { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? Precio { get; set; }

		public int? IdMonedaPrecio { get; set; }

		public int? PrecioMonedaNombre { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioTransporte { get; set; }

		public int? IdMonedaPrecioTransporte { get; set; }

		public int? PrecioTransporteMonedaNombre { get; set; }

		[StringLength(50)]
		public string CampoLibre1 { get; set; }

		[StringLength(50)]
		public string CampoLibre2 { get; set; }

		public int? idPuntoDescarga { get; set; }

		[StringLength(50)]
		public string PuntoDescargaStr { get; set; }

		[StringLength(250)]
		public string PuntoDescargaDescripcion { get; set; }

		public string TodosPuntosDescarga { get; set; }

	}

}
