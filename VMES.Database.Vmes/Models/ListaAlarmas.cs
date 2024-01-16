using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class ListaAlarmas
	{

		public int IDAlarma { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaError { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaRespuesta { get; set; }

		public int? SegundosAlarma { get; set; }

		public int? idOrden { get; set; }

		public int? IDError { get; set; }

		[StringLength(250)]
		public string DescripcionError { get; set; }

		public int? IDRespuesta { get; set; }

		[StringLength(250)]
		public string Texto { get; set; }

		public int? idDosificacion { get; set; }

		[StringLength(250)]
		public string OrdenNombre { get; set; }

		[StringLength(50)]
		public string OrdenProductoFinalNombre { get; set; }

		[StringLength(20)]
		public string OrdenProductoFinalRef { get; set; }

		public int? DosificacionIdProducto { get; set; }

		[StringLength(50)]
		public string DosificacionNombreProducto { get; set; }

		[StringLength(20)]
		public string DosificacionReferenciaProducto { get; set; }

		[StringLength(250)]
		public string PCRespuesta { get; set; }

		[StringLength(250)]
		public string textoOpcional { get; set; }

		[StringLength(20)]
		public string textoAdicional { get; set; }

		[StringLength(50)]
		public string Modulo { get; set; }

		[StringLength(50)]
		public string Medidor { get; set; }

		public int? MotorId { get; set; }

		[StringLength(50)]
		public string MotorNombreMes { get; set; }

		[StringLength(50)]
		public string MotorTag { get; set; }

		[StringLength(50)]
		public string seccion { get; set; }

		[StringLength(50)]
		public string gruposeccion { get; set; }

	}

}
