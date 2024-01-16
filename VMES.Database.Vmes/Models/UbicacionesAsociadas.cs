using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class UbicacionesAsociadas
	{

		[Key]
		public int id { get; set; }

		public int? idUbicacion1 { get; set; }

		public int? idUbicacion2 { get; set; }

		[ForeignKey(nameof(idUbicacion1))]
		[InverseProperty(nameof(Ubicaciones.UbicacionesAsociadasidUbicacion1Navigation))]
		public virtual Ubicaciones idUbicacion1Navigation { get; set; }

		[ForeignKey(nameof(idUbicacion2))]
		[InverseProperty(nameof(Ubicaciones.UbicacionesAsociadasidUbicacion2Navigation))]
		public virtual Ubicaciones idUbicacion2Navigation { get; set; }

	}

}
