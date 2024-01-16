using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GruposIncompatibilidades
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(250)]
		public string Descripcion { get; set; }

		[InverseProperty(nameof(Models.GruposIncompatibilidadesLineas.IdGrupoNavigation))]
		public virtual ICollection<GruposIncompatibilidadesLineas> GruposIncompatibilidadesLineas { get; set; } = new HashSet<GruposIncompatibilidadesLineas>();

		[InverseProperty(nameof(Models.ProductosGruposIncompatibilidades.IdGrupoIncompatibilidadNavigation))]
		public virtual ICollection<ProductosGruposIncompatibilidades> ProductosGruposIncompatibilidades { get; set; } = new HashSet<ProductosGruposIncompatibilidades>();

	}

}
