using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepickStore.Data;
using RepickStore.Models;

namespace RepickStore.Pages;

public class DeleteModel : PageModel
{
    private IAdRepository _repository;
    public Advertisement Advertisement { get; set; } = new();
    public DeleteModel(IAdRepository repository)
    {
        _repository = repository;
    }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Advertisement = await _repository.FindByIdAsync(id);
        return Page();
    }
    public async Task<IActionResult> OnPostAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return RedirectToPage("/");
    }
}