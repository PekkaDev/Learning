using RepickStore.Models;

namespace RepickStore.Data;

public interface IAdRepository
{
    IQueryable<Advertisement> Ads { get; }
    Task<Advertisement> FindByIdAsync(int id);
    Task CreateAsync(Advertisement ad);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, Advertisement updatedAd);
}