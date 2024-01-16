using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class VentasLinias
	{

		[Key]
		public int id { get; set; }

		public int? idVentas { get; set; }

		public int? idProducto { get; set; }

		public int? idFormato { get; set; }

		public int? idEnvase { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Bultos { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? Cantidad { get; set; }

		public int? idUnidad { get; set; }

		public int? idDomicilio { get; set; }

		public int? idMedicamento { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioUnidad { get; set; }

		public int? idContrato { get; set; }

		public int? linea { get; set; }

		[Column(TypeName = "decimal(18, 6)")]
		public decimal? MedCantidad { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? MedBultos { get; set; }

		public int? MedEnvase { get; set; }

		public int? MedUnidad { get; set; }

		public int? MedFormato { get; set; }

		[Column(TypeName = "decimal(18, 6)")]
		public decimal? MedPrecioUnidad { get; set; }

		public VentaLineaStatus? Estado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[StringLength(250)]
		public string Observaciones { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? Precio { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioTransporte { get; set; }

		[StringLength(50)]
		public string CampoLibre1 { get; set; }

		[StringLength(50)]
		public string CampoLibre2 { get; set; }

		public int? idPuntoDescarga { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFin { get; set; }

		public bool Exportado { get; set; }

		public bool Importado { get; set; }

		[ForeignKey(nameof(MedEnvase))]
		[InverseProperty(nameof(Envases.VentasLiniasMedEnvaseNavigation))]
		public virtual Envases MedEnvaseNavigation { get; set; }

		[ForeignKey(nameof(MedFormato))]
		[InverseProperty(nameof(Formatos.VentasLiniasMedFormatoNavigation))]
		public virtual Formatos MedFormatoNavigation { get; set; }

		[ForeignKey(nameof(MedUnidad))]
		[InverseProperty(nameof(Unidades.VentasLiniasMedUnidadNavigation))]
		public virtual Unidades MedUnidadNavigation { get; set; }

		[ForeignKey(nameof(idContrato))]
		[InverseProperty(nameof(Contratos.VentasLinias))]
		public virtual Contratos idContratoNavigation { get; set; }

		[ForeignKey(nameof(idDomicilio))]
		[InverseProperty(nameof(Domicilios.VentasLinias))]
		public virtual Domicilios idDomicilioNavigation { get; set; }

		[ForeignKey(nameof(idEnvase))]
		[InverseProperty(nameof(Envases.VentasLiniasidEnvaseNavigation))]
		public virtual Envases idEnvaseNavigation { get; set; }

		[ForeignKey(nameof(idFormato))]
		[InverseProperty(nameof(Formatos.VentasLiniasidFormatoNavigation))]
		public virtual Formatos idFormatoNavigation { get; set; }

		[ForeignKey(nameof(idMedicamento))]
		[InverseProperty(nameof(Medicaciones.VentasLinias))]
		public virtual Medicaciones idMedicamentoNavigation { get; set; }

		[ForeignKey(nameof(idProducto))]
		[InverseProperty(nameof(Productos.VentasLinias))]
		public virtual Productos idProductoNavigation { get; set; }

		[ForeignKey(nameof(idPuntoDescarga))]
		[InverseProperty(nameof(PuntosDescarga.VentasLinias))]
		public virtual PuntosDescarga idPuntoDescargaNavigation { get; set; }

		[ForeignKey(nameof(idUnidad))]
		[InverseProperty(nameof(Unidades.VentasLiniasidUnidadNavigation))]
		public virtual Unidades idUnidadNavigation { get; set; }

		[ForeignKey(nameof(idVentas))]
		[InverseProperty(nameof(Ventas.VentasLinias))]
		public virtual Ventas idVentasNavigation { get; set; }

		[InverseProperty(nameof(Models.LineaVentaLineaSalida.idLineaVentaNavigation))]
		public virtual ICollection<LineaVentaLineaSalida> LineaVentaLineaSalida { get; set; } = new HashSet<LineaVentaLineaSalida>();

		[InverseProperty(nameof(Models.Ordenes.VentaLinea))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

		[InverseProperty(nameof(Models.VentasLiniasMedicaciones.idVentaLiniaNavigation))]
		public virtual ICollection<VentasLiniasMedicaciones> VentasLiniasMedicaciones { get; set; } = new HashSet<VentasLiniasMedicaciones>();

		[InverseProperty(nameof(Models.VentasLiniasPuntosDescarga.idLineaVentaNavigation))]
		public virtual ICollection<VentasLiniasPuntosDescarga> VentasLiniasPuntosDescarga { get; set; } = new HashSet<VentasLiniasPuntosDescarga>();

	}

}
