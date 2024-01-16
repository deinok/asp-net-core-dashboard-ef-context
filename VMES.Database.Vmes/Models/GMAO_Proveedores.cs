using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_Proveedores
	{

		[Key]
		public int id { get; set; }

		[StringLength(50)]
		public string Ref { get; set; }

		[Required]
		[StringLength(64)]
		public string Nombre { get; set; }

		public int? MesesGarantia { get; set; }

		[InverseProperty(nameof(Models.GMAO_Compras.IdProveedorNavigation))]
		public virtual ICollection<GMAO_Compras> GMAO_Compras { get; set; } = new HashSet<GMAO_Compras>();

		[InverseProperty(nameof(Models.GMAO_ElemStocks.IdProveedorNavigation))]
		public virtual ICollection<GMAO_ElemStocks> GMAO_ElemStocks { get; set; } = new HashSet<GMAO_ElemStocks>();

		[InverseProperty(nameof(Models.GMAO_ElementosTipos.ProveedorHabitualNavigation))]
		public virtual ICollection<GMAO_ElementosTipos> GMAO_ElementosTipos { get; set; } = new HashSet<GMAO_ElementosTipos>();

	}

}
