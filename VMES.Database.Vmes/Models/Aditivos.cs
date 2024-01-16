using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Aditivos
	{

		[Key]
		public int Id { get; set; }

		public int Orden { get; set; }

		public int IdOld { get; set; }

		public int? Producto { get; set; }

		public float? Cantidad { get; set; }

		public int? Unidad { get; set; }

		public int? Ubicacion { get; set; }

		public int? Formato { get; set; }

		[StringLength(20)]
		public string Lote { get; set; }

		public float? Servida { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		public int Serie { get; set; }

		[ForeignKey(nameof(Formato))]
		[InverseProperty(nameof(Formatos.Aditivos))]
		public virtual Formatos FormatoNavigation { get; set; }

		[ForeignKey(nameof(Orden))]
		[InverseProperty(nameof(Ordenes.Aditivos))]
		public virtual Ordenes OrdenNavigation { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Productos.Aditivos))]
		public virtual Productos ProductoNavigation { get; set; }

		[ForeignKey(nameof(Ubicacion))]
		[InverseProperty(nameof(Ubicaciones.Aditivos))]
		public virtual Ubicaciones UbicacionNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.Aditivos))]
		public virtual Unidades UnidadNavigation { get; set; }

	}

}
