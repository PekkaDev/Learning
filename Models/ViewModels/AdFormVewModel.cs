using System.ComponentModel.DataAnnotations;

namespace RepickStore.Models.ViewModels;

public class AdFormViewModel
{
    [StringLength(18, MinimumLength = 3)]
    public string Name { get; set; } = String.Empty;
    [MinLength(10)]
    public string Description { get; set; } = String.Empty;
    public bool IsNew { get; set; }
    [DataType(DataType.Currency)]
    [Range(1, int.MaxValue)]
    public decimal Price { get; set; }
}