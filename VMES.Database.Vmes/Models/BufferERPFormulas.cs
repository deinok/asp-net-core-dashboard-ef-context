using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPFormulas
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

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[StringLength(50)]
		public string RefProducto { get; set; }

		public int? IdProducto { get; set; }

		public int? Estado { get; set; }

		public bool? EsMedicamento { get; set; }

		public int? IdERPFormula { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		public bool? VersionNueva { get; set; }

		[InverseProperty(nameof(Models.BufferERPFormulaProductosFinales.idFormulaNavigation))]
		public virtual ICollection<BufferERPFormulaProductosFinales> BufferERPFormulaProductosFinales { get; set; } = new HashSet<BufferERPFormulaProductosFinales>();

		[InverseProperty(nameof(Models.BufferERPVersiones.idFormulaNavigation))]
		public virtual ICollection<BufferERPVersiones> BufferERPVersiones { get; set; } = new HashSet<BufferERPVersiones>();

	}

}
