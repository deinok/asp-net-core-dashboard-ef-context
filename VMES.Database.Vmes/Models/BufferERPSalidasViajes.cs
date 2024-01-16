using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPSalidasViajes
	{

		[Key]
		public int id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FImportado { get; set; }

		public bool? Preparado { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		public int? idSalidas { get; set; }

		[StringLength(15)]
		public string MatriculaRemolque { get; set; }

		public int? idVehiculo { get; set; }

		public int? idChofer { get; set; }

		public int? idTarjeta { get; set; }

		public int? EstadoTransito { get; set; }

		[StringLength(15)]
		public string MatriculaCamion { get; set; }

		[StringLength(50)]
		public string NombreConductor { get; set; }

		[StringLength(500)]
		public string Observaciones { get; set; }

		public int? idEmpresaTransporte { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		public int? idMES { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFinTransito { get; set; }

		public int? Serie { get; set; }

		[StringLength(50)]
		public string SerieNombre { get; set; }

		public int? Numero { get; set; }

		[StringLength(50)]
		public string EmpresaTransporteNombre { get; set; }

		[StringLength(50)]
		public string RefEmpresaTransporte { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		[StringLength(20)]
		public string RefConductor { get; set; }

		[StringLength(20)]
		public string RefCliente { get; set; }

		[StringLength(20)]
		public string RefDomicilio { get; set; }

		[InverseProperty(nameof(Models.BufferERPSalidasLinias.idviajesNavigation))]
		public virtual ICollection<BufferERPSalidasLinias> BufferERPSalidasLinias { get; set; } = new HashSet<BufferERPSalidasLinias>();

	}

}
