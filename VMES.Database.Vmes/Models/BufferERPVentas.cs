using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPVentas
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

		public int? ClienteId { get; set; }

		[StringLength(20)]
		public string ClienteRef { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaEntrega { get; set; }

		public int? DomicilioId { get; set; }

		[StringLength(20)]
		public string DomicilioRef { get; set; }

		public string Comentario { get; set; }

		public string Observaciones { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioTransporte { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[StringLength(50)]
		public string RefERP { get; set; }

		public bool? isExport { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		[InverseProperty(nameof(BufferERPVentasLineas.BufferErpVenta))]
		public virtual ICollection<BufferERPVentasLineas> BufferErpVentaLineas { get; set; } = new HashSet<BufferERPVentasLineas>();

	}

}
