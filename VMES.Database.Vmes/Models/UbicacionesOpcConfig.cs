using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class UbicacionesOpcConfig
	{
		[Key]
		public int UbicacionId { get; set; }

		[Key]
		public int OpcConfigId { get; set; }

		[Key]
		public int IdPlc { get; set; }

		public bool PlcEnabled { get; set; }

		[ForeignKey(nameof(OpcConfigId))]
		[InverseProperty(nameof(Modulos.OpcConfig.UbicacionesOpcConfig))]
		public virtual OpcConfig OpcConfig { get; set; }

		[ForeignKey(nameof(UbicacionId))]
		[InverseProperty(nameof(Ubicaciones.UbicacionesOpcConfig))]
		public virtual Ubicaciones Ubicacion { get; set; }

	}

}
