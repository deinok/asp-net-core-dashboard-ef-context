using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Ventas
	{

		[Key]
		public int id { get; set; }

		public int? idSerie { get; set; }

		public int? Codigo { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		public int? Departamento { get; set; }

		[Column(TypeName = "date")]
		public DateTime? Fecha { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioTransporte { get; set; }

		public int? idCliente { get; set; }

		[Column(TypeName = "date")]
		public DateTime? FechaEntrega { get; set; }

		public int? idDomicilio { get; set; }

		public VentaStatus? Estado { get; set; }

		public string Comentario { get; set; }

		public string Observaciones { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFin { get; set; }

		[StringLength(50)]
		public string RefERP { get; set; }

		public bool? isImport { get; set; }

		public int Impresiones { get; set; }

		public bool Exportado { get; set; }

		public bool Importado { get; set; }

		[ForeignKey(nameof(Departamento))]
		[InverseProperty(nameof(Departamentos.Ventas))]
		public virtual Departamentos DepartamentoNavigation { get; set; }

		[ForeignKey(nameof(idCliente))]
		[InverseProperty(nameof(Clientes.Ventas))]
		public virtual Clientes idClienteNavigation { get; set; }

		[ForeignKey(nameof(idDomicilio))]
		[InverseProperty(nameof(Domicilios.Ventas))]
		public virtual Domicilios idDomicilioNavigation { get; set; }

		[ForeignKey(nameof(idSerie))]
		[InverseProperty(nameof(Series.Ventas))]
		public virtual Series idSerieNavigation { get; set; }

		[InverseProperty(nameof(Models.VentasLinias.idVentasNavigation))]
		public virtual ICollection<VentasLinias> VentasLinias { get; set; } = new HashSet<VentasLinias>();

	}

}
