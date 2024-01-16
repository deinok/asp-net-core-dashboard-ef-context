using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Existencias
	{

		[Key]
		public int Id { get; set; }

		public int Inventario { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? Ubicacion { get; set; }

		public int? Producto { get; set; }

		public int? Formato { get; set; }

		public int? Envase { get; set; }

		[StringLength(30)]
		public string LoteNombre { get; set; }

		public float? Cantidad { get; set; }

		public int? Unidad { get; set; }

		public int? Estado { get; set; }

		public int? Lote { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? idProveedor { get; set; }

		public int? idEntradaLinea { get; set; }

		[ForeignKey(nameof(Envase))]
		[InverseProperty(nameof(Envases.Existencias))]
		public virtual Envases EnvaseNavigation { get; set; }

		[ForeignKey(nameof(Formato))]
		[InverseProperty(nameof(Formatos.Existencias))]
		public virtual Formatos FormatoNavigation { get; set; }

		[ForeignKey(nameof(Inventario))]
		[InverseProperty(nameof(Inventarios.Existencias))]
		public virtual Inventarios InventarioNavigation { get; set; }

		[ForeignKey(nameof(Lote))]
		[InverseProperty(nameof(Lotes.Existencias))]
		public virtual Lotes LoteNavigation { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Productos.Existencias))]
		public virtual Productos ProductoNavigation { get; set; }

		[ForeignKey(nameof(Ubicacion))]
		[InverseProperty(nameof(Ubicaciones.Existencias))]
		public virtual Ubicaciones UbicacionNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.Existencias))]
		public virtual Unidades UnidadNavigation { get; set; }

		[ForeignKey(nameof(idEntradaLinea))]
		[InverseProperty(nameof(EntradasLineas.Existencias))]
		public virtual EntradasLineas idEntradaLineaNavigation { get; set; }

		[ForeignKey(nameof(idProveedor))]
		[InverseProperty(nameof(Proveedores.Existencias))]
		public virtual Proveedores idProveedorNavigation { get; set; }

	}

}
