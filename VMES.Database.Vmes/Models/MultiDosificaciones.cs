using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class MultiDosificaciones
	{

		[Key]
		public int id { get; set; }

		public int? idDosificacion { get; set; }

		public int? idUbicacion { get; set; }

		[ForeignKey(nameof(idDosificacion))]
		[InverseProperty(nameof(Dosificaciones.MultiDosificaciones))]
		public virtual Dosificaciones idDosificacionNavigation { get; set; }

		[ForeignKey(nameof(idUbicacion))]
		[InverseProperty(nameof(Ubicaciones.MultiDosificaciones))]
		public virtual Ubicaciones idUbicacionNavigation { get; set; }

	}

}
