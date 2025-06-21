using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorpages_alunos.Models;
using razorpages_alunos.Data;

namespace razorpages_alunos.Pages.AlunoModelPages;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var alunomodel = await _context.AlunoModel.FindAsync(id);
        if (alunomodel != null)
        {
            AlunoModel = alunomodel;
            _context.AlunoModel.Remove(AlunoModel);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
