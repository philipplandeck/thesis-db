using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThesisDatenbank.Areas.Identity.Data;
using ThesisDatenbank.Data;
using ThesisDatenbank.Models;

namespace ThesisDatenbank.Controllers
{
    [Authorize]
    public class SupervisorsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public SupervisorsController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Supervisors
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Supervisor.Include(s => s.Chair).Where(s => s.Chair != null);

            if (User.IsInRole("Administrator"))
            {
                ViewData["UserIsAdministrator"] = true;
            }
            else
            {
                ViewData["UserIsAdministrator"] = false;
                AppUser currentUser = await _userManager.GetUserAsync(User);
                Supervisor? supervisor = await _context.Supervisor.FirstOrDefaultAsync(s => s.UserId == currentUser.Id);
                ViewData["SupervisorExists"] = supervisor != null;
            }
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            AppUser currentUser = await _userManager.GetUserAsync(User);
            Supervisor supervisor = new()
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Email = currentUser.Email,
                Active = currentUser.Activity == AppUser.ActivityType.active,
                ChairId = currentUser.ChairId,
                Chair = currentUser.Chair,
                UserId = currentUser.Id,
                User = currentUser
            };
            _context.Add(supervisor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete()
        {
            AppUser currentUser = await _userManager.GetUserAsync(User);
            Supervisor? supervisor = await _context.Supervisor.FirstOrDefaultAsync(s => s.UserId == currentUser.Id);

            if (supervisor != null)
            {
                _context.Supervisor.Remove(supervisor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
