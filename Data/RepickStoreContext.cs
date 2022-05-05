using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RepickStore.Models;

namespace RepickStore.Data;

public class RepickStoreContext : IdentityUserContext<ApplicationUser, Guid>, IAdRepository
{
    public DbSet<Advertisement> Advertisements => Set<Advertisement>();
    public IQueryable<Advertisement> Ads => Advertisements;

    public RepickStoreContext(DbContextOptions<RepickStoreContext> options)
    : base(options) { }

    public async Task<Advertisement> FindByIdAsync(int id)
    {
        return await Ads.Include(x => x.Owner).FirstAsync(x => x.Id == id);
    }

    public async Task CreateAsync(Advertisement ad)
    {
        Add(ad);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var ad = new Advertisement();
        Advertisements.Attach(ad);
        ad.IsDeleted = true;
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, Advertisement updatedAd)
    {
        var ad = await Advertisements.FirstAsync(x => x.Id == id);
        ad.Name = updatedAd.Name;
        ad.Description = updatedAd.Description;
        ad.IsNew = updatedAd.IsNew;
        ad.Price = updatedAd.Price;
        ad.CreationDate = DateTime.Now;
        await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Advertisement>().HasQueryFilter(x => !x.IsDeleted);
    }
}