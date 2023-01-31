using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text;
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
            var appDbContext = _context.Thesis.Include(t => t.StudentProgram).Include(t => t.Supervisor)
                .Where(t => t.Status == Thesis.StatusType.Available || t.Status == Thesis.StatusType.Allocated);

            SelectList chairSelectList = new(_context.Chair, "Id", "Name");

            if (!string.IsNullOrEmpty(chairFilter))
            {
                appDbContext = appDbContext.Where(t => t.Supervisor != null && t.Supervisor.ChairId != null && t.Supervisor.ChairId.ToString() == chairFilter);
                chairSelectList.Where(x => x.Value.ToString() == chairFilter).First().Selected = true;
            }

            ViewData["ChairFilter"] = chairSelectList;

            await CreateEmails(appDbContext);

            return View(await appDbContext.ToListAsync());
        }

        public async Task CreateEmails(IQueryable<Thesis> theses)
        {
            foreach (Thesis thesis in theses)
            {
                if (thesis.SupervisorId != null)
                {
                    ViewData[thesis.SupervisorId.ToString()] = ParseEmail(thesis.Supervisor.FirstName, thesis.Supervisor.LastName);
                }
                else
                {
                    ViewData[thesis.SupervisorId.ToString()] = "";
                }
            }
        }

        static string ParseEmail(string firstName, string lastName)
        {
            string email = firstName.ToLower() + "." + lastName.ToLower() + "@uni-wuerzburg.de";
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char letter in email)
            {
                switch (letter)
                {
                    case 'ß':
                        stringBuilder.Append("ss");
                        break;
                    case 'ä':
                        stringBuilder.Append("ae");
                        break;
                    case 'ö':
                        stringBuilder.Append("oe");
                        break;
                    case 'ü':
                        stringBuilder.Append("ue");
                        break;
                    default:
                        stringBuilder.Append(letter);
                        break;
                }
            }

            return stringBuilder.ToString();
        }
    }
}
