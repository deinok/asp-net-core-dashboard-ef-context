using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class NetAlarmas
	{

		[Key]
		public int Id { get; set; }

		public int? IdPlc { get; set; }

		public int? idOrden { get; set; }

		public int? idDosificacion { get; set; }

		public int? idMedidor { get; set; }

		public int? IdModulo { get; set; }

		[StringLength(250)]
		public string TextoOpcional { get; set; }

		public int? IdError { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaError { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaRecibido { get; set; }

		public int? Respuesta { get; set; }

		[StringLength(250)]
		public string RespPC { get; set; }

		[StringLength(250)]
		public string RespUsuario { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? RespFecha { get; set; }

		[StringLength(250)]
		public string RespTxt { get; set; }

		[StringLength(250)]
		public string txtError { get; set; }

		[StringLength(250)]
		public string Opcion1 { get; set; }

		[StringLength(250)]
		public string Opcion2 { get; set; }

		[StringLength(250)]
		public string Opcion4 { get; set; }

		[StringLength(250)]
		public string Opcion3 { get; set; }

		public bool Tratada { get; set; }

		public bool Visualizada { get; set; }

		public int? idUbicacion { get; set; }

		public bool Finalizada { get; set; }

		public int? IdSeccion { get; set; }

		public int? IdGrupo { get; set; }

		public int? Ciclo_Num { get; set; }

		public int? IdOrigen { get; set; }

		public int? IdDestino { get; set; }

		public int? IdOrigenPropuesto { get; set; }

		public int? IdDestinoPropuesto { get; set; }

		public int? Ciclo_NumPropuesto { get; set; }

		public bool? RequiereRespuesta { get; set; }

		public bool? ConsultarScada { get; set; }

		public int? InfoAdicScada { get; set; }

		public int? ArgumentoPropuesto { get; set; }

		public bool? Enviada { get; set; }

		[StringLength(20)]
		public string TextoAdicional { get; set; }

		public int? FechaErrorMilisegundos { get; set; }

		public bool? Respondido { get; set; }

		public int? RespIdOrigen { get; set; }

		public int? RespIdDestino { get; set; }

		public int? RespNumCiclos { get; set; }

		public int? RespIdOrden { get; set; }

		[Column(TypeName = "decimal(15, 5)")]
		public decimal? RespArgumentos0 { get; set; }

		[Column(TypeName = "decimal(15, 5)")]
		public decimal? RespArgumentos1 { get; set; }

		[Column(TypeName = "decimal(15, 5)")]
		public decimal? RespArgumentos2 { get; set; }

		[Column(TypeName = "decimal(15, 5)")]
		public decimal? RespArgumentos3 { get; set; }

		[Column(TypeName = "decimal(15, 5)")]
		public decimal? RespVariables0 { get; set; }

		[Column(TypeName = "decimal(15, 5)")]
		public decimal? RespVariables1 { get; set; }

		[Column(TypeName = "decimal(15, 5)")]
		public decimal? RespVariables2 { get; set; }

		[Column(TypeName = "decimal(15, 5)")]
		public decimal? RespVariables3 { get; set; }

		[Column(TypeName = "decimal(15, 5)")]
		public decimal? RespVariables4 { get; set; }

		public int? RespIdProducto { get; set; }

		public int? RespIdLote { get; set; }

		public bool? Interno { get; set; }

		public NetAlarmasInternalType? TipoInterno { get; set; }

		public int? PesadaNum { get; set; }

		public bool? MostrarAUsuario { get; set; }

		public bool? Deshabilitada { get; set; }

		[Column(TypeName = "numeric(18, 8)")]
		public decimal? InfoAdicional1 { get; set; }

		[Column(TypeName = "numeric(18, 8)")]
		public decimal? InfoAdicional2 { get; set; }

		[Column(TypeName = "numeric(18, 8)")]
		public decimal? InfoAdicional3 { get; set; }

		[Column(TypeName = "numeric(18, 8)")]
		public decimal? InfoAdicional4 { get; set; }

		[Column(TypeName = "numeric(18, 8)")]
		public decimal? InfoAdicional5 { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? FechaErrorMES { get; set; }

		public int? idMotor { get; set; }

		[Obsolete] public int? idOpc { get; set; }

		public bool? RevisadoAlertas { get; set; }

		public bool? AlertaGestionada { get; set; }

		[StringLength(32)]
		public string Hash { get; set; }

		public int? OpcConfigId { get; set; }

		public bool PostEnvioProcesada { get; set; }

		[ForeignKey(nameof(IdDestino))]
		[InverseProperty(nameof(Ubicaciones.NetAlarmasIdDestinoNavigation))]
		public virtual Ubicaciones IdDestinoNavigation { get; set; }

		[ForeignKey(nameof(IdDestinoPropuesto))]
		[InverseProperty(nameof(Ubicaciones.NetAlarmasIdDestinoPropuestoNavigation))]
		public virtual Ubicaciones IdDestinoPropuestoNavigation { get; set; }

		[ForeignKey(nameof(IdError))]
		[InverseProperty(nameof(NetAlarmasTipos.NetAlarmas))]
		public virtual NetAlarmasTipos IdErrorNavigation { get; set; }

		[ForeignKey(nameof(IdGrupo))]
		[InverseProperty(nameof(SeccionesGrupos.NetAlarmas))]
		public virtual SeccionesGrupos IdGrupoNavigation { get; set; }

		[ForeignKey(nameof(IdModulo))]
		[InverseProperty(nameof(Modulos.NetAlarmas))]
		public virtual Modulos IdModuloNavigation { get; set; }

		[ForeignKey(nameof(IdOrigen))]
		[InverseProperty(nameof(Ubicaciones.NetAlarmasIdOrigenNavigation))]
		public virtual Ubicaciones IdOrigenNavigation { get; set; }

		[ForeignKey(nameof(IdOrigenPropuesto))]
		[InverseProperty(nameof(Ubicaciones.NetAlarmasIdOrigenPropuestoNavigation))]
		public virtual Ubicaciones IdOrigenPropuestoNavigation { get; set; }

		[ForeignKey(nameof(IdSeccion))]
		[InverseProperty(nameof(Secciones.NetAlarmas))]
		public virtual Secciones IdSeccionNavigation { get; set; }

		[ForeignKey(nameof(OpcConfigId))]
		[InverseProperty(nameof(Models.OpcConfig.NetAlarmas))]
		public virtual OpcConfig OpcConfig { get; set; }

		[ForeignKey(nameof(RespIdLote))]
		[InverseProperty(nameof(Lotes.NetAlarmas))]
		public virtual Lotes RespIdLoteNavigation { get; set; }

		[ForeignKey(nameof(RespIdProducto))]
		[InverseProperty(nameof(Productos.NetAlarmas))]
		public virtual Productos RespIdProductoNavigation { get; set; }

		[ForeignKey(nameof(Respuesta))]
		[InverseProperty(nameof(NetAlarmasRespuestas.NetAlarmas))]
		public virtual NetAlarmasRespuestas RespuestaNavigation { get; set; }

		[ForeignKey(nameof(idDosificacion))]
		[InverseProperty(nameof(Dosificaciones.NetAlarmas))]
		public virtual Dosificaciones idDosificacionNavigation { get; set; }

		[ForeignKey(nameof(idMedidor))]
		[InverseProperty(nameof(Medidor.NetAlarmas))]
		public virtual Medidor idMedidorNavigation { get; set; }

		[ForeignKey(nameof(idOrden))]
		[InverseProperty(nameof(Ordenes.NetAlarmas))]
		public virtual Ordenes idOrdenNavigation { get; set; }

		[ForeignKey(nameof(idUbicacion))]
		[InverseProperty(nameof(Ubicaciones.NetAlarmasidUbicacionNavigation))]
		public virtual Ubicaciones idUbicacionNavigation { get; set; }

	}

}
