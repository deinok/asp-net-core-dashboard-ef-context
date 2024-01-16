using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_Archivos_Tipos
	{

		[Key]
		public int idTipoElemento { get; set; }

		[Key]
		public int idArchivo { get; set; }

		[ForeignKey(nameof(idArchivo))]
		[InverseProperty(nameof(GMAO_Archivos.GMAO_Archivos_Tipos))]
		public virtual GMAO_Archivos idArchivoNavigation { get; set; }

		[ForeignKey(nameof(idTipoElemento))]
		[InverseProperty(nameof(GMAO_ElementosTipos.GMAO_Archivos_Tipos))]
		public virtual GMAO_ElementosTipos idTipoElementoNavigation { get; set; }

	}

}
