using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class InformeExpediciones_SalidaLinea
	{

		[StringLength(50)]
		public string ProductoNombre { get; set; }

		[StringLength(50)]
		public string PuntoDescargaNombre { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? SalidaLineaBruto { get; set; }

		public int SalidaLineaId { get; set; }

		[Column(TypeName = "numeric(19, 3)")]
		public decimal? SalidaLineaNeto { get; set; }

		[StringLength(250)]
		public string SalidaLineaObservaciones { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? SalidaLineaTara { get; set; }

		public int SalidaViajeId { get; set; }

	}

}
