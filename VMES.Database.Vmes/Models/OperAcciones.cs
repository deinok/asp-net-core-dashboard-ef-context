using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class OperAcciones
	{

		[Key]
		public int Id { get; set; }

		public int? IdPlc { get; set; }

		[StringLength(250)]
		public string Nombre { get; set; }

		public bool? RequiereTiempo { get; set; }

		[InverseProperty(nameof(Models.Componentes.OperAccionNavigation))]
		public virtual ICollection<Componentes> Componentes { get; set; } = new HashSet<Componentes>();

		[InverseProperty(nameof(Models.Dosificaciones.IdOperAccionNavigation))]
		public virtual ICollection<Dosificaciones> Dosificaciones { get; set; } = new HashSet<Dosificaciones>();

		[InverseProperty(nameof(Models.OperMotores.idAccionMotorNavigation))]
		public virtual ICollection<OperMotores> OperMotores { get; set; } = new HashSet<OperMotores>();

		[InverseProperty(nameof(Models.OperPlantillas.IdOperAccionNavigation))]
		public virtual ICollection<OperPlantillas> OperPlantillas { get; set; } = new HashSet<OperPlantillas>();

	}

}
