using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Eventos
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Tabla { get; set; }

		[StringLength(50)]
		public string Campo { get; set; }

		public int? Elemento { get; set; }

		[StringLength(50)]
		public string Accion { get; set; }

		public int? Usuario { get; set; }

		[StringLength(39)]
		public string IP { get; set; }

		[StringLength(12)]
		public string MAC { get; set; }

		[StringLength(50)]
		public string Equipo { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public string Formulario { get; set; }

		[StringLength(1000)]
		public string Observaciones { get; set; }

		[InverseProperty(nameof(Models.EventosDetalle.EventoNavigation))]
		public virtual ICollection<EventosDetalle> EventosDetalle { get; set; } = new HashSet<EventosDetalle>();

	}

}
