using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class SalidasLiniasMedicacionesExtended
	{

		public int id { get; set; }

		public int? idSalidaLinia { get; set; }

		public int? idMedicamento { get; set; }

		[StringLength(50)]
		public string MedicamentoNombre { get; set; }

		[StringLength(50)]
		public string MedicamentoReferencia { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Cantidad { get; set; }

		public int? IdUnidad { get; set; }

		[StringLength(50)]
		public string UnidadTexto { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Bultos { get; set; }

		public int? idFormato { get; set; }

		[StringLength(50)]
		public string FormatoNombre { get; set; }

		[StringLength(50)]
		public string FormatoDescripcion { get; set; }

		public int? idEnvase { get; set; }

		[StringLength(50)]
		public string EnvaseNombre { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioUnidad { get; set; }

		public int? IdMonedaPrecioUnidad { get; set; }

		public int? MonedaPrecioUnidadStr { get; set; }

		public int? Estado { get; set; }

		[StringLength(50)]
		public string EstadoStr { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? Precio { get; set; }

		public int? IdMonedaPrecio { get; set; }

		public int? MonedaPrecioStr { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? idOrigen { get; set; }

		[StringLength(50)]
		public string OrigenNombre { get; set; }

	}

}
