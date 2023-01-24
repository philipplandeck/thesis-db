using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThesisDatenbank.Data;
using ThesisDatenbank.Models;

namespace ThesisDatenbank.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SupervisorsController : Controller
    {
        private readonly AppDbContext _context;
        
        public SupervisorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Supervisors
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Supervisor.Include(s => s.Chair);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Supervisors/Create
        public IActionResult Create()
        {
            ViewData["ChairId"] = new SelectList(_context.Chair, "Id", "Name");
            return View(new Supervisor());
        }

        // POST: Supervisors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Active,ChairId")] Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                if (supervisor.ChairId == 0) supervisor.ChairId = null;
                _context.Add(supervisor);
                // _context.Chair.Where(c => c.Id == supervisor.ChairId).First().Supervisors.Add(supervisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChairId"] = new SelectList(_context.Chair, "Id", "Name", supervisor.ChairId);
            return View(supervisor);
        }

        // GET: Supervisors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Supervisor == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisor.FindAsync(id);
            if (supervisor == null)
            {
                return NotFound();
            }
            ViewData["ChairId"] = new SelectList(_context.Chair, "Id", "Name", supervisor.ChairId);
            return View(supervisor);
        }

        // POST: Supervisors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Active,ChairId")] Supervisor supervisor)
        {
            if (id != supervisor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (supervisor.ChairId == 0) supervisor.ChairId = null;
                    _context.Update(supervisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupervisorExists(supervisor.Id))
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
            ViewData["ChairId"] = new SelectList(_context.Chair, "Id", "Name", supervisor.ChairId);
            return View(supervisor);
        }

        // GET: Supervisors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Supervisor == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisor
                .Include(s => s.Chair)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supervisor == null)
            {
                return NotFound();
            }

            return View(supervisor);
        }

        // POST: Supervisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Supervisor == null)
            {
                return Problem("Entity set 'AppDbContext.Supervisor'  is null.");
            }
            var supervisor = await _context.Supervisor.FindAsync(id);
            if (supervisor != null)
            {
                _context.Supervisor.Remove(supervisor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupervisorExists(int id)
        {
          return _context.Supervisor.Any(e => e.Id == id);
        }
    }
}
