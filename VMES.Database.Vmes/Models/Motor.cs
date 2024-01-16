using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Table("Motores")]
	public class Motor
	{

		[Key]
		public int Id { get; set; }

		[Column("TAG")]
		[Required]
		[StringLength(64)]
		public string Tag { get; set; }

		public int OpcConfigId { get; set; }

		[Column("idPLC")]
		public int IdPlc { get; set; }

		public bool PlcEnabled { get; set; }

		[ForeignKey(nameof(OpcConfigId))]
		[InverseProperty(nameof(Models.OpcConfig.Motores))]
		public virtual OpcConfig OpcConfig { get; set; }

		[InverseProperty(nameof(Models.GMAO_Elementos.idMotorNavigation))]
		public virtual ICollection<GMAO_Elementos> GMAO_Elementos { get; set; } = new HashSet<GMAO_Elementos>();

		[InverseProperty(nameof(Models.ModulosMotores.Motor))]
		public virtual ICollection<ModulosMotores> ModulosMotores { get; set; } = new HashSet<ModulosMotores>();

		[InverseProperty(nameof(Models.MotoresGruposRelacion.idMotorNavigation))]
		public virtual ICollection<MotoresGruposRelacion> MotoresGruposRelacion { get; set; } = new HashSet<MotoresGruposRelacion>();

		[InverseProperty(nameof(Models.MotoresHistorico.Motor))]
		public virtual ICollection<MotoresHistorico> MotoresHistorico { get; set; } = new HashSet<MotoresHistorico>();

	}

}
