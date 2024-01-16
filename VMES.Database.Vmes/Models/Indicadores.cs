using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Indicadores
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? IdPlc { get; set; }

		public int? IdMedidor { get; set; }

		public int? IdBascula { get; set; }

		public int? IdOpc { get; set; }

		[ForeignKey(nameof(IdBascula))]
		[InverseProperty(nameof(Bascula.Indicadores))]
		public virtual Bascula IdBasculaNavigation { get; set; }

		[ForeignKey(nameof(IdMedidor))]
		[InverseProperty(nameof(Medidor.Indicadores))]
		public virtual Medidor IdMedidorNavigation { get; set; }

	}

}
