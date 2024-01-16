using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class SesionesModulo
	{

		[Key]
		public int Id { get; set; }

		public int Modulo { get; set; }

		public int? Sesion { get; set; }

		public bool? Visible { get; set; }

		public bool? Controlable { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[ForeignKey(nameof(Modulo))]
		[InverseProperty(nameof(Modulos.SesionesModulo))]
		public virtual Modulos ModuloNavigation { get; set; }

		[ForeignKey(nameof(Sesion))]
		[InverseProperty(nameof(Sesiones.SesionesModulo))]
		public virtual Sesiones SesionNavigation { get; set; }

	}

}
