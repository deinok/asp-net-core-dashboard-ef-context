using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class SalidasExtended
	{

		public int id { get; set; }

		public int idSerie { get; set; }

		[StringLength(50)]
		public string SerieNombre { get; set; }

		public int Codigo { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		public int? IdDepartamento { get; set; }

		[StringLength(50)]
		public string DepartamentoNombre { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

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

		public bool? ClienteInhabilitado { get; set; }

		[StringLength(50)]
		public string ClienteInhabilitadoStr { get; set; }

		public int? Estado { get; set; }

		[StringLength(50)]
		public string EstadoStr { get; set; }

		[Column(TypeName = "ntext")]
		public string Comentario { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaPrevista { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFin { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Precio { get; set; }

		public int? IdMoneda { get; set; }

		public int? MonedaNombre { get; set; }

		public int? MonedaSimbolo { get; set; }

		[Column(TypeName = "ntext")]
		public string Observaciones { get; set; }

	}

}
