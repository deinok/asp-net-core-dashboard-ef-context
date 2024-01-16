using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Comprobaciones
	{

		[Column(TypeName = "numeric(18, 0)")]
		public decimal Id { get; set; }

		[Key]
		[StringLength(50)]
		public string Tabla { get; set; }

		[Key]
		[StringLength(50)]
		public string Comprobacion { get; set; }

		[Required]
		public bool? Activo { get; set; }

		[StringLength(50)]
		public string ComprobacionNombre { get; set; }

		[StringLength(50)]
		public string TablaNombre { get; set; }

	}

}
