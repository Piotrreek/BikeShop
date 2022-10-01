using Azure.Storage.Blobs;
using BikeShop.Entities;
using BikeShop.Extensions;
using BikeShop.Models;
using BikeShop.Repositories;
using BikeShop.Services;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(config =>
{
    config.ModelBinderProviders.Insert(0, new InvariantDecimalModelBinderProvider());
});
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
builder.Services.AddScoped<IValidationService<CreateBikeViewModel>, ValidationService<CreateBikeViewModel>>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBikeRepository, BikeRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();

builder.Services.AddScoped<IAzureBlobService, AzureBlobService>();
builder.Services.AddScoped(x => new BlobServiceClient(builder.Configuration.GetValue<string>("ConnectionStrings:AzureBlobContainer")));

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
