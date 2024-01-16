using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class HumanMachineInterface
	{

		[Key]
		public int Id { get; set; }

		public bool Enabled { get; set; }

		[Required]
		[StringLength(64)]
		public string Name { get; set; }

		public HumanMachineInterfaceType Type { get; set; }

		public class EntradasSalidasHumanMachineInterface : HumanMachineInterface
		{

			public int TagId { get; set; }

			[ForeignKey(nameof(TagId))]
			[InverseProperty(nameof(Models.Tags.EntradasSalidasHumanMachineInterfaces))]
			public virtual Tags Tag { get; set; }

		}

		public class PremezclasHumanMachineInterface : HumanMachineInterface
		{

		}

	}

}
