using Data.SQL;
using Data.SQL.Interfaces;
using Data.SQL.Repositories;
using PetProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserService>(
    diContainer => new UserService(diContainer.GetService<IUserRepository>()));

var dataSqlStartup = new Startup();
dataSqlStartup.RegisterDbContext(builder.Services);

builder.Services.AddScoped<IUserRepository>(x => new UserRepository(x.GetService<WebContext>()));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
