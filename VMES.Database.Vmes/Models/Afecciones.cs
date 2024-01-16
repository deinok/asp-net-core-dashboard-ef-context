using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Afecciones
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[StringLength(255)]
		public string Nombre { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[InverseProperty(nameof(Models.Medicaciones.AfeccionNavigation))]
		public virtual ICollection<Medicaciones> Medicaciones { get; set; } = new HashSet<Medicaciones>();

		[InverseProperty(nameof(Models.Productos.AfeccionNavigation))]
		public virtual ICollection<Productos> Productos { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Models.Recetas.idAfeccionNavigation))]
		public virtual ICollection<Recetas> Recetas { get; set; } = new HashSet<Recetas>();

	}

}
