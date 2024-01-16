using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class ListaDosificaciones
	{

		public int Id { get; set; }

		public int Orden { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[Column(TypeName = "decimal(32, 19)")]
		public decimal? Porcentaje { get; set; }

		[Column(TypeName = "decimal(28, 15)")]
		public decimal? Cantidad { get; set; }

		[StringLength(50)]
		public string Unidad { get; set; }

		[StringLength(30)]
		public string Lote { get; set; }

		[StringLength(50)]
		public string Modulo { get; set; }

		public int? ModuloOrdenacion { get; set; }

		[StringLength(50)]
		public string Medidor { get; set; }

		public int? PosicionDosificacion { get; set; }

		[StringLength(50)]
		public string OrigenPrincipal { get; set; }

		public string Origenes { get; set; }

	}

}
