using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_Archivos_Elementos
	{

		[Key]
		public int idElemento { get; set; }

		[Key]
		public int idArchivo { get; set; }

		[ForeignKey(nameof(idArchivo))]
		[InverseProperty(nameof(GMAO_Archivos.GMAO_Archivos_Elementos))]
		public virtual GMAO_Archivos idArchivoNavigation { get; set; }

		[ForeignKey(nameof(idElemento))]
		[InverseProperty(nameof(GMAO_Elementos.GMAO_Archivos_Elementos))]
		public virtual GMAO_Elementos idElementoNavigation { get; set; }

	}

}
