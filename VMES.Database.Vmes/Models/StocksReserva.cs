using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class StocksReserva
	{

		[Key]
		public int id { get; set; }

		public int? idOrden { get; set; }

		public int? idEntradasLineas { get; set; }

		public int? idSalidasLineas { get; set; }

		public int? idSalidasLineasMedic { get; set; }

		public int? idLote { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Cantidad { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[Required]
		public bool? Activo { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaServido { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? CantidadReservada { get; set; }

		public int? idProducto { get; set; }

		public int? idUbicacion { get; set; }

		public int? idStock { get; set; }

		[ForeignKey(nameof(idEntradasLineas))]
		[InverseProperty(nameof(EntradasLineas.StocksReserva))]
		public virtual EntradasLineas idEntradasLineasNavigation { get; set; }

		[ForeignKey(nameof(idLote))]
		[InverseProperty(nameof(Lotes.StocksReserva))]
		public virtual Lotes idLoteNavigation { get; set; }

		[ForeignKey(nameof(idOrden))]
		[InverseProperty(nameof(Ordenes.StocksReserva))]
		public virtual Ordenes idOrdenNavigation { get; set; }

		[ForeignKey(nameof(idProducto))]
		[InverseProperty(nameof(Productos.StocksReserva))]
		public virtual Productos idProductoNavigation { get; set; }

		[ForeignKey(nameof(idSalidasLineasMedic))]
		[InverseProperty(nameof(SalidasLiniasMedicaciones.StocksReserva))]
		public virtual SalidasLiniasMedicaciones idSalidasLineasMedicNavigation { get; set; }

		[ForeignKey(nameof(idSalidasLineas))]
		[InverseProperty(nameof(SalidasLinias.StocksReserva))]
		public virtual SalidasLinias idSalidasLineasNavigation { get; set; }

		[ForeignKey(nameof(idStock))]
		[InverseProperty(nameof(Stocks.StocksReserva))]
		public virtual Stocks idStockNavigation { get; set; }

		[ForeignKey(nameof(idUbicacion))]
		[InverseProperty(nameof(Ubicaciones.StocksReserva))]
		public virtual Ubicaciones idUbicacionNavigation { get; set; }

	}

}
