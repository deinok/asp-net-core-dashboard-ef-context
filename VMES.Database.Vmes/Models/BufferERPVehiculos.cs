using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPVehiculos
	{

		[Key]
		public int id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Timestamp { get; set; }

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

		[StringLength(10)]
		public string Matricula { get; set; }

		[StringLength(10)]
		public string Remolque { get; set; }

		public float? Tara { get; set; }

		public int? PesoMaximo { get; set; }

		[StringLength(50)]
		public string Chofer { get; set; }

		[StringLength(50)]
		public string EmpresaTransporte { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

	}

}
