using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class SolicitudAjusteCaudal
	{

		[Key]
		public int Id { get; set; }

		public int ProductoId { get; set; }

		public int UbicacionId { get; set; }

		public SolicitudAjusteCaudalType Type { get; set; }

		public SolicitudAjusteCaudalStatus Status { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal NuevoCaudalEntrada { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal NuevoCaudalSalida { get; set; }

		public DateTime Creacion { get; set; }

		public DateTime Modificacion { get; set; }

		public int? OrdenId { get; set; }

		public int? UsuarioId { get; set; }

		[ForeignKey($"{nameof(ProductoId)}, {nameof(UbicacionId)}")]
		[InverseProperty(nameof(Models.Caudal.SolicitudesAjusteCaudal))]
		public virtual Caudal Caudal { get; set; }

		[ForeignKey(nameof(OrdenId))]
		[InverseProperty(nameof(Ordenes.SolicitudesAjusteCaudal))]
		public virtual Ordenes Orden { get; set; }

		[ForeignKey(nameof(ProductoId))]
		[InverseProperty(nameof(Productos.SolicitudesAjusteCaudal))]
		public virtual Productos Producto { get; set; }

		[ForeignKey(nameof(UbicacionId))]
		[InverseProperty(nameof(Ubicaciones.SolicitudesAjusteCaudal))]
		public virtual Ubicaciones Ubicacion { get; set; }

		[ForeignKey(nameof(UsuarioId))]
		[InverseProperty(nameof(Usuarios.SolicitudesAjusteCaudal))]
		public virtual Usuarios Usuario { get; set; }

	}

}
