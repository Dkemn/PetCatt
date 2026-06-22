using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetCat.Data;

namespace PetCat.Pages.MascotaPages;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public Mascota Mascota { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var mascota = await _context.Mascotas
            .Include(m => m.Vacunas)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (mascota is null)
        {
            return NotFound();
        }
        else
        {
            Mascota = mascota;
        }
        return Page();
    }
}