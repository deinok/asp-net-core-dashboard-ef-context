using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class ModulosMotores
	{

		[Key]
		public int ModuloId { get; set; }

		[Key]
		public int MotorId { get; set; }

		[ForeignKey(nameof(ModuloId))]
		[InverseProperty(nameof(Modulos.ModulosMotores))]
		public virtual Modulos Modulo { get; set; }

		[ForeignKey(nameof(MotorId))]
		[InverseProperty(nameof(Models.Motor.ModulosMotores))]
		public virtual Motor Motor { get; set; }

	}

}
