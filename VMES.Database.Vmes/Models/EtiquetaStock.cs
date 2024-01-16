using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class EtiquetaStock
	{

		[StringLength(50)]
		public string Departamento { get; set; }

		public int Id { get; set; }

		[Required]
		[StringLength(20)]
		public string Referencia { get; set; }

		[Required]
		[StringLength(30)]
		public string Nombre { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Inicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fin { get; set; }

		[StringLength(4000)]
		public string Caducidad { get; set; }

		public int IdProducto { get; set; }

		[Required]
		[StringLength(20)]
		public string RefProducto { get; set; }

		[Required]
		[StringLength(20)]
		public string Ref2Producto { get; set; }

		[Required]
		[StringLength(50)]
		public string NombreProducto { get; set; }

		[Required]
		[StringLength(4000)]
		public string CodigoBarras { get; set; }

	}

}
