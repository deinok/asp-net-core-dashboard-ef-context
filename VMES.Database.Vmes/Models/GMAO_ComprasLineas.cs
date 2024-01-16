using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_ComprasLineas
	{

		[Key]
		public int id { get; set; }

		public int idCompra { get; set; }

		public int? idElemento { get; set; }

		public int Cantidad { get; set; }

		public int CantidadRecibida { get; set; }

		public DateTime? FechaRecepcion { get; set; }

		[ForeignKey(nameof(idCompra))]
		[InverseProperty(nameof(GMAO_Compras.GMAO_ComprasLineas))]
		public virtual GMAO_Compras idCompraNavigation { get; set; }

		[ForeignKey(nameof(idElemento))]
		[InverseProperty(nameof(GMAO_Elementos.GMAO_ComprasLineas))]
		public virtual GMAO_Elementos idElementoNavigation { get; set; }

		[InverseProperty(nameof(Models.GMAO_ElemStocks.IdCompraLineaNavigation))]
		public virtual ICollection<GMAO_ElemStocks> GMAO_ElemStocks { get; set; } = new HashSet<GMAO_ElemStocks>();

	}

}
