using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class SalidasInformeAduanas
	{

		public int? Viaje { get; set; }

		public int IdSalida { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? IdCliente { get; set; }

		[StringLength(50)]
		public string NombreCliente { get; set; }

		[StringLength(14)]
		public string CIFCliente { get; set; }

		public int? idProducto { get; set; }

		[StringLength(50)]
		public string NombreProducto { get; set; }

		public int? IdEmpTransport { get; set; }

		[StringLength(50)]
		public string NombreEmpTransport { get; set; }

		[StringLength(14)]
		public string CIFEmpTransport { get; set; }

		public int? IdChofer { get; set; }

		[StringLength(50)]
		public string NombreChofer { get; set; }

		[StringLength(14)]
		public string CIFChofer { get; set; }

		public double? Servida { get; set; }

		public int? IdLote { get; set; }

		[StringLength(30)]
		public string NombreLote { get; set; }

	}

}
