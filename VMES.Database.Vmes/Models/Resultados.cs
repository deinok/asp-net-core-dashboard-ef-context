using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Resultados
	{

		[Key]
		public int Id { get; set; }

		public int Serie { get; set; }

		public int Orden { get; set; }

		public int IdOld { get; set; }

		public int? Pesada { get; set; }

		public int? Ubicacion { get; set; }

		public float? Cantidad { get; set; }

		public float? Parcial { get; set; }

		public int? Proceso { get; set; }

		public int? Estado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Inicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fin { get; set; }

		[StringLength(30)]
		public string LoteNombre { get; set; }

		public int? Formato { get; set; }

		public int? Lote { get; set; }

		public int? Producto { get; set; }

		public int? Ciclo { get; set; }

		public int? Medidor { get; set; }

		public int? Unidad { get; set; }

		public float? CantidadPrincipal { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? PosicionDosificacion { get; set; }

		public bool? Regularizado { get; set; }

		public int? TipoPesada { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? PesoAcumuladoBascula { get; set; }

		public int? NumCorreccion { get; set; }

		public int? Destino { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? Temperatura { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? Humedad { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? Ph { get; set; }

		[Obsolete]
		public int? TiempoEfectivo { get; set; }

		[Obsolete]
		public int? TiempoTotal { get; set; }

		[Column(TypeName = "decimal(18, 5)")]
		[Obsolete]
		public decimal? KwhEfectivo { get; set; }

		[Column(TypeName = "decimal(18, 5)")]
		[Obsolete]
		public decimal? KWhTotal { get; set; }

		public int? IndicadorId { get; set; }

		public int? MultiDosiId { get; set; }

		public int? TotalCiclos { get; set; }

		public int? Camino { get; set; }

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

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? Variable1 { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? Variable2 { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? TimeStamp { get; set; }

		public int? DuracionStamp { get; set; }

		public int? idUsuario { get; set; }

		public bool? Editado { get; set; }

		public int? IdDosificacion { get; set; }

		[ForeignKey(nameof(Formato))]
		[InverseProperty(nameof(Formatos.Resultados))]
		public virtual Formatos FormatoNavigation { get; set; }

		[ForeignKey(nameof(Lote))]
		[InverseProperty(nameof(Lotes.Resultados))]
		public virtual Lotes LoteNavigation { get; set; }

		[ForeignKey(nameof(Medidor))]
		[InverseProperty(nameof(Models.Medidor.ResultadosNavigation))]
		public virtual Medidor MedidorNavigation { get; set; }

		[ForeignKey(nameof(Orden))]
		[InverseProperty(nameof(Ordenes.Resultados))]
		public virtual Ordenes OrdenNavigation { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Productos.Resultados))]
		public virtual Productos ProductoNavigation { get; set; }

		[ForeignKey(nameof(Ubicacion))]
		[InverseProperty(nameof(Ubicaciones.Resultados))]
		public virtual Ubicaciones UbicacionNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.Resultados))]
		public virtual Unidades UnidadNavigation { get; set; }

	}

}
