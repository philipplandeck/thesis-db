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
            return View(await _userManager.Users.Include(s => s.Chair).ToListAsync());
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
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,ChairId, Activity")] AppUser newUser)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            if (id != newUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    user.FirstName = newUser.FirstName;
                    user.LastName = newUser.LastName;
                    if (newUser.ChairId == 0)
                    {
                        user.ChairId = null;
                    }
                    else
                    {
                        user.ChairId = newUser.ChairId;
                    }
                    user.ChairId = newUser.ChairId;
                    user.Activity = newUser.Activity;
                    await _userManager.UpdateAsync(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool userExists = await _userManager.FindByIdAsync(user.Id.ToString()) != null;
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
