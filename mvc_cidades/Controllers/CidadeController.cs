using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cidades.Models;
using cidades.Data;

public class CidadeController : Controller
{
    private readonly ApplicationDbContext _context;

    public CidadeController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: CIDADEMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.CidadeModel.ToListAsync());
    }

    // GET: CIDADEMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cidademodel = await _context.CidadeModel
            .FirstOrDefaultAsync(m => m.Id == id);
        if (cidademodel == null)
        {
            return NotFound();
        }

        return View(cidademodel);
    }

    // GET: CIDADEMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CIDADEMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CidadeModel cidademodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(cidademodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(cidademodel);
    }

    // GET: CIDADEMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cidademodel = await _context.CidadeModel.FindAsync(id);
        if (cidademodel == null)
        {
            return NotFound();
        }
        return View(cidademodel);
    }

    // POST: CIDADEMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, CidadeModel cidademodel)
    {
        if (id != cidademodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(cidademodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidadeModelExists(cidademodel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(cidademodel);
    }

    // GET: CIDADEMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cidademodel = await _context.CidadeModel
            .FirstOrDefaultAsync(m => m.Id == id);
        if (cidademodel == null)
        {
            return NotFound();
        }

        return View(cidademodel);
    }

    // POST: CIDADEMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var cidademodel = await _context.CidadeModel.FindAsync(id);
        if (cidademodel != null)
        {
            _context.CidadeModel.Remove(cidademodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CidadeModelExists(int? id)
    {
        return _context.CidadeModel.Any(e => e.Id == id);
    }
}
