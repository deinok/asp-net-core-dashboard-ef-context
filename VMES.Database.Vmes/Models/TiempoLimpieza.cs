using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class TiempoLimpieza
	{

		[Key]
		public int ModuloId { get; set; }

		[Key]
		public int UbicacionId { get; set; }

		public int Tiempo { get; set; }

		[ForeignKey(nameof(ModuloId))]
		[InverseProperty(nameof(Modulos.TiempoLimpieza))]
		public virtual Modulos Modulo { get; set; }

		[ForeignKey(nameof(UbicacionId))]
		[InverseProperty(nameof(Ubicaciones.TiempoLimpieza))]
		public virtual Ubicaciones Ubicacion { get; set; }

	}

}
