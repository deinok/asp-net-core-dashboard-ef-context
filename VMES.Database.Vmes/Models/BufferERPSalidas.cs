using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPSalidas
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

		public int? Serie { get; set; }

		public int? Numero { get; set; }

		public string Observaciones { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public string Comentario { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaPrevista { get; set; }

		[StringLength(50)]
		public string RefCliente { get; set; }

		public bool? esExport { get; set; }

		[StringLength(50)]
		public string SerieNombre { get; set; }

		public int? idMES { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		public int? idSerie { get; set; }

		[StringLength(20)]
		public string NombreSerie { get; set; }

		[StringLength(20)]
		public string RefDomicilio { get; set; }

		[StringLength(20)]
		public string MatriculaCamion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaExpedicion { get; set; }

		[StringLength(50)]
		public string NombreChofer { get; set; }

		[InverseProperty(nameof(Models.BufferERPSalidasLinias.idSalidasNavigation))]
		public virtual ICollection<BufferERPSalidasLinias> BufferERPSalidasLinias { get; set; } = new HashSet<BufferERPSalidasLinias>();

	}

}
