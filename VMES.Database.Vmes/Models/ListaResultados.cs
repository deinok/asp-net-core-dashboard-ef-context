using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class ListaResultados
	{

		public int Id { get; set; }

		public int Serie { get; set; }

		public int Orden { get; set; }

		public int? Ciclo { get; set; }

		[StringLength(50)]
		public string Producto { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		[StringLength(20)]
		public string Referencia2 { get; set; }

		[StringLength(50)]
		public string Ubicacion { get; set; }

		public float? Cantidad { get; set; }

		public float? CantidadPrincipal { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Inicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fin { get; set; }

		[StringLength(30)]
		public string Lote { get; set; }

		public int? PosicionDosificacion { get; set; }

		[StringLength(50)]
		public string Medidor { get; set; }

		public int? ModuloOrdenacion { get; set; }

		[StringLength(50)]
		public string Modulo { get; set; }

		[StringLength(20)]
		public string Estado { get; set; }

	}

}
