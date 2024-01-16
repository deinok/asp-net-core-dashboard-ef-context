using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class ExistenciasProductoLote
	{

		public int Inventario { get; set; }

		[StringLength(50)]
		public string ProductoNombre { get; set; }

		[StringLength(30)]
		public string LoteNombre { get; set; }

		[StringLength(50)]
		public string UnidadNombre { get; set; }

		public int? Estado { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[StringLength(50)]
		public string ProveedorNombre { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? LoteCaducidad { get; set; }

		public int? ProductoTipo { get; set; }

		public string LotesProveedor { get; set; }

		public double? Cantidad { get; set; }

		[StringLength(50)]
		public string UbicacionNombre { get; set; }

		public long RowID { get; set; }

	}

}
