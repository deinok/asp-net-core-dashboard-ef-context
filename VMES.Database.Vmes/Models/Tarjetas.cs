using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Tarjetas
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string Valor { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? idOld { get; set; }

		public TarjetaStatus? Estado { get; set; }

		[Column("IdOrdenActual")]
		public int? OrdenActualId { get; set; }

		[Column("IdLinEntrada")]
		public int? EntradaLineaId { get; set; }

		[Column("IdLinSalida")]
		public int? SalidaLineaId { get; set; }

		public bool? PermisoArcosDesinfeccion { get; set; }

		public int? Ordenacion { get; set; }

		[StringLength(128)]
		public string Referencia { get; set; }

		[ForeignKey(nameof(EntradaLineaId))]
		[InverseProperty(nameof(EntradasLineas.Tarjetas))]
		public virtual EntradasLineas EntradaLinea { get; set; }

		[ForeignKey(nameof(SalidaLineaId))]
		[InverseProperty(nameof(SalidasLinias.Tarjetas))]
		public virtual SalidasLinias SalidaLinea { get; set; }

		[ForeignKey(nameof(OrdenActualId))]
		[InverseProperty(nameof(Models.Ordenes.Tarjetas))]
		public virtual Ordenes OrdenActual { get; set; }

		[InverseProperty(nameof(Models.Choferes.TarjetaNavigation))]
		public virtual ICollection<Choferes> Choferes { get; set; } = new HashSet<Choferes>();

		[InverseProperty(nameof(Models.Entradas.idTarjetaNavigation))]
		public virtual ICollection<Entradas> Entradas { get; set; } = new HashSet<Entradas>();

		[InverseProperty(nameof(Models.Ordenes.idTarjetaNavigation))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

		[InverseProperty(nameof(Models.SalidasViajes.idTarjetaNavigation))]
		public virtual ICollection<SalidasViajes> SalidasViajes { get; set; } = new HashSet<SalidasViajes>();

		[InverseProperty(nameof(Models.Vehiculos.TarjetaNavigation))]
		public virtual ICollection<Vehiculos> Vehiculos { get; set; } = new HashSet<Vehiculos>();

	}

}
