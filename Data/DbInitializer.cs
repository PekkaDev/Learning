using RepickStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace RepickStore.Data;

public static class DbInitializer
{
    public static async Task SeedDataAsync(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<RepickStoreContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        if (!await userManager.Users.AnyAsync())
        {
            var user = new ApplicationUser
            {
                UserName = "testUser",
                Email = "test@emal.com"
            };
            await userManager.CreateAsync(user);
        }
        if (!await context.Advertisements.AnyAsync())
        {
            var ads = new Advertisement[]
            {
                new(){Name="A1",Description="Some Description",IsNew=true,Price=10,CreationDate=DateTime.Now},
                new(){Name="A2",Description="Some Description",IsNew=true,Price=10,CreationDate=DateTime.Now},
                new(){Name="A3",Description="Some Description",IsNew=true,Price=10,CreationDate=DateTime.Now},
                new(){Name="A4",Description="Some Description",IsNew=true,Price=10,CreationDate=DateTime.Now},
                new(){Name="A5",Description="Some Description",IsNew=true,Price=10,CreationDate=DateTime.Now},
                new(){Name="B1",Description="Some Description",IsNew=true,Price=10,CreationDate=DateTime.Now},
                new(){Name="B2",Description="Some Description",IsNew=true,Price=10,CreationDate=DateTime.Now},
                new(){Name="B3",Description="Some Description",IsNew=true,Price=10,CreationDate=DateTime.Now},
                new(){Name="B4",Description="Some Description",IsNew=true,Price=10,CreationDate=DateTime.Now},
                new(){Name="B5",Description="Some Description",IsNew=true,Price=10,CreationDate=DateTime.Now}
            };
            var user = await userManager.FindByNameAsync("testUser");
            user.Advertisements = ads;
            await context.SaveChangesAsync();
        }
    }
}