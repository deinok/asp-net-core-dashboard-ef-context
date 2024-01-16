using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_ElemStocks
	{

		[Key]
		public int id { get; set; }

		public int? idElemento { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? Cantidad { get; set; }

		[StringLength(250)]
		public string NumSerie { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaEntrada { get; set; }

		public int? IdProveedor { get; set; }

		public int? IdCompraLinea { get; set; }

		public int? Estado { get; set; }

		public int? MesesGarantia { get; set; }

		public int? IdModelo { get; set; }

		[ForeignKey(nameof(IdCompraLinea))]
		[InverseProperty(nameof(GMAO_ComprasLineas.GMAO_ElemStocks))]
		public virtual GMAO_ComprasLineas IdCompraLineaNavigation { get; set; }

		[ForeignKey(nameof(IdModelo))]
		[InverseProperty(nameof(GMAO_MarcasModelos.GMAO_ElemStocks))]
		public virtual GMAO_MarcasModelos IdModeloNavigation { get; set; }

		[ForeignKey(nameof(IdProveedor))]
		[InverseProperty(nameof(GMAO_Proveedores.GMAO_ElemStocks))]
		public virtual GMAO_Proveedores IdProveedorNavigation { get; set; }

		[ForeignKey(nameof(idElemento))]
		[InverseProperty(nameof(GMAO_Elementos.GMAO_ElemStocks))]
		public virtual GMAO_Elementos idElementoNavigation { get; set; }

		[InverseProperty(nameof(Models.GMAO_HistStocksYElementos.idStockNavigation))]
		public virtual ICollection<GMAO_HistStocksYElementos> GMAO_HistStocksYElementos { get; set; } = new HashSet<GMAO_HistStocksYElementos>();

	}

}
