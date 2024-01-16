using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_ParadasConfiguracion
	{

		[Key]
		public int id { get; set; }

		[Required]
		[StringLength(64)]
		public string Nombre { get; set; }

		[StringLength(1024)]
		public string Descripcion { get; set; }

		[StringLength(1024)]
		public string Observaciones { get; set; }

		public TimeSpan HoraInicio { get; set; }

		public long? DayOfMonth { get; set; }

		public byte? DayOfWeek { get; set; }

		public int? Month { get; set; }

		public byte Scheduling { get; set; }

		public int? WeeklyRepeat { get; set; }

		[InverseProperty(nameof(Models.GMAO_ElemIntervenciones.IdParadaConfiguracionNavigation))]
		public virtual ICollection<GMAO_ElemIntervenciones> GMAO_ElemIntervenciones { get; set; } = new HashSet<GMAO_ElemIntervenciones>();

		[InverseProperty(nameof(Models.GMAO_ElementReviewTask.Task))]
		public virtual ICollection<GMAO_ElementReviewTask> GMAO_ElementReviewTasks { get; set; } = new HashSet<GMAO_ElementReviewTask>();

		[InverseProperty(nameof(Models.GMAO_ParadasConfiguracionModulos.idParadaConfiguracionNavigation))]
		public virtual ICollection<GMAO_ParadasConfiguracionModulos> GMAO_ParadasConfiguracionModulos { get; set; } = new HashSet<GMAO_ParadasConfiguracionModulos>();

		[InverseProperty(nameof(Models.GMAO_ParadasConfiguracionTareas.idParadaConfiguracionNavigation))]
		public virtual ICollection<GMAO_ParadasConfiguracionTareas> GMAO_ParadasConfiguracionTareas { get; set; } = new HashSet<GMAO_ParadasConfiguracionTareas>();

	}

}
