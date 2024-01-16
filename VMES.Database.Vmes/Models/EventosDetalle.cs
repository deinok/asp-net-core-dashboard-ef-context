using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class EventosDetalle
	{

		[Key]
		public int Id { get; set; }

		public int Evento { get; set; }

		[StringLength(50)]
		public string Campo { get; set; }

		[StringLength(200)]
		public string ValorAntiguo { get; set; }

		[StringLength(200)]
		public string ValorNuevo { get; set; }

		[ForeignKey(nameof(Evento))]
		[InverseProperty(nameof(Eventos.EventosDetalle))]
		public virtual Eventos EventoNavigation { get; set; }

	}

}
