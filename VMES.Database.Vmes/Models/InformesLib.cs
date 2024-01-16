using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class InformesLib
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string NombreInforme { get; set; }

		public int? IdCategoria { get; set; }

		public bool IsBase { get; set; }

		public int? IdInformeBase { get; set; }

		public bool Visible { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaUltima { get; set; }

		[StringLength(50)]
		public string UltimoEditor { get; set; }

		public byte[] DatosInforme { get; set; }

		[StringLength(50)]
		public string Vista { get; set; }

		public byte[] VistaXML { get; set; }

		[Obsolete]
		[StringLength(50)]
		public string ImpresoraDefecto { get; set; }

		public bool? ImpAutomatico { get; set; }

		public int? NumCopias { get; set; }

		public bool? VisibleUsuario { get; set; }

		[StringLength(250)]
		public string CopiaPara { get; set; }

		public Guid? DefaultPrinterId { get; set; }

		[ForeignKey(nameof(DefaultPrinterId))]
		[InverseProperty(nameof(Printer.InformeLibs))]
		public virtual Printer DefaultPrinter { get; set; }

		[ForeignKey(nameof(IdCategoria))]
		[InverseProperty(nameof(InformesLibCategorias.InformesLib))]
		public virtual InformesLibCategorias IdCategoriaNavigation { get; set; }

		[ForeignKey(nameof(IdInformeBase))]
		[InverseProperty(nameof(InformesLib.InverseIdInformeBaseNavigation))]
		public virtual InformesLib IdInformeBaseNavigation { get; set; }

		[InverseProperty(nameof(Models.InformesLibUsuarios.IdInformeNavigation))]
		public virtual ICollection<InformesLibUsuarios> InformesLibUsuarios { get; set; } = new HashSet<InformesLibUsuarios>();

		[InverseProperty(nameof(InformesLib.IdInformeBaseNavigation))]
		public virtual ICollection<InformesLib> InverseIdInformeBaseNavigation { get; set; } = new HashSet<InformesLib>();

	}

}
