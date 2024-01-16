using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_Operarios
	{

		[Key]
		public int id { get; set; }

		[Required]
		[StringLength(64)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string Apellidos { get; set; }

		[StringLength(50)]
		public string DNI { get; set; }

		public bool? Autorizado { get; set; }

		[StringLength(50)]
		public string Telefono { get; set; }

		[StringLength(50)]
		public string Telefono2 { get; set; }

		[StringLength(50)]
		public string Email { get; set; }

		public bool? Externo { get; set; }

		[StringLength(50)]
		public string Login { get; set; }

		[StringLength(50)]
		public string Pass { get; set; }

		[Column(TypeName = "decimal(12, 3)")]
		public decimal? CosteDietas { get; set; }

		[Column(TypeName = "decimal(12, 3)")]
		public decimal? CosteHora { get; set; }

		[InverseProperty(nameof(Models.GMAO_Departamentos.IdResponsableNavigation))]
		public virtual ICollection<GMAO_Departamentos> GMAO_Departamentos { get; set; } = new HashSet<GMAO_Departamentos>();

		[InverseProperty(nameof(Models.GMAO_Deps_Operarios.idOperarioNavigation))]
		public virtual ICollection<GMAO_Deps_Operarios> GMAO_Deps_Operarios { get; set; } = new HashSet<GMAO_Deps_Operarios>();

		[InverseProperty(nameof(Models.GMAO_ElemIntervenciones.IdOperarioResponsableNavigation))]
		public virtual ICollection<GMAO_ElemIntervenciones> GMAO_ElemIntervenciones { get; set; } = new HashSet<GMAO_ElemIntervenciones>();

		[InverseProperty(nameof(Models.GMAO_ElemIntervencionesTrabajos.IdOperarioNavigation))]
		public virtual ICollection<GMAO_ElemIntervencionesTrabajos> GMAO_ElemIntervencionesTrabajos { get; set; } = new HashSet<GMAO_ElemIntervencionesTrabajos>();

		[InverseProperty(nameof(Models.GMAO_ParadasConfiguracionTareas.idOperarioNavigation))]
		public virtual ICollection<GMAO_ParadasConfiguracionTareas> GMAO_ParadasConfiguracionTareas { get; set; } = new HashSet<GMAO_ParadasConfiguracionTareas>();

	}

}
