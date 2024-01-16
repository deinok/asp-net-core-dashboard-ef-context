using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class TagsBasculas
	{

		[Key]
		public int id { get; set; }

		public int? idTag { get; set; }

		public int? idBascula { get; set; }

		public bool? Predeterminada { get; set; }

		[ForeignKey(nameof(idBascula))]
		[InverseProperty(nameof(Bascula.TagsBasculas))]
		public virtual Bascula idBasculaNavigation { get; set; }

		[ForeignKey(nameof(idTag))]
		[InverseProperty(nameof(Tags.TagsBasculas))]
		public virtual Tags idTagNavigation { get; set; }

	}

}
