using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_Departamentos
	{

		[Key]
		public int id { get; set; }

		[Required]
		[StringLength(64)]
		public string Nombre { get; set; }

		[StringLength(250)]
		public string Descripcion { get; set; }

		public int? IdResponsable { get; set; }

		public bool? Externo { get; set; }

		[StringLength(50)]
		public string Telefono { get; set; }

		[ForeignKey(nameof(IdResponsable))]
		[InverseProperty(nameof(GMAO_Operarios.GMAO_Departamentos))]
		public virtual GMAO_Operarios IdResponsableNavigation { get; set; }

		[InverseProperty(nameof(Models.GMAO_Deps_Operarios.idDepartamentoNavigation))]
		public virtual ICollection<GMAO_Deps_Operarios> GMAO_Deps_Operarios { get; set; } = new HashSet<GMAO_Deps_Operarios>();

		[InverseProperty(nameof(Models.GMAO_ElemIntervenciones.IDDepartamentoNavigation))]
		public virtual ICollection<GMAO_ElemIntervenciones> GMAO_ElemIntervenciones { get; set; } = new HashSet<GMAO_ElemIntervenciones>();

	}

}
