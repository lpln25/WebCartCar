using CartCar.App.Context;
using CartCar.App.Hubs;
using CartCar.App.Models.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var mvcBuilder = builder.Services.AddControllersWithViews();

// update html razor page in debug, with out stop
#if DEBUG
mvcBuilder.AddRazorRuntimeCompilation();
#endif

// signalR
builder.Services.AddSignalR();

var con = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DatabaseContext>
    (options => options.UseSqlServer(con));
builder.Services.AddScoped<IDrivingOffenseService, DrivingOffenseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// signalR
app.MapHub<SiteHub>("/conhub");

app.Run();
