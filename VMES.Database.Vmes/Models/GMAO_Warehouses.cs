using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_Warehouses
	{

		[Key]
		public Guid Id { get; set; }

		[Required]
		[StringLength(128)]
		public string Name { get; set; }

		[Required]
		[StringLength(128)]
		public string Reference { get; set; }

		[InverseProperty(nameof(Models.GMAO_ElemIntervencionesPiezas.Warehouse))]
		public virtual ICollection<GMAO_ElemIntervencionesPiezas> GMAO_ElemIntervencionesPiezas { get; set; } = new HashSet<GMAO_ElemIntervencionesPiezas>();

		[InverseProperty(nameof(Models.GMAO_WarehouseStocks.Warehouse))]
		public virtual ICollection<GMAO_WarehouseStocks> GMAO_WarehouseStocks { get; set; } = new HashSet<GMAO_WarehouseStocks>();

	}

}
