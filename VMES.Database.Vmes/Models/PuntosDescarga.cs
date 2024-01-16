using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class PuntosDescarga
	{

		[Key]
		public int id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(250)]
		public string Descripcion { get; set; }

		public int? idDomicilio { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		public int? IntegraId { get; set; }

		public int? IntegraDomicilioId { get; set; }

		public bool Exportado { get; set; }

		public bool Importado { get; set; }

		[ForeignKey(nameof(idDomicilio))]
		[InverseProperty(nameof(Domicilios.PuntosDescarga))]
		public virtual Domicilios idDomicilioNavigation { get; set; }

		[InverseProperty(nameof(Models.SalidasLinias.idPuntoDescargaNavigation))]
		public virtual ICollection<SalidasLinias> SalidasLinias { get; set; } = new HashSet<SalidasLinias>();

		[InverseProperty(nameof(Models.SalidasLiniasPuntosDescarga.idPuntoDescargaNavigation))]
		public virtual ICollection<SalidasLiniasPuntosDescarga> SalidasLiniasPuntosDescarga { get; set; } = new HashSet<SalidasLiniasPuntosDescarga>();

		[InverseProperty(nameof(Models.VentasLinias.idPuntoDescargaNavigation))]
		public virtual ICollection<VentasLinias> VentasLinias { get; set; } = new HashSet<VentasLinias>();

		[InverseProperty(nameof(Models.VentasLiniasPuntosDescarga.idPuntoDescargaNavigation))]
		public virtual ICollection<VentasLiniasPuntosDescarga> VentasLiniasPuntosDescarga { get; set; } = new HashSet<VentasLiniasPuntosDescarga>();

	}

}
