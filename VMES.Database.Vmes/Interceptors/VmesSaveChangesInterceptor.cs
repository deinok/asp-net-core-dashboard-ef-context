#warning
#if NET7_0_OR_GREATER

using System;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Interceptors
{

	public class VmesSaveChangesInterceptor : SaveChangesInterceptor
	{

		public void AddAudit(DbContextEventData dbContextEventData, InterceptionResult<int> interceptionResult)
		{
			var vmesDbContext = dbContextEventData.Context as VmesDbContext;
			var entityEntries = vmesDbContext.ChangeTracker.Entries()
				.Where(x => x.State != EntityState.Detached)
				.Where(x => x.State != EntityState.Unchanged)
				.Where(x => x.Entity.GetType() != typeof(Audit))
				.Where(x => x.Entity.GetType() != typeof(AuditTable))
				.Where(x => x.Entity.GetType() != typeof(AuditColumn))
				.ToList();
			if (entityEntries.Any())
			{
				var stackTraceFrames = new StackTrace(true)
					.GetFrames()
					.Where(x => x.GetFileName() != null)
					.Where(x => !x.GetFileName().EndsWith("VmesSaveChangesInterceptor.cs"))
					.Select(x => x.ToString())
					.ToList();
				var networkInterface = NetworkInterface.GetAllNetworkInterfaces()
					.Where(x => x.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
					.FirstOrDefault();
				var audit = new Audit
				{
					Hostname = Environment.MachineName,
					Timestamp = DateTime.Now,
					StackTrace = string.Join(Environment.NewLine, stackTraceFrames),
					User = null,
					Ip = networkInterface?.GetIPProperties()
						.UnicastAddresses
						.Where(x => x.Address.AddressFamily == AddressFamily.InterNetwork)
						.First()?
						.Address
						.ToString(),
					Mac = networkInterface?
						.GetPhysicalAddress()
						.ToString()
				};
				foreach (var entityEntry in entityEntries)
				{
					var auditTable = new AuditTable
					{
						State = entityEntry.State,
						Table = entityEntry.Metadata.GetTableName(),
					};
					var propertyEntries = entityEntry.Properties
						.Where(x => x.IsModified)
						.ToList();
					foreach (var propertyEntry in propertyEntries)
					{
						var auditColumn = new AuditColumn
						{
							Column = propertyEntry.Metadata.Name,
							OldValue = propertyEntry.OriginalValue?.ToString(),
							NewValue = propertyEntry.CurrentValue?.ToString()
						};
						auditTable.AuditColumns.Add(auditColumn);
					}
					audit.AuditTables.Add(auditTable);
				}
				vmesDbContext.Audits.Add(audit);
			}
		}

		public override InterceptionResult<int> SavingChanges(DbContextEventData dbContextEventData, InterceptionResult<int> interceptionResult)
		{
			this.AddAudit(dbContextEventData, interceptionResult);
			return base.SavingChanges(dbContextEventData, interceptionResult);
		}

		public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData dbContextEventData, InterceptionResult<int> interceptionResult, CancellationToken cancellationToken = default)
		{
			this.AddAudit(dbContextEventData, interceptionResult);
			return await base.SavingChangesAsync(dbContextEventData, interceptionResult, cancellationToken);
		}

	}

}

#endif
