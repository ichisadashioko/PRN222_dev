using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN222_SP25_B5_RAZOR.Models;

namespace PRN222_SP25_B5_RAZOR.Pages.LoadDB
{
    public class IndexModel : PageModel
    {
        private readonly Prn222Sp25B5Context ctx;

        public IndexModel(Prn222Sp25B5Context ctx)
        {
            this.ctx = ctx;
        }
        public void OnGet()
        {
            var st = ctx.Students.Include(s => s.Depart).ToList();
            ViewData["st"] = st;
            var ds = ctx.Departments.ToList();
            ViewData["ds"] = ds;
        }
    }
}
