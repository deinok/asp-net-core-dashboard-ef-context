using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Formulas
	{

		[Key]
		public int Id { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? Medida { get; set; }

		public float? Total { get; set; }

		public int? Producto { get; set; }

		public int? Formato { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public FormulaState? Estado { get; set; }

		public bool? Importado { get; set; }

		public int? Familia { get; set; }

		public int? Departamento { get; set; }

		public int? Original { get; set; }

		public int? Modulo { get; set; }

		public float? Mezclas { get; set; }

		public bool? Recalculado { get; set; }

		public bool? Exportado { get; set; }

		public bool? Medicamento { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaFin { get; set; }

		[StringLength(20)]
		public string idRefERP { get; set; }

		[Obsolete]
		public int? idOld { get; set; }

		public bool IsDeleted { get; set; }

		[ForeignKey(nameof(Departamento))]
		[InverseProperty(nameof(Departamentos.Formulas))]
		public virtual Departamentos DepartamentoNavigation { get; set; }

		[ForeignKey(nameof(Familia))]
		[InverseProperty(nameof(Familias.Formulas))]
		public virtual Familias FamiliaNavigation { get; set; }

		[ForeignKey(nameof(Modulo))]
		[InverseProperty(nameof(Modulos.Formulas))]
		public virtual Modulos ModuloNavigation { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Productos.Formulas))]
		public virtual Productos ProductoNavigation { get; set; }

		[InverseProperty(nameof(Models.CabOrdenes.FormulaNavigation))]
		public virtual ICollection<CabOrdenes> CabOrdenes { get; set; } = new HashSet<CabOrdenes>();

		[InverseProperty(nameof(Models.Formularios.FormulaNavigation))]
		public virtual ICollection<Formularios> Formularios { get; set; } = new HashSet<Formularios>();

		[InverseProperty(nameof(Models.Incompatibilidades.FormulaNavigation))]
		public virtual ICollection<Incompatibilidades> Incompatibilidades { get; set; } = new HashSet<Incompatibilidades>();

		[InverseProperty(nameof(Models.Ordenes.FormulaNavigation))]
		public virtual ICollection<Ordenes> Ordenes { get; set; } = new HashSet<Ordenes>();

		[InverseProperty(nameof(Models.Versiones.FormulaNavigation))]
		public virtual ICollection<Versiones> Versiones { get; set; } = new HashSet<Versiones>();

	}

}
