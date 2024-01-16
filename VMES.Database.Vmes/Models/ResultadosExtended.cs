using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class ResultadosExtended
	{

		public int Id { get; set; }

		public int IdOrden { get; set; }

		public int? IdEntradaOrden { get; set; }

		public int? IdLineaEntradaOrden { get; set; }

		public int? IdSalidaOrden { get; set; }

		public int? IdLineaSalidaOrden { get; set; }

		public int? IdViajeLineaSalidaOrden { get; set; }

		public int? Pesada { get; set; }

		public int? Ubicacion { get; set; }

		[StringLength(50)]
		public string UbicacionNombre { get; set; }

		[StringLength(20)]
		public string UbicacionReferencia { get; set; }

		public float? Cantidad { get; set; }

		public float? Parcial { get; set; }

		public int? Proceso { get; set; }

		public int? Estado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Inicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fin { get; set; }

		public int? Lote { get; set; }

		[StringLength(30)]
		public string LoteNombre { get; set; }

		[StringLength(20)]
		public string LoteReferencia { get; set; }

		public int? Producto { get; set; }

		[StringLength(50)]
		public string ProductoNombre { get; set; }

		[StringLength(20)]
		public string ProductoReferencia { get; set; }

		[StringLength(20)]
		public string ProductoReferencia2 { get; set; }

		public int? ProductoTipo { get; set; }

		public int? Ciclo { get; set; }

		public int? Medidor { get; set; }

		[StringLength(50)]
		public string MedidorNombre { get; set; }

		public int? Unidad { get; set; }

		[StringLength(50)]
		public string UnidadNombre { get; set; }

		public float? CantidadPrincipal { get; set; }

		public int? PosicionDosificacion { get; set; }

		public int? NumCorreccion { get; set; }

		public int? Destino { get; set; }

		[StringLength(50)]
		public string DestinoNombre { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? Temperatura { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? Humedad { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? Ph { get; set; }

		public int? TiempoEfectivo { get; set; }

		public int? TiempoTotal { get; set; }

		[Column(TypeName = "decimal(18, 5)")]
		public decimal? KwhEfectivo { get; set; }

		[Column(TypeName = "decimal(18, 5)")]
		public decimal? KWhTotal { get; set; }

		public int? IndicadorId { get; set; }

		public int? MultiDosiId { get; set; }

		public int? TotalCiclos { get; set; }

		public int? idUsuario { get; set; }

		[StringLength(50)]
		public string UsuarioNombre { get; set; }

		public bool? Editado { get; set; }

		public int ModuloTipo { get; set; }

	}

}
