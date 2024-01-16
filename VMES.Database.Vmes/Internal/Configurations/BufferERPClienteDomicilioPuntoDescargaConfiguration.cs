using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BufferERPClienteDomicilioPuntoDescargaConfiguration : IEntityTypeConfiguration<BufferERPClienteDomicilioPuntoDescarga>
	{

		public void Configure(EntityTypeBuilder<BufferERPClienteDomicilioPuntoDescarga> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.FechaInsercion)
				.HasDefaultValueSql("(getdate())");
			entityTypeBuilder.HasOne(x => x.idDomicilioNavigation)
				.WithMany(x => x.BufferERPClienteDomicilioPuntoDescarga)
				.HasForeignKey(x => x.idDomicilio)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK_BufferERPClienteDomicilioPuntoDescarga_BufferERPClientesDomicilios");
		}

	}

}
