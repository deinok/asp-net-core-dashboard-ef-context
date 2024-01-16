using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Recetas
	{

		[Key]
		public int id { get; set; }

		public int? idCliente { get; set; }

		public int? idDomicilio { get; set; }

		public int? idAfeccion { get; set; }

		public int? NumReceta { get; set; }

		public int? idSerie { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		public int? idSalidaLinea { get; set; }

		[StringLength(254)]
		public string Indicaciones { get; set; }

		public int? Frecuencia { get; set; }

		public int? Duracion { get; set; }

		public int? TiempoEspera { get; set; }

		public int? Conservacion { get; set; }

		[StringLength(254)]
		public string Observaciones { get; set; }

		[StringLength(254)]
		public string NaturalezaTratamiento { get; set; }

		public int? TiempoEsperaLeche { get; set; }

		public int? TiempoEsperaHuevos { get; set; }

		[StringLength(254)]
		public string NumRegistro { get; set; }

		public int? idVeterinario { get; set; }

		public int? idProducto { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? CantidadPienso { get; set; }

		[Column(TypeName = "decimal(8, 3)")]
		public decimal? proporcionDiaria { get; set; }

		public bool? AutoGenerada { get; set; }

		public int? MedicacionId { get; set; }

		public int? EspecieId { get; set; }

		public RecetaStatus Estado { get; set; }

		[ForeignKey(nameof(idAfeccion))]
		[InverseProperty(nameof(Afecciones.Recetas))]
		public virtual Afecciones idAfeccionNavigation { get; set; }

		[ForeignKey(nameof(idCliente))]
		[InverseProperty(nameof(Clientes.Recetas))]
		public virtual Clientes idClienteNavigation { get; set; }

		[ForeignKey(nameof(idDomicilio))]
		[InverseProperty(nameof(Domicilios.Recetas))]
		public virtual Domicilios idDomicilioNavigation { get; set; }

		[ForeignKey(nameof(EspecieId))]
		[InverseProperty(nameof(Especies.Recetas))]
		public virtual Especies EspecieNavigation { get; set; }

		[ForeignKey(nameof(MedicacionId))]
		[InverseProperty(nameof(Medicaciones.Recetas))]
		public virtual Medicaciones MedicacionNavigation { get; set; }

		[ForeignKey(nameof(idProducto))]
		[InverseProperty(nameof(Productos.Recetas))]
		public virtual Productos idProductoNavigation { get; set; }

		[ForeignKey(nameof(idSalidaLinea))]
		[InverseProperty(nameof(SalidasLinias.Recetas))]
		public virtual SalidasLinias idSalidaLineaNavigation { get; set; }

		[ForeignKey(nameof(idSerie))]
		[InverseProperty(nameof(Series.Recetas))]
		public virtual Series idSerieNavigation { get; set; }

		[ForeignKey(nameof(idVeterinario))]
		[InverseProperty(nameof(Veterinarios.Recetas))]
		public virtual Veterinarios idVeterinarioNavigation { get; set; }

		[InverseProperty(nameof(Models.RecetasLineas.idRecetaNavigation))]
		public virtual ICollection<RecetasLineas> RecetasLineas { get; set; } = new HashSet<RecetasLineas>();

	}

}
