using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BufferERPClientesDomiciliosConfiguration : IEntityTypeConfiguration<BufferERPClientesDomicilios>
	{

		public void Configure(EntityTypeBuilder<BufferERPClientesDomicilios> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.FechaInsercion)
				.HasDefaultValueSql("(getdate())");
			entityTypeBuilder.HasOne(x => x.idClienteNavigation)
				.WithMany(x => x.BufferERPClientesDomicilios)
				.HasForeignKey(x => x.idCliente)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK_BufferERPClientesDomicilios_BufferERPClientes");
		}

	}

}
