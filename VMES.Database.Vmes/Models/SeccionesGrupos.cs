using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class SeccionesGrupos
	{

		[Column("id")]
		[Key]
		public int Id { get; set; }

		[Column("idPLC")]
		public int? IdPlc { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? OpcConfigId { get; set; }

		[ForeignKey(nameof(OpcConfigId))]
		[InverseProperty(nameof(Models.OpcConfig.SeccionesGrupos))]
		public virtual OpcConfig OpcConfig { get; set; }

		[InverseProperty(nameof(Models.NetAlarmas.IdGrupoNavigation))]
		public virtual ICollection<NetAlarmas> NetAlarmas { get; set; } = new HashSet<NetAlarmas>();

	}

}
