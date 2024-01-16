using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VMES.Database.Vmes.Extensions
{

	public static class DatabaseFacadeExtensions
	{

		public static async Task AlterIndexAllRebuildAsync(this DatabaseFacade databaseFacade, string tableName, bool online = false, CancellationToken cancellationToken = default)
		{
			await databaseFacade.ExecuteSqlRawAsync($"ALTER INDEX ALL ON [{tableName}] REBUILD WITH (ONLINE={(online ? "ON" : "OFF")});", cancellationToken);
		}

		public static async Task AlterIndexAllReorganizeAsync(this DatabaseFacade databaseFacade, string tableName, CancellationToken cancellationToken = default)
		{
			var oldCommandTimeout = databaseFacade.GetCommandTimeout();
			var newCommandTimeout = TimeSpan.FromMinutes(10);
			databaseFacade.SetCommandTimeout(newCommandTimeout);
			await databaseFacade.ExecuteSqlRawAsync($"ALTER INDEX ALL ON [{tableName}] REORGANIZE;", cancellationToken);
			databaseFacade.SetCommandTimeout(oldCommandTimeout);
		}

		public static async Task BackupDatabaseToDiskAsync(this DatabaseFacade databaseFacade, string fileName, bool? compress = null, CancellationToken cancellationToken = default)
		{
			var databaseName = databaseFacade.GetDbConnection().Database;
			switch (compress)
			{
				case true:
					await databaseFacade.ExecuteSqlRawAsync($"BACKUP DATABASE [{databaseName}] TO DISK = '{fileName}' WITH COMPRESSION;", cancellationToken);
					break;
				case false:
					await databaseFacade.ExecuteSqlRawAsync($"BACKUP DATABASE [{databaseName}] TO DISK = '{fileName}' WITH NO_COMPRESSION;", cancellationToken);
					break;
				case null:
					await databaseFacade.ExecuteSqlRawAsync($"BACKUP DATABASE [{databaseName}] TO DISK = '{fileName}';", cancellationToken);
					break;
			}
		}

		public static async Task DbccShrinkdatabaseAsync(this DatabaseFacade databaseFacade, ushort targetPercent = 0, CancellationToken cancellationToken = default)
		{
			var databaseName = databaseFacade.GetDbConnection().Database;
			await databaseFacade.ExecuteSqlRawAsync($"DBCC SHRINKDATABASE ([{databaseName}], {targetPercent});", cancellationToken);
		}

		public static async Task UpdateStatisticsAsync(this DatabaseFacade databaseFacade, string tableName, CancellationToken cancellationToken = default)
		{
			await databaseFacade.ExecuteSqlRawAsync($"UPDATE STATISTICS [{tableName}];", cancellationToken);
		}

	}

}
