using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Salidas
	{

		[Key]
		public int id { get; set; }

		public string Observaciones { get; set; }

		public int idSerie { get; set; }

		public int Codigo { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		public int? IdDepartamento { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? idCliente { get; set; }

		public SalidaStatus? Estado { get; set; }

		public string Comentario { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaPrevista { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FInicio { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FFin { get; set; }

		public int? idViaje { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Precio { get; set; }

		[StringLength(20)]
		public string ReferenciaVenta { get; set; }

		public bool Exportado { get; set; }

		public bool Importado { get; set; }

		[StringLength(1000)]
		public string ErrorExportacion { get; set; }

		[ForeignKey(nameof(IdDepartamento))]
		[InverseProperty(nameof(Departamentos.Salidas))]
		public virtual Departamentos IdDepartamentoNavigation { get; set; }

		[ForeignKey(nameof(idCliente))]
		[InverseProperty(nameof(Clientes.Salidas))]
		public virtual Clientes idClienteNavigation { get; set; }

		[ForeignKey(nameof(idSerie))]
		[InverseProperty(nameof(Series.Salidas))]
		public virtual Series idSerieNavigation { get; set; }

		[ForeignKey(nameof(idViaje))]
		[InverseProperty(nameof(SalidasViajes.Salidas))]
		public virtual SalidasViajes idViajeNavigation { get; set; }

		[InverseProperty(nameof(Models.SalidasLinias.idSalidasNavigation))]
		public virtual ICollection<SalidasLinias> SalidasLinias { get; set; } = new HashSet<SalidasLinias>();

	}

}
