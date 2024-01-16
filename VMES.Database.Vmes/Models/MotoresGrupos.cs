using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class MotoresGrupos
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[InverseProperty(nameof(Models.MotoresGruposRelacion.idGrupoNavigation))]
		public virtual ICollection<MotoresGruposRelacion> MotoresGruposRelacion { get; set; } = new HashSet<MotoresGruposRelacion>();

	}

}
