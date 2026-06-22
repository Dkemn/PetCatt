using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetCat.Data;

namespace PetCat.Pages.VacunaPages;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet(int? mascotaId)
    {
        ViewData["MascotaId"] = new SelectList(_context.Mascotas, "Id", "Nombre", mascotaId);

        if (mascotaId.HasValue)
        {
            Vacuna = new Vacuna { MascotaId = mascotaId.Value };
        }

        return Page();
    }

    [BindProperty]
    public Vacuna Vacuna { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["MascotaId"] = new SelectList(_context.Mascotas, "Id", "Nombre");
            return Page();
        }

        _context.Vacunas.Add(Vacuna);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
}