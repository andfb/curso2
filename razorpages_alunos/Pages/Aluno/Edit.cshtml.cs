using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorpages_alunos.Models;
using razorpages_alunos.Data;

namespace razorpages_alunos.Pages.AlunoModelPages;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
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
        AlunoModel = alunomodel;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(AlunoModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AlunoModelExists(AlunoModel.Id))
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

    private bool AlunoModelExists(int id)
    {
        return _context.AlunoModel.Any(e => e.Id == id);
    }
}
