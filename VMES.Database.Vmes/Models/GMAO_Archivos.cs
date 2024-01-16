using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_Archivos
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public string Descripcion { get; set; }

		public int? Tipo { get; set; }

		[StringLength(50)]
		public string NombreArchivoOriginal { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaSubida { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? UltimaModificacion { get; set; }

		public int? IdUsuario { get; set; }

		public Guid? CMMSFileId { get; set; }

		[InverseProperty(nameof(Models.GMAO_Archivos_Elementos.idArchivoNavigation))]
		public virtual ICollection<GMAO_Archivos_Elementos> GMAO_Archivos_Elementos { get; set; } = new HashSet<GMAO_Archivos_Elementos>();

		[InverseProperty(nameof(Models.GMAO_Archivos_Intervenciones.idArchivoNavigation))]
		public virtual ICollection<GMAO_Archivos_Intervenciones> GMAO_Archivos_Intervenciones { get; set; } = new HashSet<GMAO_Archivos_Intervenciones>();

		[InverseProperty(nameof(Models.GMAO_Archivos_Modelos.idArchivoNavigation))]
		public virtual ICollection<GMAO_Archivos_Modelos> GMAO_Archivos_Modelos { get; set; } = new HashSet<GMAO_Archivos_Modelos>();

		[InverseProperty(nameof(Models.GMAO_Archivos_Tipos.idArchivoNavigation))]
		public virtual ICollection<GMAO_Archivos_Tipos> GMAO_Archivos_Tipos { get; set; } = new HashSet<GMAO_Archivos_Tipos>();

	}

}
