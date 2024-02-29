using Data.SQL;
using Data.SQL.Interfaces;
using Data.SQL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using PetProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddAuthentication(AuthService.AUTH_NAME)
    .AddCookie(AuthService.AUTH_NAME, x =>
    {
        x.LoginPath = "/User/Login";
        x.AccessDeniedPath = "/User/AccessDenied";
    });

builder.Services.AddScoped<IUserService>(
    diContainer => new UserService(diContainer.GetService<IUserRepository>()));
builder.Services.AddScoped<IAuthService>(
    diContainer => new AuthService(diContainer.GetService<IUserService>(), diContainer.GetService<IHttpContextAccessor>()));

var dataSqlStartup = new Startup();
dataSqlStartup.RegisterDbContext(builder.Services);

builder.Services.AddScoped<IUserRepository>(x => new UserRepository(x.GetService<WebContext>()));

builder.Services.AddHttpContextAccessor();

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
