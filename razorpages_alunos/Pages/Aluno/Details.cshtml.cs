using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorpages_alunos.Models;
using razorpages_alunos.Data;

namespace razorpages_alunos.Pages.AlunoModelPages;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public AlunoModel AlunoModel { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var alunomodel = await _context.AlunoModel.FirstOrDefaultAsync(m => m.Id == id);
        if (alunomodel is null)
        {
            return NotFound();
        }
        else
        {
            AlunoModel = alunomodel;
        }

        return Page();
    }
}
