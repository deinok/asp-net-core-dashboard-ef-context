using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPFormulaProductosFinales
	{

		[Key]
		public int id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FImportado { get; set; }

		public bool? Preparado { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		public int? idFormula { get; set; }

		public int? idProducto { get; set; }

		[StringLength(50)]
		public string RefProducto { get; set; }

		public bool? Principal { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		[StringLength(20)]
		public string RefFormula { get; set; }

		[ForeignKey(nameof(idFormula))]
		[InverseProperty(nameof(BufferERPFormulas.BufferERPFormulaProductosFinales))]
		public virtual BufferERPFormulas idFormulaNavigation { get; set; }

	}

}
