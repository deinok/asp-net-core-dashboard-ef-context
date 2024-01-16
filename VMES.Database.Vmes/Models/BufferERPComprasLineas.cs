using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPComprasLineas
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

		public int? CompraId { get; set; }

		[StringLength(20)]
		public string CompraRef { get; set; }

		public int Linea { get; set; }

		public int? ProductoId { get; set; }

		[StringLength(20)]
		public string ProductoRef { get; set; }

		public float? Cantidad { get; set; }

		public int? Departamento { get; set; }

		public int? LoteId { get; set; }

		[StringLength(20)]
		public string LoteRef { get; set; }

		public int? Bultos { get; set; }

		public int? EnvaseId { get; set; }

		[StringLength(20)]
		public string EnvaseRef { get; set; }

		public int? UnidadId { get; set; }

		[StringLength(20)]
		public string UnidadRef { get; set; }

		public int? ContratoId { get; set; }

		[StringLength(20)]
		public string ContratoRef { get; set; }

		[StringLength(100)]
		public string Comentario { get; set; }

		public float? PrecioCompra { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? FormatoId { get; set; }

		[StringLength(20)]
		public string FormatoRef { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		[ForeignKey(nameof(CompraId))]
		[InverseProperty(nameof(BufferERPCompras.BufferERPComprasLineas))]
		public virtual BufferERPCompras Compra { get; set; }

	}

}
