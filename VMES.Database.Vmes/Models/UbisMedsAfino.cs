using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class UbisMedsAfino
	{

		[Key]
		public int idUbicacion { get; set; }

		[Key]
		public int idMedidor { get; set; }

		public int? PAfino { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal? MaxAfino { get; set; }

		public int? VelocidadMaxima { get; set; }

		public int? VelocidadLenta { get; set; }

		public int id { get; set; }

		[ForeignKey(nameof(idMedidor))]
		[InverseProperty(nameof(Medidor.UbisMedsAfino))]
		public virtual Medidor idMedidorNavigation { get; set; }

		[ForeignKey(nameof(idUbicacion))]
		[InverseProperty(nameof(Ubicaciones.UbisMedsAfino))]
		public virtual Ubicaciones idUbicacionNavigation { get; set; }

	}

}
