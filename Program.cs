using LoveCalculatorApp.Services;
using LoveCalculatorApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ? Add Services
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ILoveCalculatorService, LoveCalculatorService>();
builder.Services.AddScoped<IMapperService, MapperService>();
builder.Services.AddScoped<UserService>();

// ? Add DbContext (SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ? Enable Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// ? MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ? Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ? Enable Session (VERY IMPORTANT)
app.UseSession();

app.UseAuthorization();

// ? Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}"); // ?? start from Login

app.Run();