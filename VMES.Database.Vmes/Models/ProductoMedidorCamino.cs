using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class ProductoMedidorCamino
	{

		[Key]
		public int Id { get; set; }

		public int CaminoId { get; set; }

		public int MedidorId { get; set; }

		public int ProductoId { get; set; }

		public bool Activo { get; set; }

		[Column("Tipo")]
		public ProductoMedidorCaminoType Type { get; set; }

		public DateTime FechaCreacion { get; set; }

		public DateTime FechaEdicion { get; set; }

		[ForeignKey(nameof(CaminoId))]
		[InverseProperty(nameof(Models.Camino.ProductosMedidoresCaminos))]
		public virtual Camino Camino { get; set; }

		[ForeignKey(nameof(MedidorId))]
		[InverseProperty(nameof(Models.Medidor.ProductosMedidoresCaminos))]
		public virtual Medidor Medidor { get; set; }

		[ForeignKey(nameof(ProductoId))]
		[InverseProperty(nameof(Models.Productos.ProductosMedidoresCaminos))]
		public virtual Productos Producto { get; set; }

	}

}
