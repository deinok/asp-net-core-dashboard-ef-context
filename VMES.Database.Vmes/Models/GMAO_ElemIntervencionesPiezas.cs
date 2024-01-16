using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_ElemIntervencionesPiezas
	{

		[Key]
		public int id { get; set; }

		public int? IdIntervencion { get; set; }

		public int ElementId { get; set; }

		public int Quantity { get; set; }

		public Guid WarehouseId { get; set; }

		[ForeignKey(nameof(ElementId))]
		[InverseProperty(nameof(GMAO_Elementos.GMAO_ElemIntervencionesPiezas))]
		public virtual GMAO_Elementos Element { get; set; }

		[ForeignKey(nameof(IdIntervencion))]
		[InverseProperty(nameof(GMAO_ElemIntervenciones.GMAO_ElemIntervencionesPiezas))]
		public virtual GMAO_ElemIntervenciones IdIntervencionNavigation { get; set; }

		[ForeignKey(nameof(WarehouseId))]
		[InverseProperty(nameof(GMAO_Warehouses.GMAO_ElemIntervencionesPiezas))]
		public virtual GMAO_Warehouses Warehouse { get; set; }

	}

}
