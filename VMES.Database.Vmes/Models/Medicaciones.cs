using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Medicaciones
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public DateTime? Fecha { get; set; }

		public int? Frecuencia { get; set; }

		public int? Duracion { get; set; }

		public int? TiempoEspera { get; set; }

		public int? Conservacion { get; set; }

		public int? Total { get; set; }

		public int? Afeccion { get; set; }

		public int? Estado { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[StringLength(254)]
		public string Observaciones { get; set; }

		[StringLength(254)]
		public string Indicaciones { get; set; }

		[StringLength(254)]
		public string NaturalezaTratamiento { get; set; }

		[StringLength(50)]
		public string Literal { get; set; }

		public int? TiempoEsperaLeche { get; set; }

		public int? TiempoEsperaHuevos { get; set; }

		public bool? StockIngredientes { get; set; }

		[StringLength(120)]
		public string Edad { get; set; }

		[ForeignKey(nameof(Afeccion))]
		[InverseProperty(nameof(Afecciones.Medicaciones))]
		public virtual Afecciones AfeccionNavigation { get; set; }

		[InverseProperty(nameof(Models.Formularios.MedicacionNavigation))]
		public virtual ICollection<Formularios> Formularios { get; set; } = new HashSet<Formularios>();

		[InverseProperty(nameof(Models.Lotes.MedicacionNavigation))]
		public virtual ICollection<Lotes> Lotes { get; set; } = new HashSet<Lotes>();

		[InverseProperty(nameof(Models.MedicacionesIngredientes.MedicacionNavigation))]
		public virtual ICollection<MedicacionesIngredientes> MedicacionesIngredientes { get; set; } = new HashSet<MedicacionesIngredientes>();

		[InverseProperty(nameof(Models.Ordenes.MedicacionNavigation))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

		[InverseProperty(nameof(Models.Recetas.MedicacionNavigation))]
		public virtual ICollection<Recetas> Recetas { get; set; } = new HashSet<Recetas>();

		[InverseProperty(nameof(Models.SalidasLinias.MedicacionNavigation))]
		public virtual ICollection<SalidasLinias> SalidasLinias { get; set; } = new HashSet<SalidasLinias>();

		[InverseProperty(nameof(Models.Tarifas.MedicacionNavigation))]
		public virtual ICollection<Tarifas> Tarifas { get; set; } = new HashSet<Tarifas>();

		[InverseProperty(nameof(Models.VentasLinias.idMedicamentoNavigation))]
		public virtual ICollection<VentasLinias> VentasLinias { get; set; } = new HashSet<VentasLinias>();

	}

}
