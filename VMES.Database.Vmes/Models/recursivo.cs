using System;
using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class recursivo
	{

		public int? ProductoDest { get; set; }

		public int? LoteDest { get; set; }

		public int? ProductoOrig { get; set; }

		public int? LoteOrig { get; set; }

		[StringLength(250)]
		public string OrdenProd { get; set; }

		public int? NivelProducto { get; set; }

	}

}
