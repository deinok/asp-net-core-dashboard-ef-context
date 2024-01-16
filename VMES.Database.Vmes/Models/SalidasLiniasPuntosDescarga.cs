using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class SalidasLiniasPuntosDescarga
	{

		[Key]
		public int id { get; set; }

		public int idLineaSalida { get; set; }

		public int idPuntoDescarga { get; set; }

		[ForeignKey(nameof(idLineaSalida))]
		[InverseProperty(nameof(SalidasLinias.SalidasLiniasPuntosDescarga))]
		public virtual SalidasLinias idLineaSalidaNavigation { get; set; }

		[ForeignKey(nameof(idPuntoDescarga))]
		[InverseProperty(nameof(PuntosDescarga.SalidasLiniasPuntosDescarga))]
		public virtual PuntosDescarga idPuntoDescargaNavigation { get; set; }

	}

}
