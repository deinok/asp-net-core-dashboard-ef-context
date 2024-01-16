using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_ElemAlternativos
	{

		[Key]
		public int IdPadre { get; set; }

		[Key]
		public int IdHijo { get; set; }

		[ForeignKey(nameof(IdHijo))]
		[InverseProperty(nameof(GMAO_Elementos.GMAO_ElemAlternativosIdHijoNavigation))]
		public virtual GMAO_Elementos IdHijoNavigation { get; set; }

		[ForeignKey(nameof(IdPadre))]
		[InverseProperty(nameof(GMAO_Elementos.GMAO_ElemAlternativosIdPadreNavigation))]
		public virtual GMAO_Elementos IdPadreNavigation { get; set; }

	}

}
