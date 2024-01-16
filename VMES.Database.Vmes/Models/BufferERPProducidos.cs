using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPProducidos
	{

		[Key]
		public int id { get; set; }

		public int? idOrden { get; set; }

		public int? idProducto { get; set; }

		[StringLength(50)]
		public string ProductoNombre { get; set; }

		public int? idLote { get; set; }

		[StringLength(50)]
		public string LoteNombre { get; set; }

		[Column(TypeName = "date")]
		public DateTime? LoteFCaducidad { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaOrden { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? CantidadTotal { get; set; }

		public int? NCiclos { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? CantidadCicloOriginal { get; set; }

		[StringLength(50)]
		public string ProductoReferencia { get; set; }

		public int? idUbicacion { get; set; }

		[StringLength(50)]
		public string UbicacionNombre { get; set; }

		public int? idModulo { get; set; }

		[StringLength(50)]
		public string ModuloNombre { get; set; }

		public int? idDesglose { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		[Column(TypeName = "date")]
		public DateTime? LoteFFabricacion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		public int? IdOrdenLegitimo { get; set; }

		public int? idFormula { get; set; }

		[StringLength(50)]
		public string FormulaNombre { get; set; }

		[StringLength(20)]
		public string FormulaReferencia { get; set; }

		[StringLength(20)]
		public string FormulaRefERP { get; set; }

		public int? idFormulaVersion { get; set; }

		[StringLength(50)]
		public string FormulaVersionNombre { get; set; }

		[StringLength(20)]
		public string FormulaVersionReferencia { get; set; }

		[StringLength(20)]
		public string FormulaVersionRefERP { get; set; }

		public int? idMedicacion { get; set; }

		[StringLength(50)]
		public string MedicacionNombre { get; set; }

		[StringLength(30)]
		public string ModuloRef { get; set; }

		[StringLength(20)]
		public string MedidorRef { get; set; }

		public int? ModuloTipo { get; set; }

	}

}
