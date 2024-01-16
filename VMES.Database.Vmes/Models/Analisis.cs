using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Analisis
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public float? Precio { get; set; }

		public int? Estado { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? idOld { get; set; }

		[InverseProperty(nameof(Models.Familias.AnalisiNavigation))]
		public virtual ICollection<Familias> Familias { get; set; } = new HashSet<Familias>();

	}

}
