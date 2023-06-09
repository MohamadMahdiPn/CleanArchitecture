using System.Reflection;
using HR_Management.UI.Contracts;
using HR_Management.UI.Services;
using HR_Management.UI.Services.Base;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IClient, Client>(x =>
    x.BaseAddress = new Uri(builder.Configuration.GetSection("ApiAddress").Value));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
  
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
