using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Lotes
	{

		public int Producto { get; set; }

		public int? OldId { get; set; }

		[Key]
		public int Id { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		[StringLength(30)]
		public string Nombre { get; set; }

		public int? Formato { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? Departamento { get; set; }

		public int? Entrada { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Inicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fin { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Caducidad { get; set; }

		public LoteStatus? Estado { get; set; }

		public float? Cantidad { get; set; }

		public bool Importado { get; set; }

		public bool Exportado { get; set; }

		public float? PrecioCoste { get; set; }

		public bool Prioritario { get; set; }

		public bool? Modificado { get; set; }

		public int? Medicacion { get; set; }

		public bool? Mezclado { get; set; }

		public int? IdProveedor { get; set; }

		[Column(TypeName = "decimal(15, 3)")]
		public decimal? CantidadPedida { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fabricacion { get; set; }

		public bool? NombreEnCodBarras { get; set; }

		[StringLength(30)]
		public string CampoStrLibre1 { get; set; }

		[StringLength(30)]
		public string CampoStrLibre2 { get; set; }

		[StringLength(30)]
		public string CampoStrLibre3 { get; set; }

		[StringLength(30)]
		public string CampoStrLibre4 { get; set; }

		[ForeignKey(nameof(Formato))]
		[InverseProperty(nameof(Formatos.Lotes))]
		public virtual Formatos FormatoNavigation { get; set; }

		[ForeignKey(nameof(IdProveedor))]
		[InverseProperty(nameof(Proveedores.Lotes))]
		public virtual Proveedores IdProveedorNavigation { get; set; }

		[ForeignKey(nameof(Medicacion))]
		[InverseProperty(nameof(Medicaciones.Lotes))]
		public virtual Medicaciones MedicacionNavigation { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Productos.Lotes))]
		public virtual Productos ProductoNavigation { get; set; }

		[InverseProperty(nameof(Models.BufferERPSolicitudRegularizacion.IdLoteNavigation))]
		public virtual ICollection<BufferERPSolicitudRegularizacion> BufferERPSolicitudRegularizacion { get; set; } = new HashSet<BufferERPSolicitudRegularizacion>();

		[InverseProperty(nameof(Models.BufferERPSolicitudTraspaso.Lote))]
		public virtual ICollection<BufferERPSolicitudTraspaso> BufferERPSolicitudTraspaso { get; set; } = new HashSet<BufferERPSolicitudTraspaso>();

		[InverseProperty(nameof(Models.CabOrdenes.LoteDestinoNavigation))]
		public virtual ICollection<CabOrdenes> CabOrdenes { get; set; } = new HashSet<CabOrdenes>();

		[InverseProperty(nameof(Models.Desgloses.LoteNavigation))]
		public virtual ICollection<Desgloses> Desgloses { get; set; } = new HashSet<Desgloses>();

		[InverseProperty(nameof(Models.Disposiciones.LoteNavigation))]
		public virtual ICollection<Disposiciones> Disposiciones { get; set; } = new HashSet<Disposiciones>();

		[InverseProperty(nameof(Dosificaciones.LoteActualNavigation))]
		public virtual ICollection<Dosificaciones> DosificacionesLoteActualNavigation { get; set; } = new HashSet<Dosificaciones>();

		[InverseProperty(nameof(Dosificaciones.LoteNavigation))]
		public virtual ICollection<Dosificaciones> DosificacionesLoteNavigation { get; set; } = new HashSet<Dosificaciones>();

		[InverseProperty(nameof(Models.EntradasLineas.LoteNavigation))]
		public virtual ICollection<EntradasLineas> EntradasLineas { get; set; } = new HashSet<EntradasLineas>();

		[InverseProperty(nameof(Models.EntradasLotes.IdLoteNavigation))]
		public virtual ICollection<EntradasLotes> EntradasLotes { get; set; } = new HashSet<EntradasLotes>();

		[InverseProperty(nameof(Models.Existencias.LoteNavigation))]
		public virtual ICollection<Existencias> Existencias { get; set; } = new HashSet<Existencias>();

		[InverseProperty(nameof(Models.LogMovimientosStocks.IdLoteNavigation))]
		public virtual ICollection<LogMovimientosStocks> LogMovimientosStocks { get; set; } = new HashSet<LogMovimientosStocks>();

		[InverseProperty(nameof(LotesMezclados.idLoteNuevoNavigation))]
		public virtual ICollection<LotesMezclados> LotesMezcladosidLoteNuevoNavigation { get; set; } = new HashSet<LotesMezclados>();

		[InverseProperty(nameof(LotesMezclados.idLoteOrigenNavigation))]
		public virtual ICollection<LotesMezclados> LotesMezcladosidLoteOrigenNavigation { get; set; } = new HashSet<LotesMezclados>();

		[InverseProperty(nameof(Models.NetAlarmas.RespIdLoteNavigation))]
		public virtual ICollection<NetAlarmas> NetAlarmas { get; set; } = new HashSet<NetAlarmas>();

		[InverseProperty(nameof(Models.Ordenes.LoteDestinoNavigation))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

		[InverseProperty(nameof(Models.Regularizaciones.LoteNavigation))]
		public virtual ICollection<Regularizaciones> Regularizaciones { get; set; } = new HashSet<Regularizaciones>();

		[InverseProperty(nameof(Models.Resultados.LoteNavigation))]
		public virtual ICollection<Resultados> Resultados { get; set; } = new HashSet<Resultados>();

		[InverseProperty(nameof(Models.SalidasLiniasLote.idLoteNavigation))]
		public virtual ICollection<SalidasLiniasLote> SalidasLiniasLote { get; set; } = new HashSet<SalidasLiniasLote>();

		[InverseProperty(nameof(Models.Stocks.LoteNavigation))]
		public virtual ICollection<Stocks> Stocks { get; set; } = new HashSet<Stocks>();

		[InverseProperty(nameof(Models.StocksReserva.idLoteNavigation))]
		public virtual ICollection<StocksReserva> StocksReserva { get; set; } = new HashSet<StocksReserva>();

		[InverseProperty(nameof(Models.Ubicaciones.LoteNavigation))]
		public virtual ICollection<Ubicaciones> Ubicaciones { get; set; } = new HashSet<Ubicaciones>();

	}

}
