using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_Archivos_Intervenciones
	{

		[Key]
		public int idIntervencion { get; set; }

		[Key]
		public int idArchivo { get; set; }

		[ForeignKey(nameof(idArchivo))]
		[InverseProperty(nameof(GMAO_Archivos.GMAO_Archivos_Intervenciones))]
		public virtual GMAO_Archivos idArchivoNavigation { get; set; }

		[ForeignKey(nameof(idIntervencion))]
		[InverseProperty(nameof(GMAO_ElemIntervenciones.GMAO_Archivos_Intervenciones))]
		public virtual GMAO_ElemIntervenciones idIntervencionNavigation { get; set; }

	}

}
