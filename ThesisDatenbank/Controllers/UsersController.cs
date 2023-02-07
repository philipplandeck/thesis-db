using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThesisDatenbank.Areas.Identity.Data;
using ThesisDatenbank.Data;
using ThesisDatenbank.Models;

namespace ThesisDatenbank.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UsersController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users
                .Include(u => u.Chair)
                .Where(u => u.Chair != null)
                .OrderBy(u => u.LastName)
                .ToListAsync());
        }

        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _userManager.Users == null)
            {
                return NotFound();
            }

            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            ViewData["ChairId"] = new SelectList(await _context.Chair.ToListAsync(), nameof(Chair.Id), nameof(Chair.Name), user.ChairId);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,Activity,ChairId")] AppUser newUser)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null || id != newUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    user.FirstName = newUser.FirstName;
                    user.LastName = newUser.LastName;
                    user.Activity = newUser.Activity;
                    user.ChairId = newUser.ChairId;

                    Supervisor? supervisor = await _context.Supervisor.FirstOrDefaultAsync(s => s.UserId == id);
                    if (supervisor != null)
                    {
                        supervisor.FirstName = user.FirstName;
                        supervisor.LastName = user.LastName;
                        supervisor.Active = user.Activity == AppUser.ActivityType.active;
                        supervisor.ChairId = user.ChairId;

                        _context.Update(supervisor);
                        await _context.SaveChangesAsync();
                    }

                    await _userManager.UpdateAsync(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool userExists = await _userManager.FindByIdAsync(id) != null;
                    if (!userExists)
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

            ViewData["ChairId"] = new SelectList(await _context.Chair.ToListAsync(), nameof(Chair.Id), nameof(Chair.Name), user.ChairId);
            return View(user);
        }
    }
}
