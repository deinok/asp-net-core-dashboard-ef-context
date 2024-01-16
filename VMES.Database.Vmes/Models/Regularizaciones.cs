using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Regularizaciones
	{

		public int? Serie { get; set; }

		[Key]
		public int Id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? Ubicacion { get; set; }

		public int? Producto { get; set; }

		public int? Formato { get; set; }

		public int? Envase { get; set; }

		[Obsolete]
		[StringLength(20)]
		public string LoteNombre { get; set; }

		public float? Cantidad { get; set; }

		public int? Unidad { get; set; }

		public int? Tipo { get; set; }

		[StringLength(250)]
		public string Observaciones { get; set; }

		public int? Estado { get; set; }

		public int? Usuario { get; set; }

		public int? Lote { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[ForeignKey(nameof(Envase))]
		[InverseProperty(nameof(Envases.Regularizaciones))]
		public virtual Envases EnvaseNavigation { get; set; }

		[ForeignKey(nameof(Formato))]
		[InverseProperty(nameof(Formatos.Regularizaciones))]
		public virtual Formatos FormatoNavigation { get; set; }

		[ForeignKey(nameof(Lote))]
		[InverseProperty(nameof(Lotes.Regularizaciones))]
		public virtual Lotes LoteNavigation { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Productos.Regularizaciones))]
		public virtual Productos ProductoNavigation { get; set; }

		[ForeignKey(nameof(Serie))]
		[InverseProperty(nameof(Series.Regularizaciones))]
		public virtual Series SerieNavigation { get; set; }

		[ForeignKey(nameof(Ubicacion))]
		[InverseProperty(nameof(Ubicaciones.Regularizaciones))]
		public virtual Ubicaciones UbicacionNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.Regularizaciones))]
		public virtual Unidades UnidadNavigation { get; set; }

		[ForeignKey(nameof(Usuario))]
		[InverseProperty(nameof(Usuarios.Regularizaciones))]
		public virtual Usuarios UsuarioNavigation { get; set; }

	}

}
