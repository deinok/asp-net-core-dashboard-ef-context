using System;
using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	public class Dashboard
	{

		[Key]
		public Guid Id { get; set; }

		[Required]
		[StringLength(64)]
		public string Name { get; set; }

		[Required]
		public string Value { get; set; }

	}

}
