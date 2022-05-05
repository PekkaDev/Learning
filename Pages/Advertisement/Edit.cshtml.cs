using RepickStore.Data;
using RepickStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using RepickStore.Models;

namespace RepickStore.Pages;

public class EditModel : PageModel
{
    private IAdRepository _repository;
    [BindProperty]
    public AdFormViewModel Input { get; set; } = new();
    public EditModel(IAdRepository repository)
    {
        _repository = repository;
    }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var ad = await _repository.FindByIdAsync(id);
        Input.Name = ad.Name;
        Input.Description = ad.Description;
        Input.IsNew = ad.IsNew;
        Input.Price = ad.Price;
        return Page();
    }
    public async Task<IActionResult> OnPostAsync(int id)
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
        await _repository.UpdateAsync(id, advertisement);
        return RedirectToPage("/");
    }
}