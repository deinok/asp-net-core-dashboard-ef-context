using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMES.Database.Vmes.Models
{

	[Table("OpcConfig")]
	public class OpcConfig
	{

		[Key]
		public int Id { get; set; }

		[Column("Nombre")]
		[StringLength(64)]
		public string Name { get; set; }

		[Column("Tipo")]
		public OpcConfigType Type { get; set; }

		[Column("Activado")]
		public bool Enabled { get; set; }

		[Obsolete]
		public bool SincUbicaciones { get; set; }

		[Obsolete]
		public bool SincUsuarios { get; set; }

		[Obsolete]
		public int Version { get; set; }

		[Obsolete]
		[StringLength(250)]
		public string Topic { get; set; }

		[Obsolete]
		[StringLength(50)]
		public string OPCIP { get; set; }

		[Obsolete]
		public int? OPCRate { get; set; }

		[Obsolete]
		[StringLength(250)]
		public string OPCNombre { get; set; }

		[Obsolete]
		public bool IsGeneral { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? BitVida { get; set; }

		public int? Calidad { get; set; }

		[Obsolete]
		[StringLength(256)]
		public Uri DiscoveryUrl { get; set; }

		[Column("Endpoint")]
		[StringLength(256)]
		public Uri EndpointUrl { get; set; }

		[StringLength(256)]
		public string DeviceAlias { get; set; }

		[Obsolete]
		public bool IsPrincipal { get; set; }

		[Obsolete]
		public bool Maestro { get; set; }

		public Guid GatewayId { get; set; }

		[ForeignKey(nameof(GatewayId))]
		[InverseProperty(nameof(Models.Gateway.OpcConfig))]
		public virtual Gateway Gateway { get; set; }

		[InverseProperty(nameof(Models.Bascula.OpcConfig))]
		public virtual ICollection<Bascula> Basculas { get; set; } = new HashSet<Bascula>();

		[InverseProperty(nameof(Models.BufferConsumidos.OpcConfig))]
		public virtual ICollection<BufferConsumidos> BufferConsumidos { get; set; } = new HashSet<BufferConsumidos>();

		[InverseProperty(nameof(Models.BufferProducidos.OpcConfig))]
		public virtual ICollection<BufferProducidos> BufferProducidos { get; set; } = new HashSet<BufferProducidos>();

		[InverseProperty(nameof(Models.Electrovalvula.OpcConfig))]
		public virtual ICollection<Electrovalvula> Electrovalvulas { get; set; } = new HashSet<Electrovalvula>();

		[InverseProperty(nameof(Models.Modulos.OpcConfig))]
		public virtual ICollection<Modulos> Modulos { get; set; } = new HashSet<Modulos>();

		[InverseProperty(nameof(Models.Motor.OpcConfig))]
		public virtual ICollection<Motor> Motores { get; set; } = new HashSet<Motor>();

		[InverseProperty(nameof(Models.NetAlarmas.OpcConfig))]
		public virtual ICollection<NetAlarmas> NetAlarmas { get; set; } = new HashSet<NetAlarmas>();

		[InverseProperty(nameof(Models.OperMotores.OpcConfig))]
		public virtual ICollection<OperMotores> OperMotores { get; set; } = new HashSet<OperMotores>();

		[InverseProperty(nameof(Models.Secciones.OpcConfig))]
		public virtual ICollection<Secciones> Secciones { get; set; } = new HashSet<Secciones>();

		[InverseProperty(nameof(Models.SeccionesGrupos.OpcConfig))]
		public virtual ICollection<SeccionesGrupos> SeccionesGrupos { get; set; } = new HashSet<SeccionesGrupos>();

		[InverseProperty(nameof(Models.Tags.OpcConfig))]
		public virtual ICollection<Tags> Tags { get; set; } = new HashSet<Tags>();

		[InverseProperty(nameof(Models.Ubicaciones.OpcConfig))]
		public virtual ICollection<Ubicaciones> Ubicaciones { get; set; } = new HashSet<Ubicaciones>();

		[InverseProperty(nameof(Models.UbicacionesOpcConfig.OpcConfig))]
		public virtual ICollection<UbicacionesOpcConfig> UbicacionesOpcConfig { get; set; } = new HashSet<UbicacionesOpcConfig>();

		[InverseProperty(nameof(Models.Usuarios.IdOpcNavigation))]
		public virtual ICollection<Usuarios> Usuarios { get; set; } = new HashSet<Usuarios>();

	}

}
