using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class MedidoresDosificaciones
	{

		[Key]
		public int id { get; set; }

		[Required]
		public bool? Activo { get; set; }

		public int idMedidor { get; set; }

		public int idOrigen { get; set; }

		public int idProducto { get; set; }

		[Required]
		public bool? GenerarConProductos { get; set; }

		[ForeignKey(nameof(idMedidor))]
		[InverseProperty(nameof(Medidor.MedidoresDosificaciones))]
		public virtual Medidor idMedidorNavigation { get; set; }

		[ForeignKey(nameof(idOrigen))]
		[InverseProperty(nameof(Origenes.MedidoresDosificaciones))]
		public virtual Origenes idOrigenNavigation { get; set; }

		[ForeignKey(nameof(idProducto))]
		[InverseProperty(nameof(Productos.MedidoresDosificaciones))]
		public virtual Productos idProductoNavigation { get; set; }

		[InverseProperty(nameof(Models.Dosificaciones.idMedGeneradorNavigation))]
		public virtual ICollection<Dosificaciones> Dosificaciones { get; set; } = new HashSet<Dosificaciones>();

	}

}
