using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class SalidasViajes
	{

		[Key]
		public int id { get; set; }

		[StringLength(15)]
		public string MatriculaRemolque { get; set; }

		public int? idVehiculo { get; set; }

		public int? idChofer { get; set; }

		public int? idTarjeta { get; set; }

		public int? EstadoTransito { get; set; }

		[StringLength(15)]
		public string MatriculaCamion { get; set; }

		[StringLength(50)]
		public string NombreConductor { get; set; }

		[StringLength(500)]
		public string Observaciones { get; set; }

		public int? idEmpresaTransporte { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FInicioTransito { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FFinalTransito { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FInicioViaje { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FFinViaje { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaCreacion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaPrevista { get; set; }

		public int Numero { get; set; }

		public int idSerie { get; set; }

		public SalidaViajeStatus? Estado { get; set; }

		public bool? PreDesinfeccion { get; set; }

		public bool? PostDesinfeccion { get; set; }

		public bool Exportado { get; set; }

		public bool Importado { get; set; }

		[StringLength(1000)]
		public string ErrorExportacion { get; set; }

		[ForeignKey(nameof(idChofer))]
		[InverseProperty(nameof(Choferes.SalidasViajes))]
		public virtual Choferes idChoferNavigation { get; set; }

		[ForeignKey(nameof(idEmpresaTransporte))]
		[InverseProperty(nameof(EmpresasTransporte.SalidasViajes))]
		public virtual EmpresasTransporte idEmpresaTransporteNavigation { get; set; }

		[ForeignKey(nameof(idSerie))]
		[InverseProperty(nameof(Series.SalidasViajes))]
		public virtual Series idSerieNavigation { get; set; }

		[ForeignKey(nameof(idTarjeta))]
		[InverseProperty(nameof(Tarjetas.SalidasViajes))]
		public virtual Tarjetas idTarjetaNavigation { get; set; }

		[ForeignKey(nameof(idVehiculo))]
		[InverseProperty(nameof(Vehiculos.SalidasViajes))]
		public virtual Vehiculos idVehiculoNavigation { get; set; }

		[InverseProperty(nameof(Models.CabOrdenes.ViajeSalidaNavigation))]
		public virtual ICollection<CabOrdenes> CabOrdenes { get; set; } = new HashSet<CabOrdenes>();

		[InverseProperty(nameof(Models.Ordenes.ViajeSalidaNavigation))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

		[InverseProperty(nameof(Models.Salidas.idViajeNavigation))]
		public virtual ICollection<Salidas> Salidas { get; set; } = new HashSet<Salidas>();

		[InverseProperty(nameof(Models.SalidasLinias.idviajesNavigation))]
		public virtual ICollection<SalidasLinias> SalidasLinias { get; set; } = new HashSet<SalidasLinias>();

	}

}
