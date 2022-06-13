using FinalProject_KhatiashviliGoga;
using FinalProject_KhatiashviliGoga.Interfaces;
using FinalProject_KhatiashviliGoga.Mapping;
using FinalProject_KhatiashviliGoga.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FinalProject_KhatiashviliGoga") ?? throw new InvalidOperationException("Connection string 'FinalProject_KhatiashviliGoga' not found.");

builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IMapper<FinalProject_KhatiashviliGoga.Entities.Organization, FinalProject_KhatiashviliGoga.Models.OrganizationModel>, OrganizationMapper>();


builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IMapper<FinalProject_KhatiashviliGoga.Entities.Person, FinalProject_KhatiashviliGoga.Models.PersonModel>, PersonMapper>();



builder.Services.AddDbContext<FinalProject_KhatiashviliGogaContext>(options =>
    options.UseSqlServer(connectionString));;

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
   // .AddEntityFrameworkStores<MyFirstProjectMVC1Context>();;

// Add services to the container.
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
    pattern: "{controller=Home}/{action=Index}/{id?}");





app.Run();

