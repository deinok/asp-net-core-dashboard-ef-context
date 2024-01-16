using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Table("Caudales")]
	public class Caudal
	{

		[Key]
		public int ProductoId { get; set; }

		[Key]
		public int UbicacionId { get; set; }

		public CaudalMode Mode { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal CaudalEntrada { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal CaudalSalida { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal PorcentajeAjusteAutomaticoMaximo { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal PorcentajeAjusteMaximo { get; set; }

		[ForeignKey(nameof(ProductoId))]
		[InverseProperty(nameof(Productos.Caudales))]
		public virtual Productos Producto { get; set; }

		[ForeignKey(nameof(UbicacionId))]
		[InverseProperty(nameof(Ubicaciones.Caudales))]
		public virtual Ubicaciones Ubicacion { get; set; }

		[InverseProperty(nameof(SolicitudAjusteCaudal.Caudal))]
		public virtual ICollection<SolicitudAjusteCaudal> SolicitudesAjusteCaudal { get; set; }

	}

}
