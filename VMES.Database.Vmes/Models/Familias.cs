using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Familias
	{

		[Key]
		public int Id { get; set; }

		[StringLength(20)]
		public string Referencia { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		public int? Departamento { get; set; }

		public int? Analisi { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[Obsolete]
		public int? idOld { get; set; }

		[ForeignKey(nameof(Analisi))]
		[InverseProperty(nameof(Analisis.Familias))]
		public virtual Analisis AnalisiNavigation { get; set; }

		[ForeignKey(nameof(Departamento))]
		[InverseProperty(nameof(Departamentos.Familias))]
		public virtual Departamentos DepartamentoNavigation { get; set; }

		[InverseProperty(nameof(Models.Dominios.FamiliaNavigation))]
		public virtual ICollection<Dominios> Dominios { get; set; } = new HashSet<Dominios>();

		[InverseProperty(nameof(Models.Formulas.FamiliaNavigation))]
		public virtual ICollection<Formulas> Formulas { get; set; } = new HashSet<Formulas>();

		[InverseProperty(nameof(Models.Productos.FamiliaNavigation))]
		public virtual ICollection<Productos> Productos { get; set; } = new HashSet<Productos>();

	}

}
