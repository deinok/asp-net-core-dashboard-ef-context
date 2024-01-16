using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Gateway
	{

		[Key]
		public Guid Id { get; set; }

		public Guid TenantId { get; set; }

		[Required]
		[StringLength(64)]
		public string Name { get; set; }

		[ForeignKey(nameof(TenantId))]
		[InverseProperty(nameof(Models.Tenant.Gateways))]
		public virtual Tenant Tenant { get; set; }

		[InverseProperty(nameof(Models.OpcConfig.Gateway))]
		public virtual ICollection<OpcConfig> OpcConfig { get; set; } = new HashSet<OpcConfig>();

	}

}
