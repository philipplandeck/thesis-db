using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThesisDatenbank.Data;
using ThesisDatenbank.Models;

namespace ThesisDatenbank.Controllers
{
    [Authorize]
    public class ThesesController : Controller
    {
        private readonly AppDbContext _context;

        public ThesesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Theses
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Thesis.Include(t => t.StudentProgram).Include(t => t.Supervisor);
            const int length = 10;

            ViewData["From"] = length;
            ViewData["Length"] = length;
            ViewData["More"] = appDbContext.Count() > length;
            return View(await appDbContext.Take(length).ToListAsync());
        }

        // GET: Theses (PartialView)
        public async Task<IActionResult> GetTheses(int from, int length)
        {
            var appDbContext = _context.Thesis.Include(t => t.StudentProgram).Include(t => t.Supervisor);

            ViewData["From"] = from + length;
            ViewData["Length"] = length;
            ViewData["More"] = appDbContext.Count() > from + length;

            return PartialView("IndexPartial", await appDbContext.Skip(from).Take(length).ToListAsync());
        }

        // GET: Theses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Thesis == null)
            {
                return NotFound();
            }

            var thesis = await _context.Thesis
                .Include(t => t.StudentProgram)
                .Include(t => t.Supervisor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thesis == null)
            {
                return NotFound();
            }

            return View(thesis);
        }

        // GET: Theses/Create
        public IActionResult Create()
        {
            ViewData["StudentProgramId"] = new SelectList(_context.Program, "Id", "Name");
            ViewData["SupervisorId"] = new SelectList(_context.Supervisor.Where(s => s.Active == true).ToList(), "Id", "LastName");
            return View(new Thesis());
        }

        // POST: Theses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Bachelor,Master,Status,StudentName,StudentEMail,StudentId,StudentProgramId,Registration,Filing,Summary,Strengths,Weaknesses,Evaluation,ContentVal,LayoutVal,StructureVal,StyleVal,LiteratureVal,DifficultyVal,NoveltyVal,RichnessVal,ContentWt,LayoutWt,StructureWt,StyleWt,LiteratureWt,DifficultyWt,NoveltyWt,RichnessWt,Grade,LastModified,SupervisorId")] Thesis thesis)
        {
            if (ModelState.IsValid)
            {
                if (thesis.StudentProgramId == 0) thesis.StudentProgramId = null;
                if (thesis.SupervisorId == 0) thesis.SupervisorId = null;
                _context.Add(thesis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentProgramId"] = new SelectList(_context.Program, "Id", "Name", thesis.StudentProgramId);
            ViewData["SupervisorId"] = new SelectList(_context.Supervisor.Where(s => s.Active == true).ToList(), "Id", "LastName", thesis.SupervisorId);
            return View(thesis);
        }

        // GET: Theses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Thesis == null)
            {
                return NotFound();
            }

            var thesis = await _context.Thesis.FindAsync(id);
            if (thesis == null)
            {
                return NotFound();
            }
            ViewData["StudentProgramId"] = new SelectList(_context.Program, "Id", "Name", thesis.StudentProgramId);
            ViewData["SupervisorId"] = new SelectList(_context.Supervisor.Where(s => s.Active == true).ToList(), "Id", "LastName", thesis.SupervisorId);
            return View(thesis);
        }

        // POST: Theses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Bachelor,Master,Status,StudentName,StudentEMail,StudentId,StudentProgramId,Registration,Filing,Summary,Strengths,Weaknesses,Evaluation,ContentVal,LayoutVal,StructureVal,StyleVal,LiteratureVal,DifficultyVal,NoveltyVal,RichnessVal,ContentWt,LayoutWt,StructureWt,StyleWt,LiteratureWt,DifficultyWt,NoveltyWt,RichnessWt,Grade,LastModified,SupervisorId")] Thesis thesis)
        {
            if (id != thesis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (thesis.StudentProgramId == 0) thesis.StudentProgramId = null;
                    if (thesis.SupervisorId == 0) thesis.SupervisorId = null;
                    thesis.LastModified = DateTime.Now;
                    _context.Update(thesis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThesisExists(thesis.Id))
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
            ViewData["StudentProgramId"] = new SelectList(_context.Program, "Id", "Name", thesis.StudentProgramId);
            ViewData["SupervisorId"] = new SelectList(_context.Supervisor.Where(s => s.Active == true).ToList(), "Id", "LastName", thesis.SupervisorId);
            return View(thesis);
        }

        // GET: Theses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Thesis == null)
            {
                return NotFound();
            }

            var thesis = await _context.Thesis
                .Include(t => t.StudentProgram)
                .Include(t => t.Supervisor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thesis == null)
            {
                return NotFound();
            }

            return View(thesis);
        }

        // POST: Theses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Thesis == null)
            {
                return Problem("Entity set 'AppDbContext.Thesis'  is null.");
            }
            var thesis = await _context.Thesis.FindAsync(id);
            if (thesis != null)
            {
                _context.Thesis.Remove(thesis);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThesisExists(int id)
        {
          return _context.Thesis.Any(e => e.Id == id);
        }
    }
}
