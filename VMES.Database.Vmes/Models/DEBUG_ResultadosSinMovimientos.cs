using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class DEBUG_ResultadosSinMovimientos
	{

		public int idOrden { get; set; }

		[StringLength(250)]
		public string Orden { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? InicioOrden { get; set; }

		public int? Ciclo { get; set; }

		[StringLength(50)]
		public string Ubicacion { get; set; }

		public int? idProducto { get; set; }

		[StringLength(50)]
		public string ProductoSinMovimientoStock { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaResultado { get; set; }

	}

}
