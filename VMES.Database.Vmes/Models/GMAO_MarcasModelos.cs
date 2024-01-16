using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_MarcasModelos
	{

		[Key]
		public int id { get; set; }

		public int idMarca { get; set; }

		[Required]
		[StringLength(64)]
		public string Nombre { get; set; }

		[StringLength(13)]
		public string EAN13 { get; set; }

		[StringLength(1024)]
		public string Descripcion { get; set; }

		[StringLength(1024)]
		public string Observaciones { get; set; }

		[ForeignKey(nameof(idMarca))]
		[InverseProperty(nameof(GMAO_Marcas.GMAO_MarcasModelos))]
		public virtual GMAO_Marcas idMarcaNavigation { get; set; }

		[InverseProperty(nameof(Models.GMAO_Archivos_Modelos.idModeloNavigation))]
		public virtual ICollection<GMAO_Archivos_Modelos> GMAO_Archivos_Modelos { get; set; } = new HashSet<GMAO_Archivos_Modelos>();

		[InverseProperty(nameof(Models.GMAO_ElemStocks.IdModeloNavigation))]
		public virtual ICollection<GMAO_ElemStocks> GMAO_ElemStocks { get; set; } = new HashSet<GMAO_ElemStocks>();

		[InverseProperty(nameof(Models.GMAO_Elementos.Modelo))]
		public virtual ICollection<GMAO_Elementos> GMAO_Elementos { get; set; } = new HashSet<GMAO_Elementos>();

		[InverseProperty(nameof(Models.GMAO_ElementosTiposModelos.idModeloNavigation))]
		public virtual ICollection<GMAO_ElementosTiposModelos> GMAO_ElementosTiposModelos { get; set; } = new HashSet<GMAO_ElementosTiposModelos>();

		[InverseProperty(nameof(Models.GMAO_WarehouseStocks.Model))]
		public virtual ICollection<GMAO_WarehouseStocks> GMAO_WarehouseStocks { get; set; } = new HashSet<GMAO_WarehouseStocks>();

	}

}
