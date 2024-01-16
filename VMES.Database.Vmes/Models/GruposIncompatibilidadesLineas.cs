using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GruposIncompatibilidadesLineas
	{

		[Key]
		public int Id { get; set; }

		public int IdGrupo { get; set; }

		public int IdProducto { get; set; }

		public int? Tipo { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? PorcentajeMinimo { get; set; }

		[ForeignKey(nameof(IdGrupo))]
		[InverseProperty(nameof(GruposIncompatibilidades.GruposIncompatibilidadesLineas))]
		public virtual GruposIncompatibilidades IdGrupoNavigation { get; set; }

		[ForeignKey(nameof(IdProducto))]
		[InverseProperty(nameof(Productos.GruposIncompatibilidadesLineas))]
		public virtual Productos IdProductoNavigation { get; set; }

	}

}
