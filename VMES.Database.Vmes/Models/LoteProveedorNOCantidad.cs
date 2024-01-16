using System;
using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class LoteProveedorNOCantidad
	{

		public int IdLote { get; set; }

		[StringLength(50)]
		public string Proveedor { get; set; }

		public string LotesProveedor { get; set; }

	}

}
