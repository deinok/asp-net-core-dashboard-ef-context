using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class LineasCompra
	{

		[Key]
		public int Id { get; set; }

		public int? Serie { get; set; }

		public int Compra { get; set; }

		public int Linea { get; set; }

		public int? Producto { get; set; }

		public float? Cantidad { get; set; }

		public float? Servida { get; set; }

		public CompraLineaStatus? Estado { get; set; }

		public bool? Importado { get; set; }

		public int? Departamento { get; set; }

		public int? Lote { get; set; }

		public int? Bultos { get; set; }

		public int? Envase { get; set; }

		public int? Unidad { get; set; }

		[StringLength(20)]
		public string Contrato { get; set; }

		[StringLength(100)]
		public string Comentario { get; set; }

		public bool? Exportado { get; set; }

		public float? PrecioCompra { get; set; }

		public int? IdContrato { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFin { get; set; }

		public int? idLineaEntrada { get; set; }

		public int? Formato { get; set; }

		public bool? PagarTeorico { get; set; }

		[ForeignKey(nameof(Compra))]
		[InverseProperty(nameof(Compras.LineasCompra))]
		public virtual Compras CompraNavigation { get; set; }

		[ForeignKey(nameof(Envase))]
		[InverseProperty(nameof(Envases.LineasCompra))]
		public virtual Envases EnvaseNavigation { get; set; }

		[ForeignKey(nameof(Formato))]
		[InverseProperty(nameof(Formatos.LineasCompra))]
		public virtual Formatos FormatoNavigation { get; set; }

		[ForeignKey(nameof(IdContrato))]
		[InverseProperty(nameof(Contratos.LineasCompra))]
		public virtual Contratos IdContratoNavigation { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Productos.LineasCompra))]
		public virtual Productos ProductoNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.LineasCompra))]
		public virtual Unidades UnidadNavigation { get; set; }

		[ForeignKey(nameof(idLineaEntrada))]
		[InverseProperty(nameof(EntradasLineas.LineasCompra))]
		public virtual EntradasLineas idLineaEntradaNavigation { get; set; }

	}

}
