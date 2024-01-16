using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class BackupsConfiguration : IEntityTypeConfiguration<Backups>
	{

		public void Configure(EntityTypeBuilder<Backups> entityTypeBuilder)
		{
			entityTypeBuilder.HasIndex(x => x.HayError)
				.HasName("_dta_index_Backups_1");
		}

	}

}
