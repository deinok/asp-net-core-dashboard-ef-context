using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class MotoresGruposRelacion
	{

		[Key]
		public int idGrupo { get; set; }

		[Key]
		public int idMotor { get; set; }

		[ForeignKey(nameof(idGrupo))]
		[InverseProperty(nameof(MotoresGrupos.MotoresGruposRelacion))]
		public virtual MotoresGrupos idGrupoNavigation { get; set; }

		[ForeignKey(nameof(idMotor))]
		[InverseProperty(nameof(Motor.MotoresGruposRelacion))]
		public virtual Motor idMotorNavigation { get; set; }

	}

}
