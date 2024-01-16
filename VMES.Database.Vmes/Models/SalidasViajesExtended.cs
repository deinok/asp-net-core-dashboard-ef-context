using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class SalidasViajesExtended
	{

		public int id { get; set; }

		public int idSerie { get; set; }

		[StringLength(50)]
		public string SerieNombre { get; set; }

		public int Numero { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaCreacion { get; set; }

		public int? idVehiculo { get; set; }

		[StringLength(10)]
		public string VehiculoMatricula { get; set; }

		[StringLength(10)]
		public string VehiculoRemolque { get; set; }

		[StringLength(20)]
		public string VehiculoReferencia { get; set; }

		public int? idChofer { get; set; }

		[StringLength(50)]
		public string ChoferNombre { get; set; }

		[StringLength(14)]
		public string ChoferCIF { get; set; }

		public int? idTarjeta { get; set; }

		[StringLength(50)]
		public string TarjetaNombre { get; set; }

		public int? idEmpresaTransporte { get; set; }

		[StringLength(50)]
		public string EmpresaTransporteNombre { get; set; }

		[StringLength(14)]
		public string EmpresaTransporteCIF { get; set; }

		[StringLength(20)]
		public string EmpresaTransporteReferencia { get; set; }

		[StringLength(50)]
		public string EmpresaTransporteDireccion { get; set; }

		[StringLength(5)]
		public string EmpresaTransporteCodigoPostal { get; set; }

		[StringLength(50)]
		public string EmpresaTransportePoblacion { get; set; }

		[StringLength(50)]
		public string EmpresaTransporteProvincia { get; set; }

		[StringLength(20)]
		public string EmpresaTransporteTlf { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaSalidaFabrica { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaPrevista { get; set; }

		public int? Estado { get; set; }

		[StringLength(50)]
		public string EstadoStr { get; set; }

		[StringLength(500)]
		public string Observaciones { get; set; }

	}

}
