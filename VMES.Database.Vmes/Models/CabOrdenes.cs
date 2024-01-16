using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class CabOrdenes
	{

		[Key]
		public int id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaCreacion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFinal { get; set; }

		public int? Tipo { get; set; }

		public int? ProductoDestino { get; set; }

		public int? UbicacionDestino { get; set; }

		public int? LoteDestino { get; set; }

		public int? Prioridad { get; set; }

		public int? Formula { get; set; }

		public int? Modulo { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Cantidad { get; set; }

		public int? Version { get; set; }

		public int? idOld { get; set; }

		public int? SerieOld { get; set; }

		public int? Entrada { get; set; }

		public int? ViajeSalida { get; set; }

		[ForeignKey(nameof(Entrada))]
		[InverseProperty(nameof(Entradas.CabOrdenes))]
		public virtual Entradas EntradaNavigation { get; set; }

		[ForeignKey(nameof(Formula))]
		[InverseProperty(nameof(Formulas.CabOrdenes))]
		public virtual Formulas FormulaNavigation { get; set; }

		[ForeignKey(nameof(LoteDestino))]
		[InverseProperty(nameof(Lotes.CabOrdenes))]
		public virtual Lotes LoteDestinoNavigation { get; set; }

		[ForeignKey(nameof(Modulo))]
		[InverseProperty(nameof(Modulos.CabOrdenes))]
		public virtual Modulos ModuloNavigation { get; set; }

		[ForeignKey(nameof(ProductoDestino))]
		[InverseProperty(nameof(Productos.CabOrdenes))]
		public virtual Productos ProductoDestinoNavigation { get; set; }

		[ForeignKey(nameof(UbicacionDestino))]
		[InverseProperty(nameof(Ubicaciones.CabOrdenes))]
		public virtual Ubicaciones UbicacionDestinoNavigation { get; set; }

		[ForeignKey(nameof(Version))]
		[InverseProperty(nameof(Versiones.CabOrdenes))]
		public virtual Versiones VersionNavigation { get; set; }

		[ForeignKey(nameof(ViajeSalida))]
		[InverseProperty(nameof(SalidasViajes.CabOrdenes))]
		public virtual SalidasViajes ViajeSalidaNavigation { get; set; }

		[InverseProperty(nameof(Models.Ordenes.IdCabNavigation))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

	}

}
