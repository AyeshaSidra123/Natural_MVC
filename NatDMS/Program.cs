using Microsoft.AspNetCore.Hosting;
using NatDMS;
using NatDMS.Models;
using Natural.Core.IServices;
using Naturals.Service.Service;
using Microsoft.Extensions.DependencyInjection;
using Natural.Core.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddTransient<IUnifiedService, UnifiedService>();
builder.Services.AddScoped<IDistributorService, DistributorService>();
builder.Services.AddScoped<IRetailorService , RetailorService>(); 
builder.Services.AddScoped<IExecutiveService, ExecutiveService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddScoped<IExecutiveService, ExecutiveService>();
builder.Services.AddScoped<IDsrService,DsrService>();
builder.Services.AddScoped<IDsrDetailsService, DSRDetailService>();

builder.Services.AddScoped<IAssignDistributorToExecutiveService, AssignDistributorToExecutiveService>();
builder.Services.Configure<ApiDetails>(builder.Configuration.GetSection("ApiUrlDetails"));
builder.Services.AddHttpClient<IHttpClientWrapper, HttpClientWrapper>();


builder.Services.AddAutoMapper(typeof(Program));



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        
        options.Cookie.SameSite = SameSiteMode.None;
        //options.ExpireTimeSpan = TimeSpan.FromSeconds(20);
    });



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");
 

app.Run();
