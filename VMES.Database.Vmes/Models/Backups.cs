using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class Backups
	{

		[Key]
		public int Id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? fecha { get; set; }

		public bool? HayError { get; set; }

		[StringLength(500)]
		public string TextoError { get; set; }

	}

}
