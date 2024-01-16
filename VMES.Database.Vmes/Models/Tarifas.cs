using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Tarifas
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? Cliente { get; set; }

		public int? Producto { get; set; }

		public int? Medicacion { get; set; }

		public int? Envase { get; set; }

		public float? Precio { get; set; }

		public int? Unidad { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[ForeignKey(nameof(Cliente))]
		[InverseProperty(nameof(Clientes.Tarifas))]
		public virtual Clientes ClienteNavigation { get; set; }

		[ForeignKey(nameof(Envase))]
		[InverseProperty(nameof(Envases.Tarifas))]
		public virtual Envases EnvaseNavigation { get; set; }

		[ForeignKey(nameof(Medicacion))]
		[InverseProperty(nameof(Medicaciones.Tarifas))]
		public virtual Medicaciones MedicacionNavigation { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Productos.Tarifas))]
		public virtual Productos ProductoNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.Tarifas))]
		public virtual Unidades UnidadNavigation { get; set; }

	}

}
