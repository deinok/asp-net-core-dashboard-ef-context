using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_HistStocksYElementos
	{

		[Key]
		public int id { get; set; }

		public int? idStock { get; set; }

		public int? idElemento { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFinal { get; set; }

		public int? HorasUsoInicio { get; set; }

		public int? HorasUsoFinal { get; set; }

		[ForeignKey(nameof(idElemento))]
		[InverseProperty(nameof(GMAO_Elementos.GMAO_HistStocksYElementos))]
		public virtual GMAO_Elementos idElementoNavigation { get; set; }

		[ForeignKey(nameof(idStock))]
		[InverseProperty(nameof(GMAO_ElemStocks.GMAO_HistStocksYElementos))]
		public virtual GMAO_ElemStocks idStockNavigation { get; set; }

	}

}
