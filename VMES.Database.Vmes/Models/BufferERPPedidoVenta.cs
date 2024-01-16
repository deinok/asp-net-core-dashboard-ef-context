using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPPedidoVenta
	{

		[Key]
		public int id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FImportado { get; set; }

		public bool? Preparado { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[StringLength(50)]
		public string RefCliente { get; set; }

		[StringLength(50)]
		public string RefDomicilio { get; set; }

		[StringLength(50)]
		public string RefPDescarga { get; set; }

		public string Observaciones { get; set; }

		public string Comentario { get; set; }

		[StringLength(50)]
		public string RefProducto { get; set; }

		[StringLength(50)]
		public string RefEnvase { get; set; }

		[StringLength(50)]
		public string RefFormato { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Cantidad { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[StringLength(50)]
		public string RefFormula { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		[StringLength(50)]
		public string RefChofer { get; set; }

		[StringLength(50)]
		public string RefVehiculo { get; set; }

		[StringLength(50)]
		public string RefEmpTransporte { get; set; }

		[StringLength(50)]
		public string MatriculaVehiculo { get; set; }

		[StringLength(50)]
		public string MatriculaRemolque { get; set; }

		[StringLength(50)]
		public string Conductor { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaPrevista { get; set; }

		[StringLength(50)]
		public string RefUnidades { get; set; }

		[StringLength(50)]
		public string RefVersionFormula { get; set; }

		[StringLength(20)]
		public string RefERP { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

	}

}
