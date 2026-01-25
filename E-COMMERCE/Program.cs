using E_COMMERCE.Areas.Identity.Data;
using E_COMMERCE.Data;
using E_COMMERCE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using PayPalCheckoutSdk.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Read connection strings
var eCommerceConn = builder.Configuration.GetConnectionString("E_COMMERCEContextConnection")
    ?? throw new InvalidOperationException("Connection string 'E_COMMERCEContextConnection' not found.");
var commerce2Conn = builder.Configuration.GetConnectionString("Commerce2ContextConnection")
    ?? throw new InvalidOperationException("Connection string `Commerce2ContextConnection` not found.");
builder.Services.AddSingleton<IEmailSender, DummyEmailSender>();
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Account/Login"; // لازم يكون موجود هذا المسار
//});


builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId =builder .Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret =builder.Configuration ["Authentication:Google:ClientSecret"];
});
// Register DbContexts
builder.Services.AddDbContext<Commerce2Context>(options =>
    options.UseSqlServer(commerce2Conn));

//builder.Services.AddDefaultIdentity<E_COMMERCEUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<E_COMMERCEContext>();

builder.Services.AddDbContext<E_COMMERCEContext>(options =>
    options.UseSqlServer(eCommerceConn));

// Register Identity (single registration) with role support and token providers
builder.Services.AddIdentity<E_COMMERCEUser, IdentityRole>(options =>
{
    // SignIn settings
    options.SignIn.RequireConfirmedAccount = false;

    // User settings
    options.User.RequireUniqueEmail = true;

    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // (Optional) Lockout / User character rules can be configured here if needed.
})
.AddEntityFrameworkStores<E_COMMERCEContext>()
.AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login"; // ✅ ده الصح
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

// Register MVC and Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Application services
builder.Services.AddScoped<ECO>();

// PayPal client (Sandbox by default, use LiveEnvironment for production)
builder.Services.AddSingleton<PayPalHttpClient>(serviceProvider =>
{
    var environment = new SandboxEnvironment(
        builder.Configuration["PayPal:ClientId"],
        builder.Configuration["PayPal:Secret"]);
    return new PayPalHttpClient(environment);
});

// Seed admin user & role
async Task SeedAdminAsync(IHost app)
{
    using var scope = app.Services.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<E_COMMERCEUser>>();

    string roleName = "Admin";
    string adminEmail = "admin@site.com";
    string adminPassword = "Admin@123";

    if (!await roleManager.RoleExistsAsync(roleName))
    {
        await roleManager.CreateAsync(new IdentityRole(roleName));
    }

    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new E_COMMERCEUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(adminUser, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, roleName);
        }
    }
    else
    {
        if (!await userManager.IsInRoleAsync(adminUser, roleName))
        {
            await userManager.AddToRoleAsync(adminUser, roleName);
        }
    }
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Ensure the admin role/user exist before handling requests
await SeedAdminAsync(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
