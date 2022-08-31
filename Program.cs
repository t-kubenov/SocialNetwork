using SocialNetwork.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Old DbContext
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

builder.Services.AddDbContext<SocialNetworkContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SocialNetworkContextConnection"));
});

builder.Services.AddDefaultIdentity<SocialNetworkUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SocialNetworkContext>();

builder.Services.AddControllersWithViews();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
