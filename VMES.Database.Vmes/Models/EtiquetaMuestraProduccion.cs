using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class EtiquetaMuestraProduccion
	{

		public int IdOrden { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Inicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime Fin { get; set; }

		[StringLength(50)]
		public string NombreProducto { get; set; }

		[StringLength(30)]
		public string NombreLote { get; set; }

		public int? IdLote { get; set; }

		public int? Medicado { get; set; }

	}

}
