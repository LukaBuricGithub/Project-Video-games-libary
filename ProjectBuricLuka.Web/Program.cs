using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using ProjectBuricLuka.DAL;
using ProjectBuricLuka.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddDbContext<VideoGamesDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ClientManagerDbContext"),
            opt => opt.MigrationsAssembly("ProjectBuricLuka.DAL")));


builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<VideoGamesDbContext>();
builder.Services.AddRazorPages();

builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

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

var supportedCultures = new[]
{
    new CultureInfo("hr"), new CultureInfo("en-US")
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("hr"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});



app.MapControllerRoute(
    name: "o-igrama",
    pattern: "o-igrama",
    defaults: new { controller = "Home", action = "About" });

app.MapControllerRoute(
    name: "o-aplikaciji",
    pattern: "o-aplikaciji",
    defaults: new { controller = "Home", action = "Privacy" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
