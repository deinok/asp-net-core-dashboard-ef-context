using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Pistolas
	{

		[Key]
		public int Id { get; set; }

		public int? IdMedidor { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string NombrePuerto { get; set; }

		public int? Velocidad { get; set; }

		public int? BitsDatos { get; set; }

		[Column(TypeName = "numeric(2, 1)")]
		public decimal? BitsParada { get; set; }

		public int? Paridad { get; set; }

		public int? HandShake { get; set; }

		public bool? DTR { get; set; }

		public bool? RTS { get; set; }

		[StringLength(50)]
		public string Tipo { get; set; }

		[StringLength(15)]
		public string IP { get; set; }

		public int? Puerto { get; set; }

		public bool? ModoEntradasAlmacen { get; set; }

		public bool? ModoSalidasAlmacen { get; set; }

		public bool? ModoPicking { get; set; }

		[ForeignKey(nameof(IdMedidor))]
		[InverseProperty(nameof(Medidor.Pistolas))]
		public virtual Medidor IdMedidorNavigation { get; set; }

	}

}
