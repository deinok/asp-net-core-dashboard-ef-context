using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Vehiculos
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(10)]
		public string Matricula { get; set; }

		[StringLength(10)]
		public string Remolque { get; set; }

		public float? Tara { get; set; }

		public int? Chofer { get; set; }

		public int? Tarjeta { get; set; }

		public bool? Importado { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		public bool? Refrescado { get; set; }

		public bool? Exportado { get; set; }

		public bool? Activo { get; set; }

		public int? Posicion { get; set; }

		public int? EmpresaTransporte { get; set; }

		public int? PesoMaximo { get; set; }

		public int? idOld { get; set; }

		[ForeignKey(nameof(Chofer))]
		[InverseProperty(nameof(Choferes.Vehiculos))]
		public virtual Choferes ChoferNavigation { get; set; }

		[ForeignKey(nameof(EmpresaTransporte))]
		[InverseProperty(nameof(EmpresasTransporte.Vehiculos))]
		public virtual EmpresasTransporte EmpresaTransporteNavigation { get; set; }

		[ForeignKey(nameof(Tarjeta))]
		[InverseProperty(nameof(Tarjetas.Vehiculos))]
		public virtual Tarjetas TarjetaNavigation { get; set; }

		[InverseProperty(nameof(Models.CertificadoDesinfeccion.idCamionNavigation))]
		public virtual ICollection<CertificadoDesinfeccion> CertificadoDesinfeccion { get; set; } = new HashSet<CertificadoDesinfeccion>();

		[InverseProperty(nameof(Models.Entradas.idVehiculoNavigation))]
		public virtual ICollection<Entradas> Entradas { get; set; } = new HashSet<Entradas>();

		[InverseProperty(nameof(Models.Ordenes.IdVehiculoNavigation))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

		[InverseProperty(nameof(Models.SalidasViajes.idVehiculoNavigation))]
		public virtual ICollection<SalidasViajes> SalidasViajes { get; set; } = new HashSet<SalidasViajes>();

	}

}
