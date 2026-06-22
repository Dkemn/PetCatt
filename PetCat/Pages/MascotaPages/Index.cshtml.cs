using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetCat.Data;

namespace PetCat.Pages.MascotaPages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Mascota> Mascota { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Mascota = await _context.Mascotas.ToListAsync();
    }
}
