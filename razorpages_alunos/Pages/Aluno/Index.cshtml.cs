using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorpages_alunos.Models;
using razorpages_alunos.Data;

namespace razorpages_alunos.Pages.AlunoModelPages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<AlunoModel> AlunoModel { get; set; } = default!;

    public async Task OnGetAsync()
    {
        AlunoModel = await _context.AlunoModel.ToListAsync();
    }
}
