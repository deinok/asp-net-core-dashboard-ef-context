using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_ElemIntervenciones
	{

		[Key]
		public int id { get; set; }

		public int idElemento { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFinal { get; set; }

		public int? IdOperarioResponsable { get; set; }

		public int? IDDepartamento { get; set; }

		public string Referencia { get; set; }

		public string Observaciones { get; set; }

		public string Descripcion { get; set; }

		public int? IdParadaConfiguracion { get; set; }

		public bool? IsRevisionElemento { get; set; }

		public bool? Cerrada { get; set; }

		[ForeignKey(nameof(IDDepartamento))]
		[InverseProperty(nameof(GMAO_Departamentos.GMAO_ElemIntervenciones))]
		public virtual GMAO_Departamentos IDDepartamentoNavigation { get; set; }

		[ForeignKey(nameof(IdOperarioResponsable))]
		[InverseProperty(nameof(GMAO_Operarios.GMAO_ElemIntervenciones))]
		public virtual GMAO_Operarios IdOperarioResponsableNavigation { get; set; }

		[ForeignKey(nameof(IdParadaConfiguracion))]
		[InverseProperty(nameof(GMAO_ParadasConfiguracion.GMAO_ElemIntervenciones))]
		public virtual GMAO_ParadasConfiguracion IdParadaConfiguracionNavigation { get; set; }

		[ForeignKey(nameof(idElemento))]
		[InverseProperty(nameof(GMAO_Elementos.GMAO_ElemIntervenciones))]
		public virtual GMAO_Elementos idElementoNavigation { get; set; }

		[InverseProperty(nameof(Models.GMAO_Archivos_Intervenciones.idIntervencionNavigation))]
		public virtual ICollection<GMAO_Archivos_Intervenciones> GMAO_Archivos_Intervenciones { get; set; } = new HashSet<GMAO_Archivos_Intervenciones>();

		[InverseProperty(nameof(Models.GMAO_ElemIntervencionesPiezas.IdIntervencionNavigation))]
		public virtual ICollection<GMAO_ElemIntervencionesPiezas> GMAO_ElemIntervencionesPiezas { get; set; } = new HashSet<GMAO_ElemIntervencionesPiezas>();

		[InverseProperty(nameof(Models.GMAO_ElemIntervencionesTrabajos.IdIntervencionNavigation))]
		public virtual ICollection<GMAO_ElemIntervencionesTrabajos> GMAO_ElemIntervencionesTrabajos { get; set; } = new HashSet<GMAO_ElemIntervencionesTrabajos>();

	}

}
