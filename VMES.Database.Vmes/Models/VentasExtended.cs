using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class VentasExtended
	{

		public int id { get; set; }

		public int? idSerie { get; set; }

		[StringLength(50)]
		public string SerieNombre { get; set; }

		public int? SerieEstado { get; set; }

		[StringLength(50)]
		public string SerieEstadoTexto { get; set; }

		public int? Codigo { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		public int? Departamento { get; set; }

		[Column(TypeName = "date")]
		public DateTime? Fecha { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioTransporte { get; set; }

		public int? idCliente { get; set; }

		[StringLength(50)]
		public string ClienteNombre { get; set; }

		[StringLength(20)]
		public string ClienteReferencia { get; set; }

		[StringLength(50)]
		public string ClienteRazonSocial { get; set; }

		[StringLength(14)]
		public string ClienteCIF { get; set; }

		[StringLength(50)]
		public string ClienteDireccion { get; set; }

		[StringLength(5)]
		public string ClienteCodigoPostal { get; set; }

		[StringLength(50)]
		public string ClientePoblacion { get; set; }

		public int? ClienteProvincia { get; set; }

		[StringLength(50)]
		public string ClienteProvicinaNombre { get; set; }

		public int? ClientePais { get; set; }

		[StringLength(50)]
		public string ClientePaisNombre { get; set; }

		[StringLength(20)]
		public string ClienteTelefono { get; set; }

		[Column(TypeName = "date")]
		public DateTime? FechaEntrega { get; set; }

		public int? idDomicilio { get; set; }

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

		[StringLength(50)]
		public string DomicilioDescripcion { get; set; }

		[StringLength(20)]
		public string DomicilioSIMOGAN { get; set; }

		[StringLength(20)]
		public string DomicilioREGA { get; set; }

		public int? Estado { get; set; }

		[StringLength(50)]
		public string EstadoTexto { get; set; }

		[Column(TypeName = "ntext")]
		public string Comentario { get; set; }

		[Column(TypeName = "ntext")]
		public string Observaciones { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFin { get; set; }

	}

}
