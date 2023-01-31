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

        public IQueryable<Thesis> GetTheses(string? chairFilter, string? studentFilter, string? titleFilter)
        {
            IQueryable<Thesis> appDbContext = _context.Thesis.Include(t => t.StudentProgram).Include(t => t.Supervisor);

            if (!string.IsNullOrEmpty(chairFilter))
            {
                appDbContext = appDbContext.Where(t => t.Supervisor != null && t.Supervisor.ChairId != null && t.Supervisor.ChairId.ToString() == chairFilter);
            }
            if (!string.IsNullOrEmpty(studentFilter))
            {
                appDbContext = appDbContext.Where(t => t.StudentName != null && t.StudentName.Contains(studentFilter));
            }
            if (!string.IsNullOrEmpty(titleFilter))
            {
                appDbContext = appDbContext.Where(t => t.Title != null && t.Title.Contains(titleFilter));
            }

            return appDbContext.OrderBy(t => t.Registration);
        }

        public int GetChairId(int supervisorId)
        {
            if (supervisorId != -1)
            {
                Supervisor? supervisor = _context.Supervisor.Find(supervisorId);
                if (supervisor != null)
                {
                    int? chairId = supervisor.ChairId;
                    if (chairId != null)
                    {
                        return (int) chairId;
                    }
                }

            }
            return supervisorId;
        }

        public SelectList GetSupervisorSelectList(int? chairId, int? selectedSupervisorId)
        {
            List<SelectListItem> selectListItems = new();
            List<Supervisor> supervisors = new();

            if (chairId == null || chairId == -1) 
            {
                supervisors = _context.Supervisor.Where(s => s.Active == true).ToList();
            }
            else
            {
                supervisors = _context.Supervisor.Where(s => s.ChairId != null && s.ChairId == chairId).Where(s => s.Active == true).ToList();
            }

            foreach (Supervisor supervisor in supervisors)
            {
                string text = supervisor.FirstName + " " + supervisor.LastName;
                string value = supervisor.Id.ToString();
                selectListItems.Add(new SelectListItem() { Text = text, Value = value });
            }

            return new SelectList(selectListItems, "Value", "Text", selectedSupervisorId);
        }

        // GET: Theses
        public async Task<IActionResult> Index(string? chairFilter, string? studentFilter, string? titleFilter)
        {
            IQueryable<Thesis> appDbContext = GetTheses(chairFilter, studentFilter, titleFilter);

            SelectList chairSelectList = new(_context.Chair, "Id", "Name");

            if (!string.IsNullOrEmpty(chairFilter))
            {
                chairSelectList.Where(x => x.Value.ToString() == chairFilter).First().Selected = true;
            }

            ViewData["ChairFilter"] = chairSelectList;
            ViewData["ChairString"] = chairFilter;
            ViewData["StudentFilter"] = studentFilter;
            ViewData["TitleFilter"] = titleFilter;

            const int length = 10;

            ViewData["From"] = length;
            ViewData["Length"] = length;
            ViewData["More"] = appDbContext.Count() > length;

            return View(await appDbContext.Take(length).ToListAsync());
        }

        // GET: Theses (PartialView)
        public async Task<IActionResult> LoadMoreTheses(int from, int length, string? chair, string? student, string? title)
        {
            IQueryable<Thesis> appDbContext = GetTheses(chair, student, title);

            ViewData["ChairString"] = chair;
            ViewData["StudentFilter"] = student;
            ViewData["TitleFilter"] = title;

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
            ViewData["Chairs"] = new SelectList(_context.Chair, "Id", "Name");
            ViewData["Supervisors"] = GetSupervisorSelectList(null, null);
            return View(new Thesis());
        }

        // POST: Theses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Bachelor,Master,Status,StudentName,StudentEMail,StudentId,StudentProgramId,Registration,Filing,Summary,Strengths,Weaknesses,Evaluation,ContentVal,LayoutVal,StructureVal,StyleVal,LiteratureVal,DifficultyVal,NoveltyVal,RichnessVal,ContentWt,LayoutWt,StructureWt,StyleWt,LiteratureWt,DifficultyWt,NoveltyWt,RichnessWt,Grade,LastModified,SupervisorId")] Thesis thesis)
        {
            if (ModelState.IsValid)
            {
                if (thesis.SupervisorId == -1)
                {
                    thesis.SupervisorId = null;
                }
                _context.Add(thesis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (thesis.SupervisorId is not null and not (-1))
            {
                Supervisor? supervisor = await _context.Supervisor.FindAsync(thesis.SupervisorId);
                if (supervisor != null)
                {
                    ViewData["Chairs"] = new SelectList(_context.Chair, "Id", "Name", supervisor.ChairId);
                    ViewData["Supervisors"] = GetSupervisorSelectList(supervisor.ChairId, thesis.SupervisorId);
                }
            }
            else
            {
                ViewData["Chairs"] = new SelectList(_context.Chair, "Id", "Name");
                ViewData["Supervisors"] = GetSupervisorSelectList(null, null);
            }
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
            if (thesis.SupervisorId is not null and not (-1))
            {
                Supervisor? supervisor = await _context.Supervisor.FindAsync(thesis.SupervisorId);
                if (supervisor != null)
                {
                    ViewData["Chairs"] = new SelectList(_context.Chair, "Id", "Name", supervisor.ChairId);
                    ViewData["Supervisors"] = GetSupervisorSelectList(supervisor.ChairId, thesis.SupervisorId);
                }
            }
            else
            {
                ViewData["Chairs"] = new SelectList(_context.Chair, "Id", "Name");
                ViewData["Supervisors"] = GetSupervisorSelectList(null, null);
            }
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
                    if (thesis.StudentProgramId == -1)
                    {
                        thesis.StudentProgramId = null;
                    }
                    else
                    {
                        thesis.StudentProgramId++;
                    }
                    if (thesis.SupervisorId == -1)
                    {
                        thesis.SupervisorId = null;
                    }
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
            if (thesis.SupervisorId is not null and not (-1))
            {
                Supervisor? supervisor = await _context.Supervisor.FindAsync(thesis.SupervisorId);
                if (supervisor != null)
                {
                    ViewData["Chairs"] = new SelectList(_context.Chair, "Id", "Name", supervisor.ChairId);
                    ViewData["Supervisors"] = GetSupervisorSelectList(supervisor.ChairId, thesis.SupervisorId);
                }
            }
            else
            {
                ViewData["Chairs"] = new SelectList(_context.Chair, "Id", "Name");
                ViewData["Supervisors"] = GetSupervisorSelectList(null, null);
            }
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
