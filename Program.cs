using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TALLER_3.Models.Domain;
using TALLER_3.Repositories.Abstract;
using TALLER_3.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//CODIGO AGREGADO
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// For Identity  
    builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<DatabaseContext>()
        .AddDefaultTokenProviders();

    builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/UserAuthentication/Login");

// FIN DEL CODIGO AGREGADO

builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();



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
    pattern: "{controller=UserAuthentication}/{action=Login}/{id?}");


app.Run();
