using Microsoft.EntityFrameworkCore;
using Project1.Models;
using Project1.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEnrollmentRepo, EnrollmentRepo>();
builder.Services.AddScoped<ICourseRepo, CourseRepo>();
//builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddDbContext<SMSDBContext>(option => option.UseSqlServer
               (builder.Configuration.GetConnectionString("DbCon"))
               );


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.Cookie.Name = "MyCookie";
                    options.LoginPath = "";
                    options.SlidingExpiration = false;

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Enrollment}/{action=Details}/{id?}");

app.Run();
