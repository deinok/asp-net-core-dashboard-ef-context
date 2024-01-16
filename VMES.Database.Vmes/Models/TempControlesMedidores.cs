using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class TempControlesMedidores
	{

		[Key]
		public int id { get; set; }

		public int? idTempControl { get; set; }

		public int? idMedidor { get; set; }

		public bool? Obligatorio { get; set; }

		public bool? Unico { get; set; }

		[ForeignKey(nameof(idMedidor))]
		[InverseProperty(nameof(Medidor.TempControlesMedidores))]
		public virtual Medidor idMedidorNavigation { get; set; }

		[ForeignKey(nameof(idTempControl))]
		[InverseProperty(nameof(TempControles.TempControlesMedidores))]
		public virtual TempControles idTempControlNavigation { get; set; }

	}

}
