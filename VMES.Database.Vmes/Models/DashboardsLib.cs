using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class DashboardsLib
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string NombreDashboard { get; set; }

		public int? IdCategoria { get; set; }

		public bool IsBase { get; set; }

		public int? IdDashboardBase { get; set; }

		public bool Visible { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaUltima { get; set; }

		[StringLength(50)]
		public string UltimoEditor { get; set; }

		public byte[] DatosDashboard { get; set; }

		[StringLength(50)]
		public string Vista { get; set; }

		public byte[] VistaXML { get; set; }

		[StringLength(50)]
		public string ImpresoraDefecto { get; set; }

		public bool? ImpAutomatico { get; set; }

		public int? NumCopias { get; set; }

		public bool? VisibleUsuario { get; set; }

		[ForeignKey(nameof(IdCategoria))]
		[InverseProperty(nameof(DashboardsLibCategorias.DashboardsLib))]
		public virtual DashboardsLibCategorias IdCategoriaNavigation { get; set; }

		[ForeignKey(nameof(IdDashboardBase))]
		[InverseProperty(nameof(DashboardsLib.InverseIdDashboardBaseNavigation))]
		public virtual DashboardsLib IdDashboardBaseNavigation { get; set; }

		[InverseProperty(nameof(DashboardsLib.IdDashboardBaseNavigation))]
		public virtual ICollection<DashboardsLib> InverseIdDashboardBaseNavigation { get; set; } = new HashSet<DashboardsLib>();

	}

}
