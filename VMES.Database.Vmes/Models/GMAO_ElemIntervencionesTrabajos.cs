using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_ElemIntervencionesTrabajos
	{

		[Key]
		public int id { get; set; }

		public int? idProveedor { get; set; }

		public int? IdOperario { get; set; }

		[StringLength(250)]
		public string Operarios { get; set; }

		[Column(TypeName = "decimal(12, 3)")]
		public decimal? CosteTraslado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFinal { get; set; }

		[Column(TypeName = "decimal(12, 3)")]
		public decimal? NHoras { get; set; }

		[Column(TypeName = "decimal(12, 3)")]
		public decimal? CosteHora { get; set; }

		[Column(TypeName = "decimal(12, 3)")]
		public decimal? CosteDietas { get; set; }

		public int? NumOperarios { get; set; }

		public int? IdIntervencion { get; set; }

		public bool? EnMantenimiento { get; set; }

		public int? IdMantenimiento { get; set; }

		public string Observaciones { get; set; }

		public string Descripcion { get; set; }

		public Guid? ReviewTaskId { get; set; }

		[ForeignKey(nameof(ReviewTaskId))]
		[InverseProperty(nameof(GMAO_ElementReviewTask.WorkOrderTasks))]
		public virtual GMAO_ElementReviewTask GMAO_ElementReviewTask { get; set; }

		[ForeignKey(nameof(IdIntervencion))]
		[InverseProperty(nameof(GMAO_ElemIntervenciones.GMAO_ElemIntervencionesTrabajos))]
		public virtual GMAO_ElemIntervenciones IdIntervencionNavigation { get; set; }

		[ForeignKey(nameof(IdOperario))]
		[InverseProperty(nameof(GMAO_Operarios.GMAO_ElemIntervencionesTrabajos))]
		public virtual GMAO_Operarios IdOperarioNavigation { get; set; }

	}

}
