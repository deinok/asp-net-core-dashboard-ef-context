using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class EnlaceERP
	{

		[Key]
		public int id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? idEnlaceERPTipo { get; set; }

		public int? FormatoFichero { get; set; }

		public bool? TamFijo { get; set; }

		public int? Separador { get; set; }

		public int? SeparadorDecimal { get; set; }

		[StringLength(10)]
		public string SeparadorPersonalizado { get; set; }

		[StringLength(50)]
		public string NombreTablaXML { get; set; }

		public bool? Automatico { get; set; }

		[StringLength(250)]
		public string Carpeta { get; set; }

		[StringLength(50)]
		public string NombreFichero { get; set; }

		public bool? CualquierFichero { get; set; }

		public int? DependienteDe { get; set; }

		public bool? NombreFicheroDepIgual { get; set; }

		[StringLength(50)]
		public string NombreFicheroDepPre { get; set; }

		[StringLength(50)]
		public string NombreFicheroDepPost { get; set; }

		public bool? EjecutarDependientePrimero { get; set; }

		public bool? FicheroEmpiezaPor { get; set; }

		public bool? IgnorarCabecera { get; set; }

		public bool? Manual { get; set; }

		public bool? Activo { get; set; }

		public bool? ImportarMP { get; set; }

		public bool? EliminarFichero { get; set; }

		public bool? DependenciaEstricta { get; set; }

		public int? NumDecimales { get; set; }

		[ForeignKey(nameof(idEnlaceERPTipo))]
		[InverseProperty(nameof(EnlaceERPTipo.EnlaceERP))]
		public virtual EnlaceERPTipo idEnlaceERPTipoNavigation { get; set; }

		[InverseProperty(nameof(Models.EnlaceERPLinea.idEnlaceERPNavigation))]
		public virtual ICollection<EnlaceERPLinea> EnlaceERPLinea { get; set; } = new HashSet<EnlaceERPLinea>();

	}

}
