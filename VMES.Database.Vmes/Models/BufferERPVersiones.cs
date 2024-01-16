using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPVersiones
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

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? Estado { get; set; }

		public int? Unidad { get; set; }

		[Column(TypeName = "numeric(18, 5)")]
		public decimal? Cantidad { get; set; }

		[Column(TypeName = "numeric(18, 5)")]
		public decimal? LimitePesoCiclo { get; set; }

		public bool? LimpiezaPosteriorObligada { get; set; }

		[StringLength(20)]
		public string RefERPUnidades { get; set; }

		public int? IdERPVersion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		[StringLength(20)]
		public string RefFormula { get; set; }

		[ForeignKey(nameof(idFormula))]
		[InverseProperty(nameof(BufferERPFormulas.BufferERPVersiones))]
		public virtual BufferERPFormulas idFormulaNavigation { get; set; }

		[InverseProperty(nameof(Models.BufferERPComponentes.idVersionNavigation))]
		public virtual ICollection<BufferERPComponentes> BufferERPComponentes { get; set; } = new HashSet<BufferERPComponentes>();

	}

}
