using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class LineaVentaLineaSalida
	{

		[Key]
		public int Id { get; set; }

		public int idLineaVenta { get; set; }

		public int idLineaSalida { get; set; }

		[ForeignKey(nameof(idLineaSalida))]
		[InverseProperty(nameof(SalidasLinias.LineaVentaLineaSalida))]
		public virtual SalidasLinias idLineaSalidaNavigation { get; set; }

		[ForeignKey(nameof(idLineaVenta))]
		[InverseProperty(nameof(VentasLinias.LineaVentaLineaSalida))]
		public virtual VentasLinias idLineaVentaNavigation { get; set; }

	}

}
