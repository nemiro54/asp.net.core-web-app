using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebApplication1Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApplication1Context") ??
                      throw new InvalidOperationException("Connection string 'WebApplication1Context' not found.")));

// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//     .AddEntityFrameworkStores<WebApplication1Context>();

builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<WebApplication1Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     
//     DataSeed.Initialize(services);
// }

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

app.UseAuthentication();;
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// app.MapRazorPages();

app.Run();