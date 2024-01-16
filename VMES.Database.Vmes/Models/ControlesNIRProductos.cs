using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class ControlesNIRProductos
	{

		[Key]
		public int idControlNir { get; set; }

		[Key]
		public int idProducto { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaCreacion { get; set; }

		public int? Estado { get; set; }

		public bool? Obligatorio { get; set; }

		public bool? Restrictivo { get; set; }

		public int id { get; set; }

		[ForeignKey(nameof(idControlNir))]
		[InverseProperty(nameof(ControlesNIR.ControlesNIRProductos))]
		public virtual ControlesNIR idControlNirNavigation { get; set; }

		[ForeignKey(nameof(idProducto))]
		[InverseProperty(nameof(Productos.ControlesNIRProductos))]
		public virtual Productos idProductoNavigation { get; set; }

	}

}
