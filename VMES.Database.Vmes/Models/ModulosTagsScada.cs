using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class ModulosTagsScada
	{

		[Key]
		public int Id { get; set; }

		public int? Modulo { get; set; }

		public int? TagIndex { get; set; }

		public bool? Activo { get; set; }

		[StringLength(50)]
		public string NombreMes { get; set; }

		[ForeignKey(nameof(Modulo))]
		[InverseProperty(nameof(Modulos.ModulosTagsScada))]
		public virtual Modulos ModuloNavigation { get; set; }

	}

}
