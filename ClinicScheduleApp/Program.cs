using Microsoft.EntityFrameworkCore;

using ClinicScheduleApp.DataAccess;
using Microsoft.AspNetCore.Identity;
using ClinicScheduleApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connStr = builder.Configuration.GetConnectionString("FinalExamDb");
builder.Services.AddDbContext<ClinicScheduleDbContext>(options => options.UseSqlServer(connStr));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
	options.Password.RequiredLength = 6;
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireUppercase = true;
	options.Password.RequireNonAlphanumeric = true;

}).AddEntityFrameworkStores<ClinicScheduleDbContext>()
  .AddDefaultTokenProviders();

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

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    await ClinicScheduleDbContext.CreateAdminUser(scope.ServiceProvider);
}

app.Run();
