using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class NetAlarmasRespuestas
	{

		[Key]
		public int id { get; set; }

		public NetAlarmasResponseType? IdPlc { get; set; }

		[StringLength(250)]
		public string Texto { get; set; }

		public bool? SeleccionUbicacion { get; set; }

		public bool? SeleccionProducto { get; set; }

		public bool? SeleccionLote { get; set; }

		public bool? SeleccUbicacionDestino { get; set; }

		public bool? SeleccArgumento0 { get; set; }

		public bool? SeleccArgumento1 { get; set; }

		public bool? SeleccArgumento2 { get; set; }

		public bool? SeleccArgumento3 { get; set; }

		public bool? SeleccVariables0 { get; set; }

		public bool? SeleccVariables1 { get; set; }

		public bool? SeleccVariables2 { get; set; }

		public bool? SeleccVariables3 { get; set; }

		public bool? SeleccVariables4 { get; set; }

		public bool? SeleccTextoAdicional { get; set; }

		[StringLength(250)]
		public string txtTextoAdicional { get; set; }

		[StringLength(250)]
		public string txtArgumento0 { get; set; }

		[StringLength(250)]
		public string txtArgumento1 { get; set; }

		[StringLength(250)]
		public string txtArgumento2 { get; set; }

		[StringLength(250)]
		public string txtArgumento3 { get; set; }

		[StringLength(250)]
		public string txtVariables0 { get; set; }

		[StringLength(250)]
		public string txtVariables1 { get; set; }

		[StringLength(250)]
		public string txtVariables2 { get; set; }

		[StringLength(250)]
		public string txtVariables3 { get; set; }

		[StringLength(250)]
		public string txtVariables4 { get; set; }

		public int? DecimalesArgumentos { get; set; }

		public bool? CopiarAdicional5AVar0 { get; set; }

		public bool? CopiarAdicional5AVar1 { get; set; }

		public bool? CopiarAdicional5AVar2 { get; set; }

		public bool? CopiarAdicional5AVar3 { get; set; }

		public bool? CopiarAdicional5AVar4 { get; set; }

		[InverseProperty(nameof(Models.NetAlarmas.RespuestaNavigation))]
		public virtual ICollection<NetAlarmas> NetAlarmas { get; set; } = new HashSet<NetAlarmas>();

		[InverseProperty(nameof(Models.NetAlarmasTiposRespuestas.idRespuestaNavigation))]
		public virtual ICollection<NetAlarmasTiposRespuestas> NetAlarmasTiposRespuestas { get; set; } = new HashSet<NetAlarmasTiposRespuestas>();

		[InverseProperty(nameof(Models.NetAlarmasTipoRespuestaOrigen.NetAlarmasRespuesta))]
		public virtual ICollection<NetAlarmasTipoRespuestaOrigen> NetAlarmasTiposRespuestasOrigenes { get; set; } = new HashSet<NetAlarmasTipoRespuestaOrigen>();

	}

}
