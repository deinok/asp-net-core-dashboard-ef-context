using DevExpress.AspNetCore;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb;
using WebEFCoreApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

IFileProvider? fileProvider = builder.Environment.ContentRootFileProvider;
IConfiguration? configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDevExpressControls();
builder.Services.AddScoped<DashboardConfigurator>((IServiceProvider serviceProvider) => {
    
    DashboardConfigurator configurator = new DashboardConfigurator();
    configurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(configuration));

    IDashboardStorage dashboardFileStorage = new DashboardInMemoryStorage();
    configurator.SetDashboardStorage(dashboardFileStorage);

    DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();

    // Register an Entity Framework data source.������������
    var connectionParameters = new EFConnectionParameters(typeof(VMES.Database.Vmes.VmesDbContext));
    DashboardEFDataSource efDataSource = new DashboardEFDataSource("EF Data Source", "EF Data Connection", connectionParameters);
    dataSourceStorage.RegisterDataSource("efDataSource", efDataSource.SaveToXml());

    configurator.SetDataSourceStorage(dataSourceStorage);
    configurator.SetEFContextProvider(new CustomEFContextProvider(serviceProvider));

    return configurator;
});
builder.Services.AddDbContext<VMES.Database.Vmes.VmesDbContext>(options => options.UseSqlServer("Database=DashboardBug;Password=your_password;Server=localhost;TrustServerCertificate=True;User Id=sa;"), ServiceLifetime.Transient);
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseDevExpressControls();

app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();

app.MapDashboardRoute("dashboardControl", "DefaultDashboard");

using var serviceScope = app.Services.CreateScope();
var vmesDbContext = serviceScope.ServiceProvider.GetRequiredService<VMES.Database.Vmes.VmesDbContext>();
vmesDbContext.Database.Migrate();

app.Run();
