using Rotativa.AspNetCore;
using Microsoft.AspNetCore.Identity;
using AspNetCore.Identity.MongoDbCore.Extensions;
using Mmorpg.Web.Services;
using Mmorpg.Web.Models;
using Mmorpg.Web.Settings;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();
builder.Services.AddRazorPages();

var emailSection = builder.Configuration.GetSection("Email");

var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("de"),
    new CultureInfo("pl"),
    new CultureInfo("ru"),
    new CultureInfo("fr"),
    new CultureInfo("pt"),
    new CultureInfo("es"),
    new CultureInfo("it"),
    new CultureInfo("ko"),
    new CultureInfo("ja"),
    new CultureInfo("id"),
    new CultureInfo("zh-Hans"),
    new CultureInfo("zh-Hant"),
    new CultureInfo("ar"),
    new CultureInfo("tr")
};

var mongoSection = builder.Configuration.GetSection("MongoDb");
builder.Services.Configure<Mmorpg.Web.Settings.MongoDbSettings>(mongoSection);
var mongoSettings = mongoSection.Get<Mmorpg.Web.Settings.MongoDbSettings>();
if (mongoSettings is null || string.IsNullOrWhiteSpace(mongoSettings.ConnectionString) || string.IsNullOrWhiteSpace(mongoSettings.DatabaseName))
{
    throw new InvalidOperationException("Configuração do MongoDb ausente ou inválida em appsettings.json (MongoDb:ConnectionString/DatabaseName)");
}
builder.Services.AddIdentity<Mmorpg.Web.Models.ApplicationUser, Mmorpg.Web.Models.ApplicationRole>()
    .AddMongoDbStores<Mmorpg.Web.Models.ApplicationUser, Mmorpg.Web.Models.ApplicationRole, Guid>(mongoSettings.ConnectionString, mongoSettings.DatabaseName)
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
});

builder.Services.AddHealthChecks();

builder.Services.Configure<Mmorpg.Web.Settings.EmailSettings>(emailSection);
builder.Services.AddScoped<Mmorpg.Web.Services.IEmailSender, Mmorpg.Web.Services.EmailSender>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    app.UseHttpsRedirection();
}

var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("pt"),
    SupportedCultures = supportedCultures.ToList(),
    SupportedUICultures = supportedCultures.ToList()
};
localizationOptions.RequestCultureProviders = new List<IRequestCultureProvider>
{
    new CookieRequestCultureProvider(),
    new AcceptLanguageHeaderRequestCultureProvider()
};
app.UseRequestLocalization(localizationOptions);

var rotativaDir = System.IO.Path.Combine(app.Environment.WebRootPath, "Rotativa");
if (System.IO.Directory.Exists(rotativaDir))
{
    RotativaConfiguration.Setup(app.Environment.WebRootPath, "Rotativa");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.MapHealthChecks("/health");

app.Run();
