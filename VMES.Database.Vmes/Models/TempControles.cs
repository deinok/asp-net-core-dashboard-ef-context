using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class TempControles
	{

		[Key]
		public int id { get; set; }

		public int? idPLC { get; set; }

		public int? ModoDefecto { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? MinAlarma_Min { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? MinAlarma_Max { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? MaxAlarma_Min { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? MaxAlarma_Max { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? Consigna_Min { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? Consigna_Max { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? Histeresys_Min { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? Histeresys_Max { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? ConsignaPausa_Min { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? ConsignaPausa_Max { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? ZonaMuerta_Min { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? ZonaMuerta_Max { get; set; }

		public bool? ModoCalentar { get; set; }

		public bool? ModoEnfriar { get; set; }

		public bool? ModoCalentarYEnfriar { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[InverseProperty(nameof(Models.Componentes.IdTempControlNavigation))]
		public virtual ICollection<Componentes> Componentes { get; set; } = new HashSet<Componentes>();

		[InverseProperty(nameof(Models.Dosificaciones.IdTempControlNavigation))]
		public virtual ICollection<Dosificaciones> Dosificaciones { get; set; } = new HashSet<Dosificaciones>();

		[InverseProperty(nameof(Models.OperPlantillas.IdTempControlNavigation))]
		public virtual ICollection<OperPlantillas> OperPlantillas { get; set; } = new HashSet<OperPlantillas>();

		[InverseProperty(nameof(Models.TempControlesMedidores.idTempControlNavigation))]
		public virtual ICollection<TempControlesMedidores> TempControlesMedidores { get; set; } = new HashSet<TempControlesMedidores>();

	}

}
