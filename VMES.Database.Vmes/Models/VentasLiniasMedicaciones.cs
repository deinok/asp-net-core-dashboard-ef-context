using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class VentasLiniasMedicaciones
	{

		[Key]
		public int id { get; set; }

		public int idVentaLinia { get; set; }

		public int? idEnvase { get; set; }

		public int? idFormato { get; set; }

		public int idUnidad { get; set; }

		public DateTime? Fecha { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal Cantidad { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal? Bultos { get; set; }

		public int? Estado { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal? Precio { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal? PrecioUnidad { get; set; }

		public int ProductoId { get; set; }

		[ForeignKey(nameof(idEnvase))]
		[InverseProperty(nameof(Envases.VentasLiniasMedicaciones))]
		public virtual Envases idEnvaseNavigation { get; set; }

		[ForeignKey(nameof(idFormato))]
		[InverseProperty(nameof(Formatos.VentasLiniasMedicaciones))]
		public virtual Formatos idFormatoNavigation { get; set; }

		[ForeignKey(nameof(ProductoId))]
		[InverseProperty(nameof(Productos.VentasLiniasMedicaciones))]
		public virtual Productos ProductoNavigation { get; set; }

		[ForeignKey(nameof(idUnidad))]
		[InverseProperty(nameof(Unidades.VentasLiniasMedicaciones))]
		public virtual Unidades idUnidadNavigation { get; set; }

		[ForeignKey(nameof(idVentaLinia))]
		[InverseProperty(nameof(VentasLinias.VentasLiniasMedicaciones))]
		public virtual VentasLinias idVentaLiniaNavigation { get; set; }

	}

}
