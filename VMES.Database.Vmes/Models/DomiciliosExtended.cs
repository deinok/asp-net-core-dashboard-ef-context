using System;
using System.ComponentModel.DataAnnotations;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class DomiciliosExtended
	{

		public int DomicilioId { get; set; }

		public int? DomicilioIdCliente { get; set; }

		[StringLength(50)]
		public string DomicilioNombre { get; set; }

		[StringLength(50)]
		public string DomicilioReferencia { get; set; }

		[StringLength(50)]
		public string DomicilioDireccion { get; set; }

		[StringLength(50)]
		public string DomicilioPoblacion { get; set; }

		[StringLength(20)]
		public string DomicilioTelefono { get; set; }

		[StringLength(5)]
		public string DomicilioCodigoPostal { get; set; }

		public int? DomicilioProvincia { get; set; }

		public int? DomicilioPais { get; set; }

		[StringLength(50)]
		public string DomicilioPaisNombre { get; set; }

		public bool? Inhabilitado { get; set; }

		[StringLength(50)]
		public string DomicilioInhabilitadoStr { get; set; }

		[StringLength(50)]
		public string DomicilioDescripcion { get; set; }

		[StringLength(20)]
		public string DomicilioSIMOGAN { get; set; }

	}

}
