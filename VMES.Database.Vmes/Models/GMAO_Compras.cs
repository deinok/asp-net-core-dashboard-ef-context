using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_Compras
	{

		[Key]
		public int id { get; set; }

		public DateTime FechaPedido { get; set; }

		[Required]
		[StringLength(64)]
		public string RefPedido { get; set; }

		public int IdProveedor { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaRecepcionPrevista { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaRecepcion { get; set; }

		public int? Estado { get; set; }

		[ForeignKey(nameof(IdProveedor))]
		[InverseProperty(nameof(GMAO_Proveedores.GMAO_Compras))]
		public virtual GMAO_Proveedores IdProveedorNavigation { get; set; }

		[InverseProperty(nameof(Models.GMAO_ComprasLineas.idCompraNavigation))]
		public virtual ICollection<GMAO_ComprasLineas> GMAO_ComprasLineas { get; set; } = new HashSet<GMAO_ComprasLineas>();

	}

}
