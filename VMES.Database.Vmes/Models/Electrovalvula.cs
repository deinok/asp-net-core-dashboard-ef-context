using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Electrovalvula
	{

		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(64)]
		public string Tag { get; set; }

		public int OpcConfigId { get; set; }

		public int IdPlc { get; set; }

		public bool PlcEnabled { get; set; }

		[ForeignKey(nameof(OpcConfigId))]
		[InverseProperty(nameof(Models.OpcConfig.Electrovalvulas))]
		public virtual OpcConfig OpcConfig { get; set; }

		[InverseProperty(nameof(Models.GMAO_Elementos.Electrovalvula))]
		public virtual ICollection<GMAO_Elementos> GMAO_Elementos { get; set; } = new HashSet<GMAO_Elementos>();

	}

}
