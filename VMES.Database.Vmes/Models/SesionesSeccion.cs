using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class SesionesSeccion
	{

		public int Seccion { get; set; }

		[Key]
		public int Id { get; set; }

		public int? Sesion { get; set; }

		public bool? Visible { get; set; }

		public bool? Controlable { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[ForeignKey(nameof(Seccion))]
		[InverseProperty(nameof(Secciones.SesionesSeccion))]
		public virtual Secciones SeccionNavigation { get; set; }

		[ForeignKey(nameof(Sesion))]
		[InverseProperty(nameof(Sesiones.SesionesSeccion))]
		public virtual Sesiones SesionNavigation { get; set; }

	}

}
