using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class MotoresHistorico
	{

		[Key]
		public int MotorId { get; set; }

		[Key]
		public DateTime Timestamp { get; set; }

		public long TotalJouls { get; set; }

		public long EfectiveJouls { get; set; }

		public long ActiveWatts { get; set; }

		public long TotalWatts { get; set; }

		public long ReactiveWatts { get; set; }

		[ForeignKey(nameof(MotorId))]
		[InverseProperty(nameof(Models.Motor.MotoresHistorico))]
		public virtual Motor Motor { get; set; }

	}

}
