using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using New_folder.Data;
using New_folder.Repositories.Interfaces;
using New_folder.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(option => option.UseMySql(
            builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
               ));

builder.Services.AddScoped<IAddressService, IAddressService>();
builder.Services.AddScoped<IBrokerService, IBrokerService>();
builder.Services.AddScoped<IInvestmentService, IInvestmentService>();
builder.Services.AddScoped<IInvestmentTypeService, IInvestmentTypeService>();
builder.Services.AddScoped<IInvestorService, IInvestorService>();
builder.Services.AddScoped<IPaymentService, IPaymentService>();
builder.Services.AddScoped<IUserService, IUserService>();
builder.Services.AddScoped<IWithdrawalService, IWithdrawalService>();
builder.Services.AddScoped<IChatService, IChatService>();
builder.Services.AddScoped<IEmailService, IEmailService>();


builder.Services.AddScoped<IAddressRepository, IAddressRepository>();
builder.Services.AddScoped<IBrokerRepository, IBrokerRepository>();
builder.Services.AddScoped<IInvestmentRepository, IInvestmentRepository>();
builder.Services.AddScoped<IInvestmentTypeRepository, IInvestmentTypeRepository>();
builder.Services.AddScoped<IInvestorRepository, IInvestorRepository>();
builder.Services.AddScoped<IRoleRepository, IRoleRepository>();
builder.Services.AddScoped<IUserRepository, IUserRepository>();
builder.Services.AddScoped<IUserRepository, IUserRepository>();
builder.Services.AddScoped<IWithdrawalRepository, IWithdrawalRepository>();
builder.Services.AddScoped<IChatRepository, IChatRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(config =>
            {
                config.LoginPath = "/User/Login";
                config.Cookie.Name = "Investment";
                config.LogoutPath = "/User/Logout";
                config.ExpireTimeSpan = TimeSpan.FromMinutes(240);
                config.AccessDeniedPath = "/User/Login";
            });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "location_countries",
        pattern: "location/countries",
        defaults: new { controller = "Location", action = "Countries" }
    );

    // Define additional routes for states and cities

    endpoints.MapDefaultControllerRoute();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
