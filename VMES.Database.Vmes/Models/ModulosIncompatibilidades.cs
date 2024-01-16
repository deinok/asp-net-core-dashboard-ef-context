using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class ModulosIncompatibilidades
	{

		[Key]
		public int Id { get; set; }

		public int? ModuloBase { get; set; }

		public int? ModuloRelacionado { get; set; }

		public bool? SiempreFlexible { get; set; }

		[ForeignKey(nameof(ModuloBase))]
		[InverseProperty(nameof(Modulos.ModulosIncompatibilidadesModuloBaseNavigation))]
		public virtual Modulos ModuloBaseNavigation { get; set; }

		[ForeignKey(nameof(ModuloRelacionado))]
		[InverseProperty(nameof(Modulos.ModulosIncompatibilidadesModuloRelacionadoNavigation))]
		public virtual Modulos ModuloRelacionadoNavigation { get; set; }

	}

}
