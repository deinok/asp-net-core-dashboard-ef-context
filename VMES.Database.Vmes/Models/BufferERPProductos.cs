using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPProductos
	{

		[Key]
		public int id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FImportado { get; set; }

		public bool? Preparado { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string Familia { get; set; }

		public float? Densidad { get; set; }

		[StringLength(20)]
		public string UnidadRefERP { get; set; }

		public int? Tipo { get; set; }

		[StringLength(20)]
		public string FormatoRefERP { get; set; }

		[StringLength(20)]
		public string EnvaseRefERP { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		[StringLength(20)]
		public string Referencia2 { get; set; }

		[StringLength(50)]
		public string NumeroRegistro { get; set; }

		public int? Caducidad { get; set; }

		public bool? Medicamento { get; set; }

		public int? Modulo { get; set; }

		public int? Medidor { get; set; }

		public int? TiempoEspera { get; set; }

		[Column(TypeName = "numeric(18, 2)")]
		public decimal? ToleranciaSuperior { get; set; }

		[Column(TypeName = "numeric(18, 2)")]
		public decimal? ToleranciaInferior { get; set; }

		public bool? PausaPosteriorDosificacion { get; set; }

		[Column(TypeName = "numeric(18, 2)")]
		public decimal? DesviacionMaxima { get; set; }

		public int? Estado { get; set; }

		public int? IdERPProducto { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

	}

}
