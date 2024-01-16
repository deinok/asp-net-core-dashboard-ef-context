using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class DesglosesExtended
	{

		public int Id { get; set; }

		public int? Serie { get; set; }

		public int Orden { get; set; }

		public int? IdEntrada { get; set; }

		public int? IdLineaEntrada { get; set; }

		public int? IdOld { get; set; }

		public int? Producto { get; set; }

		[StringLength(50)]
		public string ProductoNombre { get; set; }

		[StringLength(20)]
		public string ProductoReferencia { get; set; }

		public int? ProductoTipo { get; set; }

		public int? Lote { get; set; }

		[StringLength(30)]
		public string LoteNombre { get; set; }

		[StringLength(20)]
		public string LoteReferencia { get; set; }

		public int? Ubicacion { get; set; }

		[StringLength(50)]
		public string UbicacionNombre { get; set; }

		[StringLength(20)]
		public string UbicacionReferencia { get; set; }

		public float? Cantidad { get; set; }

		public float? Servida { get; set; }

		public int? Unidad { get; set; }

		[StringLength(50)]
		public string UnidadNombre { get; set; }

		public float? CantidadPrincipal { get; set; }

		public int? TipoRegistro { get; set; }

		[StringLength(50)]
		public string TipoRegistroTexto { get; set; }

		public bool? Finalizado { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? Estado { get; set; }

		public int Ciclo { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? NumCorrecion { get; set; }

		[Column(TypeName = "decimal(12, 5)")]
		public decimal? ProdDensidad { get; set; }

		[StringLength(250)]
		public string ProdNombre { get; set; }

		[StringLength(250)]
		public string ProdNombreLoteActual { get; set; }

		[Column(TypeName = "decimal(12, 5)")]
		public decimal? Temperatura { get; set; }

		[Column(TypeName = "decimal(12, 5)")]
		public decimal? Humedad { get; set; }

		[Column(TypeName = "decimal(12, 5)")]
		public decimal? Ph { get; set; }

		public int? DuracionStamp { get; set; }

		public int? TiempoEfectivo { get; set; }

		public int? TiempoTotal { get; set; }

		[Column(TypeName = "decimal(18, 5)")]
		public decimal? KWhEfectivo { get; set; }

		[Column(TypeName = "decimal(18, 5)")]
		public decimal? KWhTotal { get; set; }

		public int? MedidorId { get; set; }

		[StringLength(50)]
		public string MedidorNombre { get; set; }

		public int? IndicadorId { get; set; }

		public int? UsuarioId { get; set; }

		public int? MultidosiId { get; set; }

		public int? TotalCiclos { get; set; }

		public int? Camino { get; set; }

		public int? Secuencia { get; set; }

		public int? OperacionId { get; set; }

		public int? ValidacionId { get; set; }

		public int? TemperaturaId { get; set; }

		public int? PhId { get; set; }

		public bool? FinalSecuencia { get; set; }

		public bool? FinalCiclo { get; set; }

		public bool? FinalMedidor { get; set; }

		public bool? FinalOrden { get; set; }

		public bool? CantidadManual { get; set; }

		public bool? OrdenCancelada { get; set; }

		public bool? BitAux1 { get; set; }

		public bool? BitAux2 { get; set; }

		[Column(TypeName = "decimal(12, 5)")]
		public decimal? Variable1 { get; set; }

		[Column(TypeName = "decimal(12, 5)")]
		public decimal? Variable2 { get; set; }

		public int? Tipo { get; set; }

		[StringLength(50)]
		public string TipoStr { get; set; }

		public bool? Editado { get; set; }

		[StringLength(50)]
		public string ModuloNombre { get; set; }

		public int? ModuloTipo { get; set; }

	}

}
