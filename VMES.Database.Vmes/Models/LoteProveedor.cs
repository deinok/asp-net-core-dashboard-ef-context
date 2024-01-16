using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class LoteProveedor
	{

		public int IdLote { get; set; }

		[StringLength(50)]
		public string Proveedor { get; set; }

		[Column(TypeName = "decimal(15, 3)")]
		public decimal? TotalRecibido { get; set; }

		public string LotesProveedor { get; set; }

	}

}
