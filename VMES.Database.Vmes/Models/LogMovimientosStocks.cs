using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class LogMovimientosStocks
	{

		[Key]
		public int Id { get; set; }

		public int? IdProducto { get; set; }

		public int? IdLote { get; set; }

		public int? IdStock { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? Cantidad { get; set; }

		public int? IdUbicacion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? Modulo { get; set; }

		public int? Medidor { get; set; }

		public LogMovimientosStocksType? TipoMovimiento { get; set; }

		public int? Operario { get; set; }

		public int? idOrden { get; set; }

		public int? Ciclo { get; set; }

		public bool? Exportado { get; set; }

		[StringLength(100)]
		public string ErrorTxtExport { get; set; }

		[StringLength(500)]
		public string Comentario { get; set; }

		[ForeignKey(nameof(IdLote))]
		[InverseProperty(nameof(Lotes.LogMovimientosStocks))]
		public virtual Lotes IdLoteNavigation { get; set; }

		[ForeignKey(nameof(IdProducto))]
		[InverseProperty(nameof(Productos.LogMovimientosStocks))]
		public virtual Productos IdProductoNavigation { get; set; }

		[ForeignKey(nameof(IdStock))]
		[InverseProperty(nameof(Stocks.LogMovimientosStocks))]
		public virtual Stocks IdStockNavigation { get; set; }

		[ForeignKey(nameof(IdUbicacion))]
		[InverseProperty(nameof(Ubicaciones.LogMovimientosStocks))]
		public virtual Ubicaciones IdUbicacionNavigation { get; set; }

		[ForeignKey(nameof(Medidor))]
		[InverseProperty(nameof(Models.Medidor.LogMovimientosStocks))]
		public virtual Medidor MedidorNavigation { get; set; }

		[ForeignKey(nameof(Modulo))]
		[InverseProperty(nameof(Modulos.LogMovimientosStocks))]
		public virtual Modulos ModuloNavigation { get; set; }

		[ForeignKey(nameof(Operario))]
		[InverseProperty(nameof(Usuarios.LogMovimientosStocks))]
		public virtual Usuarios OperarioNavigation { get; set; }

		[ForeignKey(nameof(idOrden))]
		[InverseProperty(nameof(Ordenes.LogMovimientosStocks))]
		public virtual Ordenes idOrdenNavigation { get; set; }

	}

}
