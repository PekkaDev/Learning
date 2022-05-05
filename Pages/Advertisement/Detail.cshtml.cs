using RepickStore.Models;
using RepickStore.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace RepickStore.Pages;

public class DetailModel : PageModel
{
    private IAdRepository _repository;
    public Advertisement Advertisement { get; set; } = new();
    public DetailModel(IAdRepository repository)
    {
        _repository = repository;
    }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Advertisement = await _repository.FindByIdAsync(id);
        return Page();
    }
}