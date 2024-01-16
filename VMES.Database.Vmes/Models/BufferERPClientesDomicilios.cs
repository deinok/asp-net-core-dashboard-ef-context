using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPClientesDomicilios
	{

		[Key]
		public int id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FImportado { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		public int? idCliente { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		[StringLength(50)]
		public string Direccion { get; set; }

		[StringLength(50)]
		public string Poblacion { get; set; }

		[StringLength(20)]
		public string Telefono { get; set; }

		[StringLength(5)]
		public string CodigoPostal { get; set; }

		[StringLength(50)]
		public string Provincia { get; set; }

		[StringLength(50)]
		public string Pais { get; set; }

		[StringLength(50)]
		public string MarcaOficial { get; set; }

		[StringLength(50)]
		public string Responsable { get; set; }

		[StringLength(50)]
		public string Especie { get; set; }

		public int? NumeroEspecies { get; set; }

		public bool? Inhabilitado { get; set; }

		[StringLength(50)]
		public string Descripcion { get; set; }

		[StringLength(20)]
		public string Simogan { get; set; }

		[StringLength(20)]
		public string REGA { get; set; }

		[StringLength(20)]
		public string LoteAnimalActual { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		[StringLength(20)]
		public string RefCliente { get; set; }

		[ForeignKey(nameof(idCliente))]
		[InverseProperty(nameof(BufferERPClientes.BufferERPClientesDomicilios))]
		public virtual BufferERPClientes idClienteNavigation { get; set; }

		[InverseProperty(nameof(Models.BufferERPClienteDomicilioPuntoDescarga.idDomicilioNavigation))]
		public virtual ICollection<BufferERPClienteDomicilioPuntoDescarga> BufferERPClienteDomicilioPuntoDescarga { get; set; } = new HashSet<BufferERPClienteDomicilioPuntoDescarga>();

	}

}
