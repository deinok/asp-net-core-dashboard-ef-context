using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class VersionTPrevisto
	{

		[Key]
		public int Id { get; set; }

		public int idVersion { get; set; }

		public int idModulo { get; set; }

		[Column(TypeName = "numeric(18, 2)")]
		public decimal? Tiempo { get; set; }

		[ForeignKey(nameof(idModulo))]
		[InverseProperty(nameof(Modulos.VersionTPrevisto))]
		public virtual Modulos idModuloNavigation { get; set; }

		[ForeignKey(nameof(idVersion))]
		[InverseProperty(nameof(Versiones.VersionTPrevisto))]
		public virtual Versiones idVersionNavigation { get; set; }

	}

}
