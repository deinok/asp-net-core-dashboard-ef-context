using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class ComprasExtended
	{

		public int Id { get; set; }

		public int? idSerie { get; set; }

		[StringLength(50)]
		public string SerieNombre { get; set; }

		public int? SerieEstado { get; set; }

		[StringLength(50)]
		public string SerieEstadoTexto { get; set; }

		public int? Numero { get; set; }

		public int? idProveedor { get; set; }

		[StringLength(20)]
		public string ProveedorReferencia { get; set; }

		[StringLength(50)]
		public string ProveedorNombre { get; set; }

		[StringLength(14)]
		public string ProveedorCIF { get; set; }

		[StringLength(50)]
		public string ProveedorDireccion { get; set; }

		[StringLength(5)]
		public string ProveedorCodigoPostal { get; set; }

		[StringLength(50)]
		public string ProveedorPoblacion { get; set; }

		[StringLength(20)]
		public string ProveedorTelefono { get; set; }

		public int? ProveedorProvincia { get; set; }

		[StringLength(50)]
		public string ProveedorProvinciaNombre { get; set; }

		[StringLength(40)]
		public string ProveedorAbreviado { get; set; }

		public int? ProveedorPais { get; set; }

		[StringLength(50)]
		public string ProveedorPaisNombre { get; set; }

		public bool? ProveedorInhabilitado { get; set; }

		[StringLength(50)]
		public string ProveedorInhabilitadoTexto { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? Estado { get; set; }

		[StringLength(50)]
		public string EstadoTexto { get; set; }

		public bool? Importado { get; set; }

		public int? Departamento { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaEntrega { get; set; }

		[StringLength(100)]
		public string Comentario { get; set; }

		public bool? Impresa { get; set; }

		public bool? Refrescado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fin { get; set; }

		public bool? Exportado { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		public int? idContrato { get; set; }

		[StringLength(20)]
		public string ReferenciaContrato { get; set; }

	}

}
