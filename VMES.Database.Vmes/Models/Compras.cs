using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Compras
	{

		public int? Serie { get; set; }

		[Key]
		public int Id { get; set; }

		public int? Proveedor { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public CompraStatus? Estado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? UltimaFecha { get; set; }

		public bool Importado { get; set; }

		public int? Departamento { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Entrega { get; set; }

		[StringLength(100)]
		public string Comentario { get; set; }

		public bool? Impresa { get; set; }

		public bool? Refrescado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fin { get; set; }

		public bool Exportado { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		public int? Numero { get; set; }

		public int? idContrato { get; set; }

		[StringLength(20)]
		public string ReferenciaContrato { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal? PrecioTransporte { get; set; }

		[ForeignKey(nameof(Departamento))]
		[InverseProperty(nameof(Departamentos.Compras))]
		public virtual Departamentos DepartamentoNavigation { get; set; }

		[ForeignKey(nameof(Proveedor))]
		[InverseProperty(nameof(Proveedores.Compras))]
		public virtual Proveedores ProveedorNavigation { get; set; }

		[ForeignKey(nameof(Serie))]
		[InverseProperty(nameof(Series.Compras))]
		public virtual Series SerieNavigation { get; set; }

		[ForeignKey(nameof(idContrato))]
		[InverseProperty(nameof(Contratos.Compras))]
		public virtual Contratos idContratoNavigation { get; set; }

		[InverseProperty(nameof(Models.LineasCompra.CompraNavigation))]
		public virtual ICollection<LineasCompra> LineasCompra { get; set; } = new HashSet<LineasCompra>();

	}

}
