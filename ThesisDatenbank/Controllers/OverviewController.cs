using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
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

        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Thesis.Include(t => t.StudentProgram).Include(t => t.Supervisor)
                .Where(x => x.Status == Thesis.StatusType.Available || x.Status == Thesis.StatusType.Allocated)
                .OrderBy(x => x.Supervisor.ChairId);

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
            return RemoveDiacritics(email);
        }

        /* According to Stack Overflow
         * https://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net
         */
        static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }
    }
}
