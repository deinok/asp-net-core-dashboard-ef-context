using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPSalidasLinMedicamentos
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

		public int? idSalidasLinia { get; set; }

		public int? idMedicamento { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Cantidad { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Bultos { get; set; }

		public int? IdUnidad { get; set; }

		public int? idFormato { get; set; }

		public int? idEnvase { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioUnidad { get; set; }

		[StringLength(20)]
		public string RefERPUnidades { get; set; }

		[StringLength(20)]
		public string RefERPFormatos { get; set; }

		[StringLength(20)]
		public string RefERPEnvases { get; set; }

		[StringLength(50)]
		public string MedicamentoNombre { get; set; }

		[StringLength(50)]
		public string MedicamentoReferencia { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		[ForeignKey(nameof(idSalidasLinia))]
		[InverseProperty(nameof(BufferERPSalidasLinias.BufferERPSalidasLinMedicamentos))]
		public virtual BufferERPSalidasLinias idSalidasLiniaNavigation { get; set; }

		[InverseProperty(nameof(Models.BufferERPSalidasLiniasLote.idLineaSalidaMedicamentoNavigation))]
		public virtual ICollection<BufferERPSalidasLiniasLote> BufferERPSalidasLiniasLote { get; set; } = new HashSet<BufferERPSalidasLiniasLote>();

	}

}
