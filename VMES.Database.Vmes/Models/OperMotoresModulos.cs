using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class OperMotoresModulos
	{

		public int? IdOperMotor { get; set; }

		public int? IdModulo { get; set; }

		public int? IdMedidor { get; set; }

		[Key]
		public int Id { get; set; }

		public bool? VerVariable { get; set; }

		[StringLength(250)]
		public string TextoVariable { get; set; }

		public bool? obligatorio { get; set; }

		public int? ValorMaximo { get; set; }

		public int? ValorMinimo { get; set; }

		[StringLength(250)]
		public string TextoVariable2 { get; set; }

		public int? ValorMaximo2 { get; set; }

		public int? ValorMinimo2 { get; set; }

		public bool? VerVariable2 { get; set; }

		public bool? ControlOrdenacion { get; set; }

		public int? NumOrdenacion { get; set; }

		public bool? ObligatorioConProductos { get; set; }

		[ForeignKey(nameof(IdMedidor))]
		[InverseProperty(nameof(Medidor.OperMotoresModulos))]
		public virtual Medidor IdMedidorNavigation { get; set; }

		[ForeignKey(nameof(IdModulo))]
		[InverseProperty(nameof(Modulos.OperMotoresModulos))]
		public virtual Modulos IdModuloNavigation { get; set; }

		[ForeignKey(nameof(IdOperMotor))]
		[InverseProperty(nameof(OperMotores.OperMotoresModulos))]
		public virtual OperMotores IdOperMotorNavigation { get; set; }

	}

}
