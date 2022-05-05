using Microsoft.EntityFrameworkCore;

namespace RepickStore.Models;

public class Advertisement
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public bool IsNew { get; set; }
    public bool IsDeleted { get; set; }
    [Precision(18, 2)]
    public decimal Price { get; set; }
    public int Views { get; set; }
    public DateTime CreationDate { get; set; }

    public ApplicationUser Owner { get; set; } = new();
}