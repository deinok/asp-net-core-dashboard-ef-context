using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class InformesLibUsuarios
	{

		[Key]
		public int Id { get; set; }

		public int IdInforme { get; set; }

		public int IdUsuario { get; set; }

		public bool ImpAutomatico { get; set; }

		[Obsolete]
		[StringLength(50)]
		public string ImpresoraDefecto { get; set; }

		public int NumCopias { get; set; }

		[Required]
		public bool? Visible { get; set; }

		[Required]
		public bool? Habilitado { get; set; }

		public Guid? DefaultPrinterId { get; set; }

		[ForeignKey(nameof(DefaultPrinterId))]
		[InverseProperty(nameof(Printer.InformeLibUsuarios))]
		public virtual Printer DefaultPrinter { get; set; }

		[ForeignKey(nameof(IdInforme))]
		[InverseProperty(nameof(InformesLib.InformesLibUsuarios))]
		public virtual InformesLib IdInformeNavigation { get; set; }

		[ForeignKey(nameof(IdUsuario))]
		[InverseProperty(nameof(Usuarios.InformesLibUsuarios))]
		public virtual Usuarios IdUsuarioNavigation { get; set; }

	}

}
