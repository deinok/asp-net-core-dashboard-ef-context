using System;
using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class LoteClienteDomicilio
	{

		public int? IdLote { get; set; }

		public int? idorden { get; set; }

		public int? idsalida { get; set; }

		[StringLength(50)]
		public string Cliente { get; set; }

		[StringLength(50)]
		public string Domicilio { get; set; }

		[StringLength(50)]
		public string Direccion { get; set; }

		public double? TotalServido { get; set; }

		public int? NumeroSalida { get; set; }

		[StringLength(50)]
		public string MarcaOficial { get; set; }

		public int? idlinea { get; set; }

	}

}
