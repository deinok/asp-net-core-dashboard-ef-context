#warning
#if NET7_0_OR_GREATER

using Microsoft.EntityFrameworkCore;

namespace VMES.Database.Vmes
{

	public partial class VmesDbContext : DbContext
	{

		public static readonly Interceptors.VmesSaveChangesInterceptor VmesSaveChangesInterceptor = new Interceptors.VmesSaveChangesInterceptor();

	}

}

#endif
