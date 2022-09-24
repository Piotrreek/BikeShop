using BikeShop.Entities;
using BikeShop.Models;
using BikeShop.Services;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#if DEBUG
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
builder.Services.AddDbContext<BikeShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BikeShopDb")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<BikeShopContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/account/login";
});

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddScoped<IValidationService<UserViewModel>, ValidationService<UserViewModel>>();
builder.Services.AddScoped<IValidationService<LoginViewModel>, ValidationService<LoginViewModel>>();

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
