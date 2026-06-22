using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetCat.Data;

namespace PetCat.Pages.VacunaPages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Vacuna> Vacuna { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Vacuna = await _context.Vacunas
            .Include(v => v.Mascota)
            .ToListAsync();
    }
}