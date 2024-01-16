using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class DatosMuestraEntrada
	{

		public int idLineaEntrada { get; set; }

		[StringLength(50)]
		public string producto { get; set; }

		[StringLength(20)]
		public string prodRef { get; set; }

		[StringLength(20)]
		public string prodRef2 { get; set; }

		[StringLength(30)]
		public string lote { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? lotefecha { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? lotecaducidad { get; set; }

		[StringLength(50)]
		public string proveedor { get; set; }

		[StringLength(14)]
		public string provCif { get; set; }

		[StringLength(20)]
		public string provRef { get; set; }

		[StringLength(50)]
		public string EntradaRef { get; set; }

		[StringLength(20)]
		public string refcompra { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? CantidadPedida { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? PesoBruto { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? NetoOrigen { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicioRecepcion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFinRecepcion { get; set; }

		public int? IdMuestra { get; set; }

		public int? loteId { get; set; }

		public int ProductoId { get; set; }

		public int Numero { get; set; }

		[StringLength(50)]
		public string Serie { get; set; }

	}

}
