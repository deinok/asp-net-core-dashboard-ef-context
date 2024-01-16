using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Tenant
	{

		[Key]
		public Guid Id { get; set; }

		[Required]
		[StringLength(64)]
		public string Name { get; set; }

		[InverseProperty(nameof(Gateway.Tenant))]
		public virtual ICollection<Gateway> Gateways { get; set; } = new HashSet<Gateway>();

	}

}
