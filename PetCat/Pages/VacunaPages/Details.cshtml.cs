using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetCat.Data;

namespace PetCat.Pages.VacunaPages;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public Vacuna Vacuna { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var vacuna = await _context.Vacunas
            .Include(v => v.Mascota)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (vacuna is null)
        {
            return NotFound();
        }
        else
        {
            Vacuna = vacuna;
        }
        return Page();
    }
}