using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace VMES.Database.Vmes.Extensions
{

	public static class ReferenceEntryExtensions
	{

		public static async Task LoadIfNullAsync<TEntity, TProperty>(this ReferenceEntry<TEntity, TProperty> referenceEntry, CancellationToken cancellationToken = default) where TEntity : class where TProperty : class
		{
			if (referenceEntry.CurrentValue == null)
			{
				await referenceEntry.LoadAsync(cancellationToken);
			}
		}

	}

}
