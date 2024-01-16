using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class OrdenesTransicionEstadosHistory
	{

		[Key]
		public int IdAuto { get; set; }

		public DateTime InicioValidez { get; set; }

		public DateTime? FinValidez { get; set; }

		public int ContadorActualizaciones { get; set; }

		public int? EstadoAnterior { get; set; }

		public int? Estado { get; set; }

		public int? ExportadoERP { get; set; }

		[Column("IdOrden")]
		public int? OrdenId { get; set; }

		[ForeignKey(nameof(OrdenId))]
		[InverseProperty(nameof(Ordenes.OrdenesTransicionEstadosHistory))]
		public virtual Ordenes Orden { get; set; }

	}

}
