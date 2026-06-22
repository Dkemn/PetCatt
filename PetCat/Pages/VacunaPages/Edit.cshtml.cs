using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetCat.Data;

namespace PetCat.Pages.VacunaPages;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Vacuna Vacuna { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var vacuna = await _context.Vacunas.FirstOrDefaultAsync(m => m.Id == id);
        if (vacuna is null)
        {
            return NotFound();
        }
        Vacuna = vacuna;

        ViewData["MascotaId"] = new SelectList(_context.Mascotas, "Id", "Nombre", Vacuna.MascotaId);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["MascotaId"] = new SelectList(_context.Mascotas, "Id", "Nombre", Vacuna.MascotaId);
            return Page();
        }

        _context.Attach(Vacuna).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VacunaExists(Vacuna.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool VacunaExists(int id)
    {
        return _context.Vacunas.Any(e => e.Id == id);
    }
}
