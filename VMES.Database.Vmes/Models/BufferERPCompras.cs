using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPCompras
	{

		[Key]
		public int Id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FImportado { get; set; }

		public bool? Preparado { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		public int? Serie { get; set; }

		public int? ProveedorId { get; set; }

		[StringLength(20)]
		public string ProveedorRef { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? DepartamentoId { get; set; }

		[StringLength(20)]
		public string DepartamentoRef { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Entrega { get; set; }

		[StringLength(100)]
		public string Comentario { get; set; }

		public bool? Refrescado { get; set; }

		public int? Numero { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		public int? ContratoId { get; set; }

		[StringLength(20)]
		public string ContratoRef { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		[InverseProperty(nameof(Models.BufferERPComprasLineas.Compra))]
		public virtual ICollection<BufferERPComprasLineas> BufferERPComprasLineas { get; set; } = new HashSet<BufferERPComprasLineas>();

	}

}
