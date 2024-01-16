using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Destinos
	{

		[Key]
		public int Id { get; set; }

		public int Modulo { get; set; }

		public int? Ubicacion { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public bool? TraspasoAutomatico { get; set; }

		public int? DestinoTraspasoAutomatico { get; set; }

		public bool? DestinoVolteo { get; set; }

		[Required]
		public bool? Activo { get; set; }

		public bool? ComprobarProducto { get; set; }

		[ForeignKey(nameof(Modulo))]
		[InverseProperty(nameof(Modulos.Destinos))]
		public virtual Modulos ModuloNavigation { get; set; }

		[ForeignKey(nameof(Ubicacion))]
		[InverseProperty(nameof(Ubicaciones.Destinos))]
		public virtual Ubicaciones UbicacionNavigation { get; set; }

		[InverseProperty(nameof(Models.DestinosMedidores.idDestinoNavigation))]
		public virtual ICollection<DestinosMedidores> DestinosMedidores { get; set; } = new HashSet<DestinosMedidores>();

	}

}
