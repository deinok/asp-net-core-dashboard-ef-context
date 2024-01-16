using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class FamiliasMedidor
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[InverseProperty(nameof(Models.Medidor.FamiliaMedidorNavigation))]
		public virtual ICollection<Medidor> Medidores { get; set; } = new HashSet<Medidor>();

		[InverseProperty(nameof(Models.Productos.FamiliaMedidorNavigation))]
		public virtual ICollection<Productos> Productos { get; set; } = new HashSet<Productos>();

	}

}
