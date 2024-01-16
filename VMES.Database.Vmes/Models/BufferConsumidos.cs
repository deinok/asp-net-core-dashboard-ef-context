using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferConsumidos
	{

		[Key]
		public int Id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaRecibido { get; set; }

		public int? Orden { get; set; }

		public int? Ciclo { get; set; }

		public int? NumCorrecion { get; set; }

		public int? Origen { get; set; }

		public int? Destino { get; set; }

		[Column(TypeName = "decimal(12, 5)")]
		public decimal? ProdDensidad { get; set; }

		public int? ProdCodigo { get; set; }

		[StringLength(250)]
		public string ProdNombre { get; set; }

		public int? ProdIdLoteActual { get; set; }

		[StringLength(250)]
		public string ProdNombreLoteActual { get; set; }

		[Column(TypeName = "decimal(12, 5)")]
		public decimal? Cantidad { get; set; }

		[Column(TypeName = "decimal(12, 5)")]
		public decimal? Temperatura { get; set; }

		[Column(TypeName = "decimal(12, 5)")]
		public decimal? Humedad { get; set; }

		[Column(TypeName = "decimal(12, 5)")]
		public decimal? Ph { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaConsumido { get; set; }

		public int? DuracionStamp { get; set; }

		public int? TiempoEfectivo { get; set; }

		public int? TiempoTotal { get; set; }

		[Column(TypeName = "decimal(18, 5)")]
		public decimal? KWhEfectivo { get; set; }

		[Column(TypeName = "decimal(18, 5)")]
		public decimal? KWhTotal { get; set; }

		public int? MedidorId { get; set; }

		public int? IndicadorId { get; set; }

		public int? ModuloId { get; set; }

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

		[Column(TypeName = "decimal(18,2)")]
		public decimal? Variable1 { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal? Variable2 { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaTratado { get; set; }

		public int? CodError { get; set; }

		public string TxtError { get; set; }

		[Column(TypeName = "datetime")]
		[Obsolete]
		public DateTime? TimeStamp { get; set; }

		[Obsolete]
		public int? idUsuario { get; set; }

		public int? idDosificacionMes { get; set; }

		[Obsolete]
		public int? idopc { get; set; }

		[StringLength(32)]
		public string Hash { get; set; }

		public int? OpcConfigId { get; set; } /* TODO NOT NULL */

		[ForeignKey(nameof(OpcConfigId))]
		[InverseProperty(nameof(Models.OpcConfig.BufferConsumidos))]
		public virtual OpcConfig OpcConfig { get; set; }

	}

}
