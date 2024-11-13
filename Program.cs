using _5LetrasBanco.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*builder.Services.AddDbContext<Contexto> //Blasque
    (options => options.UseSqlServer("Data Source=SP-1491030\\SQLSENAI;Initial Catalog = 5Letras-Banco;Integrated Security = True;TrustServerCertificate = True"));*/

/*builder.Services.AddDbContext<Contexto> //Gyuliana
    (options => options.UseSqlServer("Data Source=SP-1491016\\SQLSENAI;Initial Catalog = 5Letras-Banco;Integrated Security = True;TrustServerCertificate = True"));*/

/* builder.Services.AddDbContext<Contexto> //Iara
    (options => options.UseSqlServer("Data Source=SP-1491033\\SQLSENAI;Initial Catalog = 5Letras-Banco;Integrated Security = True;TrustServerCertificate = True")); */

/*builder.Services.AddDbContext<Contexto> //Renara
    (options => options.UseSqlServer("Data Source=SP-1491035\\SQLSENAI;Initial Catalog = 5Letras-Banco;Integrated Security = True;TrustServerCertificate = True")); */
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
