using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class EntradasExtended
	{

		public int id { get; set; }

		public int Serie { get; set; }

		[StringLength(50)]
		public string SerieNombre { get; set; }

		public int? SerieEstado { get; set; }

		[StringLength(50)]
		public string SerieEstadoTexto { get; set; }

		public int Numero { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaCreacion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaPrevista { get; set; }

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

		public int? idProveedor { get; set; }

		[StringLength(20)]
		public string ProveedorReferencia { get; set; }

		[StringLength(50)]
		public string ProveedorNombre { get; set; }

		[StringLength(14)]
		public string ProveedorCIF { get; set; }

		[StringLength(50)]
		public string ProveedorDireccion { get; set; }

		[StringLength(5)]
		public string ProveedorCodigoPostal { get; set; }

		[StringLength(50)]
		public string ProveedorPoblacion { get; set; }

		[StringLength(20)]
		public string ProveedorTelefono { get; set; }

		public int? ProveedorProvincia { get; set; }

		[StringLength(50)]
		public string ProveedorProvinciaNombre { get; set; }

		[StringLength(40)]
		public string ProveedorAbreviado { get; set; }

		public int? ProveedorPais { get; set; }

		[StringLength(50)]
		public string ProveedorPaisNombre { get; set; }

		public bool? ProveedorInhabilitado { get; set; }

		[StringLength(50)]
		public string AutorizacionDestinoFinal { get; set; }

		[StringLength(50)]
		public string ProveedorInhabilitadoTexto { get; set; }

		public int? idTarjeta { get; set; }

		[StringLength(50)]
		public string TarjetaNombre { get; set; }

		public int? Estado { get; set; }

		[StringLength(50)]
		public string EstadoTexto { get; set; }

		[StringLength(500)]
		public string Observaciones { get; set; }

		public int? idEmpresaTransporte { get; set; }

		[StringLength(50)]
		public string EmpresaTransporteNombre { get; set; }

		[StringLength(20)]
		public string EmpresaTransporteReferencia { get; set; }

		[StringLength(14)]
		public string EmpresaTransporteCIF { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Precio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFin { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[StringLength(20)]
		public string ReferenciaCompra { get; set; }

		public bool? PreDesinfeccion { get; set; }

		public bool? PostDesinfeccion { get; set; }

		public bool? PreDesinfeccionOK { get; set; }

		public int? CoeficienteRendimiento { get; set; }

		[StringLength(50)]
		public string DUA { get; set; }

		[StringLength(20)]
		public string Factura { get; set; }

		[StringLength(20)]
		public string Albaran { get; set; }

		[StringLength(100)]
		public string AceptacionDestinoFinal { get; set; }

		[StringLength(50)]
		public string PredesinfeccionOKTexto { get; set; }

		public bool? PostDesinfeccionOK { get; set; }

		[StringLength(50)]
		public string PostdesinfeccionOKTexto { get; set; }

	}

}
