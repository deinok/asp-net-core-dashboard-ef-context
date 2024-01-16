using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class SalidasLiniasMuestras
	{

		[Key]
		public int id { get; set; }

		public int? idSalidasLineas { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Resultado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaResultado { get; set; }

		public int? idControlesNir { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(500)]
		public string Descripcion { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? ValorMinimo { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? ValorEsperado { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? ValorMaximo { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? ValorMinimoAlerta { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? ValorMaximoAlerta { get; set; }

		public bool? ActivarMinimo { get; set; }

		public bool? ActivarMaximo { get; set; }

		public bool? ActivarMinimoAlerta { get; set; }

		public bool? ActivarMaximoAlerta { get; set; }

		public int? Estado { get; set; }

		[ForeignKey(nameof(idControlesNir))]
		[InverseProperty(nameof(ControlesNIR.SalidasLiniasMuestras))]
		public virtual ControlesNIR idControlesNirNavigation { get; set; }

		[ForeignKey(nameof(idSalidasLineas))]
		[InverseProperty(nameof(SalidasLinias.SalidasLiniasMuestras))]
		public virtual SalidasLinias idSalidasLineasNavigation { get; set; }

	}

}
