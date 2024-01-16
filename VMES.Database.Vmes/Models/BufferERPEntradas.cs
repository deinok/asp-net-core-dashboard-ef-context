using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPEntradas
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

		public int? Serie { get; set; }

		public int? Numero { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaCreacion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaPrevista { get; set; }

		public int? idVehiculo { get; set; }

		public int? idChofer { get; set; }

		public int? idProveedor { get; set; }

		public int? idTarjeta { get; set; }

		[StringLength(15)]
		public string MatriculaCamion { get; set; }

		[StringLength(50)]
		public string NombreConductor { get; set; }

		[StringLength(500)]
		public string Observaciones { get; set; }

		public int? idEmpresaTransporte { get; set; }

		[StringLength(15)]
		public string MatriculaRemolque { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Precio { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[StringLength(20)]
		public string ReferenciaCompra { get; set; }

		public bool? PreDesinfeccion { get; set; }

		public bool? PostDesinfeccion { get; set; }

		[StringLength(20)]
		public string refProveedor { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public bool? isExport { get; set; }

		public int? idMES { get; set; }

		[StringLength(50)]
		public string SerieNombre { get; set; }

		[StringLength(20)]
		public string refEmpresaTransporte { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		public bool? exportado { get; set; }

		public bool? Preparado2 { get; set; }

		[StringLength(20)]
		public string RefConductor { get; set; }

		[InverseProperty(nameof(Models.BufferERPEntradasLineas.idBufferEntradaNavigation))]
		public virtual ICollection<BufferERPEntradasLineas> BufferERPEntradasLineas { get; set; } = new HashSet<BufferERPEntradasLineas>();

	}

}
