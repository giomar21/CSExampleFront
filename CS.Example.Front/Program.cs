using CS.Example.Business.Interfaces.Usuarios;
using CS.Example.Business.Root.Usuarios;
using CS.Example.Common;
using CS.Example.Communication.Usuarios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IBusinessUsuario), typeof(BusinessUsuario));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var settings = builder.Configuration.GetSection("Settings").Get<Settings>();

UsuariosService.Init(settings.URL_API);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
