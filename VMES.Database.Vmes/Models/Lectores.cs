using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	public class Lectores
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? Tipo { get; set; }

		public int? Receptor { get; set; }

		public bool? Inhalambrico { get; set; }

		public bool? Terminal { get; set; }

		public bool? Multipuesto { get; set; }

		public int? Nodo { get; set; }

		[StringLength(20)]
		public string Plc { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

	}

}
