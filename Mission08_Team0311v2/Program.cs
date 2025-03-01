using Microsoft.EntityFrameworkCore;

using Mission08_Team0311v2.Models;

var builder = WebApplication.CreateBuilder(args);

// Ensure UseWebRoot() uses a relative path
builder.WebHost.UseWebRoot("wwwroot");  // This ensures a relative path is used for static files

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TaskContext>(options => options.UseSqlite(builder.Configuration["ConnectionStrings:TaskConnection"]));

builder.Services.AddScoped<ITaskRepository, EFTaskRepository>();

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