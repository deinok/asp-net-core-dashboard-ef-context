using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class SalidasAlbaranes
	{

		[Key]
		public int id { get; set; }

		public int? Serie { get; set; }

		public int? Numero { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public bool? Auto { get; set; }

		[ForeignKey(nameof(Serie))]
		[InverseProperty(nameof(Series.SalidasAlbaranes))]
		public virtual Series SerieNavigation { get; set; }

		[InverseProperty(nameof(Models.SalidasLinias.idAlbaranNavigation))]
		public virtual ICollection<SalidasLinias> SalidasLinias { get; set; } = new HashSet<SalidasLinias>();

	}

}
