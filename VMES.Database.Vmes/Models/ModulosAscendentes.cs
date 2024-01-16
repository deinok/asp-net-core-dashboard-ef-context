using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class ModulosAscendentes
	{

		[Key]
		public int Id { get; set; }

		public int Medidor { get; set; }

		public int? Ascendente { get; set; }

		public int? Origen { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public bool? ArrastrarLote { get; set; }

		[ForeignKey(nameof(Ascendente))]
		[InverseProperty(nameof(Modulos.ModulosAscendentes))]
		public virtual Modulos AscendenteNavigation { get; set; }

		[ForeignKey(nameof(Medidor))]
		[InverseProperty(nameof(Models.Medidor.ModulosAscendentes))]
		public virtual Medidor MedidorNavigation { get; set; }

	}

}
