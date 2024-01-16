using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class GMAO_Elementos
	{

		[Key]
		public int id { get; set; }

		[StringLength(64)]
		public string Referencia { get; set; }

		[StringLength(128)]
		public string Nombre { get; set; }

		[StringLength(1024)]
		public string Descripcion { get; set; }

		[StringLength(1024)]
		public string Observaciones { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal? PrecioCosteNuevo { get; set; }

		public int? Tipo { get; set; }

		public bool? IsMaquina { get; set; }

		public bool? IsPieza { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal? HorasUsoActuales { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal? RevisionHoras { get; set; }

		public int? DiasRevision { get; set; }

		public bool? RequiereRevision { get; set; }

		public int? MesesRevision { get; set; }

		public bool? RevisionEnSiguienteParada { get; set; }

		public int? MaxHorasSiguienteRevision { get; set; }

		public int? MaxDiasSiguienteRevision { get; set; }

		public int? OrdenArbol { get; set; }

		public int? idMotor { get; set; }

		public bool CapturarDatos { get; set; }

		public int? ModeloId { get; set; }

		[StringLength(256)]
		public string SerialNumber { get; set; }

		public GmaoElementType Type { get; set; }

		public int? ElementoPadreId { get; set; }

		public int? ElectrovalvulaId { get; set; }

		public byte LinkType { get; set; }

		public DateTime LastReview { get; set; }

		public int TiempoServicio { get; set; }

		public int TiempoServicioDesdeUltimaRevision { get; set; }

		public int TiempoTrabajando { get; set; }

		public int TiempoTrabajandoDesdeUltimaRevision { get; set; }

		public int ContadorAlarmas { get; set; }

		public int ContadorAlarmasDesdeUltimaRevision { get; set; }

		[ForeignKey(nameof(ElectrovalvulaId))]
		[InverseProperty(nameof(Models.Electrovalvula.GMAO_Elementos))]
		public virtual Electrovalvula Electrovalvula { get; set; }

		[ForeignKey(nameof(ElementoPadreId))]
		[InverseProperty(nameof(GMAO_Elementos.InverseElementoPadre))]
		public virtual GMAO_Elementos ElementoPadre { get; set; }

		[ForeignKey(nameof(ModeloId))]
		[InverseProperty(nameof(GMAO_MarcasModelos.GMAO_Elementos))]
		public virtual GMAO_MarcasModelos Modelo { get; set; }

		[ForeignKey(nameof(Tipo))]
		[InverseProperty(nameof(GMAO_ElementosTipos.GMAO_Elementos))]
		public virtual GMAO_ElementosTipos TipoNavigation { get; set; }

		[ForeignKey(nameof(idMotor))]
		[InverseProperty(nameof(Motor.GMAO_Elementos))]
		public virtual Motor idMotorNavigation { get; set; }

		[InverseProperty(nameof(Models.GMAO_ElementReviewSettings.Element))]
		public virtual GMAO_ElementReviewSettings GMAO_ElementReviewSettings { get; set; }

		[InverseProperty(nameof(Models.FileGmaoElement.GmaoElement))]
		public virtual ICollection<FileGmaoElement> FileGmaoElement { get; set; } = new HashSet<FileGmaoElement>();

		[InverseProperty(nameof(Models.GMAO_Archivos_Elementos.idElementoNavigation))]
		public virtual ICollection<GMAO_Archivos_Elementos> GMAO_Archivos_Elementos { get; set; } = new HashSet<GMAO_Archivos_Elementos>();

		[InverseProperty(nameof(Models.GMAO_CaracteristicasElementos.idElementoNavigation))]
		public virtual ICollection<GMAO_CaracteristicasElementos> GMAO_CaracteristicasElementos { get; set; } = new HashSet<GMAO_CaracteristicasElementos>();

		[InverseProperty(nameof(Models.GMAO_ComprasLineas.idElementoNavigation))]
		public virtual ICollection<GMAO_ComprasLineas> GMAO_ComprasLineas { get; set; } = new HashSet<GMAO_ComprasLineas>();

		[InverseProperty(nameof(GMAO_ElemAlternativos.IdHijoNavigation))]
		public virtual ICollection<GMAO_ElemAlternativos> GMAO_ElemAlternativosIdHijoNavigation { get; set; } = new HashSet<GMAO_ElemAlternativos>();

		[InverseProperty(nameof(GMAO_ElemAlternativos.IdPadreNavigation))]
		public virtual ICollection<GMAO_ElemAlternativos> GMAO_ElemAlternativosIdPadreNavigation { get; set; } = new HashSet<GMAO_ElemAlternativos>();

		[InverseProperty(nameof(Models.GMAO_ElemIntervenciones.idElementoNavigation))]
		public virtual ICollection<GMAO_ElemIntervenciones> GMAO_ElemIntervenciones { get; set; } = new HashSet<GMAO_ElemIntervenciones>();

		[InverseProperty(nameof(Models.GMAO_ElemIntervencionesPiezas.Element))]
		public virtual ICollection<GMAO_ElemIntervencionesPiezas> GMAO_ElemIntervencionesPiezas { get; set; } = new HashSet<GMAO_ElemIntervencionesPiezas>();

		[InverseProperty(nameof(GMAO_ElemPertenencia.IdHijoNavigation))]
		public virtual ICollection<GMAO_ElemPertenencia> GMAO_ElemPertenenciaIdHijoNavigation { get; set; } = new HashSet<GMAO_ElemPertenencia>();

		[InverseProperty(nameof(GMAO_ElemPertenencia.IdPadreNavigation))]
		public virtual ICollection<GMAO_ElemPertenencia> GMAO_ElemPertenenciaIdPadreNavigation { get; set; } = new HashSet<GMAO_ElemPertenencia>();

		[InverseProperty(nameof(Models.GMAO_ElemStocks.idElementoNavigation))]
		public virtual ICollection<GMAO_ElemStocks> GMAO_ElemStocks { get; set; } = new HashSet<GMAO_ElemStocks>();

		[InverseProperty(nameof(Models.GMAO_ElementReviewTask.Element))]
		public virtual ICollection<GMAO_ElementReviewTask> GMAO_ElementReviewTasks { get; set; } = new HashSet<GMAO_ElementReviewTask>();

		[InverseProperty(nameof(Models.GMAO_HistStocksYElementos.idElementoNavigation))]
		public virtual ICollection<GMAO_HistStocksYElementos> GMAO_HistStocksYElementos { get; set; } = new HashSet<GMAO_HistStocksYElementos>();

		[InverseProperty(nameof(Models.GMAO_ParadasConfiguracionTareas.idElementoNavigation))]
		public virtual ICollection<GMAO_ParadasConfiguracionTareas> GMAO_ParadasConfiguracionTareas { get; set; } = new HashSet<GMAO_ParadasConfiguracionTareas>();

		[InverseProperty(nameof(Models.GMAO_SolicitudOrdenTrabajo.Elemento))]
		public virtual ICollection<GMAO_SolicitudOrdenTrabajo> GMAO_SolicitudOrdenTrabajo { get; set; } = new HashSet<GMAO_SolicitudOrdenTrabajo>();

		[InverseProperty(nameof(Models.GMAO_WarehouseStocks.Element))]
		public virtual ICollection<GMAO_WarehouseStocks> GMAO_WarehouseStocks { get; set; } = new HashSet<GMAO_WarehouseStocks>();

		[InverseProperty(nameof(GMAO_Elementos.ElementoPadre))]
		public virtual ICollection<GMAO_Elementos> InverseElementoPadre { get; set; } = new HashSet<GMAO_Elementos>();

	}

}
