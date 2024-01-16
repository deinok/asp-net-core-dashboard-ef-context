using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class OperMotores
	{

		[Key]
		public int Id { get; set; }

		public int? IdPlc { get; set; }

		[StringLength(250)]
		public string Nombre { get; set; }

		public int? Tipo { get; set; }

		public bool? ForzarMedidor { get; set; }

		public int? IdMedidor { get; set; }

		public bool? DescargaMezclador { get; set; }

		public bool? NoRepetido { get; set; }

		public bool? Cajon1 { get; set; }

		public bool? Cajon2 { get; set; }

		public bool? Cajon3 { get; set; }

		public bool? Cajon4 { get; set; }

		public bool? Cajon5 { get; set; }

		public bool? Cajon6 { get; set; }

		public bool? Cajon7 { get; set; }

		public bool? Cajon8 { get; set; }

		public bool? Cajon9 { get; set; }

		public bool? Cajon10 { get; set; }

		public bool? RaseraTunelCarga { get; set; }

		public int? idAccionMotor { get; set; }

		public int? idMedidorForzado { get; set; }

		public bool? DescargaSoloSiCamino { get; set; }

		public int? DescargaCaminoFiltro { get; set; }

		public bool? EsTiempoMezclaERP { get; set; }

		public int? OpcConfigId { get; set; }

		[ForeignKey(nameof(IdMedidor))]
		[InverseProperty(nameof(Medidor.OperMotoresIdMedidorNavigation))]
		public virtual Medidor IdMedidorNavigation { get; set; }

		[ForeignKey(nameof(OpcConfigId))]
		[InverseProperty(nameof(Models.OpcConfig.OperMotores))]
		public virtual OpcConfig OpcConfig { get; set; }

		[ForeignKey(nameof(idAccionMotor))]
		[InverseProperty(nameof(OperAcciones.OperMotores))]
		public virtual OperAcciones idAccionMotorNavigation { get; set; }

		[ForeignKey(nameof(idMedidorForzado))]
		[InverseProperty(nameof(Medidor.OperMotoresidMedidorForzadoNavigation))]
		public virtual Medidor idMedidorForzadoNavigation { get; set; }

		[InverseProperty(nameof(Models.Componentes.OperMotorNavigation))]
		public virtual ICollection<Componentes> Componentes { get; set; } = new HashSet<Componentes>();

		[InverseProperty(nameof(Models.Dosificaciones.IdOperMotorNavigation))]
		public virtual ICollection<Dosificaciones> Dosificaciones { get; set; } = new HashSet<Dosificaciones>();

		[InverseProperty(nameof(Models.OperMotoresModulos.IdOperMotorNavigation))]
		public virtual ICollection<OperMotoresModulos> OperMotoresModulos { get; set; } = new HashSet<OperMotoresModulos>();

		[InverseProperty(nameof(Models.OperPlantillas.IdOperMotorNavigation))]
		public virtual ICollection<OperPlantillas> OperPlantillas { get; set; } = new HashSet<OperPlantillas>();

	}

}
