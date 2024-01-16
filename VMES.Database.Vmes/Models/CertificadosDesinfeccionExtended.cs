using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class CertificadosDesinfeccionExtended
	{

		public int id { get; set; }

		public int? Serie { get; set; }

		public int? Numero { get; set; }

		[StringLength(50)]
		public string NRegistroCentro { get; set; }

		[StringLength(50)]
		public string Responsable { get; set; }

		[StringLength(10)]
		public string DNIResponsable { get; set; }

		[StringLength(50)]
		public string NombreCentro { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? fecha { get; set; }

		public int? VehiculoId { get; set; }

		[StringLength(10)]
		public string VehiculoMatricula { get; set; }

		[StringLength(10)]
		public string VehiculoRemolque { get; set; }

		[StringLength(20)]
		public string VehiculoReferencia { get; set; }

		public int? ChoferId { get; set; }

		[StringLength(50)]
		public string ChoferNombre { get; set; }

		[StringLength(50)]
		public string DesinfectanteNombre { get; set; }

		[StringLength(50)]
		public string Precinto { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaCertificado { get; set; }

		public int? idOrden { get; set; }

	}

}
