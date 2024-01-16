using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	public class Documentos
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		public int? TipoMovimiento { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

	}

}
