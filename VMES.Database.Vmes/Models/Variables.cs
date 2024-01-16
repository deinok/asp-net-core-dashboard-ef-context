using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Variables
	{

		[Key]
		public int Id { get; set; }

		public int Modulo { get; set; }

		[StringLength(50)]
		public string Nombre { get; set; }

		[StringLength(50)]
		public string ValorPlc { get; set; }

		public float? Defecto { get; set; }

		public int? Unidad { get; set; }

		public float? Minimo { get; set; }

		public float? Maximo { get; set; }

		public bool? Modificable { get; set; }

		public bool? Importado { get; set; }

		public bool? Exportado { get; set; }

		[StringLength(50)]
		public string ValorPartePlc { get; set; }

		public int? Producto { get; set; }

		public int? Ubicacion { get; set; }

		public bool? RegistrarEnParte { get; set; }

		public bool? RegularizarStock { get; set; }

		public int? idOld { get; set; }

		[ForeignKey(nameof(Modulo))]
		[InverseProperty(nameof(Modulos.Variables))]
		public virtual Modulos ModuloNavigation { get; set; }

		[InverseProperty(nameof(Models.Valores.VariableNavigation))]
		public virtual ICollection<Valores> Valores { get; set; } = new HashSet<Valores>();

	}

}
