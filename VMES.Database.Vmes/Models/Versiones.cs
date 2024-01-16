using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Versiones
	{

		[Key]
		public int Id { get; set; }

		public int Formula { get; set; }

		public int IdOld { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public VersionState? Estado { get; set; }

		public int? VersionOriginal { get; set; }

		public int? Unidad { get; set; }

		public float? Cantidad { get; set; }

		public bool? Refrescado { get; set; }

		public bool? Importado { get; set; }

		public bool? Recalculado { get; set; }

		public bool? Exportado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? UltimaModificacion { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? LimitePesoCiclo { get; set; }

		public bool? LimpiezaPosteriorObligada { get; set; }

		public int? Caminos { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFin { get; set; }

		[StringLength(20)]
		public string RefErp { get; set; }

		[StringLength(50)]
		public string comentarios { get; set; }

		[ForeignKey(nameof(Formula))]
		[InverseProperty(nameof(Formulas.Versiones))]
		public virtual Formulas FormulaNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.Versiones))]
		public virtual Unidades UnidadNavigation { get; set; }

		[InverseProperty(nameof(Models.CabOrdenes.VersionNavigation))]
		public virtual ICollection<CabOrdenes> CabOrdenes { get; set; } = new HashSet<CabOrdenes>();

		[InverseProperty(nameof(Models.Componentes.VersionNavigation))]
		public virtual ICollection<Componentes> Componentes { get; set; } = new HashSet<Componentes>();

		[InverseProperty(nameof(Models.Ordenes.VersionNavigation))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

		[InverseProperty(nameof(Models.VersionTPrevisto.idVersionNavigation))]
		public virtual ICollection<VersionTPrevisto> VersionTPrevisto { get; set; } = new HashSet<VersionTPrevisto>();

	}

}
