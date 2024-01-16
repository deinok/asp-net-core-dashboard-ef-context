using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class VentasLiniasPuntosDescarga
	{

		[Key]
		public int id { get; set; }

		public int idLineaVenta { get; set; }

		public int idPuntoDescarga { get; set; }

		[ForeignKey(nameof(idLineaVenta))]
		[InverseProperty(nameof(VentasLinias.VentasLiniasPuntosDescarga))]
		public virtual VentasLinias idLineaVentaNavigation { get; set; }

		[ForeignKey(nameof(idPuntoDescarga))]
		[InverseProperty(nameof(PuntosDescarga.VentasLiniasPuntosDescarga))]
		public virtual PuntosDescarga idPuntoDescargaNavigation { get; set; }

	}

}
