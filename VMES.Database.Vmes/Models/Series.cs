using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Series
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int ContadorOrdenes { get; set; }

		public SerieStatus? Estado { get; set; }

		public bool Importado { get; set; }

		public bool Exportado { get; set; }

		public int ContadorCompras { get; set; }

		public int ContadorVentas { get; set; }

		public int ContadorViajes { get; set; }

		public int ContadorRecetas { get; set; }

		public int ContadorAlbaranes { get; set; }

		public int ContadorCertificadoDesinfeccion { get; set; }

		public int ContadorSalidas { get; set; }

		public int ContadorEntradas { get; set; }

		[InverseProperty(nameof(Models.CertificadoDesinfeccion.SerieNavigation))]
		public virtual ICollection<CertificadoDesinfeccion> CertificadoDesinfeccion { get; set; } = new HashSet<CertificadoDesinfeccion>();

		[InverseProperty(nameof(Models.Compras.SerieNavigation))]
		public virtual ICollection<Compras> Compras { get; set; } = new HashSet<Compras>();

		[InverseProperty(nameof(Models.Entradas.SerieNavigation))]
		public virtual ICollection<Entradas> Entradas { get; set; } = new HashSet<Entradas>();

		[InverseProperty(nameof(Models.Recetas.idSerieNavigation))]
		public virtual ICollection<Recetas> Recetas { get; set; } = new HashSet<Recetas>();

		[InverseProperty(nameof(Models.Regularizaciones.SerieNavigation))]
		public virtual ICollection<Regularizaciones> Regularizaciones { get; set; } = new HashSet<Regularizaciones>();

		[InverseProperty(nameof(Models.Salidas.idSerieNavigation))]
		public virtual ICollection<Salidas> Salidas { get; set; } = new HashSet<Salidas>();

		[InverseProperty(nameof(Models.SalidasAlbaranes.SerieNavigation))]
		public virtual ICollection<SalidasAlbaranes> SalidasAlbaranes { get; set; } = new HashSet<SalidasAlbaranes>();

		[InverseProperty(nameof(Models.SalidasViajes.idSerieNavigation))]
		public virtual ICollection<SalidasViajes> SalidasViajes { get; set; } = new HashSet<SalidasViajes>();

		[InverseProperty(nameof(Models.Ventas.idSerieNavigation))]
		public virtual ICollection<Ventas> Ventas { get; set; } = new HashSet<Ventas>();

	}

}
