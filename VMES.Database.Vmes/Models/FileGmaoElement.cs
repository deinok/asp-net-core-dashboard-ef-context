using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class FileGmaoElement
	{

		[Key]
		public Guid FileId { get; set; }

		[Key]
		public int GmaoElementId { get; set; }

		[ForeignKey(nameof(FileId))]
		[InverseProperty(nameof(Files.FileGmaoElement))]
		public virtual Files File { get; set; }

		[ForeignKey(nameof(GmaoElementId))]
		[InverseProperty(nameof(GMAO_Elementos.FileGmaoElement))]
		public virtual GMAO_Elementos GmaoElement { get; set; }

	}

}
