using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class UsuariosRolesConfiguration : IEntityTypeConfiguration<UsuariosRoles>
	{

		public void Configure(EntityTypeBuilder<UsuariosRoles> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.AutoRespuestasVer)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.CambioRapidoOPC)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.ComprasEditar)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.ComprasVer)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.Comunicaciones)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.ContratosEditar)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.ContratosVer)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.Copias)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.DashboardVer)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.DesinfeccionEditar)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.DesinfeccionVer)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.ERP)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.EntradasAlmacenEditar)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.EntradasAlmacenVer)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.GMAO)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.Gestion)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.Incompatibilidades)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.Inventarios)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.Laboratorio)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.LotesEditar)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.LotesVer)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.MedicamentosEditar)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.MedicamentosVer)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.ModuloEnergia)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.ModuloOEE)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.OrdenesAConfirmarEditar)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.OrdenesAConfirmarVer)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.OrdenesEditar)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.OrdenesVer)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.PRECabOrdenesProduccion)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PRECabOrdenesSalidasViajes)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.PlantillasEditar)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.PlantillasVer)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.Premezclas)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.Produccion)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.Productividad)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.Quimica)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.RecetasEditar)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.RecetasVer)
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property(x => x.SalidasViajesEditar)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.SalidasViajesVer)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.StocksEditar)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.StocksPestana)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.StocksVer)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.Tarjetas)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.Transito)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.TrazabilidadResumenVer)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.Utilidades)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.VentasEditar)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.VentasVer)
				.HasDefaultValueSql("((1))");
			entityTypeBuilder.Property(x => x.VisorDosificacionesVer)
				.HasDefaultValueSql("((0))");
		}

	}

}
