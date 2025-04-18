using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN222_SP25_B5_RAZOR.Pages.LoadDB
{
    public class checkbox_as_radioModel : PageModel
    {
        private readonly Prn222Sp25B5Context ctx;

        public checkbox_as_radioModel(Prn222Sp25B5Context ctx)
        {
            this.ctx = ctx;
        }
        [BindProperty]
        public Student std { get; set; } = default;
        public void OnGet()
        {
            var ds = ctx.Departments.ToList();
            ViewData["ds"] = ds;
        }
    }
}
