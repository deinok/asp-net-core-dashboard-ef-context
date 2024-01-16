using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_Archivos_Modelos
	{

		[Key]
		public int idModelo { get; set; }

		[Key]
		public int idArchivo { get; set; }

		[ForeignKey(nameof(idArchivo))]
		[InverseProperty(nameof(GMAO_Archivos.GMAO_Archivos_Modelos))]
		public virtual GMAO_Archivos idArchivoNavigation { get; set; }

		[ForeignKey(nameof(idModelo))]
		[InverseProperty(nameof(GMAO_MarcasModelos.GMAO_Archivos_Modelos))]
		public virtual GMAO_MarcasModelos idModeloNavigation { get; set; }

	}

}
