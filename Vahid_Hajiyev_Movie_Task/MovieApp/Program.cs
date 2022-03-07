using Microsoft.EntityFrameworkCore;
using MovieApp.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var MySpec = "Policy1";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MySpec,
                        builder =>
                        {
                            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                        });
});

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<MovieDbContext>(options =>
 //   options.UseSqlServer(connectionString));

builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(connectionString,
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(100),
            errorNumbersToAdd: null);
    }));


builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();



//builder.Services.AddTransient<IMovieData, InMemoryMovieData>();
//builder.Services.AddScoped(provider => new MvcMovieDbContext(""));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  //  app.UseHsts();
}

app.UseCors(MySpec);


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();