using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_ElementReviewTask
	{

		[Key]
		public Guid Id { get; set; }

		public int ElementId { get; set; }

		public int TaskId { get; set; }

		public GmaoElementReviewTriggerType TriggerType { get; set; }

		[StringLength(256)]
		public string Comments { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime UpdatedDate { get; set; }

		public DateTime ResetDate { get; set; }

		public bool IsEnabled { get; set; }

		public int Threshold { get; set; }

		public int Counter { get; set; }

		[ForeignKey(nameof(ElementId))]
		[InverseProperty(nameof(GMAO_Elementos.GMAO_ElementReviewTasks))]
		public virtual GMAO_Elementos Element { get; set; }

		[ForeignKey(nameof(TaskId))]
		[InverseProperty(nameof(GMAO_ParadasConfiguracion.GMAO_ElementReviewTasks))]
		public virtual GMAO_ParadasConfiguracion Task { get; set; }

		[InverseProperty(nameof(GMAO_ElemIntervencionesTrabajos.GMAO_ElementReviewTask))]
		public virtual ICollection<GMAO_ElemIntervencionesTrabajos> WorkOrderTasks { get; set; } = new HashSet<GMAO_ElemIntervencionesTrabajos>();

	}

}
