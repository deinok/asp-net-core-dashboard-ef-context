using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Inventarios
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? Estado { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[InverseProperty(nameof(Models.Existencias.InventarioNavigation))]
		public virtual ICollection<Existencias> Existencias { get; set; } = new HashSet<Existencias>();

	}

}
