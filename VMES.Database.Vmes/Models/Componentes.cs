using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	public class Componentes
	{

		[Key]
		public int Id { get; set; }

		public int Version { get; set; }

		public int? Producto { get; set; }

		public float? Porcentaje { get; set; }

		public float? Cantidad { get; set; }

		public int? Unidad { get; set; }

		public int? Tipo { get; set; }

		public int? Grupo { get; set; }

		public int? Formato { get; set; }

		public bool? Importado { get; set; }

		public bool? Automatico { get; set; }

		public DosificacionType? TipoDosificacion { get; set; }

		public int? Modulo { get; set; }

		public int? Medidor { get; set; }

		public int? Orden { get; set; }

		public bool? Exportado { get; set; }

		public int? idOld { get; set; }

		[Column(TypeName = "numeric(18, 2)")]
		public decimal? ToleranciaSuperior { get; set; }

		[Column(TypeName = "numeric(18, 2)")]
		public decimal? ToleranciaInferior { get; set; }

		public bool? PausaPosteriorDosificacion { get; set; }

		public bool? DosificarProductoAnterior { get; set; }

		public int? OperTiempo { get; set; }

		public int? OperMotor { get; set; }

		public int? OperAccion { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? OperVariable { get; set; }

		[StringLength(250)]
		public string TextoVariable { get; set; }

		public int? idPlantilla { get; set; }

		[Column(TypeName = "numeric(15, 3)")]
		public decimal? OperVariable2 { get; set; }

		public int? IdTempControl { get; set; }

		public int? TempModo { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? MinAlarma { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? MaxAlarma { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? Consigna { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? Histeresys { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? ConsignaPausa { get; set; }

		[Column(TypeName = "decimal(9, 4)")]
		public decimal? ZonaMuerta { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? DosiVariable1 { get; set; }

		[Column(TypeName = "decimal(18, 3)")]
		public decimal? DosiVariable2 { get; set; }

		[ForeignKey(nameof(Formato))]
		[InverseProperty(nameof(Formatos.Componentes))]
		public virtual Formatos FormatoNavigation { get; set; }

		[ForeignKey(nameof(IdTempControl))]
		[InverseProperty(nameof(TempControles.Componentes))]
		public virtual TempControles IdTempControlNavigation { get; set; }

		[ForeignKey(nameof(Medidor))]
		[InverseProperty(nameof(Models.Medidor.Componentes))]
		public virtual Medidor MedidorNavigation { get; set; }

		[ForeignKey(nameof(Modulo))]
		[InverseProperty(nameof(Modulos.Componentes))]
		public virtual Modulos ModuloNavigation { get; set; }

		[ForeignKey(nameof(OperAccion))]
		[InverseProperty(nameof(OperAcciones.Componentes))]
		public virtual OperAcciones OperAccionNavigation { get; set; }

		[ForeignKey(nameof(OperMotor))]
		[InverseProperty(nameof(OperMotores.Componentes))]
		public virtual OperMotores OperMotorNavigation { get; set; }

		[ForeignKey(nameof(Producto))]
		[InverseProperty(nameof(Productos.Componentes))]
		public virtual Productos ProductoNavigation { get; set; }

		[ForeignKey(nameof(Unidad))]
		[InverseProperty(nameof(Unidades.Componentes))]
		public virtual Unidades UnidadNavigation { get; set; }

		[ForeignKey(nameof(Version))]
		[InverseProperty(nameof(Versiones.Componentes))]
		public virtual Versiones VersionNavigation { get; set; }

		[ForeignKey(nameof(idPlantilla))]
		[InverseProperty(nameof(OperCabPlantillas.Componentes))]
		public virtual OperCabPlantillas idPlantillaNavigation { get; set; }

	}

}
