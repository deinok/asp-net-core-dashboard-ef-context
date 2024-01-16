using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Etiquetas
	{

		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public string Contenido { get; set; }

		public int? Impresora { get; set; }

		[StringLength(50)]
		public string Inicializacion { get; set; }

		[StringLength(255)]
		public string Archivo { get; set; }

		public int? Tipo { get; set; }

		public int? Copias { get; set; }

		public int? EtiquetaEstilo { get; set; }

		[StringLength(50)]
		public string MarcaInicio { get; set; }

		[StringLength(50)]
		public string MarcaFin { get; set; }

		[StringLength(50)]
		public string MarcaFormato { get; set; }

		[StringLength(50)]
		public string MarcaVariable { get; set; }

		public int? Variable { get; set; }

		public bool? Preliminar { get; set; }

		[StringLength(50)]
		public string MarcaSeparacion { get; set; }

		public int? MacroCodigoBarras { get; set; }

		public int? TamanyoCodigoBarras { get; set; }

		public int? TipoCodigoBarras { get; set; }

		[StringLength(50)]
		public string FuenteCodigoBarras { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[StringLength(50)]
		public string MarcaCampo { get; set; }

		[StringLength(20)]
		public string MarcaPedirArchivo { get; set; }

		public int? Sesion { get; set; }

		[InverseProperty(nameof(Productos.EtiquetaControlNavigation))]
		public virtual ICollection<Productos> ProductosEtiquetaControlNavigation { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Productos.EtiquetaEntradasNavigation))]
		public virtual ICollection<Productos> ProductosEtiquetaEntradasNavigation { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Productos.EtiquetaGranelNavigation))]
		public virtual ICollection<Productos> ProductosEtiquetaGranelNavigation { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Productos.EtiquetaMuestrasNavigation))]
		public virtual ICollection<Productos> ProductosEtiquetaMuestrasNavigation { get; set; } = new HashSet<Productos>();

		[InverseProperty(nameof(Productos.EtiquetaSacosNavigation))]
		public virtual ICollection<Productos> ProductosEtiquetaSacosNavigation { get; set; } = new HashSet<Productos>();

	}

}
