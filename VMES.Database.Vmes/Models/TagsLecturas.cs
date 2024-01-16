using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class TagsLecturas
	{

		[Key]
		public int id { get; set; }

		[StringLength(100)]
		public string Lectura { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FRecibido { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(250)]
		public string TextoError { get; set; }

		[StringLength(250)]
		public string Solucion { get; set; }

		public int? idTag { get; set; }

		[ForeignKey(nameof(idTag))]
		[InverseProperty(nameof(Models.Tags.TagsLecturas))]
		public virtual Tags idTagNavigation { get; set; }

		[InverseProperty(nameof(Models.Tags.idLecturaTagNavigation))]
		public virtual ICollection<Tags> Tags { get; set; } = new HashSet<Tags>();

	}

}
