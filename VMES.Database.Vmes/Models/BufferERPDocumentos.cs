using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPDocumentos
	{

		[Key]
		public int id { get; set; }

		public int? RefERP { get; set; }

		public bool? Entrada { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public bool? Visible { get; set; }

		public bool? ViajeSalida { get; set; }

		public bool? Automatico { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

	}

}
