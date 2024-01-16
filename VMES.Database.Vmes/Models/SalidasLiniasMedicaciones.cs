using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class SalidasLiniasMedicaciones
	{

		[Key]
		public int id { get; set; }

		public int idSalidaLinia { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal Cantidad { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal? Bultos { get; set; }

		public int IdUnidad { get; set; }

		public int? idFormato { get; set; }

		public int? idEnvase { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal? PrecioUnidad { get; set; }

		public int? Estado { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal? Precio { get; set; }

		public DateTime? Fecha { get; set; }

		public int? idOrigen { get; set; }

		public int ProductoId { get; set; }

		[ForeignKey(nameof(IdUnidad))]
		[InverseProperty(nameof(Unidades.SalidasLiniasMedicaciones))]
		public virtual Unidades IdUnidadNavigation { get; set; }

		[ForeignKey(nameof(idEnvase))]
		[InverseProperty(nameof(Envases.SalidasLiniasMedicaciones))]
		public virtual Envases idEnvaseNavigation { get; set; }

		[ForeignKey(nameof(idFormato))]
		[InverseProperty(nameof(Formatos.SalidasLiniasMedicaciones))]
		public virtual Formatos idFormatoNavigation { get; set; }

		[ForeignKey(nameof(idOrigen))]
		[InverseProperty(nameof(Ubicaciones.SalidasLiniasMedicaciones))]
		public virtual Ubicaciones idOrigenNavigation { get; set; }

		[ForeignKey(nameof(idSalidaLinia))]
		[InverseProperty(nameof(SalidasLinias.SalidasLiniasMedicaciones))]
		public virtual SalidasLinias idSalidaLiniaNavigation { get; set; }

		[ForeignKey(nameof(ProductoId))]
		[InverseProperty(nameof(Productos.SalidasLiniasMedicaciones))]
		public virtual Productos ProductoNavigation { get; set; }

		[InverseProperty(nameof(Models.SalidasLiniasLote.idLineaSalidaMedicamentoNavigation))]
		public virtual ICollection<SalidasLiniasLote> SalidasLiniasLote { get; set; } = new HashSet<SalidasLiniasLote>();

		[InverseProperty(nameof(Models.StocksReserva.idSalidasLineasMedicNavigation))]
		public virtual ICollection<StocksReserva> StocksReserva { get; set; } = new HashSet<StocksReserva>();

	}

}
