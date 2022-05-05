using Microsoft.AspNetCore.Identity;

namespace RepickStore.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Advertisement> Advertisements { get; set; } = new List<Advertisement>();
}