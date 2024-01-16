using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Contratos
	{

		[Key]
		public int id { get; set; }

		public ContractType? Tipo { get; set; }

		public int? IdCliente { get; set; }

		public int? IdProveedor { get; set; }

		public int? IdDireccionCliente { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[Column(TypeName = "date")]
		public DateTime? FechaInicio { get; set; }

		[Column(TypeName = "date")]
		public DateTime? FechaFin { get; set; }

		public bool? Caduca { get; set; }

		public int? IdProducto { get; set; }

		[Column(TypeName = "decimal(18, 6)")]
		public decimal? CantidadAsignada { get; set; }

		[Column(TypeName = "decimal(18, 6)")]
		public decimal? Precio { get; set; }

		[Column(TypeName = "decimal(18, 6)")]
		public decimal? PrecioTransporte { get; set; }

		[Column(TypeName = "decimal(18, 6)")]
		public decimal? CantidadXPedido { get; set; }

		public int? DiasEntrePedidos { get; set; }

		public bool? Activo { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		public int? Unidad { get; set; }

		[StringLength(1024)]
		public string Observaciones { get; set; }

		[ForeignKey(nameof(IdCliente))]
		[InverseProperty(nameof(Clientes.Contratos))]
		public virtual Clientes IdClienteNavigation { get; set; }

		[ForeignKey(nameof(IdProducto))]
		[InverseProperty(nameof(Productos.Contratos))]
		public virtual Productos IdProductoNavigation { get; set; }

		[ForeignKey(nameof(IdProveedor))]
		[InverseProperty(nameof(Proveedores.Contratos))]
		public virtual Proveedores IdProveedorNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.Contratos))]
		public virtual Unidades UnidadNavigation { get; set; }

		[InverseProperty(nameof(Models.Compras.idContratoNavigation))]
		public virtual ICollection<Compras> Compras { get; set; } = new HashSet<Compras>();

		[InverseProperty(nameof(Models.EntradasContratos.idContratoNavigation))]
		public virtual ICollection<EntradasContratos> EntradasContratos { get; set; } = new HashSet<EntradasContratos>();

		[InverseProperty(nameof(Models.LineasCompra.IdContratoNavigation))]
		public virtual ICollection<LineasCompra> LineasCompra { get; set; } = new HashSet<LineasCompra>();

		[InverseProperty(nameof(Models.VentasLinias.idContratoNavigation))]
		public virtual ICollection<VentasLinias> VentasLinias { get; set; } = new HashSet<VentasLinias>();

	}

}
