using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Obsolete]
	public class GMAO_ElementosTipos
	{

		[Key]
		public int id { get; set; }

		[StringLength(250)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string Referencia { get; set; }

		public string Descripcion { get; set; }

		public string Observaciones { get; set; }

		public int? ProveedorHabitual { get; set; }

		[ForeignKey(nameof(ProveedorHabitual))]
		[InverseProperty(nameof(GMAO_Proveedores.GMAO_ElementosTipos))]
		public virtual GMAO_Proveedores ProveedorHabitualNavigation { get; set; }

		[InverseProperty(nameof(Models.GMAO_Archivos_Tipos.idTipoElementoNavigation))]
		public virtual ICollection<GMAO_Archivos_Tipos> GMAO_Archivos_Tipos { get; set; } = new HashSet<GMAO_Archivos_Tipos>();

		[InverseProperty(nameof(Models.GMAO_CaracteristicasTipos.idTipoElementoNavigation))]
		public virtual ICollection<GMAO_CaracteristicasTipos> GMAO_CaracteristicasTipos { get; set; } = new HashSet<GMAO_CaracteristicasTipos>();

		[InverseProperty(nameof(Models.GMAO_Elementos.TipoNavigation))]
		public virtual ICollection<GMAO_Elementos> GMAO_Elementos { get; set; } = new HashSet<GMAO_Elementos>();

		[InverseProperty(nameof(Models.GMAO_ElementosTiposModelos.idTipoNavigation))]
		public virtual ICollection<GMAO_ElementosTiposModelos> GMAO_ElementosTiposModelos { get; set; } = new HashSet<GMAO_ElementosTiposModelos>();

	}

}
