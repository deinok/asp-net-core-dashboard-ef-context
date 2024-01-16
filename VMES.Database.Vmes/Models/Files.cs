using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Files
	{

		[Key]
		public Guid Id { get; set; }

		[Required]
		public byte[] Bytes { get; set; }

		[Required]
		[StringLength(64)]
		public string MimeType { get; set; }

		[InverseProperty(nameof(Models.FileGmaoElement.File))]
		public virtual ICollection<FileGmaoElement> FileGmaoElement { get; set; } = new HashSet<FileGmaoElement>();

	}

}
