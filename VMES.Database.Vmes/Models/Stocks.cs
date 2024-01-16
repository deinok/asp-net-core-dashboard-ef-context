using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Stocks
	{

		[Key]
		public int Id { get; set; }

		public int Ubicacion { get; set; }

		public int? Formato { get; set; }

		public int Lote { get; set; }

		public int? Envase { get; set; }

		public float? Cantidad { get; set; } /* TODO MOVE TO DECIMAL(18, 3)*/

		public int? Unidad { get; set; }

		public DateTime Fecha { get; set; }

		[Obsolete("THE TRUE STATE IS THE VALUE OF [Cantidad]")]
		public StockStatus? Estado { get; set; }

		public bool Importado { get; set; }

		public bool Exportado { get; set; }

		public int? Palet { get; set; }

		public bool? Procesando { get; set; }

		[StringLength(4000)]
		public string Observaciones { get; set; }

		[Obsolete]
		public int? idOld { get; set; }

		[Obsolete]
		public int? idEntradasLineas { get; set; }

		[Obsolete]
		public int? idSalidasLineas { get; set; }

		public DateTime? FechaERP { get; set; }

		[ForeignKey(nameof(Envase))]
		[InverseProperty(nameof(Envases.Stocks))]
		public virtual Envases EnvaseNavigation { get; set; }

		[ForeignKey(nameof(Formato))]
		[InverseProperty(nameof(Formatos.Stocks))]
		public virtual Formatos FormatoNavigation { get; set; }

		[ForeignKey(nameof(Lote))]
		[InverseProperty(nameof(Lotes.Stocks))]
		public virtual Lotes LoteNavigation { get; set; }

		[ForeignKey(nameof(Ubicacion))]
		[InverseProperty(nameof(Ubicaciones.Stocks))]
		public virtual Ubicaciones UbicacionNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.Stocks))]
		public virtual Unidades UnidadNavigation { get; set; }

		[ForeignKey(nameof(idEntradasLineas))]
		[InverseProperty(nameof(EntradasLineas.Stocks))]
		public virtual EntradasLineas idEntradasLineasNavigation { get; set; }

		[ForeignKey(nameof(idSalidasLineas))]
		[InverseProperty(nameof(SalidasLinias.Stocks))]
		public virtual SalidasLinias idSalidasLineasNavigation { get; set; }

		[InverseProperty(nameof(Models.LogMovimientosStocks.IdStockNavigation))]
		public virtual ICollection<LogMovimientosStocks> LogMovimientosStocks { get; set; } = new HashSet<LogMovimientosStocks>();

		[InverseProperty(nameof(Models.StocksReserva.idStockNavigation))]
		public virtual ICollection<StocksReserva> StocksReserva { get; set; } = new HashSet<StocksReserva>();

	}

}
