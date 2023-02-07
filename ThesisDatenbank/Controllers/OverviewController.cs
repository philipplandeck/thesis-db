using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThesisDatenbank.Data;
using ThesisDatenbank.Models;

namespace ThesisDatenbank.Controllers
{
    public class OverviewController : Controller
    {
        private readonly AppDbContext _context;

        public OverviewController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? chairFilter)
        {
            var appDbContext = _context.Thesis.Include(t => t.Supervisor)
                .Where(t => t.Supervisor != null)
                .Where(t => t.Status == Thesis.StatusType.Available || t.Status == Thesis.StatusType.Allocated);

            SelectList chairSelectList = new(_context.Chair, "Id", "Name");

            if (!string.IsNullOrEmpty(chairFilter))
            {
                appDbContext = appDbContext.Where(t => t.Supervisor.ChairId.ToString() == chairFilter);
                chairSelectList.Where(x => x.Value.ToString() == chairFilter).First().Selected = true;
            }

            ViewData["ChairFilter"] = chairSelectList;

            return View(await appDbContext.OrderBy(t => t.Supervisor.Chair.Name).ToListAsync());
        }
    }
}
