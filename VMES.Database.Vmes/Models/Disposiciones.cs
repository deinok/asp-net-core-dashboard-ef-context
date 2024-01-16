using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Disposiciones
	{

		[Key]
		public int Id { get; set; }

		public int Serie { get; set; }

		public int? Orden { get; set; }

		public int IdOld { get; set; }

		public int? Producto { get; set; }

		public int? Lote { get; set; }

		public int? Ubicacion { get; set; }

		public float? Cantidad { get; set; }

		public float? Servida { get; set; }

		public int? Unidad { get; set; }

		public int? Tipo { get; set; }

		public float? CantidadPrincipal { get; set; }

		public int? TipoRegistro { get; set; }

		public bool? Finalizado { get; set; }

		public float? Porcentaje { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int? ordenacion { get; set; }

		public int? SerieOld { get; set; }

		public int? Formato { get; set; }

		[ForeignKey(nameof(Formato))]
		[InverseProperty(nameof(Formatos.Disposiciones))]
		public virtual Formatos FormatoNavigation { get; set; }

		[ForeignKey(nameof(Lote))]
		[InverseProperty(nameof(Lotes.Disposiciones))]
		public virtual Lotes LoteNavigation { get; set; }

		[ForeignKey(nameof(Orden))]
		[InverseProperty(nameof(Ordenes.Disposiciones))]
		public virtual Ordenes OrdenNavigation { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Productos.Disposiciones))]
		public virtual Productos ProductoNavigation { get; set; }

		[ForeignKey(nameof(Ubicacion))]
		[InverseProperty(nameof(Ubicaciones.Disposiciones))]
		public virtual Ubicaciones UbicacionNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.Disposiciones))]
		public virtual Unidades UnidadNavigation { get; set; }

	}

}
