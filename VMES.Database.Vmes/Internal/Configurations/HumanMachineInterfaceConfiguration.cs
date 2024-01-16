using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class HumanMachineInterfaceConfiguration : IEntityTypeConfiguration<HumanMachineInterface>
	{

		public void Configure(EntityTypeBuilder<HumanMachineInterface> entityTypeBuilder)
		{
			entityTypeBuilder.HasDiscriminator(x => x.Type)
				.HasValue<HumanMachineInterface>(HumanMachineInterfaceType.Undefined)
				.HasValue<HumanMachineInterface.EntradasSalidasHumanMachineInterface>(HumanMachineInterfaceType.EntradasSalidas)
				.HasValue<HumanMachineInterface.PremezclasHumanMachineInterface>(HumanMachineInterfaceType.Premezclas);
		}

	}

}
