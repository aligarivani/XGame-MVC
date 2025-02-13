using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using XGame.DataContext;

var builder = WebApplication.CreateBuilder ( args );

// Add services to the container.
builder.Services.AddControllersWithViews ();
builder.Services.AddAuthorization ( option =>
{
    option.AddPolicy ( "Adminonly", policy => policy.RequireRole ( "Admin" ) );
    option.AddPolicy ( "UserOnly", policy => policy.RequireRole ( "User" ) );

} );
builder.Services.AddAuthentication ( CookieAuthenticationDefaults.AuthenticationScheme ).AddCookie ( option =>
{
    option.LoginPath = "/Auth/Login";
    option.LogoutPath = "/";
    option.AccessDeniedPath = "/";
    option.ExpireTimeSpan = TimeSpan.FromDays ( 7 );
    option.SlidingExpiration = true;

} );
builder.Services.AddDbContext<DataContext> ( option =>
{
    option.UseSqlServer ( "Server=DESKTOP-AMB23MJ;Database=XGame;Integrated Security=True;TrustServerCertificate=True;" );
} );
var app = builder.Build ();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment ())
{
    app.UseExceptionHandler ( "/Home/Error" );
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts ();
}

app.UseHttpsRedirection ();
app.UseRouting ();
app.UseAuthentication ();
app.UseAuthorization ();

app.MapStaticAssets ();

app.MapControllerRoute (
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}" )
    .WithStaticAssets ();


app.Run ();
