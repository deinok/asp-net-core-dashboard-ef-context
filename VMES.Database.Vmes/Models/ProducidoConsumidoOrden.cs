using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class ProducidoConsumidoOrden
	{

		public int Id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? IdProducto { get; set; }

		[StringLength(50)]
		public string NombreProducto { get; set; }

		public int? IdLote { get; set; }

		[StringLength(30)]
		public string NombreLote { get; set; }

		public double? CantidadProducida { get; set; }

		[StringLength(50)]
		public string UdProd { get; set; }

		[StringLength(50)]
		public string UbicacionDestino { get; set; }

		public double? TotalDosificado { get; set; }

		[StringLength(50)]
		public string UdCons { get; set; }

		public int? IdProDosi { get; set; }

		[StringLength(50)]
		public string PartidaArancelariaCompras { get; set; }

		[StringLength(50)]
		public string PartidaArancelariaFabricacion { get; set; }

		public int? IdLoteDosi { get; set; }

	}

}
