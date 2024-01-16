using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPProveedores
	{

		[Key]
		public int id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FImportado { get; set; }

		public bool? Preparado { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(14)]
		public string CIF { get; set; }

		[StringLength(50)]
		public string Direccion { get; set; }

		[StringLength(5)]
		public string CodigoPostal { get; set; }

		[StringLength(50)]
		public string Poblacion { get; set; }

		[StringLength(20)]
		public string Telefono { get; set; }

		[StringLength(50)]
		public string Provincia { get; set; }

		[StringLength(40)]
		public string Abreviado { get; set; }

		public bool? Importado { get; set; }

		[StringLength(50)]
		public string Pais { get; set; }

		public bool? Inhabilitado { get; set; }

		public int? Tipo { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

	}

}
