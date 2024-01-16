using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class ComprasLineasExtended
	{

		public int Id { get; set; }

		public int idCompra { get; set; }

		public int Linea { get; set; }

		public int? idProducto { get; set; }

		[StringLength(50)]
		public string ProductoNombre { get; set; }

		public float? Cantidad { get; set; }

		public float? Servida { get; set; }

		public int? Estado { get; set; }

		[StringLength(50)]
		public string EstadoStr { get; set; }

		public bool? Importado { get; set; }

		public int? Departamento { get; set; }

		public int? idLote { get; set; }

		public int? Bultos { get; set; }

		public int? idEnvase { get; set; }

		[StringLength(50)]
		public string EnvaseNombre { get; set; }

		public int? idUnidad { get; set; }

		[StringLength(50)]
		public string UnidadTexto { get; set; }

		[StringLength(20)]
		public string ContratoTextoLibre { get; set; }

		[StringLength(100)]
		public string Comentario { get; set; }

		public bool? Exportado { get; set; }

		public float? PrecioCompra { get; set; }

		public int? IdContrato { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFin { get; set; }

	}

}
