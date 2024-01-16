using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Opciones
	{

		[Key]
		[StringLength(50)]
		public string Clave { get; set; }

		[StringLength(250)]
		public string Valor { get; set; }

		[StringLength(1024)]
		public string Comentario { get; set; }

		[Obsolete]
		public int id { get; set; }

		[InverseProperty(nameof(Models.OpcionesRoles.idClaveNavigation))]
		public virtual ICollection<OpcionesRoles> OpcionesRoles { get; set; } = new HashSet<OpcionesRoles>();

		[InverseProperty(nameof(Models.OpcionesUsuarios.idClaveNavigation))]
		public virtual ICollection<OpcionesUsuarios> OpcionesUsuarios { get; set; } = new HashSet<OpcionesUsuarios>();

		public static class Constants
		{
			public const string AutoLecturaHMI = "AutoLecturaHMI";
			public const string Fabrica = "Fabrica";
			public const string LoteModoYYMMDDCCC = "LoteModoYYMMDDCCC";
			public const string ModoAutoRespuesta = "ModoAutoRespuesta";
			public const string PrioridadLoteAConsumir = "PrioridadLoteAConsumir";
			public const string ToleranciaInfDefecto = "ToleranciaInfDefecto";
			public const string ToleranciaSupDefecto = "ToleranciaSupDefecto";
		}

	}

}
