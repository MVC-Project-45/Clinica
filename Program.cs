using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_Final.Models;
<<<<<<< HEAD
using MVC_Final.Services;
=======
using MVC_Final.Repositories;
>>>>>>> d576ac289627ee7cbeba60cf9920020457739937

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(
options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cs"));
});
<<<<<<< HEAD
builder.Services.AddScoped<IDoctorAdmin, DoctorAdminService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IReviewService, ReviewService>();


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.Password.RequiredLength = 6;
    option.Password.RequireUppercase = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireDigit = false;





}
 ).AddEntityFrameworkStores<Context>();
=======


builder.Services.AddScoped<IDoctorAdmin, DoctorAdminRepository>();
>>>>>>> d576ac289627ee7cbeba60cf9920020457739937

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
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
