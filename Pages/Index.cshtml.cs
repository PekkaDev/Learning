using RepickStore.Data;
using RepickStore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RepickStore.Pages;

public class IndexModel : PageModel
{
    public IEnumerable<Advertisement> Advertisements { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    [BindProperty(SupportsGet = true)]
    public InputModel Input { get; set; }
    private IAdRepository _repository { get; set; }
    public IndexModel(IAdRepository repository)
    {
        _repository = repository;
        Advertisements = Enumerable.Empty<Advertisement>();
        Input = new();
    }
    public async Task<IActionResult> OnGetAsync(int itemsPerPage = 20)
    {
        TotalItems = _repository.Ads.Count();
        TotalPages = TotalItems / itemsPerPage + (TotalPages % itemsPerPage == 0 ? 0 : 1);
        Advertisements = await _repository.Ads
            .OrderByDescending(x => x.CreationDate)
            .Skip((Input.CurrentPage - 1) * itemsPerPage)
            .Take(itemsPerPage).ToListAsync();
        return Page();
    }
    public class InputModel
    {
        public int CurrentPage { get; set; } = 1;
        public string SearchString { get; set; } = String.Empty;
    }
}