using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BufferERPClientesConfiguration : IEntityTypeConfiguration<BufferERPClientes>
	{

		public void Configure(EntityTypeBuilder<BufferERPClientes> entityTypeBuilder)
		{
			entityTypeBuilder.Property(x => x.FechaInsercion)
				.HasDefaultValueSql("(getdate())");
		}

	}

}
