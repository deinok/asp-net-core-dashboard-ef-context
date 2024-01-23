using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class EntradasLineas
	{

		[Key]
		public int id { get; set; }

		public int? idEntradas { get; set; }

		public int? idProducto { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? CantidadPedida { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicioRecepcion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFinRecepcion { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? PesoBruto { get; set; }

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

		public bool? TransitoActivo { get; set; }

		public int? idBasculaPesajeBruto { get; set; }

		public int? idBasculaPesajeNeto { get; set; }

		public bool? EntradaManualPesos { get; set; }

		public EntradaLineaStatus? Estado { get; set; }

		public bool? FueraCajon { get; set; }

		public int? idProveedor { get; set; }

		public int? LedControlDocumental { get; set; }

		public int? LedAnalisisLaboratorio { get; set; }

		public int? LedAutorizacion { get; set; }

		public int? LedCargaProducto { get; set; }

		public int? LedDevolucionTarjeta { get; set; }

		public int? Lote { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? Tara { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? PesoNetoManual { get; set; }

		public bool? RecogerPesoEnBascula { get; set; }

		public int? Unidad { get; set; }

		public int? Destino1 { get; set; }

		public int? Destino2 { get; set; }

		public int? Destino3 { get; set; }

		public int? Destino4 { get; set; }

		public int? Formato { get; set; }

		public int? Envase { get; set; }

		public int? Bultos { get; set; }

		[StringLength(250)]
		public string Observaciones { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Precio { get; set; }

		public bool? PagarKgTeoricos { get; set; }

		[StringLength(50)]
		public string CampoLibre1 { get; set; }

		[StringLength(50)]
		public string CampoLIbre2 { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? idModulo { get; set; }

		public bool? Autorizada { get; set; }

		[Column("exportado")]
		public bool Exportado { get; set; }

		public bool Importado { get; set; }

		[StringLength(200)]
		public string ErrorExport { get; set; }

		public bool? CamionBanera { get; set; }

		public int? EstadoTarjeta { get; set; }

		public int? TipoOrigen { get; set; }

		public int? Origen1 { get; set; }

		public int? Origen2 { get; set; }

		public int? Origen3 { get; set; }

		public int? Origen4 { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? NetoOrigen { get; set; }

		public int? NumLineaCompra { get; set; }

		public int? IdMuestra { get; set; }

		public bool? AnadirStockPesaje { get; set; }

		public int? idOrigenProv { get; set; }

		public bool? TaraAplicada { get; set; }

		[StringLength(32)]
		public string ReferenciaErp { get; set; }

		[ForeignKey(nameof(Destino1))]
		[InverseProperty(nameof(Ubicaciones.EntradasLineasDestino1Navigation))]
		public virtual Ubicaciones Destino1Navigation { get; set; }

		[ForeignKey(nameof(Destino2))]
		[InverseProperty(nameof(Ubicaciones.EntradasLineasDestino2Navigation))]
		public virtual Ubicaciones Destino2Navigation { get; set; }

		[ForeignKey(nameof(Destino3))]
		[InverseProperty(nameof(Ubicaciones.EntradasLineasDestino3Navigation))]
		public virtual Ubicaciones Destino3Navigation { get; set; }

		[ForeignKey(nameof(Destino4))]
		[InverseProperty(nameof(Ubicaciones.EntradasLineasDestino4Navigation))]
		public virtual Ubicaciones Destino4Navigation { get; set; }

		[ForeignKey(nameof(Envase))]
		[InverseProperty(nameof(Envases.EntradasLineas))]
		public virtual Envases EnvaseNavigation { get; set; }

		[ForeignKey(nameof(Formato))]
		[InverseProperty(nameof(Formatos.EntradasLineas))]
		public virtual Formatos FormatoNavigation { get; set; }

		[ForeignKey(nameof(Lote))]
		[InverseProperty(nameof(Lotes.EntradasLineas))]
		public virtual Lotes LoteNavigation { get; set; }

		[ForeignKey(nameof(Origen1))]
		[InverseProperty(nameof(Ubicaciones.EntradasLineasOrigen1Navigation))]
		public virtual Ubicaciones Origen1Navigation { get; set; }

		[ForeignKey(nameof(Origen2))]
		[InverseProperty(nameof(Ubicaciones.EntradasLineasOrigen2Navigation))]
		public virtual Ubicaciones Origen2Navigation { get; set; }

		[ForeignKey(nameof(Origen3))]
		[InverseProperty(nameof(Ubicaciones.EntradasLineasOrigen3Navigation))]
		public virtual Ubicaciones Origen3Navigation { get; set; }

		[ForeignKey(nameof(Origen4))]
		[InverseProperty(nameof(Ubicaciones.EntradasLineasOrigen4Navigation))]
		public virtual Ubicaciones Origen4Navigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.EntradasLineas))]
		public virtual Unidades UnidadNavigation { get; set; }

		[ForeignKey(nameof(idBasculaPesajeBruto))]
		[InverseProperty(nameof(Bascula.EntradasLineasidBasculaPesajeBrutoNavigation))]
		public virtual Bascula idBasculaPesajeBrutoNavigation { get; set; }

		[ForeignKey(nameof(idBasculaPesajeNeto))]
		[InverseProperty(nameof(Bascula.EntradasLineasidBasculaPesajeNetoNavigation))]
		public virtual Bascula idBasculaPesajeNetoNavigation { get; set; }

		[ForeignKey(nameof(idEntradas))]
		[InverseProperty(nameof(Entradas.EntradasLineas))]
		public virtual Entradas idEntradasNavigation { get; set; }

		[ForeignKey(nameof(idModulo))]
		[InverseProperty(nameof(Modulos.EntradasLineas))]
		public virtual Modulos idModuloNavigation { get; set; }

		[ForeignKey(nameof(idOrigenProv))]
		[InverseProperty(nameof(ProveedoresOrigenes.EntradasLineas))]
		public virtual ProveedoresOrigenes idOrigenProvNavigation { get; set; }

		[ForeignKey(nameof(idProducto))]
		[InverseProperty(nameof(Productos.EntradasLineas))]
		public virtual Productos idProductoNavigation { get; set; }

		[ForeignKey(nameof(idProveedor))]
		[InverseProperty(nameof(Proveedores.EntradasLineas))]
		public virtual Proveedores idProveedorNavigation { get; set; }

		[InverseProperty(nameof(Models.EntradasContratos.idEntradasLineasNavigation))]
		public virtual ICollection<EntradasContratos> EntradasContratos { get; set; } = new HashSet<EntradasContratos>();

		[InverseProperty(nameof(Models.EntradasLineasResultadosNIR.idEntradasLineasNavigation))]
		public virtual ICollection<EntradasLineasResultadosNIR> EntradasLineasResultadosNIR { get; set; } = new HashSet<EntradasLineasResultadosNIR>();

		[InverseProperty(nameof(Models.EntradasLotes.IdEntradasLineasNavigation))]
		public virtual ICollection<EntradasLotes> EntradasLotes { get; set; } = new HashSet<EntradasLotes>();

		[InverseProperty(nameof(Models.Existencias.idEntradaLineaNavigation))]
		public virtual ICollection<Existencias> Existencias { get; set; } = new HashSet<Existencias>();

		[InverseProperty(nameof(Models.LineasCompra.idLineaEntradaNavigation))]
		public virtual ICollection<LineasCompra> LineasCompra { get; set; } = new HashSet<LineasCompra>();

		[InverseProperty(nameof(Models.Ordenes.LineaEntradaNavigation))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

		[InverseProperty(nameof(Models.Stocks.idEntradasLineasNavigation))]
		public virtual ICollection<Stocks> Stocks { get; set; } = new HashSet<Stocks>();

		[InverseProperty(nameof(Models.StocksReserva.idEntradasLineasNavigation))]
		public virtual ICollection<StocksReserva> StocksReserva { get; set; } = new HashSet<StocksReserva>();

		[InverseProperty(nameof(Models.Tarjetas.EntradaLinea))]
		public virtual ICollection<Tarjetas> Tarjetas { get; set; } = new HashSet<Tarjetas>();

	}

}
