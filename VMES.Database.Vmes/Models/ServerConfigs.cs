using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	public class ServerConfigs
	{

		[Key]
		[StringLength(50)]
		public string Campo { get; set; }

		[Required]
		[StringLength(250)]
		public string Valor { get; set; }

		public int id { get; set; }

	}

}
