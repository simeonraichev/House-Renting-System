using HouseRentingSystem.Infrastructure.Data;
using HouseRentingSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity: RequireConfirmedAccount");
    options.SignIn.RequireConfirmedEmail = builder.Configuration.GetValue<bool>("Identity: RequireConfirmedEmail");
    options.SignIn.RequireConfirmedPhoneNumber = builder.Configuration.GetValue<bool>("Identity: RequireConfirmedPhoneNumber");
    options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity: RequiredLength");
    options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity: RequireNonAlphanumeric");

})
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationSevices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
