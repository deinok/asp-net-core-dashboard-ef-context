using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public partial class GMAO_WarehouseStocks
	{

		[Key]
		public int ElementId { get; set; }

		[Key]
		public Guid WarehouseId { get; set; }

		public int Quantity { get; set; }

		public int? SafetyStock { get; set; }

		[StringLength(64)]
		public string Corridor { get; set; }

		[StringLength(64)]
		public string RackBody { get; set; }

		[StringLength(64)]
		public string RackColumn { get; set; }

		[StringLength(64)]
		public string RackRow { get; set; }

		[Key]
		public int ModelId { get; set; }

		[ForeignKey(nameof(ElementId))]
		[InverseProperty(nameof(GMAO_Elementos.GMAO_WarehouseStocks))]
		public virtual GMAO_Elementos Element { get; set; }

		[ForeignKey(nameof(ModelId))]
		[InverseProperty(nameof(GMAO_MarcasModelos.GMAO_WarehouseStocks))]
		public virtual GMAO_MarcasModelos Model { get; set; }

		[ForeignKey(nameof(WarehouseId))]
		[InverseProperty(nameof(GMAO_Warehouses.GMAO_WarehouseStocks))]
		public virtual GMAO_Warehouses Warehouse { get; set; }

	}

}
