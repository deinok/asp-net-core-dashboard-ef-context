using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	public class ConfigWCF
	{

		[Key]
		[StringLength(50)]
		public string Campo { get; set; }

		[Required]
		[StringLength(50)]
		public string Valor { get; set; }

		public int id { get; set; }

	}

}
