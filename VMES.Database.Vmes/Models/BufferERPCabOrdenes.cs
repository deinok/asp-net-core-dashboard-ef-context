using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPCabOrdenes
	{

		[Required]
		[StringLength(50)]
		public string Nombre { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[StringLength(50)]
		public string RefProducto { get; set; }

		[StringLength(50)]
		public string NombreProducto { get; set; }

		[StringLength(50)]
		public string NombreLoteProducto { get; set; }

		[Column(TypeName = "date")]
		public DateTime? FCaducidadLoteProducto { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Cantidad { get; set; }

		public int? NumCiclos { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FImportado { get; set; }

		[Key]
		public int Id { get; set; }

		public bool? preparado { get; set; }

		[StringLength(50)]
		public string RefERP { get; set; }

		[Column(TypeName = "date")]
		public DateTime? FFabricacionLoteProducto { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		[InverseProperty(nameof(Models.BufferERPLinOrdenes.idCabordenNavigation))]
		public virtual ICollection<BufferERPLinOrdenes> BufferERPLinOrdenes { get; set; } = new HashSet<BufferERPLinOrdenes>();

	}

}
