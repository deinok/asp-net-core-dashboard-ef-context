using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class TiposIva
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public float? Porcentaje { get; set; }

		public bool? Principal { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[InverseProperty(nameof(Models.Productos.TipoIvaNavigation))]
		public virtual ICollection<Productos> Productos { get; set; } = new HashSet<Productos>();

	}

}
