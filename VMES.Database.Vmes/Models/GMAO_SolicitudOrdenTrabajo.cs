using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_SolicitudOrdenTrabajo
	{

		[Key]
		public int Id { get; set; }

		public int CreadaPorId { get; set; }

		[StringLength(1024)]
		public string Descripcion { get; set; }

		public int ElementoId { get; set; }

		public byte Estado { get; set; }

		public int? GestionadaPorId { get; set; }

		public DateTime Creada { get; set; }

		[ForeignKey(nameof(CreadaPorId))]
		[InverseProperty(nameof(Usuarios.GMAO_SolicitudOrdenTrabajoCreadaPor))]
		public virtual Usuarios CreadaPor { get; set; }

		[ForeignKey(nameof(ElementoId))]
		[InverseProperty(nameof(GMAO_Elementos.GMAO_SolicitudOrdenTrabajo))]
		public virtual GMAO_Elementos Elemento { get; set; }

		[ForeignKey(nameof(GestionadaPorId))]
		[InverseProperty(nameof(Usuarios.GMAO_SolicitudOrdenTrabajoGestionadaPor))]
		public virtual Usuarios GestionadaPor { get; set; }

	}

}
