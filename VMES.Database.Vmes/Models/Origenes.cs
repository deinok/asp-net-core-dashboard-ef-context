using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Origenes
	{

		[Key]
		public int ID { get; set; }

		public int Medidor { get; set; }

		public int? Ubicacion { get; set; }

		public int? Prioridad { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public bool? MultiDosificacion { get; set; }

		public bool? PorcentajeObligatorio { get; set; }

		public bool? VerVariable { get; set; }

		public bool? VerVariable2 { get; set; }

		[StringLength(250)]
		public string TextoVariable { get; set; }

		[StringLength(250)]
		public string TextoVariable2 { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? ValorDefecto { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? ValorDefecto2 { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? ValorMinimo { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? ValorMinimo2 { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? ValorMaximo { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? ValorMaximo2 { get; set; }

		public bool? PorcentajeAPLC { get; set; }

		public bool? ActivarMinimoDosificacion { get; set; }

		public bool? ActivarMaximoDosificacion { get; set; }

		[Column(TypeName = "decimal(15, 3)")]
		public decimal? MaximoDosificacion { get; set; }

		[Column(TypeName = "decimal(15, 3)")]
		public decimal? MinimoDosificacion { get; set; }

		public bool? Proponer { get; set; }

		public bool? Activo { get; set; }

		public int? PrioridadDosificacion { get; set; }

		public bool ProductoStockObligatorio { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal? Capacidad { get; set; }

		public bool SeleccionCargaAutomatica { get; set; }

		[ForeignKey(nameof(Medidor))]
		[InverseProperty(nameof(Models.Medidor.Origenes))]
		public virtual Medidor MedidorNavigation { get; set; }

		[ForeignKey(nameof(Ubicacion))]
		[InverseProperty(nameof(Ubicaciones.Origenes))]
		public virtual Ubicaciones UbicacionNavigation { get; set; }

		[InverseProperty(nameof(Models.MedidoresDosificaciones.idOrigenNavigation))]
		public virtual ICollection<MedidoresDosificaciones> MedidoresDosificaciones { get; set; } = new HashSet<MedidoresDosificaciones>();

		[InverseProperty(nameof(NetAlarmasTipoRespuestaOrigen.Origen))]
		public virtual ICollection<NetAlarmasTipoRespuestaOrigen> NetAlarmasTiposRespuestasOrigenes { get; set; } = new HashSet<NetAlarmasTipoRespuestaOrigen>();

	}

}
