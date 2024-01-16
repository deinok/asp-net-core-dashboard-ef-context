using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{


	[Obsolete]
	public class InformeExpediciones
	{

		[StringLength(5)]
		public string ClienteCodigoPostal { get; set; }

		[StringLength(50)]
		public string ClienteDireccion { get; set; }

		[StringLength(50)]
		public string ClienteNombre { get; set; }

		[StringLength(50)]
		public string ClientePoblacion { get; set; }

		[StringLength(20)]
		public string ClienteTelefono { get; set; }

		[StringLength(50)]
		public string DomicilioNombre { get; set; }

		[StringLength(50)]
		public string DomicilioPoblacion { get; set; }

		[StringLength(20)]
		public string DomicilioSimogan { get; set; }

		[StringLength(14)]
		public string EmpresasTransporteCif { get; set; }

		[StringLength(50)]
		public string EmpresasTransporteNombre { get; set; }

		[StringLength(50)]
		public string ProvinciaClienteNombre { get; set; }

		[StringLength(50)]
		public string ProvinciaDomicilioNombre { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? SalidaFechaFin { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? SalidaFechaInicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? SalidaFecha { get; set; }

		public int SalidaViajeNumero { get; set; }

		[StringLength(500)]
		public string SalidaViajeObservaciones { get; set; }

		public int SalidaViajeId { get; set; }

		[StringLength(50)]
		public string SerieNombre { get; set; }

		[StringLength(10)]
		public string VehiculoMatricula { get; set; }

		[StringLength(10)]
		public string VehiculoRemolque { get; set; }

	}

}
