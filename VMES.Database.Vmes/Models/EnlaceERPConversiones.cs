using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	public class EnlaceERPConversiones
	{

		[Key]
		public int id { get; set; }

		public int? Tipo { get; set; }

		[StringLength(150)]
		public string VOriginal { get; set; }

		[StringLength(150)]
		public string VNuevo { get; set; }

		public int? campo { get; set; }

	}

}
