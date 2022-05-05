using Microsoft.EntityFrameworkCore;
using RepickStore.Data;
using RepickStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<RepickStoreContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IAdRepository, RepickStoreContext>();

builder.Services.AddDefaultIdentity<ApplicationUser>()
    .AddEntityFrameworkStores<RepickStoreContext>();


var app = builder.Build();

// if (app.Environment.IsDevelopment())
// app.UseHttpLogging();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

await DbInitializer.SeedDataAsync(app);

app.Run();
