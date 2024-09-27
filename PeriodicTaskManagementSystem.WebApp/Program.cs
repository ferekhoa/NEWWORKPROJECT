using Microsoft.EntityFrameworkCore;
using PeriodicTaskManagementSystem.Business.Interfaces;
using PeriodicTaskManagementSystem.Business.Services;
using PeriodicTaskManagementSystem.DataAccess.Data;
using PeriodicTaskManagementSystem.DataAccess.Interfaces;
using PeriodicTaskManagementSystem.DataAccess.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext Configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Services Configuration
builder.Services.AddScoped<IRoleService, RoleService>();

//Repositories Configuration
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

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
