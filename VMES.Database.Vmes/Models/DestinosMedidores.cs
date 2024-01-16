using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class DestinosMedidores
	{

		[Key]
		public int id { get; set; }

		public int? idDestino { get; set; }

		public int? idMedidor { get; set; }

		public bool? Incompatible { get; set; }

		public bool? Requerido { get; set; }

		[ForeignKey(nameof(idDestino))]
		[InverseProperty(nameof(Destinos.DestinosMedidores))]
		public virtual Destinos idDestinoNavigation { get; set; }

		[ForeignKey(nameof(idMedidor))]
		[InverseProperty(nameof(Medidor.DestinosMedidores))]
		public virtual Medidor idMedidorNavigation { get; set; }

	}

}
