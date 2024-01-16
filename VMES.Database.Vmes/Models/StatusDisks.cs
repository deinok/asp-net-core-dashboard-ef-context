using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class StatusDisks
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string pc { get; set; }

		[StringLength(250)]
		public string DeviceId { get; set; }

		[StringLength(250)]
		public string Model { get; set; }

		[StringLength(50)]
		public string Status { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? RamLibre { get; set; }

		[Column(TypeName = "numeric(8, 3)")]
		public decimal? CPU { get; set; }

	}

}
