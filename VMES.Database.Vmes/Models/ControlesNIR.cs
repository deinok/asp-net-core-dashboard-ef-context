using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class ControlesNIR
	{

		[Key]
		public int id { get; set; }

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

		[InverseProperty(nameof(Models.ControlesNIRProductos.idControlNirNavigation))]
		public virtual ICollection<ControlesNIRProductos> ControlesNIRProductos { get; set; } = new HashSet<ControlesNIRProductos>();

		[InverseProperty(nameof(Models.EntradasLineasResultadosNIR.idControlesNirNavigation))]
		public virtual ICollection<EntradasLineasResultadosNIR> EntradasLineasResultadosNIR { get; set; } = new HashSet<EntradasLineasResultadosNIR>();

		[InverseProperty(nameof(Models.SalidasLiniasMuestras.idControlesNirNavigation))]
		public virtual ICollection<SalidasLiniasMuestras> SalidasLiniasMuestras { get; set; } = new HashSet<SalidasLiniasMuestras>();

	}

}
