using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Productos
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? Familia { get; set; }

		public float? Densidad { get; set; }

		public int? Unidad { get; set; }

		public ProductType? Tipo { get; set; }

		public int? Stock { get; set; }

		public bool? ControlStock { get; set; }

		public bool? Dosificable { get; set; }

		public bool? Automatico { get; set; }

		public DosificacionType? TipoDosificacion { get; set; }

		public int? Formato { get; set; }

		public int? Envase { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		[Column("Referencia2")]
		[StringLength(20)]
		public string NombreComercial { get; set; }

		public bool Importado { get; set; }

		public float? Humedad { get; set; }

		public float? PesoEspecifico { get; set; }

		public int? Entradas { get; set; }

		public bool? Muestras { get; set; }

		public int? EtiquetaGranel { get; set; }

		public int? EtiquetaSacos { get; set; }

		public int? EtiquetaMuestras { get; set; }

		public int? EtiquetaControl { get; set; }

		public int? Formula { get; set; }

		public int? Analisi { get; set; }

		[StringLength(50)]
		public string NumeroRegistro { get; set; }

		public bool? Inhabilitado { get; set; }

		public int? Caducidad { get; set; }

		public bool? Refrescado { get; set; }

		public bool? Receptable { get; set; }

		public bool Exportado { get; set; }

		public bool? Medicamento { get; set; }

		public bool? AplicacionDirecta { get; set; }

		public int? Modulo { get; set; }

		public int? Medidor { get; set; }

		public int? FamiliaMedidor { get; set; }

		public int? Afeccion { get; set; }

		public float? PrecioCompra { get; set; }

		public float? PrecioVenta { get; set; }

		public float? PrecioMedioCompra { get; set; }

		public float? StockMinimo { get; set; }

		public bool? Bloqueado { get; set; }

		public int? TiempoEspera { get; set; }

		public int? TipoIva { get; set; }

		public float? PrecioCompraMedio { get; set; }

		public float? PrecioCompraUltimo { get; set; }

		public int? Estado { get; set; }

		public int? EtiquetaEntradas { get; set; }

		[StringLength(50)]
		public string ViaAdministracion { get; set; }

		public bool? MostrarEnEtiqueta { get; set; }

		[StringLength(254)]
		public string NombreAMostrarEnEtiqueta { get; set; }

		[Obsolete]
		public int? idOld { get; set; }

		[Column(TypeName = "numeric(18, 2)")]
		public decimal? ToleranciaSuperior { get; set; }

		[Column(TypeName = "numeric(18, 2)")]
		public decimal? ToleranciaInferior { get; set; }

		public bool? PausaPosteriorDosificacion { get; set; }

		[Column(TypeName = "numeric(18, 2)")]
		public decimal? DesviacionMaxima { get; set; }

		public int? PlantillaCabCargaPiquera { get; set; }

		public bool? TipoPR { get; set; }

		public int? PlantillaCabProduccion { get; set; }

		public int? PlantillaCabCargaPiquera2 { get; set; }

		public int? PlantillaCabSecadero { get; set; }

		[StringLength(20)]
		public string EAN13 { get; set; }

		public int? PlantillaCabProduccion2 { get; set; }

		public int? PlantillaCabProduccion3 { get; set; }

		public int? DestinoDefecto { get; set; }

		[StringLength(50)]
		public string PartidaArancelariaFabricacion { get; set; }

		[StringLength(50)]
		public string PartidaArancelariaCompras { get; set; }

		public int? PlantillaCabMolturacion { get; set; }

		[StringLength(20)]
		public string NombreScada { get; set; }

		[ForeignKey(nameof(Afeccion))]
		[InverseProperty(nameof(Afecciones.Productos))]
		public virtual Afecciones AfeccionNavigation { get; set; }

		[ForeignKey(nameof(DestinoDefecto))]
		[InverseProperty(nameof(Models.Ubicaciones.Productos))]
		public virtual Ubicaciones DestinoDefectoNavigation { get; set; }

		[ForeignKey(nameof(Envase))]
		[InverseProperty(nameof(Envases.Productos))]
		public virtual Envases EnvaseNavigation { get; set; }

		[ForeignKey(nameof(EtiquetaControl))]
		[InverseProperty(nameof(Etiquetas.ProductosEtiquetaControlNavigation))]
		public virtual Etiquetas EtiquetaControlNavigation { get; set; }

		[ForeignKey(nameof(EtiquetaEntradas))]
		[InverseProperty(nameof(Etiquetas.ProductosEtiquetaEntradasNavigation))]
		public virtual Etiquetas EtiquetaEntradasNavigation { get; set; }

		[ForeignKey(nameof(EtiquetaGranel))]
		[InverseProperty(nameof(Etiquetas.ProductosEtiquetaGranelNavigation))]
		public virtual Etiquetas EtiquetaGranelNavigation { get; set; }

		[ForeignKey(nameof(EtiquetaMuestras))]
		[InverseProperty(nameof(Etiquetas.ProductosEtiquetaMuestrasNavigation))]
		public virtual Etiquetas EtiquetaMuestrasNavigation { get; set; }

		[ForeignKey(nameof(EtiquetaSacos))]
		[InverseProperty(nameof(Etiquetas.ProductosEtiquetaSacosNavigation))]
		public virtual Etiquetas EtiquetaSacosNavigation { get; set; }

		[ForeignKey(nameof(FamiliaMedidor))]
		[InverseProperty(nameof(FamiliasMedidor.Productos))]
		public virtual FamiliasMedidor FamiliaMedidorNavigation { get; set; }

		[ForeignKey(nameof(Familia))]
		[InverseProperty(nameof(Familias.Productos))]
		public virtual Familias FamiliaNavigation { get; set; }

		[ForeignKey(nameof(Formato))]
		[InverseProperty(nameof(Formatos.Productos))]
		public virtual Formatos FormatoNavigation { get; set; }

		[ForeignKey(nameof(Medidor))]
		[InverseProperty(nameof(Models.Medidor.Productos))]
		public virtual Medidor MedidorNavigation { get; set; }

		[ForeignKey(nameof(Modulo))]
		[InverseProperty(nameof(Models.Modulos.Productos))]
		public virtual Modulos ModuloNavigation { get; set; }

		[ForeignKey(nameof(PlantillaCabCargaPiquera2))]
		[InverseProperty(nameof(OperCabPlantillas.ProductosPlantillaCabCargaPiquera2Navigation))]
		public virtual OperCabPlantillas PlantillaCabCargaPiquera2Navigation { get; set; }

		[ForeignKey(nameof(PlantillaCabCargaPiquera))]
		[InverseProperty(nameof(OperCabPlantillas.ProductosPlantillaCabCargaPiqueraNavigation))]
		public virtual OperCabPlantillas PlantillaCabCargaPiqueraNavigation { get; set; }

		[ForeignKey(nameof(PlantillaCabMolturacion))]
		[InverseProperty(nameof(OperCabPlantillas.ProductosPlantillaCabMolturacionNavigation))]
		public virtual OperCabPlantillas PlantillaCabMolturacionNavigation { get; set; }

		[ForeignKey(nameof(PlantillaCabProduccion2))]
		[InverseProperty(nameof(OperCabPlantillas.ProductosPlantillaCabProduccion2Navigation))]
		public virtual OperCabPlantillas PlantillaCabProduccion2Navigation { get; set; }

		[ForeignKey(nameof(PlantillaCabProduccion3))]
		[InverseProperty(nameof(OperCabPlantillas.ProductosPlantillaCabProduccion3Navigation))]
		public virtual OperCabPlantillas PlantillaCabProduccion3Navigation { get; set; }

		[ForeignKey(nameof(PlantillaCabProduccion))]
		[InverseProperty(nameof(OperCabPlantillas.ProductosPlantillaCabProduccionNavigation))]
		public virtual OperCabPlantillas PlantillaCabProduccionNavigation { get; set; }

		[ForeignKey(nameof(PlantillaCabSecadero))]
		[InverseProperty(nameof(OperCabPlantillas.ProductosPlantillaCabSecaderoNavigation))]
		public virtual OperCabPlantillas PlantillaCabSecaderoNavigation { get; set; }

		[ForeignKey(nameof(TipoIva))]
		[InverseProperty(nameof(TiposIva.Productos))]
		public virtual TiposIva TipoIvaNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.Productos))]
		public virtual Unidades UnidadNavigation { get; set; }

		[InverseProperty(nameof(Models.Aditivos.ProductoNavigation))]
		public virtual ICollection<Aditivos> Aditivos { get; set; } = new HashSet<Aditivos>();

		[InverseProperty(nameof(Models.CabOrdenes.ProductoDestinoNavigation))]
		public virtual ICollection<CabOrdenes> CabOrdenes { get; set; } = new HashSet<CabOrdenes>();

		[InverseProperty(nameof(Caudal.Producto))]
		public virtual ICollection<Caudal> Caudales { get; set; } = new HashSet<Caudal>();

		[InverseProperty(nameof(Models.Componentes.ProductoNavigation))]
		public virtual ICollection<Componentes> Componentes { get; set; } = new HashSet<Componentes>();

		[InverseProperty(nameof(Models.ComponentesActivos.ProductoNavigation))]
		public virtual ICollection<ComponentesActivos> ComponentesActivos { get; set; } = new HashSet<ComponentesActivos>();

		[InverseProperty(nameof(Models.Contratos.IdProductoNavigation))]
		public virtual ICollection<Contratos> Contratos { get; set; } = new HashSet<Contratos>();

		[InverseProperty(nameof(Models.ControlesNIRProductos.idProductoNavigation))]
		public virtual ICollection<ControlesNIRProductos> ControlesNIRProductos { get; set; } = new HashSet<ControlesNIRProductos>();

		[InverseProperty(nameof(Models.Desgloses.ProductoNavigation))]
		public virtual ICollection<Desgloses> Desgloses { get; set; } = new HashSet<Desgloses>();

		[InverseProperty(nameof(Models.Disposiciones.ProductoNavigation))]
		public virtual ICollection<Disposiciones> Disposiciones { get; set; } = new HashSet<Disposiciones>();

		[InverseProperty(nameof(Dosificaciones.ProductoActualNavigation))]
		public virtual ICollection<Dosificaciones> DosificacionesProductoActualNavigation { get; set; } = new HashSet<Dosificaciones>();

		[InverseProperty(nameof(Dosificaciones.ProductoNavigation))]
		public virtual ICollection<Dosificaciones> DosificacionesProductoNavigation { get; set; } = new HashSet<Dosificaciones>();

		[InverseProperty(nameof(Models.EnlaceERPAsigUbi.IdProductoNavigation))]
		public virtual ICollection<EnlaceERPAsigUbi> EnlaceERPAsigUbi { get; set; } = new HashSet<EnlaceERPAsigUbi>();

		[InverseProperty(nameof(Models.EntradasLineas.idProductoNavigation))]
		public virtual ICollection<EntradasLineas> EntradasLineas { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(Models.Existencias.ProductoNavigation))]
		public virtual ICollection<Existencias> Existencias { get; set; } = new HashSet<Existencias>();

		[InverseProperty(nameof(Models.FormulaProdModulo.idProductoNavigation))]
		public virtual ICollection<FormulaProdModulo> FormulaProdModulo { get; set; } = new HashSet<FormulaProdModulo>();

		[InverseProperty(nameof(Models.Formularios.ProductoNavigation))]
		public virtual ICollection<Formularios> Formularios { get; set; } = new HashSet<Formularios>();

		[InverseProperty(nameof(Models.Formulas.ProductoNavigation))]
		public virtual ICollection<Formulas> Formulas { get; set; } = new HashSet<Formulas>();

		[InverseProperty(nameof(Models.GruposIncompatibilidadesLineas.IdProductoNavigation))]
		public virtual ICollection<GruposIncompatibilidadesLineas> GruposIncompatibilidadesLineas { get; set; } = new HashSet<GruposIncompatibilidadesLineas>();

		[InverseProperty(nameof(Models.Incompatibilidades.ProductoNavigation))]
		public virtual ICollection<Incompatibilidades> Incompatibilidades { get; set; } = new HashSet<Incompatibilidades>();

		[InverseProperty(nameof(Models.LineasCompra.ProductoNavigation))]
		public virtual ICollection<LineasCompra> LineasCompra { get; set; } = new HashSet<LineasCompra>();

		[InverseProperty(nameof(Models.LogMovimientosStocks.IdProductoNavigation))]
		public virtual ICollection<LogMovimientosStocks> LogMovimientosStocks { get; set; } = new HashSet<LogMovimientosStocks>();

		[InverseProperty(nameof(Models.Lotes.ProductoNavigation))]
		public virtual ICollection<Lotes> Lotes { get; set; } = new HashSet<Lotes>();

		[InverseProperty(nameof(Models.MedicacionesIngredientes.ProductoNavigation))]
		public virtual ICollection<MedicacionesIngredientes> MedicacionesIngredientes { get; set; } = new HashSet<MedicacionesIngredientes>();

		[InverseProperty(nameof(Models.MedidoresDosificaciones.idProductoNavigation))]
		public virtual ICollection<MedidoresDosificaciones> MedidoresDosificaciones { get; set; } = new HashSet<MedidoresDosificaciones>();

		[InverseProperty(nameof(Models.Modulos.ProdFinalDefectoNavigation))]
		public virtual ICollection<Modulos> Modulos { get; set; } = new HashSet<Modulos>();

		[InverseProperty(nameof(Models.NetAlarmas.RespIdProductoNavigation))]
		public virtual ICollection<NetAlarmas> NetAlarmas { get; set; } = new HashSet<NetAlarmas>();

		[InverseProperty(nameof(Models.OperPlantillas.IdProductoNavigation))]
		public virtual ICollection<OperPlantillas> OperPlantillas { get; set; } = new HashSet<OperPlantillas>();

		[InverseProperty(nameof(Models.Ordenes.ProductoDestinoNavigation))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

		[InverseProperty(nameof(ProductoEnvaseEtiqueta.Producto))]
		public virtual ICollection<ProductoEnvaseEtiqueta> ProductosEnvasesEtiquetas { get; set; } = new HashSet<ProductoEnvaseEtiqueta>();

		[InverseProperty(nameof(Models.ProductosGruposIncompatibilidades.IdProductoNavigation))]
		public virtual ICollection<ProductosGruposIncompatibilidades> ProductosGruposIncompatibilidades { get; set; } = new HashSet<ProductosGruposIncompatibilidades>();

		[InverseProperty(nameof(Models.ProductoMedidorCamino.Producto))]
		public virtual ICollection<ProductoMedidorCamino> ProductosMedidoresCaminos { get; set; } = new HashSet<ProductoMedidorCamino>();

		[InverseProperty(nameof(Models.ProductosOperCabPlantillas.IdProductoNavigation))]
		public virtual ICollection<ProductosOperCabPlantillas> ProductosOperCabPlantillas { get; set; } = new HashSet<ProductosOperCabPlantillas>();

		[InverseProperty(nameof(Models.Recetas.idProductoNavigation))]
		public virtual ICollection<Recetas> Recetas { get; set; } = new HashSet<Recetas>();

		[InverseProperty(nameof(Models.RecetasLineas.ProductoNavigation))]
		public virtual ICollection<RecetasLineas> RecetasLineas { get; set; } = new HashSet<RecetasLineas>();

		[InverseProperty(nameof(Models.Regularizaciones.ProductoNavigation))]
		public virtual ICollection<Regularizaciones> Regularizaciones { get; set; } = new HashSet<Regularizaciones>();

		[InverseProperty(nameof(Models.Resultados.ProductoNavigation))]
		public virtual ICollection<Resultados> Resultados { get; set; } = new HashSet<Resultados>();

		[InverseProperty(nameof(Models.SalidasLinias.idProductoNavigation))]
		public virtual ICollection<SalidasLinias> SalidasLinias { get; set; } = new HashSet<SalidasLinias>();

		[InverseProperty(nameof(Models.SalidasLiniasMedicaciones.ProductoNavigation))]
		public virtual ICollection<SalidasLiniasMedicaciones> SalidasLiniasMedicaciones { get; set; } = new HashSet<SalidasLiniasMedicaciones>();

		[InverseProperty(nameof(SolicitudAjusteCaudal.Producto))]
		public virtual ICollection<SolicitudAjusteCaudal> SolicitudesAjusteCaudal { get; set; } = new HashSet<SolicitudAjusteCaudal>();

		[InverseProperty(nameof(Models.StocksReserva.idProductoNavigation))]
		public virtual ICollection<StocksReserva> StocksReserva { get; set; } = new HashSet<StocksReserva>();

		[InverseProperty(nameof(Models.Tarifas.ProductoNavigation))]
		public virtual ICollection<Tarifas> Tarifas { get; set; } = new HashSet<Tarifas>();

		[InverseProperty(nameof(Models.Ubicaciones.ProductoNavigation))]
		public virtual ICollection<Ubicaciones> Ubicaciones { get; set; } = new HashSet<Ubicaciones>();

		[InverseProperty(nameof(Models.VentasLinias.idProductoNavigation))]
		public virtual ICollection<VentasLinias> VentasLinias { get; set; } = new HashSet<VentasLinias>();

		[InverseProperty(nameof(Models.SalidasLiniasMedicaciones.ProductoNavigation))]
		public virtual ICollection<VentasLiniasMedicaciones> VentasLiniasMedicaciones { get; set; } = new HashSet<VentasLiniasMedicaciones>();

	}

}
