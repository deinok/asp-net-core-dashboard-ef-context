using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class ModuloEstadoComunicaciones
	{

		[Key]
		public int ModuloId { get; set; }

		public ModuleCommunicationStatus Estado { get; set; }

		public bool CerrarModulo { get; set; }

		public bool CerrarOpc { get; set; }

		public bool Resituar { get; set; }

		public DateTime UltimaActualizacionIntegraServer { get; set; }

		public DateTime UltimaActualizacionIntegraModulo { get; set; }

		public int? ProcessId { get; set; }

		[ForeignKey(nameof(ModuloId))]
		[InverseProperty(nameof(Modulos.ModuloEstadoComunicaciones))]
		public virtual Modulos Modulo { get; set; }

	}

}
