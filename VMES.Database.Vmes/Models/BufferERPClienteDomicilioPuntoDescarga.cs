using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPClienteDomicilioPuntoDescarga
	{

		[Key]
		public int id { get; set; }

		public int? idDomicilio { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(250)]
		public string Descripcion { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FImportado { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		[ForeignKey(nameof(idDomicilio))]
		[InverseProperty(nameof(BufferERPClientesDomicilios.BufferERPClienteDomicilioPuntoDescarga))]
		public virtual BufferERPClientesDomicilios idDomicilioNavigation { get; set; }

	}

}
