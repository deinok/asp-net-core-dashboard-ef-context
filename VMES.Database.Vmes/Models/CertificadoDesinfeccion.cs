using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class CertificadoDesinfeccion
	{

		[Key]
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

		public int? idCamion { get; set; }

		[StringLength(15)]
		public string Matricula { get; set; }

		[StringLength(15)]
		public string Remolque { get; set; }

		[StringLength(50)]
		public string Conductor { get; set; }

		[StringLength(50)]
		public string Desinfectante { get; set; }

		[StringLength(50)]
		public string Precinto { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaCertificado { get; set; }

		public int? idTransportista { get; set; }

		public int? idOrden { get; set; }

		[ForeignKey(nameof(Serie))]
		[InverseProperty(nameof(Series.CertificadoDesinfeccion))]
		public virtual Series SerieNavigation { get; set; }

		[ForeignKey(nameof(idCamion))]
		[InverseProperty(nameof(Vehiculos.CertificadoDesinfeccion))]
		public virtual Vehiculos idCamionNavigation { get; set; }

		[ForeignKey(nameof(idOrden))]
		[InverseProperty(nameof(Ordenes.CertificadoDesinfeccion))]
		public virtual Ordenes idOrdenNavigation { get; set; }

		[ForeignKey(nameof(idTransportista))]
		[InverseProperty(nameof(Choferes.CertificadoDesinfeccion))]
		public virtual Choferes idTransportistaNavigation { get; set; }

	}

}
