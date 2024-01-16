using System;
using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class InformeExpediciones_SalidaLinea_Resultado
	{

		[StringLength(30)]
		public string LoteNombre { get; set; }

		public double? ResultadoCantidad { get; set; }

		public int SalidaLineaId { get; set; }

		[StringLength(50)]
		public string UnidadNombre { get; set; }

	}

}
