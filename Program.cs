using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EDU.Models;
using EDU.Repository;
using EDU.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// 1. MVC Controllers & Views
// --------------------
builder.Services.AddControllersWithViews();

// --------------------
// 2. Database Context
// --------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// --------------------
// 3. Identity & Authentication
// --------------------
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Password settings
    options.Password.RequiredLength = 4;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 5;

    // Sign-in settings
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// --------------------
// 4. Dependency Injection for Repositories
// --------------------
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

// --------------------
// 5. Session Configuration
// --------------------
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true; // More secure
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// --------------------
// 6. Middleware Pipeline
// --------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
