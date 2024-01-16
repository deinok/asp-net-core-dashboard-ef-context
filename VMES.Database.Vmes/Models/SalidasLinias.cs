using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class SalidasLinias
	{

		[Key]
		public int id { get; set; }

		public int? idSalidas { get; set; }

		public int? idProducto { get; set; }

		public int? MedicacionId { get; set; }

		public int? idFormato { get; set; }

		public int? idEnvase { get; set; }

		public int? idUnidad { get; set; }

		public int? idDomicilio { get; set; }

		public int? Origen1 { get; set; }

		public int? Origen2 { get; set; }

		public int? Origen3 { get; set; }

		public int? Origen4 { get; set; }

		public bool? FueraCajon { get; set; }

		public bool? Cajon1 { get; set; }

		public bool? Cajon2 { get; set; }

		public bool? Cajon3 { get; set; }

		public bool? Cajon4 { get; set; }

		public bool? Cajon5 { get; set; }

		public bool? Cajon6 { get; set; }

		public bool? Cajon7 { get; set; }

		public bool? Cajon8 { get; set; }

		public bool? Cajon9 { get; set; }

		public bool? Cajon10 { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFinCarga { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicioCarga { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Bultos { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Bruto { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Tara { get; set; }

		public SalidaLineaStatus? Estado { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioUnidad { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? Cantidad { get; set; }

		public int? LedControlDocumental { get; set; }

		public int? LedAnalisisLaboratorio { get; set; }

		public int? LedAutorizacion { get; set; }

		public int? LedCargaProducto { get; set; }

		public int? LedDevolucionTarjeta { get; set; }

		public int? idviajes { get; set; }

		public int? idorden { get; set; }

		public bool? TransitoActivo { get; set; }

		public int? idmodulo { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? Precio { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioTransporte { get; set; }

		public int? EstadoTarjeta { get; set; }

		[StringLength(250)]
		public string Observaciones { get; set; }

		public bool? Autorizada { get; set; }

		public int? idBasculaPesajeBruto { get; set; }

		public int? idBasculaPesajeNeto { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? PesoNetoManual { get; set; }

		[StringLength(50)]
		public string CampoLibre1 { get; set; }

		[StringLength(50)]
		public string CampoLibre2 { get; set; }

		public int? LedViajeAsignado { get; set; }

		public int? idPuntoDescarga { get; set; }

		public bool Exportado { get; set; }

		public bool Importado { get; set; }

		[StringLength(1000)]
		public string ErrorExportacion { get; set; }

		public int? idAlbaran { get; set; }

		public int? TipoOrigen { get; set; }

		public bool? CamionBanera { get; set; }

		public bool? VaciarSilos { get; set; }

		[StringLength(20)]
		public string RefPedidoERP { get; set; }

		[ForeignKey(nameof(Origen1))]
		[InverseProperty(nameof(Ubicaciones.SalidasLiniasOrigen1Navigation))]
		public virtual Ubicaciones Origen1Navigation { get; set; }

		[ForeignKey(nameof(Origen2))]
		[InverseProperty(nameof(Ubicaciones.SalidasLiniasOrigen2Navigation))]
		public virtual Ubicaciones Origen2Navigation { get; set; }

		[ForeignKey(nameof(Origen3))]
		[InverseProperty(nameof(Ubicaciones.SalidasLiniasOrigen3Navigation))]
		public virtual Ubicaciones Origen3Navigation { get; set; }

		[ForeignKey(nameof(Origen4))]
		[InverseProperty(nameof(Ubicaciones.SalidasLiniasOrigen4Navigation))]
		public virtual Ubicaciones Origen4Navigation { get; set; }

		[ForeignKey(nameof(idAlbaran))]
		[InverseProperty(nameof(SalidasAlbaranes.SalidasLinias))]
		public virtual SalidasAlbaranes idAlbaranNavigation { get; set; }

		[ForeignKey(nameof(idBasculaPesajeBruto))]
		[InverseProperty(nameof(Bascula.SalidasLiniasidBasculaPesajeBrutoNavigation))]
		public virtual Bascula idBasculaPesajeBrutoNavigation { get; set; }

		[ForeignKey(nameof(idBasculaPesajeNeto))]
		[InverseProperty(nameof(Bascula.SalidasLiniasidBasculaPesajeNetoNavigation))]
		public virtual Bascula idBasculaPesajeNetoNavigation { get; set; }

		[ForeignKey(nameof(idDomicilio))]
		[InverseProperty(nameof(Domicilios.SalidasLinias))]
		public virtual Domicilios idDomicilioNavigation { get; set; }

		[ForeignKey(nameof(idEnvase))]
		[InverseProperty(nameof(Envases.SalidasLinias))]
		public virtual Envases idEnvaseNavigation { get; set; }

		[ForeignKey(nameof(idFormato))]
		[InverseProperty(nameof(Formatos.SalidasLinias))]
		public virtual Formatos idFormatoNavigation { get; set; }

		[ForeignKey(nameof(idProducto))]
		[InverseProperty(nameof(Productos.SalidasLinias))]
		public virtual Productos idProductoNavigation { get; set; }

		[ForeignKey(nameof(idPuntoDescarga))]
		[InverseProperty(nameof(PuntosDescarga.SalidasLinias))]
		public virtual PuntosDescarga idPuntoDescargaNavigation { get; set; }

		[ForeignKey(nameof(idSalidas))]
		[InverseProperty(nameof(Salidas.SalidasLinias))]
		public virtual Salidas idSalidasNavigation { get; set; }

		[ForeignKey(nameof(idUnidad))]
		[InverseProperty(nameof(Unidades.SalidasLinias))]
		public virtual Unidades idUnidadNavigation { get; set; }

		[ForeignKey(nameof(idmodulo))]
		[InverseProperty(nameof(Modulos.SalidasLinias))]
		public virtual Modulos idmoduloNavigation { get; set; }

		[ForeignKey(nameof(idviajes))]
		[InverseProperty(nameof(SalidasViajes.SalidasLinias))]
		public virtual SalidasViajes idviajesNavigation { get; set; }

		[ForeignKey(nameof(MedicacionId))]
		[InverseProperty(nameof(Medicaciones.SalidasLinias))]
		public virtual Medicaciones MedicacionNavigation { get; set; }

		[InverseProperty("idLineaSalidaNavigation")]
		public virtual ICollection<LineaVentaLineaSalida> LineaVentaLineaSalida { get; set; } = new HashSet<LineaVentaLineaSalida>();

		[InverseProperty("LineaSalidaNavigation")]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

		[InverseProperty("idSalidaLineaNavigation")]
		public virtual ICollection<Recetas> Recetas { get; set; } = new HashSet<Recetas>();

		[InverseProperty("idLineaSalidaNavigation")]
		public virtual ICollection<SalidasLiniasLote> SalidasLiniasLote { get; set; } = new HashSet<SalidasLiniasLote>();

		[InverseProperty("idSalidaLiniaNavigation")]
		public virtual ICollection<SalidasLiniasMedicaciones> SalidasLiniasMedicaciones { get; set; } = new HashSet<SalidasLiniasMedicaciones>();

		[InverseProperty("idSalidasLineasNavigation")]
		public virtual ICollection<SalidasLiniasMuestras> SalidasLiniasMuestras { get; set; } = new HashSet<SalidasLiniasMuestras>();

		[InverseProperty("idLineaSalidaNavigation")]
		public virtual ICollection<SalidasLiniasPuntosDescarga> SalidasLiniasPuntosDescarga { get; set; } = new HashSet<SalidasLiniasPuntosDescarga>();

		[InverseProperty("idSalidasLineasNavigation")]
		public virtual ICollection<Stocks> Stocks { get; set; } = new HashSet<Stocks>();

		[InverseProperty("idSalidasLineasNavigation")]
		public virtual ICollection<StocksReserva> StocksReserva { get; set; } = new HashSet<StocksReserva>();

		[InverseProperty("IdLinSalidaNavigation")]
		public virtual ICollection<Tarjetas> Tarjetas { get; set; } = new HashSet<Tarjetas>();

	}

}
