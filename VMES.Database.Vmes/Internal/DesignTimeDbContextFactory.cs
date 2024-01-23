using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VMES.Database.Vmes.Internal
{

	internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<VmesDbContext>
	{

		public VmesDbContext CreateDbContext(string[] args)
		{
			var dbContextOptionsBuilder = new DbContextOptionsBuilder<VmesDbContext>();
			dbContextOptionsBuilder.UseSqlServer("Server=tcp:vmes-production.database.windows.net,1433;Initial Catalog=DashboardBug;Persist Security Info=False;User ID=sa;Password=your_password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
			return new VmesDbContext(dbContextOptionsBuilder.Options);
		}

	}

}
