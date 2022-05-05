using RepickStore.Models;
using RepickStore.Models.ViewModels;
using RepickStore.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace RepickStore.Pages;

public class CreateModel : PageModel
{
    private IAdRepository _repository;
    [BindProperty]
    public AdFormViewModel Input { get; set; } = new();
    public CreateModel(IAdRepository repository)
    {
        _repository = repository;
    }
    public IActionResult OnGet()
    {
        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var advertisement = new Advertisement()
        {
            Name = Input.Name,
            Description = Input.Description,
            IsNew = Input.IsNew,
            Price = Input.Price,
            CreationDate = DateTime.Now
        };
        await _repository.CreateAsync(advertisement);
        return RedirectToPage("/Index");
    }
}