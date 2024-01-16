using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Camino
	{

		[Key]
		public int Id { get; set; }

		public int MedidorId { get; set; }

		public int IdPlc { get; set; }

		[Required]
		[StringLength(64)]
		public string Nombre { get; set; }

		[Column("Tipo")]
		public CaminoType Type { get; set; }

		public bool Defecto { get; set; }

		[ForeignKey(nameof(MedidorId))]
		[InverseProperty(nameof(Models.Medidor.Caminos))]
		public virtual Medidor Medidor { get; set; }

		[InverseProperty(nameof(ProductoMedidorCamino.Camino))]
		public virtual ICollection<ProductoMedidorCamino> ProductosMedidoresCaminos { get; set; } = new HashSet<ProductoMedidorCamino>();

	}

}
