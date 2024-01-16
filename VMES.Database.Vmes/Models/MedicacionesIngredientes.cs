using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class MedicacionesIngredientes
	{

		[Key]
		public int Medicacion { get; set; }

		[Key]
		public int Producto { get; set; }

		public float Cantidad { get; set; }

		public int Unidad { get; set; }

		[Obsolete("Use unit type")]
		public float Porcentaje { get; set; }

		public bool Importado { get; set; }

		public bool Exportado { get; set; }

		public bool AplicacionDirecta { get; set; }

		public bool Produccion { get; set; }

		[ForeignKey(nameof(Medicacion))]
		[InverseProperty(nameof(Medicaciones.MedicacionesIngredientes))]
		public virtual Medicaciones MedicacionNavigation { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Productos.MedicacionesIngredientes))]
		public virtual Productos ProductoNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.MedicacionesIngredientes))]
		public virtual Unidades UnidadNavigation { get; set; }

	}

}
