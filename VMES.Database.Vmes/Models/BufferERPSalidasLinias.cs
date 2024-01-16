using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class BufferERPSalidasLinias
	{

		[Key]
		public int id { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FImportado { get; set; }

		public bool? Preparado { get; set; }

		public bool? Tratado { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FTratado { get; set; }

		[StringLength(1000)]
		public string Errores { get; set; }

		public int? idSalidas { get; set; }

		[StringLength(50)]
		public string RefProducto { get; set; }

		public int? idFormato { get; set; }

		[StringLength(50)]
		public string RefEnvase { get; set; }

		public int? idUnidad { get; set; }

		[StringLength(50)]
		public string RefDomicilio { get; set; }

		public int? Origen1 { get; set; }

		public int? Origen2 { get; set; }

		public int? Origen3 { get; set; }

		public int? Origen4 { get; set; }

		public bool? FueraCajon { get; set; }

		public bool? Cajon1 { get; set; }

		public bool? Cajon2 { get; set; }

		public bool? Cajon3 { get; set; }

		public bool? Cajon4 { get; set; }

		public bool? Cajon5 { get; set; }

		public bool? Cajon6 { get; set; }

		public bool? Cajon7 { get; set; }

		public bool? Cajon8 { get; set; }

		public bool? Cajon9 { get; set; }

		public bool? Cajon10 { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Bultos { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Bruto { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Tara { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioUnidad { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? Cantidad { get; set; }

		public int? idviajes { get; set; }

		public int? idmodulo { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? Fecha { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? Precio { get; set; }

		[Column(TypeName = "numeric(18, 6)")]
		public decimal? PrecioTransporte { get; set; }

		[StringLength(250)]
		public string Observaciones { get; set; }

		[StringLength(20)]
		public string RefERPUnidades { get; set; }

		[StringLength(20)]
		public string RefERPFormatos { get; set; }

		[StringLength(20)]
		public string RefERPEnvases { get; set; }

		[StringLength(50)]
		public string Origen1Nombre { get; set; }

		[StringLength(50)]
		public string Origen2Nombre { get; set; }

		[StringLength(50)]
		public string Origen3Nombre { get; set; }

		[StringLength(50)]
		public string Origen4Nombre { get; set; }

		public int? idViajeMES { get; set; }

		[StringLength(20)]
		public string RefPedidoERP { get; set; }

		[StringLength(50)]
		public string ModuloNombre { get; set; }

		[StringLength(20)]
		public string RefPuntoDescarga { get; set; }

		public int? idSalidaMes { get; set; }

		public int? idLiniaMes { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaInsercion { get; set; }

		public int? idSerie { get; set; }

		[StringLength(20)]
		public string NombreSerie { get; set; }

		[StringLength(20)]
		public string RefVenta { get; set; }

		public int? NumLineaVenta { get; set; }

		[Column(TypeName = "numeric(18, 3)")]
		public decimal? Neto { get; set; }

		public int? idDomicilio { get; set; }

		[StringLength(50)]
		public string NombreDomicilio { get; set; }

		public int? NumLineaViaje { get; set; }

		[ForeignKey(nameof(idSalidas))]
		[InverseProperty(nameof(BufferERPSalidas.BufferERPSalidasLinias))]
		public virtual BufferERPSalidas idSalidasNavigation { get; set; }

		[ForeignKey(nameof(idviajes))]
		[InverseProperty(nameof(BufferERPSalidasViajes.BufferERPSalidasLinias))]
		public virtual BufferERPSalidasViajes idviajesNavigation { get; set; }

		[InverseProperty(nameof(Models.BufferERPSalidasLinMedicamentos.idSalidasLiniaNavigation))]
		public virtual ICollection<BufferERPSalidasLinMedicamentos> BufferERPSalidasLinMedicamentos { get; set; } = new HashSet<BufferERPSalidasLinMedicamentos>();

		[InverseProperty(nameof(Models.BufferERPSalidasLiniasLote.idLineaSalidaNavigation))]
		public virtual ICollection<BufferERPSalidasLiniasLote> BufferERPSalidasLiniasLote { get; set; } = new HashSet<BufferERPSalidasLiniasLote>();

	}

}
