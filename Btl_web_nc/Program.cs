using System.Text;
using Btl_web_nc.Models;
using Btl_web_nc.RepositoryInterfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add session services
builder.Services.AddDistributedMemoryCache(); // Cấu hình cache
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Thay đổi thời gian timeout tùy ý
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContextPool<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Sign up repositories
builder.Services.AddScoped<IFavouriteRepositories, FavouriteRepository>();
builder.Services.AddScoped<IUserRepositories, UserRepository>();
builder.Services.AddScoped<IRoleRepositories, RoleRepository>();
builder.Services.AddScoped<ITypeRepositories, TypeRepository>();
builder.Services.AddScoped<IPostRepositories, PostRepository>();
builder.Services.AddScoped<INotifyRepositories, NotifyRepository>();

builder.Services.AddScoped<IPasswordHasher<User>,PasswordHasher<User>>();

builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Đường dẫn đến trang đăng nhập
        options.AccessDeniedPath = "/Account/AccessDenied"; // Đường dẫn đến trang báo lỗi truy cập
    });
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied"; // Đường dẫn khi bị từ chối truy cập

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
app.UseSession(); // Thêm middleware session
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();