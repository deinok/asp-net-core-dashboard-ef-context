using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Entradas
	{

		[Key]
		public int id { get; set; }

		public int Serie { get; set; }

		public int Numero { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaCreacion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaPrevista { get; set; }

		public int? idVehiculo { get; set; }

		public int? idChofer { get; set; }

		public int? idProveedor { get; set; }

		public int? idTarjeta { get; set; }

		public EntradaStatus? Estado { get; set; }

		public int? EstadoTransito { get; set; }

		[StringLength(15)]
		public string MatriculaCamion { get; set; }

		[StringLength(50)]
		public string NombreConductor { get; set; }

		[StringLength(500)]
		public string Observaciones { get; set; }

		public int? idEmpresaTransporte { get; set; }

		public int? LedControlDocumental { get; set; }

		[StringLength(15)]
		public string MatriculaRemolque { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Precio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FInicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FFin { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[StringLength(20)]
		public string ReferenciaCompra { get; set; }

		public bool? PreDesinfeccion { get; set; }

		public bool? PostDesinfeccion { get; set; }

		public bool? PreDesinfeccionOK { get; set; }

		public bool? PostDesinfeccionOK { get; set; }

		[Column("exportado")]
		public bool Exportado { get; set; }

		public bool Importado { get; set; }

		[StringLength(50)]
		public string DUA { get; set; }

		[StringLength(20)]
		public string Factura { get; set; }

		[StringLength(20)]
		public string Albaran { get; set; }

		public int? CoeficienteRendimiento { get; set; }

		[StringLength(100)]
		public string AceptacionDestinoFinal { get; set; }

		[ForeignKey(nameof(Serie))]
		[InverseProperty(nameof(Series.Entradas))]
		public virtual Series SerieNavigation { get; set; }

		[ForeignKey(nameof(idChofer))]
		[InverseProperty(nameof(Choferes.Entradas))]
		public virtual Choferes idChoferNavigation { get; set; }

		[ForeignKey(nameof(idEmpresaTransporte))]
		[InverseProperty(nameof(EmpresasTransporte.Entradas))]
		public virtual EmpresasTransporte idEmpresaTransporteNavigation { get; set; }

		[ForeignKey(nameof(idProveedor))]
		[InverseProperty(nameof(Proveedores.Entradas))]
		public virtual Proveedores idProveedorNavigation { get; set; }

		[ForeignKey(nameof(idTarjeta))]
		[InverseProperty(nameof(Tarjetas.Entradas))]
		public virtual Tarjetas idTarjetaNavigation { get; set; }

		[ForeignKey(nameof(idVehiculo))]
		[InverseProperty(nameof(Vehiculos.Entradas))]
		public virtual Vehiculos idVehiculoNavigation { get; set; }

		[InverseProperty(nameof(Models.CabOrdenes.EntradaNavigation))]
		public virtual ICollection<CabOrdenes> CabOrdenes { get; set; } = new HashSet<CabOrdenes>();

		[InverseProperty(nameof(Models.EntradasLineas.idEntradasNavigation))]
		public virtual ICollection<EntradasLineas> EntradasLineas { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(Models.Ordenes.EntradaNavigation))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

	}

}
