using BookReservationSystem.BL.Configs;
using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages(); 
DependencyInjectionConfig.ConfigureServices(builder.Services);
ConfigureIdentityServices(builder.Services);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static void ConfigureIdentityServices(IServiceCollection services)
{
    services.AddDefaultIdentity<User>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 4;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
    })
        .AddRoles<Role>()
        .AddEntityFrameworkStores<BookReservationSystemDbContext>()
        .AddDefaultTokenProviders(); ;

    services.ConfigureApplicationCookie(options =>
    {
        options.LogoutPath = "/Identity/Logout";
        options.LoginPath = "/Identity/Login";
    });
}